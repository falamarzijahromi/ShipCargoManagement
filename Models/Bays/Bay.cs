using Rahyab.Framework.Domain;
using Rahyab.Operation.Domain.Contracts.Events.Hatches;
using Rahyab.Operation.Domain.Models.Hatches.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches.Bays
{
    public class Bay : Entity<BayId>
    {
        protected Bay(Guid voyageId, int hatchId, int bayNumber, int MinUnderDeckTier, int MaxOnDeckTier)
        {
            Id = new(voyageId, hatchId, bayNumber);

            VoyageId = voyageId;
            HatchId = hatchId;
            BayNumber = bayNumber;

            this.MinUnderDeckTier = MinUnderDeckTier;
            this.MaxOnDeckTier = MaxOnDeckTier;
        }


        public static Bay CreateBay(Guid voyageId, int hatchId, int bayNumber, int minUnderDeckTier, int maxOnDeckTier, int rowsCount, int maxUnderDeckTier, int minOnDeckTier)
        {
            var bay = new Bay(voyageId, hatchId, bayNumber, minUnderDeckTier, maxOnDeckTier);

            bay.CreateRows(rowsCount, maxUnderDeckTier, minOnDeckTier, minUnderDeckTier);

            return bay;
        }



        public Guid VoyageId { get; private set; }
        public int HatchId { get; private set; }
        public int BayNumber { get; private set; }

        public int MinUnderDeckTier { get; }
        public int MaxOnDeckTier { get; }

        public List<Row> Rows { get; private set; } = new();





        public void Register(BayRegistration registration)
        {
            TierNumberIsNotValidException.Check(registration.TierNumber, MinUnderDeckTier, MaxOnDeckTier);

            var rowToReceit = GetRow(registration.RowNumber);

            rowToReceit.Register(registration);
        }

        public void SetNotAlloweds(List<(int row, int tier)> notAlloweds)
        {
            var groupedNotAllowed = notAlloweds.GroupBy(n => n.row);

            foreach (var group in groupedNotAllowed)
            {
                var row = Rows.Single(r => r.RowNumber == group.Key);

                var notAllowedTiers = group.Select(n => n.tier).ToList();

                row.NotAllowedTiers = notAllowedTiers;
            }
        }



        internal void Update(Bay bay)
        {
            Rows.Clear();

            HatchId = bay.HatchId;
            BayNumber = bay.BayNumber;

            Rows.AddRange(bay.Rows);
        }

        internal static HatchBaysSetEvent CreateHatchBaysSetEvent(List<Bay> bays, Guid voyageId, int hatchNumber)
        {
            var @event = new HatchBaysSetEvent
            {
                HatchNumber = hatchNumber,
                VoyageId = voyageId,
            };

            var bayStates = new List<BayStateEventDTO>();

            foreach (var bay in bays)
            {
                BayEventDTO bayToAdd = new()
                {
                    BayNumber = bay.BayNumber,
                    MaxOnDeckTierTier = bay.MaxOnDeckTier,
                    MinUnderDeckTier = bay.MinUnderDeckTier,
                };

                FillBayStates(bayStates, bay);

                @event.Bays.Add(bayToAdd);
            }


            return @event;
        }

        private static void FillBayStates(List<BayStateEventDTO> bayStates, Bay bay)
        {
            var underDeckStates = bay.Rows
                .SelectMany(r => r.UnderDeckTiers)
                .Where(r => !r.IsBlank)
                .Select(r => new BayStateEventDTO
                {
                    BayNumber = bay.BayNumber,
                    RowNumber = r.RowNumber,
                    TierNumber = r.TierNumber,
                    Size = r.Size,

                }).ToList();

            bayStates.AddRange(underDeckStates);

            var onDeckStates = bay.Rows
                .SelectMany(r => r.OnDeckTiers)
                .Where(r => !r.IsBlank)
                .Select(r => new BayStateEventDTO
                {
                    BayNumber = bay.BayNumber,
                    RowNumber = r.RowNumber,
                    TierNumber = r.TierNumber,
                    Size = r.Size,

                }).ToList();

            bayStates.AddRange(onDeckStates);
        }

        private Row GetRow(int row)
        {
            var result = Rows.SingleOrDefault(r => r.RowNumber == row);

            RowNumberNotExistsException.Check(result, row, BayNumber);

            return result;
        }

        private void CreateRows(int rowsCount, int maxUnderDeckTier, int minOnDeckTier, int minUnderDeckTier)
        {
            var index = 1;

            if (rowsCount.IsOdd())
            {
                rowsCount -= 1;
                index = 0;
            }

            for (; index <= rowsCount; index++)
            {
                Row rowToAdd = new(index, maxUnderDeckTier, minUnderDeckTier, minOnDeckTier);

                Rows.Add(rowToAdd);
            }
        }
    }
}

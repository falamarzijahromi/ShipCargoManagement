using Rahyab.Framework.Domain;
using Rahyab.Framework.SharedKernel.Container;
using Rahyab.Operation.Domain.Contracts.Events.Hatches;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using Rahyab.Operation.Domain.Models.Hatches.Exceptions;
using Rahyab.Operation.Domain.Models.Jobs;
using Rahyab.Operation.Domain.Models.Voyages.Structures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches
{
    public abstract class Hatch : AggregateRoot<HatchId>
    {
        public Hatch(Guid voyageId, int hatchNumber)
        {
            Id = new HatchId(voyageId, hatchNumber);

            VoyageId = voyageId;
            HatchNumber = hatchNumber;
        }



        public Guid VoyageId { get; }

        public int HatchNumber { get; }

        public List<Bay> Bays { get; set; } = new();


        public virtual void LoadJob(VoyageStructure structure, Job job, int bay, int row, int tier)
        {
            BayIsNotForHatchException.Check(Bays, bay, HatchNumber);

            Only20FootContainersAllowedException.Check(job.Container.Size, bay);

            structure.CheckJobReception(job, HatchNumber, bay, row, tier);

            LoadContainer(job.Container.Size, bay, row, tier);

            var @event = new JobReceitedEvent
            {
                BayNumber = bay,
                HatchNumber = HatchNumber,
                JobId = job.Id,
                RowNumber = row,
                TierNumber = tier,
                VoyageId = VoyageId,
                Size = job.Container.Size,
            };

            Publish(@event);
        }

        public virtual void LoadContainer(ContainerSize size, int bay, int row, int tier)
        {
            var bayToRegister = Bays.Single(b => b.BayNumber == bay);

            var registration = new BayRegistration(row, tier, size, false);

            bayToRegister.Register(registration);
        }

        public virtual void SetBays(List<Bay> bays)
        {
            HatchMustHaveOneBayException.Check(bays);

            RemoveCandidateBays(bays);

            UpsertBays(bays);

            var @event = Bay.CreateHatchBaysSetEvent(bays, VoyageId, HatchNumber);

            Publish(@event);
        }

        private void UpsertBays(List<Bay> bays)
        {
            foreach (var bay in bays)
            {
                var bayToUpdate = Bays.SingleOrDefault(b => b.BayNumber == bay.BayNumber);

                if (bayToUpdate is not null)
                {
                    bayToUpdate.Update(bay);
                }
                else
                {
                    Bays.Add(bay);
                }
            }
        }

        private void RemoveCandidateBays(List<Bay> bays)
        {
            var baysToRemove = Bays.Where(b => bays.Any(bay => bay.BayNumber != b.BayNumber)).ToList();

            foreach (var bay in baysToRemove)
            {
                Bays.Remove(bay);
            }
        }
    }
}

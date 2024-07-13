using Rahyab.Framework.SharedKernel.Container;
using Rahyab.Operation.Application.Contracts.Commands.Voyages;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Application.Hatches.Factoires
{
    public class BayFactory
    {
        private readonly Guid voyageId;
        private readonly HatchDTO hatch;

        public BayFactory(Guid voyageId, HatchDTO hatch)
        {
            this.voyageId = voyageId;
            this.hatch = hatch;
        }

        public List<Bay> CreateBays()
        {
            List<Bay> results = new();

            foreach (var bay in hatch.Bays)
            {
                var bayToAdd = CreateBay(bay);

                results.Add(bayToAdd);
            }

            return results;
        }

        private Bay CreateBay(BayDTO bay)
        {
            var result = Bay.CreateBay(voyageId, hatch.Number, bay.Number, hatch.MinUnderDeckTier, hatch.MaxOnDeckTier, hatch.RowCount, hatch.MaxUnderDeckTier, hatch.MinOnDeckTier);

            SetBayBlanks(bay.BayBlanks, result);

            SetNotAlloweds(bay.NotAlloweds, result);

            return result;
        }

        private static void SetNotAlloweds(List<BayNotAllowedDTO> notAlloweds, Bay result)
        {
            var notAllowedsList = notAlloweds.Select(n => (n.Row, n.Tier)).ToList();

            result.SetNotAlloweds(notAllowedsList);
        }

        private static void SetBayBlanks(List<BayBlankDTO> bayBlanks, Bay result)
        {
            var registrationSize = result.BayNumber.IsEven() ? ContainerSize.Size40 : ContainerSize.Size20;

            var groupedByRow = bayBlanks.GroupBy(b => b.Row);

            foreach (var rowGroup in groupedByRow)
            {
                var orderedByTier = rowGroup.OrderBy(r => r.Tier);

                foreach (var blank in orderedByTier)
                {
                    var blankRegistration = new BayRegistration(blank.Row, blank.Tier, registrationSize, true);

                    result.Register(blankRegistration);
                }
            }
        }
    }
}

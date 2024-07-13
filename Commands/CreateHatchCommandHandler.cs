using Rahyab.Framework.Application.Command;
using Rahyab.Framework.SharedKernel.Container;
using Rahyab.Operation.Application.Contracts.Commands.Hatches;
using Rahyab.Operation.Domain.Models.Hatches;
using System.Linq;
using Rahyab.Operation.Application.Hatches.Factoires;
using System;

namespace Rahyab.Operation.Application.Hatches
{
    public class CreateHatchCommandHandler : ICommandHandler<UpsertHatchCommand>
    {
        private readonly IHatchRepository repository;

        public CreateHatchCommandHandler(IHatchRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(UpsertHatchCommand command)
        {
            Hatch hatch = GetHatchFor(command.VoyageId, command.Hatch.Type, command.Hatch.Number);

            var bayFactory = new BayFactory(command.VoyageId, command.Hatch);

            var bays = bayFactory.CreateBays(command.VoyageId, command.Hatch);

            hatch.SetBays(bays);

            SetHatchInitialStates(command, hatch);

            repository.Create(hatch);
        }

        private Hatch GetHatchFor(Guid voyageId, string bayType, int hatchNumber)
        {
            var hatchId = new HatchId(voyageId,hatchNumber);

            var hatch = repository.Get(hatchId);

            if (hatch is null)
                hatch = HatchFactory.CreateHatch(voyageId, bayType, hatchNumber);

            return hatch;
        }

        private static void SetHatchInitialStates(UpsertHatchCommand command, Hatch hatch)
        {
            var filteredSelections = command.BaySelections
                .Where(bs => bs.HatchNumber == hatch.HatchNumber)
                .Where(bs => bs.OperationType is VoyageOperationTypes.Discharge)
                .ToList();


            var groupOrderByTier = filteredSelections
                .GroupBy(bs => bs.Tier)
                .OrderBy(gr => gr.Key)
                .ToList();


            foreach (var tierGroup in groupOrderByTier)
            {
                foreach (var container in tierGroup)
                {
                    hatch.LoadContainer(container.Size, container.BayNumber, container.Row, container.Tier);
                }
            }
        }
    }
}

using Rahyab.Framework.Application.Command;
using Rahyab.Operation.Application.Contracts.Commands.Hatches;
using Rahyab.Operation.Domain.Models.Hatches;
using Rahyab.Operation.Domain.Models.Jobs;
using Rahyab.Operation.Domain.Models.Voyages.Structures;

namespace Rahyab.Operation.Application.Hatches
{
    public class ReceitJobCommandHandler : ICommandHandler<ReceitJobCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly IHatchRepository hatchRepository;
        private readonly IVoyageStructureRepository voyageStructureRepository;

        public ReceitJobCommandHandler(
            IJobRepository jobRepository,
            IHatchRepository hatchRepository,
            IVoyageStructureRepository voyageStructureRepository)
        {
            this.jobRepository = jobRepository;
            this.hatchRepository = hatchRepository;
            this.voyageStructureRepository = voyageStructureRepository;
        }

        public void Handle(ReceitJobCommand command)
        {
            var job = jobRepository.Get(command.JobId);

            var structure = voyageStructureRepository.Get(command.VoyageId);

            int hatchNumber = structure.GetHatchNumber(command.BayNumber);

            var hatch = hatchRepository.Get(new HatchId(command.VoyageId, hatchNumber));

            hatch.LoadJob(structure, job, command.BayNumber, command.RowNumber, command.TierNumber);

            hatchRepository.Update(hatch);
        }
    }
}

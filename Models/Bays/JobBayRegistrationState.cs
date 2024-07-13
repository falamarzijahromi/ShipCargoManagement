using Rahyab.Framework.SharedKernel.Container;

namespace Rahyab.Operation.Domain.Models.Hatches.Bays
{

    public class JobBayRegistrationState : RegistrationState
    {
        public JobBayRegistrationState(ContainerSize containerSize)
        {
            ContainerSize = containerSize;
        }



        public ContainerSize ContainerSize { get; }



        public override bool CanDischarge() => true;

        public override bool CanPutOver(ContainerSize size)
        {
            return ContainerSize.Equals(ContainerSize.Size20) ? true : (ContainerSize.TEU.Equals(size.TEU));
        }
    }
}

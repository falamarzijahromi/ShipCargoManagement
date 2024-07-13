using Rahyab.Framework.SharedKernel.Container;

namespace Rahyab.Operation.Domain.Models.Hatches.Bays
{
    public class Job40FootSideEffectRegistrationState : RegistrationState
    {
        public override bool CanDischarge() => true;

        public override bool CanPutOver(ContainerSize size)
        {
            return (size.TEU.Equals(ContainerSize.Size40.TEU));
        }
    }
}

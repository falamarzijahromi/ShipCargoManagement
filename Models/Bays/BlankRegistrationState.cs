using Rahyab.Framework.SharedKernel.Container;

namespace Rahyab.Operation.Domain.Models.Hatches.Bays
{
    public class BlankRegistrationState : RegistrationState
    {
        public override bool CanDischarge() => false;

        public override bool CanPutOver(ContainerSize size) => true;
    }
}

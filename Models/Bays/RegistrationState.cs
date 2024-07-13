using Rahyab.Framework.SharedKernel.Container;

namespace Rahyab.Operation.Domain.Models.Hatches.Bays
{
    public abstract class RegistrationState
    {
        public abstract bool CanDischarge();

        public abstract bool CanPutOver(ContainerSize size);
    }
}

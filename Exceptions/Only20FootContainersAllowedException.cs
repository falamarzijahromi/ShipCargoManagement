using Rahyab.Framework.Core.Exceptions;
using Rahyab.Framework.SharedKernel.Container;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Only20FootContainersAllowedException : BusinessException
    {
        private Only20FootContainersAllowedException() { }

        public override string Message => "Only 20 Foot Containers Allowed For Odd Bay Numbers";

        internal static void Check(ContainerSize size, int bay)
        {
            if (size.Equals(ContainerSize.Size20) && bay.IsEven())
                throw new Only20FootContainersAllowedException();
        }
    }
}

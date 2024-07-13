using Rahyab.Framework.Core.Exceptions;
using Rahyab.Framework.SharedKernel.Container;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Double20FootHatchesLoadException : BusinessException
    {
        private Double20FootHatchesLoadException() { }

        public override string Message => "Double 20 Foot Hatches Only Load 20 Foot Containers.";

        internal static void Check(ContainerSize size)
        {
            if (!size.Equals(ContainerSize.Size20))
                throw new Double20FootHatchesLoadException();
        }
    }
}

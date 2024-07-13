using Rahyab.Framework.Core.Exceptions;
using Rahyab.Framework.SharedKernel.Container;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Single40FootHatchesLoadException : BusinessException
    {
        private Single40FootHatchesLoadException() { }

        public override string Message => "Single 40 Foot Hatches Only Load 40 Foot Containers.";

        internal static void Check(ContainerSize size)
        {
            if (!size.Equals(ContainerSize.Size40))
                throw new Single40FootHatchesLoadException();
        }
    }
}

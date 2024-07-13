using Rahyab.Framework.Core.Exceptions;
using Rahyab.Framework.SharedKernel.Container;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Single20FootHatchLoadException : BusinessException
    {
        private Single20FootHatchLoadException() { }

        public override string Message => "Single 20 Foot Hatches Only Load 20 Foot Containers.";

        internal static void Check(ContainerSize size)
        {
            if (!size.Equals(ContainerSize.Size20))
            {
                throw new Single20FootHatchLoadException();
            }
        }
    }
}

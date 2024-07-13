using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Single20FootHatchMustHaveOneBayException : BusinessException
    {
        private Single20FootHatchMustHaveOneBayException() { }

        public override string Message => "Single 20 Foot Hatch Must Have Only One Bay";

        internal static void Check(int baysCount)
        {
            if (baysCount > 1)
                throw new Single20FootHatchMustHaveOneBayException();
        }
    }
}

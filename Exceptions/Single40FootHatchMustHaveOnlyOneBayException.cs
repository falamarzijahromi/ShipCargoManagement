using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Single40FootHatchMustHaveOnlyOneBayException : BusinessException
    {
        private Single40FootHatchMustHaveOnlyOneBayException() { }

        public override string Message => "Single 40 Foot Hatch Must Have Only One Bay";

        internal static void Check(int baysCount)
        {
            if (baysCount > 1)
                throw new Single40FootHatchMustHaveOnlyOneBayException();
        }
    }
}

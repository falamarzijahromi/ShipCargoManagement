using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Support40FootHatchesRequires2OddBaysException : BusinessException
    {
        private Support40FootHatchesRequires2OddBaysException() { }

        public override string Message => "Support 40 Foot Hatches Requires 2 Odd Bays And One Even Bay.";

        internal static void Check(int baysCount)
        {
            if (baysCount != 3)
                throw new Support40FootHatchesRequires2OddBaysException();
        }
    }
}

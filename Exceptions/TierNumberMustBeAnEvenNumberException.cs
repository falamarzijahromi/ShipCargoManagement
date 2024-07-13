using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class TierNumberMustBeAnEvenNumberException : BusinessException
    {
        private TierNumberMustBeAnEvenNumberException() { }

        public override string Message => "Tier Number Must Be an Even Number";

        internal static void Check(int tierNumber)
        {
            if (tierNumber % 2 != 0)
                throw new TierNumberMustBeAnEvenNumberException();
        }
    }
}

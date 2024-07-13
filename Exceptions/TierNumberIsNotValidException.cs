using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class TierNumberIsNotValidException : BusinessException
    {
        private TierNumberIsNotValidException() { }

        public override string Message => "Tier Number Is Not Valid";

        internal static void Check(int tierNumber, int minUnderDeckTier, int maxOnDeckTier)
        {
            if (tierNumber < minUnderDeckTier || tierNumber > maxOnDeckTier)
                throw new TierNumberIsNotValidException();
        }
    }
}

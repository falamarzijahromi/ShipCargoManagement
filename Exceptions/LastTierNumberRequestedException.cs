using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class LastTierNumberRequestedException : BusinessException
    {
        private int tierNumber;

        public LastTierNumberRequestedException(int tierNumber)
        {
            this.tierNumber = tierNumber;
        }

        public override string Message => $"Last Tier Number On Requested Row Is {tierNumber}";
    }
}

using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class TierIsNotAllowedException : BusinessException
    {
        public override string Message => "Tier Is Not Allowed";
    }
}

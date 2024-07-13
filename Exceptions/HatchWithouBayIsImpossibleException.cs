using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class HatchWithouBayIsImpossibleException : BusinessException
    {
        public override string Message => "Hatch Without Bay Is Impossible!";
    }
}

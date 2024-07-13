using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class HatchDoesNotSipport40FootException : BusinessException
    {
        public override string Message => "Requested Hatch Does Not Support 40 Foot Containers.";
    }
}

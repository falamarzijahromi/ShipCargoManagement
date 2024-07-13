using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class RequestedBayIsNotExistsException : BusinessException
    {
        public override string Message => "Requested Bay Is Not Exists";
    }
}

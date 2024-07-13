using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class BelowContainerIsNotSuitableException : BusinessException
    {
        public override string Message => "It Is Not Possible To Put It On The Container Below!";
    }
}

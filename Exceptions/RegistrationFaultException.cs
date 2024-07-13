using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class RegistrationFaultException : BusinessException
    {
        private readonly int rowNumber;
        private readonly int tierNumber;

        public RegistrationFaultException(int rowNumber, int tierNumber)
        {
            this.rowNumber = rowNumber;
            this.tierNumber = tierNumber;
        }

        public override string Message => $"Registration Problem On Postion Row: {rowNumber}, tier: {tierNumber}";
    }
}

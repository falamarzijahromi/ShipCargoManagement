using Rahyab.Framework.Core.Exceptions;
using Rahyab.Operation.Domain.Models.Hatches.Bays;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class RowNumberNotExistsException : BusinessException
    {
        private readonly int row;
        private readonly int bay;

        private RowNumberNotExistsException(int row, int bay)
        {
            this.row = row;
            this.bay = bay;
        }

        public override string Message => $"Row: {row} Not Exists In Bay: {bay}";

        internal static void Check(Row result, int row, int bayNumber)
        {
            if (result is null)
                throw new RowNumberNotExistsException(row, bayNumber);
        }
    }
}

using Rahyab.Framework.SharedKernel.Container;
using Rahyab.Operation.Domain.Models.Hatches.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Bays
{
    public class BayRegistration
    {
        public BayRegistration(int rowNumber, int tierNumber, ContainerSize size, bool isBlank)
        {
            TierNumberMustBeAnEvenNumberException.Check(tierNumber);

            RowNumber = rowNumber;
            TierNumber = tierNumber;
            IsBlank = isBlank;
            Size = size;
        }



        public int RowNumber { get; }
        public int TierNumber { get; }
        public bool IsBlank { get; }
        public ContainerSize Size { get; }



        public bool CanPutOver(ContainerSize size)
        {
            var result = true;

            if (!IsBlank)
                result = Size.Equals(ContainerSize.Size20) ? true : (Size.TEU.Equals(size.TEU));

            return result;
        }
    }
}

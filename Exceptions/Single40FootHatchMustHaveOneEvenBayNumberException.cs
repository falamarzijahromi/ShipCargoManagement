using Rahyab.Framework.Core.Exceptions;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Single40FootHatchMustHaveOneEvenBayNumberException : BusinessException
    {
        private Single40FootHatchMustHaveOneEvenBayNumberException() { }

        public override string Message => "Single 40 Foot Hatch Must Have One Bay With Even Number.";

        internal static void Check(System.Collections.Generic.List<Bays.Bay> bays)
        {
            var bay = bays.SingleOrDefault();

            if (bay is null || bay.BayNumber.IsEven())
            {
                throw new Single40FootHatchMustHaveOneEvenBayNumberException();
            }
        }
    }
}

using Rahyab.Framework.Core.Exceptions;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Single20FootHatchMustHaveOneOddBayException : BusinessException
    {
        private Single20FootHatchMustHaveOneOddBayException() { }

        public override string Message => "Single 20 Foot Hatch Must Have One Bay With Odd Number.";

        internal static void Check(List<Bay> bays)
        {
            var bay = bays.SingleOrDefault();

            if (bay is null || bay.BayNumber.IsEven())
                throw new Single20FootHatchMustHaveOneOddBayException();
        }
    }
}

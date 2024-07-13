using Rahyab.Framework.Core.Exceptions;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Double20FootHatchesBayNumbersException : BusinessException
    {
        private Double20FootHatchesBayNumbersException() { }

        public override string Message => "Double 20 Foot Hatche Bay Numbers Must Be Odd.";

        internal static void Check(List<Bay> bays)
        {
            var evenBayNumbers = bays.Where(b => b.BayNumber.IsEven());

            if (evenBayNumbers.Any())
                throw new Double20FootHatchesBayNumbersException();
        }
    }
}

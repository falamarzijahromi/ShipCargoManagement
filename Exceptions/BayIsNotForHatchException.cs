using Rahyab.Framework.Core.Exceptions;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class BayIsNotForHatchException : BusinessException
    {
        private readonly int bayNumber;
        private readonly int hatchNumber;

        private BayIsNotForHatchException(int bayNumber, int hatchNumber)
        {
            this.bayNumber = bayNumber;
            this.hatchNumber = hatchNumber;
        }

        public override string Message => $"Bay: {bayNumber} is not For Hatch: {hatchNumber}";

        internal static void Check(List<Bay> bays, int bayNumber, int hatchNumber)
        {
            if (!bays.Any(b => b.BayNumber == bayNumber))
                throw new BayIsNotForHatchException(bayNumber, hatchNumber);
        }
    }
}

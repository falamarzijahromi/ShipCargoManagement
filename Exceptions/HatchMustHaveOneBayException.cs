using Rahyab.Framework.Core.Exceptions;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class HatchMustHaveOneBayException : BusinessException
    {
        private HatchMustHaveOneBayException() { }

        public override string Message => "Hatch Must Have At Least One Bay.";

        internal static void Check(List<Bay> bays)
        {
            if (!bays.Any())
                throw new HatchMustHaveOneBayException();
        }
    }
}

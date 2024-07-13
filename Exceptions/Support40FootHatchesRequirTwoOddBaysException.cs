using Rahyab.Framework.Core.Exceptions;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Support40FootHatchesRequirTwoOddBaysException : BusinessException
    {
        private Support40FootHatchesRequirTwoOddBaysException() { }

        public override string Message => "Support 40 Foot Hatches Require Two Odd Bays Number Greater And Lesser Than The Even Bay Number";

        internal static void Check(List<Bay> bays, Bay singleOddBay)
        {
            var lesserOddBay = bays.SingleOrDefault(b => b.BayNumber == singleOddBay.BayNumber - 1);
            var greaterOddBay = bays.SingleOrDefault(b => b.BayNumber == singleOddBay.BayNumber + 1);

            if (lesserOddBay is null || greaterOddBay is null)
                throw new Support40FootHatchesRequirTwoOddBaysException();
        }
    }
}

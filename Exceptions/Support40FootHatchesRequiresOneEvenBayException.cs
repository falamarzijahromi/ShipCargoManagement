using Rahyab.Framework.Core.Exceptions;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Support40FootHatchesRequiresOneEvenBayException : BusinessException
    {
        private Support40FootHatchesRequiresOneEvenBayException() { }

        public override string Message => "Support 40 Foot Hatches Require One Even Bay.";

        internal static void CheckForSingleOddBay(List<Bay> bays, out Bay singleOddBay)
        {
            singleOddBay = bays.SingleOrDefault(b => BayNumber.IsEvent());

            if (singleOddBay is null)
                throw new Support40FootHatchesRequiresOneEvenBayException();
        }
    }
}

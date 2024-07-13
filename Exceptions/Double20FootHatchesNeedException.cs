using Rahyab.Framework.Core.Exceptions;

namespace Rahyab.Operation.Domain.Models.Hatches.Exceptions
{
    public class Double20FootHatchesNeedException : BusinessException
    {
        private Double20FootHatchesNeedException() { }

        public override string Message => "Double 20 Foot Hatches Required 2 Odd Bays.";

        internal static void Check(int baysCount)
        {
            if (baysCount != 2)
                throw new Double20FootHatchesNeedException();
        }
    }
}

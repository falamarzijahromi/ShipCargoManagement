using Rahyab.Operation.Domain.Models.Hatches;
using System;

namespace Rahyab.Operation.Application.Hatches.Factoires
{
    public static class HatchFactory
    {
        public static Hatch CreateHatch(Guid voyageId, string bayType, int hatchNumber)
        {
            return bayType switch
            {
                "Single20Foot" => new Single20FootHatch(voyageId, hatchNumber),
                "Single40Foot" => new Single40FootHatch(voyageId, hatchNumber),
                "Double20Foot" => new Double20FootHatch(voyageId, hatchNumber),
                "Support40Foot" => new Support40FootHatch(voyageId, hatchNumber),
                _ => throw new Exception("Hatch Is Not Supported For Operation"),
            };
        }
    }
}

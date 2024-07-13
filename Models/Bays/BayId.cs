using Rahyab.Framework.Domain;
using System;

namespace Rahyab.Operation.Domain.Models.Hatches.Bays
{
    public class BayId : ValueObject
    {
        public BayId(Guid voyageId, int hatchId, int bayNumber)
        {
            VoyageId = voyageId;
            HatchId = hatchId;
            BayNumber = bayNumber;
        }

        public Guid VoyageId { get; }
        public int HatchId { get; }
        public int BayNumber { get; }
    }
}

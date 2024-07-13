using Rahyab.Framework.Domain;
using System;

namespace Rahyab.Operation.Domain.Models.Hatches
{
    public class HatchId : ValueObject
    {
        public HatchId(Guid voyageId, int hatchNumber)
        {
            VoyageId = voyageId;
            HatchNumber = hatchNumber;
        }

        public Guid VoyageId { get; }
        public int HatchNumber { get; }
    }
}

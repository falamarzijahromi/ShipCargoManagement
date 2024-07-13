using Rahyab.Framework.Domain;
using System;

namespace Rahyab.Operation.Domain.Models.Hatches.Bays
{
    public class RowId : ValueObject
    {
        public RowId(Guid voyageId, int hatchId, int bayNumber, int rowNumber)
        {
            VoyageId = voyageId;
            HatchId = hatchId;
            BayNumber = bayNumber;
            RowNumber = rowNumber;
        }

        public Guid VoyageId { get; }
        public int HatchId { get; }
        public int BayNumber { get; }
        public int RowNumber { get; }
    }
}

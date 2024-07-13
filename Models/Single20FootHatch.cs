using Rahyab.Framework.SharedKernel.Container;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using Rahyab.Operation.Domain.Models.Hatches.Exceptions;
using System;
using System.Collections.Generic;

namespace Rahyab.Operation.Domain.Models.Hatches
{
    public class Single20FootHatch : Hatch
    {
        public Single20FootHatch(Guid voyageId, int hatchNumber) 
            : base(voyageId, hatchNumber)
        {
        }


        public override void LoadContainer(ContainerSize size, int bay, int row, int tier)
        {
            Single20FootHatchLoadException.Check(size);

            base.LoadContainer(size, bay, row, tier);
        }

        public override void SetBays(List<Bay> bays)
        {
            base.SetBays(bays);

            Single20FootHatchMustHaveOneBayException.Check(bays.Count);

            Single20FootHatchMustHaveOneOddBayException.Check(bays);
        }
    }
}

using Rahyab.Framework.SharedKernel.Container;
using Rahyab.Operation.Domain.Models.Hatches.Bays;
using Rahyab.Operation.Domain.Models.Hatches.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches
{
    public class Support40FootHatch : Hatch
    {
        public Support40FootHatch(Guid voyageId, int hatchNumber) 
            : base(voyageId, hatchNumber)
        {
        }


        public override void LoadContainer(ContainerSize size, int bay, int row, int tier)
        {
            base.LoadContainer(size, bay, row, tier);

            if (bay.IsEven())
                RegisterSideEffects(size, bay, row, tier);
        }

        public override void SetBays(List<Bay> bays)
        {
            base.SetBays(bays);

            Support40FootHatchesRequires2OddBaysException.Check(bays.Count);

            Support40FootHatchesRequiresOneEvenBayException.CheckForSingleOddBay(bays, out var singleOddBay);

            Support40FootHatchesRequirTwoOddBaysException.Check(bays, singleOddBay);
        }



        private void RegisterSideEffects(ContainerSize size, int bay, int row, int tier)
        {
            var sideEffectBays = Bays.Where(b => b.BayNumber != bay).Select(b => b.BayNumber);

            foreach (var bayToSideEffect in sideEffectBays)
            {
                LoadContainer(size, bayToSideEffect, row, tier);
            }
        }
    }
}

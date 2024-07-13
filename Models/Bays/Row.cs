using Rahyab.Framework.Domain;
using Rahyab.Framework.SharedKernel.Container;
using Rahyab.Operation.Domain.Models.Hatches.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rahyab.Operation.Domain.Models.Hatches.Bays
{
    public class Row : Entity<int>
    {
        public Row(int rowNumber, int maxUnderDeckTier, int minUnderDeckTier, int minOnDeckTier)
        {
            RowNumber = rowNumber;
            MaxUnderDeckTier = maxUnderDeckTier;
            MinUnderDeckTier = minUnderDeckTier;
            MinOnDeckTier = minOnDeckTier;
        }



        public Stack<BayRegistration> UnderDeckTiers { get; set; } = new();
        public Stack<BayRegistration> OnDeckTiers { get; set; } = new();
        public int RowNumber { get; }
        public int MaxUnderDeckTier { get; }
        public int MinUnderDeckTier { get; }
        public int MinOnDeckTier { get; }
        public List<int> NotAllowedTiers { get; set; } = new();



        public void Register(BayRegistration registration)
        {
            CheckValidTier(registration.TierNumber, out var lastRegistration);

            CheckValidSize(registration.Size, lastRegistration);

            AddRegistration(registration);
        }



        private void AddRegistration(BayRegistration registration)
        {
            if (registration.TierNumber >= MinOnDeckTier)
            {
                OnDeckTiers.Push(registration);
            }
            else
            {
                UnderDeckTiers.Push(registration);
            }
        }

        private void CheckValidSize(ContainerSize size, BayRegistration regsitration)
        {
            if (regsitration is not null && !regsitration.CanPutOver(size))
            {
                throw new BelowContainerIsNotSuitableException();
            }
        }

        private void CheckValidTier(int tier, out BayRegistration regsitration)
        {
            if (NotAllowedTiers.Contains(tier))
            {
                throw new TierIsNotAllowedException();
            }

            if (tier > MaxUnderDeckTier && tier < MinOnDeckTier)
            {
                throw new TierNumberIsNotValidException();
            }

            var stackToPeek = (tier >= MinOnDeckTier) ? OnDeckTiers : UnderDeckTiers;

            regsitration = stackToPeek.IsEmpty() ? default : stackToPeek.Peek();

            if (regsitration is null && tier != MinUnderDeckTier && tier != MinOnDeckTier)
            {
                throw new RegistrationFaultException(RowNumber, tier);
            }

            if (regsitration is not null && (tier <= regsitration.TierNumber || tier - 2 != regsitration.TierNumber))
            {
                throw new LastTierNumberRequestedException(regsitration.TierNumber);
            }
        }
    }
}
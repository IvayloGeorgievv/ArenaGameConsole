using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLibrary;

namespace ArenaGame
{
    // When the Barbarian drops below certain health he will go into Rage mode where during RageDuration he is unable to take damage
    // Also during Rage he deals more damage
    public class Barbarian : Hero
    {
        protected bool IsInRage { get;private set; }
        protected int RageDuration { get; private set; }

        private int ragePhasesCount;

        public Barbarian(string name) : base(name)
        {
            IsInRage = false;
            RageDuration = 4;
            ragePhasesCount = 0;
        }

        public Barbarian(string name, Weapon weapon) : base(name, weapon)
        {
            IsInRage = false;
            RageDuration = 4;
            ragePhasesCount = 0;
        }

        public override int Attack()
        {
            if (IsInRage)
            {
                ragePhasesCount++;
                if (ragePhasesCount >= RageDuration)
                {
                    IsInRage = false;
                }

                int damageWithRage = base.Attack() + 25;

                return damageWithRage;
            }

            return base.Attack();
        }

        public override void TakeDamage(int incomingDamage)
        {
            //If his health is below 80 the Rage phase is triggered
            if(Health <= 80 && !IsInRage)
            {
                IsInRage = true;
                ragePhasesCount = 0;
                return;
            }
            if(IsInRage)
            {
                ragePhasesCount++;
                if (ragePhasesCount >= RageDuration)
                {
                    IsInRage = false;
                }
            }
            else
            {
                base.TakeDamage(incomingDamage);
            }
        }
    }
}

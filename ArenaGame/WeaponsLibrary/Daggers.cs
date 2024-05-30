using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLibrary
{
    public class Daggers : Weapon
    {
        protected int BleedingWoundsDamage { get; private set; }
        public Daggers(string name) : base(name)
        {
            Damage = DetermineDamage();
            BleedingWoundsDamage = 15;
            ActivateSpecialTraitNtnRound = 4;
            SpecialTraitDamage = BleedingWoundsDamage;
        }

        protected override int DetermineDamage()
        {
            return Random.Shared.Next(15, 35);
        }
    }
}

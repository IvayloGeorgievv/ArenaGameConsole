using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLibrary
{
    public class Greatsword : Weapon
    {
        protected int ExecutionerStrikeDamage { get; private set; }
        public Greatsword(string name) : base(name)
        {
            Damage = DetermineDamage();
            ExecutionerStrikeDamage = Random.Shared.Next(40,60);
            ActivateSpecialTraitNtnRound = 5;
            SpecialTraitDamage = ExecutionerStrikeDamage;
        }

        protected override int DetermineDamage()
        {
            return Random.Shared.Next(30, 60);
        }
    }
}

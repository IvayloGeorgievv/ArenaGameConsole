using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLibrary
{
    public class MageStaff : Weapon
    {
        protected int ElementalBurstDamage { get;private set; }
        public MageStaff(string name) : base(name)
        {
            Damage = DetermineDamage();
            ElementalBurstDamage = Random.Shared.Next(5, 25);// The Mage staff has a random Elemental burst damage between 5 and 25
            ActivateSpecialTraitNtnRound = 3; //Each 3rd round the trait will activate
            SpecialTraitDamage = ElementalBurstDamage;
        }

        protected override int DetermineDamage()
        {
            return Random.Shared.Next(10, 20);
        }
    }
}

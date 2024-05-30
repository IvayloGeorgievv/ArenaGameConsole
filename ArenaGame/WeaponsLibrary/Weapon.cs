using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLibrary
{
    public class Weapon
    {
        public string Name { get; private set; }
        public int Damage { get; protected set; }
        public int AttackCount { get; set; }
        public int ActivateSpecialTraitNtnRound { get; protected set; }
        public int SpecialTraitDamage { get; protected set; }

        public Weapon(string name)
        {
            Name = name;
            Damage = DetermineDamage();
            AttackCount = 0;
            ActivateSpecialTraitNtnRound = 0;
            SpecialTraitDamage = 0;
        }

        protected virtual int DetermineDamage()
        {
            return Random.Shared.Next(10,30);
        }

        protected bool ThrowDice(int chance)
        {
            int dice = Random.Shared.Next(101);
            return dice <= chance;
        }

    }
}

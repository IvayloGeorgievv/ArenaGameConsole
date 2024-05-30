using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLibrary;

namespace ArenaGame
{

    // The Mage hero is able to reflect damage to compansate for the lesser health. His reflection of damage does not cost Mana
    // That way he is more competitive with other hero types and has some chance in battle
    public class Mage : Hero
    {
        protected int Mana { get; private set; }
        protected int StartingMana { get; private set; }

        private const int ReflectMagicDigit = 3;
        private const int ManaCostPerAttack = 20;
        private const int RestoreManaEachNtnRound = 2;

        //Here the program keeps the damage of the attack if the Mage reflects it
        protected int ReflectedDamage { get; private set; }
        private bool isReflecting = false;

        private int spellCount;

        public Mage(string name) : base(name) 
        {
            Mana = 100;
            StartingMana = Mana;
            spellCount = 0;
        }
        public Mage(string name, Weapon weapon) : base(name, weapon)
        {
            Mana = 100;
            StartingMana = Mana;
            spellCount = 0;
        }

        public override int Attack()
        {
            //Mage cannot attack without mana but he can reflect the damage from the previous attack of the opponent
            if (Mana < ManaCostPerAttack)
            {
                int damageWithoutMana = 0;
                if(isReflecting) 
                {
                    isReflecting = false;
                    int reflectedDamage =  ReflectedDamage;
                    ReflectedDamage = 0;
                    damageWithoutMana += reflectedDamage;
                }
                
                //The Mage can restore some of his Mana even if he does not have any at the moment
                if (spellCount % RestoreManaEachNtnRound == 0 && ThrowDice(25))
                {
                    RestoreMana(StartingMana * 30 / 100);
                }

                return damageWithoutMana;
            }

            Mana -= ManaCostPerAttack;
            int attack = base.Attack() + ReflectedDamage;
            ReflectedDamage = 0;

            spellCount++;

            if (spellCount % RestoreManaEachNtnRound == 0 && ThrowDice(25))
            {
                RestoreMana(StartingMana * 30 / 100);
            }

            return attack;
        }

        private void RestoreMana(int mana)
        {
            Mana = Math.Min(Mana + mana, 100);
        }

        public override void TakeDamage(int incomingDamage)
        {
            // The reflection of damage just adds the damage of the opponent attack to the next attack of the Mage
            // That way it gives the other hero a chance to finish the Mage before a powerful blow from him
            if(incomingDamage % ReflectMagicDigit == 0 && ThrowDice(20))
            {
                isReflecting = true;
                ReflectDamage(incomingDamage);
                return;
            }

            base.TakeDamage(incomingDamage);
        }

        private void ReflectDamage(int damage)
        {
            ReflectedDamage = damage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tamagotchi
{
    class Tamagotchi
    {
        // variables:
        private int age;
        private int health;
        private int energy;
        private int hunger;
        private bool isDead;
        private bool isSleeping;
        private bool hasPooped;
        private int ticks;

        private Timer updateTimer;

        public int Age { get { return age; } }
        public int Health { get { return health; } }
        public int Energy { get { return energy; } }
        public int Hunger { get { return hunger; } }
        public bool IsDead { get { return isDead; } }
        public bool IsSleeping { get { return isSleeping; } }

        private const int maxHealth = 100;
        private const int maxEnergy = 100;
        private const int maxHunger = 100;
        private const int poopLimit = 20;
        private const int energyRegen = 2;
        private const int sleepingHunger = 2;
        private const int awakeHunger = 4;
        private const int healthDrain = 5;
        private const int energyUsage = 5;

        public Tamagotchi()
        {
            age = 0;
            health = maxHealth;
            energy = maxEnergy;
            hunger = 0;
            isDead = false;
            isSleeping = false;
            hasPooped = false;

            updateTimer = new Timer(Update, null, 0, 1000);
        }

        public void Update(object state)
        {
            if (!isDead)
            {
                ticks++;

                if ( ticks >= 100)
                {
                    ticks = 0;
                    age++;
                }

                if (energy == 0)
                {
                    Sleep();
                }

                if (isSleeping)
                {
                    energy = Math.Min(maxEnergy, energy + energyRegen);
                    if (energy >= maxEnergy)
                    {
                        Wake();
                    }

                    hunger = Math.Min(maxHunger, hunger + sleepingHunger);
                }
                else
                {
                    hunger = Math.Min(maxHunger, hunger + awakeHunger);
                    energy = Math.Max(0, energy - energyUsage);
                }

                if (hunger >= maxHunger)
                {
                    health = Math.Max(0, health - healthDrain);
                }

                if (health <= 0)
                {
                    Die();
                }
            }
        }

        public void Feed(int feedAmount)
        {
            hunger = Math.Max(0, hunger - feedAmount);
            Wake();
        }

        private void Poop()
        {
            hunger = Math.Min(maxHunger, hunger + (hunger/100)*10);
            hasPooped = true;
        }

        public void Sleep()
        {
            isSleeping = true;
        }

        public void Wake()
        {
            isSleeping = false;
        }

        private void Die()
        {
            isDead = true;
        }

        public bool SaveState()
        {
            return true;
        }

        public void LoadState()
        {

        }
    }
}

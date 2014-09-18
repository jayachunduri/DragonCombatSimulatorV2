using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatV2
{
    public class Enemy: GamePlayer
    {
        //As it inherits all the properties of parent class, not declaring the properties
                
        //constructor
        public Enemy()
        {
            this.name = "Dragon";
            this.health = 200;
        }

        public Enemy(string name)
        {
            this.name = name;
            this.health = 100;
        }

        public Enemy(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

       //Returns the emount of damage for enemy health after the attach.
        public override int DoAttach()
        {
            Random rng = new Random();
            int random = rng.Next(1, 101);
            if (random <= 80) //means dragon got hit
            {
                Console.WriteLine("\nDragon got the hit");
                return rng.Next(5, 16);
            }
            else //means dragon missed
            {
                Console.WriteLine("\nDragon missed!!!!");
            }
            return 0;
        }

        //It takes how much damage the enemy done to the player
        public override void TakeDamage(int damage)
        {
            this.health = this.health - damage;
        }
   
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatV2
{
    class Game
    {
        //declaring properties
        Player user;
        Enemy dragon;

        //Constructor
        public Game()
        {
            Console.Write("Enter your name: ");
            this.user = new Player(Console.ReadLine());
            this.dragon = new Enemy("Dragon", 200);
        }

        public Game(Player user, Enemy dragon)
        {
            this.user = user;
            this.dragon = dragon;
        }

        //Function to greet the user.
        public void Greet()
        {
            Console.WriteLine("\nWelcome to DRAGON HIT, " +this.user.name);
            Console.WriteLine("\ntype \"HELP\" for the introduction \n or Press enter to skip the introduction:");
            string temp = Console.ReadLine();

            if (temp == "")
                return;
            else if (temp.ToLower() == "help")
            {
                Console.WriteLine(@"
THE STORY: There once was kingdom full of riches. 
One day a very big dragon came to the kingdom. 
It started destroying the kingdom , and everyone got scared.
Everyone except king, queen and few brave warriors fled the kingdom. 
They fight with the dragon, but sadly there was only one warrior and king were left alive.
Now it's that brave warriors turn to kill the dragon and save the king and his kingdom. 

THAT WARRIOR IS YOU. 

You will have 3 choices to hit the Dragon. 
SWORD: 70% chance. It will do 20-35 damage.
FIREBALL: Always hits. It will do 10-15 damage.
HEAL: Heals the player for 10-20 HP

After your hit, Dragon's turn to hit you.

Welcome to the game: DRAGON HIT!

    ");
            }
        }

            //Displays current health of player and enemy
        public void DisplayCombatInfo()
        {
            Console.WriteLine(user.name + " health: " + user.health + "\n" + dragon.name + " health: " + dragon.health);
        }

        //Actual game logic
        public void PlayGame()
        {
            while (user.IsAlive) //means both are alive to play
            {
                DisplayCombatInfo();
                Console.ReadKey(); //user can view the information
                this.dragon.TakeDamage(this.user.DoAttach());
                if (dragon.IsAlive) //if dragon survives user's attack, then only it can attack
                {
                    DisplayCombatInfo();
                    Console.ReadKey();
                    this.user.TakeDamage(this.dragon.DoAttach());
                }
                else
                    Console.WriteLine("\n" +this.user.name + " you WON!");
            }

           Console.WriteLine("\n" +this.user.name + " you lost");
        }
    }
}

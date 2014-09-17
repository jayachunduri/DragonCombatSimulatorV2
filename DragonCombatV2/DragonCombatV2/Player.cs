using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatV2
{
    public enum AttackType
    {
        Sword = 1,
        FireBall,
        Heal
    }

    public abstract class GamePlayer
    {
        //properties
        public string name { get; set; }
        public int health { get; set; }
        public bool IsAlive
        {
            get
            {
                if (health > 0)
                    return true;
                else
                    return false;
            }
        }

        //constructor
        public GamePlayer()
        {
        }

        abstract public int DoAttach();
        //{
        //   // return 0;
        //}

        abstract public void TakeDamage(int damage);
        //{
        //}
    }

    //Inheriting Player
    public class Player : GamePlayer
    {
        //As it will get 3 properties of it's parent class, declaring only one property
        AttackType attack { get; set; }

        //constructor
        public Player()
        {
            this.name = "User";
            this.health = 100;
        }

        public Player(string name)
        {
            this.name = name;
            this.health = 100;
        }

        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        //Takes current enemy health and returns enemy health after the attach.
        public override int DoAttach()
        {
            Random rng = new Random();
            this.attack = ChooseAttach();
            
            switch (attack)
            {
                case AttackType.Sword: //user selected the sword
                    int hit = rng.Next(1, 101);
                    if (hit <= 70) //user got a hit
                    {
                        Console.WriteLine("Congrats you got a hit!");
                        return rng.Next(20, 26);
                    }
                    else //user missed it
                    {
                        Console.WriteLine("\n OOPS...You have missed");
                        return 0;
                    }
                    
                    
                case AttackType.FireBall: //user selected the fire ball
                    return rng.Next(10, 16);
                                        
                case AttackType.Heal: //user selected heal
                    if (health == 100)
                    {
                        Console.WriteLine("Sorry, you already have max HP points. Make a new choice");
                        return DoAttach();
                    }
                    else
                    {
                        return rng.Next(10, 21);
                    }
                    
                default:
                    Console.WriteLine("You have entered wrong choice. Make a new choice");
                    return DoAttach();
                    
            }

           
        }

        public AttackType ChooseAttach()
        {
            AttackType userChoice;
            string choice = "";

            //this loop is for exception handling. If user accidentaly presses enter, it will ask for choice again
            while (choice == "")
            {
                Console.WriteLine(@"
Make your choice
1. Sword.
2. Fire ball
3. Heal
             ");

                choice = Console.ReadLine();
            }
            userChoice = (AttackType)Enum.Parse(typeof(AttackType), choice);
            return userChoice;
        }

        //It takes how much damage the enemy done to the player
        public override void TakeDamage(int damage)
        {
            this.health = this.health - damage;
        }
   
    }
}

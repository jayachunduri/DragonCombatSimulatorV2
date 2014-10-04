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
        public static Player user;
        Enemy dragon;
        
        //Constructor
        public Game()
        {
            Console.Write("Enter your name: ");
            user = new Player(Console.ReadLine());
            this.dragon = new Enemy("Dragon", 200);
        }

        public Game(Player name, Enemy dragon)
        {
            user = name;
            this.dragon = dragon;
        }

        //Function to greet the user.
        public void Greet()
        {
            Console.WriteLine("\nWelcome to DRAGON HIT, " +user.name);
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
            //Console.Clear();
            Console.WriteLine(user.name + " health: " + user.health + "\n" + dragon.name + " health: " + dragon.health);
        }

        //Actual game logic
        public void PlayGame()
        {
            while (user.IsAlive && dragon.IsAlive) //means both are alive to play
            {
                
                DisplayCombatInfo();
                Console.ReadKey(); //user can view the information
                this.dragon.TakeDamage(user.DoAttach());

                if (dragon.IsAlive) //if dragon survives user's attack, then only it can attack
                {

                    DisplayCombatInfo();
                    Console.ReadKey();
                    user.TakeDamage(this.dragon.DoAttach());
                }
                else
                {
                    Console.WriteLine("\n" + user.name + " you WON!");
                    return;
                }
            }

           Console.WriteLine("\n" +user.name + " you lost");
           AddHighScore(user.Score);
           DisplayHighScores();
            
        }

        public static void AddHighScore(int Score)
        {
            //Console.WriteLine("Your Name:");
            //string playerName = Console.ReadLine();

            //create a gateway to the data base
            JayaEntities db = new JayaEntities();

            //create a new highscore object
            HighScore newHighScore = new HighScore();

            newHighScore.DateCreated = DateTime.Now;
            newHighScore.Game = "Dragon Combat";
            newHighScore.Name = user.name;
            newHighScore.Score = Score;

            //add it to the data base
            db.HighScores.Add(newHighScore);

            //save changes
            db.SaveChanges();
        }

        public static void DisplayHighScores()
        {
            //clear the console
            Console.Clear();

            //write the high score text
            Console.WriteLine("Dragon combat high score");
            Console.WriteLine("------------------------");

            //create a new connection
            JayaEntities db = new JayaEntities();

            //get the high score list
            //List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "Dragon").OrderBy(x => x.Score).Take(10).ToList();

            foreach (var item in db.HighScores.Where(x => x.Game == "Dragon").OrderBy(x => x.Score).Take(10))
            {
                //Console.WriteLine("{0}, {1} - {2}", highScoreList.IndexOf(item) + 1, item.Name, item.Score);
                Console.WriteLine(item.Name +" " +item.Score );
            }
        }
    }
}

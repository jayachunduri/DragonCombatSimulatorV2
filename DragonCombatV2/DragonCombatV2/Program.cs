using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Jaya", 100);
            Enemy enemy = new Enemy("Dragon", 200);

            
            Game game = new Game(player, enemy);
            game.Greet();
            game.PlayGame();
        }
    }
}

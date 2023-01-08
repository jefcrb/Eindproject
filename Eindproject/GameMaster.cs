using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject
{
    static public class GameMaster
    {
        static private bool hasStarted = false;
        static private bool gameOver = false;
        static private int levelCount = 0;
        static private bool hasWon = false;
        static public int Health { get; set; } = 3;
        static public int LevelCount
        {
            get
            {
                Console.WriteLine("Starting level " + levelCount);
                return levelCount;
            }
            set
            {
                levelCount = value;
            }
        }
        static public bool HasStarted
        {
            get { return hasStarted; }
            set
            {
                if (value)
                {
                    Health = 3;
                    IsPaused = false;
                    HasWon = false;
                    GameOver = false;
                }
                hasStarted = value;
            }
        }
        static public bool IsPaused { get; set; } = false;
        static public bool HasWon
        {
            get { return hasWon; }
            set
            {
                if (value)
                    IsPaused = true;

                Console.WriteLine("HasWon set to " + value);
                hasWon = value;
            }
        }
        static public bool GameOver
        {
            get
            {
                if (Health <= 0)
                    return true;
                else return false;
            }
            set { gameOver = value; }
        }

        static public void TogglePause()
        {
            IsPaused = !IsPaused;
        }
    }
}

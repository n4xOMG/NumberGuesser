using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessing
{
    public class Games
    {
        Random Random = new Random();
        private int gameID;
        private int playerID;
        private int guessCount;
        private int number;
        private string winLose;
        public Games() { }

        public Games(int guessCount, int number, string winLose, int gameID)
        {
            this.guessCount = guessCount;
            this.number = number;
            this.winLose = winLose;
            this.gameID = gameID;
        }

        public Games(int playerID, int guessCount, int number, string winLose)
        {
            this.playerID = playerID;
            this.guessCount = guessCount;
            this.number = number;
            this.winLose = winLose;
        }

        public int GameID { get => gameID; set => gameID = value; }
        public int PlayerID { get => playerID; set => playerID = value; }
        public int GuessCount { get => guessCount; set => guessCount = value; }
        public int Number { get => number; set => number = value; }
        public string WinLose { get => winLose; set => winLose = value; }

        public int getRandomNum(int n1, int n2)
        {
            return Random.Next(n1, n2);
        }
    }
}

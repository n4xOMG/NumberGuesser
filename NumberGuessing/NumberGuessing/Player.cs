using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessing
{
    public class Player
    {
        private int playerID;
        private string playerName;
        private int playCount;
        private int winCount;
        private int loseCount;


        public Player()
        {
        }

        public Player(int playerID, string playerName, int playCount, int winCount, int loseCount)
        {
            this.playerID = playerID;
            this.playerName = playerName;
            this.playCount = playCount;
            this.winCount = winCount;
            this.loseCount = loseCount;
        }
        public Player(string playerName, int playCount, int winCount, int loseCount)
        {
            this.playerName = playerName;
            this.playCount = playCount;
            this.winCount = winCount;
            this.loseCount = loseCount;
        }
        public Player(int playCount, int winCount, int loseCount, int playerID)
        {
            this.playCount = playCount;
            this.winCount = winCount;
            this.loseCount = loseCount;
            this.playerID = playerID;
        }

        public int PlayerID { get => playerID; set => playerID = value; }
        public string PlayerName { get => playerName; set => playerName = value; }
        public int PlayCount { get => playCount; set => playCount = value; }
        public int WinCount { get => winCount; set => winCount = value; }
        public int LoseCount { get => loseCount; set => loseCount = value; }
    }
}

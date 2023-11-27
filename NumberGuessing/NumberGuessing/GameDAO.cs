using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessing
{
    public class GameDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        DBConnection db = new DBConnection();
        public DataTable LoadList()
        {
            string sqlStr = string.Format("SELECT * FROM Games where playerID != null ");
            return db.LoadList(sqlStr);
        }
        public int Add(Games g)
        {
            string sqlStr = string.Format("INSERT INTO Games (PlayerID, GuessCount, Number, WinLose) VALUES ('" + g.PlayerID + "','" + g.GuessCount + "','" + g.Number + "','" + g.WinLose + "'); SELECT SCOPE_IDENTITY();");
            return db.GetID(sqlStr);
        }
        public void Update(Games g)
        {
            string sqlStr = string.Format("UPDATE Games set guessCount ='" + g.GuessCount + "', number ='" + g.Number + "', WinLose ='" + g.WinLose + "'where gameID='"  + g.GameID + "';");
            db.Process(sqlStr);
        }
    }
}

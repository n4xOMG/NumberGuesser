using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessing
{
    public class PlayerDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        DBConnection db = new DBConnection();
        public void Add(Player p)
        {
            string sqlStr = string.Format("insert into Players values('" + p.PlayerName + "','" + p.PlayCount + "','" + p.WinCount + "','" + p.LoseCount + "')");
            db.Process(sqlStr);
        }
        public void Update(Player p)
        {
            string sqlStr = string.Format("UPDATE Players set playCount ='" + p.PlayCount + "', winCount ='" + p.WinCount + "', loseCount ='" + p.LoseCount + "'where playerID='" + p.PlayerID + "';");
            db.Process(sqlStr);
        }
        public int? checkName(string name)
        {
            string sqlStr = string.Format("SELECT playerID FROM Players where playerName='" + name + "'");
            DataTable dt = db.LoadList(sqlStr);
            if (dt.Rows.Count > 0)
            {
                return (int)dt.Rows[0]["playerID"];
            }
            else
            {
                return null;
            }
        }
        public int? getPlayCount(string name)
        {
            string sqlStr = string.Format("SELECT playCount FROM Players where playerName='" + name + "'");
            DataTable dt = db.LoadList(sqlStr);
            if (dt.Rows.Count > 0)
            {
                return (int)dt.Rows[0]["playCount"];
            }
            else
            {
                return null;
            }
        }
        public int? getWinCount(string name)
        {
            string sqlStr = string.Format("SELECT winCount FROM Players where playerName='" + name + "'");
            DataTable dt = db.LoadList(sqlStr);
            if (dt.Rows.Count > 0)
            {
                return (int)dt.Rows[0]["winCount"];
            }
            else
            {
                return null;
            }
        }
        public int? getLoseCount(string name)
        {
            string sqlStr = string.Format("SELECT loseCount FROM Players where playerName='" + name + "'");
            DataTable dt = db.LoadList(sqlStr);
            if (dt.Rows.Count > 0)
            {
                return (int)dt.Rows[0]["loseCount"];
            }
            else
            {
                return null;
            }
        }
    }
}

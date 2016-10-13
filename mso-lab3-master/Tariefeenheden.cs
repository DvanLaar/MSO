using System;
using System.Data.SQLite;

namespace Lab3
{
	public static class Tariefeenheden
	{
		public static String[] getStations()
		{
			return new String[] {
				"Utrecht Centraal",
				"Gouda",
				"Geldermalsen",
				"Hilversum",
				"Duivendrecht",
				"Weesp"
			};
		}

		public static int getTariefeenheden(String from, String to) 
		{
            SQLiteConnection con = makeCon();

            from = from.Split()[0];
            to = to.Split()[0];

            SQLiteCommand cmmnd = new SQLiteCommand("SELECT * FROM stations WHERE id = '" + from + "';", con);
            con.Open();
            SQLiteDataReader reader = cmmnd.ExecuteReader();
            reader.Read();
            int result = Int32.Parse(reader[to].ToString());
            con.Close();

            return result;
		}

        private static SQLiteConnection makeCon()
        {
            string[] commands = new string[7]{
                "CREATE Table stations (id text NOT NULL, Utrecht text, Gouda text, Geldermalsen text, Hilversum text, Duivendrecht text, Weesp text);",
                "INSERT INTO \"stations\" VALUES('Utrecht', 0, 32, 26, 18, 31, 33);",
                "INSERT INTO \"stations\" VALUES('Gouda', 32, 0, 58, 50, 54, 57);",
                "INSERT INTO \"stations\" VALUES('Geldermalsen', 26, 58, 0, 44, 57, 59);",
                "INSERT INTO \"stations\" VALUES('Hilversum', 18, 50, 44, 0, 18, 15);",
                "INSERT INTO \"stations\" VALUES('Duivendrecht', 31, 54, 57, 18, 0, 3);",
                "INSERT INTO \"stations\" VALUES('Weesp', 33, 57, 59, 15, 3, 0);"
            };

            SQLiteConnection.CreateFile("stations.sqlite");
            SQLiteConnection con = new SQLiteConnection("Data Source=stations.sqlite;Version=3;");

            foreach (string s in commands)
            {
                SQLiteCommand command = new SQLiteCommand(s, con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            return con;
        }
	}
}


using UnityEngine;
using System.Data.SQLite;
using System.Data;


public class TestSqlite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/db/utfprgame"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SQLiteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT id,cidade FROM Cidades";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string cidade = reader.GetString(1);
            

            Debug.Log("id= " + id + "  cidade =" + cidade);
        }
        
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

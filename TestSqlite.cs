using UnityEngine;
using System.Data.SQLite;
using System.Data;


public class TestSqlite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/db"; //Path to database.
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




        /*
        string connectionStr = Application.dataPath + "/db";
        SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + connectionStr + ";Version=3;");
        connection.Open();


        // Ler dados
        SQLiteCommand command = connection.CreateCommand();
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT id,cidade FROM Cidades";
        var reader = command.ExecuteScalar();
        connection.Close();


        
        SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection);
        DataSet DS = new DataSet();
        adapter.Fill(DS);
        adapter.Dispose();
        CloseConnection();
        return DS.Tables[0];
        */




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

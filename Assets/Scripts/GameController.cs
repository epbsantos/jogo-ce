using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Data.SQLite;
using System.Data;

public class GameController : MonoBehaviour
{

    public string banco;
    public GameObject escolhas;
    public Text cidade;
    
    /* // Colocar via script a referencia da categoria
    public UnityEngine.UI.Button c1;
    public UnityEngine.UI.Button c2;
    public UnityEngine.UI.Button c3;
    */

    public Text tc1;
    public Text tc2;
    public Text tc3;

    public Text dica;

    private string nome_da_fase;
    private string[] seq; // Vetor de fases
    private string descricao_da_fase;
    private string[] cat;

    private int id_seq;

    // Start is called before the first frame update
    void Start()
    {
        id_seq = 0;
        loadFase(1);

        loadCidade(seq[id_seq]); // Carrega a primeira cidade
        //loadCategorias();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrarEscolhas()
    {
        if( escolhas.tag == "on")
        {
            escolhas.tag = "off";
            //LeanTween.moveLocalY(escolhas, 175f, 0.5f);
            LeanTween.scale(escolhas, new Vector3(0f, 0f, 1f), 0.5f);

            LeanTween.scale(dica.gameObject, new Vector3(0f, 0f, 1f), 0.5f); // dica off

        }
        else
        {
            escolhas.tag = "on";
            //LeanTween.moveLocalY(escolhas, 175f, 0.5f);
            LeanTween.scale(escolhas, new Vector3(1f, 1f, 1f), 0.5f);

            LeanTween.scale(dica.gameObject, new Vector3(0f, 0f, 1f), 0.5f); // dica off
        }
        
        
    }

    public void mostraDica(int i)
    {
        escolhas.tag = "off";
        //LeanTween.moveLocalY(escolhas, 175f, 0.5f);
        LeanTween.scale(escolhas, new Vector3(0f, 0f, 1f), 0.5f);
        LeanTween.scale(dica.gameObject, new Vector3(1f, 1f, 1f), 0.5f); // dica onn

        Debug.Log(i + "     " + seq[id_seq+1]);

        string conn = "URI=file:" + Application.dataPath + banco; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SQLiteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT dica FROM Dicas WHERE id_categoria = " + i + " AND id_cidade = " + seq[id_seq+1];
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            dica.text = reader.GetString(0);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    void sqlite()
    {
        string conn = "URI=file:" + Application.dataPath + banco; //Path to database.
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


            //Debug.Log("id= " + id + "  cidade =" + cidade);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    void loadFase(int i)
    {
        string conn = "URI=file:" + Application.dataPath + banco; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SQLiteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT nome_da_fase,sequencia,descricao_da_fase FROM Fases WHERE id = " + i;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            nome_da_fase = reader.GetString(0);
            string sequencia = reader.GetString(1);
            descricao_da_fase = reader.GetString(2);

            seq = sequencia.Split(',');
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    void loadCidade(string i)
    {
        string conn = "URI=file:" + Application.dataPath + banco; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SQLiteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT cidade FROM Cidades WHERE id = " + i;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            cidade.text = reader.GetString(0);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    /* // Está com problema, verificar a chamada da tabela categoria e colocar no vetor / botoes
    void loadCategorias()
    {
        string conn = "URI=file:" + Application.dataPath + banco; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SQLiteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT categoria FROM Categorias";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        int i = 0;
        while (reader.Read())
        {
            cat[i] = reader.GetString(0);
            i++;
            Debug.Log(reader.GetString(0));
        }

        tc1.text = cat[0];
        tc2.text = cat[1];
        tc3.text = cat[2];

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
    */
}

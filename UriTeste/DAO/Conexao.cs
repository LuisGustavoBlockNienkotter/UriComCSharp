using System;
using MySql.Data.MySqlClient;

namespace UriTeste.DAO
{
    public class Conexao
    {
        //Aqui você substitui pelos seus dados
        public static string connString = "Server=localhost;Database=uriTeste;Uid='root';Pwd=''"; 
        public static MySqlConnection connection = new MySqlConnection(connString);
        public MySqlCommand command = connection.CreateCommand();
        public static MySqlDataReader dr;
    }  
}

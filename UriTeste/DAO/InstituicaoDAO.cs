using System;
using System.Collections.Generic;
using System.Data;
using UriTeste.classes;

namespace UriTeste.DAO
{
    public class InstituicaoDAO : Conexao
    {

        public void inserir(Instituicao ins){
            try{
                connection.Open();
                string nome = ins.getNome();
                command.CommandText = "INSERT INTO Instituicao (nome) VALUES('"+ nome +"')";
                command.ExecuteNonQuery();
            }finally{
                connection.Close();            
            }
        }

        public List<Instituicao> selectAll(){
            try{
                connection.Open();
                command.CommandText = "SELECT * FROM Instituicao";
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<Instituicao> lista = new List<Instituicao>();
                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["id"]);
                    string nome = dr["Nome"].ToString();
                    Instituicao ins = new Instituicao(id, nome);
                    lista.Add(ins);
                }
                return lista;
            }finally{
                connection.Close();            
            }
        }

        public Instituicao selectById(int codigo){
            try{
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.CommandText = "SELECT * FROM Instituicao WHERE id = "+ codigo;
                //command.Parameters.AddWithValue("@idSelectById", codigo);
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                dr.Read();
                int id = Convert.ToInt32(dr["id"]);
                string nome = dr["Nome"].ToString();
                Instituicao ins = new Instituicao(id, nome);
                return ins;
            }finally{
                connection.Close();            
            }
        }

        public List<Instituicao> selectByNome(string nome){
            try{
                connection.Open();
                command.CommandText = "SELECT * FROM Instituicao WHERE nome = '"+ nome +"'";
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<Instituicao> lista = new List<Instituicao>();
                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["id"]);
                    string nomeIns = dr["Nome"].ToString();
                    Instituicao ins = new Instituicao(id, nomeIns);
                    lista.Add(ins);
                }
                return lista;
            }finally{
                connection.Close();            
            }
        }

        public void delete(Instituicao ins){
            try{
                connection.Open();
                command.CommandText = "DELETE FROM Instituicao WHERE id = @idDel";
                command.Parameters.AddWithValue("@idDel", ins.getCodigo());
                command.ExecuteNonQuery();
            }finally{
                connection.Close();            
            }
        }

        public void update(Instituicao ins){
            try{
                connection.Open();
                command.CommandText = "UPDATE Instituicao SET nome = @nomeUp WHERE id = @idUp";
                command.Parameters.AddWithValue("@idUp", ins.getCodigo());
                command.Parameters.AddWithValue("@nomeUp", ins.getNome());
                command.ExecuteNonQuery();
            }finally{
                connection.Close();            
            }
        }


    }  
}

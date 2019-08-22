using System;
using System.Collections.Generic;
using System.Data;
using UriTeste.classes;

namespace UriTeste.DAO
{
    public class TurmaDAO : Conexao
    {

        public void inserir(Turma turma){
            try{
                connection.Open();
                string nome = turma.getNome();
                command.CommandText = "INSERT INTO Turma (nome) VALUES('"+ nome +"')";
                command.ExecuteNonQuery();
            }finally{
                connection.Close();            
            }
        }

        public List<Turma> selectAll(){
            try{
                connection.Open();
                command.CommandText = "SELECT * FROM Turma";
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<Turma> lista = new List<Turma>();
                List<Aluno> listaAlunos = new List<Aluno>();
                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["id"]);
                    string nome = dr["Nome"].ToString();
                    Turma turma = new Turma(id, nome, listaAlunos);
                    lista.Add(turma);
                }
                return lista;
            }finally{
                connection.Close();            
            }
        }

        public Turma selectById(int codigo){
            try{
                connection.Open();
                command.CommandText = "SELECT * FROM Turma WHERE id = @id";
                command.Parameters.AddWithValue("@id", codigo);
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                dr.Read();
                int id = Convert.ToInt32(dr["id"]);
                string nome = dr["Nome"].ToString();
                List<Aluno> listaAlunos = new List<Aluno>();
                Turma turma = new Turma(id, nome, listaAlunos);
                return turma;
            }finally{
                connection.Close();            
            }
        }

        public List<Turma> selectByNome(string nome){
            try{
                connection.Open();
                command.CommandText = "SELECT * FROM Turma WHERE nome = '"+ nome +"'";
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<Turma> lista = new List<Turma>();
                List<Aluno> listaAlunos = new List<Aluno>();
                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["id"]);
                    string nomeTurma = dr["Nome"].ToString();
                    Turma turma = new Turma(id, nomeTurma, listaAlunos);
                    lista.Add(turma);
                }
                return lista;
            }finally{
                connection.Close();            
            }
        }

        public void delete(Turma turma){
            try{
                connection.Open();
                command.CommandText = "DELETE FROM Turma WHERE id = @idDel";
                command.Parameters.AddWithValue("@idDel", turma.getCodigo());
                command.ExecuteNonQuery();
            }finally{
                connection.Close();            
            }
        }

        public void update(Turma turma){
            try{
                connection.Open();
                command.CommandText = "UPDATE Turma SET nome = @nomeUp WHERE id = @idUp";
                command.Parameters.AddWithValue("@idUp", turma.getCodigo());
                command.Parameters.AddWithValue("@nomeUp", turma.getNome());
                command.ExecuteNonQuery();
            }finally{
                connection.Close();            
            }
        }


    }  
}

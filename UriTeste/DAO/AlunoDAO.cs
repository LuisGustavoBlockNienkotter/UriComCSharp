using System;
using System.Collections.Generic;
using System.Data;
using UriTeste.classes;

namespace UriTeste.DAO
{
    public class AlunoDAO : Conexao
    {

        public void inserir(Aluno aluno){
            try{
                connection.Open();
                command.CommandText = "INSERT INTO Aluno (id, nome, rankGeral,"+ 
                                              "id_Instituicao, dataCadastro, score,"+
                                              "tentados, resolvidos, submissoes) VALUES(@id , @nome ,"+ 
                                              "@rankGeral , @id_Instituicao, @dataCadastro , @score ,"+
                                              "@tentados , @resolvidos , @submissoes)";
                command.Parameters.AddWithValue("@id", aluno.getCodigo());
                command.Parameters.AddWithValue("@nome", aluno.getNome());
                command.Parameters.AddWithValue("@rankGeral", aluno.getRankGeral());
                command.Parameters.AddWithValue("@id_Instituicao", aluno.getInstituicao().getCodigo());
                command.Parameters.AddWithValue("@dataCadastro", aluno.getDataCadastro());
                command.Parameters.AddWithValue("@score", aluno.getScore());
                command.Parameters.AddWithValue("@tentados", aluno.getTentados());
                command.Parameters.AddWithValue("@resolvidos", aluno.getResolvidos());
                command.Parameters.AddWithValue("@submissoes", aluno.getSubmetidos());
                command.ExecuteNonQuery();
            }finally{
                connection.Close();            
            }
         }

        public List<Aluno> selectAll(){
            try{
                Controlador control = new Controlador();
                connection.Open();
                command.CommandText = "SELECT * FROM Aluno";
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<Aluno> lista = new List<Aluno>();
                List<int> idIns = new List<int>();
                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["id"]);
                    string nome = dr["Nome"].ToString();
                    string rankGeral = dr["rankGeral"].ToString();
                    idIns.Add(Convert.ToInt32(dr["id_Instituicao"]));
                    //Instituicao ins = control.procurarInstituicaoPorCodigo(Convert.ToInt32(dr["id_Instituicao"]));
                    string dataCadastro = dr["dataCadastro"].ToString();
                    float score = float.Parse(dr["score"].ToString());
                    int resolvidos = 0;
                    if (!(dr["resolvidos"] is DBNull)){
                        resolvidos = Convert.ToInt32(dr["resolvidos"]);
                    }  
                    int tentados = 0;
                    if (!(dr["tentados"] is DBNull)){
                        tentados = Convert.ToInt32(dr["tentados"]);
                    }  
                    int submissoes = 0;
                    if (!(dr["submissoes"] is DBNull)){
                        submissoes = Convert.ToInt32(dr["submissoes"]);
                    }  
                    Aluno aluno = new Aluno(id, nome, rankGeral, null, dataCadastro, score, resolvidos, tentados, submissoes);
                    lista.Add(aluno);
                }
                connection.Close();
                int index = 0;
                foreach (var id in idIns){
                    Instituicao ins = control.procurarInstituicaoPorCodigo(id);
                    lista[index].setInstituicao(ins);
                    index++;
                }
                return lista;
            }finally{
                if (connection.State == ConnectionState.Open){
                    connection.Close(); 
                }          
            }
         }

        public Aluno selectById(int codigo){
            try{
                Controlador control = new Controlador();
                connection.Open();
                command.CommandText = "SELECT * FROM Aluno WHERE id = "+codigo;
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<int> idIns = new List<int>();
                dr.Read();
                int id = Convert.ToInt32(dr["id"]);
                string nome = dr["Nome"].ToString();
                string rankGeral = dr["rankGeral"].ToString();
                idIns.Add(Convert.ToInt32(dr["id_Instituicao"]));
                //Instituicao ins = control.procurarInstituicaoPorCodigo(Convert.ToInt32(dr["id_Instituicao"]));
                string dataCadastro = dr["dataCadastro"].ToString();
                float score = float.Parse(dr["score"].ToString());
                int resolvidos = 0;
                if (!(dr["resolvidos"] is DBNull)){
                    resolvidos = Convert.ToInt32(dr["resolvidos"]);
                }  
                int tentados = 0;
                if (!(dr["tentados"] is DBNull)){
                    tentados = Convert.ToInt32(dr["tentados"]);
                }  
                int submissoes = 0;
                if (!(dr["submissoes"] is DBNull)){
                    submissoes = Convert.ToInt32(dr["submissoes"]);
                }  
                Aluno aluno = new Aluno(id, nome, rankGeral, null, dataCadastro, score, resolvidos, tentados, submissoes);
                connection.Close();
                foreach (var idInst in idIns){
                    Instituicao ins = control.procurarInstituicaoPorCodigo(idInst);
                    aluno.setInstituicao(ins);
                }
                return aluno;
            }finally{
                if (connection.State == ConnectionState.Open){
                    connection.Close(); 
                }          
            }
         }

        public List<Aluno> selectByNome(string nome){
            try{
                Controlador control = new Controlador();
                connection.Open();
                command.CommandText = "SELECT * FROM Aluno WHERE nome = '"+ nome+"'";
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<Aluno> lista = new List<Aluno>();
                List<int> idIns = new List<int>();
                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["id"]);
                    string nomeA = dr["Nome"].ToString();
                    string rankGeral = dr["rankGeral"].ToString();
                    idIns.Add(Convert.ToInt32(dr["id_Instituicao"]));
                    //Instituicao ins = control.procurarInstituicaoPorCodigo(Convert.ToInt32(dr["id_Instituicao"]));
                    string dataCadastro = dr["dataCadastro"].ToString();
                    float score = float.Parse(dr["score"].ToString());
                    int resolvidos = 0;
                    if (!(dr["resolvidos"] is DBNull)){
                        resolvidos = Convert.ToInt32(dr["resolvidos"]);
                    }  
                    int tentados = 0;
                    if (!(dr["tentados"] is DBNull)){
                        tentados = Convert.ToInt32(dr["tentados"]);
                    }  
                    int submissoes = 0;
                    if (!(dr["submissoes"] is DBNull)){
                        submissoes = Convert.ToInt32(dr["submissoes"]);
                    }  
                    Aluno aluno = new Aluno(id, nomeA, rankGeral, null, dataCadastro, score, resolvidos, tentados, submissoes);
                    lista.Add(aluno);
                }
                connection.Close();
                int index = 0;
                foreach (var id in idIns){
                    Instituicao ins = control.procurarInstituicaoPorCodigo(id);
                    lista[index].setInstituicao(ins);
                    index++;
                }
                return lista;
            }finally{
                if (connection.State == ConnectionState.Open){
                    connection.Close(); 
                }          
            }
         }

        public List<Aluno> selectByInstituicao(Instituicao ins){
            try{
                Controlador control = new Controlador();
                connection.Open();
                command.CommandText = "SELECT * FROM Aluno WHERE id_Instituicao = "+ins.getCodigo();
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                List<Aluno> lista = new List<Aluno>();
                List<int> idIns = new List<int>();
                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["id"]);
                    string nomeA = dr["Nome"].ToString();
                    string rankGeral = dr["rankGeral"].ToString();
                    idIns.Add(Convert.ToInt32(dr["id_Instituicao"]));
                    //Instituicao ins = control.procurarInstituicaoPorCodigo(Convert.ToInt32(dr["id_Instituicao"]));
                    string dataCadastro = dr["dataCadastro"].ToString();
                    float score = float.Parse(dr["score"].ToString());
                    int resolvidos = 0;
                    if (!(dr["resolvidos"] is DBNull)){
                        resolvidos = Convert.ToInt32(dr["resolvidos"]);
                    }  
                    int tentados = 0;
                    if (!(dr["tentados"] is DBNull)){
                        tentados = Convert.ToInt32(dr["tentados"]);
                    }  
                    int submissoes = 0;
                    if (!(dr["submissoes"] is DBNull)){
                        submissoes = Convert.ToInt32(dr["submissoes"]);
                    }  
                    Aluno aluno = new Aluno(id, nomeA, rankGeral, null, dataCadastro, score, resolvidos, tentados, submissoes);
                    lista.Add(aluno);
                }
                connection.Close();
                int index = 0;
                foreach (var id in idIns){
                    Instituicao insAdd = control.procurarInstituicaoPorCodigo(id);
                    lista[index].setInstituicao(insAdd);
                    index++;
                }
                return lista;
            }finally{
                if (connection.State == ConnectionState.Open){
                    connection.Close(); 
                }          
            }
         }

        public void delete(Aluno aluno){
            try{
                connection.Open();
                command.CommandText = "DELETE FROM Aluno WHERE id = @idDel";
                command.Parameters.AddWithValue("@idDel", aluno.getCodigo());
                command.ExecuteNonQuery();
            }finally{
                connection.Close();            
            }
         }

        public void update(Aluno aluno){
            try{
                connection.Open();
                command.CommandText = "UPDATE Aluno SET nome = @nomeUp , rankGeral = @rankGeralUp , "+
                                      "id_Instituicao = @id_InstituicaoUp, dataCadastro = @dataCadastroUp , score = @scoreUp ,"+
                                      "tentados = @tentadosUp , resolvidos = @resolvidosUp , submissoes = @submissoesUp WHERE id = @idUp";
                command.Parameters.AddWithValue("@idUp", aluno.getCodigo());
                command.Parameters.AddWithValue("@nomeUp", aluno.getNome());
                command.Parameters.AddWithValue("@rankGeralUp", aluno.getRankGeral());
                command.Parameters.AddWithValue("@id_InstituicaoUp", aluno.getInstituicao().getCodigo());
                command.Parameters.AddWithValue("@dataCadastroUp", aluno.getDataCadastro());
                command.Parameters.AddWithValue("@scoreUp", aluno.getScore());
                command.Parameters.AddWithValue("@tentadosUp", aluno.getTentados());
                command.Parameters.AddWithValue("@resolvidosUp", aluno.getResolvidos());
                command.Parameters.AddWithValue("@submissoesUp", aluno.getSubmetidos());
                command.ExecuteNonQuery();
            }finally{
                connection.Close();            
            }
         }


    }  
}

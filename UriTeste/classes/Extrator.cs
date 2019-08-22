using System;
using System.Net;
namespace UriTeste.classes
{
    public class Extrator
    {
        public Aluno extrator(int codigo)
        {
            string html ="";
             using (WebClient client = new WebClient())
            {
                html = client.DownloadString("https://www.urionlinejudge.com.br/judge/en/profile/"+codigo);
            }
            string[] imagem1 = html.Split("img src=\"https://www.gravatar.com/avatar/");
            string imagem = imagem1[1].Split("?s=")[0];

            string[] nome1 = imagem1[1].Split(codigo+"\">");
            string nome = nome1[1].Split("</a>")[0];

            string[] rankGeral1 = nome1[1].Split("Place:</span>");
            string rankGeral = rankGeral1[1].Split("</li>")[0].Trim();

            string[] instituicao1 = rankGeral1[1].Split("'name'>");
            string instituicao = instituicao1[1].Split("</i>")[0];
            
            Instituicao ins = new Instituicao();
            ins.setNome(instituicao);

            string[] data1 = instituicao1[1].Split("Since:</span>");
            string data = data1[1].Split("</li>")[0].Trim();
            ///////////03/12/19

            string[] score1 = data1[1].Split("Points:</span>");
            string score2 = score1[1].Split("</li>")[0].Trim().Replace(",", "").Replace(".",",");
            float score = float.Parse(score2);

            string[] resolvidos1 = score1[1].Split("Solved:</span>");
            int resolvidos = Int32.Parse(resolvidos1[1].Split("</li>")[0].Trim());

            string[] tentados1 = resolvidos1[1].Split("Tried:</span>");
            int tentados = Int32.Parse(tentados1[1].Split("</li>")[0].Trim());

            string[] submetidos1 = tentados1[1].Split("Submissions:</span>");
            int submetidos = Int32.Parse(submetidos1[1].Split("</li>")[0].Trim());

            Aluno aluno = new Aluno(codigo, nome, rankGeral, ins, data, score, resolvidos, tentados, submetidos, imagem);

            return aluno;
        }
    }
}
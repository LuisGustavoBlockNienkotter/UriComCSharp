using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UriTeste.classes;
using UriTeste.DAO;


namespace UriTeste
{
    public class Program
    {
        public static void Main(string[] args){
            //CreateWebHostBuilder(args).Build().Run();
            Instituicao ins = new Instituicao(0, "AAAAA");
            Aluno aluno = new Aluno(2, "TESTE", "2", ins, "2019/8/12", 200, 3, 3,5, "");
            List<Aluno> listaAlunos = new List<Aluno>();
            listaAlunos.Add(aluno);
            Turma turma = new Turma(1, "TURMA TESTE", listaAlunos);


            Controlador control = new Controlador();

            //control.inserirInstituicao(ins);
            Instituicao insTeste = control.procurarInstituicaoPorCodigo(3);
            //insTeste.setNome("NOVO NOME");
            //control.deletarInstituicao(insTeste);
            //control.atualizarInstituicao(insTeste);
            List<Instituicao> listaIns = control.listarInstituicao();
            
            Turma turmaTeste = control.procurarTurmaPorCodigo(4);
            turmaTeste.setNome("NOVO NOME DA TURMA");
            //control.inserirTurma(turma);
            control.atualizarTurma(turmaTeste);
            List<Turma> listaTurma = control.listarTurmas();

            Aluno alunoTeste = new Aluno(400000, "TESTE", "2", insTeste, "2019/8/12", 200, 3, 3,5, "");
            //control.inserirAluno(alunoTeste);
            List<Aluno> listaAlunosTeste = control.procurarAlunoPorInstituicao(insTeste);
            //Aluno al = control.procurarAlunoPorNome("vc");


            foreach (var item in listaAlunosTeste)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine(al);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UriTeste.classes
{
    public class Turma
    {
        private int codigo { get; set; }
        private string nome { get; set; }
        private List<Aluno> alunos { get; set; }

        public Turma(int codigo = 1, string nome = "", List<Aluno> alunos = null){
            this.codigo = codigo;
            this.nome = nome;
            this.alunos = alunos;
        }

        public int getCodigo(){
            return this.codigo;
        }

        public void setCodigo(int cod){
            this.codigo = cod;
        }

        public string getNome(){
            return this.nome;
        }

        public void setNome(string nome){
            this.nome = nome;
        }

        public List<Aluno> getAlunos(){
            return this.alunos;
        }

        public void setAlunos(List<Aluno> alunos){
            this.alunos = alunos;
        }

        public string listarAlunos(){
            string txt = "";
            foreach (var aluno in alunos){
                txt+=aluno.ToString(); 
            }
            return txt;
        }
        public override string ToString(){
            return "Turma || Código: " + this.codigo + " | Nome: " + this.nome + 
            " | Alunos: " + this.listarAlunos();
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace UriTeste.classes
{
    public class Instituicao
    {
        private int codigo { get; set; }
        private string nome { get; set; }

        public Instituicao(int codigo = 1, string nome = ""){
            this.codigo = codigo;
            this.nome = nome;
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

        public override string ToString(){
            return "Instituição || Código: " + this.codigo + " | Nome: " + this.nome;
        }
    }
}
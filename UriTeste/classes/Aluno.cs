using System;
using System.ComponentModel.DataAnnotations;

namespace UriTeste.classes
{
    public class Aluno
    {
        private int codigo { get; set; }
        private string imagem { get; set; }
        private string nome { get; set; }
        private string rankGeral { get; set; }
        private Instituicao ins { get; set; }
        private string dataCadastro { get; set; }
        private float score { get; set; }
        private int resolvidos { get; set; }
        private int tentados { get; set; }
        private int submetidos { get; set; }

        public Aluno(int codigo = 1, string nome = "", string rankGeral = "", Instituicao ins = null,
                    string dataCadastro = "01/01/01", float score = 0, int resolvidos = 0,
                    int tentados = 0, int submetidos = 0, string imagem = ""){
            this.codigo = codigo;
            this.nome = nome;
            this.rankGeral = rankGeral;
            this.ins = ins;
            this.dataCadastro = dataCadastro;
            this.score = score;
            this.resolvidos = resolvidos;
            this.tentados = tentados;
            this.submetidos = submetidos;
            this.imagem = imagem;
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

        public string getRankGeral(){
            return this.rankGeral;
        }

        public void setRankGeral(string rank){
            this.rankGeral = rank;
        }

        public Instituicao getInstituicao(){
            return this.ins;
        }

        public void setInstituicao(Instituicao ins){
            this.ins = ins;
        }

        public string getDataCadastro(){
            return this.dataCadastro;
        }

        public void setDataCadastro(string data){
            this.dataCadastro = data;
        }

        public float getScore(){
            return this.score;
        }

        public void setScore(float score){
            this.score = score;
        }

        public int getResolvidos(){
            return this.resolvidos;
        }

        public void setResolvidos(int resolvidos){
            this.resolvidos = resolvidos;
        }

        public int getTentados(){
            return this.tentados;
        }

        public void setTentados(int tentados){
            this.tentados = tentados;
        }

        public int getSubmetidos(){
            return this.submetidos;
        }

        public void setSubmetidos(int submetidos){
            this.submetidos = submetidos;
        }

        public string getImagem(){
            return this.imagem;
        }

        public void gsImagem(string imagem){
            this.imagem = imagem;
        }

        public override string ToString(){
            return "Aluno || Código: " + this.codigo + " | Nome: " + this.nome + 
            " | Rank Geral: " + this.rankGeral + " | Instituição: " + this.ins.ToString() +
            " | Data de Cadastro: " + this.dataCadastro + " | Score: " + this.score +
            " | Resolvidos: " + this.resolvidos + " | Tentados: " + this.tentados +
            " | Submetidos: " + this.submetidos;
        }
    }
}
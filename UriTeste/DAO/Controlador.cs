using UriTeste.classes;
using System.Collections.Generic;

namespace UriTeste.DAO
{
    class Controlador{
        private InstituicaoDAO instituicoes;
        private TurmaDAO turmas;
        private AlunoDAO alunos;
        public Controlador(){
            this.instituicoes = new InstituicaoDAO();
            this.turmas = new TurmaDAO();
            this.alunos = new AlunoDAO();
        }

        public void inserirInstituicao(Instituicao ins){
            this.instituicoes.inserir(ins);
        }
        public List<Instituicao> listarInstituicao(){
            return this.instituicoes.selectAll();
        }
        public Instituicao procurarInstituicaoPorCodigo(int codigo){
            return this.instituicoes.selectById(codigo);
        }
        public List<Instituicao> procurarInstituicaoPorNome(string nome){
            return this.instituicoes.selectByNome(nome);
        }
        public void deletarInstituicao(Instituicao ins){
            this.instituicoes.delete(ins);
        }
        public void atualizarInstituicao(Instituicao ins){
            this.instituicoes.update(ins);
        }
        public void inserirTurma(Turma turma){
            this.turmas.inserir(turma);
        }
        public List<Turma> listarTurmas(){
            return this.turmas.selectAll();
        }
        public Turma procurarTurmaPorCodigo(int codigo){
            return this.turmas.selectById(codigo);
        }
        public List<Turma> procurarTurmaPorNome(string nome){
            return this.turmas.selectByNome(nome);
        }
        public void deletarTurma(Turma turma){
            this.turmas.delete(turma);
        }
        public void atualizarTurma(Turma turma){
            this.turmas.update(turma);
        }
        public void inserirAluno(Aluno aluno){
            this.alunos.inserir(aluno);
        }
        public List<Aluno> listarAlunos(){
            return this.alunos.selectAll();
        }
        public Aluno procurarAlunoPorCodigo(int codigo){
            return this.alunos.selectById(codigo);
        }
        public List<Aluno> procurarAlunoPorNome(string nome){
            return this.alunos.selectByNome(nome);
        }
        public List<Aluno> procurarAlunoPorInstituicao(Instituicao ins){
            return this.alunos.selectByInstituicao(ins);
        }
    }
}

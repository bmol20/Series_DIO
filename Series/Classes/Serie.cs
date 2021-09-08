using System;

namespace Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get ; set ;}
        private string Nome { get ; set ;}
        private string Descricao { get ; set ;}
        private int Ano { get ; set ;}
        private bool Excluido { get ; set ;}

        public Serie(int id, Genero genero, string nome, string descricao, int ano){
            this.Id = id;
            this.Genero = genero;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Ano = ano;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            if (Excluido == true){
                retorno += "Excluido: Sim";
            }
            else retorno += "Excluido: Não";
			return retorno;
        }

        public string retornaNome()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}
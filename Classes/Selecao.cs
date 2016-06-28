using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixeiroViajante.Classes
{
    public class Selecao
    {
        #region [Atributos]

        private List<Cromossomo> lstNovaPopulacao = new List<Cromossomo>();
        private List<Cromossomo> lstPopulacaoAtual = new List<Cromossomo>();
        private int iNumSelecionados = 0;
        private int iTamPopulacao = 0;

        public List<Cromossomo> NovaPopulacao
        {
            get { return lstNovaPopulacao; }
        }

        #endregion Fim [Atributos]

        #region [Construtor]

        public Selecao()
        {

        }

        /// <summary>
        /// Construtor com a lista da população atual e o número de indivíduos que serão selecionados sem cruzamento
        /// </summary>
        /// <param name="pListaPopulacaoAtual"></param>
        /// <param name="pNumSelecionados"></param>
        public Selecao( List<Cromossomo> pListaPopulacaoAtual, int pNumSelecionados, int pTamPopulacao )
        {
            this.lstPopulacaoAtual = pListaPopulacaoAtual;
            this.iNumSelecionados = pNumSelecionados;
            this.iTamPopulacao = pTamPopulacao;
        }

        #endregion Fim [Construtor]

        #region [Métodos]

        /// <summary>
        /// Método que recebe a população atual gerada (n * 5) e faz a seleção para n candidatos
        /// </summary>
        /// <param name="pListaPopulacaoAtual"></param>
        public void AplicarSelecaoRoleta()
        {
            AdicionarMelhores();

            Random oRandom = new Random();

            int iPosicaoSorteio = 0;

            List<Cromossomo> lstRoleta = new List<Cromossomo>();
            Cromossomo oCromoSorteado = new Cromossomo();

            while( iTamPopulacao > lstNovaPopulacao.Count )
            {
                lstRoleta.Clear();

                while( lstRoleta.Count < 5 )
                {
                    iPosicaoSorteio = oRandom.Next( lstPopulacaoAtual.Count );

                    oCromoSorteado = lstPopulacaoAtual[iPosicaoSorteio];

                    if( !lstRoleta.Contains( oCromoSorteado ) )
                        lstRoleta.Add( oCromoSorteado );
                }
                oCromoSorteado = null;
                oCromoSorteado = RodarRoleta( lstRoleta );

                if( !lstNovaPopulacao.Contains( oCromoSorteado ) )
                    lstNovaPopulacao.Add( oCromoSorteado );
            }
        }

        /// <summary>
        /// Monta uma lista onde as posições são preenchidas com os cromossos no número de posições igual ao tamanho do seu fitness
        /// </summary>
        /// <param name="pListaRoleta"></param>
        /// <returns></returns>
        private Cromossomo RodarRoleta( List<Cromossomo> pListaRoleta )
        {
            List<Cromossomo> lstRoleta = new List<Cromossomo>();

            Random oRandom = new Random();

            foreach( Cromossomo cromo in pListaRoleta )
            {
                int iTotal = Convert.ToInt32( cromo.Fitness * 10000 );

                for( int i = 0; i < iTotal; i++ )
                {
                    lstRoleta.Add( cromo );
                }
            }

            int iSorteio = oRandom.Next( lstRoleta.Count );

            return lstRoleta[iSorteio];
        }


        /// <summary>
        /// Aqui é definido pelo usuário quantos serão selecionados sem cruzamento por serem os melhores
        /// </summary>
        private void AdicionarMelhores()
        {
            int iSelecionados = 0;
            List<Cromossomo> lstJaSelecionados = new List<Cromossomo>();
            double nFitness = 0;
            Cromossomo oCromoSel = new Cromossomo();

            while( iSelecionados < iNumSelecionados)
            {
                nFitness = 0;
                foreach( Cromossomo oCr in lstPopulacaoAtual )
                {
                    if( !lstJaSelecionados.Contains( oCr ) )
                    {
                        if( oCr.Fitness > nFitness )
                        {
                            nFitness = oCr.Fitness;
                            oCromoSel = oCr;
                        }
                    }
                }

                lstNovaPopulacao.Add( oCromoSel );
                lstJaSelecionados.Add( oCromoSel );
                iSelecionados++;
            }
        }

        #endregion Fim [Métodos]
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixeiroViajante.Classes
{
    public class Cruzamento
    {
        #region [Atributos e Propriedades]

        private List<Cromossomo> lstPopulacao = new List<Cromossomo>();

        private List<Cromossomo> lstNovaGeracao = new List<Cromossomo>();

        private DataTable dtbDistancias = new DataTable();

        /// <summary>
        /// Define de qual lado serão pegas as rotas do cromosso predominante
        /// </summary>
        private enum eLado
        {
            esquerda = 0,

            direita = 1
        }

        private eLado eLadoEscolher = eLado.esquerda;

        /// <summary>
        /// Lista com a nova geração gerada
        /// </summary>
        public List<Cromossomo> Geracao
        {
            get { return this.lstNovaGeracao; }
        }

        /// <summary>
        /// Tabela de distâncias
        /// </summary>
        public DataTable Distancias
        {
            get { return dtbDistancias; }
            set { dtbDistancias = value; }
        }

        #endregion Fim [Atributos e Propriedades]

        #region [Construtor]

        public Cruzamento()
        {

        }

        public Cruzamento( List<Cromossomo> pListaCruzamento )
        {
            this.lstPopulacao = pListaCruzamento;
        }

        #endregion Fim [Construtores]

        #region [Métodos]

        /// <summary>
        /// Método de geração de uma nova geração 
        /// Usando a seguinte técnica. São sorteados 2 cromossomos, dentre esse é feita
        /// uma análise para ver qual tem a melhor metada (menor distância). O seleciona é o predominante
        /// o resto dos cromossomos ficam a cargo do cromosso não predominante
        /// </summary>
        public void NovaGeracao()
        {
            Cromossomo oCromoPai = null;
            Cromossomo oCromoMae = null;
            Cromossomo oCromossomoFilho = null;

            while( lstNovaGeracao.Count < lstPopulacao.Count )
            {
                oCromoPai = SortearCandidato();

                oCromoMae = SortearCandidato();

                oCromossomoFilho = new Cromossomo();

                while( oCromoPai == oCromoMae )
                {
                    oCromoMae = SortearCandidato();
                }


                if( AnalisarPredominante( oCromoPai, oCromoMae ) )
                {
                    PegarMetadeEAdicionar( oCromoPai, oCromossomoFilho );
                    AdicionarSegundaMetade( oCromoMae, oCromossomoFilho );
                }
                else
                {
                    PegarMetadeEAdicionar( oCromoMae, oCromossomoFilho );
                    AdicionarSegundaMetade( oCromoPai, oCromossomoFilho );
                }

                lstNovaGeracao.Add( oCromossomoFilho );
            }
        }

        private void AdicionarSegundaMetade(Cromossomo oCromoPegar, Cromossomo oCromoFilho)
        {
            Tuple<string, int> tplInicial = oCromoFilho.ListaRotas[0];
            
            oCromoPegar.ListaRotas.ForEach( rota =>
             {
                 if( oCromoFilho.ListaRotas.Where( item => item.Item1.Equals( rota.Item1 ) ).Count() == 0 )
                 {
                     oCromoFilho.AdicionarRota( rota.Item1, rota.Item2 );
                 }
             } );

            oCromoFilho.AdicionarRota( tplInicial.Item1, 0 );

            oCromoFilho.TabelaDistancias = dtbDistancias;

            oCromoFilho.RecalcularDistancias();
        }

        private Cromossomo SortearCandidato()
        {
            Random oRandom = new Random();

            int iSorteado = oRandom.Next( lstPopulacao.Count );

            return lstPopulacao[iSorteado];
        }

        private bool AnalisarPredominante( Cromossomo pCromo1, Cromossomo pCromo2 )
        {
            int iTotalCromo1Metade1 = 0;
            int iTotalCromo1Metade2 = 0;
            int iTotalCromo2Metade1 = 0;
            int iTotalCromo2Metade2 = 0;
            int iContador = 0;
            List<Tuple<Cromossomo, int>> lstMaioresMenores = new List<Tuple<Cromossomo, int>>();
            bool bRetorno = false;

            foreach( Tuple<string, int> cromo1 in pCromo1.ListaRotas )
            {
                if( iContador <= pCromo1.ListaRotas.Count / 2 )
                {
                    iTotalCromo1Metade1 += cromo1.Item2;
                }

                if( iContador > pCromo1.ListaRotas.Count / 2 )
                {
                    iTotalCromo1Metade2 += cromo1.Item2;
                }

                iContador++;
            }

            iContador = 0;
            foreach( Tuple<string, int> cromo2 in pCromo2.ListaRotas )
            {
                if( iContador <= pCromo1.ListaRotas.Count / 2 )
                {
                    iTotalCromo2Metade1 += cromo2.Item2;
                }

                if( iContador > pCromo1.ListaRotas.Count / 2 )
                {
                    iTotalCromo2Metade2 += cromo2.Item2;
                }

                iContador++;
            }

            if( iTotalCromo1Metade1 < iTotalCromo1Metade2 &&
                  iTotalCromo1Metade1 < iTotalCromo2Metade1 &&
                  iTotalCromo1Metade1 < iTotalCromo2Metade2 )
            {
                bRetorno = true;
                eLadoEscolher = eLado.esquerda;
            }

            else if( iTotalCromo1Metade2 < iTotalCromo1Metade1 &&
                iTotalCromo1Metade2 < iTotalCromo2Metade1 &&
                iTotalCromo1Metade2 < iTotalCromo2Metade2 )
            {
                bRetorno = true;
                eLadoEscolher = eLado.direita;
            }

            return bRetorno;
        }

        private void PegarMetadeEAdicionar(Cromossomo pCromossomo, Cromossomo pCromossomoFilho)
        {
            int iContador = 0;

            foreach( Tuple<string, int> oCromo in pCromossomo.ListaRotas )
            {
                if( eLadoEscolher == eLado.direita )
                {
                    if( iContador > pCromossomo.ListaRotas.Count / 2 )
                    {
                        pCromossomoFilho.AdicionarRota( oCromo.Item1, oCromo.Item2 );
                    }
                }
                else
                {
                    if( iContador < pCromossomo.ListaRotas.Count / 2 )
                    {
                        pCromossomoFilho.AdicionarRota( oCromo.Item1, oCromo.Item2 );
                    }
                }

                iContador++;
            }
        }

        #endregion Fim [Métodos]
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaixeiroViajante
{
    public class Populacao
    {
        #region [Atributos e Propriedades]

        private List<Cromossomo> lstCromossomos = new List<Cromossomo>();

        private int iQtdCidades = 0;

        private DataTable dtbRotas = new DataTable();

        public List<Cromossomo> ListaPopulacao
        {
            get { return lstCromossomos; }
        }

        #endregion Fim [Atributos e Propriedades]

        #region [Construtor]

        public Populacao( int pQtdCidades, DataTable pDtbRotas )
        {
            iQtdCidades = pQtdCidades;
            dtbRotas = pDtbRotas;
        }

        #endregion Fim [Construtor]

        #region [Métodos]

        /// <summary>
        /// Cálculo do total da população que por padrão é o número de cidades * 5
        /// </summary>
        /// <returns></returns>
        public int CalcularPopulacao()
        {
            int nPopulacao = iQtdCidades * 5;

            return nPopulacao;
        }

        /// <summary>
        /// Gera uma lista com a população total 
        /// </summary>
        public void GeraPopulacao()
        {
            int iPopulacao = CalcularPopulacao();

            for( int i = 0; i <= iPopulacao; i++ )
            {
                lstCromossomos.Add( GerarCromossomo() );
            }
        }

        /// <summary>
        /// Método para gerar um cromosso a partir do sorteio de itens da lista
        /// </summary>
        /// <returns></returns>
        private Cromossomo GerarCromossomo()
        {
            List<Tuple<string, int>> lstColunas = new List<Tuple<string, int>>();

            Cromossomo oCromossomo = new Cromossomo();

            List<string> lstColunasSelecionadas = new List<string>();

            string sRota = "";

            string sRotaAnterior = "";

            int iRota = -1;

            Tuple<string, int> tplInicial = null;

            int iIndiceSorteio = 0;

            int iPrimeiraCidade = 0;

            Random oRandom = new Random();

            foreach( DataColumn drwColuna in dtbRotas.Columns )
            {
                if( iPrimeiraCidade > 0 )
                    lstColunas.Add( new Tuple<string, int>( drwColuna.ColumnName, drwColuna.Ordinal ) );

                iPrimeiraCidade++;
            }

            Thread.Sleep( 30 );

            iIndiceSorteio = oRandom.Next( lstColunas.Count - 1 );

            tplInicial = lstColunas[iIndiceSorteio];

            sRotaAnterior = tplInicial.Item1;

            iPrimeiraCidade = 0;

            while( iQtdCidades > oCromossomo.ListaRotas.Count )
            {
                sRota = lstColunas[iIndiceSorteio].Item1;

                iRota = lstColunas[iIndiceSorteio].Item2;

                if( !lstColunasSelecionadas.Contains( sRota ) )
                {
                    oCromossomo.AdicionarRota( sRota, iPrimeiraCidade > 0 ? CalcularDistancia( iRota, sRotaAnterior ) : 0);

                    sRotaAnterior = sRota;

                    lstColunasSelecionadas.Add( sRota );

                    iPrimeiraCidade++;
                }

                Thread.Sleep( 10 );

                iIndiceSorteio = oRandom.Next( lstColunas.Count );
            }

            oCromossomo.AdicionarRota( sRota, CalcularDistancia( iRota, tplInicial.Item1 ) );

            oCromossomo.TabelaDistancias = dtbRotas;

            return oCromossomo;
        }

        /// <summary>
        /// Calcula a distância de uma cidade a outra buscando na tabela de cidades
        /// </summary>
        /// <param name="pOrigem"></param>
        /// <param name="pDestino"></param>
        /// <returns></returns>
        private int CalcularDistancia( int pOrigem, string pDestino )
        {
            return Convert.ToInt32( dtbRotas.Rows[pOrigem - 1][pDestino] );
        }

        #endregion Fim [Métodos]

    }
}

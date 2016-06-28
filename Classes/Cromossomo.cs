using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaixeiroViajante
{
    public class Cromossomo
    {
        #region [Atributos]

        private DataTable dtbDistancias = new DataTable();

        private List<int> lstEntradas = new List<int>();

        //Lista com as rotas
        //A string contém o "nome da cidade"
        //O inteiro contém a distância
        private List<Tuple<string, int>> lstRotas = new List<Tuple<string, int>>();

        /// <summary>
        /// Cálcula o fitness
        /// </summary>
        public double Fitness
        {
            get
            {
                double nFitness = 0;
                nFitness = ( 1.0 / lstRotas.AsEnumerable().Sum( carinha => carinha.Item2 ) );

                return nFitness;
            }
        }

        /// <summary>
        /// Distancia total do cromossomo
        /// </summary>
        public int Distancia
        {
            get
            {
                return lstRotas.AsEnumerable().Sum( carinha => carinha.Item2 );
            }
        }

        public List<Tuple<string,int>> ListaRotas
        {
            get { return lstRotas; }
        }

        /// <summary>
        /// Tabela de distâncias
        /// </summary>
        public DataTable TabelaDistancias
        {
            get { return dtbDistancias; }
            set { dtbDistancias = value; }
        }

        #endregion Fim [Atributos]

        #region [Construtor]
        public Cromossomo()
        {
            
        }

        #endregion Fim [Construtor]

        #region [Métodos]

        /// <summary>
        /// Adiciona uma nova rota a lista de rotas
        /// </summary>
        /// <param name="pNomeColuna"></param>
        /// <param name="pDistancia"></param>
        public void AdicionarRota( string pNomeColuna, int pDistancia )
        {
            lstRotas.Add( new Tuple<string, int>( pNomeColuna, pDistancia ) );
        }

        /// <summary>
        /// Método para recalcular distâncias
        /// </summary>
        public void RecalcularDistancias()
        {
            string sRota = lstRotas[0].Item1;
            int iIndice = Convert.ToInt32( lstRotas[0].Item1.Substring( lstRotas[0].Item1.Length - 1 ) );
            int iContador = 0;
            List<Tuple<string, int>> lstNovasDistancias = new List<Tuple<string, int>>();

            lstNovasDistancias.Add( lstRotas[0] );

            lstRotas.ForEach( rota =>
             {
                 iIndice = Convert.ToInt32( rota.Item1.Substring( rota.Item1.Length - 1 ) );
                 if( iContador > 0 )
                     lstNovasDistancias.Add( new Tuple<string, int>( rota.Item1, CalcularDistancia( iIndice, sRota ) ) );

                 iContador++;
                 sRota = rota.Item1;

             } );

            lstRotas.Clear();
            lstRotas = lstNovasDistancias;
        }

        /// <summary>
        /// Calcula a distância de uma cidade a outra buscando na tabela de cidades
        /// </summary>
        /// <param name="pOrigem"></param>
        /// <param name="pDestino"></param>
        /// <returns></returns>
        private int CalcularDistancia( int pOrigem, string pDestino )
        {
            return Convert.ToInt32( dtbDistancias.Rows[pOrigem > 0 ? pOrigem : 0][pDestino] );
        }

        #endregion Fim [Métodos]
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixeiroViajante
{
    public class Populacao
    {

        private List<Cromossomo> lstCromossomos = new List<Cromossomo>();
        private int iQtdCidades = 0;
        private int nPercentual = 0;
        private double iFitnessMinimo = 0;

        public Populacao( int pQtdCidades, int pPercentual, double pFitnessMinimo )
        {
            iQtdCidades = pQtdCidades;
            nPercentual = pPercentual;
            iFitnessMinimo = pFitnessMinimo;
        }

        public int CalcularPopulacao()
        {
            int nPopulacao = Combinacao( iQtdCidades );
            double nValPercentual = ( Convert.ToDouble( nPercentual ) / 100 );

            nPopulacao = Convert.ToInt32( nPopulacao * ( nValPercentual ) );

            return nPopulacao;
        }

        private int Fatorial( int x )
        {
            int i, fat = 1;
            for( i = x; i >= 2; i-- )
            {
                fat *= i;
            }
            return fat;
        }

        private int Combinacao( int n )
        {
            return ( Fatorial( n ) );
        }

        public void GeraPopulacao()
        {
            int iPopulacao = CalcularPopulacao();
            Cromossomo oCromosso = null;

            for( int i = 0; i <= iPopulacao; i++ )
            {
                oCromosso = new Cromossomo();

                if( oCromosso.Fitness > iFitnessMinimo )
                    lstCromossomos.Add( oCromosso );
            }
        }
    }
}

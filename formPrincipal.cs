using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixeiroViajante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerar_Click( object sender, EventArgs e )
        {
            this.GerarDistancias();
        }

        private void GerarDistancias()
        {
            DataTable dtbDistancias = new DataTable();

            int iNumCidades = Convert.ToInt32( txtCidades.Text );
            DataColumn dcNovaColuna = null;
            DataRow drwNovaLinha = null;

            DataColumn dcPrimeiraColuna = new DataColumn( "C", typeof( string ) );
            //DataRow drwPrimeiraLinha = dtbDistancias.NewRow();
            dtbDistancias.Columns.Add( dcPrimeiraColuna );
            //dtbDistancias.Rows.Add( drwPrimeiraLinha );

            if( iNumCidades > 0 )
            {
                for( int i = 0; i < iNumCidades; i++ )
                {
                    dcNovaColuna = new DataColumn( "CIDADE_" + i, typeof( double ) );

                    dtbDistancias.Columns.Add( dcNovaColuna );
                }

                for( int i = 0; i < iNumCidades; i++ )
                {
                    drwNovaLinha = dtbDistancias.NewRow();

                    drwNovaLinha["C"] = "CIDADE_" + i;

                    dtbDistancias.Rows.Add( drwNovaLinha );
                }

                int iContadorColuna = 0;
                foreach( DataRow drwLinha in dtbDistancias.Rows )
                {

                    iContadorColuna = 0;
                    foreach( DataColumn dcCol in dtbDistancias.Columns )
                    {
                        if( iContadorColuna > 0 )
                            drwLinha[dcCol] = GerarNumeroAleatorio();

                        iContadorColuna++;
                    }
                }

                grdDistancias.DataSource = dtbDistancias;
            }
        }

        public int GerarNumeroAleatorio()
        {
            Random oRandom = new Random();
            int iMaximo = Convert.ToInt32( txtMaximo.Text );
            int iRetorno = 0;

            Thread.Sleep( 30 );
            if( iMaximo > 0 )
                iRetorno = oRandom.Next( iMaximo );
            else
                iRetorno = oRandom.Next( iMaximo );

            return iRetorno;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Populacao oPopulacao = new Populacao( Convert.ToInt32( txtCidades.Text ), Convert.ToInt32( txtPopulacao.Text ), ( Convert.ToDouble( txtFitnessMinimo.Text ) / 100 ) );
            oPopulacao.CalcularPopulacao();
            oPopulacao.GeraPopulacao();
        }
    }
}

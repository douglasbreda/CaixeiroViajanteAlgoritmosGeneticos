using CaixeiroViajante.Classes;
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
    public partial class formInicial : Form
    {
        #region [Atributos]

        DataTable dtbDistancias = new DataTable();

        #endregion Fim [Atributos]

        #region [Construtor]

        public formInicial()
        {
            InitializeComponent();
        }

        #endregion Fim [Construtor]

        #region [Eventos]

        private void btnGerar_Click( object sender, EventArgs e )
        {
            this.GerarDistancias();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Populacao oPopulacao = new Populacao( Convert.ToInt32( txtCidades.Text ), dtbDistancias );
            oPopulacao.CalcularPopulacao();
            oPopulacao.GeraPopulacao();

            Selecao oSelecao = new Selecao( oPopulacao.ListaPopulacao, Convert.ToInt32( txtSelecionados.Text ), Convert.ToInt32( txtCidades.Text ) );
            oSelecao.AplicarSelecaoRoleta();

            Cruzamento oCruzamento = new Cruzamento( oSelecao.NovaPopulacao );
            oCruzamento.Distancias = dtbDistancias;
            oCruzamento.NovaGeracao();
        }

        #endregion Fim [Eventos]

        #region [Métodos]

        private void GerarDistancias()
        {
            dtbDistancias = new DataTable();
            int iNumCidades = Convert.ToInt32( txtCidades.Text );
            DataColumn dcNovaColuna = null;
            DataRow drwNovaLinha = null;

            DataColumn dcPrimeiraColuna = new DataColumn( "C", typeof( string ) );

            dcPrimeiraColuna.ReadOnly = true;
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


                //Zera todas os valores
                for( int i = 0; i < dtbDistancias.Rows.Count; i++ )
                {
                    for( int j = 1; j < dtbDistancias.Columns.Count; j++ )
                    {
                        dtbDistancias.Rows[i][j] = 0;
                    }
                }

                bool bPrimeiraColuna = true;

                int iContadorColuna = 1;

                foreach( DataRow drwLinha in dtbDistancias.Rows )
                {
                    foreach( DataColumn dcCol in dtbDistancias.Columns )
                    {
                        if( !bPrimeiraColuna && dcCol.Ordinal > iContadorColuna )
                            drwLinha[dcCol] = GerarNumeroAleatorio();

                        bPrimeiraColuna = false;
                    }
                    
                    iContadorColuna++;
                }

                EspelharTabela();
                grdDistancias.DataSource = dtbDistancias;
            }
        }

        private void EspelharTabela()
        {
            bool bPrimeiraColuna = true;
            for( int i = 0; i < dtbDistancias.Rows.Count; i++ )
            {
                bPrimeiraColuna = true;
                for( int j = 0; j < dtbDistancias.Columns.Count; j++ )
                {
                    if( !bPrimeiraColuna )
                    {
                        if( Convert.ToInt32( dtbDistancias.Rows[i][j] ) == 0 )
                            dtbDistancias.Rows[i][j] = Convert.ToInt32( dtbDistancias.Rows[j >= dtbDistancias.Rows.Count ? j - 1 : j > 0 ? j - 1 : j][i + 1] );
                    }

                    bPrimeiraColuna = false;
                }
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

            if( iRetorno == 0 )
                GerarNumeroAleatorio();

            return iRetorno;
        }

        #endregion Fim [Métodos]
    }
}


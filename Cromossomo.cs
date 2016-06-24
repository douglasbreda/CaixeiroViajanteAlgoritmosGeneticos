using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaixeiroViajante
{
    public class Cromossomo
    {
        #region [Atributos]

        private List<int> lstEntradas = new List<int>();
        private double nFitness = 0;

        public double Fitness
        {
            get { return nFitness; }
            set { nFitness = value; }
        }

        #endregion Fim [Atributos]

        #region [Construtor]
        public Cromossomo()
        {
            GerarFitness();
        }

        #endregion Fim [Construtor]

        #region [Métodos]

        private double GerarFitness()
        {
            Random oRandom = new Random();

            Thread.Sleep( 30 );

            nFitness = oRandom.NextDouble();

            return nFitness;
        }

        #endregion Fim [Métodos]
    }
}

using System;
using System.Windows.Forms;

namespace Lab3
{
    public class CoinEater : PaymentStrategy
    {
        IKEAMyntAtare2000 eater;

        public CoinEater()
        {
            eater = new IKEAMyntAtare2000();
        }

        public override int BeginTransaction(float price)
        {
            eater.starta();
            eater.betala((int)Math.Round(price * 100));
            return 1;
        }

        public override bool EndTransaction(int id)
        {
            if (id != 1)
                return false;
            eater.stoppa();
            return true;
        }
    }

	public class IKEAMyntAtare2000
	{
		public void starta()
		{
			MessageBox.Show ("Välkommen till IKEA Mynt Ätare 2000");
		}

		public void stoppa()
		{
			MessageBox.Show ("Hejdå!");
		}

		public void betala(int pris)
		{
			MessageBox.Show (pris + " cent");
		}
	}
}


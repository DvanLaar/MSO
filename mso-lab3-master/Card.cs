using System;
using System.Windows.Forms;

namespace Lab3
{
	public abstract class Card : PaymentStrategy
	{
		public abstract void Connect();
        public abstract void Disconnect();
        public override abstract int BeginTransaction(float price);
        public override abstract bool EndTransaction(int id);
        public abstract void CancelTransaction(int id);
        public override void Pay(float price)
        {
            this.Connect();
            int id = this.BeginTransaction(price);
            this.EndTransaction(id);
            this.Disconnect();
        }
	}

	// Mock CreditCard implementation
	public class CreditCard : Card
	{
        public override void Connect()
		{
			MessageBox.Show ("Connecting to credit card reader");
		}

        public override void Disconnect()
		{
			MessageBox.Show ("Disconnecting from credit card reader");
		}

        public override int BeginTransaction(float amount)
		{
			MessageBox.Show ("Begin transaction 1 of " + amount + " EUR");
			return 1;
		}

        public override bool EndTransaction(int id)
		{
			if (id != 1)
				return false;

			MessageBox.Show("End transaction 1");
			return true;
		}

        public override void CancelTransaction(int id)
		{
			if (id != 1)
				throw new Exception ("Incorrect transaction id");

			MessageBox.Show("Cancel transaction 1");
		}
	}

	// Mock CreditCard implementation
	public class DebitCard : Card
	{
        public override void Connect()
		{
			MessageBox.Show ("Connecting to debit card reader");
		}

        public override void Disconnect()
		{
			MessageBox.Show ("Disconnecting from debit card reader");
		}

        public override int BeginTransaction(float price)
		{
			MessageBox.Show ("Begin transaction 1 of " + price + " EUR");
			return 1;
		}

        public override bool EndTransaction(int id)
		{
			if (id != 1)
				return false;

			MessageBox.Show("End transaction 1");
			return true;
		}

        public override void CancelTransaction(int id)
		{
			if (id != 1)
				throw new Exception ("Incorrect transaction id");

			MessageBox.Show("Cancel transaction 1");
		}
	}
}


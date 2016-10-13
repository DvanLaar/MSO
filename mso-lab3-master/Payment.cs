using System;

public abstract class PaymentStrategy
{
    abstract public int BeginTransaction(float price);
    abstract public bool EndTransaction(int id);
    public virtual void Pay(float price)
    {
        int id = this.BeginTransaction(price);
        this.EndTransaction(id);
    }
}
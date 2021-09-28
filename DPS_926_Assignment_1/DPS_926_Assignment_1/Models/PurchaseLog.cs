using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DPS_926_Assignment_1
{
    public class PurchaseLog
    {
        public String Name { get; private set; }
        public Decimal Total { get; private set; }
        public int Quantity { get; private set; }
        public DateTime PurchaseTime { get; private set;}

        public PurchaseLog(String name, Decimal total, int qt, DateTime purchaseTime)
        {
            this.Name = name;
            this.Total = total;
            this.Quantity = qt;
            this.PurchaseTime = purchaseTime;
        }

        public override bool Equals(object obj)
        {

            if (obj == null) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            PurchaseLog other = (PurchaseLog)obj;

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.Name.Equals(other.Name) && this.Total == other.Total
                && this.Quantity == other.Quantity && this.PurchaseTime == other.PurchaseTime;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + (int)this.Total + this.Quantity + this.PurchaseTime.GetHashCode();
        }
    }
}

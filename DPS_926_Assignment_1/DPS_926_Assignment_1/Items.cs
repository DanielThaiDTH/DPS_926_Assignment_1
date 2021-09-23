using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DPS_926_Assignment_1
{
    public class Item
    {
        public String Name { get; private set; }
        public Decimal Price { get; private set; }
        public int Quantity { get; set; }

        public Item(String name, Decimal price, int qt)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = qt;
        }

        public override bool Equals(object obj)
        {

            if (obj == null) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            Item other = (Item) obj;

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + 1;
        }
    }

}

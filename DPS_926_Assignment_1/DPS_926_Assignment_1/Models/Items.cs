//Daniel Thai

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DPS_926_Assignment_1
{
    /*Represents an item that can be purchased. Stores the name, price and quantity. 
      Will notify if quantity is changed. Equality is determined soley by the item name.*/
    public class Item :INotifyPropertyChanged
    {
        private int _quantity;
        public String Name { get; private set; }
        public Decimal Price { get; private set; }
        public int Quantity { 
            get { return _quantity; }
            set 
            {
                if (_quantity == value)
                    return;

                _quantity = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Quantity)));
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;

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

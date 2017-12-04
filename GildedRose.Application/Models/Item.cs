using System;

namespace GildedRose.Application.Models
{
    public class Item
    {
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentOutOfRangeException();

                _name = value;
            }

        }
        private string _name;

    }
}
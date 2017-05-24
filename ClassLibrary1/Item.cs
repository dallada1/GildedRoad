using System;

namespace GildedRose
{
    public abstract class Item
    {
        public String Name { get; protected set; }
        public Int32 SellIn { get; protected set; }
        public Int32 Quality { get; protected set; }

        public Item(String Name, Int32 SellIn, Int32 Quailty)
        {
            this.Name = Name;
            this.SellIn = SellIn;
            this.Quality = Quality;
        }

        public abstract void Update();

        protected Boolean IsLessThanMaxQuality()
        {
            return (Quality < 50);
        }

        protected void IncrementGenericItemQuality()
        {
            if (IsLessThanMaxQuality())
                IncreaseQuality();
        }

        protected void DecreaseQuality()
        {
            if (Quality > 0)
                Quality--;
        }

        protected void IncreaseQuality()
        {
            if (Quality > 0)
                Quality++;
        }

        protected void DecreaseSellInDateByOne()
        {
            SellIn--;
        }

       
    }
}

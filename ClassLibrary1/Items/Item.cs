using System;

namespace GildedRose
{
    public abstract class Item
    {
        private const Int32 MaxQuality = 50;
        private const Int32 MinQuality = 0;
        public String Name { get; protected set; }
        public Int32 SellIn { get; protected set; }
        public Int32 Quality { get; protected set; }

        public Item(Int32 SellIn, Int32 Quality)
        {
            this.SellIn = SellIn;
            this.Quality = Quality;
        }

        public abstract void Update();

        protected Boolean IsLessThanMaxQuality()
        {
            return (Quality < MaxQuality);
        }

        protected void IncrementGenericItemQuality()
        {
            if (IsLessThanMaxQuality())
                IncreaseQuality();
        }

        protected void DecreaseQuality()
        {
            if (Quality > MinQuality)
                Quality--;
        }

        protected void IncreaseQuality()
        {
            if (Quality > MinQuality)
                Quality++;
        }

        protected void DecreaseSellInDateByOne()
        {
            SellIn--;
        }
    }
}

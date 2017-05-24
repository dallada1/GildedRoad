using System;

namespace GildedRose.Items
{
    public class AgedBrie : Item
    {
        public AgedBrie(Int32 SellIn, Int32 Quailty) : base(SellIn, Quailty)
        {
            this.Name = "Aged Brie";
        }

        public override void Update()
        {
            DecreaseSellInDateByOne();

            if (IsLessThanMaxQuality())
                IncreaseQuality();

            if (SellIn < 0)
                IncreaseQuality();
        }
    }
}

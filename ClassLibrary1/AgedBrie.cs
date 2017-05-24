using System;

namespace GildedRose
{
    public class AgedBrie : Item
    {
        public AgedBrie(String Name, Int32 SellIn, Int32 Quailty) : base(Name, SellIn, Quailty)
        { }

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

using System;

namespace GildedRose
{
    public class BackstagePass : Item
    {
        private const Int32 ElevenDays = 11;
        private const Int32 SixDays = 6;

        public BackstagePass(Int32 SellIn, Int32 Quailty) : base(SellIn, Quailty)
        {
            this.Name = "Backstage passes to a TAFKAL80ETC concert";
        }

        public override void Update()
        {
            DecreaseSellInDateByOne();

            if (IsLessThanMaxQuality())
                IncreaseQuality();

            if (SellIn < ElevenDays)
                IncrementGenericItemQuality();

            if (SellIn < SixDays)
                IncrementGenericItemQuality();

            if (SellIn < 0)
                Quality = 0;
        }
    }
}
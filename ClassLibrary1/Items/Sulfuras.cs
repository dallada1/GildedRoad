using System;

namespace GildedRose.Items
{
    public class Sulfuras : Item
    {
        public Sulfuras(Int32 SellIn, Int32 Quailty) : base(SellIn, Quailty)
        {
            this.Name = "Sulfuras, Hand of Ragnaros";
        }

        public override void Update()
        { }
    }
}

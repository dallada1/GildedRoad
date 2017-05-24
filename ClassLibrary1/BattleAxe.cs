using System;

namespace GildedRose
{
    public class BattleAxe : Item
    {
        public BattleAxe(String Name, Int32 SellIn, Int32 Quailty) : base(Name, SellIn, Quailty)
        { }

        public override void Update()
        {
            DecreaseQuality();
            DecreaseSellInDateByOne();

            if (SellIn < 0)
                DecreaseQuality();
        }
    }
}

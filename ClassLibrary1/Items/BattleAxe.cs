using System;

namespace GildedRose
{
    public class BattleAxe : Item
    {
        public BattleAxe(Int32 SellIn, Int32 Quailty) : base(SellIn, Quailty)
        {
            this.Name = "Battle Axe";
        }

        public override void Update()
        {
            DecreaseQuality();
            DecreaseSellInDateByOne();

            if (SellIn < 0)
                DecreaseQuality();
        }
    }
}

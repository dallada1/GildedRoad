using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRoseInn
    {
        public List<Item> Items { get; set; }
        private const Int32 ElevenDays = 11;
        private const Int32 SixDays = 6;

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (IsGenericItem(Items[i]))
                    UpdateGenericItem(Items[i]);
                else if (Items[i].Name == ItemNames.BackstagePass)
                    UpdateBackstagePassBelowElevenAndSixDays(Items[i]);
                else if (Items[i].Name == ItemNames.AgedBrie)
                    UpdateAgedBrie(Items[i]);
            }
        }

        private void UpdateGenericItem(Item item)
        {
            DecreaseItemQuality(item);
            DecreaseSellInDateByOne(item);
            
            if (item.SellIn < 0)
                DecreaseItemQuality(item);
        }

        private void UpdateBackstagePassBelowElevenAndSixDays(Item item)
        {
            DecreaseSellInDateByOne(item);

            if (IsLessThanMaxQuality(item))
                IncreaseItemQuality(item);

            if (item.SellIn < ElevenDays)
                IncrementGenericItemQuality(item);

            if (item.SellIn < SixDays)
                IncrementGenericItemQuality(item);

            if (item.SellIn < 0)
                item.Quality = 0;
        }

        private void UpdateAgedBrie(Item item)
        {
            DecreaseSellInDateByOne(item);

            if (IsLessThanMaxQuality(item))
                IncreaseItemQuality(item);

            if (item.SellIn < 0)
                IncreaseItemQuality(item);
        }

        private Boolean IsGenericItem(Item item)
        {
            return item.Name != ItemNames.AgedBrie && item.Name != ItemNames.BackstagePass && item.Name != ItemNames.Sulfuras;
        }
        
        private Boolean IsLessThanMaxQuality(Item item)
        {
            return (item.Quality < 50);
        }

        private void IncrementGenericItemQuality(Item item)
        {
            if (IsLessThanMaxQuality(item))
                IncreaseItemQuality(item);
        }

        private void DecreaseItemQuality(Item item)
        {
            if (item.Quality > 0)
                item.Quality--;
        }

        private void IncreaseItemQuality(Item item)
        {
            if (item.Quality > 0)
                item.Quality++;
        }

        private void DecreaseSellInDateByOne(Item item)
        {
            item.SellIn--;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}

using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRoseInn
    {
        public List<Item> Items { get; set; }
      
        public void UpdateQuality()
        {
            foreach (var item in Items)
                item.Update();
        }
    }
}

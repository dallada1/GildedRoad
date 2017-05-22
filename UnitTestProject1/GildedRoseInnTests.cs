using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseTests
{
    [TestClass]
    public class GildedRoseInnTests
    {
        private GildedRoseInn gildedRose;

        public GildedRoseInnTests()
        {
            gildedRose = new GildedRoseInn();
            gildedRose.Items = new List<Item>();
        }

        [TestMethod]
        public void TestNonSpecialItemDecrementsOneQualityAfterOneDay()
        {
            var nonSpecialItem = CreateNewItem("Generic Item", 50, 50);

            gildedRose.Items.Add(nonSpecialItem);
            gildedRose.UpdateQuality();

            var updatedGenericItem = GetItemByName(nonSpecialItem.Name);

            Assert.AreEqual(49, updatedGenericItem.SellIn);
            Assert.AreEqual(49, updatedGenericItem.Quality);
        }

        private Item CreateNewItem(String itemName, Int32 sellIn, Int32 quality)
        {
            var item = new Item();
            item.Name = itemName;
            item.SellIn = sellIn;
            item.Quality = quality;

            return item;
        }

        private Item GetItemByName(String itemName)
        {
            return gildedRose.Items.Where(i => i.Name == itemName).First(); 
        }
    }
}

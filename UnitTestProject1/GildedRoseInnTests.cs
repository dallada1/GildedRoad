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
        public void NonSpecialItemDecrementsOneQualityAfterOneDay()
        {
            UpdateGildedRoseInventory(new List<Item> { new BattleAxe(ItemNames.GenericItem, 50, 50) });

            var updatedItem = GetItemByName(ItemNames.GenericItem);

            Assert.AreEqual(49, updatedItem.SellIn);
            Assert.AreEqual(49, updatedItem.Quality);
        }

        [TestMethod]
        public void NonSpecialItemDecrementsTwoQualityAfterSellByDate()
        {
            UpdateGildedRoseInventory(new List<Item> { new BattleAxe(ItemNames.GenericItem, 0, 50) });

            var updatedItem = GetItemByName(ItemNames.GenericItem);

            Assert.AreEqual(-1, updatedItem.SellIn);
            Assert.AreEqual(48, updatedItem.Quality);
        }

        [TestMethod]
        public void NonSpecialItemDoesNotDecrementQualityBelowZero()
        {
            UpdateGildedRoseInventory(new List<Item> { new BattleAxe(ItemNames.GenericItem, 50, 0) });

            var updatedItem = GetItemByName(ItemNames.GenericItem);


            Assert.AreEqual(49, updatedItem.SellIn);
            Assert.AreEqual(0, updatedItem.Quality);
        }

        [TestMethod]
        public void AgedBrieIncrementPlusOneAfterOneDay()
        {
            UpdateGildedRoseInventory(new List<Item> { new AgedBrie(ItemNames.AgedBrie, 50, 10) });

            var updatedItem = GetItemByName(ItemNames.AgedBrie);

            Assert.AreEqual(49, updatedItem.SellIn);
            Assert.AreEqual(11, updatedItem.Quality);
        }

        [TestMethod]
        public void AgedBrieIncreasesTwiceAsFastAfterSellByIsLessThanZero()
        {
            UpdateGildedRoseInventory(new List<Item> { new AgedBrie(ItemNames.AgedBrie, 0, 10) });

            var updatedItem = GetItemByName(ItemNames.AgedBrie);

            Assert.AreEqual(-1, updatedItem.SellIn);
            Assert.AreEqual(12, updatedItem.Quality);
        }

        [TestMethod]
        public void AgedBrieQualityCannotExceedFifty()
        {
            UpdateGildedRoseInventory(new List<Item> { new AgedBrie(ItemNames.AgedBrie, 50, 50) });

            var updatedItem = GetItemByName(ItemNames.AgedBrie);

            Assert.AreEqual(49, updatedItem.SellIn);
            Assert.AreEqual(50, updatedItem.Quality);
        }

        [TestMethod]
        public void AgedBrieDoesNotDecreaseByTwoUnderTen()
        {
            UpdateGildedRoseInventory(new List<Item> { new AgedBrie(ItemNames.AgedBrie, 9, 10) });

            var updatedItem = GetItemByName(ItemNames.AgedBrie);

            Assert.AreEqual(8, updatedItem.SellIn);
            Assert.AreEqual(11, updatedItem.Quality);
        }

        [TestMethod]
        public void SulfurasDoesNotDecrementQualityOrSellInDate()
        {
            UpdateGildedRoseInventory(new List<Item> { new Sulfuras(ItemNames.Sulfuras, 50, 80) });

            var updatedItem = GetItemByName(ItemNames.Sulfuras);

            Assert.AreEqual(50, updatedItem.SellIn);
            Assert.AreEqual(80, updatedItem.Quality);
        }

        [TestMethod]
        public void BackstagePassesIncreaseQualityByOneWhenSellByDateIsGreaterThanTenDays()
        {
            UpdateGildedRoseInventory(new List<Item> { new BackstagePass(ItemNames.BackstagePass, 50, 10) });

            var updatedItem = GetItemByName(ItemNames.BackstagePass);

            Assert.AreEqual(49, updatedItem.SellIn);
            Assert.AreEqual(11, updatedItem.Quality);
        }

        [TestMethod]
        public void BackstagePassesIncreaseQualityByTwoWhenSellByDateIsBetweenTenAndSixInclusively()
        {
            UpdateGildedRoseInventory(new List<Item> { new BackstagePass(ItemNames.BackstagePass, 10, 10) });

            var updatedItem = GetItemByName(ItemNames.BackstagePass);

            Assert.AreEqual(9, updatedItem.SellIn);
            Assert.AreEqual(12, updatedItem.Quality);
        }

        [TestMethod]
        public void BackstagePassesIncreaseQualityByThreeWhenSellByDateIsBetweenFiveAndZeroInclusively()
        {
            UpdateGildedRoseInventory(new List<Item> { new BackstagePass(ItemNames.BackstagePass, 5, 10) });

            var updatedItem = GetItemByName(ItemNames.BackstagePass);

            Assert.AreEqual(4, updatedItem.SellIn);
            Assert.AreEqual(13, updatedItem.Quality);
        }

        [TestMethod]
        public void BackstagePassesQualityBecomesZeroAfterSellInIsLessThanZero()
        {
            UpdateGildedRoseInventory(new List<Item> { new BackstagePass(ItemNames.BackstagePass, -1, 10) });

            var updatedItem = GetItemByName(ItemNames.BackstagePass);

            Assert.AreEqual(-2, updatedItem.SellIn);
            Assert.AreEqual(0, updatedItem.Quality);
        }

        [TestMethod]
        public void UpdatesMultipleItemsAtOnce()
        {
            UpdateGildedRoseInventory(new List<Item>
            {
                new BackstagePass(ItemNames.BackstagePass, 20, 15),
                new BattleAxe(ItemNames.GenericItem, 50, 10),
                new AgedBrie(ItemNames.AgedBrie, 40, 30)
            });

            var backstagePass = GetItemByName(ItemNames.BackstagePass);
            var genericItem = GetItemByName(ItemNames.GenericItem);
            var agedBrie = GetItemByName(ItemNames.AgedBrie);

            Assert.AreEqual(19, backstagePass.SellIn);
            Assert.AreEqual(16, backstagePass.Quality);

            Assert.AreEqual(49, genericItem.SellIn);
            Assert.AreEqual(9, genericItem.Quality);

            Assert.AreEqual(39, agedBrie.SellIn);
            Assert.AreEqual(31, agedBrie.Quality);
        }

        [TestMethod]
        public void MultipleUpdatesForASingleItem()
        {
            UpdateGildedRoseInventory(new List<Item> { new BattleAxe(ItemNames.GenericItem, 40, 10) }, 2);

            var updatedItem = GetItemByName(ItemNames.GenericItem);

            Assert.AreEqual(38, updatedItem.SellIn);
            Assert.AreEqual(8, updatedItem.Quality);
        }

        private Item GetItemByName(String itemName)
        {
            return gildedRose.Items.Where(i => i.Name == itemName).First(); 
        }

        private void UpdateGildedRoseInventory(List<Item> items, Int32 numberOfUpdates = 1)
        {
            gildedRose.Items.AddRange(items);

            for(int i = 0; i < numberOfUpdates; i++)
                gildedRose.UpdateQuality();
        }
    }
}

using System;
using GildedRose.Application.Models;
using GildedRose.Application.Operations;
using NUnit.Framework;


namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTests
    {

        private readonly InventoryManager _inventoryManager = new InventoryManager();
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Throw_Exception_When_Item_Name_Is_Empty(string name)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Item { Name = name } );
        }

        [Test]
        [TestCase("Aged Brie", 5, 2, 4, 3)]
        [TestCase("Aged Brie", 1, 1, 0, 2)]
        public void Aged_Brie_Increases_Quality_When_SellInValue_Decrease(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = ItemInitialization(name, sellIn, quality);

            var result = _inventoryManager.UpdateQuality(item);

            Assert.That(result.SellIn, Is.EqualTo(expectedSellIn));
            Assert.That(result.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        [TestCase("Normal Item", 2, 2, 1, 1)]
        public void Normal_Item_Decrease_Quality_By_One_When_SellInValue_Decrease_Before_SellByDate_Passed(string name, int quality, int sellIn, int expectedSellIn, int expectedQuality)
        {
            var item = ItemInitialization(name, sellIn, quality);

            var result = _inventoryManager.UpdateQuality(item);

            Assert.That(result.Quality, Is.EqualTo(expectedQuality));
            Assert.That(result.SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase("Normal Item", -1, 55, -2, 50)]
        public void Normal_Item_Decrease_Quality_By_One_When_SellInValue_Decrease_After_SellByDate_Passed(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = ItemInitialization(name, sellIn, quality);

            var result = _inventoryManager.UpdateQuality(item);

            Assert.That(result.Quality, Is.EqualTo(expectedQuality));
            Assert.That(result.SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase("Sulfuras", 2, 2, 2, 2)]
        public void Sulfuras_Do_Not_Increase_Or_Decrease_Quality(string name, int sellIn, int quality,
            int expectedSellIn, int expectedQuality)
        {
            var item = ItemInitialization(name, sellIn, quality);

            var result = _inventoryManager.UpdateQuality(item);

            Assert.That(result.Quality, Is.EqualTo(expectedQuality));
            Assert.That(result.SellIn, Is.EqualTo(expectedSellIn));
            
        }

        [Test]
        [TestCase("INVALID ITEM", 2, 2, "NO SUCH ITEM")]
        public void Output_No_Such_Item_When_Item_Name_Is_Invalid_Item(string name, int sellIn, int quality, string expectedOutput)
        {
            var item = ItemInitialization(name, sellIn, quality);

            var result = _inventoryManager.UpdateQuality(item);

            Assert.That(result.Name, Is.EqualTo(expectedOutput));
        }


        [Test]
        [TestCase("Backstage passes", 9, 2, 8, 4)]
        public void Backstage_Passes_Qaulity_Increases_By_Two_Between_Six_To_Ten_Days(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = ItemInitialization(name, sellIn, quality);

            var result = _inventoryManager.UpdateQuality(item);

            Assert.That(result.Quality, Is.EqualTo(expectedQuality));
            Assert.That(result.SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase("Backstage passes", 4, 3, 3, 6)]
        public void Backstage_Passes_Qaulity_Increases_By_Three_Between_One_To_Five_Days(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = ItemInitialization(name, sellIn, quality);

            var result = _inventoryManager.UpdateQuality(item);

            Assert.That(result.Quality, Is.EqualTo(expectedQuality));
            Assert.That(result.SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase("Backstage passes",-1, 2, -2, 0)]
        public void Backstage_Passes_Qaulity_Drop_To_Zero_After_Concert_SellIn_Value_Is_Less_Than_Zero(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = ItemInitialization(name, sellIn, quality);

            var result = _inventoryManager.UpdateQuality(item);

            Assert.That(result.Quality, Is.EqualTo(expectedQuality));
            Assert.That(result.SellIn, Is.EqualTo(expectedSellIn));
        }

        [Test]
        [TestCase("Conjured", 2, 2, 1, 0)]
        [TestCase("Conjured", -1, 5, -2, 1)]
        public void Conjured_Item_Qaulity_Decrease_Twice_As_Fast_As_Normal_Item(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = ItemInitialization(name, sellIn, quality);

            var result = _inventoryManager.UpdateQuality(item);

            Assert.That(result.Quality, Is.EqualTo(expectedQuality));
            Assert.That(result.SellIn, Is.EqualTo(expectedSellIn));
        }

        private static Item ItemInitialization(string name, int sellIn, int quality)
        {
            return new Item {Name = name, Quality = quality, SellIn = sellIn};
        }
    }
    
}



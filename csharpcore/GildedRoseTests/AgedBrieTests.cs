using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class AgedBrieTests
    {
        [Fact]
        public void QualityForAgedBrieIncreasesAfterUpdate()
        {
            var Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items); 
            
            app.UpdateQuality();
            
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(9,Items[0].SellIn);
            Assert.Equal(1,Items[0].Quality);
        }

        [Fact]
        public void QualityShouldNotIncreaseWhenInitialValueOver50()
        {
            var Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 52 } };
            GildedRose app = new GildedRose(Items); 
            
            app.UpdateQuality();
            
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(9,Items[0].SellIn);
            Assert.Equal(50,Items[0].Quality);
        }
        
        [Fact]
        public void QualityShouldNotChangeIfNegative()
        {
            var Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = -2 } };
            GildedRose app = new GildedRose(Items); 
            
            app.UpdateQuality();
            
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(9,Items[0].SellIn);
            Assert.Equal(-2,Items[0].Quality);
        }

        [Fact]
        public void QualityShouldNeverBeGreaterThen50()
        {
            var Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(Items); 
            
            app.UpdateQuality();
            
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(9,Items[0].SellIn);
            Assert.Equal(50,Items[0].Quality);
        }

        [Fact]
        public void QualityShouldIncreaseAfterSellInDate()
        {
            var Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 48 } };
            GildedRose app = new GildedRose(Items); 
            
            app.UpdateQuality();
            
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(-1,Items[0].SellIn);
            Assert.Equal(50,Items[0].Quality);
        }
    }
}

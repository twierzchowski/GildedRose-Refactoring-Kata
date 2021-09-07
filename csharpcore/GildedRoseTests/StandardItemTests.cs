using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class StandardItemTests
    {
        [Theory]
        [InlineData(4,3,2)]
        [InlineData(0,2,0)]
        [InlineData(0,1,0)]
        public void UpdateQuality_GivenSellIn_ShouldChangeQuality(int sellIn, int initialQuality, int expectedQuality)
        {
            //Given
            var items = new List<Item> { new Item { Name = "foo", SellIn = sellIn, Quality = initialQuality } };
            var app = new GildedRose(items);
            
            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(expectedQuality,items[0].Quality);
        }
        
        [Fact]
        public void UpdateQuality_ShouldNotDropQualityBelowZero()
        {
            //Given
            var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            var app = new GildedRose(items); 
            
            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(0,items[0].Quality);
        }
        
        [Fact]
        public void UpdateQuality_ShouldNotHaveNegative()
        {
            //Given
            var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = -2 } };
            var app = new GildedRose(items); 
            
            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(-2,items[0].Quality);
        }
    }
}

using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace GildedRoseTests
{
    public class SulfurasTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(-2)]
        public void UpdateQuality_ShouldNotChangeQuality(int quality)
        {
            //Given
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 4,
                    Quality = quality
                }
            };
            var app = new GildedRose(items);
            
            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(quality, items[0].Quality);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(0)]
        [InlineData(-5)]
        public void UpdateQuality_ShouldNotChangeSellIn(int sellIn)
        {
            //Given
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = sellIn,
                    Quality = 2
                }
            };
            var app = new GildedRose(items);

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(sellIn, items[0].SellIn);
        }
    }
}

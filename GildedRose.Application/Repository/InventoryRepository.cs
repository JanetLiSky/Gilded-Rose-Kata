using System.Collections.Generic;
using GildedRose.Application.Models;

namespace GildedRose.Application.Repository
{
    public static class InventoryRepository
    {
        public static IList<Item> Items { get; } = new List<Item>
        {
            new Item {Name = "Aged Brie", SellIn = 1, Quality = 1},
            new Item {Name = "Backstage passes", SellIn = -1, Quality = 2},
            new Item {Name = "Backstage passes", SellIn = 9, Quality = 2},
            new Item {Name = "Sulfuras", SellIn = 2, Quality = 2},
            new Item {Name = "Normal Item", SellIn = -1, Quality = 55},
            new Item {Name = "Normal Item", SellIn = 2, Quality = 2},
            new Item {Name = "INVALID ITEM", SellIn = 2, Quality = 2},
            new Item {Name = "Conjured", SellIn = 2, Quality = 2},
            new Item {Name = "Conjured", SellIn = -1, Quality = 5}
        };

    }

}
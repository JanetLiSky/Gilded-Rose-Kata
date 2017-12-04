using System.Collections.Generic;
using System.Linq;
using GildedRose.Application.Interfaces;
using GildedRose.Application.Models;
using GildedRose.Application.Repository;

namespace GildedRose.Application.Operations
{
    public class InventoryManager :IInventoryManager
    {
        private const int _maxQuality = 50;
        private const string _noItemValue = "NO SUCH ITEM";


        public IList<Item> UpdateInventory(IList<Item> items)
        {
            return items.Select(itm => UpdateQuality(itm)).ToList();
        }

        public Item UpdateQuality(Item item)
        {
            if (item.Name.Contains("Sulfuras")) return item;

            if (item.Name.Contains("INVALID ITEM"))
            {
                item.Name = _noItemValue;
            }

            if (item.Name.Contains("Aged Brie"))
            {
                item.Quality++;
            }

            if (item.Name.Contains("Normal Item"))
            {
                 item.Quality = CalculateNormalItemQuality(item);
            }

            if (item.Name.Contains("Conjured"))
            {
                item.Quality = CalculateConjuredItemQuality(item);
            }

            if (item.Name.Contains("Backstage passes"))
            {
                item.Quality = CalcuateBackstagePassItemQuality(item);
            }

            item.SellIn--;

            return item;
        }

        private static int CalculateNormalItemQuality(Item item)
        {
            var quality  = item.SellIn < 0 ? (item.Quality - 2) : (item.Quality - 1);
        
            return quality <= _maxQuality ? quality : _maxQuality; 
        }

        private static int CalculateConjuredItemQuality(Item item)
        {
            var quality = item.SellIn < 0 ? item.Quality - (2 * 2) : item.Quality - 2;

            return quality <= _maxQuality ? quality : _maxQuality;
        }

        private static int CalcuateBackstagePassItemQuality(Item item)
        {
            var quality = item.Quality;

            if (item.SellIn <= 10 && item.SellIn > 5)
            {
                quality = item.Quality + 2;
            }
            else if (item.SellIn <= 5 && item.SellIn > 0)
            {
                quality = item.Quality + 3;
            }
            else if (item.SellIn < 0)
            {
                quality = 0;
            }

            return quality <= _maxQuality ? quality : _maxQuality;
        }
        
    }
}
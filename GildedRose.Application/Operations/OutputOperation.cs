using static System.Console;
using System.Collections.Generic;
using GildedRose.Application.Models;

namespace GildedRose.Application.Operations
{
    public class OutputOperation
    {
        public static void OutputInventoryUpdateResults(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
               WriteLine(item.Name.Contains("NO SUCH ITEM")
                    ? $"\t {item.Name} "
                    : $"\t {item.Name}   {item.SellIn}   {item.Quality}");
            }
        }
    }
}
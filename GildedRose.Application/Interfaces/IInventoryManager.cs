using System.Collections.Generic;
using GildedRose.Application.Models;


namespace GildedRose.Application.Interfaces
{
    public interface IInventoryManager
    {
        IList<Item> UpdateInventory(IList<Item> items);
        Item UpdateQuality(Item item);
    }
}

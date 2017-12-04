using System;
using static System.Console;
using GildedRose.Application.Operations;
using GildedRose.Application.Repository;

namespace GildedRose.Application
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Write("Expected Output :");
            WriteLine(Environment.NewLine);

            var inventoryManager = new InventoryManager();
            var itemList = inventoryManager.UpdateInventory(InventoryRepository.Items);

            OutputOperation.OutputInventoryUpdateResults(itemList);

            WriteLine(Environment.NewLine);
            Write("Press Enter to continue!");
            ReadKey();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

using UnityEngine;

[System.Serializable]
public class Drop
{   
    [SerializeField] public ItemData Item;
    [SerializeField] public int MinDrop;
    [SerializeField] public int MaxDrop;
    [SerializeField] public float Chance;

    public Drop(ItemData item,int minDrop, int maxDrop, float percentageChance){
        Item = item;
        MinDrop = minDrop;
        MaxDrop = maxDrop;
        Chance = percentageChance;
    }

    public Drop(ItemData item, float percentageChance){
        Item = item;
        Chance = percentageChance;
    }

    public List<ItemInstance> DropLoot()
    {
        float randomNumber = Random.value * 100;
        
        if (randomNumber <= Chance)
        {
            int totalStackSize = Random.Range(MinDrop, MaxDrop);

            // Return empty list if no items to drop
            if (totalStackSize <= 0)
                return null;

            // Define the maximum stack size
            int maxStackSize = Item.StackSize; // Example value, replace with actual max stack size
            List<ItemInstance> droppedItems = new List<ItemInstance>();

            // While there are still items to distribute
            while (totalStackSize > 0)
            {
                // Determine the size of the next stack, either maxStackSize or whatever remains
                int currentStackSize = Mathf.Min(totalStackSize, maxStackSize);
                
                // Add the new ItemInstance to the list with the current stack size
                droppedItems.Add(new ItemInstance(Item, currentStackSize));
                
                // Decrease the remaining stack size by the amount used in this stack
                totalStackSize -= currentStackSize;
            }

            return droppedItems;
        }

        return null;
    }
}

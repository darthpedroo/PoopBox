using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestDropTable
{
    
    private ItemData _stackSize64Item;
    private ItemData _stackSize1Item;
    [SetUp]
    public void SetUp()
    {
        _stackSize64Item = ScriptableObject.CreateInstance<ItemData>();
        _stackSize64Item.Name = "StackSize64Item"; 
        _stackSize64Item.StackSize = 64;
        _stackSize1Item = ScriptableObject.CreateInstance<ItemData>();
        _stackSize1Item.StackSize = 1;
        _stackSize1Item.Name = "StackSize1Item";
    }

    [Test]
    public void DropTableGetDropsDivides400ItemsInto7Stacks()
    {
        DropTableBuilder builder = new();
        builder.Add(_stackSize64Item, minDrop: 400, maxDrop: 400, percentageChance: 100);
        DropTable dropTable = builder.GetDropTable();
        ItemInstance[] resultDrops = dropTable.GetDrops();
        Assert.AreEqual(7, resultDrops.Length, "Drop table should split 400 items into 7 stacks.");
    }
    [Test]
    public void DropTableGetDropsDivides7ItemsInto7Stacks()
    {
        DropTableBuilder builder = new();
        builder.Add(_stackSize1Item, minDrop: 7, maxDrop: 7, percentageChance: 100);
        DropTable dropTable = builder.GetDropTable();
        ItemInstance[] resultDrops = dropTable.GetDrops();
        Assert.AreEqual(7, resultDrops.Length, "Drop table should split 7 items into 7 stacks.");
    }
}

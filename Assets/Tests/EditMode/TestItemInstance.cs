using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestItemInstance
{
    // A Test behaves as an ordinary method
    private ItemInstance _testItem1;
    private ItemInstance _testItem2;
    private ItemData _testItemData;
    private ItemData _testItemData2;
    [SetUp]
    public void SetUp(){
        _testItemData = ScriptableObject.CreateInstance<ItemData>();
        _testItemData.Name = "testItemData"; 
        _testItemData.StackSize = 64;
        _testItemData2 = ScriptableObject.CreateInstance<ItemData>();
        _testItemData2.StackSize = 1;
        _testItemData2.Name = "testItemData2";
    }
    [Test]
    public void TestStackFailsWhenStackingTwoDifferentItems()
    {
        _testItem1 = new(_testItemData,2);
        _testItem2 = new(_testItemData2,1);
        Assert.IsFalse(_testItem1.Stack(_testItem2));
    }

    [Test]
    public void TestStackSeparatesItemCountCorrectly()
    {
        _testItem1 = new(_testItemData,34);
        _testItem2 = new(_testItemData,32);
        _testItem1.Stack(_testItem2);
        Assert.AreEqual(2,_testItem2.Count);
    }
    [Test]
    public void TestTwoInstancesOfTheSameItemAreEqual(){
        _testItem1 = new(_testItemData,34);
        _testItem2 = new(_testItemData,32);
        Assert.IsTrue(_testItem1 == _testItem2);
    }
    [Test]
    public void TestTwoDifferentItemsInstanceAreNotEqual(){
        _testItem1 = new(_testItemData,34);
        _testItem2 = new(_testItemData2,32);
        Assert.IsTrue(_testItem1 != _testItem2);
    }
}

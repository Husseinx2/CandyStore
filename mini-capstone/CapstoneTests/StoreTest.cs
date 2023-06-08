using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class StoreTest
    {
        [TestMethod]
        public void StoreTestObjectCreation()
        {
            //Arrange
            Store testObject = new Store();

            //Act (done in arrange above)

            //Assert
            Assert.IsNotNull(testObject);
        }

        [TestMethod]
        public void ShowInventoryTest()
        {
            // Arrange
            Store test = new Store();

            // Act
            List<Candy> result = test.ShowInventory();
            List<Candy> candies = new List<Candy>();

            // Assert
            //CollectionAssert.AllItemsAreInstancesOfType(result, new List<Candy>());
            CollectionAssert.AreEqual(candies, result);
        }

        [TestMethod]

        public void AddMoneyTest()
        {
            //arrange
            Store testOne = new Store();
            Store testTwo = new Store();
            Store testThree = new Store();
            //act
             testOne.AddMoney(10); //adds 10
             testTwo.AddMoney(1001); //adds 0
             testThree.AddMoney(-1); //adds 0

            decimal resultOne = testOne.GetMoney();
            decimal resultTwo = testTwo.GetMoney();
            decimal resultThree = testThree.GetMoney();
            //assert
            Assert.AreEqual(10,resultOne);
            Assert.AreEqual(0, resultTwo);
            Assert.AreEqual(0, resultThree);

        }
    }
}

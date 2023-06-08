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
    }
}

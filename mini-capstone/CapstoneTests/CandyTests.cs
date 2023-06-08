using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CandyTests
    {
        [TestMethod]
        public void CandyConstructorTest()
        {
            // Arrange CH C1 | Snuckers Bar | 1.35 | T
            Candy test = new Candy("CH", "C1", "Snuckers", 1.35M, true);

            // Act

            // Assert
            Assert.IsNotNull(test);
        }
    }
}

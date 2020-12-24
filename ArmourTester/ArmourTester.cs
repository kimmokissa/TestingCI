using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Testing2018;

namespace ArmourTester
{
    [TestClass]
    public class ArmourTester
    {

        [TestMethod]
        public void TestConditionMint()
        {
            Armour ar = new Armour("Jorma", "Kokkeli", 100, 2, 2);
            string condition = ar.getCondition();

            Assert.AreEqual("Mint", condition);

        }

        [TestMethod]
        public void TestConditionPoor()
        {
            int takeDam = 90;
            int prot = 100;
  
            Armour ar = new Armour("Jorma", "Kokkeli", prot, 2, 2);

            ar.takeDam(takeDam);
            string condition = ar.getCondition();

            Assert.AreEqual("Poor", condition);

        }

        [TestMethod]
        public void TestConditionDestroyed()
        {
            int takeDam = 100;
            Armour ar = new Armour("Jorma", "Kokkeli", takeDam, 2, 2);

            ar.takeDam(takeDam);
            string condition = ar.getCondition();

            Assert.AreEqual("Destroyed", condition);

        }
        [TestMethod]
        public void TestRepairDestroyedItemReturnsExcellent()
        {
            int takeDam = 100;
            Armour ar = new Armour("Jorma", "Kokkeli", takeDam, 2, 2);

            ar.takeDam(takeDam);
            
            ar.repair(81);
            string condition = ar.getCondition();
            Assert.AreEqual("Excellent", condition);

        }
        [TestMethod]
        public void TestOveRepairExcellentItemReturnsMint()
        {
            int takeDam = 20;
            Armour ar = new Armour("Jorma", "Kokkeli", 100, 2, 2);

            ar.takeDam(takeDam);
            
            ar.repair(105);
            string condition = ar.getCondition();
            Assert.AreEqual("Mint", condition);

        }
    }
}

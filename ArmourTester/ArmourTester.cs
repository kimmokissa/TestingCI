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
        public void TestCurrentProt()
        {
            // Tests that the current protection is the assumed 10 after taking 10 damage when having starting prot of 20.
            int takeDam = 10;
            Armour ar = new Armour("Jorma", "Kokkeli", 20, 2, 2);

            ar.takeDam(takeDam);
            int currentCond = ar.getCurProt();
            Assert.AreEqual(10, currentCond);
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
        public void TestOveRepairExcellentItemReturns100()
        {
            // Test that the repair method doesn't over repair the armor above the maxProt value.

            int takeDam = 20;
            Armour ar = new Armour("Jorma", "Kokkeli", 100, 2, 2);

            ar.takeDam(takeDam);
            
            ar.repair(105);

            int condition = ar.getCurProt();
            Assert.AreEqual(100, condition);
        }

        [TestMethod]
        public void TestNegativeRepair()
        {
            // Tests if the repair method takes negative int

            Armour ar = new Armour("Jorma", "Kokkeli", 100, 2, 2);


            ar.repair(-120);

            int condition = ar.getCurProt();
            Assert.AreNotEqual(0, condition);
        }

        [TestMethod]
        public void TestNegativeDamage()
        {
            // Tests if the repair method takes negative int

            Armour ar = new Armour("Jorma", "Kokkeli", 100, 2, 2);


            ar.takeDam(-120);

            int condition = ar.getCurProt();
            Assert.AreEqual(100, condition);
        }
    }
}

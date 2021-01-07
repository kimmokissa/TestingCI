using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Testing2018;

namespace ArmourTester
{
    [TestClass]
    public class ArmourTester
    {

        [TestMethod]
        public void getCondition_TakesDamageAndRepair_ReturnsMint()
        {
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);
            ar.takeDam(10);
            ar.repair(10);

            string condition = ar.getCondition();
            
            Assert.AreEqual("Mint", condition);
        }

        [TestMethod]
        public void getCondition_TakesDamage_ReturnsExcellent()
        {
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);
            ar.takeDam(10);

            string condition = ar.getCondition();

            Assert.AreEqual("Excellent", condition);
        }

        [TestMethod]
        public void getCondition_TakesDamage_ReturnsGood()
        {
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);
            ar.takeDam(30);

            string condition = ar.getCondition();

            Assert.AreEqual("Good", condition);
        }

        [TestMethod]
        public void getCondition_TakesDamage_ReturnsAverage()
        {
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);
            ar.takeDam(60);

            string condition = ar.getCondition();

            Assert.AreEqual("Average", condition);
        }

        [TestMethod]
        public void getCondition_TakesDamage_ReturnsWeak()
        {
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);
            ar.takeDam(80);

            string condition = ar.getCondition();

            Assert.AreEqual("Weak", condition);
        }

        [TestMethod]
        public void getCondition_TakesDamage_ReturnsPoor()
        {
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);
            ar.takeDam(90);

            string condition = ar.getCondition();

            Assert.AreEqual("Poor", condition);
        }

        [TestMethod]
        public void getCondition_TakesDamage_ReturnsDestroyed()
        {
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);
            ar.takeDam(100);
            string condition = ar.getCondition();

            Assert.AreEqual("Destroyed", condition);
        }

        [TestMethod]
        public void getCurProt_TakeDamage_ReturnsEqual()
        {
            // Tests that the current protection is the assumed 10 after taking 10 damage when having starting prot of 20.
            int takeDam = 10;
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 20, 2, 2);

            ar.takeDam(takeDam);
            int currentCond = ar.getCurProt();
            Assert.AreEqual(10, currentCond);
        }


        [TestMethod]
        public void repair_RepairDestroyedItem_ReturnsExcellent()
        {
            int takeDam = 100;
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", takeDam, 2, 2);

            ar.takeDam(takeDam);
            
            ar.repair(81);
            string condition = ar.getCondition();
            Assert.AreEqual("Excellent", condition);
        }

        [TestMethod]
        public void repair_OveRepairExcellentItem_ReturnsEqual()
        {
            // Test that the repair method doesn't over repair the armor above the maxProt value.

            int takeDam = 20;
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);

            ar.takeDam(takeDam);
            ar.repair(105);
            int maxProt = ar.getMaxProt();
            int curProt = ar.getCurProt();
            Assert.AreEqual(maxProt, curProt);
        }

        [TestMethod]
        public void getLevel_GetsArmorLevel_ReturnsEqual()
        {
            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);


            int level = ar.getLevel();
            Assert.AreEqual(2, level);
        }

        // The test below are trivial and makes one think how the Armour.cs is implemented, if one is allowed
        // to do negative repairing or negative damage intentionally or accidentally, what is the point of
        // having two separate methods, it could just be replaced with a single method that handles 
        // the damage taking and repairing, something like "changeCondition" method.

        [TestMethod]
        public void repair_NegativeRepair_ReturnsEqual()
        {
            // Tests if the repair method repairs with negative int, it should not.

            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);

            ar.repair(-100);

            int condition = ar.getCurProt();
            Assert.AreEqual(100, condition);
        }


        [TestMethod]
        public void takeDam_NegativeDamage_ReturnsEqual()
        {
            // Tests if the takeDam method with negative int, it should not.

            Armour ar = new Armour("Rautahanska", "Raudasta tehty käsine", 100, 2, 2);


            ar.takeDam(-100);

            int condition = ar.getCurProt();
            Assert.AreEqual(100, condition);
        }

    }
}

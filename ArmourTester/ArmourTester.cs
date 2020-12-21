using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Testing2018;

namespace ArmourTester
{
    [TestClass]
    public class ArmourTester
    {
        [TestMethod]
        public void TestLevel1()
        {
            Armour ar = new Armour("Jorma", "Kokkeli", 20, 2, 2);
            int lvl = ar.getLevel();

            if (lvl != 2) Assert.Fail();

        }
        [TestMethod]
        public void TestSlot1()
        {
            Armour ar = new Armour("Jorma", "Kokkeli", 20, 2, 2);
            int slot = ar.getSlot();

            if (slot != 2) Assert.Fail();

        }
        [TestMethod]
        public void TestCondition()
        {
            Armour ar = new Armour("Jorma", "Kokkeli", 20, 2, 2);
            string condition = ar.getCondition();

            Assert.AreEqual("Mint", condition);

        }

        [TestMethod]
        public void TestTakeDamageAndBreakArmor()
        {
            /*
             * Test take damage function by creating new Armour and assigning it damage equal
             * to its pProt value. It should now be Destroyed.
             */

            int takeDam = 20;
            Armour ar = new Armour("Jorma", "Kokkeli", takeDam, 2, 2);

            ar.takeDam(takeDam);
            string condition = ar.getCondition();

            Assert.AreEqual("Destroyed", condition);

        }
    }
}

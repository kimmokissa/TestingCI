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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing2018
{
    class Armour
    {
        private String name;
        private String desc; // briefly about the eqs appearance
        private int maxProt;  // how much it protects at its best
        private int curProt;  // how much it protects now
                              /*
                           * SLOTS:
                           * 0: Head
                           * 1: Torso
                           * 2: Arms
                           * 3: Legs
                           */
        private int slot;    // place where the eq is wielded
        private int level;    // armours level...


        public static int HEAD_SLOT = 0;
        public static int TORSO_SLOT = 1;
        public static int ARMS_SLOT = 2;
        public static int LEGS_SLOT = 3;

        public static int WEARTEAR = 1;

        /*
         * General constructor.  
         */
        public Armour(String pName, String pDesc, int pProt, int pSlot, int pLevel)
        {

            name = pName;
            desc = pDesc;
            maxProt = pProt;
            curProt = pProt;
            slot = pSlot;
            level = pLevel;

        }


        /*
         * Method for creating textural information about the condition of the eq.
         * Levels:
         * - 100%: Mint
         * - 80%: Excellent
         * - 60%: Good
         * - 40%: Average
         * - 20%: Weak
         * - 1%: Poor
         * - 0%: Destoyed
         */
        public String getCondition()
        {
            String retVal = "";
            // dividing integers are not usable here  
            double cur = curProt;
            double max = maxProt;
            // relation is double between 0.0 - 1.0
            double relation = cur / max;
            if (relation >= 1.0)
            {
                retVal = "Mint";
            }
            else if (relation >= 0.8)
            {
                retVal = "Excellent";
            }
            else if (relation >= 0.6)
            {
                retVal = "Good";
            }
            else if (relation >= 0.4)
            {
                retVal = "Average";
            }
            else if (relation >= 0.2)
            {
                retVal = "Weak";
            }
            else if (relation >= 0.01)
            {
                retVal = "Poor";
            }
            else
            {
                retVal = "Destroyed";
            }

            return retVal;
        }

        /*
         * Getter for the maximum protection.  
         */
        public int getMaxProt()
        {
            return maxProt;
        }
        /*
         * Getter for the current protection.  
         */
        public int getCurProt()
        {
            return curProt;
        }
        /*
         * Getter for the slot.  
         */
        public int getSlot()
        {
            return slot;
        }
        /*
         * Getter for level.  
         */
        public int getLevel()
        {
            return level;
        }
        /*
         * Method takeDam is createed to wear&tear the equipment.
         * @param amount parameter that includes information about the amount
         *        how much the curProt is reduced.
         */

        public void takeDam(int pAmount)
        {
            if ((curProt - pAmount) < 0)
            {
                curProt = 0;
            }
            else
            {
                curProt -= pAmount;
            }
        }

        /*
         * Method repair is createed to repair the equipment after wear&tear.
         * @param pAmount parameter that includes information about the amount
         *        how much the curProt is added.
         */

        public void repair(int pAmount)
        {
            if ((curProt + pAmount) > maxProt)
            {
                curProt = maxProt;
            }
            else
            {
                curProt = curProt + pAmount;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Rusu_AnaMaria_Proiect
{
    class Pancake
    {
        private PancakeType mFlavor;

        public PancakeType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        private float mPrice;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        public Pancake(PancakeType aFlavor) // constructor
        {
            mFlavor = aFlavor;
        }
    }
    public enum PancakeType
    {
        Chocolate,
        SourCherry,
        Banana,
        Mango,
        Pomegranate
    }

}

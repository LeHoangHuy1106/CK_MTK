﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.FactoryPattern
{
    class staff : AccountStaff
    {
        public string displayName()
        {
            string Numrd_str;
            Random rd = new Random();
            Numrd_str = (rd.Next(100000, 99999)).ToString();
            return "Staff" + Numrd_str;
        }

        public string images()
        {
            return null;
        }

        public string passWord()
        {
            return "0";
        }

        public int type()
        {
            return 2;
        }

        public string userName()
        {
            return this.displayName();   
        }
    }
}

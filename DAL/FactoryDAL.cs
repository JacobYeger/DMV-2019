﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDAL
    { 
          
      public static IDAL getInstance()
      {
            return new myDAL();
      }
        
    }
}


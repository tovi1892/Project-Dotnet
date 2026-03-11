using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXml;

static  internal class Config
{
    static private string fileName= "data-config";
    static private int productNextId;

    static public int MyProductNextId
    {
		get { return productNextId; }
		 
	}


}

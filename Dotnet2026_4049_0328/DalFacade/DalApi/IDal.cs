using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

public interface IDal
{
    Isale sale { get; }
    Iproduct product { get; }
    Icustomer customer  { get; }

}

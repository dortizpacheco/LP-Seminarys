using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Reflection;

namespace CShap40
{
    class Factory 
    { 
        public static dynamic New { get { return new New(); } }
    }

}

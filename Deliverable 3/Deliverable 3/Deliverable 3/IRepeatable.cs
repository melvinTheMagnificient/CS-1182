//Deliverable 3
//Melissa Coblentz
//Prof Holmes
//16 February 2017
//Description: Forces class to create deep copies.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_4 {
    interface IRepeatable {
        /// <summary>
        /// Forces object to create a deep copy
        /// </summary>
        /// <returns></returns>
        object CreateCopy();
    }
}

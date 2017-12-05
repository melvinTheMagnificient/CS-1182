//Deliverable 4
//Melissa Coblentz
//Prof Holmes
//2 March 2017
//Description: Creates a deep copy of an object and returns that object type
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_4 {
    interface IRepeatable <T> {
        /// <summary>
        /// Forces object to create a deep copy of type T
        /// </summary>
        /// <returns></returns>
        T CreateCopy();
    }
}

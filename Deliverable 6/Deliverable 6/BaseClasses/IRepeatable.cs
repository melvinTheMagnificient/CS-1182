//Deliverable 6
//Melissa Coblentz
//Prof Holmes
//6 April 2017
//Description: Creates a deep copy of an object and returns that object type
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClasses {
    public interface IRepeatable<T> {
        /// <summary>
        /// Forces object to create a deep copy of type T
        /// </summary>
        /// <returns></returns>
        T CreateCopy();
    }
}

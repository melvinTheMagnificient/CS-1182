//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Creates a deep copy of an object and returns that object type

namespace BaseClasses {

    public interface IRepeatable<T> {

        /// <summary>
        /// Forces object to create a deep copy of type T
        /// </summary>
        /// <returns></returns>
        T CreateCopy();
    }
}
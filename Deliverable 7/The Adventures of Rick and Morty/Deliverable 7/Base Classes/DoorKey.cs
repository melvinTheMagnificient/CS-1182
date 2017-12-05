//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Door key with code matching door
using System;

namespace BaseClasses {

    [Serializable]
    public class DoorKey : Item {

        #region Fields

        /// <summary>
        /// Private string variable
        /// </summary>
        private string _Code;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// DoorKey overloaded constructor
        /// </summary>
        /// <param name="name">string doorkey's name</param>
        /// <param name="value">int doorkey's value</param>
        /// <param name="code">string doorkey's code (should match door's code)</param>
        public DoorKey(string name, int value, string code) : base(name, value) {
            _Code = code;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Code's read only property
        /// </summary>
        public string Code {
            get {
                return _Code;
            }
        }

        #endregion Properties
    }
}
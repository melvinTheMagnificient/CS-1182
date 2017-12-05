//Deliverable 5
//Melissa Coblentz
//Prof Holmes
//16 March 2017
//Description: Door key
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClasses {
    public class DoorKey : Item {
        #region Fields
        /// <summary>
        /// Private string variable
        /// </summary>
        private string _Code;
        #endregion

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
        #endregion

        #region Properties
        /// <summary>
        /// Code's read only property
        /// </summary>
        public string Code {
            get {
                return _Code;
            }
        }
        #endregion
    }
}

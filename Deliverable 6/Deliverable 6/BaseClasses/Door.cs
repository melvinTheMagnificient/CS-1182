//Deliverable 6
//Melissa Coblentz
//Prof Holmes
//6 April 2017
//Description: Door item
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClasses {
    public class Door : Item {
        #region Fields
        /// <summary>
        /// Private string variable code
        /// </summary>
        private string _Code;
        #endregion

        #region Constructors
        /// <summary>
        /// Door's overloaded constructor
        /// </summary>
        /// <param name="name">string door's name</param>
        /// <param name="value">int door's value</param>
        /// <param name="code">string door's code (should match doorkey's code)</param>
        public Door(string name, int value, string code) : base(name, value) {
            _Code = code;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Door's code read and write property
        /// </summary>
        public string Code {
            get {
                return _Code;
            }

            set {
                _Code = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Checks if door's code matches doorkey's code
        /// </summary>
        /// <param name="doorKey"></param>
        /// <returns></returns>
        public bool DoorKeyMatch(DoorKey doorKey) {
            return doorKey.Code == Code;
        }
        #endregion
    }
}

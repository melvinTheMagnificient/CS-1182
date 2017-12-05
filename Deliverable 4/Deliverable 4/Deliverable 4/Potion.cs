//Deliverable 4
//Melissa Coblentz
//Prof Holmes
//2 March 2017
//Description: Item with color
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Deliverable_4 {
    class Potion : Item, IRepeatable<Potion> {
        #region Fields
        /// <summary>
        /// private fields for any potion object
        /// </summary>
        private Color _PotionColor;
        #endregion

        #region Constructor
        /// <summary>
        /// constructs potion object
        /// </summary>
        /// <param name="color"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Potion(Color color, string name, int value) : base(name, value) {
            _PotionColor = color;
        }
        #endregion

        #region Properties
        /// <summary>
        /// read and write potion color
        /// </summary>
        public Color PotionColor {
            get {
                return _PotionColor;
            }
            set {
                _PotionColor = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a deep copy of a potion
        /// </summary>
        /// <returns>Potion</returns>
        public Potion CreateCopy() {
            Potion x = new Potion(this.PotionColor, this.Name, this.Value);
            return x;
        }
        #endregion
    }
}

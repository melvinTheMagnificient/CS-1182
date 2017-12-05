//Deliverable 5
//Melissa Coblentz
//Prof Holmes
//16 March 2017
//Description: Base actor class. Hero and mosnter inherit from this.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClasses {
    public abstract class Actor {
        #region Fields
        /// <summary>
        /// private variables for any actor object
        /// </summary>
        private string _Name;
        private string _Title;
        private int _AttackSpeed;
        private int _StartingXCoordinate;
        private int _StartingYCoordinate;
        private int _MaxHP;
        private int _HP;
        #endregion

        #region Constructor
        /// <summary>
        /// Overloaded constructor for an Actor
        /// </summary>
        /// <param name="HP">actor's current health points (int)</param>
        /// <param name="maxHP">maximum health points actor can have (int)</param>
        /// <param name="name">actor's first name (string)</param>
        /// <param name="title">actor's title (string)</param>
        /// <param name="startingXCoordinate">actor's starting x coordinate (int)</param>
        /// <param name="startingYCoordinate">actor's starting y coordinate (int)</param>
        /// <param name="attackSpeed">speed actor attacks at (int)</param>
        public Actor(int maxHP, string name, string title, int attackSpeed,
            int StartingXCoordinate, int StartingYCoordinate) {
            _Name = name;
            _Title = title;
            _AttackSpeed = attackSpeed;
            _MaxHP = maxHP;
            _HP = maxHP;
            _StartingXCoordinate = StartingXCoordinate;
            _StartingYCoordinate = StartingYCoordinate;
        }
        #endregion

        #region Properties
        /// <summary>
        /// gets actor's name and returns it with only the first letter capitalized
        /// </summary>
        public string Name {
            get {
                return CapitalizeFirstLetter(_Name);
            }
            set {
                _Name = value;
            }
        }

        /// <summary>
        /// reads and writes actor's title
        /// </summary>
        public string Title {
            get {
                return _Title;
            }
            set {
                _Title = value;
            }
        }

        /// <summary>
        /// reads and writes actor's attack speed
        /// </summary>
        virtual public int AttackSpeed {
            get {
                return _AttackSpeed;
            }
        }

        /// <summary>
        /// read only actor's starting x coordinate
        /// </summary>
        public int StartingXCoordinate {
            get {
                return _StartingXCoordinate;
            }
        }

        /// <summary>
        /// read only actor's starting y coordinate
        /// </summary>
        public int StartingYCoordinate {
            get {
                return _StartingYCoordinate;
            }
        }

        /// <summary>
        /// read only actor's max HP possible
        /// </summary>
        public int MaxHP {
            get {
                return _MaxHP;
            }
        }

        /// <summary>
        /// read only actor's curret HP
        /// </summary>
        public int HP {
            get {
                return _HP;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Capitalizes the only first letter of a string and makes the the rest lower case. 
        /// </summary>
        /// <param name="word"></param>
        /// <returns>string</returns>
        virtual public string CapitalizeFirstLetter(string word) {
            if (word.Length > 0) {
                return (char.ToUpper(word[0]) + word.Substring(1, word.Length - 1)).ToString();
            }
            else {
                return "";
            }
        }

        /// <summary>
        /// Unimportant words of a title are lowercase, first letters of important words are uppercase.
        /// </summary>
        /// <returns>string</returns>
        virtual public string TitleFormat() {
            string formattedTitle = "";
            string[] indvWords = Title.Split().ToArray();
            for (int i = 0; i < indvWords.Length; i++) {
                indvWords[i] = indvWords[i].ToLower();
                if (!(indvWords[i] == "the" || indvWords[i] == "a" || indvWords[i] == "an"
                    || indvWords[i] == "of" || indvWords[i] == "as" || indvWords[i] == "in")) {
                    indvWords[i] = CapitalizeFirstLetter(indvWords[i]);
                }
                formattedTitle += indvWords[i] + " ";
            }
            return formattedTitle;
        }

        /// <summary>
        /// Creates full name with capitalized first name and formatted title.
        /// </summary>
        /// <returns>string</returns>
        /// <source>Created with help from Megan Urban</source>
        virtual public string NameWithTitle() {
            return (CapitalizeFirstLetter(Name) + " " + TitleFormat()).Trim();
        }

        /// <summary>
        /// Increases actor's current HP
        /// </summary>
        /// <param name="amount"></param>
        public void IncreaseHP(int amount) {
            _HP += amount;
            if (_HP > _MaxHP) {
                _HP = _MaxHP;
            }
        }

        /// <summary>
        /// Decreases actor's current HP
        /// </summary>
        /// <param name="amount"></param>
        public void DecreaseHP(int amount) {
            _HP -= amount;
            if (_HP < 0) {
                _HP = 0;
            }
        }

        /// <summary>
        /// Directions actor can move
        /// </summary>
        public enum Direction {
            moveUp,
            moveDown,
            moveLeft,
            moveRight
        }

        /// <summary>
        /// Moves actor using Direction enums
        /// </summary>
        /// <param name="direction">(int)Actor.Direction.move(up/down/left/right)</param>
        virtual public void Move(int direction) {
            if (direction == 0) {
                _StartingYCoordinate -= 1;
            }
            else if (direction == 1) {
                _StartingYCoordinate += 1;
            }
            else if (direction == 2) {
                _StartingXCoordinate -= 1;
            }
            else if (direction == 3) {
                _StartingXCoordinate += 1;
            }
        }
        #endregion
    }
}

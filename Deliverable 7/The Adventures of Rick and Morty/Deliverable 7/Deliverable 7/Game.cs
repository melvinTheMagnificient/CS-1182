//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Current game
using BaseClasses;
using System;

namespace Deliverable_7 {

    internal static class Game {

        #region Fields

        /// <summary>
        /// Private fields in Game class
        /// </summary>
        private static State _GameState;

        private static Map _CurrentMap;
        private static int _Height;
        private static int _Width;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Sets GameState to lost if hero's hp is 0
        /// </summary>
        public static State GameState {
            get {
                if (CurrentMap.CurrentHero.HP == 0) {
                    return State.lost;
                }
                return _GameState;
            }
            set {
                _GameState = value;
            }
        }

        /// <summary>
        /// returns game's current map
        /// </summary>
        public static Map CurrentMap {
            get {
                return _CurrentMap;
            }
            set {
                _CurrentMap = value;
            }
        }

        /// <summary>
        /// Height of gameboard
        /// </summary>
        public static int Height {
            get {
                return _Height;
            }
            set {
                _Height = value;
            }
        }

        /// <summary>
        /// Width of gameboard
        /// </summary>
        public static int Width {
            get {
                return _Width;
            }
            set {
                _Width = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates new board and places hero on board
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public static void ResetGame(int height, int width) {
            _Height = height;
            _Width = width;
            GameState = State.running;
            _CurrentMap = new Map(width, height);

            Random rnd = new Random();
            int row = rnd.Next(0, _CurrentMap.GameBoard.GetLength(0));
            int col = rnd.Next(0, _CurrentMap.GameBoard.GetLength(1));
            while (_CurrentMap.GameBoard[row, col].Item != null || _CurrentMap.GameBoard[row, col].Monster != null) {
                row = rnd.Next(0, _CurrentMap.GameBoard.GetLength(0));
                col = rnd.Next(0, _CurrentMap.GameBoard.GetLength(1));
            }
            _CurrentMap.CurrentHero = new Hero(20, "Rick", "", 200, row, col);
            CurrentMap.GameBoard[row, col].HasBeenDiscovered = true;
        }

        /// <summary>
        /// Resets game using properties
        /// </summary>
        public static void ResetGame() {
            ResetGame(Height, Width);
        }

        /// <summary>
        /// Enum of game state (running, lost, won)
        /// </summary>
        public enum State {
            running,
            lost,
            won
        }

        #endregion Methods
    }
}
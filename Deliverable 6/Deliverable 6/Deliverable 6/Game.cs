//Deliverable 6
//Melissa Coblentz
//Prof Holmes
//6 April 2017
//Description: Current game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClasses;

namespace Deliverable_6 {
    static class Game {
        #region Fields
        /// <summary>
        /// Private fields in Game class
        /// </summary>
        private static State _GameState;
        private static Map _CurrentMap;
        #endregion

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
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates new board and places hero on board
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public static void ResetGame(int height, int width) {
            GameState = State.running;
            _CurrentMap = new Map(width, height);

            Random rnd = new Random();
            int row = rnd.Next(0, _CurrentMap.GameBoard.GetLength(0));
            int col = rnd.Next(0, _CurrentMap.GameBoard.GetLength(1));
            while (_CurrentMap.GameBoard[row, col].Item != null || _CurrentMap.GameBoard[row, col].Monster != null) {
                row = rnd.Next(0, _CurrentMap.GameBoard.GetLength(0));
                col = rnd.Next(0, _CurrentMap.GameBoard.GetLength(1));
            }            
            _CurrentMap.CurrentHero = new Hero(100, "Harry Potter", "the Chosen One", 200, row, col);
            CurrentMap.GameBoard[row, col].HasBeenDiscovered = true;
        }

        /// <summary>
        /// Enum of game state (running, lost, won)
        /// </summary>
        public enum State {
            running,
            lost,
            won
        }
        #endregion
    }
}

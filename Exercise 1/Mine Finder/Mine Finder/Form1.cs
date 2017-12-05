//Exercise 1 - Mine Finder
//CS 1182
//Melissa Coblentz
//19 January 2017
//Professor Holmes
//Description: Simplified minesweeper.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mine_Finder {
    public partial class frmMineSweeper : Form {
        public frmMineSweeper() {
            InitializeComponent();
            SetButtonClicks();
        }

        string[,] board = new string[9, 9];

        /// <summary>
        /// Set the click events for all of the buttons in the grid. Made by Professor Holmes.
        /// </summary>
        private void SetButtonClicks() {
            btn_0_0.Click += btnBomb_Click; btn_0_1.Click += btnBomb_Click; btn_0_2.Click += btnBomb_Click;
            btn_0_3.Click += btnBomb_Click; btn_0_4.Click += btnBomb_Click; btn_0_5.Click += btnBomb_Click;
            btn_0_6.Click += btnBomb_Click; btn_0_7.Click += btnBomb_Click; btn_0_8.Click += btnBomb_Click;
            btn_1_0.Click += btnBomb_Click; btn_1_1.Click += btnBomb_Click; btn_1_2.Click += btnBomb_Click;
            btn_1_3.Click += btnBomb_Click; btn_1_4.Click += btnBomb_Click; btn_1_5.Click += btnBomb_Click;
            btn_1_6.Click += btnBomb_Click; btn_1_7.Click += btnBomb_Click; btn_1_8.Click += btnBomb_Click;
            btn_2_0.Click += btnBomb_Click; btn_2_1.Click += btnBomb_Click; btn_2_2.Click += btnBomb_Click;
            btn_2_3.Click += btnBomb_Click; btn_2_4.Click += btnBomb_Click; btn_2_5.Click += btnBomb_Click;
            btn_2_6.Click += btnBomb_Click; btn_2_7.Click += btnBomb_Click; btn_2_8.Click += btnBomb_Click;
            btn_3_0.Click += btnBomb_Click; btn_3_1.Click += btnBomb_Click; btn_3_2.Click += btnBomb_Click;
            btn_3_3.Click += btnBomb_Click; btn_3_4.Click += btnBomb_Click; btn_3_5.Click += btnBomb_Click;
            btn_3_6.Click += btnBomb_Click; btn_3_7.Click += btnBomb_Click; btn_3_8.Click += btnBomb_Click;
            btn_4_0.Click += btnBomb_Click; btn_4_1.Click += btnBomb_Click; btn_4_2.Click += btnBomb_Click;
            btn_4_3.Click += btnBomb_Click; btn_4_4.Click += btnBomb_Click; btn_4_5.Click += btnBomb_Click;
            btn_4_6.Click += btnBomb_Click; btn_4_7.Click += btnBomb_Click; btn_4_8.Click += btnBomb_Click;
            btn_5_0.Click += btnBomb_Click; btn_5_1.Click += btnBomb_Click; btn_5_2.Click += btnBomb_Click;
            btn_5_3.Click += btnBomb_Click; btn_5_4.Click += btnBomb_Click; btn_5_5.Click += btnBomb_Click;
            btn_5_6.Click += btnBomb_Click; btn_5_7.Click += btnBomb_Click; btn_5_8.Click += btnBomb_Click;
            btn_6_0.Click += btnBomb_Click; btn_6_1.Click += btnBomb_Click; btn_6_2.Click += btnBomb_Click;
            btn_6_3.Click += btnBomb_Click; btn_6_4.Click += btnBomb_Click; btn_6_5.Click += btnBomb_Click;
            btn_6_6.Click += btnBomb_Click; btn_6_7.Click += btnBomb_Click; btn_6_8.Click += btnBomb_Click;
            btn_7_0.Click += btnBomb_Click; btn_7_1.Click += btnBomb_Click; btn_7_2.Click += btnBomb_Click;
            btn_7_3.Click += btnBomb_Click; btn_7_4.Click += btnBomb_Click; btn_7_5.Click += btnBomb_Click;
            btn_7_6.Click += btnBomb_Click; btn_7_7.Click += btnBomb_Click; btn_7_8.Click += btnBomb_Click;
            btn_8_0.Click += btnBomb_Click; btn_8_1.Click += btnBomb_Click; btn_8_2.Click += btnBomb_Click;
            btn_8_3.Click += btnBomb_Click; btn_8_4.Click += btnBomb_Click; btn_8_5.Click += btnBomb_Click;
            btn_8_6.Click += btnBomb_Click; btn_8_7.Click += btnBomb_Click; btn_8_8.Click += btnBomb_Click;
        }

        /// <summary>
        /// Resets text and color of buttons when new bomb pattern is selected.
        /// </summary>
        private void ResetButtonText() {
            for (int row = 0; row < board.GetLength(0); row++) {
                for (int col = 0; col < board.GetLength(1); col++) {
                    Button b = (Button)this.Controls["btn_" + row + "_" + col];
                    b.Text = "?";
                    b.BackColor = Color.Empty;
                }
            }
        }

        /// <summary>
        /// Loads bomb pattern onto board using given txt file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFromFile_Click(object sender, EventArgs e) {
            Array.Clear(board, 0, 81);
            ResetButtonText();
            FillArrayFromFile();
        }

        /// <summary>
        /// Loads random bomb pattern onto board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFillBoardRandomly_Click(object sender, EventArgs e) {
            Array.Clear(board, 0, 81);
            ResetButtonText();
            FillArrayRandomly();
        }

        /// <summary>
        /// Fills board array with bomb pattern from given txt file. If no file, MessageBox.
        /// </summary>
        private void FillArrayFromFile() {
            if (File.Exists("board.txt")) {
                string[] lines = File.ReadAllLines("board.txt");
                for (int row = 0; row < lines.Length; row++) {
                    string individuals = lines[row];
                    for (int col = 0; col < individuals.Length; col++) {
                        board[row, col] = individuals[col].ToString();
                    }
                }
            }
            else {
                MessageBox.Show("File not found");
            }
        }

        /// <summary>
        /// Fills board array with random bomb pattern.
        /// </summary>
        private void FillArrayRandomly() {
            Random rnd = new Random();
            for (int bombCount = 0; bombCount < 10; bombCount++) {
                board[rnd.Next(0, 9), rnd.Next(0, 9)] = "x";
            }
            for (int row = 0; row < board.GetLength(0); row++) {
                for (int col = 0; col < board.GetLength(1); col++) {
                    if (board[row, col] == null) {
                        board[row, col] = "o";
                    }
                }
            }
        }

        /// <summary>
        /// Handle the button click for each of the buttons. Started by Professor Holmes.
        /// </summary>
        /// <param name="sender"> Button sending the event. </param>
        /// <param name="e"> Extra variables from the button click event. </param>
        private void btnBomb_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            String nameToParse = btn.Name;
            String[] parts = nameToParse.Split('_');
            int row = int.Parse(parts[1]);
            int col = int.Parse(parts[2]);

            if (board[row, col] == "x") {
                btn.BackColor = Color.Black;
            }
            else {
                btn.Text = CountBombs(row, col).ToString();
            }
        }

        /// <summary>
        /// Returns number of bombs around selected button. Help from Taylor.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private int CountBombs(int row, int col) {
            int count = 0;
            if ((row > 0 && col > 0) && board[row - 1, col - 1] == "x") {
                count++;
            }
            if ((col > 0) && board[row, col - 1] == "x") {
                count++;
            }
            if ((row < 8 && col > 0) && board[row + 1, col - 1] == "x") {
                count++;
            }
            if ((row < 8) && board[row + 1, col] == "x") {
                count++;
            }
            if ((row < 8 && col < 8) && board[row + 1, col + 1] == "x") {
                count++;
            }
            if ((col < 8) && board[row, col + 1] == "x") {
                count++;
            }
            if ((row > 0 && col < 8) && board[row - 1, col + 1] == "x") {
                count++;
            }
            if ((row > 0) && board[row - 1, col] == "x") {
                count++;
            }
            return count;
        }
    }
}

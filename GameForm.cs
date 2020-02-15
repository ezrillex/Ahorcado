using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Data.SQLite;

namespace Ahorcado
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            this.Hide();
            InitializeComponent();
        }

        #region DEFINITIONS
        Graphics g;
        
        Pen BlackPen;
        Pen RedPen;
        Pen GreenPen;
        
        List<Button> GameButtons;
        List<Label> GameLabels;
        
        Label[] HistoryLabels;
        #endregion

        /// <summary>
        /// GameForm Loading Method. Handles most of the initialization of the program.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Update score with value loaded
            label_puntaje.Text = "Puntaje: " + Data.Puntaje;

            // Create graphics object and pen
            g = this.CreateGraphics();
            BlackPen = new Pen(Color.Black, 3);
            RedPen = new Pen(Color.Red, 3);
            GreenPen = new Pen(Color.Green, 3);

            // Enable antialiasing to reduce aliasing in lines
            if(Data.AntialiasEnabled == true)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
            }
            else
            {
                g.SmoothingMode = SmoothingMode.None;
            }

            // Center Play Button
            PlayButton.Location = new Point((this.Size.Width - PlayButton.Width) / 2, (this.Size.Height - PlayButton.Height) / 2);

            // Create a list of controls associated with the main game and not the menus
            GameButtons = new List<Button>();
            GameButtons.Add(button_A);
            GameButtons.Add(button_B);
            GameButtons.Add(button_C);
            GameButtons.Add(button_D);
            GameButtons.Add(button_E);
            GameButtons.Add(button_F);
            GameButtons.Add(button_G);
            GameButtons.Add(button_H);
            GameButtons.Add(button_I);
            GameButtons.Add(button_J);
            GameButtons.Add(button_K);
            GameButtons.Add(button_L);
            GameButtons.Add(button_M);
            GameButtons.Add(button_N);
            GameButtons.Add(button_Ñ);
            GameButtons.Add(button_O);
            GameButtons.Add(button_P);
            GameButtons.Add(button_Q);
            GameButtons.Add(button_R);
            GameButtons.Add(button_S);
            GameButtons.Add(button_T);
            GameButtons.Add(button_U);
            GameButtons.Add(button_V);
            GameButtons.Add(button_W);
            GameButtons.Add(button_X);
            GameButtons.Add(button_Y);
            GameButtons.Add(button_Z);

            // Hide Game controls
            foreach(Button b in GameButtons)
            {
                b.Visible = false;
                b.Enabled = false;
            }

            // Create a list of labels associated with the game
            GameLabels = new List<Label>();
            GameLabels.Add(label_puntaje);
            GameLabels.Add(label_text_historial);

            // Hide game labels
            foreach(Label l in GameLabels)
            {
                l.Visible = false;
                l.Enabled = false;
            }

            // Initialize history labels
            HistoryLabels = new Label[Data.History.size];
            for(int i = 0; i < Data.History.size; i++)
            {
                HistoryLabels[i] = new Label();
            }

            // Format and Move history label to locations
            int HistoryPosition = 1;
            foreach(Label l in HistoryLabels)
            {
                l.AutoSize = true; // fix cutting of other labels
                l.Location = new Point(12,26 + (HistoryPosition * 16));
                HistoryPosition++;
            }
            // Add labels to GameForm
            for (int i = 0; i < HistoryLabels.Count(); i++)
            {
                this.Controls.Add(HistoryLabels[i]);
            }

            Data.LoadingFinished = true;
        }

        /// <summary>
        /// Updates the screen with the updated values of the word and history.
        /// </summary>
        /// <param name="RectPen">The pen used to draw the rectangle around the word. Used to color.</param>
        private void UpdateScreen(Pen RectPen)
        {
            g.Clear(Color.White); // Clear Screen

            // Changes antialiasing according to form static property.
            if (Data.AntialiasEnabled == true)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
            }
            else if(Data.AntialiasEnabled == false)
            {
                g.SmoothingMode = SmoothingMode.None;
            }

            Font myFont = new Font("Courier New", 48);
            myFont = new Font(myFont, FontStyle.Bold); // Defines font, Courier New; 48pt; style=Bold

            int WordSize = Data.GameWord.Length;

            // calculate size of the word when using standalone letters
            Size LetterSize = new Size();
            LetterSize = g.MeasureString("A", myFont).ToSize();
            int WordWidth = LetterSize.Width * WordSize;

            // Define origin point @ the center.
            PointF source = new PointF(((this.Size.Width - WordWidth) / 2) - 7, ((this.Size.Height - LetterSize.Height) / 2) + 54);

            // Word Outline
            RectangleF WordRect = new RectangleF(source.X, source.Y, WordWidth, LetterSize.Height);

            // Draw the word
            for (int i = 0; i < WordSize; i++)
            {
                PointF CharSource = new PointF(source.X + (LetterSize.Width * i), source.Y);

                // Draws the individual chars
                if(Data.WordGuess.Length > 0)
                {
                    g.DrawString(Data.WordGuess[i].ToString(), myFont, Brushes.Black, CharSource);
                }

                // Draws Underlining
                g.DrawLine(BlackPen, CharSource.X + 10, CharSource.Y + LetterSize.Height - 20, CharSource.X + LetterSize.Width - 10, CharSource.Y + LetterSize.Height - 20);
            }

            // Draws a rectangle around the text drawn
            g.DrawRectangle(RectPen, WordRect.X, WordRect.Y, WordRect.Width, WordRect.Height);

            // TODO +1 -1 Animations here or do Correct! Wrong! moving in matchcolor

            // Draw current stage of hangman based on attempt value.
            DrawStickFigure(Data.attempts);
        }

        /// <summary>
        /// Initializes a new word. It's used at the start and when each win or loose condition is met.
        /// </summary>
        /// <param name="isCorrect">Determines if the last word was guessed succesfully or failed. By default assumes it was successfull</param>
        private void InitializeWord(bool isCorrect = true)
        {
            Data.GenerateNewWord(isCorrect);

            // Update history labels colors and text
            Font myFont = label_text_historial.Font;
            for(int i = 0; i < Data.History.size; i++)
            {
                HistoryLabels[i].Text = Data.History.items[i];
                if (Data.History.status[i] == true)
                {
                    HistoryLabels[i].ForeColor = Color.Green;
                }
                else
                {
                    HistoryLabels[i].ForeColor = Color.Red;
                }
            }

            UpdateScreen(BlackPen);
        }

        /// <summary>
        /// Updates the global variables that keep track of the letters guessed and the scoring.
        /// </summary>
        /// <param name="c">Input to process</param>
        private void UpdateWord(char c)
        {
            Data.UpdateWord(c);

            label_puntaje.Text = "Puntaje: " + Data.Puntaje;

            // Change the word and reset attempt tracking
            if (Data.WordGuess == Data.GameWord)
            {
                // Win condition. 
                Sonido.Win();
                Data.attempts = 7;
                InitializeWord();
                foreach(Button b in GameButtons)
                {
                    b.BackColor = Color.White;
                }
            }
            else if(Data.attempts == 0)
            {
                // Lose condition.
                Sonido.Lose();
                Data.attempts = 7;
                InitializeWord(false);
                foreach (Button b in GameButtons)
                {
                    b.BackColor = Color.White;
                }
            }
            else
            {
                if (Data.AnyMatchFound == false & Data.isReapeatedInWrongGuess == false)
                {
                    Sonido.Wrong();
                    this.Controls.Find("button_" + c, false)[0].BackColor = Color.Red;
                }
                else if(Data.AnyMatchFound == true & Data.RepeatedMatch == false)
                {
                    Sonido.Correct();
                    this.Controls.Find("button_" + c, false)[0].BackColor = Color.Green;
                }

                if(Data.PenColorValue is true)
                {
                    UpdateScreen(GreenPen);
                }
                else
                {
                    UpdateScreen(RedPen);
                }
            }
        }

        /// <summary>
        /// Play button press which hides the button and shows labels and keyboard buttons. Initializes the first word. Sets the game started flag to true.
        /// </summary>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            Sonido.Click();

            // Hide Play button
            PlayButton.Visible = false;
            PlayButton.Enabled = false;

            // Show keyboard
            foreach (Button b in GameButtons)
            {
                b.Visible = true;
                b.Enabled = true;
            }

            // Show Game labels
            foreach(Label l in GameLabels)
            {
                l.Visible = true;
                l.Enabled = true;
            }

            InitializeWord();
            Data.GameStarted = true;
        }

        /// <summary>
        /// Settings button press opens as dialogue the settings and about form and sets game form as owner.
        /// </summary>
        private void button_settings_Click(object sender, EventArgs e)
        {
            SettingsAndAbout SettingsWindow = new SettingsAndAbout();
            SettingsWindow.Owner = this;
            SettingsWindow.ShowDialog();
        }

        /// <summary>
        /// Disposes pens and graphics resources.
        /// </summary>
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Is there more resources to dispose? 
            BlackPen.Dispose();
            RedPen.Dispose();
            GreenPen.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// Draws a stick figure.
        /// </summary>
        /// <param name="stage">Determines the stage of the stick figure.</param>
        private void DrawStickFigure(int stage)
        {
            Point headPos = new Point(this.Width / 2, 120);
            Size headSize = new Size(50, 50);
            Rectangle head = new Rectangle(headPos, headSize);
            Pen RopePen = new Pen(Color.Black, 5);
            Pen StickFigurePen = BlackPen;

            switch (stage)
            {
                case 0:
                    // this doesn't even show so leave blank :D
                    break;
                case 1:
                    StickFigurePen = RedPen;
                    DrawRope();
                    DrawLeftArm();
                    DrawRightLeg();
                    DrawLeftLeg();
                    DrawBody();
                    DrawHead();
                    DrawRightArm();
                    break;
                case 2:
                    DrawRope();
                    DrawRightLeg();
                    DrawLeftLeg();
                    DrawBody();
                    DrawHead();
                    DrawLeftArm();
                    break;
                case 3:
                    DrawRope();
                    DrawLeftLeg();
                    DrawBody();
                    DrawHead();
                    DrawRightLeg();
                    break;
                case 4:
                    DrawBody();
                    DrawRope();
                    DrawHead();
                    DrawLeftLeg();
                    break;
                case 5:
                    DrawHead();
                    DrawRope();
                    DrawBody();
                    break;
                case 6:
                    DrawRope();
                    DrawHead();
                    break;
                case 7:
                    DrawRope();
                    break;
                default:
                    break;
            }

            void DrawRope()
            {
                // draw rope
                g.DrawLine
                    (RopePen,
                    headPos.X + (headSize.Width / 2),
                    headPos.Y,
                    headPos.X + (headSize.Width / 2),
                    headPos.Y - 15);
                // draw horizontal stick
                g.DrawLine
                    (RopePen,
                    headPos.X + (headSize.Width / 2) +2,
                    headPos.Y - 15,
                    headPos.X - 102,
                    headPos.Y - 15);
                // draw vertical stick
                g.DrawLine
                    (RopePen,
                    headPos.X - 100,
                    headPos.Y - 15,
                    headPos.X - 100,
                    headPos.Y + 190);
            }

            void DrawHead()
            {
                // head
                g.DrawEllipse(StickFigurePen, head);
            }

            void DrawBody()
            {
                // body
                g.DrawLine
                    (StickFigurePen,
                    headPos.X + (headSize.Width / 2),
                    headPos.Y + headSize.Height,
                    headPos.X + (headSize.Width / 2),
                    headPos.Y + headSize.Height + 70);
            }

            void DrawLeftArm()
            {
                // left arm
                g.DrawLine
                    (StickFigurePen,
                    headPos.X + (headSize.Width / 2),
                    headPos.Y + headSize.Height + 25,
                    headPos.X + (headSize.Width / 8),
                    headPos.Y + headSize.Height + 60);
            }

            void DrawRightArm()
            {
                // right arm
                g.DrawLine
                    (StickFigurePen,
                    headPos.X + (headSize.Width / 2),
                    headPos.Y + headSize.Height + 25,
                    headPos.X + (headSize.Width / 8 * 7),
                    headPos.Y + headSize.Height + 60);
            }

            void DrawLeftLeg()
            {
                // left leg
                g.DrawLine
                    (StickFigurePen,
                    headPos.X + (headSize.Width / 2),
                    headPos.Y + headSize.Height + 70,
                    headPos.X + (headSize.Width / 6),
                    headPos.Y + headSize.Height + 130);
            }

            void DrawRightLeg()
            {
                // right leg
                g.DrawLine
                    (StickFigurePen,
                    headPos.X + (headSize.Width / 2),
                    headPos.Y + headSize.Height + 70,
                    headPos.X + (headSize.Width / 6 * 5),
                    headPos.Y + headSize.Height + 130);
            }

            RopePen.Dispose();
        }

        /// <summary>
        /// Captures keypresses to not always use on screen keyboard.
        /// </summary>
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(Data.GameStarted == true)
            {
                Keys key = e.KeyCode;
                switch (key)
                {
                    case Keys.A:
                        UpdateWord('A');
                        break;
                    case Keys.B:
                        UpdateWord('B');
                        break;
                    case Keys.C:
                        UpdateWord('C');
                        break;
                    case Keys.D:
                        UpdateWord('D');
                        break;
                    case Keys.E:
                        UpdateWord('E');
                        break;
                    case Keys.F:
                        UpdateWord('F');
                        break;
                    case Keys.G:
                        UpdateWord('G');
                        break;
                    case Keys.H:
                        UpdateWord('H');
                        break;
                    case Keys.I:
                        UpdateWord('I');
                        break;
                    case Keys.J:
                        UpdateWord('J');
                        break;
                    case Keys.K:
                        UpdateWord('K');
                        break;
                    case Keys.L:
                        UpdateWord('L');
                        break;
                    case Keys.M:
                        UpdateWord('M');
                        break;
                    case Keys.N:
                        UpdateWord('N');
                        break;
                    case Keys.Oemtilde:
                        UpdateWord('Ñ');
                        break;
                    case Keys.O:
                        UpdateWord('O');
                        break;
                    case Keys.P:
                        UpdateWord('P');
                        break;
                    case Keys.Q:
                        UpdateWord('Q');
                        break;
                    case Keys.R:
                        UpdateWord('R');
                        break;
                    case Keys.S:
                        UpdateWord('S');
                        break;
                    case Keys.T:
                        UpdateWord('T');
                        break;
                    case Keys.U:
                        UpdateWord('U');
                        break;
                    case Keys.V:
                        UpdateWord('V');
                        break;
                    case Keys.W:
                        UpdateWord('W');
                        break;
                    case Keys.X:
                        UpdateWord('X');
                        break;
                    case Keys.Y:
                        UpdateWord('Y');
                        break;
                    case Keys.Z:
                        UpdateWord('Z');
                        break;
                    default:
                        break;
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Handles the button click events which were setup NOT programatically for speed of development.

        private void button_A_Click(object sender, EventArgs e)
        {
            UpdateWord('A');
        }

        private void button_B_Click(object sender, EventArgs e)
        {
            UpdateWord('B');
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            UpdateWord('C');
        }

        private void button_D_Click(object sender, EventArgs e)
        {
            UpdateWord('D');
        }

        private void button_E_Click(object sender, EventArgs e)
        {
            UpdateWord('E');
        }

        private void button_F_Click(object sender, EventArgs e)
        {
            UpdateWord('F');
        }

        private void button_G_Click(object sender, EventArgs e)
        {
            UpdateWord('G');
        }

        private void button_H_Click(object sender, EventArgs e)
        {
            UpdateWord('H');
        }

        private void button_I_Click(object sender, EventArgs e)
        {
            UpdateWord('I');
        }

        private void button_J_Click(object sender, EventArgs e)
        {
            UpdateWord('J');
        }

        private void button_K_Click(object sender, EventArgs e)
        {
            UpdateWord('K');
        }

        private void button_L_Click(object sender, EventArgs e)
        {
            UpdateWord('L');
        }

        private void button_M_Click(object sender, EventArgs e)
        {
            UpdateWord('M');
        }

        private void button_N_Click(object sender, EventArgs e)
        {
            UpdateWord('N');
        }

        private void button_Ñ_Click(object sender, EventArgs e)
        {
            UpdateWord('Ñ');
        }

        private void button_O_Click(object sender, EventArgs e)
        {
            UpdateWord('O');
        }

        private void button_P_Click(object sender, EventArgs e)
        {
            UpdateWord('P');
        }

        private void button_Q_Click(object sender, EventArgs e)
        {
            UpdateWord('Q');
        }

        private void button_R_Click(object sender, EventArgs e)
        {
            UpdateWord('R');
        }

        private void button_S_Click(object sender, EventArgs e)
        {
            UpdateWord('S');
        }

        private void button_T_Click(object sender, EventArgs e)
        {
            UpdateWord('T');
        }

        private void button_U_Click(object sender, EventArgs e)
        {
            UpdateWord('U');
        }

        private void button_V_Click(object sender, EventArgs e)
        {
            UpdateWord('V');
        }

        private void button_W_Click(object sender, EventArgs e)
        {
            UpdateWord('W');
        }

        private void button_X_Click(object sender, EventArgs e)
        {
            UpdateWord('X');
        }

        private void button_Y_Click(object sender, EventArgs e)
        {
            UpdateWord('Y');
        }

        private void button_Z_Click(object sender, EventArgs e)
        {
            UpdateWord('Z');
        }

    }
}
  
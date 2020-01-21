using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    struct CustomStringStack
    {
        public readonly string[] items;
        public readonly bool[] status;
        public readonly int size;

        public CustomStringStack(int Size)
        {
            if (Size <= 0) Size = 1;
            size = Size;
            items = new string[Size];
            status = new bool[Size];

            for(int i = 0; i < Size; i++)
            {
                items[i] = "";
                status[i] = true;
            }
        }

        public void push(string s, bool b = true)
        {
            // Pull everything "down"
            for(int i = size-1; i > 0; i--)
            {
                items[i] = items[i - 1];
                status[i] = status[i - 1];
            }

            // Put the string on position 0
            items[0] = s;
            status[0] = b;
        }
    }

    public partial class GameForm : Form
    {

        string GameWord = "";
        string WordGuess = "";

        int Puntaje = 0;
        int attempts = 6;

        bool GameStarted = false;

        Graphics g;
        
        Pen BlackPen;
        Pen RedPen;
        Pen GreenPen;
        
        List<Button> GameButtons;
        List<Label> GameLabels;
        List<string> WordDatabase = new List<string>() { "CARRO", "PALOMA", "PROBLEMA", "BUGEADO", "CODIGO" };
        
        Label[] HistoryLabels;

        CustomStringStack History = new CustomStringStack(5);

        public GameForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create graphics object, pen and brush
            g = this.CreateGraphics();
            BlackPen = new Pen(Color.Black, 3);
            RedPen = new Pen(Color.Red, 3);
            GreenPen = new Pen(Color.Green, 3);

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
            HistoryLabels = new Label[History.size];
            for(int i = 0; i < History.size; i++)
            {
                HistoryLabels[i] = new Label();
                
            }

            // Format and Move history label to locations
            int HistoryPosition = 1;
            foreach(Label l in HistoryLabels)
            {
                l.AutoSize = true; // fix cutting of of other labels
                l.Location = new Point(14,25 + (HistoryPosition * 16));
                HistoryPosition++;
            }
            for (int i = 0; i < HistoryLabels.Count(); i++)
            {
                this.Controls.Add(HistoryLabels[i]);

            }
        }

        private void UpdateScreen(Pen RectPen)
        {
            g.Clear(Color.White);
            // Defines font, Courier New; 48pt; style=Bold
            Font myFont = new Font("Courier New", 48);
            myFont = new Font(myFont, FontStyle.Bold);

            int WordSize = GameWord.Length;

            // 60 units wide when standalone using myfont
            // calculate width of the word when using standalone letters
            // Calculates size of text to be drawn
            Size LetterSize = new Size();
            LetterSize = g.MeasureString("A", myFont).ToSize();
            int WordWidth = LetterSize.Width * WordSize;

            // Define origin point
            PointF source = new PointF((this.Size.Width - WordWidth) / 2, (this.Size.Height - LetterSize.Height) / 2);

            // Word Hitbox
            RectangleF WordRect = new RectangleF(source.X, source.Y, WordWidth, LetterSize.Height);

            for (int i = 0; i < WordSize; i++)
            {
                PointF CharSource = new PointF(source.X + (LetterSize.Width * i), source.Y);

                // Draws the individual chars
                if(WordGuess.Length > 0)
                {
                    g.DrawString(WordGuess[i].ToString(), myFont, Brushes.Black, CharSource);
                }

                // Draws Underlining
                g.DrawLine(BlackPen, CharSource.X + 10, CharSource.Y + LetterSize.Height - 20, CharSource.X + LetterSize.Width - 10, CharSource.Y + LetterSize.Height - 20);
            }

            // Draws a rectangle around the text drawn
            g.DrawRectangle(RectPen, WordRect.X, WordRect.Y, WordRect.Width, WordRect.Height);

            // +1 -1 Animations here or do Correct! Wrong! moving in matchcolor

        }

        private void InitializeWord(bool isCorrect = true)
        {
            History.push(GameWord, isCorrect); // Added current game word without a status parameter as calling of this method usually is only when we get a succes

            // Randomly picking a new word
            Random rng = new Random();
            int index = rng.Next(WordDatabase.Count);
            GameWord = WordDatabase[index];
            WordGuess = "";

            for (int i = 0; i < GameWord.Length; i++)
            {
                WordGuess = WordGuess + " ";
            }
            
            UpdateScreen(BlackPen);

            Font myFont = label_text_historial.Font;
            
            for(int i = 0; i < History.size; i++)
            {
                HistoryLabels[i].Text = History.items[i];
                if (History.status[i] == true)
                {
                    HistoryLabels[i].ForeColor = Color.Green;
                }
                else
                {
                    HistoryLabels[i].ForeColor = Color.Red;
                }
            }
        }

        private void UpdateWord(char c)
        {
            Pen MatchPen = RedPen;
            bool AnyMatchFound = false;
            bool MatchFound = false;
            string LocalGuess = "";
            for(int i = 0; i < GameWord.Length; i++)
            {
                if(GameWord[i] == c)
                {
                    LocalGuess = LocalGuess + c;
                    MatchFound = true;
                }
                else
                {
                    LocalGuess = LocalGuess + WordGuess[i];
                }

                if(MatchFound == true)
                {
                    AnyMatchFound = true;
                    bool sameGuess = false;
                    for(int j= 0; j < WordGuess.Length; j++)
                    {
                        if (c == WordGuess[j]) 
                        {
                            sameGuess = true;
                        }
                    }
                    if(sameGuess == false)
                    {
                        Puntaje++;
                    }
                    MatchPen = GreenPen;
                    MatchFound = false;
                }
            }
            if(AnyMatchFound == false)
            {
                attempts--;
            }
            WordGuess = LocalGuess;
            if (WordGuess == GameWord)
            {
                InitializeWord();
                attempts = 6;
            }
            else if(attempts == 0)
            {
                InitializeWord(false);
                attempts = 6;
            }
            
            UpdateScreen(MatchPen);
            UpdateScore();

        }

        private void UpdateScore()
        {
            label_puntaje.Text = "Puntaje: " + Puntaje;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
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

            GameStarted = true;
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            SettingsAndAbout SettingsWindow = new SettingsAndAbout();
            SettingsWindow.Owner = this;
            SettingsWindow.ShowDialog();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BlackPen.Dispose();
            RedPen.Dispose();
            GreenPen.Dispose();
            g.Dispose();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(GameStarted == true)
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

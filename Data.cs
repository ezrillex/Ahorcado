using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Ahorcado
{
    public static class Data
    {
        #region DEFINITIONS
        public static string version = "1.1.1";
        public static string GameWord = "";
        public static string WordGuess = "";
        public static string WrongGuessLetters = "";
        public static string WORD = "";
        static string ScorePath = "";
        static string DarkPath = "";

        public static int Puntaje = 0;
        public static int attempts = 7;
        public static int ID;
        public static int RIGHT;
        public static int WRONG;
        public static int APPEARED;

        public static bool RecentlyChangedTheme = true;
        public static bool DarkMode = false;
        public static bool InitializationFinished = false;
        public static bool LoadingFinished = false;
        public static bool GameStarted = false;
        public static bool REPORTED = false;
        public static bool AntialiasEnabled = true;
        public static bool RepeatedMatch = false;
        public static bool AnyMatchFound = false;
        public static bool MatchFound = false;
        public static bool isReapeatedInWrongGuess = false;
        public static bool PenColorValue = false;

        public static SQLiteConnection DB_Connection;
        public static SQLiteCommand DB_Command;

        public static CustomStringStack History = new CustomStringStack(5);

        public static Color GlobalBackColor = Color.White;
        public static Color GlobalForeColor = Color.Black;
        public static Pen GlobalPenColor = Pens.Black;
        public static Brush GlobalBrushColor = Brushes.Black;
        #endregion

        public static void Init()
        {
            InitScore();
            InitDatabaseConnection();
            InitDarkMode();
        }

        public static void Dispose()
        {
            // Save score
            File.WriteAllText(ScorePath, Puntaje.ToString());

            // Save Dark Mode state
            File.WriteAllText(DarkPath, DarkMode.ToString());

            // Close database connection
            DB_Connection.Close();

            GlobalBrushColor.Dispose();
            GlobalPenColor.Dispose();
        }

        private static void InitScore()
        {
            // Create or load a text file to permanently save score.
            ScorePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); // Get exe path
            ScorePath += "\\score.txt";

            if (File.Exists(ScorePath))
            {
                // Load value stored in file.
                using (StreamReader sr = File.OpenText(ScorePath))
                {
                    string s = sr.ReadToEnd();
                    Puntaje = Convert.ToInt32(s);
                }
            }
            else
            {
                // Create the file
                using (StreamWriter fs = File.CreateText(ScorePath))
                {
                    fs.Write("0");
                }
            }
        }

        private static void InitDarkMode()
        {
            // Create or load a text file to permanently save score.
            DarkPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); // Get exe path
            DarkPath += "\\DarkMode.txt";

            if (File.Exists(DarkPath))
            {
                // Load value stored in file.
                using (StreamReader sr = File.OpenText(DarkPath))
                {
                    string s = sr.ReadToEnd();
                    DarkMode = Convert.ToBoolean(s);
                }
            }
            else
            {
                // Create the file
                using (StreamWriter fs = File.CreateText(DarkPath))
                {
                    fs.Write("False");
                }
            }

            UpdateDarkMode();
        }

        public static void UpdateDarkMode() 
        {
            if (DarkMode is true)
            {
                GlobalBackColor = Color.Black;
                GlobalForeColor = Color.White;
                GlobalPenColor = new Pen(Pens.White.Color, 3);
                GlobalBrushColor = Brushes.White;
            }
            else
            {
                GlobalBackColor = Color.White;
                GlobalForeColor = Color.Black;
                GlobalPenColor = new Pen(Pens.Black.Color, 3);
                GlobalBrushColor = Brushes.Black;
            }
        }

        private static void InitDatabaseConnection()
        {
            // Connect to word database
            string ProgramPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ProgramPath += @"\WordDB.db";
            DB_Connection = new SQLiteConnection("Data Source=" + ProgramPath + ";Version=3;");
            try
            {
                DB_Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al conectar a la base de datos: " + ex.Message, "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DB_Command = DB_Connection.CreateCommand();
        }

        public static void GenerateNewWord(bool isCorrect = true)
        {
            History.push(GameWord, isCorrect); // Added current game word to history. It's important the first one is initialized as ""
            
            // Update database with the new values BEFORE changing to a new word
            if (GameStarted == true) // to avoid trying to make changes with uninitiated variables
            {
                if (isCorrect == true)
                {
                    RIGHT++;
                }
                else
                {
                    WRONG++;
                }
                DB_Command.CommandText = "update Words set right=?, wrong=?, appeared=? where ID=?";
                DB_Command.Parameters.Clear();
                DB_Command.Parameters.AddWithValue("right", Data.RIGHT);
                DB_Command.Parameters.AddWithValue("wrong", Data.WRONG);
                DB_Command.Parameters.AddWithValue("appeared", Data.APPEARED);
                DB_Command.Parameters.AddWithValue("ID", Data.ID);
                DB_Command.ExecuteNonQuery();
                DB_Command.Parameters.Clear();
            }

            // Get a NEW random word from the Word Database
            SQLiteDataReader DB_Reader;
            DB_Command.CommandText = "select * from words order by random() limit 1;";
            do
            {
                DB_Reader = DB_Command.ExecuteReader();
                DB_Reader.Read();
                REPORTED = DB_Reader.GetBoolean(2);
            } while (REPORTED == true);

            ID = DB_Reader.GetInt32(0);
            WORD = DB_Reader.GetString(1);
            RIGHT = DB_Reader.GetInt32(3);
            WRONG = DB_Reader.GetInt32(4);
            APPEARED = DB_Reader.GetInt32(5);

            DB_Reader.Close();

            // Set the GameWord as the word selected by the database
            GameWord = WORD.ToUpper();
            APPEARED++;

            WrongGuessLetters = "";// reset wrong guessed letters
            WordGuess = ""; // Initialize WordGuess with the appropiate size
            for (int i = 0; i < GameWord.Length; i++)
            {
                WordGuess = WordGuess + " ";
            }
        }

        public static void UpdateWord(char c)
        {
            PenColorValue = false;
            AnyMatchFound = false;
            MatchFound = false;
            isReapeatedInWrongGuess = false;
            RepeatedMatch = false;
            string LocalGuess = "";
            // Find the character that was passed.
            for (int i = 0; i < GameWord.Length; i++)
            {
                if (GameWord[i] == c)
                {
                    LocalGuess = LocalGuess + c;
                    MatchFound = true;
                }
                else
                {
                    LocalGuess = LocalGuess + WordGuess[i];
                }

                // Account the score. Update pen to green since a match was found
                if (MatchFound == true)
                {
                    AnyMatchFound = true;
                    bool sameGuess = false;
                    for (int j = 0; j < WordGuess.Length; j++)
                    {
                        if (c == WordGuess[j])
                        {
                            sameGuess = true;
                        }
                    }
                    if (sameGuess == true)
                    {
                        RepeatedMatch = true;
                    }
                    else
                    {
                        Puntaje++;
                    }
                    PenColorValue = true;
                    MatchFound = false;
                }
            }

            WordGuess = LocalGuess;

            if (AnyMatchFound == false)
            {
                for (int i = 0; i < WrongGuessLetters.Length; i++)
                {
                    if (WrongGuessLetters[i] == c)
                    {
                        isReapeatedInWrongGuess = true;
                    }
                }
                if (isReapeatedInWrongGuess == false)
                {
                    WrongGuessLetters += c;
                    attempts--;
                }
            }
        }
    }
}

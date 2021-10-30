using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Chess
{
    public partial class Form1 : Form
    {
        public int x, y; //current position index
        public int prevX, prevY; //previous position index
        int i, j; //counters
        public Color turn; //turn counter
        bool flagSelected = false, flagMoved = false, winFlag = false; //event flags

        //Form1()
        //Main executable function used in Program.cs
        public Form1()
        {
            InitializeComponent();
            this.SettupBoard();
            this.SettupPieces();
            this.LoadUI();
        }

        //SetupBoard()
        //Initializes all board buttons with adequate names
        public void SettupBoard()
        {
            Pieces.board[0, 0] = A8; Pieces.board[0, 1] = B8; Pieces.board[0, 2] = C8; Pieces.board[0, 3] = D8; Pieces.board[0, 4] = E8; Pieces.board[0, 5] = F8; Pieces.board[0, 6] = G8; Pieces.board[0, 7] = H8;
            Pieces.board[1, 0] = A7; Pieces.board[1, 1] = B7; Pieces.board[1, 2] = C7; Pieces.board[1, 3] = D7; Pieces.board[1, 4] = E7; Pieces.board[1, 5] = F7; Pieces.board[1, 6] = G7; Pieces.board[1, 7] = H7;
            Pieces.board[2, 0] = A6; Pieces.board[2, 1] = B6; Pieces.board[2, 2] = C6; Pieces.board[2, 3] = D6; Pieces.board[2, 4] = E6; Pieces.board[2, 5] = F6; Pieces.board[2, 6] = G6; Pieces.board[2, 7] = H6;
            Pieces.board[3, 0] = A5; Pieces.board[3, 1] = B5; Pieces.board[3, 2] = C5; Pieces.board[3, 3] = D5; Pieces.board[3, 4] = E5; Pieces.board[3, 5] = F5; Pieces.board[3, 6] = G5; Pieces.board[3, 7] = H5;
            Pieces.board[4, 0] = A4; Pieces.board[4, 1] = B4; Pieces.board[4, 2] = C4; Pieces.board[4, 3] = D4; Pieces.board[4, 4] = E4; Pieces.board[4, 5] = F4; Pieces.board[4, 6] = G4; Pieces.board[4, 7] = H4;
            Pieces.board[5, 0] = A3; Pieces.board[5, 1] = B3; Pieces.board[5, 2] = C3; Pieces.board[5, 3] = D3; Pieces.board[5, 4] = E3; Pieces.board[5, 5] = F3; Pieces.board[5, 6] = G3; Pieces.board[5, 7] = H3;
            Pieces.board[6, 0] = A2; Pieces.board[6, 1] = B2; Pieces.board[6, 2] = C2; Pieces.board[6, 3] = D2; Pieces.board[6, 4] = E2; Pieces.board[6, 5] = F2; Pieces.board[6, 6] = G2; Pieces.board[6, 7] = H2;
            Pieces.board[7, 0] = A1; Pieces.board[7, 1] = B1; Pieces.board[7, 2] = C1; Pieces.board[7, 3] = D1; Pieces.board[7, 4] = E1; Pieces.board[7, 5] = F1; Pieces.board[7, 6] = G1; Pieces.board[7, 7] = H1;
        }

        //SettupPieces()
        //Initializes and sets up all necessary values for all pieces 
        //and board button images for the start of a new game
        public void SettupPieces()
        {
            turn = Color.White;

            //EMPTY FIELDS
            int i, j;
            for (i = 0; i < 8; i++)
                for (j = 2; j < 6; j++)
                {
                    Pieces.piece[j, i] = new Piece(Color.NULL, Type.NULL);
                    Pieces.board[j, i].Image = null;
                } //empty fields -> assigned NULL for color and type

            //PAWNS
            for (i = 0; i < 8; i++)
            {
                Pieces.piece[1, i] = new Pawn(Color.Black, Type.Pawn);
                Pieces.board[1, i].Image = Chess.Properties.Resources.Black_Pawn;
            }
            for (i = 0; i < 8; i++)
            {
                Pieces.piece[6, i] = new Pawn(Color.White, Type.Pawn);
                Pieces.board[6, i].Image = Chess.Properties.Resources.White_Pawn;
            }

            //ROOK
            Pieces.piece[0, 0] = new Rook(Color.Black, Type.Rook);
            Pieces.board[0, 0].Image = Chess.Properties.Resources.Black_Rook;
            Pieces.piece[0, 7] = new Rook(Color.Black, Type.Rook);
            Pieces.board[0, 7].Image = Chess.Properties.Resources.Black_Rook;
            Pieces.piece[7, 0] = new Rook(Color.White, Type.Rook);
            Pieces.board[7, 0].Image = Chess.Properties.Resources.White_Rook;
            Pieces.piece[7, 7] = new Rook(Color.White, Type.Rook);
            Pieces.board[7, 7].Image = Chess.Properties.Resources.White_Rook;

            //KNIGHT
            Pieces.piece[0, 1] = new Knight(Color.Black, Type.Knight);
            Pieces.board[0, 1].Image = Chess.Properties.Resources.Black_Knight;
            Pieces.piece[0, 6] = new Knight(Color.Black, Type.Knight);
            Pieces.board[0, 6].Image = Chess.Properties.Resources.Black_Knight;
            Pieces.piece[7, 1] = new Knight(Color.White, Type.Knight);
            Pieces.board[7, 1].Image = Chess.Properties.Resources.White_Knight;
            Pieces.piece[7, 6] = new Knight(Color.White, Type.Knight);
            Pieces.board[7, 6].Image = Chess.Properties.Resources.White_Knight;

            //BISHOP
            Pieces.piece[0, 2] = new Bishop(Color.Black, Type.Bishop);
            Pieces.board[0, 2].Image = Chess.Properties.Resources.Black_Bishop;
            Pieces.piece[0, 5] = new Bishop(Color.Black, Type.Bishop);
            Pieces.board[0, 5].Image = Chess.Properties.Resources.Black_Bishop;
            Pieces.piece[7, 2] = new Bishop(Color.White, Type.Bishop);
            Pieces.board[7, 2].Image = Chess.Properties.Resources.White_Bishop;
            Pieces.piece[7, 5] = new Bishop(Color.White, Type.Bishop);
            Pieces.board[7, 5].Image = Chess.Properties.Resources.White_Bishop;

            //KINGS & QUEENS
            Pieces.piece[0, 4] = new King(Color.Black, Type.King);
            Pieces.board[0, 4].Image = Chess.Properties.Resources.Black_King;
            Pieces.piece[0, 3] = new Queen(Color.Black, Type.Queen);
            Pieces.board[0, 3].Image = Chess.Properties.Resources.Black_Queen;
            Pieces.piece[7, 4] = new King(Color.White, Type.King);
            Pieces.board[7, 4].Image = Chess.Properties.Resources.White_King;
            Pieces.piece[7, 3] = new Queen(Color.White, Type.Queen);
            Pieces.board[7, 3].Image = Chess.Properties.Resources.White_Queen;

            this.DeselectBoard();
        }

        //DeselectBoard()
        //Deselects board - makes all the buttons have white color background
        //NOTE: White just means non-selected field, the actual field color is 2 shades of gray
        public void DeselectBoard()
        {
            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(41, 41, 41);
                    else
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(81, 81, 81);
                }

            Pieces.castleFlag = false;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (this.timer1.Enabled == true) //allow clicking on board only after timer start
            {
                Button b = (Button)sender; //takes the currently clicked button as button object b
                y = (b.Bottom - 95) / 70; //calculates Y position from Y button property (from Form1, bottom edge of button)
                x = (b.Left - 25) / 70; //calculates X position from X button property (from Form1, left edge of button)

                /*
                 INFO & FORMATING:  
                 piece[y,x] ->Chess Pieces matrix 
                 board[y,x] ->Buttons / Board Fields matrix
                 Counting starts from 0,0 from top left corner (A8 field) and has Y,X format
                 b is currently clicked button object used only within this function(event)
                */

                ///////////////////////// MOVEMENT /////////////////////////

                //check if any piece is selected
                for (i = 0; i < 8; i++)
                    for (j = 0; j < 8; j++)
                        if (Pieces.piece[i, j].Selected == true)
                            flagSelected = true;

                //If a piece is selected and ready to move - cases
                if (flagSelected == true)
                {
                    if (x == prevX && y == prevY)
                    { //Same piece = deselect
                        this.DeselectBoard();
                        flagSelected = false;
                        Pieces.piece[y, x].Selected = false;
                    }
                    else if (Pieces.piece[y, x].Color == Pieces.piece[prevY, prevX].Color && Pieces.castleFlag == false)
                    { //Same colored piece = deselect
                        this.DeselectBoard();
                        flagSelected = false;
                        Pieces.piece[prevY, prevX].Selected = false;
                        Pieces.piece[y, x].SelectFields(y, x);
                        prevX = x;
                        prevY = y;
                        flagMoved = true;
                    }
                    else if (Pieces.board[y, x].BackColor != System.Drawing.Color.FromArgb(41, 41, 41) && Pieces.board[y, x].BackColor != System.Drawing.Color.FromArgb(81, 81, 81))
                    { //Move and/or Take piece
                        if (!(Pieces.piece[prevY, prevX].Type == Type.King && Pieces.piece[y, x].Type == Type.Rook && Pieces.piece[prevY, prevX].Color == Pieces.piece[y, x].Color)) //check if it's trying to special move Castle
                        {
                            if (Pieces.piece[y, x].Type == Type.King) //flag if king is being taken
                                winFlag = true;

                            //checks if a piece is being taken (used for move history write "x")
                            bool takeFlag = false;
                            if (Pieces.piece[y, x].Color != Color.NULL)
                                takeFlag = true;

                            Pieces.piece[y, x] = Pieces.piece[prevY, prevX];
                            Pieces.board[y, x].Image = Pieces.board[prevY, prevX].Image;
                            Pieces.piece[prevY, prevX] = new Piece(Color.NULL, Type.NULL);
                            Pieces.board[prevY, prevX].Image = null;
                            flagSelected = false;
                            Pieces.piece[prevY, prevX].Selected = false;
                            this.DeselectBoard();
                            flagMoved = true;

                            Pieces.passantFlag1 = false; //reset En Passant viability after 1 turn

                            if (Math.Abs(prevY - y) == 2 && Pieces.piece[y, x].Type == Type.Pawn) //check if pawn moved 2 spaces
                            {
                                Pieces.passantFlag1 = true; //allow En Passant next turn
                                Pieces.pawnX = x;
                                Pieces.pawnY = y;
                                //save EnPassantable pawn location
                            }

                            //SPECIAL MOVE: Pawn becomes queen
                            if (y == 0 && Pieces.piece[y, x].Color == Color.White && Pieces.piece[y, x].Type == Type.Pawn)
                            {
                                Pieces.piece[y, x] = new Queen(Color.White, Type.Queen);
                                Pieces.board[y, x].Image = Chess.Properties.Resources.White_Queen;
                            }
                            if (y == 7 && Pieces.piece[y, x].Color == Color.Black && Pieces.piece[y, x].Type == Type.Pawn)
                            {
                                Pieces.piece[y, x] = new Queen(Color.Black, Type.Queen);
                                Pieces.board[y, x].Image = Chess.Properties.Resources.Black_Queen;
                            }

                            //SPECIAL MOVE: En Passant
                            if (Pieces.passantFlag2 == true)
                            {
                                Pieces.piece[Pieces.pawnY, Pieces.pawnX] = new Piece(Color.NULL, Type.NULL);
                                Pieces.board[Pieces.pawnY, Pieces.pawnX].Image = null;
                                Pieces.passantFlag2 = false;
                                takeFlag = true;
                            }

                            //write move in adequate move history box
                            //it has to be after En Passant and Pawn-Becomes-Queen bullshit or else it had problems due to SelectFields() call in MoveHistoryWrite()
                            //dev note: Fuck pawns and all their special moves <3
                            this.MoveHistoryWrite(y, x, takeFlag);

                        }
                        //SPECIAL MOVE: Castle
                        if (Pieces.castleFlag == true)
                        {
                            if (prevY == 0)
                                if (x == 0)
                                {
                                    Pieces.piece[0, 2] = new King(Color.Black, Type.King);
                                    Pieces.board[0, 2].Image = Chess.Properties.Resources.Black_King;
                                    Pieces.piece[0, 3] = new Rook(Color.Black, Type.Rook);
                                    Pieces.board[0, 3].Image = Chess.Properties.Resources.Black_Rook;

                                    Pieces.piece[prevY, prevX] = new Piece(Color.NULL, Type.NULL);
                                    Pieces.board[prevY, prevX].Image = null;
                                    Pieces.piece[y, x] = new Piece(Color.NULL, Type.NULL);
                                    Pieces.board[y, x].Image = null;
                                    this.DeselectBoard();
                                    flagMoved = true;
                                    MoveHistoryBlack.Items.Insert(0, "Castle");
                                    GameAudio("castle");

                                }
                                else if (x == 7)
                                {
                                    Pieces.piece[0, 6] = new King(Color.Black, Type.King);
                                    Pieces.board[0, 6].Image = Chess.Properties.Resources.Black_King;
                                    Pieces.piece[0, 5] = new Rook(Color.Black, Type.Rook);
                                    Pieces.board[0, 5].Image = Chess.Properties.Resources.Black_Rook;

                                    Pieces.piece[prevY, prevX] = new Piece(Color.NULL, Type.NULL);
                                    Pieces.board[prevY, prevX].Image = null;
                                    Pieces.piece[y, x] = new Piece(Color.NULL, Type.NULL);
                                    Pieces.board[y, x].Image = null;
                                    this.DeselectBoard();
                                    flagMoved = true;
                                    MoveHistoryBlack.Items.Insert(0, "Castle");
                                    GameAudio("castle");
                                }
                            if (prevY == 7)
                                if (x == 0)
                                {
                                    Pieces.piece[7, 2] = new King(Color.White, Type.King);
                                    Pieces.board[7, 2].Image = Chess.Properties.Resources.White_King;
                                    Pieces.piece[7, 3] = new Rook(Color.White, Type.Rook);
                                    Pieces.board[7, 3].Image = Chess.Properties.Resources.White_Rook;

                                    Pieces.piece[prevY, prevX] = new Piece(Color.NULL, Type.NULL);
                                    Pieces.board[prevY, prevX].Image = null;
                                    Pieces.piece[y, x] = new Piece(Color.NULL, Type.NULL);
                                    Pieces.board[y, x].Image = null;
                                    this.DeselectBoard();
                                    flagMoved = true;
                                    MoveHistoryWhite.Items.Insert(0, "Castle");
                                    GameAudio("castle");
                                }
                                else if (x == 7)
                                {
                                    Pieces.piece[7, 6] = new King(Color.White, Type.King);
                                    Pieces.board[7, 6].Image = Chess.Properties.Resources.White_King;
                                    Pieces.piece[7, 5] = new Rook(Color.White, Type.Rook);
                                    Pieces.board[7, 5].Image = Chess.Properties.Resources.White_Rook;

                                    Pieces.piece[prevY, prevX] = new Piece(Color.NULL, Type.NULL);
                                    Pieces.board[prevY, prevX].Image = null;
                                    Pieces.piece[y, x] = new Piece(Color.NULL, Type.NULL);
                                    Pieces.board[y, x].Image = null;
                                    this.DeselectBoard();
                                    flagMoved = true;
                                    MoveHistoryWhite.Items.Insert(0, "Castle");
                                    GameAudio("castle");
                                }
                        }

                        //switch turn
                        if (turn == Color.White)
                        {
                            turn = Color.Black;
                            BlackTimerPictureBox.BackColor = System.Drawing.Color.FromArgb(255, 128, 128); 
                            WhiteTimerPictureBox.BackColor = System.Drawing.Color.Transparent;
                        }
                        else
                        {
                            turn = Color.White;
                            WhiteTimerPictureBox.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            BlackTimerPictureBox.BackColor = System.Drawing.Color.Transparent;

                        }

                    }
                    else if (Pieces.board[y, x].BackColor == System.Drawing.Color.FromArgb(41, 41, 41) || Pieces.board[y, x].BackColor == System.Drawing.Color.FromArgb(81, 81, 81))
                    { //empty non-selected field = deselect
                        this.DeselectBoard();
                        flagSelected = false;
                        Pieces.piece[prevY, prevX].Selected = false;
                    }

                    //Win condition check
                    if (winFlag == true)
                        ForfeitButton.PerformClick(); //inverted because turn of the turn switch in above code

                }

                //if no piece is selected, select current piece
                if (flagSelected == false && Pieces.piece[y, x].Color != Color.NULL && Pieces.piece[y, x].Color == turn && flagMoved == false)
                {
                    Pieces.piece[y, x].SelectFields(y, x);
                    prevX = x;
                    prevY = y;
                }

                flagMoved = false;

            }
        }

        ///////////////////////// TIMER, UI, AUDIO /////////////////////////

        private long totalSeconds;
        private long totalSecondsWhite, totalSecondsBlack;
        private int scoreWhite, scoreBlack;

        //LoadUI()
        //Loads UI and values for the initial startup of the application
        public void LoadUI()
        {
            //set hh,mm,ss combo box items
            int i;
            for (i = 0; i < 60; i++)
            {
                this.MinuteBox.Items.Add(i.ToString());
                this.SecondBox.Items.Add(i.ToString());
            }
            for (i = 0; i < 24; i++)
            {
                this.HourBox.Items.Add(i.ToString());
            }

            //set default values to 00:01:00 and disable timer label on startup
            this.HourBox.SelectedIndex = 0;
            this.MinuteBox.SelectedIndex = 1;
            this.SecondBox.SelectedIndex = 0;
            this.TimerLabelWhite.Visible = false;
            this.TimerLabelWhite.Enabled = false;
            this.TimerLabelBlack.Visible = false;
            this.TimerLabelBlack.Enabled = false;
            this.ForfeitButton.Visible = false;
            this.ForfeitButton.Enabled = false;

            //set score to 0:0
            scoreWhite = 0;
            scoreBlack = 0;
            ScoreLabel.Text = "Score:      " + scoreWhite + "   -   " + scoreBlack;
        }

        //StartTimeClick() event
        //Starts the game - enables board piece movement, starts timers, activates game UI
        private void StartTimeClick(object sender, EventArgs e)
        {
            //get seconds, minutes, hours from combo boxes
            int seconds = int.Parse(this.SecondBox.SelectedItem.ToString());
            int minutes = int.Parse(this.MinuteBox.SelectedItem.ToString());
            int hours = int.Parse(this.HourBox.SelectedItem.ToString());

            //calculate TOTAL seconds
            totalSeconds = (hours * 3600) + (minutes * 60) + seconds + 1;
            totalSecondsWhite = totalSeconds;
            totalSecondsBlack = totalSeconds;

            //enable timer label
            this.TimerLabelWhite.Visible = true;
            this.TimerLabelWhite.Enabled = true;
            this.TimerLabelBlack.Visible = true;
            this.TimerLabelBlack.Enabled = true;

            //turn on forfeit button
            this.ForfeitButton.Visible = true;
            this.ForfeitButton.Enabled = true;

            //start timer
            this.timer1.Enabled = true;

            //disable combo boxes for setting time
            this.HourBox.Visible = false;
            this.HourBox.Enabled = false;
            this.MinuteBox.Visible = false;
            this.MinuteBox.Enabled = false;
            this.SecondBox.Visible = false;
            this.SecondBox.Enabled = false;

            //set background color for current turn on picture box next to timer
            WhiteTimerPictureBox.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            BlackTimerPictureBox.BackColor = System.Drawing.Color.Transparent;

            //disable the start time button
            this.StartTimeButton.Visible = false;
            this.StartTimeButton.Enabled = false;

            //play Start Game sound
            GameAudio("GameStart");
        }


        //timer1_tick() event
        //Event activates every second, adds -1 to the counter of the player whose turn it is
        //ends the game and resets the board pieces and UI if one of the timers has reached 0
        private void timer1_Tick(object sender, EventArgs e)
        {
            //set black timer time the same second the white timer starts ticking at the start
            if (totalSecondsBlack == totalSeconds && totalSecondsWhite == totalSeconds)
            {
                totalSecondsBlack--;
                long hoursBlack = totalSecondsBlack / 3600;
                long minutesBlack = (totalSecondsBlack - (hoursBlack * 3600)) / 60;
                long secondsBlack = totalSecondsBlack - (minutesBlack * 60) - (hoursBlack * 3600);
                if (hoursBlack < 10 && minutesBlack < 10 && secondsBlack < 10)
                    this.TimerLabelBlack.Text = "0" + hoursBlack.ToString() + "  :  0" + minutesBlack.ToString() + "  :  0" + secondsBlack.ToString();
                else if (hoursBlack < 10 && minutesBlack < 10)
                    this.TimerLabelBlack.Text = "0" + hoursBlack.ToString() + "  :  0" + minutesBlack.ToString() + "  :  " + secondsBlack.ToString();
                else if (hoursBlack < 10 && secondsBlack < 10)
                    this.TimerLabelBlack.Text = "0" + hoursBlack.ToString() + "  :  " + minutesBlack.ToString() + "  :  0" + secondsBlack.ToString();
                else if (minutesBlack < 10 && secondsBlack < 10)
                    this.TimerLabelBlack.Text = hoursBlack.ToString() + "  :  0" + minutesBlack.ToString() + "  :  0" + secondsBlack.ToString();
                else if (secondsBlack < 10)
                    this.TimerLabelBlack.Text = hoursBlack.ToString() + "  :  " + minutesBlack.ToString() + "  :  0" + secondsBlack.ToString();
                else if (minutesBlack < 10)
                    this.TimerLabelBlack.Text = hoursBlack.ToString() + "  :  0" + minutesBlack.ToString() + "  :  " + secondsBlack.ToString();
                else if (hoursBlack < 10)
                    this.TimerLabelBlack.Text = "0" + hoursBlack.ToString() + "  :  " + minutesBlack.ToString() + "  :  " + secondsBlack.ToString();
                else
                    this.TimerLabelBlack.Text = hoursBlack.ToString() + "  :  " + minutesBlack.ToString() + "  :  " + secondsBlack.ToString();
            }

            if (totalSecondsWhite > 0 && turn == Color.White)
            { //if timer didn't reach 0 and it's white turn
                totalSecondsWhite--;
                long hoursWhite = totalSecondsWhite / 3600;
                long minutesWhite = (totalSecondsWhite - (hoursWhite * 3600)) / 60;
                long secondsWhite = totalSecondsWhite - (minutesWhite * 60) - (hoursWhite * 3600);
                if (hoursWhite < 10 && minutesWhite < 10 && secondsWhite < 10)
                    this.TimerLabelWhite.Text = "0" + hoursWhite.ToString() + "  :  0" + minutesWhite.ToString() + "  :  0" + secondsWhite.ToString();
                else if (hoursWhite < 10 && minutesWhite < 10)
                    this.TimerLabelWhite.Text = "0" + hoursWhite.ToString() + "  :  0" + minutesWhite.ToString() + "  :  " + secondsWhite.ToString();
                else if (hoursWhite < 10 && secondsWhite < 10)
                    this.TimerLabelWhite.Text = "0" + hoursWhite.ToString() + "  :  " + minutesWhite.ToString() + "  :  0" + secondsWhite.ToString();
                else if (minutesWhite < 10 && secondsWhite < 10)
                    this.TimerLabelWhite.Text = hoursWhite.ToString() + "  :  0" + minutesWhite.ToString() + "  :  0" + secondsWhite.ToString();
                else if (secondsWhite < 10)
                    this.TimerLabelWhite.Text = hoursWhite.ToString() + "  :  " + minutesWhite.ToString() + "  :  0" + secondsWhite.ToString();
                else if (minutesWhite < 10)
                    this.TimerLabelWhite.Text = hoursWhite.ToString() + "  :  0" + minutesWhite.ToString() + "  :  " + secondsWhite.ToString();
                else if (hoursWhite < 10)
                    this.TimerLabelWhite.Text = "0" + hoursWhite.ToString() + "  :  " + minutesWhite.ToString() + "  :  " + secondsWhite.ToString();
                else
                    this.TimerLabelWhite.Text = hoursWhite.ToString() + "  :  " + minutesWhite.ToString() + "  :  " + secondsWhite.ToString();
            }
            else if (totalSecondsBlack > 0 && turn == Color.Black)
            { //if timer didn't reach 0 and it's black turn
                totalSecondsBlack--;
                long hoursBlack = totalSecondsBlack / 3600;
                long minutesBlack = (totalSecondsBlack - (hoursBlack * 3600)) / 60;
                long secondsBlack = totalSecondsBlack - (minutesBlack * 60) - (hoursBlack * 3600);
                if (hoursBlack < 10 && minutesBlack < 10 && secondsBlack < 10)
                    this.TimerLabelBlack.Text = "0" + hoursBlack.ToString() + "  :  0" + minutesBlack.ToString() + "  :  0" + secondsBlack.ToString();
                else if (hoursBlack < 10 && minutesBlack < 10)
                    this.TimerLabelBlack.Text = "0" + hoursBlack.ToString() + "  :  0" + minutesBlack.ToString() + "  :  " + secondsBlack.ToString();
                else if (hoursBlack < 10 && secondsBlack < 10)
                    this.TimerLabelBlack.Text = "0" + hoursBlack.ToString() + "  :  " + minutesBlack.ToString() + "  :  0" + secondsBlack.ToString();
                else if (minutesBlack < 10 && secondsBlack < 10)
                    this.TimerLabelBlack.Text = hoursBlack.ToString() + "  :  0" + minutesBlack.ToString() + "  :  0" + secondsBlack.ToString();
                else if (secondsBlack < 10)
                    this.TimerLabelBlack.Text = hoursBlack.ToString() + "  :  " + minutesBlack.ToString() + "  :  0" + secondsBlack.ToString();
                else if (minutesBlack < 10)
                    this.TimerLabelBlack.Text = hoursBlack.ToString() + "  :  0" + minutesBlack.ToString() + "  :  " + secondsBlack.ToString();
                else if (hoursBlack < 10)
                    this.TimerLabelBlack.Text = "0" + hoursBlack.ToString() + "  :  " + minutesBlack.ToString() + "  :  " + secondsBlack.ToString();
                else
                    this.TimerLabelBlack.Text = hoursBlack.ToString() + "  :  " + minutesBlack.ToString() + "  :  " + secondsBlack.ToString();
            }
            else
            { //if either timer reached 0
                if (totalSecondsBlack == 0 || totalSecondsWhite == 0)
                    ForfeitButton.PerformClick();
            }
        }

        //ForfeitButtonClick event
        //Forfeits the game for the player whose turn it is, resets the board and move history fully,
        //updates the score, resets the timer, and prepares UI for a new game start
        //used as end game button if king is taken or if time runs out for either player
        private void ForfeitButtonClick(object sender, EventArgs e)
        {
            //play Game Over sound
            GameAudio("GameOver");

            this.timer1.Stop();

            if (turn == Color.Black)
            {
                scoreWhite++;
                MessageBox.Show("White wins!");
                ScoreLabel.Text = "Score:      " + scoreWhite + "   -   " + scoreBlack;
            }
            else
            {
                scoreBlack++;
                MessageBox.Show("Black wins!");
                ScoreLabel.Text = "Score:      " + scoreWhite + "   -   " + scoreBlack;
            }

            //reset game board and pieces
            this.DeselectBoard();
            this.SettupPieces();
            winFlag = false;

            //enable hh,mm,ss combo boxes
            this.HourBox.Visible = true;
            this.HourBox.Enabled = true;
            this.MinuteBox.Visible = true;
            this.MinuteBox.Enabled = true;
            this.SecondBox.Visible = true;
            this.SecondBox.Enabled = true;

            //reset both timer labels to 00:00:00
            this.TimerLabelWhite.Text = "00  :  00  :  00";
            this.TimerLabelBlack.Text = "00  :  00  :  00";

            //set default box values to 00:01:00 and disable timer again
            this.HourBox.SelectedIndex = 0;
            this.MinuteBox.SelectedIndex = 1;
            this.SecondBox.SelectedIndex = 0;
            this.TimerLabelWhite.Visible = false;
            this.TimerLabelWhite.Enabled = false;
            this.TimerLabelBlack.Visible = false;
            this.TimerLabelBlack.Enabled = false;

            //turn off forfeit button
            this.ForfeitButton.Visible = false;
            this.ForfeitButton.Enabled = false;

            //reset color on both picture boxes next to timer
            WhiteTimerPictureBox.BackColor = System.Drawing.Color.Transparent;
            BlackTimerPictureBox.BackColor = System.Drawing.Color.Transparent;

            //clear move history for white and black player
            MoveHistoryWhite.Items.Clear();
            MoveHistoryBlack.Items.Clear();

            //enable the start time button
            this.StartTimeButton.Visible = true;
            this.StartTimeButton.Enabled = true;
        }

        //MoveHistoryWrite()
        //writes the code (Piece type, if it took opponent piece, moved to field name, if enemy king is checked)
        //into white or black move history viewList
        public void MoveHistoryWrite(int y, int x, bool takeFlag)
        {
            string historyType, historyTake, historyPosition, historyMate;

            historyType = Pieces.piece[y, x].Type.ToString();
            historyType = historyType.Substring(0, 1);

            if (takeFlag)
                historyTake = "x";
            else
                historyTake = "";

            historyPosition = Pieces.board[y, x].Name.ToString();
            historyPosition = historyPosition.Substring(0, 2);

            // check if the opponent king is checked (yes, I know the bool is called mated but it checks for checking)
            int i1, j1, i2, j2;
            bool mated = false;
            for (i1 = 0; i1 < 8; i1++)
                for (j1 = 0; j1 < 8; j1++)
                {
                    if (Pieces.piece[j1, i1].Color == turn)
                    {
                        Pieces.piece[j1, i1].SelectFields(j1, i1);
                        for (i2 = 0; i2 < 8; i2++)
                            for (j2 = 0; j2 < 8; j2++)
                            {
                                if (Pieces.piece[j2, i2].Type == Type.King && Pieces.piece[j2, i2].Color != Pieces.piece[y, x].Color && Pieces.board[j2, i2].BackColor == System.Drawing.Color.SkyBlue)
                                    mated = true;
                            }
                        Pieces.piece[j1, i1].Selected = false;
                        this.DeselectBoard();
                    }
                }

            if (mated)
                historyMate = "+";
            else
                historyMate = "";

            //add move to the top of white or black listView for move history (bottom has problem for visibility after a few moves)
            if (Pieces.piece[y, x].Color == Color.White)
                MoveHistoryWhite.Items.Insert(0, historyType + historyTake + historyPosition.ToLower() + historyMate); //adds to top
                //MoveHistoryWhite.Items.Add(historyType + historyTake + historyPosition.ToLower()); //adds to bottom
            else
                MoveHistoryBlack.Items.Insert(0, historyType + historyTake + historyPosition.ToLower() + historyMate); //adds to top
                //MoveHistoryBlack.Items.Add(historyType + historyTake + historyPosition.ToLower()); //adds to bottom
            
            //play audio based on move parameters
            if (winFlag)
                GameAudio("GameOver");
            else if (mated)
                GameAudio("check");
            else if (takeFlag)
                GameAudio("capture");
            else
                GameAudio("move");

        }

        //GameAudio()
        //Plays the sounds based on what move is made or which button is clicked
        public void GameAudio(string type)
        {
            SoundPlayer AudioMove = new SoundPlayer(Chess.Properties.Resources.Audio_Move);
            SoundPlayer AudioCapture = new SoundPlayer(Chess.Properties.Resources.Audio_Capture);
            SoundPlayer AudioCastle = new SoundPlayer(Chess.Properties.Resources.Audio_Castle);
            SoundPlayer AudioCheck = new SoundPlayer(Chess.Properties.Resources.Audio_Check);
            SoundPlayer AudioGameStart = new SoundPlayer(Chess.Properties.Resources.Audio_GameStart);
            SoundPlayer AudioGameOver = new SoundPlayer(Chess.Properties.Resources.Audio_GameOver);
            
            switch (type)
            {
                case "move":
                    AudioMove.Play();
                    break;
                case "capture":
                    AudioCapture.Play();
                    break;
                case "castle":
                    AudioCastle.Play();
                    break;
                case "check":
                    AudioCheck.Play();
                    break;
                case "GameStart":
                    AudioGameStart.Play();
                    break;
                case "GameOver":
                    AudioGameOver.Play();
                    break;
            }
        }

    }

    public static class Pieces
    {
        public static Button[,] board = new Button[8, 8];
        public static Piece[,] piece = new Piece[8, 8];
        public static bool castleFlag = false;
        public static bool passantFlag1 = false;
        public static bool passantFlag2 = false;
        public static int pawnX, pawnY; //Special Move En Passant temporary values
    }

}

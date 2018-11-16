using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        
        static string[,,] rooms = new string[6, 6,3] {
            {{"SE", "",""},{"SW","","" },{"ES", "The entryway collapses behind you.",""},{"EW","","" },{"SW","","" },{"S","","" } },//0
            {{"NS", "",""},{"NE", "",""},{"NEW", "",""},{"SW", "",""},{"NS", "",""},{"NS", "",""}},//1
            {{"NE", "",""},{"EW", "",""},{"SW", "","Normal"},{"NS", "",""},{"NES", "","Normal"},{"NW", "",""}},//2
            {{"ES", "",""},{"EW", "","Elite"},{"NEW", "",""},{"NSW", "",""},{"NE", "",""},{"SW", "",""}},//3
            {{"N", "",""},{"ES", "",""},{"SW", "",""},{"NE", "",""},{"ESW", "",""},{"NSW", "",""}},//4
            {{"E", "To the west you see the exit of the maze!",""},{"NW", "",""},{"NE", "",""},{"EW", "",""},{"NW", "","Boss"},{"N", "",""}} //5
        };
        int playerX = 2;
        int playerY = -1;
        //on load event
        private void Form1_Load(object sender, EventArgs e) {
            
        }
        //update room details in form
        private void UpdateRoom(string move) {
            //MessageBox.Show(rooms[y, x]);
            //change x and y
            switch (move) {
                case "North":
                    playerY--;
                    break;
                case "East":
                    playerX++;
                    break;
                case "South":
                    playerY++;
                    break;
                case "West":
                    playerX--;
                    break;
                default:
                    break;
            }
            //buttons
            buttonNorth.Enabled = rooms[playerY,playerX,0].Contains("N") ? true : false;
            buttonEast.Enabled = rooms[playerY, playerX, 0].Contains("E") ? true : false;
            buttonSouth.Enabled = rooms[playerY, playerX, 0].Contains("S") ? true : false;
            buttonWest.Enabled = rooms[playerY, playerX, 0].Contains("W") ? true : false;
            //room description
            labelRoomDescription.Text = rooms[playerY, playerX, 1];
            if (playerX==2 && playerY==0) {
                rooms[0, 2, 1] = "The entryway to the north is blocked.";
            }
            //monster fight check
            switch (rooms[playerX, playerY, 2])
            {
                case "Normal":

                    break;
                case "Elite":

                    break;
                case "Boss":

                    break;
            }
        }

        //change views
        private void ChangeState(string state) {
            switch(state) {
                case "Map":
                    MapState(true);
                    FightState(false);
                    break;
                case "Fight":
                    FightState(true);
                    MapState(false);
                    break;
            }
        }
        //Map view state
        private void MapState(bool b) {
            labelRoomDescription.Visible = b;
            buttonNorth.Visible = b;
            buttonEast.Visible = b;
            buttonSouth.Visible = b;
            buttonWest.Visible = b;
        }
        //Fight view state
        private void FightState(bool b) {

        }
        //direction buttons
        private void buttonNorth_Click(object sender, EventArgs e) => UpdateRoom("North");

        private void buttonEast_Click(object sender, EventArgs e) => UpdateRoom("East");

        private void buttonSouth_Click(object sender, EventArgs e) => UpdateRoom("South");

        private void buttonWest_Click(object sender, EventArgs e) => UpdateRoom("West");
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace tictactoe
{
    public partial class Form1 : Form
    {
        // below is the player class which has two value
        // X and O
        // by doing this we can control the player and AI symbols
        public enum Player
        {
            X, O
        }
 
        Player currentPlayer; // calling the player class 
 
        List<Button> buttons; // creating a LIST or array of buttons
        Random rand = new Random(); // importing the random number generator class
        int playerWins = 0; // set the player win integer to 0
        int computerWins = 0; // set the computer win integer to 0
 
        public Form1()
        {
            InitializeComponent();
            resetGame(); // call the set game function
        }
 
        private void playerClick(object sender, EventArgs e)
        {
            var button = (Button)sender; // find which button was clicked
            currentPlayer = Player.X; // set the player to X
            button.Text = currentPlayer.ToString(); // change the button text to player X
            button.Enabled = false; // disable the button
            button.BackColor = System.Drawing.Color.Cyan; // change the player colour to Cyan
            buttons.Remove(button); //remove the button from the list buttons so the AI can't click it either
            Check(); // check if the player won
            AImoves.Start(); // start the AI timer
        }
 
        private void AImove(object sender, EventArgs e)
        {
            // THE CPU will randomly choose a button from the list to click. 
            // While the array is greater than 0 the cpu will operate in the game
            // if the array is less than 0 it will stop playing
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count); // generate a random number within the number of buttons available
                buttons[index].Enabled = false; // assign the number to the button
                // when the random number is generated then we will look into the list
                // for what that number is we select that button
                // for example if the number is 8
                // then we select the 8th button in the list
 
                currentPlayer = Player.O; // set the AI with O
                buttons[index].Text = currentPlayer.ToString(); // show O on the button
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon; // change the background of the button dark salmon colour
                buttons.RemoveAt(index); // remove that button from the list
                Check(); // check if the AI won anything
                AImoves.Stop(); // stop the AI timer
            }
        }
 
        private void restartGame(object sender, EventArgs e)
        {
            // this function is linked with the reset button
            // when the reset button is clicked then
            // this function will run the reset game function
            resetGame();
        }
 
        private void loadbuttons()
        {
            // this the custom function which will load all the buttons from the form to the buttons list
            buttons = new List<Button> { button0, button1, button2, button3, button4, button5, button6, button7, button8, button9,button10,
            button11, button12, button13, button14, button15, button16, button17, button18, button19,button20, 
            button21, button22, button23, button24, button25, button26, button27, button28, button29,button30,
            button31, button32, button33, button34, button35, button36, button37, button38, button39,button40, 
            button41, button42, button43, button44, button45, button46, button47, button48, button49};
        }
 
        private void resetGame()
        {
            //check each of the button with a tag of play
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true; // change them all back to enabled or clickable
                    ((Button)X).Text = "?"; // set the text to question mark
                    ((Button)X).BackColor = default(Color); // change the background colour to default button colors
                }
            }
 
            loadbuttons(); // run the load buttons function so all the buttons are inserted back in the array
        }
 
        private void Check()
        {
            //in this function we will check if the player or the AI has won
            // we have two very large if statements with the winning possibilities
//Winning Condition For First Row 
            for(int i=1;i<5;i++)
                if (buttons[i].Text=="X"  && buttons[i+1].Text=="X"  && buttons[i+2].Text=="X" && buttons[i+3].Text=="X")
			{
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }
//Winning Condition For Second Row  
            for(i=8;i<12;i++){
                if (buttons[i].Text=="X"  && buttons[i+1].Text=="X"  && buttons[i+2].Text=="X" && buttons[i+3].Text=="X")
			{
            
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }

//Winning Condition For Third Row
            for( i=15;i<19;i++){
                if (buttons[i].Text=="X"  && buttons[i+1].Text=="X"  && buttons[i+2].Text=="X" && buttons[i+3].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }
//Winning Condition For Fourth Row
            for( i=22;i<26;i++){
                if (buttons[i].Text=="X"  && buttons[i+1].Text=="X"  && buttons[i+2].Text=="X" && buttons[i+3].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }           
//Winning Condition For Fifth Row  
            for(i=29;i<33;i++){
                if (buttons[i].Text=="X"  && buttons[i+1].Text=="X"  && buttons[i+2].Text=="X" && buttons[i+3].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            } 
//Winning Condition For Sixth Row  
            for( i=36;i<40;i++){
                if (buttons[i].Text=="X"  && buttons[i+1].Text=="X"  && buttons[i+2].Text=="X" && buttons[i+3].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            } 
//Winning Condition For Seventh Row   
            for(i=43;i<47;i++){
                if (buttons[i].Text=="X"  && buttons[i+1].Text=="X"  && buttons[i+2].Text=="X" && buttons[i+3].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            } 
//------------------------------------------------------------------------------------
//Winning Condition For First Column
            for( i=1;i<29;i=i+7){
                if (buttons[i].Text=="X"  && buttons[i+7].Text=="X"  && buttons[i+14].Text=="X" && buttons[i+21].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }
//Winning Condition For Second Column
            for( i=2;i<30;i=i+7){
                if (buttons[i].Text=="X"  && buttons[i+7].Text=="X"  && buttons[i+14].Text=="X" && buttons[i+21].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }
//Winning Condition For Third Column  
            for( i=3;i<31;i=i+7){
                if (buttons[i].Text=="X"  && buttons[i+7].Text=="X"  && buttons[i+14].Text=="X" && buttons[i+21].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }  
//Winning Condition For Fourth Column
            for( i=4;i<32;i=i+7){
                if (buttons[i].Text=="X"  && buttons[i+7].Text=="X"  && buttons[i+14].Text=="X" && buttons[i+21].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }   
//Winning Condition For Fifth Column 
            for(i=5;i<33;i=i+7){
                if (buttons[i].Text=="X"  && buttons[i+7].Text=="X"  && buttons[i+14].Text=="X" && buttons[i+21].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            } 
//Winning Condition For Sixth Column
            for(i=6;i<34;i=i+7){
                if (buttons[i].Text=="X"  && buttons[i+7].Text=="X"  && buttons[i+14].Text=="X" && buttons[i+21].Text=="X")
			{
            
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }  
//Winning Condition For Seventh Column 
            for(i=7;i<35;i=i+7){
                if (buttons[i].Text=="X"  && buttons[i+7].Text=="X"  && buttons[i+14].Text=="X" && buttons[i+21].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }      
//-----------------------------------------------------------------------------------------
            for( i=1;i<5;i=i+1){
                if (buttons[i].Text=="X"  && buttons[i+8].Text=="X"  && buttons[i+16].Text=="X" && buttons[i+24].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }   
            for(i=4;i<8;i=i+1){
                if (buttons[i].Text=="X"  && buttons[i+6].Text=="X"  && buttons[i+12].Text=="X" && buttons[i+18].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            } 
//---------------
            for(i=8;i<12;i=i+1){
                if (buttons[i].Text=="X"  && buttons[i+8].Text=="X"  && buttons[i+16].Text=="X" && buttons[i+24].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }        
            for( i=11;i<15;i=i+1){
                if (buttons[i].Text=="X"  && buttons[i+6].Text=="X"  && buttons[i+12].Text=="X" && buttons[i+18].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }      
//-----------------
            for( i=15;i<19;i=i+1){
                if (buttons[i].Text=="X"  && buttons[i+8].Text=="X"  && buttons[i+16].Text=="X" && buttons[i+24].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }        
            for( i=18;i<22;i=i+1){
                if (buttons[i].Text=="X"  && buttons[i+6].Text=="X"  && buttons[i+12].Text=="X" && buttons[i+18].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }
//-----------------
            for(i=22;i<26;i=i+1){
                if (buttons[i].Text=="X"  && buttons[i+8].Text=="X"  && buttons[i+16].Text=="X" && buttons[i+24].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }        
            for(i=25;i<29;i=i+1){
                if (buttons[i].Text=="X"  && buttons[i+6].Text=="X"  && buttons[i+12].Text=="X" && buttons[i+18].Text=="X")
			
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            }    
//-----------------------------------------------------------------------------------------------------------------------------------------------     
            // below if statement is for when the AI wins the game
//Winning Condition For First Row 
            for(i=1;i<5;i++){
                if (buttons[i].Text=="O"  && buttons[i+1].Text=="O"  && buttons[i+2].Text=="O" && buttons[i+3].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }
//Winning Condition For Second Row  
            for(i=8;i<12;i++){
                if (buttons[i].Text=="O"  && buttons[i+1].Text=="O"  && buttons[i+2].Text=="O" && buttons[i+3].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }

//Winning Condition For Third Row
            for(i=15;i<19;i++){
                if (buttons[i].Text=="O"  && buttons[i+1].Text=="O"  && buttons[i+2].Text=="O" && buttons[i+3].Text=="O")
			{
            
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }
//Winning Condition For Fourth Row
            for(i=22;i<26;i++){
                if (buttons[i].Text=="O"  && buttons[i+1].Text=="O"  && buttons[i+2].Text=="O" && buttons[i+3].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }           
//Winning Condition For Fifth Row  
            for(i=29;i<33;i++){
                if (buttons[i].Text=="O"  && buttons[i+1].Text=="O"  && buttons[i+2].Text=="O" && buttons[i+3].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            } 
//Winning Condition For Sixth Row  
            for(i=36;i<40;i++){
                if (buttons[i].Text=="O"  && buttons[i+1].Text=="O"  && buttons[i+2].Text=="O" && buttons[i+3].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            } 
//Winning Condition For Seventh Row   
            for(i=43;i<47;i++){
                if (buttons[i].Text=="O"  && buttons[i+1].Text=="O"  && buttons[i+2].Text=="O" && buttons[i+3].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            } 
//------------------------------------------------------------------------------------
//Winning Condition For First Column
            for(i=1;i<29;i=i+7){
                if (buttons[i].Text=="O"  && buttons[i+7].Text=="O"  && buttons[i+14].Text=="O" && buttons[i+21].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }
//Winning Condition For Second Column
            for( i=2;i<30;i=i+7){
                if (buttons[i].Text=="O"  && buttons[i+7].Text=="O"  && buttons[i+14].Text=="O" && buttons[i+21].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }
//Winning Condition For Third Column  
            for( i=3;i<31;i=i+7){
                if (buttons[i].Text=="O"  && buttons[i+7].Text=="O"  && buttons[i+14].Text=="O" && buttons[i+21].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }  
//Winning Condition For Fourth Column
            for(i=4;i<32;i=i+7){
                if (buttons[i].Text=="O"  && buttons[i+7].Text=="O"  && buttons[i+14].Text=="O" && buttons[i+21].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }   
//Winning Condition For Fifth Column 
            for(i=5;i<33;i=i+7){
                if (buttons[i].Text=="O"  && buttons[i+7].Text=="O"  && buttons[i+14].Text=="O" && buttons[i+21].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            } 
//Winning Condition For Sixth Column
            for(i=6;i<34;i=i+7){
                if (buttons[i].Text=="O"  && buttons[i+7].Text=="O"  && buttons[i+14].Text=="O" && buttons[i+21].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }  
//Winning Condition For Seventh Column 
            for(i=7;i<35;i=i+7){
                if (buttons[i].Text=="O"  && buttons[i+7].Text=="O"  && buttons[i+14].Text=="O" && buttons[i+21].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }      
//-----------------------------------------------------------------------------------------
            for(i=1;i<5;i=i+1){
                if (buttons[i].Text=="O"  && buttons[i+8].Text=="O"  && buttons[i+16].Text=="O" && buttons[i+24].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }   
            for(i=4;i<8;i=i+1){
                if (buttons[i].Text=="O"  && buttons[i+6].Text=="O"  && buttons[i+12].Text=="O" && buttons[i+18].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            } 
//---------------
            for(i=8;i<12;i=i+1){
                if (buttons[i].Text=="O"  && buttons[i+8].Text=="O"  && buttons[i+16].Text=="O" && buttons[i+24].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }        
            for(i=11;i<15;i=i+1){
                if (buttons[i].Text=="O"  && buttons[i+6].Text=="O"  && buttons[i+12].Text=="O" && buttons[i+18].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }      
//-----------------
            for(i=15;i<19;i=i+1){
                if (buttons[i].Text=="O"  && buttons[i+8].Text=="O"  && buttons[i+16].Text=="O" && buttons[i+24].Text=="O")
			{
            
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }        
            for(i=18;i<22;i=i+1){
                if (buttons[i].Text=="O"  && buttons[i+6].Text=="O"  && buttons[i+12].Text=="O" && buttons[i+18].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }
//-----------------
            for(i=22;i<26;i=i+1){
                if (buttons[i].Text=="O"  && buttons[i+8].Text=="O"  && buttons[i+16].Text=="O" && buttons[i+24].Text=="O")
			{
            
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }        
            for(i=25;i<29;i=i+1){
                if (buttons[i].Text=="O"  && buttons[i+6].Text=="O"  && buttons[i+12].Text=="O" && buttons[i+18].Text=="O")
			
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }
            }    
        }
    }
}
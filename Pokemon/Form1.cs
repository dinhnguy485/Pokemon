using Pokemon.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon
{
    public partial class Form1 : Form
    {
        //Player
        Rectangle player1 = new Rectangle(400, 250, 35, 40);

        //Player Assets
        Image[] playerDownImages = { Properties.Resources.down1, Properties.Resources.down2, Properties.Resources.down3, Properties.Resources.down4 };
        Image[] playerLeftImages = { Properties.Resources.left1, Properties.Resources.left2, Properties.Resources.left3, Properties.Resources.left4 };
        Image[] playerRightImages = { Properties.Resources.right1, Properties.Resources.right2, Properties.Resources.right3, Properties.Resources.right4 };
        Image[] playerUpImages = { Properties.Resources.up1, Properties.Resources.up2, Properties.Resources.up3, Properties.Resources.up4 };

        //Track Player Direction
        enum Direction { Down, Left, Right, Up }
        Direction playerDirection = Direction.Down; //default direction
        Image playerCurrentDirection;

        //move Animation variables
        int animationFrame = 0;
        int animationSpeed = 2;
        int animationCounter = 0;
        int player1FrameIndex = 0;

        //Random
        Random randGen = new Random();

        //Lists
        List<Rectangle> treesList = new List<Rectangle>();
        List<Rectangle> treesHitBoxList = new List<Rectangle>();
        List<Rectangle> chestList = new List<Rectangle>();

        //Money Lists
        int[] moneyRequired = { 10, 20, 30, 50, 80, 130, 210, 340 };
        int i = 0;

        //trees Images
        Image[] treesImg = { Properties.Resources.tree1, Properties.Resources.tree2, Properties.Resources.tree3, Properties.Resources.grass };
        List<Image> treeImgList = new List<Image>();

        //Player House Setup
        Image playerHouse = Properties.Resources.house;
        Image HouseInteriorImg = Properties.Resources.houseInterior;
        Image vendingMachineImg = Properties.Resources.evolveMachine;

        Image[] pokemonsList = { Properties.Resources.pikachu, Properties.Resources.squirtle, Properties.Resources.charmander, Properties.Resources.bulbasaur };
        Image grassImg = Properties.Resources.bg;
        Image forrestImg = Properties.Resources.forest;
        Image chestImg = Properties.Resources.chestImg;
        Image plantArena = Properties.Resources.arena_plant;
        Image UpgradeStatsBg = Properties.Resources.UpgradeStatsBg;
        Image boss1 = Properties.Resources.boss1;
        Image boss2 = Properties.Resources.boss2;
        Image boss3 = Properties.Resources.boss3;
        Image playerPokemon;
        Image winImg = Properties.Resources.winnerImg;
        

        Image evolveScreenBg = Properties.Resources.evolveScreen;

        Rectangle actualChest = new Rectangle(20, 50, 30, 20);

        //Player House 
        Rectangle house = new Rectangle(480, 100, 230, 200);
        Rectangle door = new Rectangle(578, 290, 35, 10);
        Rectangle houseInterior = new Rectangle(200, -20, 400, 500);
        Rectangle exitDoor = new Rectangle(310, 450, 45, 10);
        Rectangle vendingMachine = new Rectangle(250, 100, 40, 70);

        Rectangle houseWall = new Rectangle(500, 240, 200, 58);
        Rectangle houseWallInterior1 = new Rectangle(220, -20, 10, 500);
        Rectangle houseWallInterior2 = new Rectangle(190, 100, 400, 10);
        Rectangle houseWallInterior3 = new Rectangle(570, -20, 10, 500);
        Rectangle houseWallInterior4 = new Rectangle(200, 440, 110, 10);
        Rectangle houseWallInterior5 = new Rectangle(355, 440, 215, 10);

        Rectangle arena

        //Grass and Arena
        Rectangle grass = new Rectangle(0, 0, 1000, 600);
        Rectangle grassArena = new Rectangle(300, 100, 200, 200);

        //Arena setup
        Rectangle enterArena = new Rectangle(387, 262, 29, 38);
        Rectangle statsBg = new Rectangle(480, 100, 300, 150);

        //Evolve Pokemon Pic Position
        Rectangle pokemonPicEvolve = new Rectangle(80, 80, 180, 180);
        String actualPokemon;

        //Player Stats
        string playerName;
        string gameState = "Start Screen";

        int pokemonLv = 1;
        int pokemonHealth = 100;
        int pokemonAtk = 60;
        int pokemonSpAtk = 120;
        int pokemonHeal = 40;

        int bossHealth = 1000;
        int bossAtk = 320;
        int bossSpAtk = 500;
        int bossHeal = 600;
        int bossCounter = 1;

        int playerMoney = 600;

        //Setup for Battle
        string playerChoice, cpuChoice;
        int choicePause = 1000;
        int outcomePause = 3000;
        int playerTurnCount = 0;
        int cpuTurnCount = 0;
        bool playerSpAttackOnCooldown = false;
        bool cpuSpAttackOnCooldown = false;


        //Brush
        SolidBrush transparent = new SolidBrush(Color.Transparent);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        Font drawFont = new Font("Arial", 16, FontStyle.Bold);

        //Player Speed
        int player1Speed = 10;

        //Player Movement Booleans
        bool wPressed = false;
        bool sPressed = false;
        bool aPressed = false;
        bool dPressed = false;

        public Form1()
        {
            InitializeComponent();
            InitializeGameScreen();
            playerCurrentDirection = Properties.Resources.down1;
            evolveButton.Visible = false;
            exitEvolve.Visible = false;
            gameLoop.Enabled = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
            }
        }

        public void PlayerMovement()
        {
            Rectangle newPlayerPosition = player1;

            //Track if the player is moving
            bool isMoving = false;

            // Diagonal speed normalization
            double speedModifier = 1.0;
            if ((wPressed || sPressed) && (aPressed || dPressed))
            {
                speedModifier = Math.Sqrt(2) / 2.0;
            }

            if (wPressed && newPlayerPosition.Y > 0)
            {
                newPlayerPosition.Y -= player1Speed;
                isMoving = true;
                playerDirection = Direction.Up; //Update direction
            }
            if (sPressed && newPlayerPosition.Y < this.Height - 80)
            {
                newPlayerPosition.Y += player1Speed;
                isMoving = true;
                playerDirection = Direction.Down;
            }
            if (aPressed && newPlayerPosition.X > 0)
            {
                newPlayerPosition.X -= player1Speed;

                if (player1.X < player1.Width && gameState == "Arena Screen")
                {
                    newPlayerPosition.X = this.Width - player1.Width;
                    InitializeMainScreen();

                }
                isMoving = true;
                playerDirection = Direction.Left;

            }
            if (dPressed)
            {
                newPlayerPosition.X += player1Speed;
                isMoving = true;
                playerDirection = Direction.Right;

                if (player1.X > this.Width && gameState == "Main Screen")
                {
                    gameState = "Arena Screen";
                    newPlayerPosition.X = 0;
                }

                if (dPressed == true && gameState == "Arena Screen" && newPlayerPosition.X > this.Width - player1.Width)
                {
                    newPlayerPosition.X = this.Width - player1.Width;
                }
            }

            player1 = newPlayerPosition;
            // Handle animation speed
            if (isMoving)
            {
                animationCounter++;
                if (animationCounter >= animationSpeed)
                {
                    animationCounter = 0;
                    player1FrameIndex = (player1FrameIndex + 1) % GetCurrentDirectionImages().Length;
                }
            }
            else
            {
                player1FrameIndex = 3; // Display the fourth image when not moving
            }
        }

        private Image[] GetCurrentDirectionImages()
        {
            switch (playerDirection)
            {
                case Direction.Up:
                    return playerUpImages;
                case Direction.Down:
                    return playerDownImages;
                case Direction.Left:
                    return playerLeftImages;
                case Direction.Right:
                    return playerRightImages;
                default:
                    return playerDownImages;
            }
        }

        private void obstacleHitBoxSpawn()
        {
            Rectangle treeHitBox1 = new Rectangle(30, 110, 75, 40);
            treesHitBoxList.Add(treeHitBox1);
            Rectangle treeHitBox2 = new Rectangle(200, 95, 75, 40);
            treesHitBoxList.Add(treeHitBox2);
            Rectangle treeHitBox3 = new Rectangle(500, 75, 75, 40);
            treesHitBoxList.Add(treeHitBox3);
            Rectangle treeHitBox4 = new Rectangle(700, 85, 75, 40);
            treesHitBoxList.Add(treeHitBox4);
            Rectangle treeHitBox5 = new Rectangle(100, 410, 75, 40);
            treesHitBoxList.Add(treeHitBox5);
            Rectangle treeHitBox6 = new Rectangle(300, 260, 75, 40);
            treesHitBoxList.Add(treeHitBox6);
            Rectangle treeHitBox7 = new Rectangle(600, 430, 75, 40);
            treesHitBoxList.Add(treeHitBox7);
            Rectangle treeHitBox8 = new Rectangle(450, 380, 75, 40);
            treesHitBoxList.Add(treeHitBox8);
            Rectangle treeHitBox9 = new Rectangle(80, 250, 75, 40);
            treesHitBoxList.Add(treeHitBox9);
        }

        private void obstacleSpawn()
        {
            Rectangle tree1 = new Rectangle(30, 50, 75, 100);
            treesList.Add(tree1);
            Rectangle tree2 = new Rectangle(200, 35, 75, 100);
            treesList.Add(tree2);
            Rectangle tree3 = new Rectangle(500, 15, 75, 100);
            treesList.Add(tree3);
            Rectangle tree4 = new Rectangle(700, 25, 75, 100);
            treesList.Add(tree4);
            Rectangle tree5 = new Rectangle(100, 350, 75, 100);
            treesList.Add(tree5);
            Rectangle tree6 = new Rectangle(300, 200, 75, 100);
            treesList.Add(tree6);
            Rectangle tree7 = new Rectangle(600, 370, 75, 100);
            treesList.Add(tree7);
            Rectangle tree8 = new Rectangle(450, 320, 75, 100);
            treesList.Add(tree8);
            Rectangle tree9 = new Rectangle(80, 190, 75, 100);
            treesList.Add(tree9);

            for (int i = 0; i < treesList.Count; i++)
            {
                if (i % 3 == 0)
                {
                    treeImgList.Add(Properties.Resources.tree1);
                }

                else if (i % 3 == 1)
                {
                    treeImgList.Add(Properties.Resources.tree2);
                }

                else
                {
                    treeImgList.Add(Properties.Resources.tree3);
                }
            }
        }
        private void obstacleCollision()
        {
            if (gameState == "Main Screen")
            {
                for (int i = 0; i < treesHitBoxList.Count; i++)
                {
                    if (player1.IntersectsWith(treesHitBoxList[i]))
                    {
                        if (wPressed == true)
                        {
                            player1.Y += player1Speed;
                        }
                        if (sPressed == true)
                        {
                            player1.Y -= player1Speed;
                        }
                        if (aPressed == true)
                        {
                            player1.X += player1Speed;
                        }
                        if (dPressed == true)
                        {
                            player1.X -= player1Speed;
                        }
                    }
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Form1.ChangeScreen(this, new BattleScreen());

            InitializePokemonChoosingScreen();
            gameState = "Choosing Screen";
            startButton.Visible = false;
            exitButton.Visible = false;
        }

        private void pikachu_Click(object sender, EventArgs e)
        {
            pokemonPreview.Image = pokemonsList[0];
        }

        private void charmander_Click(object sender, EventArgs e)
        {
            pokemonPreview.Image = pokemonsList[2];
        }

        private void bulbasaur_Click(object sender, EventArgs e)
        {
            pokemonPreview.Image = pokemonsList[3];
        }

        private void squirtle_Click(object sender, EventArgs e)
        {
            pokemonPreview.Image = pokemonsList[1];
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            InitializeMainScreen();
            InitializeGameScreen();
            gameLoop.Enabled = true;
            chestSpawn();

            playerName = playerNameInput.Text;
            if (pokemonPreview.Image == pokemonsList[0])
            {
                actualPokemon = "Pikachu";
                playerPokemon = pokemonsList[0];
            }
            else if (pokemonPreview.Image == pokemonsList[1])
            {
                actualPokemon = "Squirtle";
                playerPokemon = pokemonsList[1];
            }
            else if (pokemonPreview.Image == pokemonsList[2])
            {
                actualPokemon = "Charmander";
                playerPokemon = pokemonsList[2];

            }
            else if (pokemonPreview.Image == pokemonsList[3])
            {
                actualPokemon = "Bulbasaur";
                playerPokemon = pokemonsList[3];

            }
            this.Focus();
        }

        public void InitializeGameScreen()
        {
            evolveButton.Visible = false;
            exitEvolve.Visible = false;
            resultBattleLabel.Visible = false;

            pikachu.Visible = false;
            squirtle.Visible = false;
            charmander.Visible = false;
            bulbasaur.Visible = false;
            playerPreview.Visible = false;
            pokemonPreview.Visible = false;
            continueButton.Visible = false;
            characterLabel.Visible = false;
            playerNameInput.Visible = false;
            attackButton.Visible = false;
            healButton.Visible = false;
            spAttackButton.Visible = false;
            battleBoss.Visible = false;
            battlePokemon.Visible = false;
        }

        public void InitializeMainScreen()
        {



            attackButton.Visible = false;
            attackButton.Enabled = false;
            healButton.Visible = false;
            healButton.Enabled = false;
            spAttackButton.Visible = false;
            spAttackButton.Enabled = false;

            battleBoss.Visible = false;
            battlePokemon.Visible = false;
            pokemonHealthLabel.Visible = false;
            bossHealthLabel.Visible = false;

            gameState = "Main Screen";

            this.BackgroundImage = Properties.Resources.bg;
            obstacleSpawn();
            doorCollision();
            obstacleHitBoxSpawn();
            chestSpawn();

            gameLoop.Enabled = true;
            this.Focus();
        }
    
        public void InitializeEvolveScreen()
        {
            gameState = "Evolve Screen";
            evolveButton.Visible = true;
            exitEvolve.Visible = true;
        }

        public void InitializePokemonChoosingScreen()
        {
            startButton.Visible = false;
            exitButton.Visible = false;
            titleLabel.Visible = false;

            pikachu.Visible = true;
            squirtle.Visible = true;
            charmander.Visible = true;
            bulbasaur.Visible = true;
            playerPreview.Visible = true;
            pokemonPreview.Visible = true;
            continueButton.Visible = true;
            characterLabel.Visible = true;
            playerNameInput.Visible = true;
        }

        private void chestSpawn()
        {
            if (gameState == "Main Screen")
            {
                Rectangle chest1 = new Rectangle(20, 50, 30, 20);
                chestList.Add(chest1);
                Rectangle chest2 = new Rectangle(150, 90, 30, 20);
                chestList.Add(chest2);
                Rectangle chest3 = new Rectangle(400, 100, 30, 20);
                chestList.Add(chest3);
                Rectangle chest4 = new Rectangle(670, 100, 30, 20);
                chestList.Add(chest4);
                Rectangle chest5 = new Rectangle(100, 300, 30, 20);
                chestList.Add(chest5);
                Rectangle chest6 = new Rectangle(100, 150, 30, 20);
                chestList.Add(chest6);
                Rectangle chest7 = new Rectangle(250, 300, 30, 20);
                chestList.Add(chest7);
                Rectangle chest8 = new Rectangle(400, 300, 30, 20);
                chestList.Add(chest8);
                Rectangle chest9 = new Rectangle(700, 300, 30, 20);
                chestList.Add(chest9);
                Rectangle chest10 = new Rectangle(20, 400, 30, 20);
                chestList.Add(chest10);
                Rectangle chest11 = new Rectangle(350, 400, 30, 20);
                chestList.Add(chest11);
                Rectangle chest12 = new Rectangle(500, 430, 30, 20);
                chestList.Add(chest12);
                Rectangle chest13 = new Rectangle(700, 400, 30, 20);
                chestList.Add(chest13);
            }
        }
        private void chestCollision()
        {
            int chestRand = randGen.Next(0, chestList.Count);
            int loot = randGen.Next(1, 500);

            if (gameState == "Main Screen" && player1.IntersectsWith(actualChest))
            {
                actualChest.X = chestList[chestRand].X;
                actualChest.Y = chestList[chestRand].Y;
                playerMoney += loot;
            }
        }
        private void doorCollision()
        {
            if (gameState == "Main Screen" && player1.IntersectsWith(door))
            {
                gameState = "House Interior";
                player1.X = 317;
                player1.Y = 380;

            }

            for (int i = 0; i < treesList.Count(); i++)
            {
                if (gameState == "House Interior" || gameState == "Arena Screen")
                {
                    treesList.RemoveAt(i);
                    treesHitBoxList.RemoveAt(i);
                }
            }

            for (int i = 0; i < chestList.Count(); i++)
            {
                if (gameState == "House Interior" || gameState == "Arena Screen")
                {
                    chestList.RemoveAt(i);
                }
            }

            if (gameState == "House Interior" && player1.IntersectsWith(exitDoor))
            {
                player1.X = door.X + 10;
                player1.Y = door.Y + 10;
                InitializeMainScreen();
            }

            if (gameState == "House Interior" && player1.IntersectsWith(vendingMachine))
            {
                gameState = "Evolve Screen";
                InitializeEvolveScreen();
            }
        }

        private void houseCollision()
        {
            if (gameState == "Main Screen" && player1.IntersectsWith(houseWall))
            {
                if (wPressed == true)
                {
                    player1.Y += player1Speed;
                }
                if (sPressed == true)
                {
                    player1.Y -= player1Speed;
                }
                if (aPressed == true)
                {
                    player1.X += player1Speed;
                }
                if (dPressed == true)
                {
                    player1.X -= player1Speed;
                }
            }
        }
        private void InteriorCollision()
        {
            if (gameState == "House Interior" && player1.IntersectsWith(houseWallInterior1))
            {
                if (aPressed == true)
                {
                    player1.X += player1Speed;
                }
            }
            if (gameState == "House Interior" && player1.IntersectsWith(houseWallInterior2))
            {
                if (wPressed == true)
                {
                    player1.Y += player1Speed;
                }
            }
            if (gameState == "House Interior" && player1.IntersectsWith(houseWallInterior3))
            {
                if (dPressed == true)
                {
                    player1.X -= player1Speed;
                }
            }
            if (gameState == "House Interior" && player1.IntersectsWith(houseWallInterior4))
            {
                if (sPressed == true)
                {
                    player1.Y -= player1Speed;
                }
            }
            if (gameState == "House Interior" && player1.IntersectsWith(houseWallInterior5))
            {
                if (sPressed == true)
                {
                    player1.Y -= player1Speed;
                }
            }

        }

        private void evolveButton_Click(object sender, EventArgs e)
        {
            if (gameState == "Evolve Screen")
            {
                if (playerMoney > moneyRequired[i])
                {
                    pokemonLv++;
                    pokemonHealth += 120;
                    pokemonAtk += 200;
                    pokemonSpAtk += 200;
                    pokemonHeal += 180;
                    playerMoney -= moneyRequired[i];

                    i++;
                }
                else
                {
                    evolveButton.Enabled = false;
                }
            }
        }
        private void exitEvolve_Click(object sender, EventArgs e)
        {
            gameState = "House Interior";
            player1.Y = vendingMachine.Y + 80;
            evolveButton.Visible = false;
            exitEvolve.Visible = false;
            this.Focus();
        }
        private void arenaEnterCollision()
        {
            if (gameState == "Arena Screen" && player1.IntersectsWith(enterArena))
            {
                gameState = "Battle Screen";
                InitializeBattleScreen();
            }
        }

        private void InitializeBattleScreen()
        {
            gameState = "Battle Screen";
            battlePokemon.Image = playerPokemon;
            battleBoss.Image = boss1;
            pokemonHealthLabel.Text = $"{pokemonHealth}";
            bossHealthLabel.Text= $"{bossHealth}";

            this.BackgroundImage = Properties.Resources.forest;

            attackButton.Visible = true;
            healButton.Visible = true;
            spAttackButton.Visible = true;

            battlePokemon.Visible = true;
            battleBoss.Visible = true;

            attackButton.Enabled = true;
            healButton.Enabled = true;
            spAttackButton.Enabled = true;
            pokemonHealthLabel.Visible = true;
            bossHealthLabel.Visible = true;
            switch (bossCounter)
            {
                case 1:
                    bossHealth = 1000;
                    bossAtk = 320;
                    bossSpAtk = 500;
                    bossHeal = 600;
                    break;
                case 2:
                    bossHealth = 2000;
                    bossAtk = 400;
                    bossSpAtk = 600;
                    bossHeal = 800;
                    break;
                case 3:
                    bossHealth = 2500;
                    bossAtk = 700;
                    bossSpAtk = 900;
                    bossHeal = 900;
                    break;
            }
        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            playerChoice = "Normal Attack";
            playerTurn();
        }

        
        private void healButton_Click(object sender, EventArgs e)
        {
            playerChoice = "Heal";
            playerTurn();
        }

        private void spAttackButton_Click(object sender, EventArgs e)
        {
            if (!playerSpAttackOnCooldown)
            {
                playerChoice = "Special Attack";
                playerSpAttackOnCooldown = true;
                playerTurnCount = 0;  // Reset cooldown counter for player
                playerTurn();
            }
            else
            {
               // MessageBox.Show("Special Attack is on cooldown!");
            }
        }
        private void playerTurn()
        {
            playerFightingResult();
            Refresh();
            checkWinCondition();
            cpuTurn();
        }
        private void cpuTurn()
        {
            computerChoice();
            computerFightingResult();
            Refresh();
            checkWinCondition();

            // Update cooldown counters
            playerTurnCount++;
            cpuTurnCount++;

            // Reset cooldown if enough turns have passed
            if (playerTurnCount >= 3)
            {
                playerSpAttackOnCooldown = false;
            }
            if (cpuTurnCount >= 3)
            {
                cpuSpAttackOnCooldown = false;
            }
        }

        public void computerChoice()
        {
            int randValue = randGen.Next(1, 60);
            if (cpuSpAttackOnCooldown && randValue < 60)
            {
                cpuChoice = "Normal Attack";
            }
            else if (cpuSpAttackOnCooldown && randValue < 90)
            {
                cpuChoice = "Heal";
            }
            else if (!cpuSpAttackOnCooldown && randValue < 30)
            {
                cpuChoice = "Heal";
            }
            else if (!cpuSpAttackOnCooldown && randValue < 90)
            {
                cpuChoice = "Special Attack";
                cpuSpAttackOnCooldown = true;
                cpuTurnCount = 0;  // Reset cooldown counter for CPU
            }
            else
            {
                cpuChoice = "Normal Attack";
            }
            Thread.Sleep(choicePause);
        }

        public void playerFightingResult()
        {
            if (playerChoice == "Heal")
            {
                pokemonHealth += pokemonHeal;
            }
            else if (playerChoice == "Normal Attack")
            {
                bossHealth -= pokemonAtk;
            }
            else if (playerChoice == "Special Attack")
            {
                bossHealth -= pokemonSpAtk;
            }
            pokemonHealthLabel.Text = $"{pokemonHealth}";
            bossHealthLabel.Text = $"{bossHealth}";
            Thread.Sleep(outcomePause);
        }

        public void computerFightingResult()
        {
            if (cpuChoice == "Heal")
            {
                bossHealth += bossHeal;
            }
            else if (cpuChoice == "Normal Attack")
            {
                pokemonHealth -= bossAtk;
            }
            else if (cpuChoice == "Special Attack")
            {
                pokemonHealth -= bossSpAtk;
            }
            pokemonHealthLabel.Text = $"{pokemonHealth}";
            bossHealthLabel.Text = $"{bossHealth}";
            Thread.Sleep(outcomePause);
        }
        public void InitializeEndScreen()
        {
            bossHealthLabel.Visible = false;
            pokemonHealthLabel.Visible = false;

            attackButton.Visible = false;
            attackButton.Enabled = false;
            healButton.Visible = false;
            healButton.Enabled = false;
            spAttackButton.Visible = false;
            spAttackButton.Enabled = false;

            battleBoss.Visible = false;
            battlePokemon.Location = new Point (this.Width / 2, this.Height / 2);
            gameState = "End Screen";
        }
        private void checkWinCondition()
        {
            if (gameState == "Battle Screen" && pokemonHealth <= 0)
            {
                pokemonHealth = 0;
                pokemonHealthLabel.Text = "0";
                resultBattleLabel.Text = "You Loss";
                gameLoop.Enabled = false;
                InitializeMainScreen();
            }

            if (gameState == "Battle Screen" && bossHealth <= 0 && bossCounter == 1)
            {
                bossHealth = 0;
                bossHealthLabel.Text = "0";
                resultBattleLabel.Text = "Next Boss";
                bossCounter++;
                InitializeBattleScreen();
            }

            if (gameState == "Battle Screen" && bossHealth <= 0 && bossCounter == 2)
            {
                bossHealth = 0;
                bossHealthLabel.Text = "0";
                battleBoss.Image = boss2;
                resultBattleLabel.Text = "Next Boss";
                bossCounter++;
                InitializeBattleScreen();

            }

            if (gameState == "Battle Screen" && bossHealth <= 0 && bossCounter == 3)
            {
                bossHealth = 0;
                bossHealthLabel.Text = "0";
                battleBoss.Image = boss3;
                resultBattleLabel.Text = "You Win";
                gameLoop.Enabled = false;
                InitializeEndScreen();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "Start Screen")
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawImage(forrestImg, grass);
                titleLabel.Image = Properties.Resources.Pokemon_Sign;
            }
            else if (gameState == "Choosing Screen")
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawImage(forrestImg, grass);
            }
            else if (gameState == "Main Screen")
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawImage(grassImg, grass);
                
                e.Graphics.DrawImage(GetCurrentDirectionImages()[player1FrameIndex], player1);

                for (int i = 0; i < treesList.Count; i++)
                {
                    e.Graphics.DrawImage(treeImgList[i], treesList[i]);
                }

                e.Graphics.DrawImage(chestImg, actualChest);

                e.Graphics.DrawImage(playerHouse, house);
                e.Graphics.DrawString($"{playerName}  LV:{pokemonLv}\nCoins:{playerMoney}", drawFont, blackBrush, 20, 30);
                e.Graphics.DrawString($"{sPressed}", drawFont, blackBrush, 20, 60);
            }

            else if (gameState == "Arena Screen")
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawImage(grassImg, grass);
                e.Graphics.DrawImage(GetCurrentDirectionImages()[player1FrameIndex], player1);
                e.Graphics.DrawImage(plantArena, grassArena);
                e.Graphics.DrawString($"LV:{pokemonLv}\nCoins:{playerMoney}", drawFont, blackBrush, 20, 30);
            }

            else if (gameState == "House Interior")
            {
                e.Graphics.Clear(Color.Black);
                e.Graphics.DrawImage(HouseInteriorImg, houseInterior);
                e.Graphics.DrawImage(GetCurrentDirectionImages()[player1FrameIndex], player1);
                e.Graphics.DrawString($"Coins:{playerMoney}", drawFont, blackBrush, 20, 30);
                e.Graphics.DrawImage(vendingMachineImg, vendingMachine);
            }
            else if (gameState == "Evolve Screen")
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawImage(evolveScreenBg, 0, 0, 800, 500);
                e.Graphics.DrawImage(UpgradeStatsBg, statsBg);
                e.Graphics.DrawString($"{pokemonHealth}", drawFont, blackBrush, 670, 106);
                e.Graphics.DrawString($"{pokemonAtk}", drawFont, blackBrush, 670, 145);
                e.Graphics.DrawString($"{pokemonHeal}", drawFont, blackBrush, 670, 180);
                e.Graphics.DrawString($"{pokemonSpAtk}", drawFont, blackBrush, 670, 218);
                e.Graphics.DrawString($"${playerMoney}", drawFont, blackBrush, 670, 50);
                e.Graphics.DrawString($"Lvl:{pokemonLv}", drawFont, blackBrush, 505, 50);
                e.Graphics.DrawString($"{actualPokemon}", drawFont, blackBrush, 120, 50);
                e.Graphics.DrawString($"${moneyRequired[i]}", drawFont, blackBrush, 550, 283);
                e.Graphics.DrawString("Cost Per Evolution: ", drawFont, blackBrush, 100, 283);
                e.Graphics.DrawImage(playerPokemon, pokemonPicEvolve);

                if (playerMoney < moneyRequired[i])
                {
                    e.Graphics.DrawString($"${moneyRequired[i]}", drawFont, redBrush, 550, 283);
                }
                else
                {
                    evolveButton.Enabled = true;
                }
            }
            else if(gameState == "End Screen")
            {
                e.Graphics.DrawImage(winImg, grass);
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            PlayerMovement();
            doorCollision();
            obstacleCollision();
            houseCollision();
            InteriorCollision();
            chestCollision();
            arenaEnterCollision();
            checkWinCondition();
            Refresh();
        }
    }
}

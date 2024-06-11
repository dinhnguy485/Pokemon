namespace Pokemon
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.exitEvolve = new System.Windows.Forms.Button();
            this.evolveButton = new System.Windows.Forms.Button();
            this.playerNameInput = new System.Windows.Forms.TextBox();
            this.characterLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.battlePokemon = new System.Windows.Forms.Label();
            this.battleBoss = new System.Windows.Forms.Label();
            this.battleTimer = new System.Windows.Forms.Timer(this.components);
            this.pokemonHealthLabel = new System.Windows.Forms.Label();
            this.bossHealthLabel = new System.Windows.Forms.Label();
            this.spAttackButton = new System.Windows.Forms.Button();
            this.healButton = new System.Windows.Forms.Button();
            this.attackButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.pokemonPreview = new System.Windows.Forms.PictureBox();
            this.playerPreview = new System.Windows.Forms.PictureBox();
            this.squirtle = new System.Windows.Forms.Button();
            this.bulbasaur = new System.Windows.Forms.Button();
            this.charmander = new System.Windows.Forms.Button();
            this.pikachu = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.resultBattleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 30;
            // 
            // exitEvolve
            // 
            this.exitEvolve.Image = global::Pokemon.Properties.Resources.exitButton;
            this.exitEvolve.Location = new System.Drawing.Point(173, 431);
            this.exitEvolve.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitEvolve.Name = "exitEvolve";
            this.exitEvolve.Size = new System.Drawing.Size(136, 44);
            this.exitEvolve.TabIndex = 41;
            this.exitEvolve.UseVisualStyleBackColor = true;
            this.exitEvolve.Click += new System.EventHandler(this.exitEvolve_Click);
            // 
            // evolveButton
            // 
            this.evolveButton.Image = global::Pokemon.Properties.Resources.evolveButton;
            this.evolveButton.Location = new System.Drawing.Point(852, 377);
            this.evolveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.evolveButton.Name = "evolveButton";
            this.evolveButton.Size = new System.Drawing.Size(141, 44);
            this.evolveButton.TabIndex = 40;
            this.evolveButton.UseVisualStyleBackColor = true;
            this.evolveButton.Click += new System.EventHandler(this.evolveButton_Click);
            // 
            // playerNameInput
            // 
            this.playerNameInput.Location = new System.Drawing.Point(108, 482);
            this.playerNameInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playerNameInput.Name = "playerNameInput";
            this.playerNameInput.Size = new System.Drawing.Size(132, 22);
            this.playerNameInput.TabIndex = 37;
            // 
            // characterLabel
            // 
            this.characterLabel.BackColor = System.Drawing.Color.Transparent;
            this.characterLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterLabel.Location = new System.Drawing.Point(28, 298);
            this.characterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.characterLabel.Name = "characterLabel";
            this.characterLabel.Size = new System.Drawing.Size(451, 41);
            this.characterLabel.TabIndex = 35;
            this.characterLabel.Text = "Enter a Name for your Character:";
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Location = new System.Drawing.Point(307, 31);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(427, 161);
            this.titleLabel.TabIndex = 28;
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 16;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // battlePokemon
            // 
            this.battlePokemon.BackColor = System.Drawing.Color.Transparent;
            this.battlePokemon.Location = new System.Drawing.Point(8, 283);
            this.battlePokemon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.battlePokemon.Name = "battlePokemon";
            this.battlePokemon.Size = new System.Drawing.Size(263, 235);
            this.battlePokemon.TabIndex = 46;
            // 
            // battleBoss
            // 
            this.battleBoss.BackColor = System.Drawing.Color.Transparent;
            this.battleBoss.Location = new System.Drawing.Point(769, 102);
            this.battleBoss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.battleBoss.Name = "battleBoss";
            this.battleBoss.Size = new System.Drawing.Size(263, 235);
            this.battleBoss.TabIndex = 45;
            // 
            // battleTimer
            // 
            this.battleTimer.Enabled = true;
            this.battleTimer.Interval = 20;
            // 
            // pokemonHealthLabel
            // 
            this.pokemonHealthLabel.AutoSize = true;
            this.pokemonHealthLabel.BackColor = System.Drawing.Color.Transparent;
            this.pokemonHealthLabel.Location = new System.Drawing.Point(280, 465);
            this.pokemonHealthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pokemonHealthLabel.Name = "pokemonHealthLabel";
            this.pokemonHealthLabel.Size = new System.Drawing.Size(0, 16);
            this.pokemonHealthLabel.TabIndex = 47;
            // 
            // bossHealthLabel
            // 
            this.bossHealthLabel.AutoSize = true;
            this.bossHealthLabel.BackColor = System.Drawing.Color.Transparent;
            this.bossHealthLabel.Location = new System.Drawing.Point(820, 137);
            this.bossHealthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bossHealthLabel.Name = "bossHealthLabel";
            this.bossHealthLabel.Size = new System.Drawing.Size(0, 16);
            this.bossHealthLabel.TabIndex = 48;
            // 
            // spAttackButton
            // 
            this.spAttackButton.Image = ((System.Drawing.Image)(resources.GetObject("spAttackButton.Image")));
            this.spAttackButton.Location = new System.Drawing.Point(887, 427);
            this.spAttackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spAttackButton.Name = "spAttackButton";
            this.spAttackButton.Size = new System.Drawing.Size(177, 91);
            this.spAttackButton.TabIndex = 44;
            this.spAttackButton.UseVisualStyleBackColor = true;
            this.spAttackButton.Click += new System.EventHandler(this.spAttackButton_Click);
            // 
            // healButton
            // 
            this.healButton.Image = ((System.Drawing.Image)(resources.GetObject("healButton.Image")));
            this.healButton.Location = new System.Drawing.Point(680, 427);
            this.healButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.healButton.Name = "healButton";
            this.healButton.Size = new System.Drawing.Size(188, 91);
            this.healButton.TabIndex = 43;
            this.healButton.UseVisualStyleBackColor = true;
            this.healButton.Click += new System.EventHandler(this.healButton_Click);
            // 
            // attackButton
            // 
            this.attackButton.Image = ((System.Drawing.Image)(resources.GetObject("attackButton.Image")));
            this.attackButton.Location = new System.Drawing.Point(499, 427);
            this.attackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(176, 91);
            this.attackButton.TabIndex = 42;
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Click += new System.EventHandler(this.attackButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Image = ((System.Drawing.Image)(resources.GetObject("continueButton.Image")));
            this.continueButton.Location = new System.Drawing.Point(96, 532);
            this.continueButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(169, 41);
            this.continueButton.TabIndex = 39;
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // pokemonPreview
            // 
            this.pokemonPreview.Location = new System.Drawing.Point(720, 298);
            this.pokemonPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pokemonPreview.Name = "pokemonPreview";
            this.pokemonPreview.Size = new System.Drawing.Size(304, 262);
            this.pokemonPreview.TabIndex = 38;
            this.pokemonPreview.TabStop = false;
            // 
            // playerPreview
            // 
            this.playerPreview.BackColor = System.Drawing.Color.Transparent;
            this.playerPreview.Image = ((System.Drawing.Image)(resources.GetObject("playerPreview.Image")));
            this.playerPreview.Location = new System.Drawing.Point(131, 342);
            this.playerPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playerPreview.Name = "playerPreview";
            this.playerPreview.Size = new System.Drawing.Size(92, 133);
            this.playerPreview.TabIndex = 36;
            this.playerPreview.TabStop = false;
            // 
            // squirtle
            // 
            this.squirtle.BackColor = System.Drawing.Color.YellowGreen;
            this.squirtle.Image = ((System.Drawing.Image)(resources.GetObject("squirtle.Image")));
            this.squirtle.Location = new System.Drawing.Point(815, 34);
            this.squirtle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.squirtle.Name = "squirtle";
            this.squirtle.Size = new System.Drawing.Size(232, 241);
            this.squirtle.TabIndex = 34;
            this.squirtle.UseVisualStyleBackColor = false;
            this.squirtle.Click += new System.EventHandler(this.squirtle_Click);
            // 
            // bulbasaur
            // 
            this.bulbasaur.BackColor = System.Drawing.Color.YellowGreen;
            this.bulbasaur.Image = ((System.Drawing.Image)(resources.GetObject("bulbasaur.Image")));
            this.bulbasaur.Location = new System.Drawing.Point(556, 34);
            this.bulbasaur.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bulbasaur.Name = "bulbasaur";
            this.bulbasaur.Size = new System.Drawing.Size(232, 241);
            this.bulbasaur.TabIndex = 33;
            this.bulbasaur.UseVisualStyleBackColor = false;
            this.bulbasaur.Click += new System.EventHandler(this.bulbasaur_Click);
            // 
            // charmander
            // 
            this.charmander.BackColor = System.Drawing.Color.YellowGreen;
            this.charmander.Image = ((System.Drawing.Image)(resources.GetObject("charmander.Image")));
            this.charmander.Location = new System.Drawing.Point(296, 34);
            this.charmander.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.charmander.Name = "charmander";
            this.charmander.Size = new System.Drawing.Size(232, 241);
            this.charmander.TabIndex = 32;
            this.charmander.UseVisualStyleBackColor = false;
            this.charmander.Click += new System.EventHandler(this.charmander_Click);
            // 
            // pikachu
            // 
            this.pikachu.BackColor = System.Drawing.Color.YellowGreen;
            this.pikachu.Image = ((System.Drawing.Image)(resources.GetObject("pikachu.Image")));
            this.pikachu.Location = new System.Drawing.Point(33, 34);
            this.pikachu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pikachu.Name = "pikachu";
            this.pikachu.Size = new System.Drawing.Size(232, 241);
            this.pikachu.TabIndex = 31;
            this.pikachu.UseVisualStyleBackColor = false;
            this.pikachu.Click += new System.EventHandler(this.pikachu_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.OrangeRed;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.Location = new System.Drawing.Point(424, 468);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(204, 92);
            this.exitButton.TabIndex = 30;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.YellowGreen;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.startButton.Location = new System.Drawing.Point(403, 283);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(245, 140);
            this.startButton.TabIndex = 29;
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resultBattleLabel
            // 
            this.resultBattleLabel.AutoSize = true;
            this.resultBattleLabel.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultBattleLabel.Location = new System.Drawing.Point(403, 283);
            this.resultBattleLabel.Name = "resultBattleLabel";
            this.resultBattleLabel.Size = new System.Drawing.Size(0, 31);
            this.resultBattleLabel.TabIndex = 49;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 567);
            this.Controls.Add(this.resultBattleLabel);
            this.Controls.Add(this.bossHealthLabel);
            this.Controls.Add(this.battlePokemon);
            this.Controls.Add(this.battleBoss);
            this.Controls.Add(this.spAttackButton);
            this.Controls.Add(this.healButton);
            this.Controls.Add(this.attackButton);
            this.Controls.Add(this.pokemonHealthLabel);
            this.Controls.Add(this.exitEvolve);
            this.Controls.Add(this.evolveButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.pokemonPreview);
            this.Controls.Add(this.playerNameInput);
            this.Controls.Add(this.playerPreview);
            this.Controls.Add(this.characterLabel);
            this.Controls.Add(this.squirtle);
            this.Controls.Add(this.bulbasaur);
            this.Controls.Add(this.charmander);
            this.Controls.Add(this.pikachu);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button exitEvolve;
        private System.Windows.Forms.Button evolveButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.PictureBox pokemonPreview;
        private System.Windows.Forms.TextBox playerNameInput;
        private System.Windows.Forms.PictureBox playerPreview;
        private System.Windows.Forms.Label characterLabel;
        private System.Windows.Forms.Button squirtle;
        private System.Windows.Forms.Button bulbasaur;
        private System.Windows.Forms.Button charmander;
        private System.Windows.Forms.Button pikachu;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label battlePokemon;
        private System.Windows.Forms.Label battleBoss;
        private System.Windows.Forms.Button spAttackButton;
        private System.Windows.Forms.Button healButton;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.Timer battleTimer;
        private System.Windows.Forms.Label pokemonHealthLabel;
        private System.Windows.Forms.Label bossHealthLabel;
        private System.Windows.Forms.Label resultBattleLabel;
    }
}


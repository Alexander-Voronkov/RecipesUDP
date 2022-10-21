namespace RecipesServer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Connected_users = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddRecipeBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AddIngrBtn = new System.Windows.Forms.Button();
            this.DeleteIngrBtn = new System.Windows.Forms.Button();
            this.Ingredients = new System.Windows.Forms.ListBox();
            this.RecipesListBox = new System.Windows.Forms.ListBox();
            this.DeleteRecipeBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(84, 50);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(153, 20);
            this.IPTextBox.TabIndex = 0;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(84, 85);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(153, 20);
            this.PortTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start receive";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Connected_users
            // 
            this.Connected_users.Enabled = false;
            this.Connected_users.FormattingEnabled = true;
            this.Connected_users.Location = new System.Drawing.Point(370, 19);
            this.Connected_users.Name = "Connected_users";
            this.Connected_users.Size = new System.Drawing.Size(338, 147);
            this.Connected_users.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IPTextBox);
            this.groupBox1.Controls.Add(this.PortTextBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 154);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // AddRecipeBtn
            // 
            this.AddRecipeBtn.Location = new System.Drawing.Point(172, 181);
            this.AddRecipeBtn.Name = "AddRecipeBtn";
            this.AddRecipeBtn.Size = new System.Drawing.Size(164, 27);
            this.AddRecipeBtn.TabIndex = 6;
            this.AddRecipeBtn.Text = "Add new recipe";
            this.AddRecipeBtn.UseVisualStyleBackColor = true;
            this.AddRecipeBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AddIngrBtn);
            this.groupBox4.Controls.Add(this.DeleteIngrBtn);
            this.groupBox4.Controls.Add(this.Ingredients);
            this.groupBox4.Controls.Add(this.AddRecipeBtn);
            this.groupBox4.Controls.Add(this.RecipesListBox);
            this.groupBox4.Controls.Add(this.DeleteRecipeBtn);
            this.groupBox4.Location = new System.Drawing.Point(12, 178);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(695, 214);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Current recipes";
            // 
            // AddIngrBtn
            // 
            this.AddIngrBtn.Location = new System.Drawing.Point(356, 181);
            this.AddIngrBtn.Name = "AddIngrBtn";
            this.AddIngrBtn.Size = new System.Drawing.Size(159, 27);
            this.AddIngrBtn.TabIndex = 11;
            this.AddIngrBtn.Text = "Add new ingredient";
            this.AddIngrBtn.UseVisualStyleBackColor = true;
            this.AddIngrBtn.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // DeleteIngrBtn
            // 
            this.DeleteIngrBtn.Location = new System.Drawing.Point(521, 181);
            this.DeleteIngrBtn.Name = "DeleteIngrBtn";
            this.DeleteIngrBtn.Size = new System.Drawing.Size(168, 27);
            this.DeleteIngrBtn.TabIndex = 10;
            this.DeleteIngrBtn.Text = "Delete selected ingredient";
            this.DeleteIngrBtn.UseVisualStyleBackColor = true;
            this.DeleteIngrBtn.Click += new System.EventHandler(this.DeleteIngrBtn_Click);
            // 
            // Ingredients
            // 
            this.Ingredients.FormattingEnabled = true;
            this.Ingredients.Location = new System.Drawing.Point(356, 32);
            this.Ingredients.Name = "Ingredients";
            this.Ingredients.Size = new System.Drawing.Size(333, 134);
            this.Ingredients.TabIndex = 9;
            // 
            // RecipesListBox
            // 
            this.RecipesListBox.FormattingEnabled = true;
            this.RecipesListBox.Location = new System.Drawing.Point(9, 32);
            this.RecipesListBox.Name = "RecipesListBox";
            this.RecipesListBox.Size = new System.Drawing.Size(326, 134);
            this.RecipesListBox.TabIndex = 8;
            this.RecipesListBox.SelectedIndexChanged += new System.EventHandler(this.RecipesListBox_SelectedIndexChanged);
            // 
            // DeleteRecipeBtn
            // 
            this.DeleteRecipeBtn.Location = new System.Drawing.Point(10, 181);
            this.DeleteRecipeBtn.Name = "DeleteRecipeBtn";
            this.DeleteRecipeBtn.Size = new System.Drawing.Size(155, 27);
            this.DeleteRecipeBtn.TabIndex = 7;
            this.DeleteRecipeBtn.Text = "Delete selected recipe";
            this.DeleteRecipeBtn.UseVisualStyleBackColor = true;
            this.DeleteRecipeBtn.Click += new System.EventHandler(this.DeleteRecipeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 419);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Connected_users);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "RecipesServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox Connected_users;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddRecipeBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button DeleteIngrBtn;
        private System.Windows.Forms.ListBox Ingredients;
        private System.Windows.Forms.ListBox RecipesListBox;
        private System.Windows.Forms.Button DeleteRecipeBtn;
        private System.Windows.Forms.Button AddIngrBtn;
    }
}


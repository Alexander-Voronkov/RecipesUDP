namespace RecipesServer
{
    partial class AddRecipe
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
            this.button1 = new System.Windows.Forms.Button();
            this.RecipeNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IngredientList = new System.Windows.Forms.ListBox();
            this.IngredientNameTB = new System.Windows.Forms.TextBox();
            this.IngredientWeightTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deletebtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecipeNameTB
            // 
            this.RecipeNameTB.Location = new System.Drawing.Point(105, 15);
            this.RecipeNameTB.Name = "RecipeNameTB";
            this.RecipeNameTB.Size = new System.Drawing.Size(197, 20);
            this.RecipeNameTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recipe name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ingredient name";
            // 
            // IngredientList
            // 
            this.IngredientList.FormattingEnabled = true;
            this.IngredientList.Location = new System.Drawing.Point(9, 22);
            this.IngredientList.Name = "IngredientList";
            this.IngredientList.Size = new System.Drawing.Size(272, 69);
            this.IngredientList.TabIndex = 5;
            // 
            // IngredientNameTB
            // 
            this.IngredientNameTB.Location = new System.Drawing.Point(138, 103);
            this.IngredientNameTB.Name = "IngredientNameTB";
            this.IngredientNameTB.Size = new System.Drawing.Size(114, 20);
            this.IngredientNameTB.TabIndex = 6;
            // 
            // IngredientWeightTB
            // 
            this.IngredientWeightTB.Location = new System.Drawing.Point(138, 131);
            this.IngredientWeightTB.Name = "IngredientWeightTB";
            this.IngredientWeightTB.Size = new System.Drawing.Size(114, 20);
            this.IngredientWeightTB.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ingredient weight";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deletebtn);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.IngredientWeightTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.IngredientNameTB);
            this.groupBox1.Controls.Add(this.IngredientList);
            this.groupBox1.Location = new System.Drawing.Point(15, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 189);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingredients";
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(152, 160);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(48, 23);
            this.deletebtn.TabIndex = 11;
            this.deletebtn.Text = "Delete";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(290, 25);
            this.button3.TabIndex = 10;
            this.button3.Text = "Add picture";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 309);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RecipeNameTB);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddRecipe";
            this.Text = "AddRecipe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox RecipeNameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox IngredientList;
        private System.Windows.Forms.TextBox IngredientNameTB;
        private System.Windows.Forms.TextBox IngredientWeightTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button button3;
    }
}
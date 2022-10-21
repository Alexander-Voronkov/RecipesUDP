namespace RecipesClient
{
    partial class MainClient
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
            this.RecipeTB = new System.Windows.Forms.TextBox();
            this.Recipes = new System.Windows.Forms.ListBox();
            this.RecipeImage = new System.Windows.Forms.PictureBox();
            this.Ingridients = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RecipeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecipeTB
            // 
            this.RecipeTB.Location = new System.Drawing.Point(14, 43);
            this.RecipeTB.Name = "RecipeTB";
            this.RecipeTB.Size = new System.Drawing.Size(386, 20);
            this.RecipeTB.TabIndex = 1;
            // 
            // Recipes
            // 
            this.Recipes.FormattingEnabled = true;
            this.Recipes.Location = new System.Drawing.Point(12, 181);
            this.Recipes.Name = "Recipes";
            this.Recipes.Size = new System.Drawing.Size(318, 108);
            this.Recipes.TabIndex = 2;
            this.Recipes.SelectedIndexChanged += new System.EventHandler(this.Recipes_SelectedIndexChanged);
            // 
            // RecipeImage
            // 
            this.RecipeImage.Location = new System.Drawing.Point(449, 30);
            this.RecipeImage.Name = "RecipeImage";
            this.RecipeImage.Size = new System.Drawing.Size(273, 122);
            this.RecipeImage.TabIndex = 3;
            this.RecipeImage.TabStop = false;
            // 
            // Ingridients
            // 
            this.Ingridients.FormattingEnabled = true;
            this.Ingridients.Location = new System.Drawing.Point(336, 181);
            this.Ingridients.Name = "Ingridients";
            this.Ingridients.Size = new System.Drawing.Size(386, 108);
            this.Ingridients.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected recipe image";
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ingridients);
            this.Controls.Add(this.RecipeImage);
            this.Controls.Add(this.Recipes);
            this.Controls.Add(this.RecipeTB);
            this.Controls.Add(this.button1);
            this.Name = "MainClient";
            this.Text = "MainClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainClient_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.RecipeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox RecipeTB;
        private System.Windows.Forms.ListBox Recipes;
        private System.Windows.Forms.PictureBox RecipeImage;
        private System.Windows.Forms.ListBox Ingridients;
        private System.Windows.Forms.Label label1;
    }
}
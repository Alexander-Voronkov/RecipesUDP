using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DllClass;
namespace RecipesServer
{
    public partial class AddRecipe : Form
    {
        List<Recipe> temp;
        public Recipe recipe;
        string path=null;
        public AddRecipe(List<Recipe> temp)
        {
            InitializeComponent();
            this.temp = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                MessageBox.Show("Select a picture for your recipe!");
                return;
            }
            if (RecipeNameTB.TextLength == 0)
            {
                MessageBox.Show("Enter a recipe name!");
                return;
            }

            if(IngredientList.Items.Count==0)
            {
                MessageBox.Show("A recipe must contain at least one ingredient!");
                return;
            }

            if (temp.Where(x=>x.RecipeName==RecipeNameTB.Text).Count()>1)
            {
                MessageBox.Show("Such recipe already exists");
                return;
            }
            using (MemoryStream m=new MemoryStream())
            {
                var img = Image.FromFile(path);
                img.Save(m, img.RawFormat);
                byte[] data = m.ToArray();
                recipe = new Recipe(RecipeNameTB.Text, Convert.ToBase64String(data), IngredientList.Items.Cast<Ingredient>().ToArray());
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IngredientNameTB.TextLength == 0)
            {      
                MessageBox.Show("Ingredient name can't be empty!");
                return;
            }

            float weight;
            if(float.TryParse(IngredientWeightTB.Text,out weight)==false)
            {
                MessageBox.Show("Wrong weight!");
                return;
            }
            if(weight==0)
            {
                MessageBox.Show("Weight can't be zero!");
                return;
            }

            var q = IngredientList.Items.Cast<Ingredient>().ToList();
            if (q.Count > 0)
            {
                if (q.Where(x => x.IngredientName == IngredientNameTB.Text).Count() > 0)
                {
                    MessageBox.Show("Recipe already contains such ingredient!");
                    return;
                }
            }

            IngredientList.Items.Add(new Ingredient(IngredientNameTB.Text,weight));
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if(IngredientList.SelectedIndices.Count>0)
            {
                IngredientList.Items.Remove(IngredientList.SelectedIndices[0]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Png files (*.png)|*.png|Jpg files (*.jpg)|*.jpg";
            openFileDialog.FilterIndex = 0;
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                path=openFileDialog.FileName;
            }
        }
    }
}

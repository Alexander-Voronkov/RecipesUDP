using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DllClass;
using System.IO;
using System.CodeDom.Compiler;

namespace RecipesClient
{
    public partial class MainClient : Form
    {
        RecipesClient client=null;
        IPEndPoint serverEP=null;
        public MainClient()
        {
            InitializeComponent();
            client= new RecipesClient();
            TempPoint temp=new TempPoint();
            
            new Form1(this,client.Client,temp).ShowDialog();
            Ingridients.Enabled = false;
            serverEP = new IPEndPoint(temp.Address,temp.Port);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(RecipeTB.Text))
            {
                MessageBox.Show("Recipe can't be empty!");
                return;
            }

            button1.Enabled = false;
            var r = await client.AskForRecipeAsync(new ServerPoint() { query = RecipeTB.Text, server = serverEP });
            if (r == null)
            {
                MessageBox.Show("An error occured!");
                button1.Enabled = true;
                return;
            }
            button1.Enabled = true;
            Recipes.Items.Add(r);
            Recipes.SetSelected(Recipes.Items.IndexOf(r),true);
        }

        private void Recipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Recipes.SelectedIndices.Count > 0)
            {
                Ingridients.Items.Clear();
                Ingridients.Items.AddRange((Recipes.SelectedItem as Recipe).Ingredients.ToArray());
                using (var ms = new MemoryStream(Convert.FromBase64String((Recipes.SelectedItem as Recipe).Img)))
                {
                    RecipeImage.Image = Image.FromStream(ms);
                }
            }
        }

        private void MainClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] bytes = Encoding.UTF8.GetBytes("DISCONNECT");
            client?.Client.Send(bytes,bytes.Length,serverEP);
            client?.Close();
        }
    }


    public class RecipesClient
    {
        UdpClient client;
        public UdpClient Client { get { return client; } }

        public RecipesClient()
        {
            client = new UdpClient();
        }

        public Task<Recipe> AskForRecipeAsync(ServerPoint mess)
        {
            return Task.Factory.StartNew(AskForRecipe, mess);
        }

        public Recipe AskForRecipe(object mess)
        {
            ServerPoint message = mess as ServerPoint;
            byte[] query = Encoding.UTF8.GetBytes($"RECIPE\n{message.query}");
            client.Send(query, query.Length, message.server);
            IPEndPoint ep = null;
            string text = String.Empty;
            StringBuilder image = new StringBuilder();
            query = client.Receive(ref ep);
            text = Encoding.UTF8.GetString(query);
            var textmessage = text.Split('\n');
            for (int i = 0; i < int.Parse(textmessage[textmessage.Length-1]); i++)
            {
                query = client.Receive(ref ep);
                image.Append(Convert.ToBase64String(query));
            }
            if (textmessage.Length <= 1)
            {
                return null;
            }
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 1; i < textmessage.Length-1; i++)
            {
                var q = textmessage[i].Split(':');
                ingredients.Add(new Ingredient(q[0], float.Parse(q[1])));
            }
            return new Recipe(textmessage[0],
                image.ToString(),
                ingredients.ToArray());
        }

        public void Close()
        {
            Client?.Close();
        }
    }

    public class ServerPoint
    {
        public string query { get; set; }
        public IPEndPoint server { get; set; }
    }
    public class TempPoint
    {
        public IPAddress Address { get; set; }
        public int Port { get; set; }
    }

}

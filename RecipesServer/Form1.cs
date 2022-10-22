using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Timers;
using System.Text.Json;
using DllClass;
using System.Security.Cryptography;
using RecipesServer.Properties;

namespace RecipesServer
{
    public partial class Form1 : Form
    {
        RecipesServer server = null;
        System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            DeleteIngrBtn.Enabled = false;
            DeleteRecipeBtn.Enabled = false;
            AddIngrBtn.Enabled = false;
            AddRecipeBtn.Enabled = false;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Tick;
        }

        private void Tick(object sender, EventArgs ea)
        {
            for (int i = 0; i < server.ConnectedClients.Count; i++)
            {
                server.ConnectedClients.ElementAt(i).Key.CurrentSession = TimeSpan.FromSeconds(server.ConnectedClients.ElementAt(i).Key.CurrentSession.TotalSeconds + 1);
                server.ConnectedClients.ElementAt(i).Key.Inactivity = TimeSpan.FromSeconds(server.ConnectedClients.ElementAt(i).Key.Inactivity.TotalSeconds + 1);
                if (server.ConnectedClients.ElementAt(i).Key.Inactivity.TotalSeconds > 600)
                {
                    server.ConnectedClients.ElementAt(i).Key.Inactivity = TimeSpan.FromSeconds(0);
                    server.ConnectedClients.Remove(server.ConnectedClients.ElementAt(i--).Key);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddRecipe ar = new AddRecipe(server.Recipes);
            ar.ShowDialog();
            RecipesListBox.Items.Add(ar.recipe as Recipe);
            server.Recipes.Add(ar.recipe);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start receive")
            {
                IPAddress ip;
                int port;
                if (!IPAddress.TryParse(IPTextBox.Text, out ip) || IPTextBox.TextLength == 0)
                {
                    MessageBox.Show("IP address can't be empty!");
                    return;
                }


                if (!int.TryParse(PortTextBox.Text, out port) || PortTextBox.TextLength == 0)
                {
                    MessageBox.Show("Wrong port!");
                    return;
                }

                server = new RecipesServer();
                try
                {
                    server.CreateNew(ip, port);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                server.StartReceive(this, Connected_users);
                RecipesListBox.Items.Clear();
                Ingredients.Items.Clear();
                RecipesListBox.Items.AddRange(server.Recipes.ToArray());
                DeleteIngrBtn.Enabled = true;
                DeleteRecipeBtn.Enabled = true;
                AddIngrBtn.Enabled = true;
                AddRecipeBtn.Enabled = true;
                button1.Text = "Stop receive";
            }
            else if (button1.Text == "Stop receive")
            {
                button1.Text = "Start receive";
                server.Close();
                DeleteIngrBtn.Enabled = false;
                DeleteRecipeBtn.Enabled = false;
                AddIngrBtn.Enabled = false;
                AddRecipeBtn.Enabled = false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AddIngr ai = new AddIngr((RecipesListBox.SelectedItem as Recipe).Ingredients);
            ai.ShowDialog();

            (RecipesListBox.SelectedItem as Recipe).Ingredients.Add(ai.res);
            Ingredients.Items.Add(ai.res);
        }

        private void DeleteIngrBtn_Click(object sender, EventArgs e)
        {
            if (Ingredients.SelectedIndices.Count > 0 && RecipesListBox.SelectedIndices.Count > 0)
            {
                (RecipesListBox.SelectedItem as Recipe).Ingredients.Remove(Ingredients.SelectedItem as Ingredient);
                Ingredients.Items.Remove(Ingredients.SelectedItem as Ingredient);
            }
        }

        private void DeleteRecipeBtn_Click(object sender, EventArgs e)
        {
            if (RecipesListBox.SelectedIndices.Count > 0)
            {
                Ingredients.Items.Clear();
                server.Recipes.Remove(RecipesListBox.SelectedItem as Recipe);
                RecipesListBox.Items.Remove(RecipesListBox.SelectedItem as Recipe);
            }
        }

        private void RecipesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RecipesListBox.SelectedIndices.Count > 0)
            {
                Ingredients.Items.Clear();
                Ingredients.Items.AddRange((RecipesListBox.SelectedItem as Recipe).Ingredients.ToArray());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server?.Save();
        }
    }

    public class RecipesServer
    {
        UdpClient server = null;
        Task loading;
        private List<UserLog> logs;
        public Dictionary<UserLog, IPEndPoint> ConnectedClients;
        public List<KeyValuePair<UserLog, DateTime>> PenaltedUsers;
        public List<UserLog> Logs { get { return logs; } }
        private List<Recipe> recipes;
        public List<Recipe> Recipes { get { return recipes; } }

        public int ConnectedUsersConstraint = 10;
        public RecipesServer()
        {
            recipes = new List<Recipe>();
            logs = new List<UserLog>();
            loading = Task.Run(LoadJson);
            PenaltedUsers = new List<KeyValuePair<UserLog, DateTime>>();
            ConnectedClients = new Dictionary<UserLog, IPEndPoint>();
        }

        private void LoadJson()
        {
            if (File.Exists("recipes.json"))
            {
                string s = File.ReadAllText("recipes.json");
                recipes = JsonConvert.DeserializeObject<List<Recipe>>(s);
            }
            if (File.Exists("users.json"))
            {
                string s = File.ReadAllText("users.json");
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new IPAddressConverter());
                settings.Converters.Add(new IPEndPointConverter());
                settings.Formatting = Formatting.Indented;
                logs = JsonConvert.DeserializeObject<List<UserLog>>(s, settings);
            }
        }

        private void CopyBytes(byte[] from, byte[]where,int pos,int count)
        {
            int q = 0;
            for (int i = pos; i < pos+count; i++)
            {
                where[q++] = from[i];       
            }
        }

        public void Save()
        {
            if (recipes.Count > 0)
            {
                File.WriteAllText("recipes.json", JsonConvert.SerializeObject(recipes, Formatting.Indented));
            }
            if (logs.Count > 0)
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new IPAddressConverter());
                settings.Converters.Add(new IPEndPointConverter());
                settings.Formatting = Formatting.Indented;
                File.WriteAllText("users.json", JsonConvert.SerializeObject(logs, settings));
            }
        }

        public void StartReceive(Form1 f, ListBox conn)
        {
            loading.Wait();
            server.BeginReceive(Callback, new TempMessage() { server = this.server, form = f });
        }

        private void Callback(IAsyncResult iar)
        {
            try
            {
                TempMessage serverstate = iar.AsyncState as TempMessage;
                UdpClient serv = serverstate.server;
                IPEndPoint client = null;
                Form1 f = serverstate.form;
                serv?.BeginReceive(Callback, new TempMessage() { server = this.server, form = f });
                byte[] bytes = serv.EndReceive(iar, ref client);
                string received = Encoding.UTF8.GetString(bytes);
                var arr = received.Split('\n');
                if (arr[0] == "DISCONNECT")
                {
                    for (int i = 0; i < ConnectedClients.Count; i++)
                    {
                        if (ConnectedClients.ElementAt(i).Value.Address.ToString() == client.Address.ToString() && ConnectedClients.ElementAt(i).Value.Port == client.Port)
                        {
                            if (f.InvokeRequired)
                            {
                                f.BeginInvoke(new Action(() =>
                                {
                                    (f.Controls.Find("Connected_users", false)[0] as ListBox).Items.Remove(ConnectedClients.ElementAt(i).Key);
                                }));
                            }
                            else
                            {
                                (f.Controls.Find("Connected_users", false)[0] as ListBox).Items.Remove(ConnectedClients.ElementAt(i).Key);
                            }
                            ConnectedClients.Remove(ConnectedClients.ElementAt(i).Key);
                        }
                    }
                    return;
                }
                if (ConnectedClients.Count >= ConnectedUsersConstraint)
                {
                    bytes = Encoding.UTF8.GetBytes("Server is overloaded! Try later...");
                    serv.Send(bytes, bytes.Length, client);
                    return;
                }
                if (arr.Length == 3 && arr[0] == "SIGNIN")
                {
                    if (PenaltedUsers.Where(x => BinaryEquals(x.Key.Login, new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(arr[0]))) && BinaryEquals(x.Key.Password, new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(arr[1])))).Count() > 0)
                    {
                        bytes = Encoding.UTF8.GetBytes("Timeout!");
                        serv.Send(bytes, bytes.Length, client);
                        return;
                    }

                    if (Logs.Where(x => BinaryEquals(x.Login, new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(arr[0])))).Count() == 0)
                    {
                        bytes = Encoding.UTF8.GetBytes("Wrong log!");
                        serv.Send(bytes, bytes.Length, client);
                        return;
                    }

                    if (Logs.Where(x => BinaryEquals(x.Login, new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(arr[0]))) && BinaryEquals(x.Password, new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(arr[1])))).Count() == 0)
                    {
                        bytes = Encoding.UTF8.GetBytes("Wrong pass!");
                        serv.Send(bytes, bytes.Length, client);
                        return;
                    }
                    UserLog user = Logs.Where(x => BinaryEquals(x.Login, new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(arr[0]))) && BinaryEquals(x.Password, new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(arr[1])))).ToList()[0];
                    if (ConnectedClients.ContainsKey(user))
                    {
                        if (f.InvokeRequired)
                        {
                            f.BeginInvoke(new Action(() => { (f.Controls.Find("Connected_users", false)[0] as ListBox).Items.Remove(user); }));
                        }
                        else
                        {
                            (f.Controls.Find("Connected_users", false)[0] as ListBox).Items.Remove(user);
                        }
                        ConnectedClients.Remove(user);
                    }
                    bytes = Encoding.UTF8.GetBytes("Access granted!");
                    serv.Send(bytes, bytes.Length, client);
                    user.timer.Start();
                    ConnectedClients.Add(user, client);
                    if (f.InvokeRequired)
                    {
                        f.BeginInvoke(new Action(() => { (f.Controls.Find("Connected_users", false)[0] as ListBox).Items.Add(user); }));
                    }
                    else
                    {
                        (f.Controls.Find("Connected_users", false)[0] as ListBox).Items.Add(user);
                    }
                }
                else if (arr.Length == 3 && arr[0] == "SIGNUP")
                {
                    if (Logs.Where(x => BinaryEquals(x.Login, new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(arr[0])))).Count() == 0)
                    {
                        Logs.Add(new UserLog(client, arr[0], arr[1]));
                        bytes = Encoding.UTF8.GetBytes("Successfully added!");
                        serv.Send(bytes, bytes.Length, client);
                        return;
                    }
                    else
                    {
                        bytes = Encoding.UTF8.GetBytes("Such user already exists! Try another login!");
                        serv.Send(bytes, bytes.Length, client);
                        return;
                    }
                }
                else if (arr.Length == 2 && arr[0] == "RECIPE")
                {
                    if (ConnectedClients.ContainsValue(client))
                    {
                        StringBuilder q = new StringBuilder();
                        if (Recipes.Where(x => x.RecipeName == arr[1]).Count() > 0)
                        {
                            Recipe r = Recipes.Where(x => x.RecipeName == arr[1]).ToList()[0];
                            q.Append($"{r.RecipeName}\n");
                            foreach (var item in r.Ingredients)
                            {
                                q.Append($"{item}\n");
                            }
                            int count = 0;
                            for (int i = 2; i < 100; i++)
                            {
                                if(r.Img.Length%i==0&&r.Img.Length/i<=60000)
                                {
                                    count = i;
                                    break;
                                }
                            }
                            q.Append($"{count}");
                            bytes = Encoding.UTF8.GetBytes(q.ToString());
                            serv.Send(bytes, bytes.Length, client);
                            int pos = 0;
                            for (int i = 0; i < count; i++)
                            {
                                Thread.Sleep(200);
                                byte[] temp=new byte[r.Img.Length/count];
                                CopyBytes(r.Img,temp,pos,r.Img.Length/count);
                                pos += r.Img.Length / count;
                                serv.Send(temp, temp.Length, client);
                            }
                            return;
                        }
                        else
                        {
                            bytes = Encoding.UTF8.GetBytes("No such recipes found!");
                            serv.Send(bytes, bytes.Length, client);
                            return;
                        }
                    }
                    else
                    {
                        bytes = Encoding.UTF8.GetBytes("Sign in if you have an account! Otherwise sign up!");
                        serv.Send(bytes, bytes.Length, client);
                        return;
                    }
                }
                else
                {
                    bytes = Encoding.UTF8.GetBytes("Unknown command!");
                    serv.Send(bytes, bytes.Length, client);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool BinaryEquals(byte[] arr1, byte[]arr2)
        {
            if (arr1.Length != arr2.Length)
                return false;


            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr1[i])
                    return false;
            }

            return true;
        }

        public void CreateNew(IPAddress ip, int port)
        {
            try
            {
                Close();
                server = new UdpClient(new IPEndPoint(ip, port));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public void Close()
        {
            server?.Close();
        }      
    }   
    public class TempMessage
    {
        public Form1 form { get; set; }
        public UdpClient server { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DllClass
{
    [Serializable]
    public class Recipe
    {
        [JsonProperty("recipename")]
        private string Recipe_Name = "";

        [JsonProperty("recipeimg")]
        private byte[] Image;
        [JsonIgnore]
        public byte[] Img { get { return Image; } }
        [JsonIgnore]
        public string RecipeName
        {
            get { return Recipe_Name; }
        }

        [JsonProperty("ingredients")]
        public List<Ingredient> Ingredients { get; }
        public Recipe(string name, byte[] img, params Ingredient[] ingredients)
        {
            if(ingredients.Length>0)
                Ingredients = ingredients.Distinct().ToList();
            else
                Ingredients = new List<Ingredient>();
            Image = img;
            Recipe_Name = name;
        }
        public Recipe()
        {
            Ingredients=new List<Ingredient>();
        }

        public override string ToString()
        {
            return RecipeName;
        }
    }

    [Serializable]
    public class Ingredient
    {
        [JsonProperty("ingrname")]
        private string Ingredient_Name = "";
        [JsonIgnore]
        public string IngredientName
        {
            get { return Ingredient_Name; }
        }

        [JsonProperty("ingrweight")]
        private float _Weight;
        [JsonIgnore]
        public float Weight
        {
            get { return _Weight; }
        }

        public Ingredient()
        {

        }

        public Ingredient(string ingredient_Name, float weight)
        {
            if (ingredient_Name == null || weight <= 0 || ingredient_Name.Length == 0)
                throw new ArgumentException("Wrong arguments!");
            Ingredient_Name = ingredient_Name;
            _Weight = weight;
        }

        public override string ToString()
        {
            return $"{IngredientName}:{Weight}";
        }
    }


    [Serializable]
    public class UserLog
    {
        [JsonIgnore]
        public bool IsActive = true;
        [JsonIgnore]
        public System.Timers.Timer timer;
        [JsonProperty("userip")]
        private IPEndPoint ip;
        [JsonIgnore]
        public IPEndPoint Ip { get { return ip; } }
        [JsonProperty("userlog")]
        private byte[] login;
        [JsonIgnore]
        public byte[] Login { get { return login; } }
        [JsonProperty("userpass")]
        private byte[] password;
        [JsonIgnore]
        public byte[] Password { get { return password; } }

        [JsonProperty("userconntime")]
        public TimeSpan ConnectionTime = TimeSpan.FromSeconds(0);

        [JsonProperty("userqueries")]
        private List<string> userqueries;
        [JsonIgnore]

        public int CurrentAttemptCount = 0;
        [JsonIgnore]
        public TimeSpan CurrentSession = TimeSpan.FromSeconds(0);
        [JsonIgnore]
        public List<string> UserQueries { get { return UserQueries; } }

        public UserLog()
        {
            userqueries = new List<string>();
            timer = new System.Timers.Timer(); 
            timer.Interval = 1000;
            timer.Elapsed += (object sender, ElapsedEventArgs ea) => { ConnectionTime = TimeSpan.FromSeconds(ConnectionTime.TotalSeconds + 1); Inactivity = TimeSpan.FromSeconds(Inactivity.TotalSeconds + 1); };
        }
        public UserLog(IPEndPoint ip, string log, string pass)
        {
            if (string.IsNullOrEmpty(log) || string.IsNullOrEmpty(pass) || ip == null)
                throw new ArgumentException("Wrong arguments while creating userlog!");
            login = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(log));
            password = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(pass));
            userqueries = new List<string>();
            this.ip = ip;
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += (object sender, ElapsedEventArgs ea) => { ConnectionTime = TimeSpan.FromSeconds(ConnectionTime.TotalSeconds + 1); Inactivity = TimeSpan.FromSeconds(Inactivity.TotalSeconds + 1); };
        }

        [JsonIgnore]
        public TimeSpan Inactivity = TimeSpan.FromSeconds(0);

        public override string ToString()
        {
            return $"{ip.Address}:{ip.Port}";
        }
    }
    public class IPAddressConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IPAddress));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return IPAddress.Parse((string)reader.Value);
        }
    }
    public class IPEndPointConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IPEndPoint));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IPEndPoint ep = (IPEndPoint)value;
            JObject jo = new JObject();
            jo.Add("Address", JToken.FromObject(ep.Address, serializer));
            jo.Add("Port", ep.Port);
            jo.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            IPAddress address = jo["Address"].ToObject<IPAddress>(serializer);
            int port = (int)jo["Port"];
            return new IPEndPoint(address, port);
        }
    }

    public static class Zipper
    {
        public static byte[] Zip(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            using (var stream = new MemoryStream(bytes))
            {
                using (var outStr = new MemoryStream())
                {
                    using (var gzs = new GZipStream(stream,CompressionLevel.Optimal))
                    {
                        var buff = new byte[4096];
                        int cnt = 0;
                        while ((cnt = stream.Read(buff, 0, buff.Length)) != 0)
                        {
                            gzs.Write(buff, 0, cnt);
                        }
                        return buff;
                    }
                }
            }
        }

        public static string Unzip(byte[]arr)
        {
            using (var stream = new MemoryStream(arr))
            {
                using (var outStr = new MemoryStream())
                {
                    using (var gzs = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        var buff = new byte[4096];
                        int cnt = 0;
                        while ((cnt = stream.Read(buff, 0, buff.Length)) != 0)
                        {
                            gzs.Write(buff, 0, cnt);
                        }
                        var res = outStr.ToArray();
                        return Encoding.UTF8.GetString(res);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Lab2
{
    public partial class BackupJsonComponent : Component
    {
        public BackupJsonComponent()
        {
            InitializeComponent();
        }

        public BackupJsonComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Save<T>(List<T> obj, string fullPath)
        {
            if (typeof(T).GetCustomAttributes(typeof(Newtonsoft.Json.JsonObjectAttribute), true).Length > 0)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                using (Stream fs = File.OpenWrite($"{fullPath}/save/{typeof(T).Name}.json"))
                {
                    fs.Write(Encoding.UTF8.GetBytes(json));
                }

                ZipFile.CreateFromDirectory($"{fullPath}/save", $"{fullPath}/{typeof(T).Name}Save.zip");
            }
            else
            {
                throw new Exception("Object not have attribute");
            }
        }
    }
}

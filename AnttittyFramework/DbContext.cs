﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnttittyFramework
{
    public class DbContext
    {
        private string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"fuck\de\jonas");

        public List<T> Load<T>()
        {
            List<T> items = new List<T>();
            string objectType = typeof(T).Name;
            string filesPath = Path.Combine(path, objectType);
            foreach(string file in Directory.GetFiles(filesPath))
            {
                using (Stream stream = File.Open(Path.Combine(filesPath, file), FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    items.Add((T)binaryFormatter.Deserialize(stream));
                }

            }
            return items;
        }
    }
}
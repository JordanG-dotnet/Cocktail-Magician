﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Cocktail_Magician_DB.DataSeeder.IOSeed
{
    public class WriteFileDatabase : IWriteFileDatabase
    {
        public void WriteJsonFile<T>(string address, IEnumerable<T> list)
        {
            var jsonToOutput = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });
            File.WriteAllText(address, jsonToOutput);
        }
    }
}

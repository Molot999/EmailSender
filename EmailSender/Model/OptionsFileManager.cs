using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmailSender.Model
{
    static class OptionsFileManager
    {
        static private readonly string optionsFilePath = Directory.GetCurrentDirectory() + @"\options";
        static public void SaveOptionsToFile(Options options)
        {
            File.WriteAllText(optionsFilePath,JsonConvert.SerializeObject(options));
        }

        static public Options UploadOptionsFromFile()
        {
            return JsonConvert.DeserializeObject<Options>(File.ReadAllText(optionsFilePath));
        }
    }
}

﻿using System.IO;
using Newtonsoft.Json;

namespace EmailSender.Model
{
    static class SmtpOptionsFileManager
    {
        private static readonly string optionsFilePath = Directory.GetCurrentDirectory() + @"\options";

        public static bool OptionsFileExists => File.Exists(optionsFilePath);
        public static void SaveOptionsToFile(SmtpOptions options) => File.WriteAllText(optionsFilePath, JsonConvert.SerializeObject(options));

        public static SmtpOptions UploadOptionsFromFile() => JsonConvert.DeserializeObject<SmtpOptions>(File.ReadAllText(optionsFilePath));
    }
}

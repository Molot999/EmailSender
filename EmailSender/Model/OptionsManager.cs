using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmailSender.Model
{
    class OptionsManager
    {
        public void SaveOptions(Options options)
        {
            string JSONOptions = JsonConvert.SerializeObject(options)
        }
    }
}

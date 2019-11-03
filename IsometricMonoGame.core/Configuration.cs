using System;
using System.IO;
using MonoGame.Core.Input;

namespace MonoGame.Core
{
    internal class Configuration
    {
        internal ControlDevice ControlDevice { get; set; }
    }

    internal static class ConfigurationAccess
    {
        private static Configuration configuration = null;

        internal static Configuration GetCurrentConfig()
        {
            return configuration;
        }

        internal static void InitializeConfig(string fileName)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(fileName);
                Configuration config = new Configuration();
                config.ControlDevice = (ControlDevice)Enum.Parse(typeof(ControlDevice), lines[0]);
                configuration = config;
            }
            catch (Exception ex)
            {
               using ( StreamWriter sw = System.IO.File.AppendText("log.txt"))
               {
                    sw.WriteLine(ex.Message);
               }
            }
        }

        private static Configuration GetDefaultConfig()
        {
            return new Configuration() { ControlDevice = ControlDevice.Keyboard };
        }
    }
}

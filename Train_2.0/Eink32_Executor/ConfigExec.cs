using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Eink32_Executor
{
    [Serializable]
    public class ConfigExec
    {
        public List<ExecItem> Items { get; set; }

        protected String _currentFileName = String.Empty;
        public String CfgFileName
        {
            get
            {
                return String.IsNullOrEmpty(_currentFileName) ? defaultConfigFileName : _currentFileName;
            }
        }

        public ConfigExec()
        {
            Items = new List<ExecItem>();
        }

        public bool Save(String fName)
        {
            bool bbOk = false;


            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigExec));

                using (StreamWriter writer = new StreamWriter(fName))
                {
                    serializer.Serialize(writer, this);
                    writer.Close();
                }

                bbOk = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);    
            }

            return bbOk;
        }

        public const String defaultConfigFileName = "C:\\Users\\Lapunik\\Dropbox\\C#\\Train_2.0\\Eink32_Executor\\exec_config.xml";

        public static ConfigExec Load(string fName = null)
        {
            if (String.IsNullOrEmpty(fName))
                fName = defaultConfigFileName;

            ConfigExec par = null;

            XmlSerializer serializer = new XmlSerializer(typeof(ConfigExec));

            try
            {
                using (FileStream stream = new FileStream(fName, FileMode.Open))
                {
                    par = (ConfigExec)serializer.Deserialize(stream);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            if (par == null)
                par = new ConfigExec();

            return par;
        }

        private static ConfigExec Singleton = null;

        public static ConfigExec Create(String fName)
        {
            if (Singleton == null)
            {
                if (String.IsNullOrEmpty(fName))
                    Singleton = new ConfigExec();
                else
                    Singleton = ConfigExec.Load(fName);
            }

            return Singleton;
        }
    }
}
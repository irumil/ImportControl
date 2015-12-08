using System.IO;
using System.Xml.Serialization;

namespace ImpStatusLibrary
{
    public class ImportControlSetting
    {
        private string _importPath;
        private double _interval;
        private double _intervalLogImport;
        private int _countForRespondToProc;

        public string ImportPath
        {
            get
            {
                //if (_importPath == null) return "D:\\1111\\Import.exe";
                return _importPath ?? "D:\\1111\\Import.exe";
            }
            set { _importPath = value; }
        }
        public bool WorkIt { get ; set; }
        public bool WorkLogImport { get; set; }
        public double Interval
        {
            get
            {
                if (_interval == 0) return 5;
                return _interval;
            }
            set { _interval = value; }
        }
        public double IntervalLogImport
        {
            get
            {
                if (_intervalLogImport == 0) return 5;
                return _intervalLogImport;
            }
            set { _intervalLogImport = value; }
        }
        public bool KillNoRespondProc {get;set; }
        public int CountForRespondToProc {
            get
            {
                if (_countForRespondToProc == 0) return 5;
                return _countForRespondToProc;
            }
            set { _countForRespondToProc = value; } 
        }
        public bool CloseCopyImport { get; set; }
        private const string FileName = "ImportControlSetting.xml";
        private static ImportControlSetting _importControlSetting;
        public static ImportControlSetting GetSettings()
        {
         
            if (_importControlSetting == null)
            {
               lock (typeof(ImportControlSetting))
               {
                   if (_importControlSetting == null)
                       _importControlSetting = new ImportControlSetting();
               }
            }

            if (!File.Exists(FileName)) return _importControlSetting;

            {
                using (FileStream fs = new FileStream(FileName, FileMode.Open))
                {
                    XmlSerializer xmlSettings = new XmlSerializer(typeof(ImportControlSetting));
                    _importControlSetting = (ImportControlSetting)xmlSettings.Deserialize(fs);
                    fs.Close();
                }
            }
            return _importControlSetting;
        }
        public void Save()
        {
            if (File.Exists(FileName)) File.Delete(FileName);

            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                XmlSerializer xmlSettings = new XmlSerializer(typeof(ImportControlSetting));
                xmlSettings.Serialize(fs, _importControlSetting);
                fs.Close();
            }
        }

    }
}

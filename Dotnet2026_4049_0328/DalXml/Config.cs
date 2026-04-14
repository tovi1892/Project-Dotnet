using System;
using System.IO;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
        // store actual file name with extension to simplify IO
        private static readonly string Folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xml");
        private static readonly string FileName = Path.Combine(Folder, "data-config.xml");
        private static readonly object s_lock = new();

        // Ensure file exists and has root/config with the expected elements
        private static void EnsureFile()
        {
            Directory.CreateDirectory(Folder);
            if (!File.Exists(FileName))
            {
                var root = new XElement("config",
                    new XElement("ProductNum", 1000),
                    new XElement("SaleNum", 100));
                root.Save(FileName);
            }
            else
            {
                // ensure elements exist (backwards compatible)
                try
                {
                    var doc = XElement.Load(FileName);
                    bool changed = false;
                    if (doc.Element("ProductNum") == null)
                    {
                        doc.Add(new XElement("ProductNum", 1000));
                        changed = true;
                    }
                    if (doc.Element("SaleNum") == null)
                    {
                        doc.Add(new XElement("SaleNum", 100));
                        changed = true;
                    }
                    if (changed) doc.Save(FileName);
                }
                catch
                {
                    // If file is corrupted, recreate safe defaults
                    var root = new XElement("config",
                        new XElement("ProductNum", 1000),
                        new XElement("SaleNum", 100));
                    root.Save(FileName);
                }
            }
        }

        // Returns current value and increments the stored value for next call
        public static int ProductNum
        {
            get
            {
                lock (s_lock)
                {
                    EnsureFile();
                    var doc = XElement.Load(FileName);
                    var el = doc.Element("ProductNum");
                    int cur = 1000;
                    if (el != null) int.TryParse(el.Value, out cur);
                    // Write next value
                    el.Value = (cur + 1).ToString();
                    doc.Save(FileName);
                    return cur;
                }
            }
        }

        public static int SaleNum
        {
            get
            {
                lock (s_lock)
                {
                    EnsureFile();
                    var doc = XElement.Load(FileName);
                    var el = doc.Element("SaleNum");
                    int cur = 100;
                    if (el != null) int.TryParse(el.Value, out cur);
                    // Write next value
                    el.Value = (cur + 1).ToString();
                    doc.Save(FileName);
                    return cur;
                }
            }
        }
    }
}

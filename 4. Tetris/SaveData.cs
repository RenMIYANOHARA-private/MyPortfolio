using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace tetris
{
    class SaveData
    {
        // XMLファイル　https://www.tairax.com/entry/Csharp/XDocument-XElement
        // 相対パス　http://lab.agr.hokudai.ac.jp/useful/utile/Path_URL.htm

        private XDocument xml = XDocument.Load(Path.GetFullPath("../../dic/") + "param.xml");


        public int getBestScore()
        {
            string bestScore = xml.Element("bestScore").Value;
            return int.Parse(bestScore);
        }

        public void saveBestScore(int bs)
        {
            xml.Element("bestScore").Value = bs.ToString();
            save();
        }

        private void save() { xml.Save(Path.GetFullPath("../../dic/") + "param.xml"); }
    }
}

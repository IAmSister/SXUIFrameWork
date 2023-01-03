
using System;
using System.Collections.Generic;
using System.Collections;

namespace GCGame.Table
{

    [Serializable]
    public class Tab_TitleType
    {
        private const string TAB_FILE_DATA = "Tables/TitleType.txt";
        enum _ID
        {
            INVLAID_INDEX = -1,
            ID_ID,
            ID_TYPENAME = 2,
            ID_TYPEDESC,
            MAX_RECORD
        }
        public static string GetInstanceFile() { return TAB_FILE_DATA; }

        private int m_Id;
        public int Id { get { return m_Id; } }

        private string m_TypeDesc;
        public string TypeDesc { get { return m_TypeDesc; } }

        private string m_TypeName;
        public string TypeName { get { return m_TypeName; } }

        public static bool LoadTable(Dictionary<int, List<object>> _tab)
        {
          
            return true;
        }
        public static void SerializableTable(string[] valuesList, int skey, Dictionary<int, List<object>> _hash)
        {
           
        }


    }
}


using System.Collections.Generic;

namespace Skill
{
    public class SkillProcessData
    {
        public const string STEP = "Step";
        public const string TARGET = "Target";
        public const string DIRECTION = "Direction";
        public const string TILE = "Tile";

        public Dictionary<string, object> Data;
        private object m_tempData;

        public string Step { get { return GetValue<string>(STEP); } }
        public string Target { get { return GetValue<string>(TARGET); } }
        public string Direction { get { return GetValue<string>(DIRECTION); } }
        public string Tile { get { return GetValue<string>(TILE); } }

        private T GetValue<T>(string _parameter)
        {
            if (Data.TryGetValue(_parameter, out m_tempData))
            {
                return (T)m_tempData;
            }
            return default(T);
        }
    }
}
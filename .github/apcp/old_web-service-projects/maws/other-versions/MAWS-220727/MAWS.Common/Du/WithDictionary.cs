using System.Collections.Generic;
using System.Linq;

namespace MAWS.Common.Du
{
    public class WithDictionary
    {
        public static Dictionary<string, string> JoinMultiple(List<Dictionary<string, string>> dictionariesToJoin)
        {
            var wrkDictionary = new Dictionary<string, string>();

            foreach (var item in dictionariesToJoin)
            {
                item.ToList().ForEach(x => wrkDictionary[x.Key] = x.Value);
            }

            return wrkDictionary;
        }
    }
}

// Du
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using System.Collections.Generic;
using System.Linq;

namespace Du
{
    /// <summary></summary>
    public class WithDictionary
    {
        /// <summary></summary>
        /// <param name="dictionariesToJoin"></param>
        /// <returns></returns>
        public static Dictionary<string, string> JoinListOf(List<Dictionary<string, string>> dictionariesToJoin)
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

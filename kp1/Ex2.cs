using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

    class StringAnalyzer
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("d", first_non_repeating_letter("aoaoaoadaoaoao"));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual("f", first_non_repeating_letter("AAOOAOAOddfdda"));
        }
        public string first_non_repeating_letter(string data)
        {
            string loweredData = data.ToLower();
            List<char> chars = loweredData.Select(ch => ch).Distinct().ToList(); // get all characters in string
            foreach (var item in chars)
            {
                if (loweredData.Count(ch => ch == item) == 1) 
                {
                    int Index;
                    if (data.IndexOf(item) == -1) Index = data.IndexOf(item.ToString().ToUpper()); // character is actually uppercase
                    else Index = data.IndexOf(item); // character is actually lowercase
                    return data[Index].ToString();
                }
            }   
            return "";
        }
    } 

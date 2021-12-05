using System.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

class StringAnalyzer
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("There are no unique characters", first_non_repeating_letter("testtest"));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual("k", first_non_repeating_letter("testKtest"));
        }
        public string first_non_repeating_letter(string data)
        {   
            string answer = "There are no unique characters";
            string Data = data.ToLower();
            char[] charArray = Data.ToCharArray();
            var Distinct = charArray.GroupBy(x => x)
              .Where(g => g.Count() == 1)
              .Select(y => y.Key)
              .ToList();

            if (Distinct.Any()){
                return Distinct[0].ToString();
            }
            else{
                return answer;
            }
              } 
            
        
    } 

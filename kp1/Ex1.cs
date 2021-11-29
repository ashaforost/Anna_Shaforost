using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

    class ListFiltering
    {
        [Test]
        public void Test1()
        {
            var data = new List<object> { 1, 2, "a", "b" };
            var output = FilterOutStrings(data);
            Assert.AreEqual(new List<int> { 1, 2 }, output);
        }
        [Test]
        public void Test2()
        {
            var data = new List<object> { 1, 2, "a", "b", "aasf", "1", "123", 231 };
            var output = FilterOutStrings(data);
            Assert.AreEqual(new List<int> { 1, 2, 231 }, output);
        }
        public List<int> FilterOutStrings(List<object> data)
        {
            return data.Where(item => item is Int32).Select(item => (int)item).ToList();
        }
    }



using System;
using System.Collections.Generic;
using System.Linq;using NUnit.Framework;

class People{

[Test]
 public void Test1()
        {
            string s = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            string exp = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            Assert.AreEqual(exp, NameSearch(s));
        }

[Test]
 public void Test2()
        {
            string s = "Jared:Smith;Liam:Browm;Oliver:Jones;Ava:Davis;Ave:Davis;Raphael:Smith;Alfred:Brown";
            string exp = "(BROWM, LIAM)(BROWN, ALFRED)(DAVIS, AVA)(DAVIS, AVE)(JONES, OLIVER)(SMITH, JARED)(SMITH, RAPHAEL)";
            Assert.AreEqual(exp, NameSearch(s));
        }


 public struct Person
        {
            public Person(string f, string l)
            {
                this.firstName = f;
                this.lastName = l;
            }
            public string firstName;
            public string lastName;
        }
 public string NameSearch(string s){
    s = s.ToUpper();

    var Friends = new List<Person>();
    string[] friendList = s.Split(";"); 

    foreach (var friend in friendList){
        string[] name = friend.Split(":");
        Friends.Add(new Person(name[0], name [1]));
    }
    Friends = Friends.OrderBy(n=>n.lastName).ThenBy(n=>n.firstName).ToList();

    var sortedFriends ="";
    foreach( var friend in Friends){
        sortedFriends +="("+ friend.lastName+", "+friend.firstName+")";
    }
    
    return sortedFriends;
    }

}



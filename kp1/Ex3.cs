
using System.Linq;
using NUnit.Framework;

class DigitalRoot{

    [Test]
    public void TestSmall(){
        Assert.AreEqual(7, digitalRoot(16));
    }

    [Test]
    public void TestLarge(){
        Assert.AreEqual(2,digitalRoot(493193));
    }

public int digitalRoot(int num){

    var payloadStr = num.ToString();
    var digitArray = payloadStr.Select(_ => int.Parse(_.ToString()));
    var sumOutput = 0;
    foreach (var digit in digitArray){
        sumOutput+=digit;
    }
    if (sumOutput >9) return digitalRoot(sumOutput);

    return sumOutput;
}




}
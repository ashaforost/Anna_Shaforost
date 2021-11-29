
using System.Linq;
using NUnit.Framework;


class PairwiseSum{

[Test]
 public void Test1()
        {
            Assert.AreEqual(4,TargetSumPairsNumber(new int[] { 1, 3, 6, 2, 2, 0, 4, 5 }, 5));
        }


[Test]
 public void Test2()
        {
            Assert.AreEqual(6, TargetSumPairsNumber(new int[] { 2,2,3,3,4,1,5,6,0 }, 5));
        }
public int TargetSumPairsNumber(int[] array, int target){
    // var lis =array.ToList();
    // int outputPairs =0;
    //  for (int i =1; i< lis; i++){
        
    //      outputPairs += list.Count(num => (list[0] + num ==target));

        
    //  }
    //  return outputPairs;

    var listArray = array.ToList();
    int outputPairs = 0;
    int length = array.Length;
    for (int i = 0; i < length; i++){
        outputPairs += listArray.Count(num => num + listArray[0] == target);
        if(listArray[0] * 2 == target) outputPairs -= 1; // we don't want to count num+num as pair
        listArray.RemoveAt(0);
            
    }
            return outputPairs;
}

}
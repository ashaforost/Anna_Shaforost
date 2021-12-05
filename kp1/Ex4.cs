
using System.Linq;
using NUnit.Framework;
using System;

class PairwiseSum{

[Test]
 public void Test1()
        {
            Assert.AreEqual(4,TargetSumPairsNumber(new int[] { 1, 4, 6, 2, 2, 0, 3, 5 }, 5));
        }


[Test]
 public void Test2()
        {
            Assert.AreEqual(6, TargetSumPairsNumber(new int[] { 2,2,3,3,4,1,5,6,0 }, 5));
        }
public int TargetSumPairsNumber(int[] array, int target){

    int outputPairs = 0;
    int length = array.Length;
    for (int i = 0; i < length; i++){
        for (int j=i+1;j < length; j++ ){
            if (array[i]+array[j] ==target) outputPairs+=1;
        }
    }
            return outputPairs;
}

}
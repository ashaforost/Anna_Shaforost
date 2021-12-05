using System;
using NUnit.Framework;
using System.Linq;


    class NextBigInteger
    {
        [Test]
        public void Test1()
        {
            var data = 12 ;
            var output = NextBigInt(data);
            Assert.AreEqual(21, output);
        }

        [Test]
        public void Test2()
        {
            var data = 11 ;
            var output = NextBigInt(data);
            Assert.AreEqual(-1, output);
        }
        [Test]
        public void Test3()
        {
            var data = 2017;
            var output = NextBigInt(data);
            Assert.AreEqual(2071, output);
        }

        static void swap( char[] arr, int i,int j){
        char temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
        }
        public int NextBigInt(int data)
        {
            var array = data.ToString().ToArray();
            var len = array.Length;
            var testArray =  array.ToList();
            testArray.Sort();
            testArray.Reverse();

            if (len ==1 || array.ToList().SequenceEqual(testArray)){
                return -1;
            }
            
            
            int i = len-1;
        
            char current = array[i-1];
            int minIndex = i;
            for (var j = i+1; j< len; j++){
                if(array[j]>current && array[j]<array[minIndex]){
                    minIndex = j;
                }
            }
            
            
            swap(array, i-1, minIndex);

            Array.Sort(array, i, len-i);

            string number = "";

            foreach(var _ in array){
                number+=_.ToString();
            }

            int output = int.Parse(number);

        return output;
        }
    }



//#define ArrayDemo
//#define Average0
//#define Average1
//#define ArrayErr
//#define TwoD
//#define ThreeDMatrix
//define Squares
//#define Jagged
//#define AssignRef
//#define LengthDemo
//#define LengthDemo3D
//#define RevCopy
//#define JaggedLength
//#define ForeachDemo0
//#define ForeachDemo1
//#define ForeachDemo2
//#define Search
//#define StringDemo
//#define Strops
//#define StringArrays
//#define ConvertDigitsToWords
//#define Substr
//#define StringSwitch


using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Ref6_Arrays_Strings
{

#if ArrayDemo
// Demonstrate a one-dimensional array. 
 
class ArrayDemo {  
  public static void Main() {  
    int[] sample = new int[10]; 
    int i;  
  
    for(i = 0; i < 10; i = i+1)  
      sample[i] = i; 
 
    for(i = 0; i < 10; i = i+1)  
      Console.WriteLine("sample[" + i + "]: " + 
                         sample[i]);  
  }  
}
#endif


#if Average0
// Compute the average of a set of values. 
 
using System; 
 
class Average {  
  public static void Main() {  
    int[] nums = new int[10]; 
    int avg = 0; 
 
    nums[0] = 99; 
    nums[1] = 10; 
    nums[2] = 100; 
    nums[3] = 18; 
    nums[4] = 78; 
    nums[5] = 23; 
    nums[6] = 63; 
    nums[7] = 9; 
    nums[8] = 87; 
    nums[9] = 49; 
 
    for(int i=0; i < 10; i++)  
      avg = avg + nums[i]; 
 
    avg = avg / 10; 
 
    Console.WriteLine("Average: " + avg); 
  }  
}

#endif

#if Average1
// Compute the average of a set of values. 
 
 
class Average {  
  public static void Main() {  
    int[] nums = { 99, 10, 100, 18, 78, 23, 
                   63, 9, 87, 49 }; 
    int avg = 0; 
 
    for(int i=0; i < 10; i++)  
      avg = avg + nums[i]; 
 
    avg = avg / 10; 
 
    Console.WriteLine("Average: " + avg); 
  }  
}

#endif



#if ArrayErr
// Demonstrate an array overrun. 
 
 
class ArrayErr {  
  public static void Main() {  
    int[] sample = new int[10]; 
    int i;  
  
    // generate an array overrun 
    for(i = 0; i < 100; i = i+1)  
      sample[i] = i; 
  }  
}

#endif

#if TwoD
// Demonstrate a two-dimensional array.   
 
class TwoD {  
  public static void Main() {  
    int t, i; 
    int[,] table = new int[3, 4];  
  
    for(t=0; t < 3; ++t) {  
      for(i=0; i < 4; ++i) {  
        table[t,i] = (t*4)+i+1;  
        Console.Write(table[t,i] + " ");  
      }  
      Console.WriteLine(); 
    }  
  } 
}
#endif

#if ThreeDMatrix
// Sum the values on a diagonal of a 3x3x3 matrix. 
 
 
class ThreeDMatrix {  
  public static void Main() {  
    int[,,] m = new int[3, 3, 3]; 
    int sum = 0; 
    int n = 1; 
 
    for(int x=0; x < 3; x++) 
      for(int y=0; y < 3; y++) 
        for(int z=0; z < 3; z++)  
          m[x, y, z] = n++; 
 
 
    sum = m[0,0,0] + m[1,1,1] + m[2, 2, 2]; 
 
    Console.WriteLine("Sum of first diagonal: " + sum); 
  }  
}

#endif

#if Squares
// Initialize a two-dimensional array. 
 
class Squares {  
  public static void Main() {  
    int[,] sqrs = { 
      { 1, 1 }, 
      { 2, 4 }, 
      { 3, 9 }, 
      { 4, 16 }, 
      { 5, 25 }, 
      { 6, 36 }, 
      { 7, 49 }, 
      { 8, 64 }, 
      { 9, 81 }, 
      { 10, 100 } 
    }; 
    int i, j; 
 
    for(i=0; i < 10; i++) {  
      for(j=0; j < 2; j++)  
        Console.Write(sqrs[i,j] + " ");   
      Console.WriteLine();  
    }  
  }  
}

#endif

#if Jagged    
// Demonstrate jagged arrays.  

class Jagged {  
  public static void Main() {  
    int[][] jagged = new int[3][];  
    jagged[0] = new int[4];  
    jagged[1] = new int[3];  
    jagged[2] = new int[5];  
  
    int i; 
 
    // store values in first array 
    for(i=0; i < 4; i++)   
      jagged[0][i] = i;  
 
    // store values in second array 
    for(i=0; i < 3; i++)   
      jagged[1][i] = i;  
 
    // store values in third array 
    for(i=0; i < 5; i++)   
      jagged[2][i] = i;  
 
 
    // display values in first array 
    for(i=0; i < 4; i++)   
      Console.Write(jagged[0][i] + " ");  
 
    Console.WriteLine(); 
 
    // display values in second array 
    for(i=0; i < 3; i++)   
      Console.Write(jagged[1][i] + " ");  
 
    Console.WriteLine(); 
 
    // display values in third array 
    for(i=0; i < 5; i++)   
      Console.Write(jagged[2][i] + " ");  
 
    Console.WriteLine(); 
  }  
}

#endif

#if AssignRef
// Assigning array reference variables. 
 
class AssignARef {  
  public static void Main() {  
    int i; 
 
    int[] nums1 = new int[10]; 
    int[] nums2 = new int[10]; 
 
    for(i=0; i < 10; i++) nums1[i] = i; 
 
    for(i=0; i < 10; i++) nums2[i] = -i; 
 
    Console.Write("Here is nums1: "); 
    for(i=0; i < 10; i++) 
      Console.Write(nums1[i] + " ");   
    Console.WriteLine(); 
 
    Console.Write("Here is nums2: "); 
    for(i=0; i < 10; i++) 
      Console.Write(nums2[i] + " ");   
    Console.WriteLine(); 
 
    nums2 = nums1; // now nums2 refers to nums1 
 
    Console.Write("Here is nums2 after assignment: "); 
    for(i=0; i < 10; i++) 
      Console.Write(nums2[i] + " ");   
    Console.WriteLine(); 
 
   // now operate on nums1 array through nums2 
   nums2[3] = 99; 
 
    Console.Write("Here is nums1 after change through nums2: "); 
    for(i=0; i < 10; i++) 
      Console.Write(nums1[i] + " ");   
    Console.WriteLine(); 
  }  
}

#endif

#if LengthDemo
// Use the Length array property.  

class LengthDemo {  
  public static void Main() {  
    int[] nums = new int[10];  
 
    Console.WriteLine("Length of nums is " + nums.Length);  
  
    // use Length to initialize nums 
    for(int i=0; i < nums.Length; i++)  
      nums[i] = i * i;  
  
    // now use Length to display nums  
    Console.Write("Here is nums: "); 
    for(int i=0; i < nums.Length; i++)  
      Console.Write(nums[i] + " ");  
 
    Console.WriteLine(); 
  }  
}

#endif

#if LengthDemo3D
// Use the Length array property on a 3-D array. 
 
class LengthDemo3D {  
  public static void Main() {  
    int[,,] nums = new int[10, 5, 6];  
 
    Console.WriteLine("Length of nums is " + nums.Length);  
  
  }  
}

#endif

#if RevCopy
// Reverse an array. 
 
using System; 
 
class RevCopy {  
  public static void Main() {  
    int i,j; 
    int[] nums1 = new int[10]; 
    int[] nums2 = new int[10]; 
 
    for(i=0; i < nums1.Length; i++) nums1[i] = i; 
 
    Console.Write("Original contents: "); 
    for(i=0; i < nums2.Length; i++) 
      Console.Write(nums1[i] + " ");   
 
    Console.WriteLine(); 
 
    // reverse copy nums1 to nums2 
    if(nums2.Length >= nums1.Length) // make sure nums2 is long enough 
      for(i=0, j=nums1.Length-1; i < nums1.Length; i++, j--) 
        nums2[j] = nums1[i]; 
 
    Console.Write("Reversed contents: "); 
    for(i=0; i < nums2.Length; i++) 
      Console.Write(nums2[i] + " ");   
 
    Console.WriteLine(); 
  } 
}
#endif

#if JaggedLength
// Demonstrate Length with jagged arrays. 
 
using System; 
 
class JaggedLength {  
  public static void Main() {  
    int[][] network_nodes = new int[4][];  
    network_nodes[0] = new int[3];  
    network_nodes[1] = new int[7];  
    network_nodes[2] = new int[2];  
    network_nodes[3] = new int[5];  
 
  
    int i, j; 
 
    // fabricate some fake CPU usage data    
    for(i=0; i < network_nodes.Length; i++)   
      for(j=0; j < network_nodes[i].Length; j++)  
        network_nodes[i][j] = i * j + 70;  
 
 
    Console.WriteLine("Total number of network nodes: " + 
                      network_nodes.Length + "\n"); 
 
    for(i=0; i < network_nodes.Length; i++) {  
      for(j=0; j < network_nodes[i].Length; j++) { 
        Console.Write("CPU usage at node " + i +  
                      " CPU " + j + ": "); 
        Console.Write(network_nodes[i][j] + "% ");  
        Console.WriteLine();  
      } 
      Console.WriteLine();  
    } 
 
  }  
}

#endif

#if ForeachDemo0
// Use the foreach loop.  
 
class ForeachDemo { 
  public static void Main() { 
    int sum = 0; 
    int[] nums = new int[10]; 
 
    // give nums some values 
    for(int i = 0; i < 10; i++)  
      nums[i] = i; 
 
    // use foreach to display and sum the values 
    foreach(int x in nums) { 
      Console.WriteLine("Value is: " + x); 
      sum += x; 
    } 
    Console.WriteLine("Summation: " + sum); 
  } 
}

#endif

#if ForEachDemo1
// Use break with a foreach. 
 
class ForeachDemo { 
  public static void Main() { 
    int sum = 0; 
    int[] nums = new int[10]; 
 
    // give nums some values 
    for(int i = 0; i < 10; i++)  
      nums[i] = i; 
 
    // use foreach to display and sum the values 
    foreach(int x in nums) { 
      Console.WriteLine("Value is: " + x); 
      sum += x; 
      if(x == 4) break; // stop the loop when 4 is obtained 
    } 
    Console.WriteLine("Summation of first 5 elements: " + sum); 
  } 
}

#endif

#if ForeachDemo2
// Use foreach on a two-dimensional array.  
 
class ForeachDemo2 { 
  public static void Main() { 
    int sum = 0; 
    int[,] nums = new int[3,5]; 
 
    // give nums some values 
    for(int i = 0; i < 3; i++)  
      for(int j=0; j < 5; j++) 
        nums[i,j] = (i+1)*(j+1); 
 
    // use foreach to display and sum the values 
    foreach(int x in nums) { 
      Console.WriteLine("Value is: " + x); 
      sum += x; 
    } 
    Console.WriteLine("Summation: " + sum); 
  } 
}

#endif

#if Search
// Search an array using foreach. 
 
class Search { 
  public static void Main() { 
    int[] nums = new int[10]; 
    int val; 
    bool found = false; 
 
    // give nums some values 
    for(int i = 0; i < 10; i++)  
      nums[i] = i; 
 
    val = 5; 
 
    // use foreach to search nums for key 
    foreach(int x in nums) { 
      if(x == val) { 
        found = true; 
        break; 
      } 
    } 
 
    if(found)  
      Console.WriteLine("Value found!"); 
  } 
}

#endif

#if StringDemo
// Introduce string. 
 
class StringDemo {  
  public static void Main() {  
 
    char[] charray = {'A', ' ', 's', 't', 'r', 'i', 'n', 'g', '.' }; 
    string str1 = new string(charray); 
    string str2 = "Another string."; 
 
    Console.WriteLine(str1); 
    Console.WriteLine(str2); 
  }  
}

#endif

#if StrOps
// Some string operations.  
  
class StrOps {   
  public static void Main() {   
    string str1 =  
      "When it comes to .NET programming, C# is #1.";   
    string str2 = string.Copy(str1);  
    string str3 = "C# strings are powerful.";   
    string strUp, strLow; 
    int result, idx;  
  
    Console.WriteLine("str1: " + str1); 
 
    Console.WriteLine("Length of str1: " +   
                       str1.Length);   
   
    // create upper- and lowercase versions of str1  
    strLow = str1.ToLower(); 
    strUp =  str1.ToUpper(); 
    Console.WriteLine("Lowercase version of str1:\n    " + 
                      strLow); 
    Console.WriteLine("Uppercase version of str1:\n    " + 
                      strUp); 
 
    Console.WriteLine();   
 
    // display str1, one char at a time.  
    Console.WriteLine("Display str1, one char at a time."); 
    for(int i=0; i < str1.Length; i++)  
      Console.Write(str1[i]);   
    Console.WriteLine("\n");   
 
    // compare strings 
    if(str1 == str2)   
      Console.WriteLine("str1 == str2");   
    else   
      Console.WriteLine("str1 != str2");   
   
    if(str1 == str3)   
      Console.WriteLine("str1 == str3");   
    else   
      Console.WriteLine("str1 != str3");   
  
    result = str1.CompareTo(str3);  
    if(result == 0)  
      Console.WriteLine("str1 and str3 are equal");  
    else if(result < 0)  
      Console.WriteLine("str1 is less than str3");  
    else  
      Console.WriteLine("str1 is greater than str3");  
  
    Console.WriteLine();   
 
    // assign a new string to str2  
    str2 = "One Two Three One";  
  
    // search string 
    idx = str2.IndexOf("One");  
    Console.WriteLine("Index of first occurrence of One: " + idx);  
    idx = str2.LastIndexOf("One");  
    Console.WriteLine("Index of last occurrence of One: " + idx);  
      
  }   
}

#endif

#if StringArrays
// Demonstrate string arrays.  
 
 
class StringArrays {  
  public static void Main() {  
    string[] str = { "This", "is", "a", "test." };  
  
    Console.WriteLine("Original array: ");  
    for(int i=0; i < str.Length; i++) 
      Console.Write(str[i] + " ");  
    Console.WriteLine("\n");  
  
    // change a string  
    str[1] = "was";  
    str[3] = "test, too!";  
  
    Console.WriteLine("Modified array: "); 
    for(int i=0; i < str.Length; i++) 
      Console.Write(str[i] + " ");  
  }  
}

#endif

#if ConvertDigitsToWords
// Display the digits of an integer using words. 
 
class ConvertDigitsToWords {   
  public static void Main() { 
    int num; 
    int nextdigit; 
    int numdigits; 
    int[] n = new int[20]; 
     
    string[] digits = { "zero", "one", "two", 
                        "three", "four", "five", 
                        "six", "seven", "eight", 
                        "nine" }; 
 
    num = 1908; 
 
    Console.WriteLine("Number: " + num); 
 
    Console.Write("Number in words: "); 
     
    nextdigit = 0; 
    numdigits = 0; 
   
    /* Get individual digits and store in n. 
       These digits are stored in reverse order. */ 
    do { 
      nextdigit = num % 10; 
      n[numdigits] = nextdigit; 
      numdigits++; 
      num = num / 10; 
    } while(num > 0); 
    numdigits--; 
 
    // display words 
    for( ; numdigits >= 0; numdigits--) 
      Console.Write(digits[n[numdigits]] + " "); 
 
    Console.WriteLine(); 
  }   
}

#endif

#if Substr
// Use Substring(). 
 
class SubStr {  
  public static void Main() {  
    string orgstr = "C# makes strings easy."; 
 
    // construct a substring 
    string substr = orgstr.Substring(5, 12); 
     
    Console.WriteLine("orgstr: " + orgstr); 
    Console.WriteLine("substr: " + substr); 
 
  }  
}

#endif

#if StringSwitch
// A string can control a switch statement. 

class StringSwitch {  
  public static void Main() {  
    string[] strs = { "one", "two", "three", "two", "one" }; 
 
    foreach(string s in strs) { 
      switch(s) { 
        case "one": 
          Console.Write(1); 
          break; 
        case "two": 
          Console.Write(2); 
          break; 
        case "three": 
          Console.Write(3); 
          break; 
      } 
    } 
    Console.WriteLine(); 
 
  } 
}
#endif

}

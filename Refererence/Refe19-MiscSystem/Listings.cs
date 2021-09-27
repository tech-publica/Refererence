using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Refe19_MiscSystem
{

#if ReadAndParse
// Implement the Pythagorean Theorem. 
class Pythagorean {     
  public static void Main() {     
    double s1; 
    double s2; 
    double hypot; 
    string str; 
 
    Console.WriteLine("Enter length of first side: "); 
    str = Console.ReadLine(); 
    s1 = Double.Parse(str); 
 
    Console.WriteLine("Enter length of second side: "); 
    str = Console.ReadLine(); 
    s2 = Double.Parse(str); 
 
    hypot = Math.Sqrt(s1*s1 + s2*s2); 
  
    Console.WriteLine("Hypotenuse is " + hypot); 
  }     
}
#endif

#if CharMethods
// Demonstrate several Char methods. 
class CharDemo {     
  public static void Main() {     
    string str = "This is a test. $23"; 
    int i; 
 
    for(i=0; i < str.Length; i++) { 
      Console.Write(str[i] + " is"); 
      if(Char.IsDigit(str[i])) 
        Console.Write(" digit"); 
      if(Char.IsLetter(str[i])) 
        Console.Write(" letter"); 
      if(Char.IsLower(str[i])) 
        Console.Write(" lowercase"); 
      if(Char.IsUpper(str[i])) 
        Console.Write(" uppercase"); 
      if(Char.IsSymbol(str[i])) 
        Console.Write(" symbol"); 
      if(Char.IsSeparator(str[i])) 
        Console.Write(" separator"); 
      if(Char.IsWhiteSpace(str[i])) 
        Console.Write(" whitespace"); 
      if(Char.IsPunctuation(str[i])) 
        Console.Write(" punctuation"); 
 
      Console.WriteLine(); 
    } 
 
    Console.WriteLine("Original: " + str); 
 
    // Convert to upper case.    
    string newstr = ""; 
    for(i=0; i < str.Length; i++) 
      newstr += Char.ToUpper(str[i]); 
  
    Console.WriteLine("Uppercased: " + newstr); 
 
  }     
}
#endif

#if SortArray
// Sort an array and search for a value. 
 
class SortDemo {     
  public static void Main() {     
    int[] nums = { 5, 4, 6, 3, 14, 9, 8, 17, 1, 24, -1, 0 }; 
   
    // Display original order. 
    Console.Write("Original order: "); 
    foreach(int i in nums)  
      Console.Write(i + " "); 
    Console.WriteLine(); 
 
    // Sort the array. 
    Array.Sort(nums); 
 
    // Display sorted order. 
    Console.Write("Sorted order:   "); 
    foreach(int i in nums)  
      Console.Write(i + " "); 
    Console.WriteLine(); 
 
 
    // Search for 14. 
    int idx = Array.BinarySearch(nums, 14); 
 
    Console.WriteLine("Index of 14 is " + idx); 
  }     
}

#endif

#if SortWithComparable
// Sort and search an array of objects. 

class MyClass : IComparable<MyClass> { 
  public int i; 
  
  public MyClass(int x) { i = x; } 
 
  // Implement IComparable<MyClass>. 
  public int CompareTo(MyClass v) { 
    return i - v.i; 
  } 
 
} 
  
class SortDemo {     
  public static void Main() {     
    MyClass[] nums = new MyClass[5]; 
 
    nums[0] = new MyClass(5); 
    nums[1] = new MyClass(2); 
    nums[2] = new MyClass(3); 
    nums[3] = new MyClass(4); 
    nums[4] = new MyClass(1); 
   
    // Display original order. 
    Console.Write("Original order: "); 
    foreach(MyClass o in nums)  
      Console.Write(o.i + " "); 
    Console.WriteLine(); 
 
    // Sort the array. 
    Array.Sort(nums); 
 
    // Display sorted order. 
    Console.Write("Sorted order:   "); 
    foreach(MyClass o in nums)  
      Console.Write(o.i + " "); 
    Console.WriteLine(); 
 
    // Search for MyClass(2). 
    MyClass x = new MyClass(2); 
    int idx = Array.BinarySearch(nums, x); 
 
    Console.WriteLine("Index of MyClass(2) is " + idx); 
  }     
}

#endif

#if ReverseArray

// Reverse an array. 
 
class ReverseDemo {     
  public static void Main() {     
    int[] nums = { 1, 2, 3, 4, 5 }; 
   
    // Display original order. 
    Console.Write("Original order: "); 
    foreach(int i in nums)  
      Console.Write(i + " "); 
    Console.WriteLine(); 
 
    // Reverse the entire array. 
    Array.Reverse(nums); 
 
    // Display reversed order. 
    Console.Write("Reversed order: "); 
    foreach(int i in nums)  
      Console.Write(i + " "); 
    Console.WriteLine(); 
 
    // Reverse a range. 
    Array.Reverse(nums, 1, 3); 
 
    // Display reversed order. 
    Console.Write("Range reversed: "); 
    foreach(int i in nums)  
      Console.Write(i + " "); 
    Console.WriteLine(); 
  } 
}

#endif

#if CopyDemo
// Copy an array. 
class CopyDemo {     
  public static void Main() {     
    int[] source = { 1, 2, 3, 4, 5 }; 
    int[] target = { 11, 12, 13, 14, 15 }; 
    int[] source2 = { -1, -2, -3, -4, -5 }; 
 
    // Display source. 
    Console.Write("source: "); 
    foreach(int i in source)  
      Console.Write(i + " "); 
    Console.WriteLine(); 
 
    // Display original target. 
    Console.Write("Original contents of target: "); 
    foreach(int i in target)  
      Console.Write(i + " "); 
    Console.WriteLine(); 
 
    // Copy the entire array. 
    Array.Copy(source, target, source.Length); 
 
    // Display copy. 
    Console.Write("target after copy:  "); 
    foreach(int i in target)  
      Console.Write(i + " "); 
    Console.WriteLine(); 
 
    // Copy into middle of target. 
    Array.Copy(source2, 2, target, 3, 2); 
 
    // Display copy. 
    Console.Write("target after copy:  "); 
    foreach(int i in target)  
      Console.Write(i + " "); 
    Console.WriteLine(); 
  } 
}

#endif

#if Predicate
// Demonstrate Predicate delegate. 
class PredDemo {      
 
  // A predicate method.  
  // Returns true if v is negative. 
  static bool isNeg(int v) { 
    if(v < 0) return true; 
    return false; 
  } 
 
  public static void Main() {      
    int[] nums = { 1, 4, -1, 5, -9 }; 
    
    Console.Write("Contents of nums: ");  
    foreach(int i in nums)   
      Console.Write(i + " ");  
    Console.WriteLine();  
  
    // First see if nums contains a negative value. 
    if(Array.Exists(nums, PredDemo.isNeg)) { 
      Console.WriteLine("nums contains a negative value."); 
 
      // Now, find first negative value. 
      int x = Array.Find(nums, PredDemo.isNeg); 
      Console.WriteLine("First negative value is : " + x); 
    } 
    else  
      Console.WriteLine("nums contains no negative values."); 
  }      
}

#endif

#if Action
// Demonstrate an Action 
  
class MyClass { 
  public int i;  
   
  public MyClass(int x) { i = x; }  
}  
  
class ActionDemo {       
 
  // An Action method. 
  // Displays the value it is passed. 
  static void show(MyClass o) { 
    Console.Write(o.i + " "); 
  } 
 
  // Another Action method. 
  // Negates the value it is passed. 
  static void neg(MyClass o) {  
    o.i = -o.i; 
  }  
  
  public static void Main() {       
    MyClass[] nums = new MyClass[5];  
  
    nums[0] = new MyClass(5);  
    nums[1] = new MyClass(2);  
    nums[2] = new MyClass(3);  
    nums[3] = new MyClass(4);  
    nums[4] = new MyClass(1);  
     
    Console.Write("Contents of nums: ");   
 
    // Use action to show the values. 
    Array.ForEach(nums, ActionDemo.show); 
 
    Console.WriteLine();   
 
    // Use action to negate the values. 
    Array.ForEach(nums, ActionDemo.neg); 
   
    Console.Write("Contents of nums negated: ");   
 
    // Use action to negate the values again. 
    Array.ForEach(nums, ActionDemo.show); 
 
    Console.WriteLine();   
  }       
}

#endif

#if Random
// An automated pair of dice. 
  
class RandDice {     
  public static void Main() {     
    Random ran = new Random(); 
 
    Console.Write(ran.Next(1, 7) + " ");  
    Console.WriteLine(ran.Next(1, 7));  
  }     
}

#endif

}

using System;

namespace Refererence.Refe20_Strings
{

#if CompareStrings
// Compare strings. 
class CompareDemo { 
  public static void Main() { 
    string str1 = "one"; 
    string str2 = "one"; 
    string str3 = "ONE"; 
    string str4 = "two"; 
    string str5 = "one, too"; 
 
 
    if(String.Compare(str1, str2) == 0) 
      Console.WriteLine(str1 + " and " + str2 + 
                        " are equal."); 
    else 
      Console.WriteLine(str1 + " and " + str2 + 
                        " are not equal."); 
 
 
    if(String.Compare(str1, str3) == 0) 
      Console.WriteLine(str1 + " and " + str3 + 
                        " are equal."); 
    else 
      Console.WriteLine(str1 + " and " + str3 + 
                        " are not equal."); 
 
    if(String.Compare(str1, str3, true) == 0) 
      Console.WriteLine(str1 + " and " + str3 + 
                        " are equal ignoring case."); 
    else 
      Console.WriteLine(str1 + " and " + str3 + 
                        " are not equal ignoring case."); 
 
     if(String.Compare(str1, str5) == 0) 
      Console.WriteLine(str1 + " and " + str5 + 
                        " are equal."); 
    else 
      Console.WriteLine(str1 + " and " + str5 + 
                        " are not equal."); 
  
    if(String.Compare(str1, 0, str5, 0, 3) == 0) 
      Console.WriteLine("First part of " + str1 + " and " + 
                        str5 + " are equal."); 
    else 
      Console.WriteLine("First part of " + str1 + " and " + 
                        str5 + " are not equal."); 
 
    int result = String.Compare(str1, str4); 
    if(result < 0) 
      Console.WriteLine(str1 + " is less than " + str4); 
    else if(result > 0) 
      Console.WriteLine(str1 + " is greater than " + str4); 
    else 
      Console.WriteLine(str1 + " equals " + str4); 
  } 
}

#endif

#if Concat
// Demonstrate Concat(). 
class ConcatDemo { 
  public static void Main() { 
 
    string result = String.Concat("This ", "is ", "a ", 
                                  "test ", "of ", "the ", 
                                  "String ", "class."); 
 
    Console.WriteLine("result: " + result); 
 
  } 
}

#endif

#if ConcatObjects
// Demonstrate the object form of Concat().  
class MyClass { 
  public static int count = 0; 
 
  public MyClass() { count++; } 
} 
 
class ConcatDemo {  
  public static void Main() {  
  
    string result = String.Concat("The value is " + 19); 
    Console.WriteLine("result: " + result);  
 
    result = String.Concat("hello ", 88, " ", 20.0, " ", 
                           false, " ",  23.45M);  
    Console.WriteLine("result: " + result);  
 
    MyClass mc = new MyClass(); 
 
    result = String.Concat(mc, " current count is ", 
                           MyClass.count); 
    Console.WriteLine("result: " + result);  
  }  
}

#endif

#if SearchStrings
// Search strings. 
 
class StringSearchDemo { 
  public static void Main() { 
    string str = "C# has powerful string handling."; 
    int idx; 
 
    Console.WriteLine("str: " + str); 
 
    idx = str.IndexOf('h'); 
    Console.WriteLine("Index of first 'h': " + idx); 
 
    idx = str.LastIndexOf('h'); 
    Console.WriteLine("Index of last 'h': " + idx); 
 
    idx = str.IndexOf("ing"); 
    Console.WriteLine("Index of first \"ing\": " + idx); 
 
    idx = str.LastIndexOf("ing"); 
    Console.WriteLine("Index of last \"ing\": " + idx); 
 
    char[] chrs = { 'a', 'b', 'c' }; 
    idx = str.IndexOfAny(chrs); 
    Console.WriteLine("Index of first 'a', 'b', or 'c': " + idx); 
 
    if(str.StartsWith("C# has")) 
      Console.WriteLine("str begins with \"C# has\""); 
 
    if(str.EndsWith("ling.")) 
      Console.WriteLine("str ends with \"ling.\""); 
  } 
}

#endif

#if Contains
// Demonstrate Contains(). 
  
class ContainsDemo {  
  public static void Main() {  
    string str = "C# combines power with performance."; 
 
    if(str.Contains("power"))  
      Console.WriteLine("The sequence power was found."); 
 
    if(str.Contains("pow")) 
      Console.WriteLine("The sequence pow was found."); 
 
    if(!str.Contains("powerful")) 
      Console.WriteLine("The sequence powerful was not found."); 
  }  
}

#endif

#if SplitAndJoin
// Split and join strings. 

class SplitAndJoinDemo { 
  public static void Main() { 
    string str = "One if by land, two if by sea."; 
    char[] seps = {' ', '.', ',' }; 
 
    // Split the string into parts. 
    string[] parts = str.Split(seps); 
    Console.WriteLine("Pieces from split: "); 
    for(int i=0; i < parts.Length; i++) 
      Console.WriteLine(parts[i]); 
    
    // Now, join the parts. 
    string whole = String.Join(" | ", parts); 
    Console.WriteLine("Result of join: "); 
    Console.WriteLine(whole); 
  } 
}

#endif

#if TokenizeDemo
// Tokenize strings. 
class TokenizeDemo { 
  public static void Main() { 
    string[] input = { 
                      "100 + 19", 
                      "100 / 3.3", 
                      "-3 * 9", 
                      "100 - 87" 
                     }; 
    char[] seps = {' '}; 
 
    for(int i=0; i < input.Length; i++) { 
      // split string into parts 
      string[] parts = input[i].Split(seps); 
      Console.Write("Command: "); 
      for(int j=0; j < parts.Length; j++) 
        Console.Write(parts[j] + " "); 
    
      Console.Write(", Result: "); 
      double n = Double.Parse(parts[0]); 
      double n2 = Double.Parse(parts[2]); 
 
      switch(parts[1]) { 
        case "+": 
          Console.WriteLine(n + n2); 
          break; 
        case "-": 
          Console.WriteLine(n - n2); 
          break; 
        case "*": 
          Console.WriteLine(n * n2); 
          break; 
        case "/": 
          Console.WriteLine(n / n2); 
          break; 
      } 
    } 
  } 
}

#endif

#if TrimAndPad
// Trimming and padding. 
  
class TrimPadDemo {  
  public static void Main() {  
    string str = "test"; 
 
    Console.WriteLine("Original string: " + str); 
     
    // Pad on left with spaces. 
    str = str.PadLeft(10); 
    Console.WriteLine("|" + str + "|"); 
 
    // Pad on right with spaces. 
    str = str.PadRight(20); 
    Console.WriteLine("|" + str + "|"); 
 
    // Trim spaces. 
    str = str.Trim(); 
    Console.WriteLine("|" + str + "|"); 
 
    // Pad on left with #s. 
    str = str.PadLeft(10, '#'); 
    Console.WriteLine("|" + str + "|"); 
 
    // Pad on right with #s. 
    str = str.PadRight(20, '#'); 
    Console.WriteLine("|" + str + "|"); 
 
    // Trim #s. 
    str = str.Trim('#'); 
    Console.WriteLine("|" + str + "|"); 
  } 
}

#endif

#if InsertReplaceRemove

// Inserting, replacing, and removing. 
  
class InsRepRevDemo {  
  public static void Main() {  
    string str = "This test"; 
 
    Console.WriteLine("Original string: " + str); 
     
    // Insert 
    str = str.Insert(5, "is a "); 
    Console.WriteLine(str); 
 
    // Replace string 
    str = str.Replace("is", "was"); 
    Console.WriteLine(str); 
 
    // Replace characters 
    str = str.Replace('a', 'X'); 
    Console.WriteLine(str); 
 
    // Remove 
    str = str.Remove(4, 5); 
    Console.WriteLine(str); 
  } 
}

#endif

#if Substring
// Use Substring(). 

class SubstringDemo {  
  public static void Main() {  
    string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
 
    Console.WriteLine("str: " + str); 
     
    Console.Write("str.Substring(15): "); 
    string substr = str.Substring(15); 
    Console.WriteLine(substr); 
 
    Console.Write("str.Substring(0, 15): "); 
    substr = str.Substring(0, 15); 
    Console.WriteLine(substr); 
  } 
}

#endif

}

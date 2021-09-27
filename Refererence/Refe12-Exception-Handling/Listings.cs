
using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Refe12_Exception_Handling
{

#if IndexOutOfRangeException
// Demonstrate exception handling. 
class ExcDemo1 { 
  public static void Main() { 
    int[] nums = new int[4]; 
 
    try { 
      Console.WriteLine("Before exception is generated."); 
 
      // Generate an index out-of-bounds exception. 
      for(int i=0; i < 10; i++) { 
        nums[i] = i; 
        Console.WriteLine("nums[{0}]: {1}", i, nums[i]); 
      } 
 
      Console.WriteLine("this won't be displayed"); 
    } 
    catch (IndexOutOfRangeException) { 
      // catch the exception 
      Console.WriteLine("Index out-of-bounds!"); 
    } 
    Console.WriteLine("After catch statement."); 
  } 
}


#endif

#if CatchException

/* An exception can be generated by one 
   method and caught by another. */ 
 

class ExcTest { 
  // Generate an exception. 
  public static void genException() { 
    int[] nums = new int[4];  
 
    Console.WriteLine("Before exception is generated."); 
  
    // Generate an index out-of-bounds exception. 
    for(int i=0; i < 10; i++) { 
      nums[i] = i; 
      Console.WriteLine("nums[{0}]: {1}", i, nums[i]); 
    } 
 
    Console.WriteLine("this won't be displayed");  
  } 
}     
 
class ExcDemo2 {  
  public static void Main() {  
  
    try {  
      ExcTest.genException(); 
    }  
    catch (IndexOutOfRangeException) {  
      // catch the exception  
      Console.WriteLine("Index out-of-bounds!");  
    }  
    Console.WriteLine("After catch statement.");  
  }  
}

#endif



#if NotHandled
// Let the C# runtime system handle the error. 

class NotHandled { 
  public static void Main() { 
    int[] nums = new int[4]; 
 
    Console.WriteLine("Before exception is generated."); 
 
    // Generate an index out-of-bounds exception. 
    for(int i=0; i < 10; i++) { 
      nums[i] = i; 
      Console.WriteLine("nums[{0}]: {1}", i, nums[i]); 
    } 
 
  } 
}

#endif

#if WrongExceptionInCatch
// This won't work! 
 
using System; 
 
class ExcTypeMismatch {  
  public static void Main() {  
    int[] nums = new int[4];  
  
    try {  
      Console.WriteLine("Before exception is generated."); 
  
      // Generate an index out-of-bounds exception. 
      for(int i=0; i < 10; i++) { 
        nums[i] = i; 
        Console.WriteLine("nums[{0}]: {1}", i, nums[i]); 
      } 
 
      Console.WriteLine("this won't be displayed");  
    }  
 
    /* Can't catch an array boundary error with a 
       DivideByZeroException. */ 
    catch (DivideByZeroException) {  
      // catch the exception  
      Console.WriteLine("Index out-of-bounds!");  
    }  
    Console.WriteLine("After catch statement.");  
  }  
}

#endif



#if RightExceptionInCatch
// Handle error gracefully and continue. 
 
class ExcDemo3 { 
  public static void Main() { 
    int[] numer = { 4, 8, 16, 32, 64, 128 }; 
    int[] denom = { 2, 0, 4, 4, 0, 8 }; 
 
    for(int i=0; i < numer.Length; i++) { 
      try { 
        Console.WriteLine(numer[i] + " / " + 
                          denom[i] + " is " + 
                          numer[i]/denom[i]); 
      } 
      catch (DivideByZeroException) { 
        // catch the exception 
        Console.WriteLine("Can't divide by Zero!"); 
      } 
    } 
  } 
}

#endif


#if MultiCatch
// Use multiple catch statements. 
 
class ExcDemo4 { 
  public static void Main() { 
    // Here, numer is longer than denom. 
    int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 }; 
    int[] denom = { 2, 0, 4, 4, 0, 8 }; 
 
    for(int i=0; i < numer.Length; i++) { 
      try { 
        Console.WriteLine(numer[i] + " / " + 
                           denom[i] + " is " + 
                           numer[i]/denom[i]); 
      } 
      catch (DivideByZeroException) { 
        // catch the exception 
        Console.WriteLine("Can't divide by Zero!"); 
      } 
      catch (IndexOutOfRangeException) { 
        // catch the exception 
        Console.WriteLine("No matching element found."); 
      } 
    } 
  } 
}

#endif


#if CatchAll
// Use the "catch all" catch statement. 
class ExcDemo5 { 
  public static void Main() { 
    // Here, numer is longer than denom. 
    int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 }; 
    int[] denom = { 2, 0, 4, 4, 0, 8 }; 
 
    for(int i=0; i < numer.Length; i++) { 
      try { 
        Console.WriteLine(numer[i] + " / " + 
                           denom[i] + " is " + 
                           numer[i]/denom[i]); 
      } 
      catch { 
        Console.WriteLine("Some exception occurred."); 
      } 
    } 
  } 
}

#endif

#if NestedTry
// Use a nested try block. 
 
class NestTrys { 
  public static void Main() { 
    // Here, numer is longer than denom. 
    int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 }; 
    int[] denom = { 2, 0, 4, 4, 0, 8 }; 
 
    try { // outer try 
      for(int i=0; i < numer.Length; i++) { 
        try { // nested try 
          Console.WriteLine(numer[i] + " / " + 
                             denom[i] + " is " + 
                             numer[i]/denom[i]); 
        } 
        catch (DivideByZeroException) { 
          // catch the exception 
          Console.WriteLine("Can't divide by Zero!"); 
        } 
      } 
    }  
    catch (IndexOutOfRangeException) { 
      // catch the exception 
      Console.WriteLine("No matching element found."); 
      Console.WriteLine("Fatal error -- program terminated."); 
    } 
  } 
}

#endif

#if ManualThrow
// Manually throw an exception. 
 
class ThrowDemo { 
  public static void Main() { 
    try { 
      Console.WriteLine("Before throw."); 
      throw new DivideByZeroException(); 
    } 
    catch (DivideByZeroException) { 
      // catch the exception 
      Console.WriteLine("Exception caught."); 
    } 
    Console.WriteLine("After try/catch block."); 
  } 
}

#endif

#if Rethrow
// Rethrow an exception. 
 
class Rethrow { 
  public static void genException() { 
    // here, numer is longer than denom 
    int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 }; 
    int[] denom = { 2, 0, 4, 4, 0, 8 }; 
 
    for(int i=0; i<numer.Length; i++) { 
      try { 
        Console.WriteLine(numer[i] + " / " + 
                          denom[i] + " is " + 
                          numer[i]/denom[i]); 
      } 
      catch (DivideByZeroException) { 
        // catch the exception 
        Console.WriteLine("Can't divide by Zero!"); 
      } 
      catch (IndexOutOfRangeException) { 
        // catch the exception 
        Console.WriteLine("No matching element found."); 
        throw; // rethrow the exception 
      } 
    } 
  }   
} 
 


class RethrowDemo { 
  public static void Main() { 
    try { 
      Rethrow.genException(); 
    } 
    catch(IndexOutOfRangeException) { 
      // recatch exception 
     Console.WriteLine("Fatal error -- " + 
                       "program terminated."); 
    } 
  } 
}

#endif


#if Finally 
 //Use Finally

class UseFinally { 
  public static void genException(int what) { 
    int t; 
    int[] nums = new int[2]; 
 
    Console.WriteLine("Receiving " + what); 
    try { 
      switch(what) { 
        case 0:  
          t = 10 / what; // generate div-by-zero error 
          break; 
        case 1: 
          nums[4] = 4; // generate array index error. 
          break; 
        case 2: 
          return; // return from try block 
      } 
    } 
    catch (DivideByZeroException) { 
      // catch the exception 
      Console.WriteLine("Can't divide by Zero!"); 
      return; // return from catch 
    } 
    catch (IndexOutOfRangeException) { 
      // catch the exception 
      Console.WriteLine("No matching element found."); 
    } 
    finally { 
      Console.WriteLine("Leaving try."); 
    } 
  }   
} 
 
class FinallyDemo { 
  public static void Main() { 
     
    for(int i=0; i < 3; i++) { 
      UseFinally.genException(i); 
      Console.WriteLine(); 
    } 
  } 
}

#endif


#if ExceptionMembers
// Using Exception members. 
 
class ExcTest { 
  public static void genException() { 
    int[] nums = new int[4];  
 
    Console.WriteLine("Before exception is generated."); 
 
    // Generate an index out-of-bounds exception. 
      for(int i=0; i < 10; i++) { 
        nums[i] = i; 
        Console.WriteLine("nums[{0}]: {1}", i, nums[i]); 
      } 
 
    Console.WriteLine("this won't be displayed");  
  } 
}     
 
class UseExcept {  
  public static void Main() {  
  
    try {  
      ExcTest.genException(); 
    }  
    catch (IndexOutOfRangeException exc) {  
      // catch the exception  
      Console.WriteLine("Standard message is: "); 
      Console.WriteLine(exc); // calls ToString() 
      Console.WriteLine("Stack trace: " + exc.StackTrace); 
      Console.WriteLine("Message: " + exc.Message); 
      Console.WriteLine("TargetSite: " + exc.TargetSite); 
    }  
    Console.WriteLine("After catch statement.");  
  }  
}

#endif


#if NullReferenceException

// Use the NullReferenceException. 
 
class X { 
  int x; 
  public X(int a) { 
    x = a; 
  } 
 
  public int add(X o) { 
    return x + o.x; 
  } 
} 
   
// Demonstrate NullReferenceException. 
class NREDemo {   
  public static void Main() {   
    X p = new X(10); 
    X q = null; // q is explicitly assigned null 
    int val; 
 
    try { 
      val = p.add(q); // this will lead to an exception 
    } catch (NullReferenceException) { 
      Console.WriteLine("NullReferenceException!"); 
      Console.WriteLine("fixing...\n"); 
 
      // now, fix it 
      q = new X(9);   
      val = p.add(q); 
    } 
 
    Console.WriteLine("val is {0}", val); 
  
  }  
}

#endif

#if RangeArrayWithErrors
// Use a custom Exception for RangeArray errors.   
  
// Create a RangeArray exception. 
class RangeArrayException : ApplicationException { 
  // Implement the standard constructors 
  public RangeArrayException() : base() { } 
  public RangeArrayException(string str) : base(str) { }  
 
  // Override ToString for RangeArrayException. 
  public override string ToString() { 
    return Message; 
  } 
} 
 
// An improved version of RangeArray. 
class RangeArray {   
  // private data 
  int[] a; // reference to underlying array   
  int lowerBound; // lowest index 
  int upperBound; // greatest index 
 
  int len; // underlying var for Length property 
    
  // Construct array given its size.  
  public RangeArray(int low, int high) {  
    high++; 
    if(high <= low) { 
      throw new RangeArrayException("Low index not less than high."); 
    } 
    a = new int[high - low];  
    len = high - low;   
 
    lowerBound = low; 
    upperBound = --high; 
  }  
  
  // Read-only Length property.  
  public int Length {  
    get {  
      return len;  
    }  
  }  
 
  // This is the indexer for RangeArray.  
  public int this[int index] {  
    // This is the get accessor.  
    get {  
      if(ok(index)) {  
        return a[index - lowerBound];  
      } else {  
        throw new RangeArrayException("Range Error."); 
      } 
    }  
  
    // This is the set accessor. 
    set {  
      if(ok(index)) {  
        a[index - lowerBound] = value;  
      }  
      else throw new RangeArrayException("Range Error."); 
    }  
  }  
  
  // Return true if index is within bounds.  
  private bool ok(int index) {  
    if(index >= lowerBound & index <= upperBound) return true;  
    return false;  
  }  
}   
   
// Demonstrate the index-range array.  
class RangeArrayDemo {   
  public static void Main() {   
    try { 
      RangeArray ra = new RangeArray(-5, 5);  
      RangeArray ra2 = new RangeArray(1, 10);  
 
      // Demonstrate ra 
      Console.WriteLine("Length of ra: " + ra.Length); 
 
      for(int i = -5; i <= 5; i++) 
        ra[i] = i; 
   
      Console.Write("Contents of ra: "); 
      for(int i = -5; i <= 5; i++) 
        Console.Write(ra[i] + " "); 
 
      Console.WriteLine("\n"); 
 
      // Demonstrate ra2 
      Console.WriteLine("Length of ra2: " + ra2.Length); 
 
      for(int i = 1; i <= 10; i++) 
        ra2[i] = i; 
 
      Console.Write("Contents of ra2: "); 
      for(int i = 1; i <= 10; i++) 
        Console.Write(ra2[i] + " "); 
 
      Console.WriteLine("\n"); 
 
    } catch (RangeArrayException exc) { 
       Console.WriteLine(exc); 
    } 
 
    // Now, demonstrate some errors. 
    Console.WriteLine("Now generate some range errors."); 
 
    // Use an invalid constructor. 
    try { 
      RangeArray ra3 = new RangeArray(100, -10); // Error 
   
    } catch (RangeArrayException exc) { 
       Console.WriteLine(exc); 
    } 
 
    // Use an invalid index. 
    try { 
      RangeArray ra3 = new RangeArray(-2, 2);  
 
      for(int i = -2; i <= 2; i++) 
        ra3[i] = i; 
 
      Console.Write("Contents of ra3: "); 
      for(int i = -2; i <= 10; i++) // generate range error 
        Console.Write(ra3[i] + " "); 
 
    } catch (RangeArrayException exc) { 
       Console.WriteLine(exc); 
    } 
  }  
}

#endif


#if CatchOrder
// Derived exceptions must appear before base class exceptions. 
 
// Create an exception. 
class ExceptA : ApplicationException { 
  public ExceptA() : base() { } 
  public ExceptA(string str) : base(str) { } 
 
  public override string ToString() { 
    return Message; 
  } 
} 
 
// Create an exception derived from ExceptA 
class ExceptB : ExceptA { 
  public ExceptB() : base() { } 
  public ExceptB(string str) : base(str) { } 
 
  public override string ToString() { 
    return Message;  
  } 
} 
 
class OrderMatters { 
  public static void Main() { 
    for(int x = 0; x < 3; x++) { 
      try { 
        if(x==0) throw new ExceptA("Caught an ExceptA exception"); 
        else if(x==1) throw new ExceptB("Caught an ExceptB exception"); 
        else throw new Exception(); 
      } 
      catch (ExceptB exc) { 
        // catch the exception 
        Console.WriteLine(exc); 
      } 
      catch (ExceptA exc) { 
        // catch the exception 
        Console.WriteLine(exc); 
      } 
      catch (Exception exc) { 
        Console.WriteLine(exc); 
      } 
    } 
  } 
}

#endif

#if CheckedExp

// Using checked and unchecked. 
 

class CheckedDemo {  
  public static void Main() {  
    byte a, b; 
    byte result; 
 
    a = 127; 
    b = 127; 
  
    try {  
      result = unchecked((byte)(a * b)); 
      Console.WriteLine("Unchecked result: " + result); 
 
      result = checked((byte)(a * b)); // this causes exception 
      Console.WriteLine("Checked result: " + result); // won't execute 
    }  
    catch (OverflowException exc) {  
      // catch the exception  
      Console.WriteLine(exc); 
    }  
  }  
}

#endif

#if CheckedBlock
// Using checked and unchecked with statement blocks. 
 
class CheckedBlocks {  
  public static void Main() {  
    byte a, b; 
    byte result; 
 
    a = 127; 
    b = 127; 
  
    try {  
      unchecked { 
        a = 127; 
        b = 127; 
        result = unchecked((byte)(a * b)); 
        Console.WriteLine("Unchecked result: " + result); 
 
        a = 125; 
        b = 5; 
        result = unchecked((byte)(a * b)); 
        Console.WriteLine("Unchecked result: " + result); 
      } 
 
      checked { 
        a = 2; 
        b = 7; 
        result = checked((byte)(a * b)); // this is OK 
        Console.WriteLine("Checked result: " + result); 
 
        a = 127; 
        b = 127; 
        result = checked((byte)(a * b)); // this causes exception 
        Console.WriteLine("Checked result: " + result); // won't execute 
      } 
    }  
    catch (OverflowException exc) {  
      // catch the exception  
      Console.WriteLine(exc); 
    }  
  }  
}
#endif

}
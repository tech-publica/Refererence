
using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Refe18_MiscLanguage
{
#if Unsafe


// Demonstrate pointers and unsafe. 
 
class UnsafeCode { 
  // Mark Main as unsafe. 
  unsafe public static void Main() { 
    int count = 99; 
    int* p; // create an int pointer 
 
    p = &count; // put address of count into p 
 
    Console.WriteLine("Initial value of count is " + *p); 
 
    *p = 10; // assign 10 to count via p 
     
    Console.WriteLine("New value of count is " + *p); 
  } 
}

#endif

#if Fixed
// Demonstrate fixed. 
 
class Test { 
  public int num; 
  public Test(int i) { num = i; } 
} 
 
class FixedCode { 
  // Mark Main as unsafe. 
  unsafe public static void Main() { 
    Test o = new Test(19); 
 
    fixed (int* p = &o.num) { // use fixed to put address of o.num into p 
 
      Console.WriteLine("Initial value of o.num is " + *p); 
   
      *p = 10; // assign the to count via p 
     
      Console.WriteLine("New value of o.num is " + *p); 
    } 
  } 
}

#endif
   

#if PointerArithmetic
// Demonstrate the effects of pointer arithmethic. 
 
using System; 
 
class PtrArithDemo { 
  unsafe public static void Main() { 
    int x; 
    int i;  
    double d; 
 
    int* ip = &i; 
    double* fp = &d; 
 
    Console.WriteLine("int     double\n"); 
 
    for(x=0; x < 10; x++) { 
       Console.WriteLine((uint) (ip) + " " + 
                         (uint) (fp)); 
       ip++; 
       fp++; 
    } 
  } 
}

#endif
   

#if PointerComparison
// Demonstrate pointer comparison. 
 

class PtrCompDemo { 
  unsafe public static void Main() { 
 
    int[] nums = new int[11]; 
    int x; 
 
    // find the middle 
    fixed (int* start = &nums[0]) {  
      fixed(int* end = &nums[nums.Length-1]) {  
        for(x=0; start+x <= end-x; x++) ; 
      } 
    } 
    Console.WriteLine("Middle element is " + x); 
  } 
}
#endif


#if ArrayAddress
// An array name with an index yields a pointer to the start of the array. 
 
class PtrArray { 
  unsafe public static void Main() { 
    int[] nums = new int[10]; 
 
    fixed(int* p = &nums[0], p2 = nums) { 
      if(p == p2) 
        Console.WriteLine("p and p2 point to same address."); 
    } 
  } 
}
#endif


#if PointerAddressing
// Index a pointer as if it were an array. 

class PtrIndexDemo { 
  unsafe public static void Main() { 
    int[] nums = new int[10]; 
 
    // index pointer 
    Console.WriteLine("Index pointer like array."); 
    fixed (int* p = nums) { 
      for(int i=0; i < 10; i++)  
        p[i] = i; // index pointer like array 
 
      for(int i=0; i < 10; i++)  
        Console.WriteLine("p[{0}]: {1} ", i, p[i]); 
    } 
 
    // use pointer arithmetic 
    Console.WriteLine("\nUse pointer arithmetic."); 
    fixed (int* p = nums) { 
      for(int i=0; i < 10; i++)  
        *(p+i) = i; // use pointer arithmetic 
 
      for(int i=0; i < 10; i++)  
        Console.WriteLine("*(p+{0}): {1} ", i, *(p+i)); 
    } 
  } 
}

#endif


#if PointerToString
// Use fixed to get a pointer to the start of a string. 
class FixedString { 
  unsafe public static void Main() { 
    string str = "this is a test";
    string ostr = str;
 
    // Point p to start of str. 
    fixed(char* p = str) { 
 
      // Display the contents of str via p. 
      for(int i=0; p[i] != 0; i++) 
        Console.Write(p[i]);
      Console.WriteLine();

      p[11] = 'o';
  
    } 
 
    Console.WriteLine(str);
    Console.WriteLine(ostr); 
     
  } 
}
#endif
    
#if MultipleIndirect

class MultipleIndirect { 
  unsafe public static void Main() { 
    int x;    // holds an int value  
    int* p;  // holds an int pointer 
    int** q; // holds an pointer to an int pointer 
 
    x = 10; 
    p = &x; // put address of x into p 
    q = &p; // put address of p into q 
 
    Console.WriteLine(**q); // display the value of x  
  } 
}
#endif



#if UseStackAlloc
// Demonstrate stackalloc. 
 
class UseStackAlloc { 
  unsafe public static void Main() { 
    int* ptrs = stackalloc int[3]; 
 
    ptrs[0] = 1; 
    ptrs[1] = 2; 
    ptrs[2] = 3; 
 
    for(int i=0; i < 3; i++) 
      Console.WriteLine(ptrs[i]); 
  } 
}

#endif


#if FixedSizeBuffer
// Demonstrate a fixed-size buffer. 
 
unsafe struct FixedBankRecord { 
  public fixed byte name[80]; // create a fixed-size buffer 
  public double balance; 
  public long ID; 
} 
  
class FixedSizeBuffer {  
  // mark Main as unsafe  
  unsafe public static void Main() {  
    Console.WriteLine("Size of FixedBankRecord is " +  
                       sizeof(FixedBankRecord)); 
  }  
}

#endif

#if Nullable
// Demonstrate a nullable type. 
 
class NullableDemo { 
  public static void Main() { 
    int? count = null; 
 
    if(count.HasValue) 
      Console.WriteLine("count has this value: " + count.Value); 
    else  
      Console.WriteLine("count has no value"); 
 
    count = 100; 
 
    if(count.HasValue) 
      Console.WriteLine("count has this value: " + count.Value); 
    else  
      Console.WriteLine("count has no value");     
  } 
}

#endif

#if NuLLableInExpressions
// Use nullable objects in expressions. 

class NullableDemo { 
  public static void Main() { 
    int? count = null; 
    int? result = null; 
 
    int incr = 10; // notice that incr is a non-nullable type 
 
    // result contains null, because count is null. 
    result = count + incr; 
 
    if(result.HasValue) 
      Console.WriteLine("result has this value: " + result.Value); 
    else  
      Console.WriteLine("result has no value");     
 
    // Now, count is given a value and result  
    // will contain a value. 
    count = 100; 
    result = count + incr; 
 
    if(result.HasValue) 
      Console.WriteLine("result has this value: " + result.Value); 
    else  
      Console.WriteLine("result has no value");     
             
  } 
}

#endif

#if NullableAssignemnt
// Using ?? 

class NullableDemo2 { 
  // Return a zero balance. 
  static double getZeroBal() { 
    Console.WriteLine("In getZeroBal()."); 
      return 0.0; 
  } 
 
  public static void Main() { 
    double? balance = 123.75; 
    double currentBalance; 
 
    // Here, getZeroBal( ) is not called because balance 
    // contains a value. 
    currentBalance = balance ?? getZeroBal(); 
 
    Console.WriteLine(currentBalance); 
  } 
}

#endif

#if PartialClass

partial class XY { 
  public XY(int a, int b) { 
    x = a; 
    y = b; 
  } 
}


partial class XY { 
  int x; 
 
  public int X { 
    get { return x; } 
    set { x = value; } 
  } 
}


partial class XY { 
  int y; 
 
  public int Y { 
    get { return y; } 
    set { y = value; } 
  } 
}

// Demonstrate partial class definitions. 

class Test { 
  public static void Main() { 
    XY xy = new XY(1, 2); 
 
 
    Console.WriteLine(xy.X + "," + xy.Y); 
  } 
}

#endif

#if ReadOnly

// Demonstrate readonly. 
 
class MyClass { 
  public static readonly int SIZE = 10; 
}

    class DemoReadOnly
    {
        const string h = "aString";
        //const Test d = new Test();   // const cannot be use with references other than strings!
        const int j = 9;
        readonly int p = 9;
        public static void Main()
        {
            int[] nums = new int[MyClass.SIZE];
            
            for (int i = 0; i < MyClass.SIZE; i++)
                nums[i] = i;
            const int myConst=0; // Ok to declare in method
            //readonly int MyConst;  // NOT Ok to declare in method
            foreach (int i in nums)
                Console.Write(i + " ");
            // MyClass.SIZE = 100; // Error!!! can't change 
            Test t = new Test();
            Console.WriteLine(Test.testConst); // const class fields are static by default!
            Console.WriteLine(t.testReadOnly);
            
        }
    }


    class Test
    {
        public readonly int testReadOnly;  // readonly initialized at run time (0 or null by default..)
        public readonly string myReadOnlyString;
        public const int testConst=9;      // must be initialized!
    }
#endif

}

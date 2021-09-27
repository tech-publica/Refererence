//#define MyClass0
//#define MyClass1
//#define Test0
//#define Test1
//#define RefTest
//#define Swap
//#define Decompose
//#define Num
//#define RefSwap
//#define Min
//#define MyClass2
//#define Rect
//#define MyClass3
//#define Factor
//#define OverLoad0
//#define OverLoad1
//#define OverLoad2
//#define Stack
//#define XTCoord
//#define CLDemo
//#define Factorial
//#define Cipher
//#define RevStr
//#define StaticDemo
//#define StaticError
//#define AnotherStaticError
//#define MyClass5
//#define CountInst
//#define MyClass6
//#define Cons
//#define NumericFn


using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Ref7_ref_out_misc
{

#if MyClass0
// Public vs private access. 
 

class MyClass {  
  private int alpha; // private access explicitly specified 
  int beta;          // private access by default 
  public int gamma;  // public access 
 
  /* Methods to access alpha and beta.  It is OK for a 
     member of a class to access a private member 
     of the same class. 
  */ 
  public void setAlpha(int a) { 
    alpha = a;  
  } 
 
  public int getAlpha() { 
    return alpha; 
  } 
 
  public void setBeta(int a) { 
    beta = a;  
  } 
 
  public int getBeta() { 
    return beta; 
  } 
}  
  
class AccessDemo {  
  public static void Main() {  
    MyClass ob = new MyClass();  
  
    /* Access to alpha and beta is allowed only 
       through methods. */ 
    ob.setAlpha(-99); 
    ob.setBeta(19); 
    Console.WriteLine("ob.alpha is " + ob.getAlpha()); 
    Console.WriteLine("ob.beta is " + ob.getBeta()); 
 
    // You cannot access alpha or beta like this: 
//  ob.alpha = 10; // Wrong! alpha is private! 
//  ob.beta = 9;   // Wrong! beta is private! 
 
    // It is OK to directly access gamma because it is public. 
    ob.gamma = 99;  
   }  
}

#endif





#if MyClass1
// References can be passed to methods.  
 
class MyClass {  
  int alpha, beta; 
  
  public MyClass(int i, int j) {  
    alpha = i;  
    beta = j;  
  }  
  
  /* Return true if ob contains the same values 
     as the invoking object. */ 
  public bool sameAs(MyClass ob) {  
    if((ob.alpha == alpha) & (ob.beta == beta)) 
       return true;  
    else return false;  
  }  
 
  // Make a copy of ob. 
  public void copy(MyClass ob) { 
    alpha = ob.alpha; 
    beta  = ob.beta; 
  } 
 
  public void show() { 
    Console.WriteLine("alpha: {0}, beta: {1}", 
                      alpha, beta); 
  } 
}  
  
class PassOb {  
  public static void Main() { 
    MyClass ob1 = new MyClass(4, 5);  
    MyClass ob2 = new MyClass(6, 7);  
  
    Console.Write("ob1: "); 
    ob1.show(); 
 
    Console.Write("ob2: "); 
    ob2.show(); 
 
    if(ob1.sameAs(ob2))  
      Console.WriteLine("ob1 and ob2 have the same values."); 
    else 
      Console.WriteLine("ob1 and ob2 have different values."); 
 
    Console.WriteLine(); 
 
    // now, make ob1 a copy of ob2 
    ob1.copy(ob2); 
 
    Console.Write("ob1 after copy: "); 
    ob1.show(); 
 
    if(ob1.sameAs(ob2))  
      Console.WriteLine("ob1 and ob2 have the same values."); 
    else 
      Console.WriteLine("ob1 and ob2 have different values."); 
 
  }  
}

#endif



#if Test0
// Value types are passed by value. 

class Test { 
  /* This method causes no change to the arguments 
     used in the call. */ 
  public void noChange(int i, int j) { 
    i = i + j; 
    j = -j; 
  } 
} 
 
class CallByValue { 
  public static void Main() { 
    Test ob = new Test(); 
 
    int a = 15, b = 20; 
 
    Console.WriteLine("a and b before call: " + 
                       a + " " + b); 
 
    ob.noChange(a, b);  
 
    Console.WriteLine("a and b after call: " + 
                       a + " " + b); 
  } 
}

#endif


#if Test1
// Objects are passed by reference. 
 
 
class Test { 
  public int a, b; 
 
  public Test(int i, int j) { 
    a = i; 
    b = j; 
  } 
 
  /* Pass an object. Now, ob.a and ob.b in object 
     used in the call will be changed. */ 
  public void change(Test ob) { 
    ob.a = ob.a + ob.b; 
    ob.b = -ob.b; 
  } 
} 
 
class CallByRef { 
  public static void Main() { 
    Test ob = new Test(15, 20); 
 
    Console.WriteLine("ob.a and ob.b before call: " + 
                       ob.a + " " + ob.b); 
 
    ob.change(ob); 
 
    Console.WriteLine("ob.a and ob.b after call: " + 
                       ob.a + " " + ob.b); 
  } 
}

#endif


#if RefTest
// Use ref to pass a value type by reference. 
 
class RefTest { 
  /* This method changes its argument. 
     Notice the use of ref. */ 
  public void sqr(ref int i) { 
    i = i * i; 
  } 
} 
 
class RefDemo { 
  public static void Main() { 
    RefTest ob = new RefTest(); 
 
    int a = 10; 
 
    Console.WriteLine("a before call: " + a); 
 
    ob.sqr(ref a); // notice the use of ref 
 
    Console.WriteLine("a after call: " + a); 
  } 
}

#endif


#if Swap
// Swap two values. 
 
class Swap { 
  // This method now changes its arguments. 
  public void swap(ref int a, ref int b) { 
    int t; 
  
    t = a; 
    a = b; 
    b = t; 
  } 
} 
 
class SwapDemo { 
  public static void Main() { 
    Swap ob = new Swap(); 
 
    int x = 10, y = 20; 
 
    Console.WriteLine("x and y before call: " + x + " " + y); 
 
    ob.swap(ref x, ref y);  
 
    Console.WriteLine("x and y after call: " + x + " " + y); 
  } 
}

#endif


#if Decompose
// Use out. 
 
class Decompose { 
 
  /* Decompose a floating-point value into its 
      integer and fractional parts. */ 
  public int parts(double n, out double frac) { 
    int whole; 
 
    whole = (int) n; 
    frac = n - whole; // pass fractional part back through frac 
    return whole; // return integer portion 
  } 
} 
  
class UseOut { 
  public static void Main() {   
   Decompose ob = new Decompose(); 
    int i; 
    double f; 
 
    i = ob.parts(10.125, out f); 
 
    Console.WriteLine("Integer portion is " + i); 
    Console.WriteLine("Fractional part is " + f); 
  } 
}

#endif

#if Num
// Use two out parameters. 
 
class Num { 
  /* Determine if x and v have a common divisor. 
     If so, return least and greatest common factors in  
     the out parameters. */ 
  public bool hasComFactor(int x, int y, 
                           out int least, out int greatest) { 
    int i; 
    int max = x < y ? x : y; 
    bool first = true; 
 
    least = 1; 
    greatest = 1;  
 
    // find least and greatest common factors 
    for(i=2; i <= max/2 + 1; i++) { 
      if( ((y%i)==0) & ((x%i)==0) ) { 
        if(first) { 
          least = i; 
          first = false; 
        } 
        greatest = i; 
      } 
    } 
 
    if(least != 1) return true; 
    else return false; 
  } 
} 
  
class DemoOut { 
  public static void Main() {   
    Num ob = new Num(); 
    int lcf, gcf; 
 
    if(ob.hasComFactor(231, 105, out lcf, out gcf)) { 
      Console.WriteLine("Lcf of 231 and 105 is " + lcf); 
      Console.WriteLine("Gcf of 231 and 105 is " + gcf); 
    } 
    else 
      Console.WriteLine("No common factor for 35 and 49."); 
 
    if(ob.hasComFactor(35, 51, out lcf, out gcf)) { 
      Console.WriteLine("Lcf of 35 and 51 " + lcf); 
      Console.WriteLine("Gcf of 35 and 51 is " + gcf); 
    } 
    else 
      Console.WriteLine("No common factor for 35 and 51."); 
 
  } 
}

#endif

#if RefSwap
// Swap two references. 
 
class RefSwap { 
  int a, b; 
   
  public RefSwap(int i, int j) { 
    a = i; 
    b = j; 
  } 
 
  public void show() { 
    Console.WriteLine("a: {0}, b: {1}", a, b); 
  } 
 
  // This method changes its arguments. 
  public void swap(ref RefSwap ob1, ref RefSwap ob2) { 
    RefSwap t; 
  
    t = ob1; 
    ob1 = ob2; 
    ob2 = t; 
  } 
} 
 
class RefSwapDemo { 
  public static void Main() { 
    RefSwap x = new RefSwap(1, 2); 
    RefSwap y = new RefSwap(3, 4); 
 
    Console.Write("x before call: "); 
    x.show(); 
 
    Console.Write("y before call: "); 
    y.show(); 
 
    Console.WriteLine(); 
 
    // exchange the objects to which x and y refer 
    x.swap(ref x, ref y);  
 
    Console.Write("x after call: "); 
    x.show(); 
 
    Console.Write("y after call: "); 
    y.show(); 
 
  } 
}

#endif

#if Min
// Demonstrate params. 

class Min { 
  public int minVal(params int[] nums) { 
    int m; 
 
    if(nums.Length == 0) { 
      Console.WriteLine("Error: no arguments."); 
      return 0; 
    } 
 
    m = nums[0]; 
    for(int i=1; i < nums.Length; i++)  
      if(nums[i] < m) m = nums[i]; 
 
    return m; 
  } 
} 
 
class ParamsDemo { 
  public static void Main() { 
    Min ob = new Min(); 
    int min; 
    int a = 10, b = 20; 
 
    // call with two values 
    min = ob.minVal(a, b); 
    Console.WriteLine("Minimum is " + min); 
 
    // call with 3 values 
    min = ob.minVal(a, b, -1); 
    Console.WriteLine("Minimum is " + min); 
 
    // call with 5 values 
    min = ob.minVal(18, 23, 3, 14, 25); 
    Console.WriteLine("Minimum is " + min); 
 
    // can call with an int array, too 
    int[] args = { 45, 67, 34, 9, 112, 8 }; 
    min = ob.minVal(args); 
    Console.WriteLine("Minimum is " + min); 
  } 
}

#endif


#if MyClass2
// Use regular parameter with a params parameter. 

class MyClass { 
  public void showArgs(string msg, params int[] nums) { 
    Console.Write(msg + ": "); 
 
    foreach(int i in nums) 
      Console.Write(i + " "); 
 
    Console.WriteLine(); 
  } 
} 
 
class ParamsDemo2 { 
  public static void Main() { 
    MyClass ob = new MyClass(); 
 
    ob.showArgs("Here are some integers",  
                1, 2, 3, 4, 5); 
 
    ob.showArgs("Here are two more",  
                17, 20); 
 
  } 
}

#endif

#if Rect
// Return an object. 

 
class Rect { 
  int width; 
  int height; 
 
  public Rect(int w, int h) { 
    width = w; 
    height = h; 
  } 
 
  public int area() { 
    return width * height; 
  } 
 
  public void show() { 
    Console.WriteLine(width + " " + height); 
  } 
 
  /* Return a rectangle that is a specified 
     factor larger than the invoking rectangle. */ 
  public Rect enlarge(int factor) { 
    return new Rect(width * factor, height * factor); 
  } 
} 
  
class RetObj { 
  public static void Main() {   
    Rect r1 = new Rect(4, 5); 
 
    Console.Write("Dimensions of r1: "); 
    r1.show(); 
    Console.WriteLine("Area of r1: " + r1.area()); 
 
    Console.WriteLine(); 
 
    // create a rectangle that is twice as big as r1 
    Rect r2 = r1.enlarge(2); 
 
    Console.Write("Dimensions of r2: "); 
    r2.show(); 
    Console.WriteLine("Area of r2 " + r2.area()); 
  } 
}

#endif


#if MyClass3
// Use a class factory. 
; 
 
class MyClass { 
  int a, b; // private 
 
  // Create a class factory for MyClass. 
  public MyClass factory(int i, int j) { 
    MyClass t = new MyClass(); 
    
    t.a = i; 
    t.b = j; 
 
    return t; // return an object 
  } 
 
  public void show() { 
    Console.WriteLine("a and b: " + a + " " + b); 
  } 
 
} 
  
class MakeObjects { 
  public static void Main() {   
    MyClass ob = new MyClass(); 
    int i, j; 
 
    // generate objects using the factory 
    for(i=0, j=10; i < 10; i++, j--) { 
      MyClass anotherOb = ob.factory(i, j); // make an object 
      anotherOb.show(); 
    } 
       
    Console.WriteLine();    
  } 
}

#endif

#if Factor
// Return an array. 
 
class Factor { 
  /* Return an array containing the factors of num. 
     On return, numfactors will contain the number of 
     factors found. */ 
  public int[] findfactors(int num, out int numfactors) { 
    int[] facts = new int[80]; // size of 80 is arbitrary 
    int i, j; 
 
    // find factors and put them in the facts array 
    for(i=2, j=0; i < num/2 + 1; i++)  
      if( (num%i)==0 ) { 
        facts[j] = i; 
        j++; 
      } 
     
    numfactors = j; 
    return facts; 
  } 
} 
  
class FindFactors { 
  public static void Main() {   
    Factor f = new Factor(); 
    int numfactors; 
    int[] factors; 
 
    factors = f.findfactors(1000, out numfactors); 
 
    Console.WriteLine("Factors for 1000 are: "); 
    for(int i=0; i < numfactors; i++) 
      Console.Write(factors[i] + " "); 
       
    Console.WriteLine();    
  } 
}

#endif

#if Overload0
// Demonstrate method overloading.  
 
class Overload {  
  public void ovlDemo() {  
    Console.WriteLine("No parameters");  
  }  
  
  // Overload ovlDemo for one integer parameter.  
  public void ovlDemo(int a) {  
    Console.WriteLine("One parameter: " + a);  
  }  
  
  // Overload ovlDemo for two integer parameters.  
  public int ovlDemo(int a, int b) {  
    Console.WriteLine("Two parameters: " + a + " " + b);  
    return a + b; 
  }  
  
  // Overload ovlDemo for two double parameters.  
  public double ovlDemo(double a, double b) { 
    Console.WriteLine("Two double parameters: " + 
                       a + " "+ b);  
    return a + b;  
  }  
}  
  
class OverloadDemo {  
  public static void Main() {  
    Overload ob = new Overload();  
    int resI; 
    double resD;      
  
    // call all versions of ovlDemo()  
    ob.ovlDemo();   
    Console.WriteLine(); 
 
    ob.ovlDemo(2);  
    Console.WriteLine(); 
 
    resI = ob.ovlDemo(4, 6);  
    Console.WriteLine("Result of ob.ovlDemo(4, 6): " + 
                       resI);  
    Console.WriteLine(); 
 
 
    resD = ob.ovlDemo(1.1, 2.32);  
    Console.WriteLine("Result of ob.ovlDemo(1.1, 2.32): " + 
                       resD);  
  }  
}

#endif


#if Overload1
/* Automatic type conversions can affect 
   overloaded method resolution. */ 
 
class Overload2 { 
  public void f(int x) { 
    Console.WriteLine("Inside f(int): " + x); 
  } 
 
  public void f(double x) { 
    Console.WriteLine("Inside f(double): " + x); 
  } 
} 
 
class TypeConv { 
  public static void Main() { 
    Overload2 ob = new Overload2(); 
 
    int i = 10; 
    double d = 10.1; 
 
    byte b = 99; 
    short s = 10; 
    float f = 11.5F; 
 
 
    ob.f(i); // calls ob.f(int) 
    ob.f(d); // calls ob.f(double) 
 
    ob.f(b); // calls ob.f(int) -- type conversion 
    ob.f(s); // calls ob.f(int) -- type conversion 
    ob.f(f); // calls ob.f(double) -- type conversion 
  } 
}

#endif


#if OverLoad2
// Add f(byte). 
 
 
class Overload2 { 
  public void f(byte x) { 
    Console.WriteLine("Inside f(byte): " + x); 
  } 
 
  public void f(int x) { 
    Console.WriteLine("Inside f(int): " + x); 
  } 
 
  public void f(double x) { 
    Console.WriteLine("Inside f(double): " + x); 
  } 
} 
 
class TypeConv { 
  public static void Main() { 
    Overload2 ob = new Overload2(); 
 
    int i = 10; 
    double d = 10.1; 
 
    byte b = 99; 
    short s = 10; 
    float f = 11.5F; 
 
 
    ob.f(i); // calls ob.f(int) 
    ob.f(d); // calls ob.f(double) 
 
    ob.f(b); // calls ob.f(byte) -- now, no type conversion 
 
    ob.f(s); // calls ob.f(int) -- type conversion 
    ob.f(f); // calls ob.f(double) -- type conversion 
  } 
}

#endif

#if MyClass4
// Demonstrate an overloaded constructor. 
 
using System; 
 
class MyClass {  
  public int x;  
  
  public MyClass() { 
    Console.WriteLine("Inside MyClass()."); 
    x = 0; 
  } 
 
  public MyClass(int i) {  
    Console.WriteLine("Inside MyClass(int)."); 
    x = i;  
  } 
 
  public MyClass(double d) { 
    Console.WriteLine("Inside MyClass(double)."); 
    x = (int) d; 
  } 
 
  public MyClass(int i, int j) { 
    Console.WriteLine("Inside MyClass(int, int)."); 
    x = i * j; 
  }    
}    
    
class OverloadConsDemo {    
  public static void Main() {    
    MyClass t1 = new MyClass();  
    MyClass t2 = new MyClass(88);  
    MyClass t3 = new MyClass(17.23);  
    MyClass t4 = new MyClass(2, 4);  
  
    Console.WriteLine("t1.x: " + t1.x); 
    Console.WriteLine("t2.x: " + t2.x); 
    Console.WriteLine("t3.x: " + t3.x); 
    Console.WriteLine("t4.x: " + t4.x); 
  } 
}

#endif

#if Stack
// A stack class for characters.   
    
  
class Stack {   
  // these members are private 
  char[] stck; // holds the stack  
  int tos;     // index of the top of the stack  
   
  // Construct an empty Stack given its size.  
  public Stack(int size) {   
    stck = new char[size]; // allocate memory for stack  
    tos = 0;   
  }   
  
  // Construct a Stack from a stack. 
  public Stack(Stack ob) {   
    // allocate memory for stack  
    stck = new char[ob.stck.Length]; 
 
    // copy elements to new stack 
    for(int i=0; i < ob.tos; i++)  
      stck[i] = ob.stck[i]; 
 
    // set tos for new stack 
    tos = ob.tos; 
  }   
  
  // Push characters onto the stack.  
  public void push(char ch) {   
    if(tos==stck.Length) {   
      Console.WriteLine(" -- Stack is full.");   
      return;   
    }   
       
    stck[tos] = ch;  
    tos++;  
  }   
   
  // Pop a character from the stack.  
  public char pop() {   
    if(tos==0) {   
      Console.WriteLine(" -- Stack is empty.");   
      return (char) 0;    
    }   
     
    tos--;   
    return stck[tos];   
  } 
 
  // Return true if the stack is full. 
  public bool full() { 
    return tos==stck.Length;    
  } 
 
  // Return true if the stack is empty. 
  public bool empty() { 
    return tos==0; 
  } 
 
  // Return total capacity of the stack. 
  public int capacity() { 
    return stck.Length; 
  } 
 
  // Return number of objects currently on the stack. 
  public int getNum() { 
    return tos; 
  } 
} 
 
// Demonstrate the Stack class.   
class StackDemo {   
  public static void Main() {   
    Stack stk1 = new Stack(10);   
    char ch;   
    int i;   
   
    // Put some characters into stk1. 
    Console.WriteLine("Push A through J onto stk1."); 
    for(i=0; !stk1.full(); i++)   
      stk1.push((char) ('A' + i));   
 
    // Create a copy of stck1 
    Stack stk2 = new Stack(stk1); 
  
    // Display the contents of stk1. 
    Console.Write("Contents of stk1: ");   
    while( !stk1.empty() ) {    
      ch = stk1.pop();   
      Console.Write(ch);   
    }   
 
    Console.WriteLine(); 
   
    Console.Write("Contents of stk2: ");   
    while ( !stk2.empty() ) {    
      ch = stk2.pop();   
      Console.Write(ch);   
    }   
 
    Console.WriteLine("\n"); 
    
  }   
}

#endif

#if XTCoord
// Demonstrate invoking a constructor through this. 
  
class XYCoord {   
  public int x, y;   
   
  public XYCoord() : this(0, 0) { 
    Console.WriteLine("Inside XYCoord()"); 
  }  
 
  public XYCoord(XYCoord obj) : this(obj.x, obj.y) { 
    Console.WriteLine("Inside XYCoord(obj)"); 
  }  
 
  public XYCoord(int i, int j) {  
    Console.WriteLine("Inside XYCoord(int, int)"); 
    x = i; 
    y = j; 
  }     
}     
     
class OverloadConsDemo {     
  public static void Main() {     
    XYCoord t1 = new XYCoord();   
    XYCoord t2 = new XYCoord(8, 9);   
    XYCoord t3 = new XYCoord(t2);   
   
    Console.WriteLine("t1.x, t1.y: " + t1.x + ", " + t1.y);  
    Console.WriteLine("t2.x, t2.y: " + t2.x + ", " + t2.y);  
    Console.WriteLine("t3.x, t3.y: " + t3.x + ", " + t3.y);  
  }     
}

#endif

#if CLDemo
// Display all command-line information. 
 
class CLDemo {  
  public static void Main(string[] args) { 
    Console.WriteLine("There are " + args.Length + 
                       " command-line arguments."); 
 
    Console.WriteLine("They are: "); 
    for(int i=0; i < args.Length; i++)  
      Console.WriteLine(args[i]);  
  }  
}

#endif

#if Cipher
// Encode or decode a message. 
 
class Cipher { 
  public static int Main(string[] args) {   
 
    // see if arguments are present 
    if(args.Length < 2) { 
      Console.WriteLine("Usage: encode/decode word1 [word2...wordN]"); 
      return 1; // return failure code 
    } 
 
    // if args present, first arg must be encode or decode 
    if(args[0] != "encode" & args[0] != "decode") { 
      Console.WriteLine("First arg must be encode or decode."); 
      return 1; // return failure code 
    } 
 
    // encode or decode message 
    for(int n=1; n < args.Length; n++) { 
      for(int i=0; i < args[n].Length; i++) { 
        if(args[0] == "encode") 
          Console.Write((char) (args[n][i] + 1) ); 
        else  
          Console.Write((char) (args[n][i] - 1) ); 
      } 
      Console.Write(" "); 
    } 
 
    Console.WriteLine(); 
 
    return 0; 
  } 
}

#endif

#if Factorial
// A simple example of recursion.  
 
class Factorial {  
  // This is a recursive function.  
  public int factR(int n) {  
    int result;  
  
    if(n==1) return 1;  
    result = factR(n-1) * n;  
    return result;  
  }  
  
  // This is an iterative equivalent.  
  public int factI(int n) {  
    int t, result;  
  
    result = 1;  
    for(t=1; t <= n; t++) result *= t;  
    return result;  
  }  
}  
  
class Recursion {  
  public static void Main() {  
    Factorial f = new Factorial();  
  
    Console.WriteLine("Factorials using recursive method.");  
    Console.WriteLine("Factorial of 3 is " + f.factR(3));  
    Console.WriteLine("Factorial of 4 is " + f.factR(4));  
    Console.WriteLine("Factorial of 5 is " + f.factR(5));  
    Console.WriteLine();  
 
    Console.WriteLine("Factorials using iterative method.");  
    Console.WriteLine("Factorial of 3 is " + f.factI(3));  
    Console.WriteLine("Factorial of 4 is " + f.factI(4));  
    Console.WriteLine("Factorial of 5 is " + f.factI(5));  
  }  
}

#endif

#if RevStr
// Display a string in reverse by using recursion. 
 
class RevStr { 
 
  // Display a string backwards. 
  public void displayRev(string str) { 
    if(str.Length > 0)  
      displayRev(str.Substring(1, str.Length-1)); 
    else  
      return; 
 
    Console.Write(str[0]); 
  } 
} 
 
class RevStrDemo { 
  public static void Main() {   
    string s = "this is a test"; 
    RevStr rsOb = new RevStr(); 
 
    Console.WriteLine("Original string: " + s); 
 
    Console.Write("Reversed string: "); 
    rsOb.displayRev(s); 
 
    Console.WriteLine(); 
  } 
}

#endif

 
#if StaticDemo 

 
class StaticDemo { 
  // a static variable 
  public static int val = 100;  
 
  // a static method 
  public static int valDiv2() { 
    return val/2; 
  } 
} 
 
class SDemo { 
  public static void Main() { 
 
    Console.WriteLine("Initial value of StaticDemo.val is " 
                      + StaticDemo.val); 
 
    StaticDemo.val = 8; 
    Console.WriteLine("StaticDemo.val is " + StaticDemo.val); 
    Console.WriteLine("StaticDemo.valDiv2(): " + 
                       StaticDemo.valDiv2()); 
  } 
}

#endif

#if StaticError
class StaticError { 
  int denom = 3; // a normal instance variable 
  static int val = 1024; // a static variable 
 
  /* Error! Can't directly access a non-static variable 
     from within a static method. */ 
  static int valDivDenom() { 
    return val/denom; // won't compile! 
  } 
}

#endif
 
 
#if AnotherStaticError
class AnotherStaticError { 
  // non-static method. 
  void nonStaticMeth() { 
     Console.WriteLine("Inside nonStaticMeth()."); 
  } 
 
  /* Error! Can't directly call a non-static method 
     from within a static method. */ 
  static void staticMeth() { 
    nonStaticMeth(); // won't compile 
  } 
}

#endif

#if MyClass5
class MyClass { 
  // non-static method. 
  void nonStaticMeth() { 
     Console.WriteLine("Inside nonStaticMeth()."); 
  } 
 
  /* Can call a non-static method through an 
     object reference from within a static method. */ 
  public static void staticMeth(MyClass ob) { 
    ob.nonStaticMeth(); // this is OK 
  } 
}

#endif



#if CountInst
// Use a static field to count instances. 
  
class CountInst {  
  static int count = 0; 
  
  // increment count when object is created 
  public CountInst() {  
    count++; 
  }  
 
  // decrement count when object is destroyed 
  ~CountInst() { 
    count--; 
  } 
  
  public static int getcount() { 
    return count; 
  } 
}  
  
class CountDemo {  
  public static void Main() { 
    CountInst ob; 
 
 
    for(int i=0; i < 10; i++) { 
      ob = new CountInst(); 
      Console.WriteLine("Current count: " +  
                        CountInst.getcount()); 
    } 
 
  }  
}
#endif


#if MyClass6
// Use a static class factory. 
 
class MyClass { 
  int a, b; 
 
  // Create a class factory for MyClass. 
  static public MyClass factory(int i, int j) { 
    MyClass t = new MyClass(); 
    
    t.a = i; 
    t.b = j; 
 
    return t; // return an object 
  } 
 
  public void show() { 
    Console.WriteLine("a and b: " + a + " " + b); 
  } 
 
} 
  
class MakeObjects { 
  public static void Main() {   
    int i, j; 
 
    // generate objects using the factory 
    for(i=0, j=10; i < 10; i++, j--) { 
      MyClass ob = MyClass.factory(i, j); // get an object 
      ob.show(); 
    } 
       
    Console.WriteLine();    
  } 
}

#endif

#if Cons
// Use a static constructor. 
  
 
class Cons { 
  public static int alpha; 
  public int beta; 
 
  // static constructor 
  static Cons() { 
    alpha = 99; 
    Console.WriteLine("Inside static constructor."); 
  } 
 
  // instance constructor 
  public Cons() { 
    beta = 100; 
    Console.WriteLine("Inside instance constructor."); 
  } 
} 
  
class ConsDemo { 
  public static void Main() {   
    Cons ob = new Cons(); 
 
    Console.WriteLine("Cons.alpha: " + Cons.alpha); 
    Console.WriteLine("ob.beta: " + ob.beta); 
  } 
}

#endif

#if NumericFn
// Demonstrate a static class. 
   
  
static class NumericFn {  
  // Return the reciprocal of a value. 
  static public double reciprocal(double num) { 
    return 1/num; 
  } 
 
  // Return the fractional part of a value. 
  static public double fracPart(double num) { 
    return num - (int) num; 
  } 
 
  // Return true if num is even. 
  static public bool isEven(double num) { 
    return (num % 2) == 0 ? true : false; 
  } 
 
  // Return true of num is odd. 
  static public bool isOdd(double num) { 
    return !isEven(num); 
  } 
 
}  
 
class StaticClassDemo {  
  public static void Main() {    
    Console.WriteLine("Reciprocal of 5 is " + 
                      NumericFn.reciprocal(5.0)); 
 
    Console.WriteLine("Fractional part of 4.234 is " + 
                      NumericFn.fracPart(4.234)); 
 
    if(NumericFn.isEven(10)) 
      Console.WriteLine("10 is even."); 
 
    if(NumericFn.isOdd(5)) 
      Console.WriteLine("5 is odd."); 
 
    // The following attempt to create an instance of  
    // NumericFn will cause an error. 
//  NumericFn ob = new NumericFn(); // Wrong! 
  }  
}
#endif

}

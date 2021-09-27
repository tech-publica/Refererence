
using System;
using System.Collections.Generic;

namespace Refererence.Refe17_Generics
{


#if SimpleGen
// A simple generic class.  
 
using System; 
 
// In the following Gen class, T is a type 
// parameter that will be replaced by a real 
// type when an object of type Gen is created. 
class Gen<T> { 
  T ob; // declare an object of type T 
   
  // Notice that this constructor has a parameter of type T. 
  public Gen(T o) { 
    ob = o; 
  } 
 
  // Return ob, which is of type T. 
  public T getob() { 
    return ob; 
  } 
 
  // Show type of T. 
  public void showType() { 
    Console.WriteLine("Type of T is " + typeof(T)); 
  } 
} 
 
// Demonstrate the generic class. 
class GenericsDemo { 
  public static void Main() { 
    // Create a Gen reference for int. 
    Gen<int> iOb;  
 
    // Create a Gen<int> object and assign its 
    // reference to iOb. 
    iOb = new Gen<int>(102); 
 
    // Show the type of data used by iOb. 
    iOb.showType(); 
 
    // Get the value in iOb. 
    int v = iOb.getob(); 
    Console.WriteLine("value: " + v); 
 
    Console.WriteLine(); 
 
    // Create a Gen object for strings. 
    Gen<string> strOb = new Gen<string>("Generics add power."); 
 
    // Show the type of data stored in strOb. 
    strOb.showType(); 
 
    // Get the value in strOb. 
    string str = strOb.getob(); 
    Console.WriteLine("value: " + str); 
  } 
}


#endif


#if NonGen

// NonGen is functionally equivalent to Gen 
// but does not use generics.  
 
class NonGen {  
  object ob; // ob is now of type object 
    
  // Pass the constructor a reference of   
  // type object. 
  public NonGen(object o) {  
    ob = o;  
  }  
  
  // Return type object. 
  public object getob() {  
    return ob;  
  }  
 
  // Show type of ob.  
  public void showType() {  
    Console.WriteLine("Type of ob is " + ob.GetType()); 
  }  
}  
  
// Demonstrate the non-generic class.  
class NonGenDemo {  
  public static void Main() {  
    NonGen iOb;   
  
    // Create NonGen object. 
    iOb = new NonGen(102);  
  
    // Show the type of data stored in iOb. 
    iOb.showType(); 
 
    // Get the value in iOb. 
    // This time, a cast is necessary. 
    int v = (int) iOb.getob();  
    Console.WriteLine("value: " + v);  
  
    Console.WriteLine();  
  
    // Create another NonGen object and  
    // store a string in it. 
    NonGen strOb = new NonGen("Non-Generics Test");  
  
    // Show the type of data stored strOb. 
    strOb.showType(); 
 
    // Get the value of strOb. 
    // Again, notice that a cast is necessary.  
    String str = (string) strOb.getob();  
    Console.WriteLine("value: " + str);  
 
    // This compiles, but is conceptually wrong! 
    iOb = strOb; 
 
    // The following line results in a run-time exception. 
    // v = (int) iOb.getob(); // run-time error! 
  }  
}

#endif


#if TwoGen
// A simple generic class with two type 
// parameters: T and V. 
 
class TwoGen<T, V> { 
  T ob1; 
  V ob2; 
   
  // Notice that this construtor has parameters 
  // of type T and V. 
  public TwoGen(T o1, V o2) { 
    ob1 = o1; 
    ob2 = o2; 
  } 
 
  // Show types of T and V. 
  public void showTypes() { 
    Console.WriteLine("Type of T is " + typeof(T)); 
    Console.WriteLine("Type of V is " + typeof(V)); 
  } 
 
  public T getob1() { 
    return ob1; 
  } 
 
  public V getob2() { 
    return ob2; 
  } 
} 
 
// Demonstrate two generic type parameters. 
class SimpGen { 
  public static void Main() { 
 
    TwoGen<int, string> tgObj = 
      new TwoGen<int, string>(119, "Alpha Beta Gamma"); 
 
    // Show the types. 
    tgObj.showTypes(); 
 
    // Obtain and show values. 
    int v = tgObj.getob1(); 
    Console.WriteLine("value: " + v); 
 
    string str = tgObj.getob2(); 
    Console.WriteLine("value: " + str); 
  } 
}

#endif

#if GenBaseClassConstraint
// A simple demonstration of a base class constraint. 
 
class A { 
  public void hello() { 
    Console.WriteLine("Hello"); 
  } 
} 
 
// Class B inherits A. 
class B : A { } 
 
// Class C does not inherit A. 
class C { } 
 
// Because of the base class constraint, all type arguments 
// passed to Test must have A as a base class. 
class Test<T> where T : A { 
  T obj; 
 
  public Test(T o) { 
    obj = o; 
  } 
 
  public void sayHello() { 
    // OK to call hello() because it's declared 
    // by the base class A. 
    obj.hello(); 
  } 
} 
 
class BaseClassConstraintDemo { 
  public static void Main() { 
    A a = new A(); 
    B b = new B(); 
    C c = new C(); 
 
    // The following is valid because 
    // A is the specified base class. 
    Test<A> t1 = new Test<A>(a); 
 
    t1.sayHello(); 
 
    // The following is valid because 
    // B inherits A. 
    Test<B> t2 = new Test<B>(b); 
 
    t2.sayHello(); 
 
 
    // The following is invalid because 
    // C does not inherit A. 
//    Test<C> t3 = new Test<C>(c); // Error! 
  } 
}


#endif

#if GenBaseClassConstraintMoreInvolved

// A more practical demonstration of a base class constraint. 
  
// A custom exception that is thrown if a name or number 
// is not found. 
class NotFoundException : ApplicationException {} 
 
// A base class that stores a name and phone number. 
class PhoneNumber { 
  string name; 
  string number; 
 
  public PhoneNumber(string n, string num) { 
    name = n; 
    number = num; 
  } 
 
  public string Number { 
    get { return number; } 
    set { number = value; } 
  } 
 
  public string Name { 
    get { return name; } 
    set { name = value; } 
  } 
} 
 
// A class of phone numbers for friends. 
class Friend : PhoneNumber { 
  bool isWorkNumber; 
 
  public Friend(string n, string num, bool wk) : 
    base(n, num) 
  { 
    isWorkNumber = wk; 
  } 
 
  public bool IsWorkNumber { 
    get { 
      return isWorkNumber; 
    } 
  } 
 
  // ... 
} 
 
// A class of phone numbers for suppliers. 
class Supplier : PhoneNumber { 
  public Supplier(string n, string num) : 
    base(n, num) { } 
 
  // ... 
} 
 
// Notice that this class does not inherit PhoneNumber, 
class EmailFriend { 
 
  // ... 
} 
 
// PhoneList can manage any type of phone list 
// as long as it is derived from PhoneNumber. 
class PhoneList<T> where T : PhoneNumber { 
  T[] phList; 
  int end; 
 
  public PhoneList() {  
    phList = new T[10]; 
    end = 0; 
  } 
 
  public bool add(T newEntry) { 
    if(end == 10) return false; 
 
    phList[end] = newEntry; 
    end++; 
 
    return true; 
  } 
 
  // Given a name, find and return the phone info. 
  public T findByName(string name) { 
 
    for(int i=0; i<end; i++) { 
 
      // Name can be used because it is a member of 
      // PhoneNumber, which is the base class constraint. 
      if(phList[i].Name == name)  
        return phList[i]; 
 
    } 
 
    // Name not in list. 
    throw new NotFoundException(); 
  } 
 
  // Given a number, find and return the phone info. 
  public T findByNumber(string number) { 
 
    for(int i=0; i<end; i++) { 
 
      // Number can be used because it is also a member of 
      // PhoneNumber which, is the base class constraint. 
      if(phList[i].Number == number)  
        return phList[i]; 
    } 
 
    // Number not in list. 
    throw new NotFoundException(); 
  } 
 
  // ... 
} 
 
// Demonstrate base clas constraints. 
class UseBaseClassConstraint { 
  public static void Main() { 
 
    // The following code is OK because Friend 
    // inherits PhoneNumber. 
    PhoneList<Friend> plist = new PhoneList<Friend>(); 
    plist.add(new Friend("Tom", "555-1234", true)); 
    plist.add(new Friend("Gary", "555-6756", true)); 
    plist.add(new Friend("Matt", "555-9254", false)); 
 
    try { 
      // Find the number of a friend given a name. 
      Friend frnd = plist.findByName("Gary"); 
 
      Console.Write(frnd.Name + ": " + frnd.Number); 
 
      if(frnd.IsWorkNumber) 
        Console.WriteLine(" (work)"); 
      else 
        Console.WriteLine(); 
    } catch(NotFoundException) { 
      Console.WriteLine("Not Found"); 
    } 
 
    Console.WriteLine(); 
 
    // The following code is also OK because Supplier 
    // inherits PhoneNumber. 
    PhoneList<Supplier> plist2 = new PhoneList<Supplier>(); 
    plist2.add(new Supplier("Global Hardware", "555-8834")); 
    plist2.add(new Supplier("Computer Warehouse", "555-9256")); 
    plist2.add(new Supplier("NetworkCity", "555-2564")); 
 
    try { 
      // Find the name of a supplier given a number 
      Supplier sp = plist2.findByNumber("555-2564"); 
      Console.WriteLine(sp.Name + ": " + sp.Number); 
    } catch(NotFoundException) { 
        Console.WriteLine("Not Found"); 
    } 
 
    // The following declaration is invalid 
    // because EmailFriend does NOT inherit PhoneNumber. 
//    PhoneList<EmailFriend> plist3 = 
//        new PhoneList<EmailFriend>(); // Error! 
 
  } 
}

#endif

#if InterfaceConstraint

// Use an interface constraint. 
 
// A custom exception that is thrown if a name or number 
// is not found. 
class NotFoundException : ApplicationException { } 
 
// An interface that supports a name and phone number. 
public interface IPhoneNumber { 
 
  string Number { 
    get; 
    set; 
  } 
 
  string Name { 
    get; 
    set; 
  } 
} 
 
// A class of phone numbers for friends. 
// It implements IPhoneNumber. 
class Friend : IPhoneNumber { 
  string name; 
  string number; 
 
  bool isWorkNumber; 
 
  public Friend(string n, string num, bool wk) { 
    name = n; 
    number = num; 
 
    isWorkNumber = wk; 
  } 
 
  public bool IsWorkNumber { 
    get { 
      return isWorkNumber; 
    } 
  } 
 
  // Implement IPhoneNumber 
  public string Number { 
    get { return number; } 
    set { number = value; } 
  } 
 
  public string Name { 
    get { return name; } 
    set { name = value; } 
  } 
 
  // ... 
} 
 
// A class of phone numbers for suppliers. 
class Supplier : IPhoneNumber { 
  string name; 
  string number; 
 
  public Supplier(string n, string num) { 
    name = n; 
    number = num; 
  } 
 
  // Implement IPhoneNumber 
  public string Number { 
    get { return number; } 
    set { number = value; } 
  } 
 
  public string Name { 
    get { return name; } 
    set { name = value; } 
  } 
 
  // ... 
} 
 
// Notice that this class does not implement IPhoneNumber, 
class EmailFriend { 
 
  // ... 
} 
 
// PhoneList can manage any type of phone list 
// as long as it is implements IPhoneNumber. 
class PhoneList<T> where T : IPhoneNumber { 
  T[] phList; 
  int end; 
 
  public PhoneList() {  
    phList = new T[10]; 
    end = 0; 
  } 
 
  public bool add(T newEntry) { 
    if(end == 10) return false; 
 
    phList[end] = newEntry; 
    end++; 
 
    return true; 
  } 
 
  // Given a name, find and return the phone info. 
  public T findByName(string name) { 
 
    for(int i=0; i<end; i++) { 
 
      // Name can be used because it is a member of 
      // IPhoneNumber, which is the interface constraint. 
      if(phList[i].Name == name)  
        return phList[i]; 
 
    } 
 
    // Name not in list. 
    throw new NotFoundException(); 
  } 
 
  // Given a number, find and return the phone info. 
  public T findByNumber(string number) { 
 
    for(int i=0; i<end; i++) { 
 
      // Number can be used becasue it is also a member of 
      // IPhoneNumber, which is the interface constraint. 
      if(phList[i].Number == number)  
        return phList[i]; 
    } 
 
    // Number not in list. 
    throw new NotFoundException(); 
  } 
 
  // ... 
} 
 
// Demonstrate interface constraints. 
class UseInterfaceConstraint { 
  public static void Main() { 
 
    // The following code is OK because Friend 
    // implements IPhoneNumber. 
    PhoneList<Friend> plist = new PhoneList<Friend>(); 
    plist.add(new Friend("Tom", "555-1234", true)); 
    plist.add(new Friend("Gary", "555-6756", true)); 
    plist.add(new Friend("Matt", "555-9254", false)); 
 
    try { 
      // Find the number of a friend given a name. 
      Friend frnd = plist.findByName("Gary"); 
 
      Console.Write(frnd.Name + ": " + frnd.Number); 
 
      if(frnd.IsWorkNumber) 
        Console.WriteLine(" (work)"); 
      else 
        Console.WriteLine(); 
    } catch(NotFoundException) { 
      Console.WriteLine("Not Found"); 
    } 
 
    Console.WriteLine(); 
 
    // The following code is also OK because Supplier 
    // implements IPhoneNumber. 
    PhoneList<Supplier> plist2 = new PhoneList<Supplier>(); 
    plist2.add(new Supplier("Global Hardware", "555-8834")); 
    plist2.add(new Supplier("Computer Warehouse", "555-9256")); 
    plist2.add(new Supplier("NetworkCity", "555-2564")); 
 
    try { 
      // Find the name of a supplier given a number 
      Supplier sp = plist2.findByNumber("555-2564"); 
      Console.WriteLine(sp.Name + ": " + sp.Number); 
    } catch(NotFoundException) { 
        Console.WriteLine("Not Found"); 
    } 
 
    // The following declaration is invalid 
    // because EmailFriend does NOT implement IPhoneNumber. 
//    PhoneList<EmailFriend> plist3 = 
//        new PhoneList<EmailFriend>(); // Error! 
  } 
}

#endif

#if DefaultConstructor
// Demonstrate a new() constructor constraint. 
 

class MyClass { 
 
  public MyClass() { 
    // ... 
  }     
 
  //... 
} 
 
class Test<T> where T : new() { 
  T obj; 
 
  public Test() { 
    // This works because of the new() constraint. 
    obj = new T(); // create a T object 
  } 
 
  // ... 
} 
 
class ConsConstraintDemo { 
  public static void Main() { 
 
    Test<MyClass> x = new Test<MyClass>(); 
 
  } 
}

#endif

#if ReferenceConstraint
// Demonstrate a reference constriant. 
 
class MyClass { 
  //... 
} 
 
// Use a reference constraint. 
class Test<T> where T : class { 
  T obj; 
 
  public Test() { 
    // The following statement is legal only 
    // because T is guaranteed to be a reference 
    // type, which can be assigned the value null. 
    obj = null; 
  } 
 
  // ... 
} 
 
class ClassConstraintDemo { 
  public static void Main() { 
 
    // The following is OK because MyClass is a class. 
    Test<MyClass> x = new Test<MyClass>(); 
 
    // The next line is in error because int is  
    // a value type. 
//    Test<int> y = new Test<int>(); 
  } 
}

#endif

#if ValueTypeConstraint

// Demonstrate a value type constriant. 
 
struct MyStruct { 
  //... 
} 
 
class MyClass { 
  // ... 
} 
 
class Test<T> where T : struct { 
  T obj; 
 
  public Test(T x) { 
    obj = x; 
  } 
 
  // ... 
} 
 
class ValueConstraintDemo { 
  public static void Main() { 
 
    // Both of these declarations are legal. 
 
    Test<MyStruct> x = new Test<MyStruct>(new MyStruct()); 
 
    Test<int> y = new Test<int>(10); 
 
    // But, the following declaration is illegal! 
//    Test<MyClass> z = new Test<MyClass>(new MyClass()); 
  } 
}

#endif

#if RelateTwo
// Create relationship between two type parameters.  
 
class A { 
  //... 
} 
 
class B : A { 
  // ... 
} 
 
// Here, V must inherit T. 
class Gen<T, V> where V : T {  
  // ... 
} 
 
class TwoConstraintDemo { 
  public static void Main() { 
 
    // This declaration is OK because B inherits A. 
    Gen<A, B> x = new Gen<A, B>(); 
 
    // This declaration is in error because 
    // A does not inherit B. 
//    Gen<B, A> y = new Gen<B, A>(); 
 
  } 
}

#endif

#if MultipleConstraints
// Use multiple where clauses. 
 
// Gen has two type arguments and both have 
// a where clause. 
class Gen<T, V> where T : class 
                where V : struct {  
  T ob1;  
  V ob2;  
 
  public Gen(T t, V v) { 
    ob1 = t; 
    ob2 = v; 
  } 
} 
 
class MultipleConstraintDemo { 
  public static void Main() { 
    // This is OK because string is a class and 
    // int is a value type. 
    Gen<string, int> obj = new Gen<string, int>("test", 11); 
 
    // The next line is wrong because bool is not 
    // a reference type. 
//    Gen<bool, int> obj = new Gen<bool, int>(true, 11); 
         
  } 
}


#endif

#if Default

// Demonstrate the default keyword. 
  
class MyClass { 
  //... 
} 
 
// Construct a default object of T. 
class Test<T> {  
  public T obj; 
 
  public Test() { 
    // The following statement would work 
    // only for reference types. 
//    obj = null; 
 
    // This statement works for both  
    // reference and value types. 
    obj = default(T); 
  } 
 
  // ... 
} 
 
class DefaultDemo { 
  public static void Main() { 
 
    // Construct Test using a reference type. 
    Test<MyClass> x = new Test<MyClass>(); 
 
    if(x.obj == null) 
      Console.WriteLine("x.obj is null."); 
 
    // Construct Test using a value type. 
    Test<int> y = new Test<int>(); 
 
    if(y.obj == 0) 
      Console.WriteLine("y.obj is 0."); 
  } 
}

#endif

#if GenericStruct
// Demonstrate a generic struct. 

// This structure is generic. 
struct XY<T> { 
  T x; 
  T y; 
 
  public XY(T a, T b) { 
    x = a; 
    y = b; 
  } 
 
  public T X { 
    get { return x; } 
    set { x = value; } 
  } 
 
  public T Y { 
    get { return y; } 
    set { y = value; } 
  } 
 
} 
 
class StructTest { 
  public static void Main() { 
    XY<int> xy = new XY<int>(10, 20); 
    XY<double> xy2 = new XY<double>(88.0, 99.0); 
 
    Console.WriteLine(xy.X + ", " + xy.Y); 
 
    Console.WriteLine(xy2.X + ", " + xy2.Y); 
  } 
}

#endif

#if GenericMethod
// Demonstrate a generic method. 
  
// A class of array utilities.  Notice that this is not 
// a generic class. 
class ArrayUtils {  
 
  // Copy an array, inserting a new element 
  // in the process.  This is a generic method. 
  public static bool copyInsert<T>(T e, int idx, 
                                   T[] src, T[] target) { 
 
    // See if target array is big enough. 
    if(target.Length < src.Length+1)  
      return false; 
 
    // Copy src to target, inserting e at idx in the proecess. 
    for(int i=0, j=0; i < src.Length; i++, j++) { 
      if(i == idx) { 
        target[j] = e; 
        j++; 
      } 
      target[j] = src[i]; 
    } 
     
    return true; 
  } 
} 
 
class GenMethDemo { 
  public static void Main() { 
    int[] nums = { 1, 2, 3 }; 
    int[] nums2 = new int[4]; 
 
    // Display contents of nums. 
    Console.Write("Contents of nums: "); 
    foreach(int x in nums) 
      Console.Write(x + " "); 
 
    Console.WriteLine(); 
 
    // Operate on an int array. 
    ArrayUtils.copyInsert(99, 2, nums, nums2); 
 
    // Display contents of nums2. 
    Console.Write("Contents of nums2: "); 
    foreach(int x in nums2) 
      Console.Write(x + " "); 
 
    Console.WriteLine(); 
 
 
    // Now, use copyInsert on an array of strings. 
    string[] strs = { "Generics", "are", "powerful."}; 
    string[] strs2 = new string[4]; 
 
    // Display contents of strs. 
    Console.Write("Contents of strs: "); 
    foreach(string s in strs) 
      Console.Write(s + " "); 
 
    Console.WriteLine(); 
 
    // Insert into a string array. 
    ArrayUtils.copyInsert("in C#", 1, strs, strs2); 
 
    // Display contents of strs2. 
    Console.Write("Contents of strs2: "); 
    foreach(string s in strs2) 
      Console.Write(s + " "); 
 
    Console.WriteLine(); 
 
    // This call is invalid because the first argument 
    // if of type double, and the third and fourth arguments 
    // have base types of int. 
//    ArrayUtils.copyInsert(0.01, 2, nums, nums2); 
 
  } 
}

#endif

#if GenericDelegate
// A simple generic delegate. 
   
// Declare a generic delegate.   
delegate T SomeOp<T>(T v);  
  
class GenDelegateDemo {  
  // Return the summation of the argument. 
  static int sum(int v) { 
    int result = 0; 
    for(int i=v; i>0; i--) 
      result += i; 
 
    return result; 
  } 
 
  // Return a string containing the reverse of the argument. 
  static string reflect(string str) { 
    string result = ""; 
 
    foreach(char ch in str) 
      result = ch + result; 
 
    return result; 
  } 
      
  public static void Main() {   
    // Construct an int delegate. Notice use of method group 
    // conversion on generic delegate. 
    SomeOp<int> intDel = sum;  
    Console.WriteLine(intDel(3)); 
 
    // Construct a string delegate. Also use method group conversion. 
    SomeOp<string> strDel = reflect;  
    Console.WriteLine(strDel("Hello")); 
  }  
}

#endif

#if EventWithGenericDelegate

// Derive a class from EventArgs.  
class MyEventArgs : EventArgs {  
  public int eventnum;  
}  
 
// Declare a generic delegate for an event.   
delegate void MyEventHandler<T, V>(T source, V args); 
  
// Declare an event class.  
class MyEvent {  
  static int count = 0;  
  
  public event MyEventHandler<MyEvent, MyEventArgs> SomeEvent;  
  
  // This fires SomeEvent.  
  public void OnSomeEvent() {  
    MyEventArgs arg = new MyEventArgs();  
  
    if(SomeEvent != null) {  
      arg.eventnum = count++;  
      SomeEvent(this, arg);  
    }  
  }  
}  
  
class X {  
  public void handler<T, V>(T source, V arg) where V : MyEventArgs {  
    Console.WriteLine("Event " + arg.eventnum +  
                      " received by an X object.");  
    Console.WriteLine("Source is " + source);  
    Console.WriteLine();  
  }  
}  
  
class Y {   
  public void handler<T,V>(T source, V arg) where V : MyEventArgs {  
    Console.WriteLine("Event " + arg.eventnum +  
                      " received by a Y object.");  
    Console.WriteLine("Source is " + source);  
    Console.WriteLine();  
  }  
}  
 
class UseGenericEventDelegate {  
  public static void Main() {   
    X ob1 = new X();  
    Y ob2 = new Y();  
    MyEvent evt = new MyEvent();  
  
    // Add handler() to the event list.  
    evt.SomeEvent += ob1.handler;  
    evt.SomeEvent += ob2.handler;  
  
    // Fire the event.  
    evt.OnSomeEvent();  
    evt.OnSomeEvent();  
  }  
}

#endif

#if GenericInterface
// Demonstrate a generic interface. 

public interface ISeries<T> { 
  T getNext(); // return next element in series 
  void reset(); // restart the series 
  void setStart(T v); // set the starting element 
} 
 
// Implement ISeries. 
class ByTwos<T> : ISeries<T> { 
  T start; 
  T val; 
 
  // This delegate defines the form of a method 
  // that will be called when the next element in 
  // the series is needed. 
  public delegate T IncByTwo(T v); 
 
  // This delegate reference will be assigned the  
  // method passed to the ByTwos constructor. 
  IncByTwo incr;  
 
  public ByTwos(IncByTwo incrMeth) { 
    start = default(T); 
    val = default(T); 
    incr = incrMeth; 
  } 
 
  public T getNext() { 
    val = incr(val); 
    return val; 
  } 
 
  public void reset() { 
    val = start; 
  } 
 
  public void setStart(T v) { 
    start = v; 
    val = start; 
  } 
} 
 
class ThreeD { 
  public int x, y, z; 
 
  public ThreeD(int a, int b, int c) { 
    x = a; 
    y = b; 
    z = c; 
  } 
} 
   
 
class GenIntfDemo { 
  // Define plus two for int. 
  static int intPlusTwo(int v) { 
    return v + 2; 
  } 
 
  // Define plus two for double. 
  static double doublePlusTwo(double v) { 
    return v + 2.0; 
  } 
 
  // Define plus two for ThreeD. 
  static ThreeD ThreeDPlusTwo(ThreeD v) { 
    if(v==null) return new ThreeD(0, 0, 0); 
    else return new ThreeD(v.x + 2, v.y + 2, v.z + 2); 
  } 
 
  public static void Main() { 
    // Demonstrate int series. 
    ByTwos<int> intBT = new ByTwos<int>(intPlusTwo); 
 
    for(int i=0; i < 5; i++) 
      Console.Write(intBT.getNext() + "  "); 
 
    Console.WriteLine(); 
 
 
    // Demonstrate double series. 
    ByTwos<double> dblBT = new ByTwos<double>(doublePlusTwo); 
 
    dblBT.setStart(11.4); 
 
    for(int i=0; i < 5; i++) 
      Console.Write(dblBT.getNext() + "  "); 
 
    Console.WriteLine(); 
 
 
    // Demonstrate ThreeD series. 
    ByTwos<ThreeD> ThrDBT = new ByTwos<ThreeD>(ThreeDPlusTwo); 
 
    ThreeD coord; 
    for(int i=0; i < 5; i++) { 
      coord = ThrDBT.getNext(); 
      Console.Write(coord.x + "," + 
                    coord.y + "," + 
                    coord.z + "  "); 
    } 
 
    Console.WriteLine(); 
 
  } 
}

#endif

#if IComparable
// Demonstrate IComparable. 
 
using System; 
 
class MyClass : IComparable { 
  public int val; 
 
  public MyClass(int x) { val = x; } 
 
  // Implement IComparable. 
  public int CompareTo(object obj) { 
    return val - ((MyClass) obj).val; 
  } 
} 
 
class CompareDemo { 
 
  // Require IComparable interface. 
  public static bool isIn<T>(T what, T[] obs) where T : IComparable { 
    foreach(T v in obs) 
      if(v.CompareTo(what) == 0) 
        return true; 
 
    return false; 
  } 
 
  // Demonstrate comparisons. 
  public static void Main() { 
    // Use isIn() with int. 
    int[] nums = { 1, 2, 3, 4, 5 }; 
 
    if(isIn(2, nums)) 
      Console.WriteLine("2 is found."); 
 
    if(isIn(99, nums)) 
      Console.WriteLine("This won't display."); 
 
 
    // Use isIn() with string. 
    string[] strs = { "one", "two", "Three"}; 
 
    if(isIn("two", strs)) 
      Console.WriteLine("two is found."); 
 
    if(isIn("five", strs)) 
      Console.WriteLine("This won't display."); 
 
 
    // Use isIn with MyClass. 
    MyClass[] mcs = { new MyClass(1), new MyClass(2), 
                      new MyClass(3), new MyClass(4) }; 
 
    if(isIn(new MyClass(3), mcs)) 
      Console.WriteLine("MyClass(3) is found."); 
 
    if(isIn(new MyClass(99), mcs)) 
      Console.WriteLine("This won't display."); 
  } 
}

#endif

#if IComparableT
// This version of MyClass implements IComparable<T> 
class MyClass : IComparable<MyClass> { 
  public int val; 
 
  public MyClass(int x) { val = x; } 
 
  public int CompareTo(MyClass obj) { 
    return val - obj.val; // Now, no cast is needed. 
  } 
 
}

#endif

#if GenericHierarchy
// A simple generic class hierarchy. 

// A generic base class. 
class Gen<T> {  
  T ob; 
    
  public Gen(T o) {  
    ob = o;  
  }  
  
  // Return ob.  
  public T getob() {  
    return ob;  
  }  
}  
 
// A class derived from Gen. 
class Gen2<T> : Gen<T> { 
  public Gen2(T o) : base(o) { 
    // ... 
  } 
} 
 
class GenHierDemo { 
  public static void Main() { 
    Gen2<string> g2 = new Gen2<string>("Hello"); 
 
    Console.WriteLine(g2.getob()); 
  } 
}

#endif

#if GenAddParam
// A derived class can add its own type parameters. 

// A generic base class. 
class Gen<T> {  
  T ob; // declare an object of type T  
    
  // Pass the constructor an object of 
  // type T. 
  public Gen(T o) {  
    ob = o;  
  }  
  
  // Return ob.  
  public T getob() {  
    return ob;  
  }  
}  
 
// A derived class of Gen that defines a second 
// type parameter, called V. 
class Gen2<T, V> : Gen<T> { 
  V ob2; 
 
  public Gen2(T o, V o2) : base(o) { 
    ob2 = o2; 
  } 
 
  public V getob2() { 
    return ob2; 
  } 
} 
  
// Create an object of type Gen2. 
class GenHierDemo2 {  
  public static void Main() {  
    
    // Create a Gen2 object for string and int. 
    Gen2<string, int> x = 
      new Gen2<string, int>("Value is: ", 99);  
 
    Console.Write(x.getob()); 
    Console.WriteLine(x.getob2()); 
  }  
}


#endif

#if NonGenBaseForGen

// A nongeneric class can be the base class 
// of a generic derived class. 
 
// A nongeneric class. 
class NonGen { 
  int num; 
 
  public NonGen(int i) { 
    num = i; 
  } 
 
  public int getnum() { 
    return num; 
  } 
} 
 
// A generic derived class. 
class Gen<T> : NonGen {  
  T ob; 
    
  public Gen(T o, int i) : base (i) {  
    ob = o;  
  }  
  
  // Return ob.  
  public T getob() {  
    return ob;  
  }  
}  
  
// Create a Gen object. 
class HierDemo3 {  
  public static void Main() {  
    
    // Create a Gen object for string. 
    Gen<String> w = new Gen<String>("Hello", 47); 
    
    Console.Write(w.getob() + " "); 
    Console.WriteLine(w.getnum()); 
  }  
} 


#endif

#if OverrideGen
// Overriding a virtual method in a generic class.  

// A generic base class.  
class Gen<T> {   
  protected T ob;   
     
  public Gen(T o) {   
    ob = o;   
  }   
   
  // Return ob. This method is virtual.  
  public virtual T getob() {   
    Console.Write("Gen's getob(): " );  
    return ob;   
  }   
}   
  
// A derived class of Gen that overrides getob().  
class Gen2<T> : Gen<T> {  
  
  public Gen2(T o) : base(o) {  }  
    
  // Override getob().  
  public override T getob() {   
    Console.Write("Gen2's getob(): ");  
    return ob;   
  }   
}  
   
// Demonstrate generic method override.  
class OverrideDemo {   
  public static void Main() {   
     
    // Create a Gen object for int.  
    Gen<int> iOb = new Gen<int>(88);  
 
    // This calls Gen's version of getob().  
    Console.WriteLine(iOb.getob());  
 
 
    // Now, create a Gen2 object and assign its  
    // reference to iOb (which is a Gen<int> variable). 
    iOb = new Gen2<int>(99);   
 
    // This calls Gen2's verison of getob().  
    Console.WriteLine(iOb.getob());  
  } 
}

#endif

#if OverrideAmbiguity

// Ambiguity can result when overloading 
// methods that use type parameters. 
// 
// This program will not compile. 
 

// A generic class that contains a potentially 
// ambiguous overload of the set() method. 
class Gen<T, V> {  
  T ob1;  
  V ob2;  
 
  // ... 
 
  // In some cases, these two methods 
  // will not differ in their parameter types. 
  public void set(T o) { 
    ob1 = o; 
  } 
 
  public void set(V o) { 
    ob2 = o; 
  } 
} 
 
class AmbiguityDemo { 
  public static void Main() { 
    Gen<int, double> ok = new Gen<int, double>(); 
 
    Gen<int, int> notOK = new Gen<int, int>(); 
 
    ok.set(10); // is valid, types differ 
 
    notOK.set(10); // ambiguous, types are the same 
     
  } 
}
#endif
}

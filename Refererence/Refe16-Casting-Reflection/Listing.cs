#define Obsolete
using System;
using System.Reflection;

namespace Refererence.Refe16_Casting_Reflection
{
#if Is
// Demonstrate is. 
 
class A {} 
class B : A {} 
 
class UseIs { 
  public static void Main() { 
    A a = new A(); 
    B b = new B(); 
 
    if(a is A) Console.WriteLine("a is an A"); 
    if(b is A)  
      Console.WriteLine("b is an A because it is derived from A"); 
    if(a is B)  
      Console.WriteLine("This won't display -- a not derived from B"); 
 
    if(b is B) Console.WriteLine("B is a B"); 
    if(a is object) Console.WriteLine("a is an object"); 
  } 
}

#endif

#if CheckCast

// Use is to avoid an invalid cast. 
 
class A {} 
class B : A {} 
 
class CheckCast { 
  public static void Main() { 
    A a = new A(); 
    B b = new B(); 
 
    // Check to see if a can be cast to B. 
    if(a is B)  // if so, do the cast 
      b = (B) a; 
    else // if not, skip the cast 
      b = null; 
 
    if(b==null)  
      Console.WriteLine("Cast b = (B) a is NOT allowed."); 
    else 
      Console.WriteLine("Cast b = (B) a is allowed"); 
  } 
}

#endif


#if As
// Demonstrate as. 
 
using System; 
 
class A {} 
class B : A {} 
 
class CheckCast { 
  public static void Main() { 
    A a = new A(); 
    B b = new B(); 
 
    b = a as B; // cast, if possible 
 
    if(b==null)  
      Console.WriteLine("Cast b = (B) a is NOT allowed."); 
    else 
      Console.WriteLine("Cast b = (B) a is allowed"); 
  } 
}

#endif

#if Typeof
// Demonstrate typeof. 
  
using System.IO; 
 
class UseTypeof { 
  public static void Main() { 
    Type t = typeof(StreamReader); 
 
    Console.WriteLine(t.FullName);     
 
    if(t.IsClass) Console.WriteLine("Is a class."); 
    if(t.IsAbstract) Console.WriteLine("Is abstract."); 
    else Console.WriteLine("Is concrete."); 
 
  } 
}

#endif

#if MethodReflection

// Analyze methods using reflection. 
class MyClass { 
  int x; 
  int y; 
 
  public MyClass(int i, int j) { 
    x = i; 
    y = j; 
  } 
 
  public int sum() { 
    return x+y; 
  } 
 
  public bool isBetween(int i) { 
    if(x < i && i < y) return true; 
    else return false; 
  } 
 
  public void set(int a, int b) { 
    x = a; 
    y = b; 
  } 
 
  public void set(double a, double b) { 
    x = (int) a; 
    y = (int) b; 
  } 
 
  public void show() { 
    Console.WriteLine(" x: {0}, y: {1}", x, y); 
  } 
} 
 
class ReflectDemo { 
  public static void Main() { 
    Type t = typeof(MyClass); // get a Type object representing MyClass 
 
    Console.WriteLine("Analyzing methods in " + t.Name);     
    Console.WriteLine(); 
 
    Console.WriteLine("Methods supported: "); 
 
    MethodInfo[] mi = t.GetMethods(); 
 
    // Display methods supported by MyClass. 
    foreach(MethodInfo m in mi) { 
      // Display return type and name. 
      Console.Write("   " + m.ReturnType.Name + 
                      " " + m.Name + "("); 
 
      // Display parameters. 
      ParameterInfo[] pi = m.GetParameters(); 
 
      for(int i=0; i < pi.Length; i++) { 
        Console.Write(pi[i].ParameterType.Name + 
                      " " + pi[i].Name); 
        if(i+1 < pi.Length) Console.Write(", "); 
      } 
 
      Console.WriteLine(")"); 
     
      Console.WriteLine(); 
    } 
  } 
}

#endif

#if InvokeMethDemo
// Invoke methods using reflection. 
using System; 
using System.Reflection; 
 
class MyClass { 
  int x; 
  int y; 
 
  public MyClass(int i, int j) { 
    x = i; 
    y = j; 
  } 
 
  public int sum() { 
    return x+y; 
  } 
 
  public bool isBetween(int i) { 
    if((x < i) && (i < y)) return true; 
    else return false; 
  } 
 
  public void set(int a, int b) { 
    Console.Write("Inside set(int, int). "); 
    x = a; 
    y = b; 
    show(); 
  } 
 
  // Overload set. 
  public void set(double a, double b) { 
    Console.Write("Inside set(double, double). "); 
    x = (int) a; 
    y = (int) b; 
    show(); 
  } 
 
  public void show() { 
    Console.WriteLine("Values are x: {0}, y: {1}", x, y); 
  } 
} 
 

class InvokeMethDemo { 
  public static void Main() { 
    Type t = typeof(MyClass);   
    MyClass reflectOb = new MyClass(10, 20); 
    int val; 
 
    Console.WriteLine("Invoking methods in " + t.Name);     
    Console.WriteLine(); 
    MethodInfo[] mi = t.GetMethods(); 
 
    // Invoke each method. 
    foreach(MethodInfo m in mi) { 
      // Get the parameters. 
      ParameterInfo[] pi = m.GetParameters(); 
 
      if(m.Name.CompareTo("set")==0 && 
         pi[0].ParameterType == typeof(int)) { 
        object[] args = new object[2]; 
        args[0] = 9; 
        args[1] = 18; 
        m.Invoke(reflectOb, args); 
      } 
      else if(m.Name.CompareTo("set")==0 && 
         pi[0].ParameterType == typeof(double)) { 
        object[] args = new object[2]; 
        args[0] = 1.12; 
        args[1] = 23.4; 
        m.Invoke(reflectOb, args); 
      } 
      else if(m.Name.CompareTo("sum")==0) { 
        val = (int) m.Invoke(reflectOb, null); 
        Console.WriteLine("sum is " + val); 
      } 
      else if(m.Name.CompareTo("isBetween")==0) { 
        object[] args = new object[1]; 
        args[0] = 14; 
        if((bool) m.Invoke(reflectOb, args)) 
          Console.WriteLine("14 is between x and y"); 
      } 
      else if(m.Name.CompareTo("show")==0) { 
        m.Invoke(reflectOb, null); 
      } 
    } 
  } 
}

#endif
      
#if CreateWithReflection
// Create an object using reflection. 
class MyClass { 
  int x; 
  int y; 
 
  public MyClass(int i) { 
    Console.WriteLine("Constructing MyClass(int, int). "); 
    x = y = i;  
  } 
 
  public MyClass(int i, int j) { 
    Console.WriteLine("Constructing MyClass(int, int). "); 
    x = i; 
    y = j; 
    show(); 
  } 
 
  public int sum() { 
    return x+y; 
  } 
 
  public bool isBetween(int i) { 
    if((x < i) && (i < y)) return true; 
    else return false; 
  } 
 
  public void set(int a, int b) { 
    Console.Write("Inside set(int, int). "); 
    x = a; 
    y = b; 
    show(); 
  } 
 
  // Overload set. 
  public void set(double a, double b) { 
    Console.Write("Inside set(double, double). "); 
    x = (int) a; 
    y = (int) b; 
    show(); 
  } 
 
  public void show() { 
    Console.WriteLine("Values are x: {0}, y: {1}", x, y); 
  } 
 
} 
 
class InvokeConsDemo { 
  public static void Main() { 
    Type t = typeof(MyClass); 
    int val; 
 
    // Get constructor info. 
    ConstructorInfo[] ci = t.GetConstructors(); 
 
    Console.WriteLine("Available constructors: "); 
    foreach(ConstructorInfo c in ci) { 
      // Display return type and name. 
      Console.Write("   " + t.Name + "("); 
 
      // Display parameters. 
      ParameterInfo[] pi = c.GetParameters(); 
 
      for(int i=0; i < pi.Length; i++) { 
        Console.Write(pi[i].ParameterType.Name + 
                      " " + pi[i].Name); 
        if(i+1 < pi.Length) Console.Write(", "); 
      } 
 
      Console.WriteLine(")"); 
    } 
    Console.WriteLine(); 
 
    // Find matching constructor. 
    int x; 
 
    for(x=0; x < ci.Length; x++) { 
      ParameterInfo[] pi =  ci[x].GetParameters(); 
      if(pi.Length == 2) break; 
    } 
 
    if(x == ci.Length) { 
      Console.WriteLine("No matching constructor found."); 
      return; 
    } 
    else 
      Console.WriteLine("Two-parameter constructor found.\n"); 
 
    // Construct the object.   
    object[] consargs = new object[2]; 
    consargs[0] = 10; 
    consargs[1] = 20; 
    object reflectOb = ci[x].Invoke(consargs); 
 
    Console.WriteLine("\nInvoking methods on reflectOb."); 
    Console.WriteLine(); 
    MethodInfo[] mi = t.GetMethods(); 
 
    // Invoke each method. 
    foreach(MethodInfo m in mi) { 
      // Get the parameters. 
      ParameterInfo[] pi = m.GetParameters(); 
 
      if(m.Name.CompareTo("set")==0 && 
         pi[0].ParameterType == typeof(int)) { 
        // This is set(int, int). 
        object[] args = new object[2]; 
        args[0] = 9; 
        args[1] = 18; 
        m.Invoke(reflectOb, args); 
      } 
      else if(m.Name.CompareTo("set")==0 && 
              pi[0].ParameterType == typeof(double)) { 
        // This is set(double, double). 
        object[] args = new object[2]; 
        args[0] = 1.12; 
        args[1] = 23.4; 
        m.Invoke(reflectOb, args); 
      } 
      else if(m.Name.CompareTo("sum")==0) { 
        val = (int) m.Invoke(reflectOb, null); 
        Console.WriteLine("sum is " + val); 
      } 
      else if(m.Name.CompareTo("isBetween")==0) { 
        object[] args = new object[1]; 
        args[0] = 14; 
        if((bool) m.Invoke(reflectOb, args)) 
          Console.WriteLine("14 is between x and y"); 
      } 
      else if(m.Name.CompareTo("show")==0) { 
        m.Invoke(reflectOb, null); 
      } 
    } 
  } 
}
#endif


#if Attribute

// A simple attribute example. 
    
using System.Reflection; 
  
[AttributeUsage(AttributeTargets.All)] 
public class RemarkAttribute : Attribute { 
  string pri_remark; // underlies remark property 
 
  public RemarkAttribute(string comment) { 
    pri_remark = comment; 
  } 
 
  public string remark { 
    get { 
      return pri_remark; 
    } 
  } 
}  
 
[RemarkAttribute("This class uses an attribute.")] 
class UseAttrib { 
  // ... 
} 
 
class AttribDemo {  
  public static void Main() {  
    Type t = typeof(UseAttrib); 
 
    Console.Write("Attributes in " + t.Name + ": "); 
 
    object[] attribs = t.GetCustomAttributes(false);  
    foreach(object o in attribs) { 
      Console.WriteLine(o); 
    } 
 
    Console.Write("Remark: "); 
 
    // Retrieve the RemarkAttribute. 
    Type tRemAtt = typeof(RemarkAttribute); 
    RemarkAttribute ra = (RemarkAttribute) 
          Attribute.GetCustomAttribute(t, tRemAtt); 
 
    Console.WriteLine(ra.remark); 
  }  
}

#endif

#if AttributeParameter
// Use a named attribute parameter. 
  
using System;  
using System.Reflection; 
  
[AttributeUsage(AttributeTargets.All)] 
public class RemarkAttribute : Attribute { 
  string pri_remark; // underlies remark property 
 
  public string supplement; // this is a named parameter 
 
  public RemarkAttribute(string comment) { 
    pri_remark = comment; 
    supplement = "None"; 
  } 
 
  public string remark { 
    get { 
      return pri_remark; 
    } 
  } 
}  
 
[RemarkAttribute("This class uses an attribute.", 
                 supplement = "This is additional info.")] 
class UseAttrib { 
  // ... 
} 
 
class NamedParamDemo {  
  public static void Main() {  
    Type t = typeof(UseAttrib); 
 
    Console.Write("Attributes in " + t.Name + ": "); 
 
    object[] attribs = t.GetCustomAttributes(false);  
    foreach(object o in attribs) { 
      Console.WriteLine(o); 
    } 
 
    // Retrieve the RemarkAttribute. 
    Type tRemAtt = typeof(RemarkAttribute); 
    RemarkAttribute ra = (RemarkAttribute) 
          Attribute.GetCustomAttribute(t, tRemAtt); 
 
    Console.Write("Remark: "); 
    Console.WriteLine(ra.remark); 
 
    Console.Write("Supplement: "); 
    Console.WriteLine(ra.supplement); 
  }  
}
#endif


#if AttributeParameterWithProperty
// Use a property as a named attribute parameter. 
  
using System;  
using System.Reflection; 
  
[AttributeUsage(AttributeTargets.All)] 
public class RemarkAttribute : Attribute { 
  string pri_remark; // underlies remark property 
 
  int pri_priority; // underlies priority property 
 
  public string supplement; // this is a named parameter 
 
  public RemarkAttribute(string comment) { 
    pri_remark = comment; 
    supplement = "None"; 
  } 
 
  public string remark { 
    get { 
      return pri_remark; 
    } 
  } 
 
  // Use a property as a named parameter. 
  public int priority { 
    get { 
      return pri_priority; 
    } 
    set { 
      pri_priority = value; 
    } 
  } 
}  
 
[RemarkAttribute("This class uses an attribute.", 
                 supplement = "This is additional info.", 
                 priority = 10)] 
class UseAttrib { 
  // ... 
} 
 
class NamedParamDemo {  
  public static void Main() {  
    Type t = typeof(UseAttrib); 
 
    Console.Write("Attributes in " + t.Name + ": "); 
 
    object[] attribs = t.GetCustomAttributes(false);  
    foreach(object o in attribs) { 
      Console.WriteLine(o); 
    } 
 
    // Retrieve the RemarkAttribute. 
    Type tRemAtt = typeof(RemarkAttribute); 
    RemarkAttribute ra = (RemarkAttribute) 
          Attribute.GetCustomAttribute(t, tRemAtt); 
 
    Console.Write("Remark: "); 
    Console.WriteLine(ra.remark); 
 
    Console.Write("Supplement: "); 
    Console.WriteLine(ra.supplement); 
 
    Console.WriteLine("Priority: " + ra.priority); 
  }  
}

#endif


#if Conditional
// Demonstrate the Conditional attribute. 
 
//#define TRIAL 
 
using System; 
using System.Diagnostics; 
 
class Test { 
 
  [Conditional("TRIAL")]  
  void trial() { 
    Console.WriteLine("Trial version, not for distribution."); 
  } 
 
  [Conditional("RELEASE")]  
  void release() { 
    Console.WriteLine("Final release version."); 
  } 
 
  public static void Main() { 
    Test t = new Test(); 
 
    t.trial(); // call only if TRIAL is defined 
    t.release(); // called only if RELEASE is defined 
  } 
}

#endif

}

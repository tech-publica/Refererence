


#if SimpleNameSpace

using System;
// Demonstrate a namespace. 
 
// Declare a namespace for counters. 
namespace Counter { 
  // A simple countdown counter. 
  class CountDown { 
    int val; 
 
    public CountDown(int n) { val = n; } 
 
    public void reset(int n) { 
      val = n; 
    } 
 
    public int count() { 
      if(val > 0) return val--; 
      else return 0; 
    } 
  } 
} 
 
class NSDemo { 
  public static void Main() { 
    // Notice how CountDown is qualified by Counter. 
    Counter.CountDown cd1 = new Counter.CountDown(10); 
    int i; 
 
    do { 
      i = cd1.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
 
    // Again, notice how CountDown is qualified by Counter. 
    Counter.CountDown cd2 = new Counter.CountDown(20); 
 
    do { 
      i = cd2.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
 
    cd2.reset(4); 
    do { 
      i = cd2.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
  } 
}
#endif


#if NameConflict
// Namespaces prevent name conflicts. 
  

// Declare a namespace for counters.  
namespace Counter {  
  // A simple countdown counter.  
  class CountDown {  
    int val;  
  
    public CountDown(int n) { 
      val = n; 
    }  
  
    public void reset(int n) {  
      val = n;  
    }  
  
    public int count() {  
      if(val > 0) return val--;  
      else return 0;  
    }  
  }  
}  
 
// Declare another namespace.  
namespace Counter2 {  
  /* This CountDown is in the default namespace and  
     does not conflict with the one in Counter. */ 
  class CountDown { 
    public void count() { 
      Console.WriteLine("This is count() in the " + 
                        "Counter2 namespace."); 
    } 
  } 
} 
 
class NSDemo2 {  
  public static void Main() {  
    // This is CountDown in the Counter namespace. 
    Counter.CountDown cd1 = new Counter.CountDown(10);  
 
    // This is CountDown in the default namespace. 
    Counter2.CountDown cd2 = new Counter2.CountDown(); 
 
    int i;  
  
    do {  
      i = cd1.count();  
      Console.Write(i + " ");  
    } while(i > 0);  
    Console.WriteLine();  
  
    cd2.count(); 
  }  
}

#endif

#if Using
// Demonstrate the using directive. 
 
using System; 
 
// Bring Counter into view. 
using Counter; 
 
// Declare a namespace for counters. 
namespace Counter { 
  // A simple countdown counter. 
  class CountDown { 
    int val; 
 
    public CountDown(int n) { 
      val = n; 
    } 
 
    public void reset(int n) { 
      val = n; 
    } 
 
    public int count() { 
      if(val > 0) return val--; 
      else return 0; 
    } 
  } 
} 
 
class NSDemo3 { 
  public static void Main() { 
    // now, CountDown can be used directly. 
    CountDown cd1 = new CountDown(10); 
    int i; 
 
    do { 
      i = cd1.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
 
    CountDown cd2 = new CountDown(20); 
 
    do { 
      i = cd2.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
 
    cd2.reset(4); 
    do { 
      i = cd2.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
  } 
}

#endif



#if Alias
// Demonstrate a using alias. 
 
using System; 
 
// Create an alias for Counter.CountDown. 
using Count = Counter.CountDown; 
 
// Declare a namespace for counters. 
namespace Counter { 
  // A simple countdown counter. 
  class CountDown { 
    int val; 
 
    public CountDown(int n) { 
      val = n; 
    } 
 
    public void reset(int n) { 
      val = n; 
    } 
 
    public int count() { 
      if(val > 0) return val--; 
      else return 0; 
    } 
  } 
} 
 
class NSDemo4 { 
  public static void Main() { 
    // Here, Count is used as a name for Counter.CountDown. 
    Count cd1 = new Count(10); 
    int i; 
 
    do { 
      i = cd1.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
 
    Count cd2 = new Count(20); 
 
    do { 
      i = cd2.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
 
    cd2.reset(4); 
    do { 
      i = cd2.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
  } 
}

#endif


#if Additive
// Namespaces are additive. 
 
using System; 
 
// Bring Counter into view. 
using Counter; 
 
// Here is one Counter namespace. 
namespace Counter { 
  // A simple countdown counter. 
  class CountDown { 
    int val; 
 
    public CountDown(int n) { 
      val = n; 
    } 
 
    public void reset(int n) { 
      val = n; 
    } 
 
    public int count() { 
      if(val > 0) return val--; 
      else return 0; 
    } 
  } 
} 
 
// Here is another Counter namespace. 
namespace Counter { 
  // A simple count-up counter. 
  class CountUp { 
    int val; 
    int target; 
 
    public int Target { 
      get{ 
        return target; 
      } 
    } 
 
    public CountUp(int n) { 
      target = n; 
      val = 0; 
    } 
 
    public void reset(int n) { 
      target = n; 
      val = 0; 
    } 
 
    public int count() { 
      if(val < target) return val++; 
      else return target; 
    } 
  } 
} 
 
class NSDemo5 { 
  public static void Main() { 
    CountDown cd = new CountDown(10); 
    CountUp cu = new CountUp(8); 
    int i; 
 
    do { 
      i = cd.count(); 
      Console.Write(i + " "); 
    } while(i > 0); 
    Console.WriteLine(); 
 
    do { 
      i = cu.count(); 
      Console.Write(i + " "); 
    } while(i < cu.Target); 
 
  } 
}

#endif

#if Nested
// Namespaces can be nested. 
 
using System; 
 
namespace NS1 { 
  class ClassA { 
     public ClassA() { 
       Console.WriteLine("constructing ClassA"); 
    } 
  } 
  namespace NS2 { // a nested namespace 
    class ClassB { 
       public ClassB() { 
         Console.WriteLine("constructing ClassB"); 
      } 
    } 
  } 
} 
 
class NestedNSDemo { 
  public static void Main() { 
    NS1.ClassA a = new NS1.ClassA(); 
 
 // NS2.ClassB b = new NS2.ClassB(); // Error!!! NS2 is not in view 
 
    NS1.NS2.ClassB b = new NS1.NS2.ClassB(); // this is right 
  } 
}


#endif

#if DontCompile
// Demonstrate why the :: qualifier is needed. 
//  
// This program will not compile. 
  
using System;  
 
// Use both the Counter and AnotherCounter namespace 
using Counter; 
using AnotherCounter; 
 
// Declare a namespace for counters.  
namespace Counter {  
  // A simple countdown counter.  
  class CountDown {  
    int val;  
  
    public CountDown(int n) {  
      val = n;  
    }  
 
    // ...  
  }  
}  
 
// Declare another namespaces for counters. 
namespace AnotherCounter {  
  // Declare another class called CountDown, which  
  // is in the global namespace. 
  class CountDown { 
    int val;  
  
    public CountDown(int n) {  
      val = n;  
    } 
 
    // ...   
  } 
} 
 
class WhyAliasQualifier {  
  public static void Main() {  
    int i;  
 
    // The following line is inherently ambiguous! 
    // Does it refer to CountDown in Counter or 
    // to CountDown in AnotherCounter? 
    CountDown cd1 = new CountDown(10); // Error! ! ! 
 
    // ... 
  }  
}
#endif

#if GlobalQualifier
// Demonstrate the :: qualifier.  
  
using System;  
  
using Counter; 
using AnotherCounter; 
 
// Give Counter an alias called Ctr. 
using Ctr = Counter;  
  
// Declare a namespace for counters.  
namespace Counter {  
  // A simple countdown counter.  
  class CountDown {  
    int val;  
  
    public CountDown(int n) {  
      val = n;  
    }  
 
    // ... 
  }  
}  
 
// Another counter namespace. 
namespace AnotherCounter {  
  // Declare another class called CountDown, which  
  // is in the global namespace. 
  class CountDown { 
    int val;  
  
    public CountDown(int n) {  
      val = n;  
    } 
 
    // ...   
  } 
} 
 
class AliasQualifierDemo {  
  public static void Main() {  
 
    // Here, the :: operator to resolves 
    // tells the compiler to use the CountDown 
    // that is in the Counter namespace. 
    Ctr::CountDown cd1 = new Ctr::CountDown(10);  
  
    // ... 
  }  
}
#endif


#if GlobalAlias
// Use the global alias. 
  
using System;  
  
// Give Counter an alias called Ctr. 
using Ctr = Counter;  
 
// Declare a namespace for counters.  
namespace Counter {  
  // A simple countdown counter.  
  class CountDown {  
    int val;  
 
    public CountDown(int n) {  
      val = n;  
    }  
 
    // ... 
  }  
}  
  
// Declare another class called CountDown, which  
// is in the global namespace.  
class CountDown { 
  int val;  
  
  public CountDown(int n) {  
    val = n;  
  }  
 
  // ...  
} 
 
class GlobalAliasQualifierDemo {  
  public static void Main() {  
 
    // Here, the :: qualifier tells the compiler 
    // to use the CountDown to use the Counter namespace. 
    Ctr::CountDown cd1 = new Ctr::CountDown(10);  
 
    // Next, create CountDown object from global namespace. 
    global::CountDown cd2 = new global::CountDown(10);  
 
    // ...  
  }  
}

#endif


#if Precompiler0 
 
#define EXPERIMENTAL 
#define TRIAL 
 
using System; 
 
class Test { 
  public static void Main() { 
     
    #if EXPERIMENTAL 
      Console.WriteLine("Compiled for experimental version."); 
    #endif 
 
    #if EXPERIMENTAL && TRIAL 
       Console.Error.WriteLine("Testing experimental trial version."); 
    #endif 
   
    Console.WriteLine("This is in all versions."); 
  } 
}

#endif



#if Precompiler1
// Demonstrate #else. 
 
#define EXPERIMENTAL 
 
using System; 
 
class Test { 
  public static void Main() { 
     
    #if EXPERIMENTAL 
      Console.WriteLine("Compiled for experimental version."); 
    #else 
      Console.WriteLine("Compiled for release."); 
    #endif 
 
    #if EXPERIMENTAL && TRIAL 
       Console.Error.WriteLine("Testing experimental trial version."); 
    #else 
       Console.Error.WriteLine("Not experimental trial version."); 
    #endif 
   
    Console.WriteLine("This is in all versions."); 
  } 
}
#endif


#if Precompiler2 
 
#define RELEASE 
 
using System; 
 
class Test { 
  public static void Main() { 
     
    #if EXPERIMENTAL 
      Console.WriteLine("Compiled for experimental version."); 
    #elif RELEASE 
      Console.WriteLine("Compiled for release."); 
    #else 
      Console.WriteLine("Compiled for internal testing."); 
    #endif 
 
    #if TRIAL && !RELEASE 
       Console.WriteLine("Trial version."); 
    #endif 
   
    Console.WriteLine("This is in all versions."); 
  } 
}

#endif


 

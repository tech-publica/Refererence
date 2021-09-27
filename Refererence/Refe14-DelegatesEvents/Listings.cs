//#define KeyPressEvent

using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Refe13_DelegatesEvents
{

#if SimpleDelegate
// A simple delegate example.  
 
// Declare a delegate.  
delegate string StrMod(string str); 
 
class DelegateTest { 
  // Replaces spaces with hyphens. 
  static string replaceSpaces(string a) { 
    Console.WriteLine("Replaces spaces with hyphens."); 
    return a.Replace(' ', '-'); 
  }  
 
  // Remove spaces. 
  static string removeSpaces(string a) { 
    string temp = ""; 
    int i; 
 
    Console.WriteLine("Removing spaces."); 
    for(i=0; i < a.Length; i++) 
      if(a[i] != ' ') temp += a[i]; 
 
    return temp; 
  }  
 
  // Reverse a string. 
  static string reverse(string a) { 
    string temp = ""; 
    int i; 
 
    Console.WriteLine("Reversing string."); 
    for(i=a.Length-1; i >= 0; i--) 
      temp += a[i]; 
 
    return temp; 
  } 
     
  public static void Main() {  
    // Construct a delegate. 
    StrMod strOp = new StrMod(replaceSpaces); 
    string str; 
 
    // Call methods through the delegate. 
    str = strOp("This is a test."); 
    Console.WriteLine("Resulting string: " + str); 
    Console.WriteLine(); 
      
    strOp = new StrMod(removeSpaces); 
    str = strOp("This is a test."); 
    Console.WriteLine("Resulting string: " + str); 
    Console.WriteLine(); 
 
    strOp = new StrMod(reverse); 
    str = strOp("This is a test."); 
    Console.WriteLine("Resulting string: " + str); 
  } 
}
#endif

#if GroupConversion

 
// Declare a delegate.  
delegate string StrMod(string str); 
 
class DelegateTest { 
  // Replaces spaces with hyphens. 
  static string replaceSpaces(string a) { 
    Console.WriteLine("Replaces spaces with hyphens."); 
    return a.Replace(' ', '-'); 
  }  
 
  // Remove spaces. 
  static string removeSpaces(string a) { 
    string temp = ""; 
    int i; 
 
    Console.WriteLine("Removing spaces."); 
    for(i=0; i < a.Length; i++) 
      if(a[i] != ' ') temp += a[i]; 
 
    return temp; 
  }  
 
  // Reverse a string. 
  static string reverse(string a) { 
    string temp = ""; 
    int i; 
 
    Console.WriteLine("Reversing string."); 
    for(i=a.Length-1; i >= 0; i--) 
      temp += a[i]; 
 
    return temp; 
  } 
}
public static void Main() {  
  // Construct a delegate using method group conversion.
  StrMod strOp = replaceSpaces; // use method group conversion 
  string str; 
 
  // Call methods through the delegate. 
  str = strOp("This is a test."); 
  Console.WriteLine("Resulting string: " + str); 
  Console.WriteLine(); 
      
  strOp = removeSpaces; // use method group conversion 
  str = strOp("This is a test."); 
  Console.WriteLine("Resulting string: " + str); 
  Console.WriteLine(); 
 
  strOp = reverse; // use method group converison 
  str = strOp("This is a test."); 
  Console.WriteLine("Resulting string: " + str); 
}

#endif

#if DelegateToInstanceMethod
// Delegates can refer to instance methods, too. 

// Declare a delegate.  
delegate string StrMod(string str); 
 
class StringOps { 
  // Replaces spaces with hyphens. 
  public string replaceSpaces(string a) { 
    Console.WriteLine("Replaces spaces with hyphens."); 
    return a.Replace(' ', '-'); 
  }  
 
  // Remove spaces. 
  public string removeSpaces(string a) { 
    string temp = ""; 
    int i; 
 
    Console.WriteLine("Removing spaces."); 
    for(i=0; i < a.Length; i++) 
      if(a[i] != ' ') temp += a[i]; 
 
    return temp; 
  }  
 
  // Reverse a string. 
  public string reverse(string a) { 
    string temp = ""; 
    int i, j; 
 
    Console.WriteLine("Reversing string."); 
    for(j=0, i=a.Length-1; i >= 0; i--, j++) 
      temp += a[i]; 
 
    return temp; 
  } 
} 
 
class DelegateTest {   
  public static void Main() {  
    StringOps so = new StringOps(); // create an instance of StringOps 
 
    // Initialize a delegate. 
    StrMod strOp = so.replaceSpaces; 
    string str; 
 
    // Call methods through delegates. 
    str = strOp("This is a test."); 
    Console.WriteLine("Resulting string: " + str); 
    Console.WriteLine(); 
      
    strOp = so.removeSpaces; 
    str = strOp("This is a test."); 
    Console.WriteLine("Resulting string: " + str); 
    Console.WriteLine(); 
 
    strOp = so.reverse; 
    str = strOp("This is a test."); 
    Console.WriteLine("Resulting string: " + str); 
  } 
}

#endif


#if MultiCasting
// Demonstrate multicasting.  
  
// Declare a delegate.  
delegate void StrMod(ref string str); 
 
class MultiCastDemo { 
  // Replaces spaces with hyphens. 
  static void replaceSpaces(ref string a) { 
    Console.WriteLine("Replaces spaces with hyphens."); 
    a = a.Replace(' ', '-'); 
  }  
 
  // Remove spaces. 
  static void removeSpaces(ref string a) { 
    string temp = ""; 
    int i; 
 
    Console.WriteLine("Removing spaces."); 
    for(i=0; i < a.Length; i++) 
      if(a[i] != ' ') temp += a[i]; 
 
    a = temp; 
  }  
 
  // Reverse a string. 
  static void reverse(ref string a) { 
    string temp = ""; 
    int i, j; 
 
    Console.WriteLine("Reversing string."); 
    for(j=0, i=a.Length-1; i >= 0; i--, j++) 
      temp += a[i]; 
 
    a = temp; 
  } 
     
  public static void Main() {  
    // Construct delegates. 
    StrMod strOp; 
    StrMod replaceSp = replaceSpaces; 
    StrMod removeSp = removeSpaces; 
    StrMod reverseStr = reverse; 
    string str = "This is a test"; 
 
    // Set up multicast. 
    strOp = replaceSp; 
    strOp += reverseStr; 
 
    // Call multicast. 
    strOp(ref str); 
    Console.WriteLine("Resulting string: " + str); 
    Console.WriteLine(); 
     
    // Remove replace and add remove. 
    strOp -= replaceSp; 
    strOp += removeSp; 
 
    str = "This is a test."; // reset string 
 
    // Call multicast. 
    strOp(ref str); 
    Console.WriteLine("Resulting string: " + str); 
    Console.WriteLine(); 
  } 
}

#endif


#if DelegateToAnonymousMethod
// Demonstrate an anonymous method. 

// Declare a delegate.   
delegate void CountIt();  
  
class AnonMethDemo {  
 
  public static void Main() {   
 
    // Here, the code for counting is passed 
    // as an anonymous method.     
     CountIt count = delegate {  
        // This is the block of code passed to the delegate. 
      for(int i=0; i <= 5; i++)  
        Console.WriteLine(i); 
    }; // notice the semicolon 
 
    count();  
  } 
}

#endif


#if DelegateToAnonymousMethodWithParam
// Demonstrate an anonymous method that takes an argument. 
  
// Notice that CountIt now has a parameter. 
delegate void CountIt(int end);  
  
class AnonMethDemo2 {  
 
  public static void Main() {   
 
    // Here, the ending value for the count 
    // is passed to the anonymous method. 
    CountIt count = delegate (int end) { 
      for(int i=0; i <= end; i++)  
        Console.WriteLine(i); 
    }; 
 
    count(3); 
    Console.WriteLine(); 
    count(5);  
  } 
}

#endif


#if DelegateToAnonymousMethodWithParam


// Demonstrate an anonymous method that returns a value. 
   
// This delegate returns a value. 
delegate int CountIt(int end);  
  
class AnonMethDemo3 {  
 
  public static void Main() {   
    int result; 
 
    // Here, the ending value for the count 
    // is passed to the anonymous method.   
    // A summation of the count is returned. 
    CountIt count = delegate (int end) { 
      int sum = 0; 
 
      for(int i=0; i <= end; i++) { 
        Console.WriteLine(i); 
        sum += i; 
      } 
      return sum; // return a value from an anonymous method 
    }; 
 
    result = count(3); 
    Console.WriteLine("Summation of 3 is " + result); 
    Console.WriteLine(); 
 
    result = count(5);  
    Console.WriteLine("Summation of 5 is " + result); 
  } 
}

#endif

#if CapturedVariable
// Demonstrate a captured variable. 
   
// This delegate returns int and takes an int argument. 
delegate int CountIt(int end);  
  
class VarCapture {  
 
  static CountIt counter() { 
    int sum = 0; 
 
    // Here, a summation of the count is stored 
    // in the captured variable sum. 
    CountIt ctObj = delegate (int end) { 
      for(int i=0; i <= end; i++) { 
        Console.WriteLine(i); 
        sum += i; 
      } 
      return sum; 
    }; 
    return ctObj; 
  } 
 
  public static void Main() {   
    // Get a counter 
    CountIt count = counter(); 
 
    int result;  
 
    result = count(3); 
    Console.WriteLine("Summation of 3 is " + result); 
    Console.WriteLine(); 
 
    result = count(5);  
    Console.WriteLine("Summation of 5 is " + result); 
  } 
}

#endif

#if Covariance_Contravariance
// Demonstrate covariance and contravariance. 
   
class X { 
  public int val; 
} 
 
// Y is derived from X. 
class Y : X { } 
 
// This delegate returns X and takes a Y argument. 
delegate X ChangeIt(Y obj);  
  
class CoContraVariance {  
 
  // This method returns X and has an X parameter. 
  static X incrA(X obj) { 
    X temp = new X(); 
    temp.val = obj.val + 1; 
    return temp; 
  } 
 
  // This method returns Y and has an Y parameter. 
  static Y incrB(Y obj) { 
    Y temp = new Y(); 
    temp.val = obj.val + 1; 
    return temp; 
  } 
 
  public static void Main() {   
    Y Yob = new Y(); 
 
    // In this case, the parameter to incrA 
    // is X and the parameter to ChangeIt is Y. 
    // Because of contravariance, the following 
    // line is OK. 
    ChangeIt change = incrA; 
 
    X Xob = change(Yob); 
 
    Console.WriteLine("Xob: " + Xob.val); 
 
    // In the next case, the return type of 
    // incrB is Y and the return type of  
    // ChangeIt is X. Because of covariance, 
    // the following line is OK. 
    change = incrB; 
 
    Yob = (Y) change(Yob); 
 
    Console.WriteLine("Yob: " + Yob.val); 
  } 
}


#endif

#if Event
// A very simple event demonstration. 
  
// Declare a delegate for an event.  
delegate void MyEventHandler(); 
 
// Declare an event class. 
class MyEvent { 
  public event MyEventHandler SomeEvent; 
 
  // This is called to fire the event. 
  public void OnSomeEvent() { 
    if(SomeEvent != null) 
      SomeEvent(); 
  } 
} 
 
class EventDemo { 
  // An event handler. 
  static void handler() { 
    Console.WriteLine("Event occurred"); 
  } 
 
  public static void Main() {  
    MyEvent evt = new MyEvent(); 
 
    // Add handler() to the event list. 
    evt.SomeEvent += handler; 
 
    // Fire the event. 
    evt.OnSomeEvent(); 
  } 
}
#endif


#if EventMulticast
// An event multicast demonstration. 
  
// Declare a delegate for an event.  
delegate void MyEventHandler(); 
 
// Declare an event class. 
class MyEvent { 
  public event MyEventHandler SomeEvent; 
 
  // This is called to fire the event. 
  public void OnSomeEvent() { 
    if(SomeEvent != null) 
      SomeEvent(); 
  } 
} 
 
class X { 
  public void Xhandler() { 
    Console.WriteLine("Event received by X object"); 
  } 
} 
 
class Y { 
  public void Yhandler() { 
    Console.WriteLine("Event received by Y object"); 
  } 
} 
 
class EventDemo2 { 
  static void handler() { 
    Console.WriteLine("Event received by EventDemo"); 
  } 
 
  public static void Main() {  
    MyEvent evt = new MyEvent(); 
    X xOb = new X(); 
    Y yOb = new Y(); 
 
    // Add handlers to the event list. 
    evt.SomeEvent += handler; 
    evt.SomeEvent += xOb.Xhandler; 
    evt.SomeEvent += yOb.Yhandler; 
 
    // Fire the event. 
    evt.OnSomeEvent(); 
    Console.WriteLine(); 
 
    // Remove a handler. 
    evt.SomeEvent -= xOb.Xhandler; 
    evt.OnSomeEvent(); 
  } 
}
#endif


#if ObjectNotificationHandler
/* Individual objects receive notifications when instance 
   event handlers are used. */ 
  

// Declare a delegate for an event.  
delegate void MyEventHandler(); 
 
// Declare an event class. 
class MyEvent { 
  public event MyEventHandler SomeEvent; 
 
  // This is called to fire the event. 
  public void OnSomeEvent() { 
    if(SomeEvent != null) 
      SomeEvent(); 
  } 
} 
 
class X { 
  int id; 
 
  public X(int x) { id = x; } 
 
  // This is an instance method that will be used as an event handler. 
  public void Xhandler() { 
    Console.WriteLine("Event received by object " + id); 
  } 
} 
 
class EventDemo3 { 
  public static void Main() {  
    MyEvent evt = new MyEvent(); 
    X o1 = new X(1); 
    X o2 = new X(2); 
    X o3 = new X(3); 
 
    evt.SomeEvent += o1.Xhandler; 
    evt.SomeEvent += o2.Xhandler; 
    evt.SomeEvent += o3.Xhandler; 
 
    // Fire the event. 
    evt.OnSomeEvent(); 
  } 
}

#endif

#if ClassNotificationHandler
/* A class receives the notification when  
   a static method is used as an event handler. */ 
  
// Declare a delegate for an event.  
delegate void MyEventHandler(); 
 
// Declare an event class. 
class MyEvent { 
  public event MyEventHandler SomeEvent; 
 
  // This is called to fire the event. 
  public void OnSomeEvent() { 
    if(SomeEvent != null) 
      SomeEvent(); 
  } 
} 
 
class X { 
 
  /* This is a static method that will be used as 
     an event handler. */ 
  public static void Xhandler() { 
    Console.WriteLine("Event received by class."); 
  } 
} 
 
class EventDemo4 { 
  public static void Main() {  
    MyEvent evt = new MyEvent(); 
 
    evt.SomeEvent += X.Xhandler; 
 
    // Fire the event. 
    evt.OnSomeEvent(); 
  } 
}

#endif


#if CustomEventManagement
// Create a custom means of managing the event invocation list.  
  
// Declare a delegate for an event.   
delegate void MyEventHandler();  
  
// Declare an event class that holds up to 3 events. 
class MyEvent {  
  MyEventHandler[] evnt = new MyEventHandler[3]; 
 
  public event MyEventHandler SomeEvent { 
    // Add an event to the list. 
    add { 
      int i; 
 
      for(i=0; i < 3; i++) 
        if(evnt[i] == null) { 
          evnt[i] = value;  
          break; 
        } 
      if (i == 3) Console.WriteLine("Event list full."); 
    } 
 
    // Remove an event from the list. 
    remove { 
      int i; 
 
      for(i=0; i < 3; i++) 
        if(evnt[i] == value) { 
          evnt[i] = null; 
          break; 
        } 
      if (i == 3) Console.WriteLine("Event handler not found."); 
    } 
  }  
  
  // This is called to fire the events.  
  public void OnSomeEvent() {  
      for(int i=0; i < 3; i++) 
        if(evnt[i] != null) evnt[i]();  
  }  
 
}  
  
// Create some classes that use MyEventHandler. 
class W { 
  public void Whandler() {  
    Console.WriteLine("Event received by W object");  
  }  
}  
  
class X { 
  public void Xhandler() {  
    Console.WriteLine("Event received by X object");  
  }  
}  
  
class Y {  
  public void Yhandler() {  
    Console.WriteLine("Event received by Y object");  
  }  
}  
  
class Z {  
  public void Zhandler() {  
    Console.WriteLine("Event received by Z object");  
  }  
}  
  
class EventDemo5 {  
  public static void Main() {   
    MyEvent evt = new MyEvent();  
    W wOb = new W();  
    X xOb = new X();  
    Y yOb = new Y();  
    Z zOb = new Z(); 
 
    // Add handlers to the event list. 
    Console.WriteLine("Adding events."); 
    evt.SomeEvent += wOb.Whandler;  
    evt.SomeEvent += xOb.Xhandler;  
    evt.SomeEvent += yOb.Yhandler;  
 
    // Can't store this one -- full. 
    evt.SomeEvent += zOb.Zhandler;  
    Console.WriteLine(); 
  
    // Fire the events.  
    evt.OnSomeEvent();  
    Console.WriteLine();  
  
    // Remove a handler. 
    Console.WriteLine("Remove xOb.Xhandler."); 
    evt.SomeEvent -= xOb.Xhandler;  
    evt.OnSomeEvent();  
 
    Console.WriteLine(); 
 
    // Try to remove it again. 
    Console.WriteLine("Try to remove xOb.Xhandler again."); 
    evt.SomeEvent -= xOb.Xhandler;  
    evt.OnSomeEvent();  
 
    Console.WriteLine(); 
 
    // Now, add Zhandler. 
    Console.WriteLine("Add zOb.Zhandler."); 
    evt.SomeEvent += zOb.Zhandler; 
    evt.OnSomeEvent();  
 
  }  
}


#endif

#if EventArgs
// A .NET-compatible event. 
 
 
// Derive a class from EventArgs. 
class MyEventArgs : EventArgs { 
  public int eventnum; 
} 
 
// Declare a delegate for an event.  
delegate void MyEventHandler(object source, MyEventArgs arg); 
 
// Declare an event class. 
class MyEvent { 
  static int count = 0; 
 
  public event MyEventHandler SomeEvent; 
 
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
  public void handler(object source, MyEventArgs arg) { 
    Console.WriteLine("Event " + arg.eventnum + 
                      " received by an X object."); 
    Console.WriteLine("Source is " + source); 
    Console.WriteLine(); 
  } 
} 
 
class Y {  
  public void handler(object source, MyEventArgs arg) { 
    Console.WriteLine("Event " + arg.eventnum + 
                      " received by a Y object."); 
    Console.WriteLine("Source is " + source); 
    Console.WriteLine(); 
  } 
} 
 
class EventDemo6 { 
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

#if EventHandler

// Use the built-in EventHandler delegate. 
  
// Declare an event class. 
class MyEvent { 
  public event EventHandler SomeEvent; // uses EventHandler delegate 
 
  // This is called to fire SomeEvent. 
  public void OnSomeEvent() { 
    if(SomeEvent != null) 
      SomeEvent(this, EventArgs.Empty); 
  } 
} 
 
class EventDemo { 
  static void handler(object source, EventArgs arg) { 
    Console.WriteLine("Event occurred"); 
    Console.WriteLine("Source is " + source); 
  } 
 
  public static void Main() {  
    MyEvent evt = new MyEvent(); 
 
    // Add handler() to the event list. 
    evt.SomeEvent += handler; 
 
    // Fire the event. 
    evt.OnSomeEvent(); 
  } 
}

#endif


#if EventWithAnonyMousMethod
// Use an anonymous method as an event handler.   
using System;  
  
// Declare a delegate for an event.   
delegate void MyEventHandler();  
  
// Declare an event class.  
class MyEvent {  
  public event MyEventHandler SomeEvent;  
  
  // This is called to fire the event.  
  public void OnSomeEvent() {  
    if(SomeEvent != null)  
      SomeEvent();  
  }  
}  
  
class AnonMethHandler {  
  public static void Main() {   
    MyEvent evt = new MyEvent();  
  
    // Use an anonymous method as an event handler. 
    evt.SomeEvent += delegate  {  
      // This is the event handler. 
      Console.WriteLine("Event received.");  
    }; 
 
    // Fire the event twice.  
    evt.OnSomeEvent();  
    evt.OnSomeEvent();  
  }  
}

#endif


#if KeyPressEvent
// A keypress event example.  
   
// Derive a custom EventArgs class that holds the key.  
class KeyEventArgs : EventArgs {  
  public char ch;  
}  
  
// Declare a delegate for an event.   
delegate void KeyHandler(object source, KeyEventArgs arg);  
  
// Declare a keypress event class.  
class KeyEvent {  
  public event KeyHandler KeyPress;  
  
  // This is called when a key is pressed.  
  public void OnKeyPress(char key) {  
    KeyEventArgs k = new KeyEventArgs();  
    
    if(KeyPress != null) {  
      k.ch = key;  
      KeyPress(this, k);  
    }  
  }  
}  
  
// Demonstrate KeyEvent.  
class KeyEventDemo {  
  public static void Main() {   
    KeyEvent kevt = new KeyEvent();  
    ConsoleKeyInfo key; 
    int count = 0; 
 
    // Use anonymous method to display the keypress.  
    kevt.KeyPress += delegate(object source, KeyEventArgs arg) {  
      Console.WriteLine(" Received keystroke: " + arg.ch);  
    };  
 
    // Use an anonymous method to count keypresses. 
    kevt.KeyPress += delegate (object source, KeyEventArgs arg) {  
      count++; // count is an outer variable 
    };  
  
    Console.WriteLine("Enter some characters. " +  
                      "Enter a period to stop.");  
    do {  
      key = Console.ReadKey(); 
      kevt.OnKeyPress(key.KeyChar);  
    } while(key.KeyChar != '.');  
 
    Console.WriteLine(count + " keys pressed.");  
  }  
}

#endif
}

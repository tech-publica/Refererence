using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Refe11_Interfaces_Structures
{

#if ISeries0

public interface ISeries { 
  int getNext(); // return next number in series 
  void reset(); // restart 
  void setStart(int x); // set starting value 
}

#endif



#if Impl0 
class ByTwos : ISeries { 
  int start; 
  int val; 
 
  public ByTwos() { 
    start = 0; 
    val = 0; 
  }  
 
  public int getNext() { 
    val += 2; 
    return val; 
  } 
 
  public void reset() { 
    val = start; 
  } 
 
  public void setStart(int x) { 
    start = x; 
    val = start; 
  } 
}


// Demonstrate the ByTwos interface. 
 

class SeriesDemo { 
  public static void Main() { 
    ByTwos ob = new ByTwos(); 
 
    for(int i=0; i < 5; i++) 
      Console.WriteLine("Next value is " + 
                         ob.getNext()); 
 
    Console.WriteLine("\nResetting"); 
    ob.reset(); 
    for(int i=0; i < 5; i++) 
      Console.WriteLine("Next value is " + 
                         ob.getNext()); 
 
    Console.WriteLine("\nStarting at 100"); 
    ob.setStart(100); 
    for(int i=0; i < 5; i++) 
      Console.WriteLine("Next value is " + 
                         ob.getNext()); 
  } 
}
#endif

#if Impl1

// Implement ISeries and add getPrevious(). 
 class ByTwos : ISeries { 
  int start; 
  int val; 
  int prev; 
 
  public ByTwos() { 
    start = 0; 
    val = 0; 
    prev = -2; 
  }  
 
  public int getNext() { 
    prev = val; 
    val += 2; 
    return val; 
  } 
 
  public void reset() { 
    val = start; 
    prev = start - 2; 
  } 
 
  public void setStart(int x) { 
    start = x; 
    val = start; 
    prev = val - 2; 
  } 
 
  // A method not specified by ISeries. 
  public int getPrevious() { 
    return prev; 
  } 
}

#endif


#if Primes

// Use ISeries to implement a series of prime numbers.  
class Primes : ISeries {  
  int start;  
  int val;  
  
  public Primes() {  
    start = 2;  
    val = 2;  
  }   
  
  public int getNext() {  
    int i, j; 
    bool isprime; 
 
    val++; 
    for(i = val; i < 1000000; i++) { 
      isprime = true; 
      for(j = 2; j < (i/j + 1); j++) { 
        if((i%j)==0) { 
          isprime = false; 
          break; 
        } 
      } 
      if(isprime) { 
        val = i; 
        break; 
      } 
    } 
    return val;        
  }  
  
  public void reset() {  
    val = start;  
  }  
  
  public void setStart(int x) {  
    start = x;  
    val = start;  
  }  
}

#endif



#if InterfaceReference

// Demonstrate interface references. 
 
// Define the interface 
public interface ISeries { 
  int getNext(); // return next number in series 
  void reset(); // restart 
  void setStart(int x); // set starting value 
} 
 
// Use ISeries to generate a sequence of even numbers. 
class ByTwos : ISeries { 
  int start; 
  int val; 
 
  public ByTwos() { 
    start = 0; 
    val = 0; 
  }  
 
  public int getNext() { 
    val += 2; 
    return val; 
  } 
 
  public void reset() { 
    val = start; 
  } 
 
  public void setStart(int x) { 
    start = x; 
    val = start; 
  } 
} 
 
// Use ISeries to implement a series of prime numbers.  
class Primes : ISeries {  
  int start;  
  int val;  
  
  public Primes() {  
    start = 2;  
    val = 2;  
  }   
  
  public int getNext() {  
    int i, j; 
    bool isprime; 
 
    val++; 
    for(i = val; i < 1000000; i++) { 
      isprime = true; 
      for(j = 2; j < (i/j + 1); j++) { 
        if((i%j)==0) { 
          isprime = false; 
          break; 
        } 
      } 
      if(isprime) { 
        val = i; 
        break; 
      } 
    } 
    return val;        
  }  
  
  public void reset() {  
    val = start;  
  }  
  
  public void setStart(int x) {  
    start = x;  
    val = start;  
  }  
} 
 
class SeriesDemo2 { 
  public static void Main() { 
    ByTwos twoOb = new ByTwos(); 
    Primes primeOb = new Primes(); 
    ISeries ob; 
 
    for(int i=0; i < 5; i++) { 
      ob = twoOb; 
      Console.WriteLine("Next ByTwos value is " + 
                          ob.getNext()); 
      ob = primeOb; 
      Console.WriteLine("Next prime number is " + 
                          ob.getNext()); 
    } 
  } 
}

#endif

#if InterfaceWithProperties

// Use a property in an interface. 
 

public interface ISeries { 
  // An interface property. 
  int next { 
    get; // return the next number in series 
    set; // set next number 
  } 
} 
 
// Implement ISeries. 
class ByTwos : ISeries { 
  int val; 
 
  public ByTwos() { 
    val = 0; 
  }  
 
  // get or set value 
  public int next { 
    get {  
      val += 2; 
      return val; 
    } 
    set { 
      val = value; 
    } 
  } 
} 
 
// Demonstrate an interface property. 
class SeriesDemo3 { 
  public static void Main() { 
    ByTwos ob = new ByTwos(); 
 
    // access series through a property 
    for(int i=0; i < 5; i++) 
      Console.WriteLine("Next value is " + ob.next); 
 
    Console.WriteLine("\nStarting at 21"); 
    ob.next = 21; 
    for(int i=0; i < 5; i++) 
      Console.WriteLine("Next value is " + ob.next); 
  } 
}

#endif

#if InterfaceWithIndexer
// Add an indexer in an interface. 
 

public interface ISeries { 
  // an interface property 
  int next { 
    get; // return the next number in series 
    set; // set next number 
  } 
 
  // an interface indexer 
  int this[int index] { 
    get; // return the specified number in series 
  } 
} 
 
// Implement ISeries. 
class ByTwos : ISeries { 
  int val; 
 
  public ByTwos() { 
    val = 0; 
  }  
 
  // get or set value using a property 
  public int next { 
    get {  
      val += 2; 
      return val; 
    } 
    set { 
      val = value; 
    } 
  } 
 
  // get a value using an index 
  public int this[int index] { 
    get {  
      val = 0; 
      for(int i=0; i<index; i++) 
        val += 2; 
      return val; 
    } 
  } 
} 
 
// Demonstrate an interface indexer. 
class SeriesDemo4 { 
  public static void Main() { 
    ByTwos ob = new ByTwos(); 
 
    // access series through a property 
    for(int i=0; i < 5; i++) 
      Console.WriteLine("Next value is " + ob.next); 
 
    Console.WriteLine("\nStarting at 21"); 
    ob.next = 21; 
    for(int i=0; i < 5; i++) 
      Console.WriteLine("Next value is " + 
                         ob.next); 
 
    Console.WriteLine("\nResetting to 0"); 
    ob.next = 0; 
 
    // access series through an indexer 
    for(int i=0; i < 5; i++) 
      Console.WriteLine("Next value is " + ob[i]); 
  } 
}

#endif

#if InterfaceInheritance
// One interface can inherit another. 
 
public interface A { 
  void meth1(); 
  void meth2(); 
} 
 
// B now includes meth1() and meth2() -- it adds meth3(). 
public interface B : A { 
  void meth3(); 
} 
 
// This class must implement all of A and B 
class MyClass : B { 
  public void meth1() { 
    Console.WriteLine("Implement meth1()."); 
  } 
 
  public void meth2() { 
    Console.WriteLine("Implement meth2()."); 
  } 
 
  public void meth3() { 
    Console.WriteLine("Implement meth3()."); 
  } 
} 
 
class IFExtend { 
  public static void Main() { 
    MyClass ob = new MyClass(); 
 
    ob.meth1(); 
    ob.meth2(); 
    ob.meth3(); 
  } 
}

#endif

#if InterfaceExplicitImpDef

interface IMyIF { 
  int myMeth(int x); 
}

class MyClass : IMyIF { 
  int IMyIF.myMeth(int x) { 
    return x / 3; 
  } 
}

#endif


#if InterfaceExplicitImplExample
// Explicitly implement an interface member. 
 

interface IEven { 
  bool isOdd(int x); 
  bool isEven(int x); 
} 
 
class MyClass : IEven { 
 
  // Explicit implementation. Notice that this member is private 
  // by default. 
  bool IEven.isOdd(int x) { 
    if((x%2) != 0) return true; 
    else return false; 
  } 
 
  // Normal implementation. 
  public bool isEven(int x) { 
    IEven o = this; // reference to invoking object 
 
    return !o.isOdd(x); 
  } 
} 
 
class Demo { 
  public static void Main() { 
    MyClass ob = new MyClass(); 
    bool result; 
 
    result = ob.isEven(4); 
    if(result) Console.WriteLine("4 is even."); 
 
    // result = ob.isOdd(4); // Error, isOdd not directly accessible 
 
    // But, this is OK. It creates an IEven reference to a MyClass object 
    // and then calls isOdd() through that reference. 
    IEven iRef = (IEven) ob; 
    result = iRef.isOdd(3); 
    if(result) Console.WriteLine("3 is odd."); 
 
  } 
}
#endif


#if ExplicitImplSameName
// Use explicit implementation to remove ambiguity. 
 
interface IMyIF_A { 
  int meth(int x); 
} 
 
interface IMyIF_B { 
  int meth(int x); 
} 
 
// MyClass implements both interfaces. 
class MyClass : IMyIF_A, IMyIF_B { 
 
  // explicitly implement the two meth()s 
  int IMyIF_A.meth(int x) { 
    return x + x; 
  } 
  int IMyIF_B.meth(int x) { 
    return x * x; 
  } 
 
  // call meth() through an interface reference. 
  public int methA(int x){ 
    IMyIF_A a_ob; 
    a_ob = this; 
    return a_ob.meth(x); // calls IMyIF_A 
  } 
 
  public int methB(int x){ 
    IMyIF_B b_ob; 
    b_ob = this; 
    return b_ob.meth(x); // calls IMyIF_B 
  } 
} 
 
class FQIFNames { 
  public static void Main() { 
    MyClass ob = new MyClass(); 
 
    Console.Write("Calling IMyIF_A.meth(): "); 
    Console.WriteLine(ob.methA(3)); 
 
    Console.Write("Calling IMyIF_B.meth(): "); 
    Console.WriteLine(ob.methB(3)); 
  } 
}


#endif


#if SwitchingImpls

// An encryption interface. 
public interface ICipher { 
  string encode(string str); 
  string decode(string str); 
}


/* A simple implementation of ICipher that codes 
   a message by shifting each character 1 position 
   higher.  Thus, A becomes B, and so on. */ 
class SimpleCipher : ICipher { 
     
  // Return an encoded string given plaintext. 
  public string encode(string str) { 
    string ciphertext = ""; 
 
    for(int i=0; i < str.Length; i++) 
      ciphertext = ciphertext + (char) (str[i] + 1); 
 
    return ciphertext; 
  } 
 
  // Return a decoded string given ciphertext. 
  public string decode(string str) { 
    string plaintext = ""; 
 
    for(int i=0; i < str.Length; i++) 
      plaintext = plaintext + (char) (str[i] - 1); 
 
    return plaintext; 
  } 
} 
 
/* This implementation of ICipher uses bit 
   manipulations and key. */ 
class BitCipher : ICipher { 
  ushort key; 
 
  // Specify a key when constructing BitCiphers. 
  public BitCipher(ushort k) { 
    key = k; 
  } 
     
  // Return an encoded string given plaintext. 
  public string encode(string str) { 
    string ciphertext = ""; 
 
    for(int i=0; i < str.Length; i++) 
      ciphertext = ciphertext + (char) (str[i] ^ key); 
 
    return ciphertext; 
  } 
 
  // Return adecoded string given ciphertext. 
  public string decode(string str) { 
    string plaintext = ""; 
 
    for(int i=0; i < str.Length; i++) 
      plaintext = plaintext + (char) (str[i] ^ key); 
 
    return plaintext; 
  } 
}

// Demonstrate ICipher. 
 
using System; 
 
class ICipherDemo { 
  public static void Main() { 
    ICipher ciphRef; 
    BitCipher bit = new BitCipher(27); 
    SimpleCipher sc = new SimpleCipher(); 
 
    string plain; 
    string coded; 
 
    // first, ciphRef refers to the simple cipher 
    ciphRef = sc; 
 
    Console.WriteLine("Using simple cipher."); 
 
    plain = "testing"; 
    coded = ciphRef.encode(plain); 
    Console.WriteLine("Cipher text: " + coded); 
 
    plain = ciphRef.decode(coded); 
    Console.WriteLine("Plain text: " + plain); 
 
    // now, let ciphRef refer to the bitwise cipher 
    ciphRef = bit; 
 
    Console.WriteLine("\nUsing bitwise cipher."); 
 
    plain = "testing"; 
    coded = ciphRef.encode(plain); 
    Console.WriteLine("Cipher text: " + coded); 
 
    plain = ciphRef.decode(coded); 
    Console.WriteLine("Plain text: " + plain); 
  } 
}

#endif


#if DynaImpl0
// Use ICipher. 
 
// A class for storing unlisted telephone numbers. 
class UnlistedPhone { 
  string pri_name;   // supports name property 
  string pri_number; // supports number property 
 
  ICipher crypt; // reference to encryption object 
 
  public UnlistedPhone(string name, string number, ICipher c) 
  { 
    crypt = c; // store encryption object 
 
    pri_name = crypt.encode(name); 
    pri_number = crypt.encode(number); 
  } 
 
  public string Name { 
    get { 
      return crypt.decode(pri_name); 
    } 
    set { 
      pri_name = crypt.encode(value); 
    } 
  } 
 
  public string Number { 
    get { 
      return crypt.decode(pri_number); 
    } 
    set { 
      pri_number = crypt.encode(value); 
    } 
  } 
} 
 
#endif

#if DynaImpl1
// Demonstrate UnlistedPhone 
class UnlistedDemo { 
  public static void Main() { 
    UnlistedPhone phone1 = 
        new UnlistedPhone("Tom", "555-3456", new BitCipher(27));  
    UnlistedPhone phone2 = 
        new UnlistedPhone("Mary", "555-8891", new BitCipher(9)); 
 
    Console.WriteLine("Unlisted number for " +  
                      phone1.Name + " is " + 
                      phone1.Number);  
 
    Console.WriteLine("Unlisted number for " +  
                      phone2.Name + " is " + 
                      phone2.Number);  
  } 
}

#endif

#if DynaImpl2
// This version uses SimpleCipher. 
 
class UnlistedDemo { 
  public static void Main() { 
 
    // now, use SimpleCipher rather than BitCipher 
    UnlistedPhone phone1 = 
        new UnlistedPhone("Tom", "555-3456", new SimpleCipher());  
    UnlistedPhone phone2 = 
        new UnlistedPhone("Mary", "555-8891", new SimpleCipher()); 
 
    Console.WriteLine("Unlisted number for " +  
                      phone1.Name + " is " + 
                      phone1.Number);  
 
    Console.WriteLine("Unlisted number for " +  
                      phone2.Name + " is " + 
                      phone2.Number);  
  } 
}

#endif

#if Structure
// Demonstrate a structure. 
 
// Define a structure. 
struct Book { 
  public string author; 
  public string title; 
  public int copyright; 
 
  public Book(string a, string t, int c) { 
    author = a; 
    title = t; 
    copyright = c; 
  } 
} 
 
// Demonstrate Book structure. 
class StructDemo { 
  public static void Main() { 
    Book book1 = new Book("J.R.R. Geeky", 
                          "The Lord of The Pings", 
                          2007); // explicit constructor 
 
    Book book2 = new Book(); // default constructor 
    Book book3; // no constructor 
 
    Console.WriteLine(book1.title + " by " + book1.author + 
                      ", (c) " + book1.copyright); 
    Console.WriteLine(); 
 
    if(book2.title == null) 
      Console.WriteLine("book2.title is null."); 
    // now, give book2 some info 
    book2.title = "Brave New World"; 
    book2.author = "Aldous Huxley"; 
    book2.copyright = 1932; 
    Console.Write("book2 now contains: "); 
    Console.WriteLine(book2.title + " by " + book2.author + 
                      ", (c) " + book2.copyright); 
 
    Console.WriteLine(); 
 
// Console.WriteLine(book3.title); // error, must initialize first 
    book3.title = "Red Storm Rising"; 
 
    Console.WriteLine(book3.title); // now OK 
  } 
}

#endif



#if CopyStruct

// Copy a struct. 
 

// Define a structure. 
struct MyStruct { 
  public int x; 
} 
 
// Demonstrate structure assignment. 
class StructAssignment { 
  public static void Main() { 
    MyStruct a; 
    MyStruct b; 
 
    a.x = 10; 
    b.x = 20; 
 
    Console.WriteLine("a.x {0}, b.x {1}", a.x, b.x); 
 
    a = b; 
    b.x = 30; 
 
    Console.WriteLine("a.x {0}, b.x {1}", a.x, b.x); 
  } 
}

#endif

#if CopyClass
// Copy a class. 
 
// Define a Class. 
class MyClass { 
  public int x; 
} 
 
// Now show a class object assignment. 
class ClassAssignment { 
  public static void Main() { 
    MyClass a = new MyClass(); 
    MyClass b = new MyClass(); 
 
    a.x = 10; 
    b.x = 20; 
 
    Console.WriteLine("a.x {0}, b.x {1}", a.x, b.x); 
 
    a = b; 
    b.x = 30; 
 
    Console.WriteLine("a.x {0}, b.x {1}", a.x, b.x); 
  } 
}

#endif

#if Packet
// Structures are good when grouping data. 
 
// Define a packet structure. 
struct PacketHeader { 
  public uint packNum; // packet number 
  public ushort packLen; // length of packet 
} 
 
// Use PacketHeader to create an e-commerce transaction record. 
class Transaction { 
  static uint transacNum = 0; 
 
  PacketHeader ph;  // incorporate PacketHeader into Transaction 
  string accountNum; 
  double amount; 
 
  public Transaction(string acc, double val) { 
   // create packet header 
    ph.packNum = transacNum++;  
    ph.packLen = 512;  // arbitrary length 
 
    accountNum = acc; 
    amount = val; 
  } 
 
  // Simulate a transaction. 
  public void sendTransaction() { 
    Console.WriteLine("Packet #: " + ph.packNum + 
                      ", Length: " + ph.packLen + 
                      ",\n    Account #: " + accountNum + 
                      ", Amount: {0:C}\n", amount); 
  } 
} 
 
// Demonstrate Packet 
class PacketDemo { 
  public static void Main() { 
    Transaction t = new Transaction("31243", -100.12); 
    Transaction t2 = new Transaction("AB4655", 345.25); 
    Transaction t3 = new Transaction("8475-09", 9800.00); 
 
    t.sendTransaction(); 
    t2.sendTransaction(); 
    t3.sendTransaction(); 
  } 
}

#endif

#if Enum
// Demonstrate an enumeration. 
 
class EnumDemo { 
  enum Apple { Jonathan, GoldenDel, RedDel, Winesap, 
               Cortland, McIntosh }; 
 
  public static void Main() { 
    string[] color = { 
      "Red", 
      "Yellow", 
      "Red", 
      "Red", 
      "Red", 
      "Reddish Green" 
    }; 
 
    Apple i; // declare an enum variable 
 
    // use i to cycle through the enum 
    for(i = Apple.Jonathan; i <= Apple.McIntosh; i++)  
      Console.WriteLine(i + " has value of " + (int)i); 
 
    Console.WriteLine(); 
 
    // use an enumeration to index an array 
    for(i = Apple.Jonathan; i <= Apple.McIntosh; i++)  
      Console.WriteLine("Color of " + i + " is " + 
                         color[(int)i]); 
 
  } 
}

#endif

#if SwitchEnum
// Simulate a conveyor belt 
 
class ConveyorControl { 
  // enumerate the conveyor commands 
  public enum Action { start, stop, forward, reverse }; 
 
  public void conveyor(Action com) { 
    switch(com) { 
      case Action.start: 
        Console.WriteLine("Starting conveyor."); 
        break; 
      case Action.stop: 
        Console.WriteLine("Stopping conveyor."); 
        break; 
      case Action.forward: 
        Console.WriteLine("Moving forward."); 
        break; 
      case Action.reverse: 
        Console.WriteLine("Moving backward."); 
        break; 
    } 
  } 
} 
 
class ConveyorDemo { 
  public static void Main() { 
    ConveyorControl c = new ConveyorControl(); 
 
    c.conveyor(ConveyorControl.Action.start); 
    c.conveyor(ConveyorControl.Action.forward); 
    c.conveyor(ConveyorControl.Action.reverse); 
    c.conveyor(ConveyorControl.Action.stop); 
     
  } 
}
#endif

}

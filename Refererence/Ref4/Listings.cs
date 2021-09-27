//#define PosNeg
//#define PosnegZero
//#define Ladder
//#define SwitchDemo
//#define SwitchDemo2
//#define EmptyCasesCanFall
//#define DecrFor
//#define FindPrimes
//#define Comma
//#define Comma2
//#define ForDemo
//#define Empty
//#define Empty2
//#define Empty3
//#define ForVar
//#define WhileDemo
//#define Power
//#define BreakDemo
//#define BreakDemo2
//#define FindSmallestFactor
//#define BreakNested
//#define ContDemo
//#define SwitchGoto
//#define UseGoto

using System;
using System.Collections.Generic;
using System.Text;



namespace Refererence.Ref4
{


#if PosNeg
// Determine if a value is positive or negative. 
 
class PosNeg {  
  public static void Main() { 
    int i; 
 
    for(i=-5; i <= 5; i++) { 
      Console.Write("Testing " + i + ": "); 
 
      if(i < 0) Console.WriteLine("negative"); 
      else Console.WriteLine("positive"); 
    } 
  } 
}
#endif


#if PosnegZero
// Determine if a value is positive, negative, or zero. 
 
 
class PosNegZero {  
  public static void Main() { 
    int i; 
 
    for(i=-5; i <= 5; i++) { 
 
      Console.Write("Testing " + i + ": "); 
 
      if(i < 0) Console.WriteLine("negative"); 
      else if(i == 0) Console.WriteLine("no sign"); 
        else Console.WriteLine("positive"); 
    } 
  } 
}
#endif


#if Ladder
 
// demo of the % operator and the if construct

class Ladder {    
  public static void Main() {    
    int num; 
 
    for(num = 2; num < 12; num++) { 
      if((num % 2) == 0) 
        Console.WriteLine("Smallest factor of " + num + " is 2.");  
      else if((num % 3) == 0)  
        Console.WriteLine("Smallest factor of " + num + " is 3.");  
      else if((num % 5) == 0) 
        Console.WriteLine("Smallest factor of " + num + " is 5.");  
      else if((num % 7) == 0)  
        Console.WriteLine("Smallest factor of " + num + " is 7.");  
      else  
        Console.WriteLine(num + " is not divisible by 2, 3, 5, or 7.");  
    } 
  } 
}
#endif


#if SwitchDemo
// Demonstrate the switch. 
 
 
class SwitchDemo {   
  public static void Main() { 
    int i; 
 
    for(i=0; i<10; i++) 
      switch(i) { 
        case 0:  
          Console.WriteLine("i is zero"); 
          break; 
        case 1:  
          Console.WriteLine("i is one"); 
          break; 
        case 2:  
          Console.WriteLine("i is two"); 
          break; 
        case 3:  
          Console.WriteLine("i is three"); 
          break; 
        case 4:  
          Console.WriteLine("i is four"); 
          break; 
        default:  
          Console.WriteLine("i is five or more"); 
          break; 
      } 
  }   
}
#endif

#if SwitchDemo2
// Use a char to control the switch. 
 
class SwitchDemo2 {   
  public static void Main() { 
    char ch; 
 
    for(ch='A'; ch<= 'E'; ch++) 
      switch(ch) { 
        case 'A':  
          Console.WriteLine("ch is A"); 
          break; 
        case 'B':  
          Console.WriteLine("ch is B"); 
          break; 
        case 'C':  
          Console.WriteLine("ch is C"); 
          break; 
        case 'D':  
          Console.WriteLine("ch is D"); 
          break; 
        case 'E':  
          Console.WriteLine("ch is E"); 
          break; 
      }     
  } 
}
#endif

#if EmptyCasesCanFall
// Empty cases can fall through. 
 
class EmptyCasesCanFall {   
  public static void Main() { 
    int i; 
 
    for(i=1; i < 5; i++)  
      switch(i) { 
        case 1: 
        case 2: 
        case 3: Console.WriteLine("i is 1, 2 or 3"); 
          break; 
        case 4: Console.WriteLine("i is 4"); 
          break; 
      } 
 
  } 
}
#endif


#if DecrFor
// A negatively running for loop. 
 

class DecrFor {     
  public static void Main() {     
    int x; 
 
    for(x = 100; x > -100; x -= 5) 
      Console.WriteLine(x); 
  } 
}
#endif



#if FindPrimes
/* 
   Determine if a number is prime.  If it is not, 
   then display its largest factor. 
*/ 
 
class FindPrimes {    
  public static void Main() {    
    int num; 
    int i; 
    int factor; 
    bool isprime; 
 
 
    for(num = 2; num < 20; num++) { 
      isprime = true;  
      factor = 0; 
 
      // see if num is evenly divisible 
      for(i=2; i <= num/2; i++) { 
        if((num % i) == 0) { 
          // num is evenly divisible -- not prime 
          isprime = false; 
          factor = i; 
        } 
      } 
 
      if(isprime) 
        Console.WriteLine(num + " is prime."); 
      else 
        Console.WriteLine("Largest factor of " + num + 
                          " is " + factor); 
    } 
 
  }    
}
#endif


#if Comma
// Use commas in a for statement. 
 
class Comma {    
  public static void Main() {    
    int i, j; 
 
    for(i=0, j=10; i < j; i++, j--) 
      Console.WriteLine("i and j: " + i + " " + j); 
  } 
}
#endif


#if Comma2
/* 
   Use commas in a for statement to find 
   the largest and smallest factor of a number. 
*/ 
 
class Comma2 {    
  public static void Main() {    
    int i, j; 
    int smallest, largest; 
    int num; 
 
    num = 100; 
    
    smallest = largest = 1; 
 
    for(i=2, j=num/2; (i <= num/2) & (j >= 2); i++, j--) { 
 
      if((smallest == 1) & ((num % i) == 0))  
        smallest = i; 
 
      if((largest == 1) & ((num % j) == 0))  
        largest = j; 
 
    } 
 
    Console.WriteLine("Largest factor: " + largest); 
    Console.WriteLine("Smallest factor: " + smallest); 
  } 
}
#endif

#if ForDemo
// Loop condition can be any bool expression. 
 
class ForDemo {    
  public static void Main() {    
    int i, j; 
    bool done = false; 
 
    for(i=0, j=100; !done; i++, j--) { 
 
      if(i*i >= j) done = true; 
 
      Console.WriteLine("i, j: " + i + " " + j); 
    } 
 
  } 
}
#endif

#if Empty
// Parts of the for can be empty.  
 
class Empty {   
  public static void Main() { 
    int i; 
 
    for(i = 0; i < 10; ) { 
      Console.WriteLine("Pass #" + i); 
      i++; // increment loop control var 
    } 
 
  }   
}
#endif


#if Empty2
// Move more out of the for loop. 
 
class Empty2 {   
  public static void Main() { 
    int i; 
 
    i = 0; // move initialization out of loop 
    for(; i < 10; ) { 
      Console.WriteLine("Pass #" + i); 
      i++; // increment loop control var 
    } 
 
  }   
}
#endif

#if Empty3
// The body of a loop can be empty. 
 
class Empty3 {   
  public static void Main() { 
    int i; 
    int sum = 0; 
 
    // sum the numbers through 5  
    for(i = 1; i <= 5; sum += i++) ; 
 
    Console.WriteLine("Sum is " + sum); 
  }   
}
#endif

#if Forvar
// Declare loop control variable inside the for. 
 
class ForVar {   
  public static void Main() { 
    int sum = 0; 
    int fact = 1; 
 
    // Compute the factorial of the numbers through 5. 
    for(int i = 1; i <= 5; i++) {  
      sum += i;  // i is known throughout the loop 
      fact *= i; 
    } 
 
    // But, i is not known here. 
 
    Console.WriteLine("Sum is " + sum); 
    Console.WriteLine("Factorial is " + fact); 
  }   
}
#endif


#if WhileDemo
// Compute the order of magnitude of an integer 

class WhileDemo {   
  public static void Main() { 
    int num; 
    int mag; 
 
    num = 435679; 
    mag = 0; 
 
    Console.WriteLine("Number: " + num); 
 
    while(num > 0) { 
      mag++; 
      num = num / 10; 
    }; 
 
    Console.WriteLine("Magnitude: " + mag); 
  }   
}
#endif

#if Power
// Compute integer powers of 2. 

class Power {   
  public static void Main() { 
    int e; 
    int result; 
 
    for(int i=0; i < 10; i++) { 
      result = 1; 
      e = i; 
 
      while(e > 0) { 
        result *= 2; 
        e--; 
      } 
 
      Console.WriteLine("2 to the " + i +  
                         " power is " + result);        
    } 
  }   
}
#endif

#if DoWhileDemo

// Display the digits of an integer in reverse order. 

class DoWhileDemo {   
  public static void Main() { 
    int num; 
    int nextdigit; 
 
    num = 198; 
 
    Console.WriteLine("Number: " + num); 
 
    Console.Write("Number in reverse order: "); 
 
    do { 
      nextdigit = num % 10; 
      Console.Write(nextdigit); 
      num = num / 10; 
    } while(num > 0); 
 
    Console.WriteLine(); 
  }   
}
#endif


#if BreakDemo
// Using break to exit a loop.   
 
class BreakDemo {  
  public static void Main() {  
 
    // use break to exit this loop 
    for(int i=-10; i <= 10; i++) {  
      if(i > 0) break; // terminate loop when i is positive 
      Console.Write(i + " ");  
    }  
    Console.WriteLine("Done");  
  }  
}
#endif

#if BreakDemo2
// Using break to exit a do-while loop.   
 
class BreakDemo2 {  
  public static void Main() {  
    int i; 
 
    i = -10;     
    do { 
      if(i > 0) break; 
      Console.Write(i + " "); 
      i++; 
    } while(i <= 10); 
  
    Console.WriteLine("Done");  
  }  
}
#endif


#if FindSmallestFactor
// Find the smallest factor of a value. 

class FindSmallestFactor {  
  public static void Main() {  
    int factor = 1; 
    int num = 1000; 
      
    for(int i=2; i < num/2; i++) {  
      if((num%i) == 0) { 
        factor = i; 
        break; // stop loop when factor is found 
      } 
    }  
    Console.WriteLine("Smallest factor is " + factor);  
  }  
}
#endif

#if BreakNested
// Using break with nested loops.  
 

class BreakNested {  
  public static void Main() {  
  
    for(int i=0; i<3; i++) {  
      Console.WriteLine("Outer loop count: " + i);  
      Console.Write("    Inner loop count: "); 
 
      int t = 0;             
      while(t < 100) {  
        if(t == 10) break; // terminate loop if t is 10  
        Console.Write(t + " ");  
        t++; 
      }  
      Console.WriteLine();  
    }  
    Console.WriteLine("Loops complete.");  
  }  
}
#endif


#if ContDemo
// Use continue. 
 

class ContDemo {   
  public static void Main() { 
 
    // print even numbers between 0 and 100 
    for(int i = 0; i <= 100; i++) {  
      if((i%2) != 0) continue; // iterate 
      Console.WriteLine(i); 
    } 
 
  }   
}

#endif

#if SwitchGoto
// Use goto with a switch. 
 
class SwitchGoto {   
  public static void Main() { 
 
    for(int i=1; i < 5; i++) { 
      switch(i) { 
        case 1: 
          Console.WriteLine("In case 1"); 
          goto case 3; 
        case 2: 
          Console.WriteLine("In case 2"); 
          goto case 1; 
        case 3: 
          Console.WriteLine("In case 3"); 
          goto default; 
        default: 
          Console.WriteLine("In default"); 
          break; 
      } 
 
      Console.WriteLine(); 
    } 
 
//    goto case 1; // Error! Can't jump into a switch. 
  } 
}

#endif

#if UseGoto
// Demonstrate the goto. 
  
class UseGoto {     
  public static void Main() {     
    int i=0, j=0, k=0; 
 
    for(i=0; i < 10; i++) { 
      for(j=0; j < 10; j++ ) { 
        for(k=0; k < 10; k++) { 
          Console.WriteLine("i, j, k: " + i + " " + j + " " + k); 
          if(k == 3) goto stop; 
        } 
      } 
    } 
 
stop: 
    Console.WriteLine("Stopped! i, j, k: " + i + ", " + j + " " + k); 
    
  }  
}
#endif

}

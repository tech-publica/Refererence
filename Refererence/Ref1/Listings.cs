using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Ref1
{


    /*

    class Example0
    {
        // A C# program begins with a call to Main(). 
        public static void Main()
        {
            Console.WriteLine("A simple C# program.");
        }
    }

   

  

    // This version does not include the using System statement. 
 
    class Example1 { 
 
      // A C# program begins with a call to Main(). 
      public static void Main() { 
 
        // Here, Console.WriteLine is fully qualified. 
        System.Console.WriteLine("A simple C# program."); 
      } 
    }


    // This program demonstrates variables.  
 
 
 
    class Example2 {   
      public static void Main() {   
        int x; // this declares a variable  
        int y; // this declares another variable  
  
        x = 100; // this assigns 100 to x 
  
        Console.WriteLine("x contains " + x);   
  
        y = x / 2;  
  
        Console.Write("y contains x / 2: ");  
        Console.WriteLine(y);  
      }   
    }


  
       //This program illustrates the differences    between int and double. 

 

 
    class Example3 {  
      public static void Main() {  
        int ivar;     // this declares an int variable 
        double dvar;  // this declares a floating-point variable 
 
        ivar = 100;   // assign ivar the value 100 
    
        dvar = 100.0; // assign dvar the value 100.0 
 
        Console.WriteLine("Original value of ivar: " + ivar); 
        Console.WriteLine("Original value of dvar: " + dvar); 
 
        Console.WriteLine(); // print a blank line 
 
        // now, divide both by 3 
        ivar = ivar / 3;  
        dvar = dvar / 3.0; 
 
        Console.WriteLine("ivar after division: " + ivar); 
        Console.WriteLine("dvar after division: " + dvar); 
      }  
    }


    // Compute the area of a circle. 
  

   
    class Circle {   
      public static void Main() {   
        double radius; 
        double area; 
 
        radius = 10.0; 
        area = radius * radius * 3.1416; 
 
        Console.WriteLine("Area is " + area); 
      }   
    }


    // Demonstrate the if.  
 

 
    class IfDemo {  
      public static void Main() {  
        int a, b, c;  
  
        a = 2;  
        b = 3;  
  
        if(a < b) Console.WriteLine("a is less than b"); 
 
        // this won't display anything  
        if(a == b) Console.WriteLine("you won't see this");  
 
        Console.WriteLine(); 
 
        c = a - b; // c contains -1 
 
        Console.WriteLine("c contains -1"); 
        if(c >= 0) Console.WriteLine("c is non-negative"); 
        if(c < 0) Console.WriteLine("c is negative"); 
 
        Console.WriteLine(); 
 
        c = b - a; // c now contains 1 
        Console.WriteLine("c contains 1"); 
        if(c >= 0) Console.WriteLine("c is non-negative"); 
        if(c < 0) Console.WriteLine("c is negative"); 
      }  
    }


    // Demonstrate the for loop. 
 

 
    class ForDemo { 
      public static void Main() { 
        int count; 
 
        for(count = 0; count < 5; count = count+1) 
          Console.WriteLine("This is count: " + count); 
 
        Console.WriteLine("Done!"); 
      } 
    }


    // Demonstrate a block of code. 
 

 
    class BlockDemo { 
      public static void Main() { 
        int i, j, d; 
 
        i = 5; 
        j = 10; 
 
        // the target of this if is a block 
        if(i != 0) { 
          Console.WriteLine("i does not equal zero"); 
          d = j / i; 
          Console.WriteLine("j / i is " + d); 
        } 
      } 
    }


    // Compute the sum and product of the numbers from 1 to 10. 
  
 
   
    class ProdSum {   
      public static void Main() {   
        int prod; 
        int sum; 
        int i; 
 
        sum = 0; 
        prod = 1; 
 
        for(i=1; i <= 10; i++) { 
          sum = sum + i; 
          prod = prod * i;       
        } 
        Console.WriteLine("Sum is " + sum); 
        Console.WriteLine("Product is " + prod); 
 
      }   
    }


    // Demonstrate an @ identifier. 
  

   
    class IdTest {   
      public static void Main() {   
        int @if; // use if as an identifier 
 
        for(@if = 0; @if < 10; @if++) 
          Console.WriteLine("@if is " + @if); 
      }   
    }


    */

}
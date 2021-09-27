//define Inches


using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Ref2
{

#if Inches
    
// Compute the distance from the Earth to the sun, in inches. 
class Inches {    
  public static void Main() {    
    long inches; 
    long miles; 
   
    miles = 93000000; // 93,000,000 miles to the sun 
 
    // 5,280 feet in a mile, 12 inches in a foot 
    inches = miles * 5280 * 12; 
   
    Console.WriteLine("Distance to the sun: " + 
                      inches + " inches."); 
   
  }    
}
#endif


#if Use_byte
    
    // Use byte.  
class Use_byte {    
  public static void Main() {    
    byte x; 
    int sum; 
 
    sum = 0; 
    for(x = 1; x <= 100; x++) 
      sum = sum + x; 
 
    Console.WriteLine("Summation of 100 is " + sum); 
  }    
}
#endif

#if FindRadius
// Find the radius of a circle given its area. 
 
using System; 
 
class FindRadius {    
  public static void Main() {    
    Double r; 
    Double area; 
 
    area = 10.0; 
 
    r = Math.Sqrt(area / 3.1416); 
 
    Console.WriteLine("Radius is " + r); 
  }    
}
#endif


#if Trigonometry
//  Demonstrate Math.Sin(), Math.Cos(), and Math.Tan(). 
class Trigonometry {    
  public static void Main() {    
    Double theta; // angle in radians 
     
    for(theta = 0.1; theta <= 1.0; theta = theta + 0.1) { 
      Console.WriteLine("Sine of " + theta + "  is " + 
                        Math.Sin(theta)); 
      Console.WriteLine("Cosine of " + theta + "  is " + 
                        Math.Cos(theta)); 
      Console.WriteLine("Tangent of " + theta + "  is " + 
                        Math.Tan(theta)); 
      Console.WriteLine(); 
    } 
 
  }    
}
#endif


#if UseDecimal

// Use the decimal type to compute a discount. 
  
using System;  
  
class UseDecimal {     
  public static void Main() {     
    decimal price;  
    decimal discount; 
    decimal discounted_price;  
  
    // compute discounted price 
    price = 19.95m;  
    discount = 0.15m; // discount rate is 15% 
 
    discounted_price = price - ( price * discount);  
  
    Console.WriteLine("Discounted price: $" + discounted_price);  
  } 
}

#endif
   

#if FutVal

   /*Use the decimal type to compute the future value 
   of an investment.*/ 
      
class FutVal { 
  public static void Main() { 
    decimal amount;   
    decimal rate_of_return;  
    int years, i;   
   
    amount = 1000.0M; 
    rate_of_return = 0.07M; 
    years = 10; 
 
    Console.WriteLine("Original investment: $" + amount); 
    Console.WriteLine("Rate of return: " + rate_of_return); 
    Console.WriteLine("Over " + years + " years"); 
 
    for(i = 0; i < years; i++) 
      amount = amount + (amount * rate_of_return); 
 
    Console.WriteLine("Future value is $" + amount);  
  } 
}

#endif

#if BoolDemo
// Demonstrate bool values. 

class BoolDemo { 
  public static void Main() { 
    bool b; 
 
    b = false; 
    Console.WriteLine("b is " + b); 
    b = true; 
    Console.WriteLine("b is " + b); 
 
    // a bool value can control the if statement 
    if(b) Console.WriteLine("This is executed."); 
 
    b = false; 
    if(b) Console.WriteLine("This is not executed."); 
 
    // outcome of a relational operator is a bool value 
    Console.WriteLine("10 > 9 is " + (10 > 9)); 
  } 
}

#endif


#if DisplayOptions
// Use format commands.  

class DisplayOptions {    
  public static void Main() {    
    int i; 
 
    Console.WriteLine("Value\tSquared\tCubed"); 
 
    for(i = 1; i < 10; i++) 
      Console.WriteLine("{0}\t{1}\t{2}",  
                        i, i*i, i*i*i); 
  }    
}

#endif   
 

  
#if UseDecimalAndFormat
    //   Use the C format specifier to output dollars and cents.  
    class UseDecimalAndFormat {     
      public static void Main() {     
        decimal price;  
        decimal discount; 
        decimal discounted_price;  
  
        // compute discounted price 
        price = 19.95m;  
        discount = 0.15m; // discount rate is 15% 
 
        discounted_price = price - ( price * discount);  
  
        Console.WriteLine("Discounted price: {0:C}", discounted_price);  
      }     
    }
#endif  
      
#if StrDemo     
    // Demonstrate escape sequences in strings. 
     class StrDemo {    
       public static void Main() {    
         Console.WriteLine("Line One\nLine Two\nLine Three"); 
         Console.WriteLine("One\tTwo\tThree"); 
         Console.WriteLine("Four\tFive\tSix"); 
 
         // embed quotes 
         Console.WriteLine("\"Why?\", he asked."); 
       }    
     }
#endif
    
#if Verbatim

   // Demonstrate verbatim literal strings. 
   class Verbatim {    
     public static void Main() {    
       Console.WriteLine(@"This is a verbatim 
   string literal 
   that spans several lines. 
   "); 
       Console.WriteLine(@"Here is some tabbed output: 
   1	2	3	4 
   5	6	7	8 
   "); 
       Console.WriteLine(@"Programmers say, ""I like C#."""); 
     }    
   }
#endif
    
#if DynInit   
     // Demonstrate dynamic initialization.  
  
     using System;  
  
     class DynInit {  
       public static void Main() {  
         double s1 = 4.0, s2 = 5.0; // length of sides 
  
         // dynamically initialize hypot  
         double hypot = Math.Sqrt( (s1 * s1) + (s2 * s2) ); 
  
         Console.Write("Hypotenuse of triangle with sides " + 
                       s1 + " by " + s2 + " is "); 
 
         Console.WriteLine("{0:#.###}.", hypot); 
 
       }  
     }
#endif
    
 
#if ScopeDemo
         // Demonstrate block scope. 
  
         class ScopeDemo { 
           public static void Main() { 
             int x; // known to all code within Main() 
 
             x = 10; 
             if(x == 10) { // start new scope
               int y = 20; // known only to this block 
 
               // x and y both known here. 
               Console.WriteLine("x and y: " + x + " " + y); 
               x = y * 2; 
             } 
             // y = 100; // Error! y not known here  
 
             // x is still known here. 
             Console.WriteLine("x is " + x); 
           } 
         }
#endif
       
       
 
#if VarInitDemo
  // Demonstrate lifetime of a variable. 
        class VarInitDemo { 
          public static void Main() { 
            int x;  
 
            for(x = 0; x < 3; x++) { 
              int y = -1; // y is initialized each time block is entered 
              Console.WriteLine("y is: " + y); // this always prints -1 
              y = 100;  
              Console.WriteLine("y is now: " + y); 
            } 
          } 
        }
#endif


#if NestVar
 
  //  This program attempts to declare a variable 
  //  in an inner scope with the same name as one 
  // defined in an outer scope. 
 
          
      
   // *** This program will not compile. *** 
 
 
         class NestVar {  
         public static void Main() {  
          int count;  

              Console.WriteLine("This is count: " + count);  
    
              int count; // illegal!!! 
             for(count = 0; count < 2; count++) 
              Console.WriteLine("This program is in error!"); 
           } 
          }  
        }
#endif



#if LtoD
        // Demonstrate automatic conversion from long to double. 
        class LtoD {    
          public static void Main() {    
            long L; 
            double D; 
   
            L = 100123285L; 
            D = L; 
   
            Console.WriteLine("L and D: " + L + " " + D); 
          }    
        }
#endif


#if LtoDError    
    // *** This program will not compile. *** 
 
        class LtoD {    
          public static void Main() {    
            long L; 
            double D; 
   
            D = 100123285.0; 
            L = D; // Illegal!!! 
   
            Console.WriteLine("L and D: " + L + " " + D); 
   
          }    
        }
#endif


#if castdemo

        // Demonstrate casting.  
        class CastDemo {    
          public static void Main() {    
            double x, y; 
            byte b; 
            int i; 
            char ch; 
            uint u; 
            short s; 
            long l; 
 
            x = 10.0; 
            y = 3.0; 
 
            // cast an int into a double 
            i = (int) (x / y); // cast double to int, fractional component lost 
            Console.WriteLine("Integer outcome of x / y: " + i); 
            Console.WriteLine(); 
     
            // cast an int into a byte, no data lost 
            i = 255; 
            b = (byte) i;  
            Console.WriteLine("b after assigning 255: " + b + 
                              " -- no data lost."); 
 
            // cast an int into a byte, data lost 
            i = 257; 
            b = (byte) i;  
            Console.WriteLine("b after assigning 257: " + b + 
                              " -- data lost."); 
            Console.WriteLine(); 
 
            // cast a uint into a short, no data lost 
            u = 32000; 
            s = (short) u; 
            Console.WriteLine("s after assigning 32000: " + s + 
                              " -- no data lost.");  
 
            // cast a uint into a short, data lost 
            u = 64000; 
            s = (short) u; 
            Console.WriteLine("s after assigning 64000: " + s + 
                              " -- data lost.");  
            Console.WriteLine(); 
 
            // cast a long into a uint, no data lost 
            l = 64000; 
            u = (uint) l; 
            Console.WriteLine("u after assigning 64000: " + u + 
                              " -- no data lost.");  
 
            // cast a long into a uint, data lost 
            l = -12; 
            u = (uint) l; 
            Console.WriteLine("u after assigning -12: " + u + 
                              " -- data lost.");  
            Console.WriteLine(); 
 
            // cast an int into a char 
            b = 88; // ASCII code for X 
            ch = (char) b; 
            Console.WriteLine("ch after assigning 88: " + ch);  
          }    
        }
#endif

 
#if PromDemo        
    // A promotion surprise!  
  
        using System;  
  
        class PromDemo {     
          public static void Main() {     
            byte b;  
    
            b = 10;  
            b = (byte) (b * b); // cast needed!!  
  
            Console.WriteLine("b: "+ b);  
          }     
        }
#endif


#if CastExpr    
    // Using casts in an expression.  
 
        class CastExpr {     
          public static void Main() {     
            double n;  
  
             for(n = 1.0; n <= 10; n++) {  
               Console.WriteLine("The square root of {0} is {1}",  
                                 n, Math.Sqrt(n));  
  
               Console.WriteLine("Whole number part: {0}" ,   
                                 (int) Math.Sqrt(n));  
   
               Console.WriteLine("Fractional part: {0}",   
                                 Math.Sqrt(n) - (int) Math.Sqrt(n) );  
               Console.WriteLine(); 
            }  
  
          }     
        }

#endif
}

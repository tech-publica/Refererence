//#define ModDemo
//#define PrePostDemo
//#define RelLogOps
//#define Scops
//#define SideEffects
//#define MakeEven
//#define IsOdd
//#define ShowBits
//#define MakeOdd
//#define Encode
//#define NotDemo
//#define ShiftDemo
//#define MultDiv
//#define NoZeroDiv
//#define NoZeroDiv2


using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Ref3
{
    #if ModDemo
    // Demonstrate the % operator. 
       
    class ModDemo {    
      public static void Main() {    
        int iresult, irem; 
        double dresult, drem; 
     
        iresult = 10 / 3; 
        irem = 10 % 3; 
     
        dresult = 10.0 / 3.0; 
        drem = 10.0 % 3.0;  
     
        Console.WriteLine("Result and remainder of 10 / 3: " + 
                           iresult + " " + irem); 
        Console.WriteLine("Result and remainder of 10.0 / 3.0: " + 
                           dresult + " " + drem); 
      }    
    }
#endif



#if PrePostDemo
    /* 
       Demonstrate the difference between prefix 
       postfix forms of ++. 
    */ 
     
    class PrePostDemo {  
      public static void Main() {    
        int x, y; 
        int i; 
     
        x = 1; 
        Console.WriteLine("Series generated using y = x + x++;"); 
        for(i = 0; i < 10; i++) { 
     
          y = x + x++; // postfix ++ 
     
          Console.WriteLine(y + " "); 
        } 
        Console.WriteLine(); 
     
        x = 1; 
        Console.WriteLine("Series generated using y = x + ++x;"); 
        for(i = 0; i < 10; i++) { 
     
          y = x + ++x; // prefix ++ 
     
          Console.WriteLine(y + " "); 
        } 
        Console.WriteLine(); 
        
      } 
    }
#endif

#if RelLogOps
    // Demonstrate the relational and logical operators. 
      
     
    class RelLogOps {    
      public static void Main() {    
        int i, j; 
        bool b1, b2; 
     
        i = 10; 
        j = 11; 
        if(i < j) Console.WriteLine("i < j"); 
        if(i <= j) Console.WriteLine("i <= j"); 
        if(i != j) Console.WriteLine("i != j"); 
        if(i == j) Console.WriteLine("this won't execute"); 
        if(i >= j) Console.WriteLine("this won't execute"); 
        if(i > j) Console.WriteLine("this won't execute"); 
     
        b1 = true; 
        b2 = false; 
        if(b1 & b2) Console.WriteLine("this won't execute"); 
        if(!(b1 & b2)) Console.WriteLine("!( " + b1 + " & " + b2+ " ) is true"); 
        if(b1 | b2) Console.WriteLine(b1 + " | " +  b2 + " is true"); 
        if(b1 ^ b2) Console.WriteLine(b1 + " ^ " +  b2 + " is true"); 
      }    
    }
#endif



#if Scops
    // Demonstrate the short-circuit operators. 
   
    class SCops {    
      public static void Main() {    
        int n, d; 
     
        n = 10; 
        d = 2; 
        if(d != 0 && (n % d) == 0) 
          Console.WriteLine(d + " is a factor of " + n); 
     
        d = 0; // now, set d to zero 
     
        // Since d is zero, the second operand is not evaluated. 
        if(d != 0 && (n % d) == 0) 
          Console.WriteLine(d + " is a factor of " + n);  
         
        /* Now, try the same thing without short-circuit operator. 
           This will cause a divide-by-zero error.  */ 
        if(d != 0 & (n % d) == 0) 
          Console.WriteLine(d + " is a factor of " + n); 
      }    
    }
#endif


#if SideEffects
    // Side-effects can be important. 
      
    class SideEffects {    
      public static void Main() {    
        int i; 
        bool someCondition = false; 
     
        i = 0; 
     
        /* Here, i is still incremented even though 
           the if statement fails. */ 
        if(someCondition & (++i < 100)) 
           Console.WriteLine("this won't be displayed"); 
        Console.WriteLine("if statement executed: " + i); // displays 1 
     
        /* In this case, i is not incremented because 
           the short-circuit operator skips the increment. */ 
        if(someCondition && (++i < 100)) 
          Console.WriteLine("this won't be displayed"); 
        Console.WriteLine("if statement executed: " + i); // still 1 !! 
      }    
    }
#endif
  
#if MakeEven
    // Use bitwise AND to make a number even. 
    class MakeEven {  
      public static void Main() { 
        ushort num;  
        ushort i;     
     
        for(i = 1; i <= 10; i++) { 
          num = i; 
     
          Console.WriteLine("num: " + num); 
     
          num = (ushort) (num & 0xFE); // num & 1111 1110 
     
          Console.WriteLine("num after turning off bit zero: " 
                            +  num + "\n");  
        } 
      } 
    }
#endif

#if IsOdd
    //  Use bitwise AND to determine if a number is odd. 
     
    class IsOdd {  
      public static void Main() { 
        ushort num;  
     
        num = 10; 
     
        if((num & 1) == 1) 
          Console.WriteLine("This won't display."); 
     
        num = 11; 
     
        if((num & 1) == 1) 
          Console.WriteLine(num + " is odd."); 
     
      } 
    }

#endif

#if ShowBits
    // Display the bits within a byte.  
    
     
    class ShowBits { 
      public static void Main() { 
        int t; 
        byte val;
      
        val = 0xFE; 
        for(t=128; t > 0; t = t/2) { 
          if((val & t) != 0) Console.Write("1 ");  
          if((val & t) == 0) Console.Write("0 ");  
        } 
      } 
    }
#endif

#if MakeOdd
    //  Use bitwise OR to make a number odd. 

    class MakeOdd {  
      public static void Main() { 
        ushort num;  
        ushort i;     
     
        for(i = 1; i <= 10; i++) { 
          num = i; 
     
          Console.WriteLine("num: " + num); 
     
          num = (ushort) (num | 1); // num | 0000 0001 
     
          Console.WriteLine("num after turning on bit zero: " 
                            +  num + "\n");  
        } 
      } 
    }
#endif
 
#if Encode
    // Use XOR to encode and decode a message.  
     
    class Encode {  
      public static void Main() { 
        char ch1 = 'H'; 
        char ch2 = 'i'; 
        char ch3 = '!'; 
        int key = 88; 
     
        Console.WriteLine("Original message: " + ch1 + ch2 + ch3); 
     
        // encode the message 
        ch1 = (char) (ch1 ^ key); 
        ch2 = (char) (ch2 ^ key); 
        ch3 = (char) (ch3 ^ key); 
     
        Console.WriteLine("Encoded message: " + ch1 + ch2 + ch3); 
     
        // decode the message 
        ch1 = (char) (ch1 ^ key); 
        ch2 = (char) (ch2 ^ key); 
        ch3 = (char) (ch3 ^ key); 
        
        Console.WriteLine("Encoded message: " + ch1 + ch2 + ch3); 
      } 
    }
#endif
   
#if NotDemo
    // Demonstrate the bitwise NOT. 
   
    class NotDemo { 
      public static void Main() { 
        sbyte b = -34; 
     
        for(int t=128; t > 0; t = t/2) { 
          if((b & t) != 0) Console.Write("1 ");  
          if((b & t) == 0) Console.Write("0 ");  
        } 
        Console.WriteLine(); 
     
        // reverse all bits 
        b = (sbyte) ~b; 
     
        for(int t=128; t > 0; t = t/2) { 
          if((b & t) != 0) Console.Write("1 ");  
          if((b & t) == 0) Console.Write("0 ");  
        } 
      } 
    }
#endif
    
#if ShiftDemo
    // Demonstrate the shift << and >> operators. 
     
    class ShiftDemo { 
      public static void Main() { 
        int val = 1; 
     
        for(int i = 0; i < 8; i++) {  
          for(int t=128; t > 0; t = t/2) { 
            if((val & t) != 0) Console.Write("1 ");  
            if((val & t) == 0) Console.Write("0 ");  
          } 
          Console.WriteLine(); 
          val = val << 1; // left shift 
        } 
        Console.WriteLine(); 
     
        val = 128; 
        for(int i = 0; i < 8; i++) {  
          for(int t=128; t > 0; t = t/2) { 
            if((val & t) != 0) Console.Write("1 ");  
            if((val & t) == 0) Console.Write("0 ");  
          } 
          Console.WriteLine(); 
          val = val >> 1; // right shift 
        } 
      } 
    }
#endif

#if MultDiv
    
    // Use the shift operators to multiply and divide by 2. 
     
    class MultDiv {  
      public static void Main() { 
        int n; 
     
        n = 10; 
     
        Console.WriteLine("Value of n: " + n); 
     
        // multiply by 2 
        n = n << 1; 
        Console.WriteLine("Value of n after n = n * 2: " + n); 
     
        // multiply by 4 
        n = n << 2; 
        Console.WriteLine("Value of n after n = n * 4: " + n); 
     
        // divide by 2 
        n = n >> 1; 
        Console.WriteLine("Value of n after n = n / 2: " + n); 
     
        // divide by 4 
        n = n >> 2; 
        Console.WriteLine("Value of n after n = n / 4: " + n); 
        Console.WriteLine(); 
     
        // reset n 
        n = 10; 
        Console.WriteLine("Value of n: " + n); 
     
        // multiply by 2, 30 times 
        n = n << 30; // data is lost 
        Console.WriteLine("Value of n after left-shifting 30 places: " + n); 
     
      } 
    }
#endif

#if NoZeroDiv
  
    // Prevent a division by zero using the ?. 

    class NoZeroDiv { 
      public static void Main() { 
        int result; 
     
        for(int i = -5; i < 6; i++) { 
          result = i != 0 ? 100 / i : 0; 
          if(i != 0)  
            Console.WriteLine("100 / " + i + " is " + result); 
        } 
      } 
    }
#endif

#if NoZeroDiv2
    // Prevent a division by zero using the ?. 
     
    using System; 
     
    class NoZeroDiv2 { 
      public static void Main() { 
     
        for(int i = -5; i < 6; i++)  
          if(i != 0 ? true : false)  
            Console.WriteLine("100 / " + i + 
                               " is " + 100 / i); 
      } 
    }
#endif

}

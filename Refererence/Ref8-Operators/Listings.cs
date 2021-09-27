//#define ThreeD0
//#define ThreeD1
//#define ThreeD2
//#define ThreeD3
//#define ThreeD4
//#define ThreeD5
//#define ThreeD6
//#define ThreeD7
//#define ThreeD8
//#define ThreeD9
//#define Nybble

using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Ref8_Operators
{
   
#if ThreeD0
// An example of operator overloading. 
  
// A three-dimensional coordinate class. 
class ThreeD { 
  int x, y, z; // 3-D coordinates   
 
  public ThreeD() { x = y = z = 0; } 
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; } 
 
  // Overload binary +. 
  public static ThreeD operator +(ThreeD op1, ThreeD op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    /* This adds together the coordinates of the two points 
       and returns the result. */ 
    result.x = op1.x + op2.x; // These are integer additions 
    result.y = op1.y + op2.y; // and the + retains its original 
    result.z = op1.z + op2.z; // meaning relative to them. 
 
    return result; 
  } 
 
  // Overload binary -. 
  public static ThreeD operator -(ThreeD op1, ThreeD op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    /* Notice the order of the operands. op1 is the left 
       operand and op2 is the right. */ 
    result.x = op1.x - op2.x; // these are integer subtractions 
    result.y = op1.y - op2.y;  
    result.z = op1.z - op2.z;  
 
    return result; 
  } 
   
  // Show X, Y, Z coordinates. 
  public void show() 
  { 
    Console.WriteLine(x + ", " + y + ", " + z); 
  } 
} 
 
class ThreeDDemo { 
  public static void Main() { 
    ThreeD a = new ThreeD(1, 2, 3); 
    ThreeD b = new ThreeD(10, 10, 10); 
    ThreeD c = new ThreeD(); 
 
    Console.Write("Here is a: "); 
    a.show(); 
    Console.WriteLine(); 
    Console.Write("Here is b: "); 
    b.show(); 
    Console.WriteLine(); 
 
    c = a + b; // add a and b together 
    Console.Write("Result of a + b: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = a + b + c; // add a, b and c together 
    Console.Write("Result of a + b + c: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = c - a; // subtract a 
    Console.Write("Result of c - a: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = c - b; // subtract b 
    Console.Write("Result of c - b: "); 
    c.show(); 
    Console.WriteLine(); 
  } 
}

#endif


#if ThreeD1
// More operator overloading. 
 
using System; 
 
// A three-dimensional coordinate class. 
class ThreeD { 
  int x, y, z; // 3-D coordinates   
 
  public ThreeD() { x = y = z = 0; } 
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; } 
 
  // Overload binary +. 
  public static ThreeD operator +(ThreeD op1, ThreeD op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    /* This adds together the coordinates of the two points 
       and returns the result. */ 
    result.x = op1.x + op2.x;  
    result.y = op1.y + op2.y;  
    result.z = op1.z + op2.z;  
 
    return result; 
  } 
 
  // Overload binary -. 
  public static ThreeD operator -(ThreeD op1, ThreeD op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    /* Notice the order of the operands. op1 is the left 
       operand and op2 is the right. */ 
    result.x = op1.x - op2.x;  
    result.y = op1.y - op2.y;  
    result.z = op1.z - op2.z;  
 
    return result; 
  } 
   
  // Overload unary -. 
  public static ThreeD operator -(ThreeD op) 
  { 
    ThreeD result = new ThreeD(); 
 
    result.x = -op.x; 
    result.y = -op.y;  
    result.z = -op.z;  
 
    return result; 
  } 
 
  // Overload unary ++. 
  public static ThreeD operator ++(ThreeD op) 
  { 
    // for ++, modify argument 
    op.x++; 
    op.y++;  
    op.z++;  
 
    return op; 
  } 
 
  // Show X, Y, Z coordinates. 
  public void show() 
  { 
    Console.WriteLine(x + ", " + y + ", " + z); 
  } 
} 
 
class ThreeDDemo { 
  public static void Main() { 
    ThreeD a = new ThreeD(1, 2, 3); 
    ThreeD b = new ThreeD(10, 10, 10); 
    ThreeD c = new ThreeD(); 
 
    Console.Write("Here is a: "); 
    a.show(); 
    Console.WriteLine(); 
    Console.Write("Here is b: "); 
    b.show(); 
    Console.WriteLine(); 
 
    c = a + b; // add a and b together 
    Console.Write("Result of a + b: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = a + b + c; // add a, b and c together 
    Console.Write("Result of a + b + c: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = c - a; // subtract a 
    Console.Write("Result of c - a: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = c - b; // subtract b 
    Console.Write("Result of c - b: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = -a; // assign -a to c 
    Console.Write("Result of -a: "); 
    c.show(); 
    Console.WriteLine(); 
 
    a++; // increment a 
    Console.Write("Result of a++: "); 
    a.show();   
  } 
}

#endif

#if ThreeD2
/* Overload addition for object + object, and 
   for object + int. */ 
 
using System; 
 
// A three-dimensional coordinate class. 
class ThreeD { 
  int x, y, z; // 3-D coordinates   
 
  public ThreeD() { x = y = z = 0; } 
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; } 
 
  // Overload binary + for object + object. 
  public static ThreeD operator +(ThreeD op1, ThreeD op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    /* This adds together the coordinates of the two points 
       and returns the result. */ 
    result.x = op1.x + op2.x;  
    result.y = op1.y + op2.y;  
    result.z = op1.z + op2.z;  
 
    return result; 
  } 
 
  // Overload binary + for object + int. 
  public static ThreeD operator +(ThreeD op1, int op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    result.x = op1.x + op2; 
    result.y = op1.y + op2; 
    result.z = op1.z + op2; 
 
    return result; 
  } 
 
  // Show X, Y, Z coordinates. 
  public void show() 
  { 
    Console.WriteLine(x + ", " + y + ", " + z); 
  } 
} 
 
class ThreeDDemo { 
  public static void Main() { 
    ThreeD a = new ThreeD(1, 2, 3); 
    ThreeD b = new ThreeD(10, 10, 10); 
    ThreeD c = new ThreeD(); 
 
    Console.Write("Here is a: "); 
    a.show(); 
    Console.WriteLine(); 
    Console.Write("Here is b: "); 
    b.show(); 
    Console.WriteLine(); 
 
    c = a + b; // object + object 
    Console.Write("Result of a + b: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = b + 10; // object + int 
    Console.Write("Result of b + 10: "); 
    c.show(); 
  } 
}

#endif

#if ThreeD3
/* Overload the + for object + object, 
   object + int, and int + object. */ 
 
using System; 
 
// A three-dimensional coordinate class. 
class ThreeD { 
  int x, y, z; // 3-D coordinates   
 
  public ThreeD() { x = y = z = 0; } 
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; } 
 
  // Overload binary + for object + object. 
  public static ThreeD operator +(ThreeD op1, ThreeD op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    /* This adds together the coordinates of the two points 
       and returns the result. */ 
    result.x = op1.x + op2.x;  
    result.y = op1.y + op2.y;  
    result.z = op1.z + op2.z;  
 
    return result; 
  } 
 
  // Overload binary + for object + int. 
  public static ThreeD operator +(ThreeD op1, int op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    result.x = op1.x + op2; 
    result.y = op1.y + op2; 
    result.z = op1.z + op2; 
 
    return result; 
  } 
 
  // Overload binary + for int + object. 
  public static ThreeD operator +(int op1, ThreeD op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    result.x = op2.x + op1; 
    result.y = op2.y + op1; 
    result.z = op2.z + op1; 
 
    return result; 
  } 
 
  // Show X, Y, Z coordinates. 
  public void show() 
  { 
    Console.WriteLine(x + ", " + y + ", " + z); 
  } 
} 
 
class ThreeDDemo { 
  public static void Main() { 
    ThreeD a = new ThreeD(1, 2, 3); 
    ThreeD b = new ThreeD(10, 10, 10); 
    ThreeD c = new ThreeD(); 
 
    Console.Write("Here is a: "); 
    a.show(); 
    Console.WriteLine(); 
    Console.Write("Here is b: "); 
    b.show(); 
    Console.WriteLine(); 
 
    c = a + b; // object + object 
    Console.Write("Result of a + b: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = b + 10; // object + int 
    Console.Write("Result of b + 10: "); 
    c.show(); 
    Console.WriteLine(); 
 
    c = 15 + b; // int + object 
    Console.Write("Result of 15 + b: "); 
    c.show(); 
  } 
}

#endif

#if ThreeD4
// Overload < and >.   
  
  
// A three-dimensional coordinate class.  
class ThreeD {  
  int x, y, z; // 3-D coordinates    
  
  public ThreeD() { x = y = z = 0; }  
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; }  
  
  // Overload <.  
  public static bool operator <(ThreeD op1, ThreeD op2)  
  {  
    if((op1.x < op2.x) && (op1.y < op2.y) && (op1.z < op2.z))  
      return true;  
    else  
      return false;  
  }  
  
  // Overload >.  
  public static bool operator >(ThreeD op1, ThreeD op2)  
  {  
    if((op1.x > op2.x) && (op1.y > op2.y) && (op1.z > op2.z))  
      return true;  
    else  
      return false;  
  }  
  
  // Show X, Y, Z coordinates.  
  public void show()  
  {  
    Console.WriteLine(x + ", " + y + ", " + z);  
  }  
}  
  
class ThreeDDemo {  
  public static void Main() {  
    ThreeD a = new ThreeD(5, 6, 7);  
    ThreeD b = new ThreeD(10, 10, 10);  
    ThreeD c = new ThreeD(1, 2, 3);  
  
    Console.Write("Here is a: ");  
    a.show();  
    Console.Write("Here is b: ");  
    b.show();  
    Console.Write("Here is c: ");  
    c.show();  
    Console.WriteLine();  
  
    if(a > c) Console.WriteLine("a > c is true");  
    if(a < c) Console.WriteLine("a < c is true");  
    if(a > b) Console.WriteLine("a > b is true");  
    if(a < b) Console.WriteLine("a < b is true");  
  }  
}

#endif

    
#if ThreeD5
// Overload true and false for ThreeD. 
 
using System;   
   
// A three-dimensional coordinate class.   
class ThreeD {   
  int x, y, z; // 3-D coordinates     
   
  public ThreeD() { x = y = z = 0; }   
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; }   
 
  // Overload true.   
  public static bool operator true(ThreeD op) { 
    if((op.x != 0) || (op.y != 0) || (op.z != 0)) 
      return true; // at least one coordinate is non-zero 
    else 
      return false; 
  }   
 
  // Overload false. 
  public static bool operator false(ThreeD op) { 
    if((op.x == 0) && (op.y == 0) && (op.z == 0)) 
      return true; // all coordinates are zero 
    else 
      return false; 
  }   
 
  // Overload unary --.  
  public static ThreeD operator --(ThreeD op)  
  {  
    // for ++, modify argument  
    op.x--;  
    op.y--;   
    op.z--;   
  
    return op;  
  }  
 
  // Show X, Y, Z coordinates.   
  public void show()   
  {   
    Console.WriteLine(x + ", " + y + ", " + z);   
  }   
}   
   
class TrueFalseDemo {   
  public static void Main() {   
    ThreeD a = new ThreeD(5, 6, 7);   
    ThreeD b = new ThreeD(10, 10, 10);   
    ThreeD c = new ThreeD(0, 0, 0);   
   
    Console.Write("Here is a: ");   
    a.show();   
    Console.Write("Here is b: ");   
    b.show();   
    Console.Write("Here is c: ");   
    c.show();   
    Console.WriteLine();   
   
    if(a) Console.WriteLine("a is true."); 
    else Console.WriteLine("a is false."); 
 
    if(b) Console.WriteLine("b is true."); 
    else Console.WriteLine("b is false."); 
 
    if(c) Console.WriteLine("c is true."); 
    else Console.WriteLine("c is false."); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Control a loop using a ThreeD object."); 
    do { 
      b.show(); 
      b--; 
    } while(b); 
 
  }   
}

#endif

#if ThreeD6
// A simple way to overload !, |, and & for ThreeD. 
 

// A three-dimensional coordinate class.   
class ThreeD {   
  int x, y, z; // 3-D coordinates     
   
  public ThreeD() { x = y = z = 0; }   
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; }   
 
 
  // Overload |.   
  public static bool operator |(ThreeD op1, ThreeD op2)   
  {  
    if( ((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) | 
       ((op2.x != 0) || (op2.y != 0) || (op2.z != 0)) ) 
      return true;   
    else   
      return false;   
  }   
 
  // Overload &.   
  public static bool operator &(ThreeD op1, ThreeD op2)   
  {   
    if( ((op1.x != 0) && (op1.y != 0) && (op1.z != 0)) & 
       ((op2.x != 0) && (op2.y != 0) && (op2.z != 0)) ) 
      return true;   
    else   
      return false;   
  }   
 
  // Overload !.   
  public static bool operator !(ThreeD op)   
  {   
    if((op.x != 0) || (op.y != 0) || (op.z != 0)) 
      return false; 
    else return true;   
  }   
 
  // Show X, Y, Z coordinates.   
  public void show()   
  {   
    Console.WriteLine(x + ", " + y + ", " + z);   
  }   
}   
   
class TrueFalseDemo {   
  public static void Main() {   
    ThreeD a = new ThreeD(5, 6, 7);   
    ThreeD b = new ThreeD(10, 10, 10);   
    ThreeD c = new ThreeD(0, 0, 0);   
   
    Console.Write("Here is a: ");   
    a.show();   
    Console.Write("Here is b: ");   
    b.show();   
    Console.Write("Here is c: ");   
    c.show();   
    Console.WriteLine();   
 
    if(!a) Console.WriteLine("a is false."); 
    if(!b) Console.WriteLine("b is false."); 
    if(!c) Console.WriteLine("c is false."); 
 
    Console.WriteLine(); 
 
    if(a & b) Console.WriteLine("a & b is true."); 
    else Console.WriteLine("a & b is false."); 
 
    if(a & c) Console.WriteLine("a & c is true."); 
    else Console.WriteLine("a & c is false."); 
 
    if(a | b) Console.WriteLine("a | b is true."); 
    else Console.WriteLine("a | b is false."); 
 
    if(a | c) Console.WriteLine("a | c is true."); 
    else Console.WriteLine("a | c is false."); 
  }   
}

#endif

#if ThreeD7
/* A better way to overload !, |, and & for ThreeD. 
   This version automatically enables the && and || operators. */ 
  
   
// A three-dimensional coordinate class.   
class ThreeD {   
  int x, y, z; // 3-D coordinates     
   
  public ThreeD() { x = y = z = 0; }   
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; }   
 
 
  // Overload | for short-circuit evaluation.   
  public static ThreeD operator |(ThreeD op1, ThreeD op2)   
  {  
    if( ((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) | 
       ((op2.x != 0) || (op2.y != 0) || (op2.z != 0)) ) 
      return new ThreeD(1, 1, 1);   
    else   
      return new ThreeD(0, 0, 0);   
  }   
 
  // Overload & for short-circuit evaluation.   
  public static ThreeD operator &(ThreeD op1, ThreeD op2)   
  {   
    if( ((op1.x != 0) && (op1.y != 0) && (op1.z != 0)) & 
       ((op2.x != 0) && (op2.y != 0) && (op2.z != 0)) ) 
      return new ThreeD(1, 1, 1);   
    else   
      return new ThreeD(0, 0, 0);   
  }   
 
  // Overload !.   
  public static bool operator !(ThreeD op)   
  {   
    if(op) return false;   
    else return true;   
  }   
 
  // Overload true.   
  public static bool operator true(ThreeD op) { 
    if((op.x != 0) || (op.y != 0) || (op.z != 0)) 
      return true; // at least one coordinate is non-zero 
    else 
      return false; 
  }   
 
  // Overload false. 
  public static bool operator false(ThreeD op) { 
    if((op.x == 0) && (op.y == 0) && (op.z == 0)) 
      return true; // all coordinates are zero 
    else 
      return false; 
  }   
 
  // Show X, Y, Z coordinates.   
  public void show()   
  {   
    Console.WriteLine(x + ", " + y + ", " + z);   
  }   
}   
   
class TrueFalseDemo {   
  public static void Main() {   
    ThreeD a = new ThreeD(5, 6, 7);   
    ThreeD b = new ThreeD(10, 10, 10);   
    ThreeD c = new ThreeD(0, 0, 0);   
   
    Console.Write("Here is a: ");   
    a.show();   
    Console.Write("Here is b: ");   
    b.show();   
    Console.Write("Here is c: ");   
    c.show();   
    Console.WriteLine();   
   
    if(a) Console.WriteLine("a is true."); 
    if(b) Console.WriteLine("b is true."); 
    if(c) Console.WriteLine("c is true."); 
 
    if(!a) Console.WriteLine("a is false."); 
    if(!b) Console.WriteLine("b is false."); 
    if(!c) Console.WriteLine("c is false."); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Use & and |"); 
    if(a & b) Console.WriteLine("a & b is true."); 
    else Console.WriteLine("a & b is false."); 
 
    if(a & c) Console.WriteLine("a & c is true."); 
    else Console.WriteLine("a & c is false."); 
 
    if(a | b) Console.WriteLine("a | b is true."); 
    else Console.WriteLine("a | b is false."); 
 
    if(a | c) Console.WriteLine("a | c is true."); 
    else Console.WriteLine("a | c is false."); 
 
    Console.WriteLine(); 
 
    // now use short-circuit ops 
    Console.WriteLine("Use short-circuit && and ||"); 
    if(a && b) Console.WriteLine("a && b is true."); 
    else Console.WriteLine("a && b is false."); 
 
    if(a && c) Console.WriteLine("a && c is true."); 
    else Console.WriteLine("a && c is false."); 
 
    if(a || b) Console.WriteLine("a || b is true."); 
    else Console.WriteLine("a || b is false."); 
 
    if(a || c) Console.WriteLine("a || c is true."); 
    else Console.WriteLine("a || c is false."); 
  }   
}

#endif

#if ThreeD8
// An example that uses an implicit conversion operator. 
 
// A three-dimensional coordinate class. 
class ThreeD { 
  int x, y, z; // 3-D coordinates   
 
  public ThreeD() { x = y = z = 0; } 
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; } 
 
  // Overload binary +. 
  public static ThreeD operator +(ThreeD op1, ThreeD op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    result.x = op1.x + op2.x;  
    result.y = op1.y + op2.y;  
    result.z = op1.z + op2.z;  
 
    return result; 
  } 
 
  // An implicit conversion from ThreeD to int. 
  public static implicit operator int(ThreeD op1) 
  { 
    return op1.x * op1.y * op1.z; 
  } 
   
  // Show X, Y, Z coordinates. 
  public void show() 
  { 
    Console.WriteLine(x + ", " + y + ", " + z); 
  } 
} 
 
class ThreeDDemo { 
  public static void Main() { 
    ThreeD a = new ThreeD(1, 2, 3); 
    ThreeD b = new ThreeD(10, 10, 10); 
    ThreeD c = new ThreeD(); 
    int i; 
 
    Console.Write("Here is a: "); 
    a.show(); 
    Console.WriteLine(); 
    Console.Write("Here is b: "); 
    b.show(); 
    Console.WriteLine(); 
 
    c = a + b; // add a and b together 
    Console.Write("Result of a + b: "); 
    c.show(); 
    Console.WriteLine(); 
 
    i = a; // convert to int 
    Console.WriteLine("Result of i = a: " + i); 
    Console.WriteLine(); 
 
    i = a * 2 - b; // convert to int 
    Console.WriteLine("result of a * 2 - b: " + i); 
  } 
}


#endif

#if ThreeD9
// Use an explicit conversion. 
 
 
// A three-dimensional coordinate class. 
class ThreeD { 
  int x, y, z; // 3-D coordinates   
 
  public ThreeD() { x = y = z = 0; } 
  public ThreeD(int i, int j, int k) { x = i; y = j; z = k; } 
 
  // Overload binary +. 
  public static ThreeD operator +(ThreeD op1, ThreeD op2) 
  { 
    ThreeD result = new ThreeD(); 
 
    result.x = op1.x + op2.x;  
    result.y = op1.y + op2.y;  
    result.z = op1.z + op2.z;  
 
    return result; 
  } 
 
  // This is now explicit. 
  public static explicit operator int(ThreeD op1) 
  { 
    return op1.x * op1.y * op1.z; 
  } 
   
  // Show X, Y, Z coordinates. 
  public void show() 
  { 
    Console.WriteLine(x + ", " + y + ", " + z); 
  } 
} 
 
class ThreeDDemo { 
  public static void Main() { 
    ThreeD a = new ThreeD(1, 2, 3); 
    ThreeD b = new ThreeD(10, 10, 10); 
    ThreeD c = new ThreeD(); 
    int i; 
 
    Console.Write("Here is a: "); 
    a.show(); 
    Console.WriteLine(); 
    Console.Write("Here is b: "); 
    b.show(); 
    Console.WriteLine(); 
 
    c = a + b; // add a and b together 
    Console.Write("Result of a + b: "); 
    c.show(); 
    Console.WriteLine(); 
 
    i = (int) a; // explicitly convert to int -- cast required 
    Console.WriteLine("Result of i = a: " + i); 
    Console.WriteLine(); 
 
    i = (int)a * 2 - (int)b; // casts required 
    Console.WriteLine("result of a * 2 - b: " + i); 
 
  } 
}

#endif

#if Nybble
// Create a 4-bit type called Nybble. 
   
  
// A 4-bit type. 
class Nybble {  
  int val; // underlying storage 
 
  public Nybble() { val = 0; }  
 
  public Nybble(int i) { 
    val = i; 
    val = val & 0xF; // retain lower 4 bits 
  } 
  
  // Overload binary + for Nybble + Nybble.  
  public static Nybble operator +(Nybble op1, Nybble op2)  
  {  
    Nybble result = new Nybble();  
  
    result.val = op1.val + op2.val;  
 
    result.val = result.val & 0xF; // retain lower 4 bits  
  
    return result;  
  }  
  
  // Overload binary + for Nybble + int.  
  public static Nybble operator +(Nybble op1, int op2)  
  {  
    Nybble result = new Nybble();  
  
    result.val = op1.val + op2;  
 
    result.val = result.val & 0xF; // retain lower 4 bits  
  
    return result;  
  }  
  
  // Overload binary + for int + Nybble.  
  public static Nybble operator +(int op1, Nybble op2)  
  {  
    Nybble result = new Nybble();  
  
    result.val = op1 + op2.val;  
 
    result.val = result.val & 0xF; // retain lower 4 bits  
  
    return result;  
  }  
  
  // Overload ++. 
  public static Nybble operator ++(Nybble op) 
  { 
    op.val++; 
 
    op.val = op.val & 0xF; // retain lower 4 bits 
 
    return op; 
  } 
 
  // Overload >. 
  public static bool operator >(Nybble op1, Nybble op2) 
  { 
    if(op1.val > op2.val) return true; 
    else return false; 
  } 
 
  // Overload <. 
  public static bool operator <(Nybble op1, Nybble op2) 
  { 
    if(op1.val < op2.val) return true; 
    else return false; 
  } 
 
  // Convert a Nybble into an int. 
  public static implicit operator int (Nybble op) 
  { 
    return op.val; 
  } 
 
  // Convert an int into a Nybble. 
  public static implicit operator Nybble (int op) 
  { 
    return new Nybble(op); 
  } 
}  
  
class NybbleDemo {  
  public static void Main() {  
    Nybble a = new Nybble(1);  
    Nybble b = new Nybble(10);  
    Nybble c = new Nybble();  
    int t; 
  
    Console.WriteLine("a: " + (int) a); 
    Console.WriteLine("b: " + (int) b); 
 
    // use a Nybble in an if statement 
    if(a < b) Console.WriteLine("a is less than b\n"); 
 
    // Add two Nybbles together 
    c = a + b; 
    Console.WriteLine("c after c = a + b: " + (int) c); 
 
    // Add an int to a Nybble 
    a += 5; 
    Console.WriteLine("a after a += 5: " + (int) a); 
 
    Console.WriteLine(); 
 
    // use a Nybble in an int expression 
    t = a * 2 + 3; 
    Console.WriteLine("Result of a * 2 + 3: " + t); 
     
    Console.WriteLine(); 
 
    // illustrate int assignment and overflow 
    a = 19; 
    Console.WriteLine("Result of a = 19: " + (int) a); 
     
    Console.WriteLine(); 
 
    // use a Nybble to control a loop     
    Console.WriteLine("Control a for loop with a Nybble."); 
    for(a = 0; a < 10; a++) 
      Console.Write((int) a + " "); 
 
    Console.WriteLine(); 
  } 
}
#endif

}

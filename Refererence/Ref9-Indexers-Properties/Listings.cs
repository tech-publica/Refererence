//#define FailSoftArray0
//#define FailSoftArray1
//#define PwrTwo
//#define FailSoftArray2D
//#define SimpProp
//#define FailSoftArray2
//#define FailSoftArray3
//#define PropAccess
//#define RangeArray


using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Ref9_Indexers_Properties
{
    

#if FailSoftArray0
// Use an indexer to create a fail-soft array. 
 
 
class FailSoftArray {  
  int[] a;    // reference to underlying array  
 
  public int Length; // Length is public 
 
  public bool errflag; // indicates outcome of last operation 
   
  // Construct array given its size. 
  public FailSoftArray(int size) { 
    a = new int[size]; 
    Length = size;  
  } 
 
  // This is the indexer for FailSoftArray. 
  public int this[int index] { 
    // This is the get accessor. 
    get { 
      if(ok(index)) { 
        errflag = false; 
        return a[index]; 
      } else { 
        errflag = true; 
        return 0; 
      } 
    } 
 
    // This is the set accessor 
    set { 
      if(ok(index)) { 
        a[index] = value; 
        errflag = false; 
      } 
      else errflag = true; 
    } 
  } 
 
  // Return true if index is within bounds. 
  private bool ok(int index) { 
   if(index >= 0 & index < Length) return true; 
   return false; 
  } 
}  
  
// Demonstrate the fail-soft array. 
class FSDemo {  
  public static void Main() {  
    FailSoftArray fs = new FailSoftArray(5); 
    int x; 
 
    // show quiet failures 
    Console.WriteLine("Fail quietly."); 
    for(int i=0; i < (fs.Length * 2); i++) 
      fs[i] = i*10; 
 
    for(int i=0; i < (fs.Length * 2); i++) { 
      x = fs[i]; 
      if(x != -1) Console.Write(x + " "); 
    } 
    Console.WriteLine(); 
 
    // now, generate failures 
    Console.WriteLine("\nFail with error reports."); 
    for(int i=0; i < (fs.Length * 2); i++) { 
      fs[i] = i*10; 
      if(fs.errflag) 
        Console.WriteLine("fs[" + i + "] out-of-bounds"); 
    } 
 
    for(int i=0; i < (fs.Length * 2); i++) { 
      x = fs[i]; 
      if(!fs.errflag) Console.Write(x + " "); 
      else 
        Console.WriteLine("fs[" + i + "] out-of-bounds"); 
    } 
  } 
}

#endif

#if FailSoftArray1

// Overload the FailSoftArray indexer. 
  

class FailSoftArray {   
  int[] a;    // reference to underlying array   
  
  public int Length; // Length is public  
  
  public bool errflag; // indicates outcome of last operation  
    
  // Construct array given its size.  
  public FailSoftArray(int size) {  
    a = new int[size];  
    Length = size;   
  }  
  
  // This is the int indexer for FailSoftArray.  
  public int this[int index] {  
    // This is the get accessor.  
    get {  
      if(ok(index)) {  
        errflag = false;  
        return a[index];  
      } else {  
        errflag = true;  
        return 0;  
      }  
    }  
  
    // This is the set accessor  
    set {  
      if(ok(index)) {  
        a[index] = value;  
        errflag = false;  
      }  
      else errflag = true;  
    }  
  }  
  
  /* This is another indexer for FailSoftArray. 
     This index takes a double argument.  It then 
     rounds that argument to the nearest integer 
     index. */  
  public int this[double idx] {  
    // This is the get accessor.  
    get {  
      int index; 
 
      // round to nearest int 
      if( (idx - (int) idx) < 0.5) index = (int) idx; 
      else index = (int) idx + 1; 
 
      if(ok(index)) {  
        errflag = false;  
        return a[index];  
      } else {  
        errflag = true;  
        return 0;  
      }  
    }  
  
    // This is the set accessor  
    set {  
      int index; 
 
      // round to nearest int 
      if( (idx - (int) idx) < 0.5) index = (int) idx; 
      else index = (int) idx + 1; 
 
      if(ok(index)) {  
        a[index] = value;  
        errflag = false;  
      }  
      else errflag = true;  
    }  
  }  
  
  // Return true if index is within bounds.  
  private bool ok(int index) {  
   if(index >= 0 & index < Length) return true;  
   return false;  
  }  
}   
   
// Demonstrate the fail-soft array.  
class FSDemo {   
  public static void Main() {   
    FailSoftArray fs = new FailSoftArray(5);  
  
    // put some values in fs 
    for(int i=0; i < fs.Length; i++) 
      fs[i] = i;  
 
    // now index with ints and doubles 
    Console.WriteLine("fs[1]: " + fs[1]); 
    Console.WriteLine("fs[2]: " + fs[2]); 
 
    Console.WriteLine("fs[1.1]: " + fs[1.1]); 
    Console.WriteLine("fs[1.6]: " + fs[1.6]); 
 
  }  
}

#endif

#if PwrTwo
// Indexers don't have to operate on actual arrays. 
 
class PwrOfTwo {  
 
  /* Access a logical array that contains 
     the powers of 2 from 0 to 15. */ 
  public int this[int index] { 
    // Compute and return power of 2. 
    get { 
      if((index >= 0) && (index < 16)) return pwr(index); 
      else return -1; 
    } 
 
    // there is no set accessor 
  } 
 
  int pwr(int p) { 
    int result = 1; 
 
    for(int i=0; i < p; i++) 
      result *= 2; 
     
    return result; 
  } 
}  
  
class UsePwrOfTwo {  
  public static void Main() {  
    PwrOfTwo pwr = new PwrOfTwo(); 
 
    Console.Write("First 8 powers of 2: "); 
    for(int i=0; i < 8; i++) 
      Console.Write(pwr[i] + " "); 
    Console.WriteLine(); 
 
    Console.Write("Here are some errors: "); 
    Console.Write(pwr[-1] + " " + pwr[17]); 
 
    Console.WriteLine(); 
  } 
}

#endif

#if FailSoftArray2D
// A two-dimensional fail-soft array. 

class FailSoftArray2D {  
  int[,] a; // reference to underlying 2D array  
  int rows, cols; // dimensions 
  public int Length; // Length is public 
 
  public bool errflag; // indicates outcome of last operation 
   
  // Construct array given its dimensions. 
  public FailSoftArray2D(int r, int c) { 
    rows = r; 
    cols = c; 
    a = new int[rows, cols]; 
    Length = rows * cols;  
  } 
 
  // This is the indexer for FailSoftArray2D. 
  public int this[int index1, int index2] { 
    // This is the get accessor. 
    get { 
      if(ok(index1, index2)) { 
        errflag = false; 
        return a[index1, index2]; 
      } else { 
        errflag = true; 
        return 0; 
      } 
    } 
 
    // This is the set accessor. 
    set { 
      if(ok(index1, index2)) { 
        a[index1, index2] = value; 
        errflag = false; 
      } 
      else errflag = true; 
    } 
  } 
 
  // Return true if indexes are within bounds. 
  private bool ok(int index1, int index2) { 
   if(index1 >= 0 & index1 < rows & 
      index2 >= 0 & index2 < cols) 
         return true; 
 
   return false; 
  } 
}  
  
// Demonstrate a 2D indexer. 
class TwoDIndexerDemo {  
  public static void Main() {  
    FailSoftArray2D fs = new FailSoftArray2D(3, 5); 
    int x; 
 
    // show quiet failures 
    Console.WriteLine("Fail quietly."); 
    for(int i=0; i < 6; i++) 
      fs[i, i] = i*10; 
 
    for(int i=0; i < 6; i++) { 
      x = fs[i,i]; 
      if(x != -1) Console.Write(x + " "); 
    } 
    Console.WriteLine(); 
 
    // now, generate failures 
    Console.WriteLine("\nFail with error reports."); 
    for(int i=0; i < 6; i++) { 
      fs[i,i] = i*10; 
      if(fs.errflag) 
        Console.WriteLine("fs[" + i + ", " + i + "] out-of-bounds"); 
    } 
 
    for(int i=0; i < 6; i++) { 
      x = fs[i,i]; 
      if(!fs.errflag) Console.Write(x + " "); 
      else 
        Console.WriteLine("fs[" + i + ", " + i + "] out-of-bounds"); 
    } 
  } 
}

#endif
// A simple property example. 
 
#if SimpProp

class SimpProp {  
  int prop; // field being managed by MyProp 
 
  public SimpProp() { prop = 0; } 
 
  /* This is the property that supports access to 
     the private instance variable prop.  It 
     allows only positive values. */ 
  public int MyProp { 
    get { 
      return prop; 
    } 
    set { 
      if(value >= 0) prop = value; 
    }  
  } 
}  
  
// Demonstrate a property. 
class PropertyDemo {  
  public static void Main() {  
    SimpProp ob = new SimpProp(); 
 
    Console.WriteLine("Original value of ob.MyProp: " + ob.MyProp); 
 
    ob.MyProp = 100; // assign value 
    Console.WriteLine("Value of ob.MyProp: " + ob.MyProp); 
 
    // Can't assign negative value to prop 
    Console.WriteLine("Attempting to assign -10 to ob.MyProp"); 
    ob.MyProp = -10; 
    Console.WriteLine("Value of ob.MyProp: " + ob.MyProp); 
  } 
}

#endif


#if FailSoftArray2    
// Add Length property to FailSoftArray. 
 
class FailSoftArray {  
  int[] a; // reference to underlying array  
  int len; // length of array -- underlies Length property 
 
  public bool errflag; // indicates outcome of last operation 
   
  // Construct array given its size.  
  public FailSoftArray(int size) { 
    a = new int[size]; 
    len = size;  
  } 
 
  // Read-only Length property. 
  public int Length { 
    get { 
      return len; 
    } 
  } 
 
  // This is the indexer for FailSoftArray. 
  public int this[int index] { 
    // This is the get accessor. 
    get { 
      if(ok(index)) { 
        errflag = false; 
        return a[index]; 
      } else { 
        errflag = true; 
        return 0; 
      } 
    } 
 
    // This is the set accessor 
    set { 
      if(ok(index)) { 
        a[index] = value; 
        errflag = false; 
      } 
      else errflag = true; 
    } 
  } 
 
  // Return true if index is within bounds. 
  private bool ok(int index) { 
   if(index >= 0 & index < Length) return true; 
   return false; 
  } 
}  
  
// Demonstrate the improved fail-soft array. 
class ImprovedFSDemo {  
  public static void Main() {  
    FailSoftArray fs = new FailSoftArray(5); 
    int x; 
 
    // can read Length 
    for(int i=0; i < fs.Length; i++) 
      fs[i] = i*10; 
 
    for(int i=0; i < fs.Length; i++) { 
      x = fs[i]; 
      if(x != -1) Console.Write(x + " "); 
    } 
    Console.WriteLine(); 
 
    // fs.Length = 10; // Error, illegal! 
  } 
}

#endif
// Convert errflag into a property. 
#if FailSoftArray3
 
class FailSoftArray {  
  int[] a; // reference to underlying array  
  int len; // length of array 
 
  bool errflag; // now private 
   
  // Construct array given its size.  
  public FailSoftArray(int size) { 
    a = new int[size]; 
    len = size;  
  } 
 
  // Read-only Length property. 
  public int Length { 
    get { 
      return len; 
    } 
  } 
 
  // Read-only Error property. 
  public bool Error { 
    get { 
      return errflag; 
    } 
  } 
 
  // This is the indexer for FailSoftArray. 
  public int this[int index] { 
    // This is the get accessor. 
    get { 
      if(ok(index)) { 
        errflag = false; 
        return a[index]; 
      } else { 
        errflag = true; 
        return 0; 
      } 
    } 
 
    // This is the set accessor 
    set { 
      if(ok(index)) { 
        a[index] = value; 
        errflag = false; 
      } 
      else errflag = true; 
    } 
  } 
 
  // Return true if index is within bounds. 
  private bool ok(int index) { 
   if(index >= 0 & index < Length) return true; 
   return false; 
  } 
}  
  
// Demonstrate the improved fail-soft array. 
class FinalFSDemo {  
  public static void Main() {  
    FailSoftArray fs = new FailSoftArray(5); 
 
    // use Error property 
    for(int i=0; i < fs.Length + 1; i++) { 
      fs[i] = i*10; 
      if(fs.Error)  
        Console.WriteLine("Error with index " + i); 
    } 
 
  } 
}

#endif

#if PropAccess
// Use an access modifier with an accessor. 
  
class PropAccess {   
  int prop; // field being managed by MyProp  
  
  public PropAccess() { prop = 0; }  
  
  /* This is the property that supports access to  
     the private instance variable prop.  It allows 
     any code to obtain the value of prop, but 
     only other class members can set the value 
     of prop. */  
  public int MyProp {  
    get {  
      return prop;  
    }  
    private set { // now, private  
      prop = value;  
    }   
  }  
 
  // This class member increments the value of MyProp. 
  public void incrProp() { 
    MyProp++; // OK, in same class. 
  } 
}   
 
// Demonstrate accessor access modifier. 
class PropAccessDemo {   
  public static void Main() {   
    PropAccess ob = new PropAccess();  
  
    Console.WriteLine("Original value of ob.MyProp: " + ob.MyProp);  
  
//    ob.MyProp = 100; // can't access set 
  
    ob.incrProp(); 
    Console.WriteLine("Value of ob.MyProp after increment: " 
                      + ob.MyProp);  
  }  
}

#endif

#if RangeArray
/* Create a specifiable range array class. 
   The RangeArray class allows indexing 
   to begin at some value other than zero. 
   When you create a RangeArray, you specify 
   the beginning and ending index. Negative 
   indexes are also  allowed.  For example, 
   you can create arrays that index from -5 to 5,  
   1 to 10, or 50 to 56. 
*/ 
  

class RangeArray {   
  // private data 
  int[] a; // reference to underlying array   
  int lowerBound; // lowest index 
  int upperBound; // greatest index 
 
  // data for properties 
  int len; // underlying var for Length property 
  bool errflag; // underlying var for outcome  
    
  // Construct array given its size.  
  public RangeArray(int low, int high) {  
    high++; 
    if(high <= low) { 
      Console.WriteLine("Invalid Indices"); 
      high = 1; // create a minimal array for safety 
      low = 0; 
    } 
    a = new int[high - low];  
    len = high - low;   
 
    lowerBound = low; 
    upperBound = --high; 
  }  
  
  // Read-only Length property.  
  public int Length {  
    get {  
      return len;  
    }  
  }  
 
  // Read-only Error property.  
  public bool Error {  
    get {  
      return errflag;  
    }  
  }  
 
  // This is the indexer for RangeArray.  
  public int this[int index] {  
    // This is the get accessor.  
    get {  
      if(ok(index)) {  
        errflag = false;  
        return a[index - lowerBound];  
      } else {  
        errflag = true;  
        return 0;  
      }  
    }  
  
    // This is the set accessor  
    set {  
      if(ok(index)) {  
        a[index - lowerBound] = value;  
        errflag = false;  
      }  
      else errflag = true;  
    }  
  }  
  
  // Return true if index is within bounds.  
  private bool ok(int index) {  
    if(index >= lowerBound & index <= upperBound) return true;  
    return false;  
  }  
}   
   
// Demonstrate the index-range array.  
class RangeArrayDemo {   
  public static void Main() {   
    RangeArray ra = new RangeArray(-5, 5);  
    RangeArray ra2 = new RangeArray(1, 10);  
    RangeArray ra3 = new RangeArray(-20, -12);  
 
    // Demonstrate ra 
    Console.WriteLine("Length of ra: " + ra.Length); 
 
    for(int i = -5; i <= 5; i++) 
      ra[i] = i; 
   
    Console.Write("Contents of ra: "); 
    for(int i = -5; i <= 5; i++) 
      Console.Write(ra[i] + " "); 
 
    Console.WriteLine("\n"); 
 
    // Demonstrate ra2 
    Console.WriteLine("Length of ra2: " + ra2.Length); 
 
    for(int i = 1; i <= 10; i++) 
      ra2[i] = i; 
 
    Console.Write("Contents of ra2: "); 
    for(int i = 1; i <= 10; i++) 
      Console.Write(ra2[i] + " "); 
 
    Console.WriteLine("\n"); 
 
    // Demonstrate ra3 
    Console.WriteLine("Length of ra3: " + ra3.Length); 
 
    for(int i = -20; i <= -12; i++) 
      ra3[i] = i; 
 
    Console.Write("Contents of ra3: "); 
    for(int i = -20; i <= -12; i++) 
      Console.Write(ra3[i] + " "); 
 
    Console.WriteLine("\n"); 
 
  }  
}
#endif

}

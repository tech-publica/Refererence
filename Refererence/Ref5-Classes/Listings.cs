//#define Building0
//#define Building1
//#define Building2
//#define Building3
//#define ChkNum0
//#define ChkNum1
//#define Building4
//#define MyClass0
//#define MyClass1
//#define Building5
//#define NewValue
//#define Destruct
//#define Rect0
//#define Rect1


using System.Collections.Generic;
using System.Text;
using System;
namespace Refererence.Ref5_Classes
{
#if Building0
// A program that uses the Building class.   
 
  
class Building {   
  public int floors;    // number of floors 
  public int area;      // total square footage of building 
  public int occupants; // number of occupants 
}   
   
// This class declares an object of type Building.   
class BuildingDemo {   
  public static void Main() {   
    Building house = new Building(); // create a Building object 
    int areaPP; // area per person 
   
    // assign values to fields in house 
    house.occupants = 4;  
    house.area = 2500;  
    house.floors = 2;  
   
    // compute the area per person 
    areaPP = house.area / house.occupants;  
   
    Console.WriteLine("house has:\n  " + 
                      house.floors + " floors\n  " + 
                      house.occupants + " occupants\n  " + 
                      house.area + " total area\n  " + 
                      areaPP + " area per person"); 
  }   
}
#endif



#if Building1
// This program creates two Building objects. 
    
  
class Building {   
  public int floors;    // number of floors 
  public int area;      // total square footage of building 
  public int occupants; // number of occupants 
}   
   
// This class declares two objects of type Building.   
class BuildingDemo {   
  public static void Main() {   
    Building house = new Building();   
    Building office = new Building(); 
 
    int areaPP; // area per person 
   
    // assign values to fields in house 
    house.occupants = 4;  
    house.area = 2500;  
    house.floors = 2;  
 
    // assign values to fields in office 
    office.occupants = 25;  
    office.area = 4200;  
    office.floors = 3;  
   
    // compute the area per person in house 
    areaPP = house.area / house.occupants;  
   
    Console.WriteLine("house has:\n  " + 
                      house.floors + " floors\n  " + 
                      house.occupants + " occupants\n  " + 
                      house.area + " total area\n  " + 
                      areaPP + " area per person"); 
 
    Console.WriteLine(); 
 
    // compute the area per person in office 
    areaPP = office.area / office.occupants;  
 
    Console.WriteLine("office has:\n  " + 
                      office.floors + " floors\n  " + 
                      office.occupants + " occupants\n  " + 
                      office.area + " total area\n  " + 
                      areaPP + " area per person"); 
  }   
}

#endif

#if Building2
// Add a method to Building. 
   
  
class Building {   
  public int floors;    // number of floors 
  public int area;      // total square footage of building 
  public int occupants; // number of occupants 
 
  // Display the area per person.  
  public void areaPerPerson() {  
    Console.WriteLine("  " + area / occupants + 
                      " area per person"); 
  }  
}   
 
// Use the areaPerPerson() method. 
class BuildingDemo {   
  public static void Main() {   
    Building house = new Building();   
    Building office = new Building(); 
 
 
    // assign values to fields in house 
    house.occupants = 4;  
    house.area = 2500;  
    house.floors = 2;  
 
    // assign values to fields in office 
    office.occupants = 25;  
    office.area = 4200;  
    office.floors = 3;  
   
 
    Console.WriteLine("house has:\n  " + 
                      house.floors + " floors\n  " + 
                      house.occupants + " occupants\n  " + 
                      house.area + " total area"); 
    house.areaPerPerson(); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("office has:\n  " + 
                      office.floors + " floors\n  " + 
                      office.occupants + " occupants\n  " + 
                      office.area + " total area"); 
    office.areaPerPerson(); 
  }   
}
#endif

#if Building3
// Return a value from areaPerPerson(). 
  
using System;  
  
class Building {   
  public int floors;    // number of floors 
  public int area;      // total square footage of building 
  public int occupants; // number of occupants 
 
  // Return the area per person.  
  public int areaPerPerson() {  
    return area / occupants; 
  }  
}   
   
// Use the return value from areaPerPerson().   
class BuildingDemo {   
  public static void Main() {   
    Building house = new Building();   
    Building office = new Building(); 
    int areaPP; // area per person 
 
    // assign values to fields in house 
    house.occupants = 4;  
    house.area = 2500;  
    house.floors = 2;  
 
    // assign values to fields in office 
    office.occupants = 25;  
    office.area = 4200;  
    office.floors = 3;  
   
    // obtain area per person for house 
    areaPP = house.areaPerPerson(); 
 
    Console.WriteLine("house has:\n  " + 
                      house.floors + " floors\n  " + 
                      house.occupants + " occupants\n  " + 
                      house.area + " total area\n  " + 
                      areaPP + " area per person"); 
 
 
    Console.WriteLine(); 
 
    // obtain area per person for office 
    areaPP = office.areaPerPerson(); 
 
    Console.WriteLine("office has:\n  " + 
                      office.floors + " floors\n  " + 
                      office.occupants + " occupants\n  " + 
                      office.area + " total area\n  " + 
                      areaPP + " area per person"); 
  }   
}

#endif


#if ChkNum0
// A simple example that uses a parameter. 
 
using System; 
 
class ChkNum {  
  // Return true if x is prime. 
  public bool isPrime(int x) { 
    for(int i=2; i <= x/i; i++) 
      if((x %i) == 0) return false; 
 
    return true; 
  } 
}  
  
class ParmDemo {  
  public static void Main() {  
    ChkNum ob = new ChkNum(); 
 
    for(int i=1; i < 10; i++) 
      if(ob.isPrime(i)) Console.WriteLine(i + " is prime."); 
      else Console.WriteLine(i + " is not prime."); 
 
  }  
}
#endif

#if ChkNum1
// Add a method that takes two arguments. 
 
using System; 
 
class ChkNum {  
  // Return true if x is prime. 
  public bool isPrime(int x) { 
    for(int i=2; i <= x/i; i++) 
      if((x %i) == 0) return false; 
 
    return true; 
  } 
 
  // Return the least common factor. 
  public int leastComFactor(int a, int b) { 
    int max; 
 
    if(isPrime(a) | isPrime(b)) return 1; 
 
    max = a < b ? a : b; 
 
    for(int i=2; i <= max/2; i++) 
      if(((a%i) == 0) & ((b%i) == 0)) return i; 
 
    return 1; 
  } 
}  
  
class ParmDemo {  
  public static void Main() {  
    ChkNum ob = new ChkNum(); 
    int a, b; 
 
    for(int i=1; i < 10; i++) 
      if(ob.isPrime(i)) Console.WriteLine(i + " is prime."); 
      else Console.WriteLine(i + " is not prime."); 
 
    a = 7; 
    b = 8; 
    Console.WriteLine("Least common factor for " + 
                      a + " and " + b + " is " + 
                      ob.leastComFactor(a, b)); 
 
    a = 100; 
    b = 8; 
    Console.WriteLine("Least common factor for " + 
                      a + " and " + b + " is " + 
                      ob.leastComFactor(a, b)); 
 
    a = 100; 
    b = 75; 
    Console.WriteLine("Least common factor for " + 
                      a + " and " + b + " is " + 
                      ob.leastComFactor(a, b)); 
 
  }  
}
#endif

#if Building4
/* 
   Add a parameterized method that computes the   
   maximum number of people that can occupy a 
   building assuming each needs a specified 
   minimum space. 
*/ 
   
  
class Building {   
  public int floors;    // number of floors 
  public int area;      // total square footage of building 
  public int occupants; // number of occupants 
 
  // Return the area per person.  
  public int areaPerPerson() {  
    return area / occupants; 
  }  
 
  /* Return the maximum number of occupants if each 
     is to have at least the specified minimum area. */ 
  public int maxOccupant(int minArea) { 
    return area / minArea; 
  } 
}   
 
// Use maxOccupant(). 
class BuildingDemo {   
  public static void Main() {   
    Building house = new Building();   
    Building office = new Building(); 
 
    // assign values to fields in house 
    house.occupants = 4;  
    house.area = 2500;  
    house.floors = 2;  
 
    // assign values to fields in office 
    office.occupants = 25;  
    office.area = 4200;  
    office.floors = 3;  
   
    Console.WriteLine("Maximum occupants for house if each has " + 
                      300 + " square feet: " + 
                      house.maxOccupant(300)); 
 
    Console.WriteLine("Maximum occupants for office if each has " + 
                      300 + " square feet: " + 
                      office.maxOccupant(300)); 
  }   
}

#endif


#if MyClass0

// A simple constructor. 
 
 
class MyClass { 
  public int x; 
 
  public MyClass() { 
    x = 10; 
  }   
}   
   
class ConsDemo {   
  public static void Main() {   
    MyClass t1 = new MyClass(); 
    MyClass t2 = new MyClass(); 
 
    Console.WriteLine(t1.x + " " + t2.x); 
  }   
}
#endif

#if Myclass1
// A parameterized constructor. 
  
 
class MyClass { 
  public int x; 
 
  public MyClass(int i) { 
    x = i; 
  }   
}   
   
class ParmConsDemo {   
  public static void Main() {   
    MyClass t1 = new MyClass(10); 
    MyClass t2 = new MyClass(88); 
 
    Console.WriteLine(t1.x + " " + t2.x); 
  }   
}
#endif

#if Building5
// Add a constructor to Building. 
   
  
class Building {   
  public int floors;    // number of floors 
  public int area;      // total square footage of building 
  public int occupants; // number of occupants 
 
 
  public Building(int f, int a, int o) { 
    floors = f; 
    area = a; 
    occupants = o; 
  } 
 
  // Display the area per person.  
  public int areaPerPerson() {  
    return area / occupants; 
  }  
 
  /* Return the maximum number of occupants if each 
     is to have at least the specified minimum area. */ 
  public int maxOccupant(int minArea) { 
    return area / minArea; 
  } 
}   
   
// Use the parameterized Building constructor. 
class BuildingDemo {   
  public static void Main() {   
    Building house = new Building(2, 2500, 4);   
    Building office = new Building(3, 4200, 25); 
 
    Console.WriteLine("Maximum occupants for house if each has " + 
                      300 + " square feet: " + 
                      house.maxOccupant(300)); 
 
    Console.WriteLine("Maximum occupants for office if each has " + 
                      300 + " square feet: " + 
                      office.maxOccupant(300)); 
  }   
}

#endif

#if NewValue
// Use new with a value type. 
 
using System; 
 
class NewValue {  
  public static void Main() {  
    int i = new int(); // initialize i to zero 
 
    Console.WriteLine("The value of i is: " + i); 
  }  
}

#endif

#if Destruct
// Demonstrate a destructor. 
  
 
class Destruct {  
  public int x;  
  
  public Destruct(int i) {  
    x = i;  
  }    
 
  // called when object is recycled 
  ~Destruct() { 
    Console.WriteLine("Destructing " + x); 
  } 
   
  // generates an object that is immediately destroyed 
  public void generator(int i) { 
    Destruct o = new Destruct(i); 
  } 
 
}    
    
class DestructDemo {    
  public static void Main() {    
    int count; 
 
    Destruct ob = new Destruct(0); 
 
    /* Now, generate a large number of objects.  At 
       some point, garbage collection will occur.  
       Note: you might need to increase the number 
       of objects generated in order to force 
       garbage collection. */ 
 
    for(count=1; count < 100000; count++) 
      ob.generator(count);  
 
    Console.WriteLine("Done"); 
  }    
}
#endif


#if Rect0
 
class Rect { 
  public int width; 
  public int height; 
 
  public Rect(int w, int h) { 
    width = w; 
    height = h; 
  } 
 
  public int area() { 
    return width * height; 
  } 
} 
  

class UseRect { 
  public static void Main() {   
    Rect r1 = new Rect(4, 5); 
    Rect r2 = new Rect(7, 9); 
 
    Console.WriteLine("Area of r1: " + r1.area()); 
 
    Console.WriteLine("Area of r2: " + r2.area()); 
 
  } 
}

#endif

#if Rect1
 
class Rect { 
  public int width; 
  public int height; 
 
  public Rect(int w, int h) { 
    this.width = w; 
    this.height = h; 
  } 
 
  public int area() { 
    return this.width * this.height; 
  } 
} 
  
class UseRect { 
  public static void Main() {   
    Rect r1 = new Rect(4, 5); 
    Rect r2 = new Rect(7, 9); 
 
    Console.WriteLine("Area of r1: " + r1.area()); 
 
    Console.WriteLine("Area of r2: " + r2.area()); 
 
  } 
}
#endif

}

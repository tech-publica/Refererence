using System;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Ref10_Class_Hierarchies
{


#if TwoDShape0
// A simple class hierarchy. 

// A class for two-dimensional objects. 
class TwoDShape { 
  public double width; 
  public double height; 
 
  public void showDim() { 
    Console.WriteLine("Width and height are " + 
                       width + " and " + height); 
  } 
} 
 
// Triangle is derived from TwoDShape. 
class Triangle : TwoDShape { 
  public string style; // style of triangle 
   
  // Return area of triangle. 
  public double area() { 
    return width * height / 2; 
  } 
 
  // Display a triangle's style. 
  public void showStyle() { 
    Console.WriteLine("Triangle is " + style); 
  } 
} 
 
class Shapes { 
  public static void Main() { 
    Triangle t1 = new Triangle(); 
    Triangle t2 = new Triangle(); 
 
    t1.width = 4.0; 
    t1.height = 4.0; 
    t1.style = "isosceles"; 
 
    t2.width = 8.0; 
    t2.height = 12.0; 
    t2.style = "right"; 
 
    Console.WriteLine("Info for t1: "); 
    t1.showStyle(); 
    t1.showDim(); 
    Console.WriteLine("Area is " + t1.area()); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Info for t2: "); 
    t2.showStyle(); 
    t2.showDim(); 
    Console.WriteLine("Area is " + t2.area()); 
  } 
}

#endif


#if TwoDShape1
// Private members are not inherited.  
 
// This example will not compile. 
using System; 
 
// A class for two-dimensional objects. 
class TwoDShape { 
  double width;  // now private 
  double height; // now private 
 
  public void showDim() { 
    Console.WriteLine("Width and height are " + 
                       width + " and " + height); 
  } 
} 
 
// Triangle is derived from TwoDShape. 
class Triangle : TwoDShape { 
  public string style; // style of triangle 
   
  // Return area of triangle. 
  public double area() { 
    return width * height / 2; // Error, can't access private member 
  } 
 
  // Display a triangle's style. 
  public void showStyle() { 
    Console.WriteLine("Triangle is " + style); 
  } 
}

#endif



#if TwoDShape2
// Use properties to set and get private members. 

 
// A class for two-dimensional objects. 
class TwoDShape { 
  double pri_width;  // now private 
  double pri_height; // now private  
 
  // Properties for width and height. 
  public double width { 
     get { return pri_width; } 
     set { pri_width = value; } 
  } 
 
  public double height { 
     get { return pri_height; } 
     set { pri_height = value; } 
  } 
 
  public void showDim() { 
    Console.WriteLine("Width and height are " + 
                       width + " and " + height); 
  } 
} 
 
// A derived class of TwoDShape for triangles. 
class Triangle : TwoDShape { 
  public string style; // style of triangle 
   
  // Return area of triangle. 
  public double area() { 
    return width * height / 2;  
  } 
 
  // Display a triangle's style. 
  public void showStyle() { 
    Console.WriteLine("Triangle is " + style); 
  } 
} 
 
class Shapes2 { 
  public static void Main() { 
    Triangle t1 = new Triangle(); 
    Triangle t2 = new Triangle(); 
 
    t1.width = 4.0; 
    t1.height = 4.0; 
    t1.style = "isosceles"; 
 
    t2.width = 8.0; 
    t2.height = 12.0; 
    t2.style = "right"; 
 
    Console.WriteLine("Info for t1: "); 
    t1.showStyle(); 
    t1.showDim(); 
    Console.WriteLine("Area is " + t1.area()); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Info for t2: "); 
    t2.showStyle(); 
    t2.showDim(); 
    Console.WriteLine("Area is " + t2.area()); 
  } 
}

#endif


#if Protected
// Demonstrate protected. 
 
 
class B { 
  protected int i, j; // private to B, but accessible by D 
 
  public void set(int a, int b) { 
    i = a; 
    j = b; 
  } 
 
  public void show() { 
    Console.WriteLine(i + " " + j); 
 } 
} 
 
class D : B { 
  int k; // private 
 
  // D can access B's i and j 
  public void setk() { 
     k = i * j; 
  } 
 
  public void showk() { 
    Console.WriteLine(k); 
  } 
} 
 
class ProtectedDemo { 
  public static void Main() { 
    D ob = new D(); 
 
    ob.set(2, 3); // OK, known to D 
    ob.show();    // OK, known to D 
 
    ob.setk();  // OK, part of D 
    ob.showk(); // OK, part of D 
  } 
}



#define SuperConstr0
// Add a constructor to Triangle. 
 
using System; 
 
// A class for two-dimensional objects. 
class TwoDShape { 
  double pri_width;  // private 
  double pri_height; // private  
 
  // properties for width and height. 
  public double width { 
     get { return pri_width; } 
     set { pri_width = value; } 
  } 
 
  public double height { 
     get { return pri_height; } 
     set { pri_height = value; } 
  } 
 
  public void showDim() { 
    Console.WriteLine("Width and height are " + 
                       width + " and " + height); 
  } 
} 
 
// A derived class of TwoDShape for triangles. 
class Triangle : TwoDShape { 
  string style; // private 
   
  // Constructor 
  public Triangle(string s, double w, double h) { 
    width = w;  // init the base class 
    height = h; // init the base class 
 
    style = s;  // init the derived class 
  } 
 
  // Return area of triangle. 
  public double area() { 
    return width * height / 2;  
  } 
 
  // Display a triangle's style. 
  public void showStyle() { 
    Console.WriteLine("Triangle is " + style); 
  } 
} 
 
class Shapes3 { 
  public static void Main() { 
    Triangle t1 = new Triangle("isosceles", 4.0, 4.0); 
    Triangle t2 = new Triangle("right", 8.0, 12.0); 
 
    Console.WriteLine("Info for t1: "); 
    t1.showStyle(); 
    t1.showDim(); 
    Console.WriteLine("Area is " + t1.area()); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Info for t2: "); 
    t2.showStyle(); 
    t2.showDim(); 
    Console.WriteLine("Area is " + t2.area()); 
  } 
}

#endif
  
#if SuperConstr1 
 // Add constructors to TwoDShape.


// A class for two-dimensional objects. 
class TwoDShape { 
  double pri_width;  // private 
  double pri_height; // private  
 
  // Constructor for TwoDShape. 
  public TwoDShape(double w, double h) { 
    width = w; 
    height = h; 
  } 
 
  // properties for width and height. 
  public double width { 
     get { return pri_width; } 
     set { pri_width = value; } 
  } 
 
  public double height { 
     get { return pri_height; } 
     set { pri_height = value; } 
  } 
 
  public void showDim() { 
    Console.WriteLine("Width and height are " + 
                       width + " and " + height); 
  } 
} 
 
 // A derived class of TwoDShape for triangles. 
class Triangle : TwoDShape { 
  string style; // private 
   
  // Call the base class constructor. 
  public Triangle(string s, double w, double h) : base(w, h) { 
    style = s;  
  } 
 
  // Return area of triangle. 
  public double area() { 
    return width * height / 2; 
  } 
 
  // Display a triangle's style. 
  public void showStyle() { 
    Console.WriteLine("Triangle is " + style); 
  } 
} 
 
class Shapes4 { 
  public static void Main() { 
    Triangle t1 = new Triangle("isosceles", 4.0, 4.0); 
    Triangle t2 = new Triangle("right", 8.0, 12.0); 
 
    Console.WriteLine("Info for t1: "); 
    t1.showStyle(); 
    t1.showDim(); 
    Console.WriteLine("Area is " + t1.area()); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Info for t2: "); 
    t2.showStyle(); 
    t2.showDim(); 
    Console.WriteLine("Area is " + t2.area()); 
  } 
}

#endif

#if SuperConstr2
// Add more constructors to TwoDShape. 
 
using System; 
 
class TwoDShape { 
  double pri_width;  // private 
  double pri_height; // private  
 
  // Default constructor. 
  public TwoDShape() { 
    width = height = 0.0; 
  } 
 
  // Constructor for TwoDShape. 
  public TwoDShape(double w, double h) { 
    width = w; 
    height = h; 
  } 
 
  // Construct object with equal width and height. 
  public TwoDShape(double x) { 
    width = height = x; 
  } 
 
  // Properties for width and height. 
  public double width { 
     get { return pri_width; } 
     set { pri_width = value; } 
  } 
 
  public double height { 
     get { return pri_height; } 
     set { pri_height = value; } 
  } 
 
  public void showDim() { 
    Console.WriteLine("Width and height are " + 
                       width + " and " + height); 
  } 
} 
 
// A derived class of TwoDShape for triangles. 
class Triangle : TwoDShape { 
  string style; // private 
   
  /* A default constructor. This automatically invokes 
     the default constructor of TwoDShape. */ 
  public Triangle() { 
    style = "null"; 
  } 
 
  // Constructor that takes three arguments. 
  public Triangle(string s, double w, double h) : base(w, h) { 
    style = s;  
  } 
 
  // Construct an isosceles triangle. 
  public Triangle(double x) : base(x) { 
    style = "isosceles";  
  } 
 
  // Return area of triangle. 
  public double area() { 
    return width * height / 2; 
  } 
 
  // Display a triangle's style. 
  public void showStyle() { 
    Console.WriteLine("Triangle is " + style); 
  } 
} 
 
class Shapes5 { 
  public static void Main() { 
    Triangle t1 = new Triangle(); 
    Triangle t2 = new Triangle("right", 8.0, 12.0); 
    Triangle t3 = new Triangle(4.0); 
 
    t1 = t2; 
 
    Console.WriteLine("Info for t1: "); 
    t1.showStyle(); 
    t1.showDim(); 
    Console.WriteLine("Area is " + t1.area()); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Info for t2: "); 
    t2.showStyle(); 
    t2.showDim(); 
    Console.WriteLine("Area is " + t2.area()); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Info for t3: "); 
    t3.showStyle(); 
    t3.showDim(); 
    Console.WriteLine("Area is " + t3.area()); 
 
    Console.WriteLine(); 
  } 
}

#endif


#if NameHiding
// An example of inheritance-related name hiding. 
 
class A { 
  public int i = 0; 
} 
 
// Create a derived class. 
class B : A { 
  new int i; // this i hides the i in A 
 
  public B(int b) { 
    i = b; // i in B 
  } 
 
  public void show() { 
    Console.WriteLine("i in derived class: " + i); 
  } 
} 
 
class NameHiding { 
  public static void Main() { 
    B ob = new B(2); 
 
    ob.show(); 
  } 
}

#endif

#if BaseForNameHiding
// Using base to overcome name hiding. 
 

class A { 
  public int i = 0; 
} 
 
// Create a derived class. 
class B : A { 
  new int i; // this i hides the i in A 
 
  public B(int a, int b) { 
    base.i = a; // this uncovers the i in A 
    i = b; // i in B 
  } 
 
  public void show() { 
    // this displays the i in A. 
    Console.WriteLine("i in base class: " + base.i); 
 
    // this displays the i in B 
    Console.WriteLine("i in derived class: " + i); 
  } 
} 
 
class UncoverName { 
  public static void Main() { 
    B ob = new B(1, 2); 
 
    ob.show(); 
  } 
}

#endif

#if CallHiddenMethod
// Call a hidden method. 
 

class A { 
  public int i = 0; 
 
  // show() in A 
  public void show() { 
    Console.WriteLine("i in base class: " + i); 
  } 
} 
 
// Create a derived class. 
class B : A { 
  new int i; // this i hides the i in A 
 
  public B(int a, int b) { 
    base.i = a; // this uncovers the i in A 
    i = b; // i in B 
  } 

  // This hides show() in A. Notice the use of new. 
  new public void show() { 
    base.show(); // this calls show() in A 
 
    // this displays the i in B 
    Console.WriteLine("i in derived class: " + i); 
  } 
} 
 
class UncoverName { 
  public static void Main() { 
    B ob = new B(1, 2); 
 
    ob.show(); 
  } 
}

#endif

#if MultilevelHierarchy
// A multilevel hierarchy. 
 
class TwoDShape { 
  double pri_width;  // private 
  double pri_height; // private  
 
  // Default constructor. 
  public TwoDShape() { 
    width = height = 0.0; 
  } 
 
  // Constructor for TwoDShape. 
  public TwoDShape(double w, double h) { 
    width = w; 
    height = h; 
  } 
 
  // Construct object with equal width and height. 
  public TwoDShape(double x) { 
    width = height = x; 
  } 
 
  // Properties for width and height. 
  public double width { 
     get { return pri_width; } 
     set { pri_width = value; } 
  } 
 
  public double height { 
     get { return pri_height; } 
     set { pri_height = value; } 
  } 
 
  public void showDim() { 
    Console.WriteLine("Width and height are " + 
                       width + " and " + height); 
  } 
} 
 
// A derived class of TwoDShape for triangles. 
class Triangle : TwoDShape { 
  string style; // private 
   
  /* A default constructor. This invokes the default 
     constructor of TwoDShape. */ 
  public Triangle() { 
    style = "null"; 
  } 
 
  // Constructor 
  public Triangle(string s, double w, double h) : base(w, h) { 
    style = s;  
  } 
 
  // Construct an isosceles triangle. 
  public Triangle(double x) : base(x) { 
    style = "isosceles";  
  } 
 
  // Return area of triangle. 
  public double area() { 
    return width * height / 2; 
  } 
 
  // Display a triangle's style. 
  public void showStyle() { 
    Console.WriteLine("Triangle is " + style); 
  } 
} 
 
// Extend Triangle. 
class ColorTriangle : Triangle { 
  string color; 
 
  public ColorTriangle(string c, string s, 
                       double w, double h) : base(s, w, h) { 
    color = c; 
  } 
 
  // Display the color. 
  public void showColor() { 
    Console.WriteLine("Color is " + color); 
  } 
} 
 
class Shapes6 { 
  public static void Main() { 
    ColorTriangle t1 =  
         new ColorTriangle("Blue", "right", 8.0, 12.0); 
    ColorTriangle t2 =  
         new ColorTriangle("Red", "isosceles", 2.0, 2.0); 
 
    Console.WriteLine("Info for t1: "); 
    t1.showStyle(); 
    t1.showDim(); 
    t1.showColor(); 
    Console.WriteLine("Area is " + t1.area()); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Info for t2: "); 
    t2.showStyle(); 
    t2.showDim(); 
    t2.showColor(); 
    Console.WriteLine("Area is " + t2.area()); 
  } 
}


#endif

#if ConstructorsSequence

// Demonstrate when constructors are called. 
 

// Create a base class. 
class A { 
  public A() {  
    Console.WriteLine("Constructing A."); 
  } 
} 
 
// Create a class derived from A. 
class B : A { 
  public B() { 
    Console.WriteLine("Constructing B."); 
  } 
} 
 
// Create a class derived from B. 
class C : B { 
  public C() { 
    Console.WriteLine("Constructing C."); 
  } 
} 
 
class OrderOfConstruction { 
  public static void Main() { 
    C c = new C(); 
  } 
}

#endif

#if ConstructorError
// This program will not compile. 
 
class X { 
  int a; 
 
  public X(int i) { a = i; } 
} 
 
class Y { 
  int a; 
 
  public Y(int i) { a = i; } 
} 
 
class IncompatibleRef { 
  public static void Main() { 
    X x = new X(10); 
    X x2;  
    Y y = new Y(5); 
 
    x2 = x; // OK, both of same type 
 
    x2 = y; // Error, not of same type 
  } 
}

#endif




#if BasicPolymorphism0
// A base class reference can refer to a derived class object. 
 
using System; 
 
class X { 
  public int a; 
 
  public X(int i) { 
    a = i; 
  } 
} 
 
class Y : X { 
  public int b; 
 
  public Y(int i, int j) : base(j) { 
    b = i; 
  } 
} 
 
class BaseRef { 
  public static void Main() { 
    X x = new X(10); 
    X x2;  
    Y y = new Y(5, 6); 
 
    x2 = x; // OK, both of same type 
    Console.WriteLine("x2.a: " + x2.a); 
 
    x2 = y; // Ok because Y is derived from X 
    Console.WriteLine("x2.a: " + x2.a); 
 
    // X references know only about X members 
    x2.a = 19; // OK 
//    x2.b = 27; // Error, X doesn't have a b member 
  } 
}
#endif

#if PassDerivedToBase
// Pass a derived class reference to a base class reference. 
 
using System; 
 
class TwoDShape { 
  double pri_width;  // private 
  double pri_height; // private 
 
  // Default constructor. 
  public TwoDShape() { 
    width = height = 0.0; 
  } 
 
  // Constructor for TwoDShape. 
  public TwoDShape(double w, double h) { 
    width = w; 
    height = h; 
  } 
 
  // Construct object with equal width and height. 
  public TwoDShape(double x) { 
    width = height = x; 
  } 
 
  // Construct object from an object. 
  public TwoDShape(TwoDShape ob) { 
    width = ob.width; 
    height = ob.height; 
  } 
 
  // Properties for width and height. 
  public double width { 
     get { return pri_width; } 
     set { pri_width = value; } 
  } 
 
  public double height { 
     get { return pri_height; } 
     set { pri_height = value; } 
  } 
 
  public void showDim() { 
    Console.WriteLine("Width and height are " + 
                       width + " and " + height); 
  } 
} 
 
// A derived class of TwoDShape for triangles. 
class Triangle : TwoDShape { 
  string style; // private 
   
  // A default constructor. 
  public Triangle() { 
    style = "null"; 
  } 
 
  // Constructor for Triangle. 
  public Triangle(string s, double w, double h) : base(w, h) { 
    style = s;  
  } 
 
  // Construct an isosceles triangle. 
  public Triangle(double x) : base(x) { 
    style = "isosceles";  
  } 
 
  // Construct an object from an object. 
  public Triangle(Triangle ob) : base(ob) { 
    style = ob.style; 
  } 
 
  // Return area of triangle. 
  public double area() { 
    return width * height / 2; 
  } 
 
  // Display a triangle's style. 
  public void showStyle() { 
    Console.WriteLine("Triangle is " + style); 
  } 
} 
 
class Shapes7 { 
  public static void Main() { 
    Triangle t1 = new Triangle("right", 8.0, 12.0); 
 
    // make a copy of t1 
    Triangle t2 = new Triangle(t1); 
 
    Console.WriteLine("Info for t1: "); 
    t1.showStyle(); 
    t1.showDim(); 
    Console.WriteLine("Area is " + t1.area()); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Info for t2: "); 
    t2.showStyle(); 
    t2.showDim(); 
    Console.WriteLine("Area is " + t2.area()); 
  } 
}


#endif


#if Virtual0
// Demonstrate a virtual method. 
 

class Base { 
  // Create virtual method in the base class.  
  public virtual void who() { 
    Console.WriteLine("who() in Base"); 
  } 
} 
 
class Derived1 : Base { 
  // Override who() in a derived class. 
  public override void who() { 
    Console.WriteLine("who() in Derived1"); 
  } 
} 
 
class Derived2 : Base { 
  // Override who() again in another derived class. 
  public override void who() { 
    Console.WriteLine("who() in Derived2"); 
  } 
} 
 
class OverrideDemo { 
  public static void Main() { 
    Base baseOb = new Base(); 
    Derived1 dOb1 = new Derived1(); 
    Derived2 dOb2 = new Derived2(); 
 
    Base baseRef; // a base-class reference 
 
    baseRef = baseOb;  
    baseRef.who(); 
 
    baseRef = dOb1;  
    baseRef.who(); 
 
    baseRef = dOb2;  
    baseRef.who(); 
  } 
}

#endif


#if Virtual1
/* When a virtual method is not overridden, 
   the base class method is used. */ 
 
class Base { 
  // Create virtual method in the base class.  
  public virtual void who() { 
    Console.WriteLine("who() in Base"); 
  } 
} 
 
class Derived1 : Base { 
  // Override who() in a derived class. 
  public override void who() { 
    Console.WriteLine("who() in Derived1"); 
  } 
} 
 
class Derived2 : Base { 
  // This class does not override who(). 
} 
 
class NoOverrideDemo { 
  public static void Main() { 
    Base baseOb = new Base(); 
    Derived1 dOb1 = new Derived1(); 
    Derived2 dOb2 = new Derived2(); 
 
    Base baseRef; // a base-class reference 
 
    baseRef = baseOb;  
    baseRef.who(); 
 
    baseRef = dOb1;  
    baseRef.who(); 
 
    baseRef = dOb2;  
    baseRef.who(); // calls Base's who() 
  } 
}

#endif

#if Virtual2
/*  In a multilevel hierarchy, the  
    first override of a virtual method 
    that is found while moving up the 
    hierarchy is the one executed. */ 
   
  
class Base {  
  // Create virtual method in the base class.   
  public virtual void who() {  
    Console.WriteLine("who() in Base");  
  }  
}  
  
class Derived1 : Base {  
  // Override who() in a derived class.  
  public override void who() {  
    Console.WriteLine("who() in Derived1");  
  }  
}  
  
class Derived2 : Derived1 {  
  // This class also does not override who().  
}  
 
class Derived3 : Derived2 {  
  // This class does not override who().  
}  
 
class NoOverrideDemo2 {  
  public static void Main() {  
    Derived3 dOb = new Derived3();  
    Base baseRef; // a base-class reference  
  
    baseRef = dOb;   
    baseRef.who(); // calls Derived1's who()  
  }  
}

#endif

#if PolyExample
// Use virtual methods and polymorphism. 
 
using System; 
 
class TwoDShape {  
  double pri_width;  // private 
  double pri_height; // private 
  string pri_name;   // private 
  
  // A default constructor.  
  public TwoDShape() {  
    width = height = 0.0;  
    name = "null";  
  }  
  
  // Parameterized constructor.  
  public TwoDShape(double w, double h, string n) {  
    width = w;  
    height = h;  
    name = n;  
  }  
  
  // Construct object with equal width and height.  
  public TwoDShape(double x, string n) {  
    width = height = x;  
    name = n;  
  }  
  
  // Construct an object from an object.  
  public TwoDShape(TwoDShape ob) {  
    width = ob.width;  
    height = ob.height;  
    name = ob.name;  
  }  
  
  // Properties for width, height, and name 
  public double width { 
    get { return pri_width; } 
    set { pri_width = value; } 
  } 
 
  public double height { 
    get { return pri_height; } 
    set { pri_height = value; } 
  } 
 
  public string name { 
    get { return pri_name; } 
    set { pri_name = value; } 
  } 
  
  public void showDim() {  
    Console.WriteLine("Width and height are " +  
                       width + " and " + height);  
  }  
  
  public virtual double area() {   
    Console.WriteLine("area() must be overridden");  
    return 0.0;  
  }   
}  
  
// A derived class of TwoDShape for triangles. 
class Triangle : TwoDShape {  
  string style; // private 
    
  // A default constructor.  
  public Triangle() {  
    style = "null";  
  }  
  
  // Constructor for Triangle.  
  public Triangle(string s, double w, double h) : 
    base(w, h, "triangle") {  
      style = s;   
  }  
  
  // Construct an isosceles triangle.  
  public Triangle(double x) : base(x, "triangle") {  
    style = "isosceles";   
  }  
  
  // Construct an object from an object.  
  public Triangle(Triangle ob) : base(ob) {  
    style = ob.style;  
  }  
  
  // Override area() for Triangle. 
  public override double area() {  
    return width * height / 2;  
  }  
  
  // Display a triangle's style. 
  public void showStyle() {  
    Console.WriteLine("Triangle is " + style);  
  }  
}  
  
// A derived class of TwoDShape for rectangles.   
class Rectangle : TwoDShape {   
  // Constructor for Rectangle.  
  public Rectangle(double w, double h) :  
    base(w, h, "rectangle"){ }  
  
  // Construct a square.  
  public Rectangle(double x) :  
    base(x, "rectangle") { }  
  
  // Construct an object from an object.  
  public Rectangle(Rectangle ob) : base(ob) { }  
  
  // Return true if the rectangle is square. 
  public bool isSquare() {   
    if(width == height) return true;   
    return false;   
  }   
     
  // Override area() for Rectangle. 
  public override double area() {   
    return width * height;   
  }   
}  
  
class DynShapes {  
  public static void Main() {  
    TwoDShape[] shapes = new TwoDShape[5];  
  
    shapes[0] = new Triangle("right", 8.0, 12.0);  
    shapes[1] = new Rectangle(10);  
    shapes[2] = new Rectangle(10, 4);  
    shapes[3] = new Triangle(7.0);  
    shapes[4] = new TwoDShape(10, 20, "generic"); 
  
    for(int i=0; i < shapes.Length; i++) {  
      Console.WriteLine("object is " + shapes[i].name);  
      Console.WriteLine("Area is " + shapes[i].area());  
  
      Console.WriteLine();    
    }  
  }  
}

#endif

#if AbstractClass
// Create an abstract class. 

 
abstract class TwoDShape {  
  double pri_width;  // private 
  double pri_height; // private 
  string pri_name;   // private 
  
  // A default constructor.  
  public TwoDShape() {  
    width = height = 0.0;  
    name = "null";  
  }  
  
  // Parameterized constructor.  
  public TwoDShape(double w, double h, string n) {  
    width = w;  
    height = h;  
    name = n;  
  }  
  
  // Construct object with equal width and height.  
  public TwoDShape(double x, string n) {  
    width = height = x;  
    name = n;  
  }  
  
  // Construct an object from an object.  
  public TwoDShape(TwoDShape ob) {  
    width = ob.width;  
    height = ob.height;  
    name = ob.name;  
  }  
  
  // Properties for width, height, and name 
  public double width { 
    get { return pri_width; } 
    set { pri_width = value; } 
  } 
 
  public double height { 
    get { return pri_height; } 
    set { pri_height = value; } 
  } 
 
  public string name { 
    get { return pri_name; } 
    set { pri_name = value; } 
  } 
  
  public void showDim() {  
    Console.WriteLine("Width and height are " +  
                       width + " and " + height);  
  }  
  
  // Now, area() is abstract. 
  public abstract double area(); 
}  
  
// A derived class of TwoDShape for triangles. 
class Triangle : TwoDShape {  
  string style; // private 
    
  // A default constructor.  
  public Triangle() {  
    style = "null";  
  }  
  
  // Constructor for Triangle.  
  public Triangle(string s, double w, double h) : 
    base(w, h, "triangle") {  
      style = s;   
  }  
  
  // Construct an isosceles triangle.  
  public Triangle(double x) : base(x, "triangle") {  
    style = "isosceles";   
  }  
  
  // Construct an object from an object.  
  public Triangle(Triangle ob) : base(ob) {  
    style = ob.style;  
  }  
  
  // Override area() for Triangle. 
  public override double area() {  
    return width * height / 2;  
  }  
  
  // Display a triangle's style. 
  public void showStyle() {  
    Console.WriteLine("Triangle is " + style);  
  }  
}  
  
// A derived class of TwoDShape for rectangles.   
class Rectangle : TwoDShape {   
  // Constructor for Rectangle.  
  public Rectangle(double w, double h) :  
    base(w, h, "rectangle"){ }  
  
  // Construct a square.  
  public Rectangle(double x) :  
    base(x, "rectangle") { }  
  
  // Construct an object from an object.  
  public Rectangle(Rectangle ob) : base(ob) { }  
  
  // Return true if the rectangle is square. 
  public bool isSquare() {   
    if(width == height) return true;   
    return false;   
  }   
     
  // Override area() for Rectangle. 
  public override double area() {   
    return width * height;   
  }   
}  
  

class AbsShape {  
  public static void Main() {  
    TwoDShape[] shapes = new TwoDShape[4];  
  
    shapes[0] = new Triangle("right", 8.0, 12.0);  
    shapes[1] = new Rectangle(10);  
    shapes[2] = new Rectangle(10, 4);  
    shapes[3] = new Triangle(7.0);  
  
    for(int i=0; i < shapes.Length; i++) {  
      Console.WriteLine("object is " + shapes[i].name);  
      Console.WriteLine("Area is " + shapes[i].area());  
  
      Console.WriteLine();    
    }  
  }  
}

#endif

#if ToString
// Demonstrate ToString() 
 

class MyClass { 
  static int count = 0; 
  int id; 
 
  public MyClass() { 
    id = count; 
    count++; 
  } 
 
  public override string ToString() { 
    return "MyClass object #" + id; 
  } 
} 
 
class Test { 
  public static void Main() { 
    MyClass ob1 = new MyClass(); 
    MyClass ob2 = new MyClass(); 
    MyClass ob3 = new MyClass(); 
 
    Console.WriteLine(ob1); 
    Console.WriteLine(ob2); 
    Console.WriteLine(ob3); 
 
  } 
}

#endif

#if Boxing0

// A simple boxing/unboxing example. 
 

class BoxingDemo { 
  public static void Main() { 
    int x; 
    object obj; 
 
    x = 10; 
    obj = x; // box x into an object 
 
    int y = (int)obj; // unbox obj into an int 
    Console.WriteLine(y); 
  } 
}

#endif

#if Boxing1
// Boxing also occurs when passing values. 
 
 
class BoxingDemo { 
  public static void Main() { 
    int x; 
    
    x = 10; 
    Console.WriteLine("Here is x: " + x); 
 
    // x is automatically boxed when passed to sqr() 
    x = BoxingDemo.sqr(x); 
    Console.WriteLine("Here is x squared: " + x); 
  } 
 
  static int sqr(object o) { 
    return (int)o * (int)o; 
  } 
}

#endif

#if Boxing2
// Boxing makes it possible to call methods on a value! 
 
using System; 
 
class MethOnValue { 
  public static void Main() { 
 
    Console.WriteLine(10.ToString()); 
 
  } 
}

#endif

#if ArrayOfObjects
// Use object to create a generic array. 
 

class GenericDemo {   
  public static void Main() {   
    object[] ga = new object[10]; 
  
    // store ints 
    for(int i=0; i < 3; i++) 
      ga[i] = i; 
  
    // store doubles 
    for(int i=3; i < 6; i++) 
      ga[i] = (double) i / 2;  
 
 
    // store two strings, a bool, and a char 
    ga[6] = "Generic Array"; 
    ga[7] = true; 
    ga[8] = 'X'; 
    ga[9] = "end"; 
 
    for(int i = 0; i < ga.Length; i++) 
      Console.WriteLine("ga[" + i + "]: " + ga[i] + " "); 
 
  }  
}

#endif
}

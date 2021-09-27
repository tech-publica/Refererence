
using System;
using System.Threading;

namespace Refererence.Refe21_Threads
{
#if SimpleThread
// Create a thread of execution. 
class MyThread { 
  public int count; 
  string thrdName; 
 
  public MyThread(string name) { 
    count = 0; 
    thrdName = name; 
  } 
 
  // Entry point of thread. 
  public void run() { 
    Console.WriteLine(thrdName + " starting."); 
 
    do { 
      Thread.Sleep(500); 
      Console.WriteLine("In " + thrdName + 
                        ", count is " + count); 
      count++; 
    } while(count < 10); 
 
    Console.WriteLine(thrdName + " terminating."); 
  } 
} 
 
class MultiThread { 
  public static void Main() { 
    Console.WriteLine("Main thread starting."); 
 
    // First, construct a MyThread object. 
    MyThread mt = new MyThread("Child #1"); 
 
    // Next, construct a thread from that object. 
    Thread newThrd = new Thread(new ThreadStart(mt.run)); 
 
    // Finally, start execution of the thread. 
    newThrd.Start(); 
 
    do { 
      Console.Write("."); 
      Thread.Sleep(100); 
    } while (mt.count != 10); 
 
    Console.WriteLine("Main thread ending."); 
  } 
}

#endif

#if ThreadWithGroupConversion
// An alternate way to start a thread. 
class MyThread { 
  public int count; 
  public Thread thrd; 
 
  public MyThread(string name) { 
    count = 0; 
    thrd = new Thread(this.run); // use method group conversion 
    thrd.Name = name; // set the name of the thread 
    thrd.Start(); // start the thread 
  } 
 
  // Entry point of thread. 
  void run() { 
    Console.WriteLine(thrd.Name + " starting."); 
 
    do { 
      Thread.Sleep(500); 
      Console.WriteLine("In " + thrd.Name + 
                        ", count is " + count); 
      count++; 
    } while(count < 10); 
 
    Console.WriteLine(thrd.Name + " terminating."); 
  } 
} 
 
class MultiThreadImproved { 
  public static void Main() { 
    Console.WriteLine("Main thread starting."); 
 
    // First, construct a MyThread object. 
    MyThread mt = new MyThread("Child #1"); 
 
    do { 
      Console.Write("."); 
      Thread.Sleep(100); 
    } while (mt.count != 10); 
 
    Console.WriteLine("Main thread ending."); 
  } 
}

#endif

#if MultipleThread
// Create multiple threads of execution. 
class MyThread { 
  public int count; 
  public Thread thrd; 
 
  public MyThread(string name) { 
    count = 0; 
    thrd = new Thread(this.run); 
    thrd.Name = name; 
    thrd.Start(); 
  } 
 
  // Entry point of thread. 
  void run() { 
    Console.WriteLine(thrd.Name + " starting."); 
 
    do { 
      Thread.Sleep(500); 
      Console.WriteLine("In " + thrd.Name + 
                        ", count is " + count); 
      count++; 
    } while(count < 10); 
 
    Console.WriteLine(thrd.Name + " terminating."); 
  } 
} 
 
class MoreThreads { 
  public static void Main() { 
    Console.WriteLine("Main thread starting."); 
 
    // Construct three threads. 
    MyThread mt1 = new MyThread("Child #1"); 
    MyThread mt2 = new MyThread("Child #2"); 
    MyThread mt3 = new MyThread("Child #3"); 
 
    do { 
      Console.Write("."); 
      Thread.Sleep(100); 
    } while (mt1.count < 10 || 
             mt2.count < 10 || 
             mt3.count < 10); 
 
    Console.WriteLine("Main thread ending."); 
  } 
}

#endif

#if IsAlive
class MyThread { 
  public int count; 
  public Thread thrd; 
 
  public MyThread(string name) { 
    count = 0; 
    thrd = new Thread(this.run); 
    thrd.Name = name; 
    thrd.Start(); 
  } 
 
  // Entry point of thread. 
  void run() { 
    Console.WriteLine(thrd.Name + " starting."); 
 
    do { 
      Thread.Sleep(500); 
      Console.WriteLine("In " + thrd.Name + 
                        ", count is " + count); 
      count++; 
    } while(count < 10); 
 
    Console.WriteLine(thrd.Name + " terminating."); 
  } 
} 
// Use IsAlive to wait for threads to end. 
class MoreThreads { 
  public static void Main() { 
    Console.WriteLine("Main thread starting."); 
 
    // Construct three threads. 
    MyThread mt1 = new MyThread("Child #1"); 
    MyThread mt2 = new MyThread("Child #2"); 
    MyThread mt3 = new MyThread("Child #3"); 
 
    do { 
      Console.Write("."); 
      Thread.Sleep(100); 
    } while (mt1.thrd.IsAlive && 
             mt2.thrd.IsAlive && 
             mt3.thrd.IsAlive); 
 
    Console.WriteLine("Main thread ending."); 
  } 
}

#endif

#if Join
// Use Join(). 
 
class MyThread { 
  public int count; 
  public Thread thrd; 
 
  public MyThread(string name) { 
    count = 0; 
    thrd = new Thread(this.run); 
    thrd.Name = name; 
    thrd.Start(); 
  } 
 
  // Entry point of thread. 
  void run() { 
    Console.WriteLine(thrd.Name + " starting."); 
 
    do { 
      Thread.Sleep(500); 
      Console.WriteLine("In " + thrd.Name + 
                        ", count is " + count); 
      count++; 
    } while(count < 10); 
 
    Console.WriteLine(thrd.Name + " terminating."); 
  } 
} 
 
// Use Join() to wait for threads to end. 
class JoinThreads { 
  public static void Main() { 
    Console.WriteLine("Main thread starting."); 
 
    // Construct three threads. 
    MyThread mt1 = new MyThread("Child #1"); 
    MyThread mt2 = new MyThread("Child #2"); 
    MyThread mt3 = new MyThread("Child #3"); 
 
    mt1.thrd.Join(); 
    Console.WriteLine("Child #1 joined."); 
 
    mt2.thrd.Join(); 
    Console.WriteLine("Child #2 joined."); 
 
    mt3.thrd.Join(); 
    Console.WriteLine("Child #3 joined."); 
 
    Console.WriteLine("Main thread ending."); 
  } 
}

#endif

#if PassArgumentToThread
// Passing an argument to the thread method. 
   
class MyThread {  
  public int count;  
  public Thread thrd;  
 
  // Notice that MyThread is also pass an int value. 
  public MyThread(string name, int num) {  
    count = 0;  
 
    // Explicitly invoke ParameterizedThreadStart constructor 
    // for the sake of illustration. 
    thrd = new Thread(new ParameterizedThreadStart(this.run)); 
 
    thrd.Name = name; 
 
     // Here, Start() is passed num as an argument. 
    thrd.Start(num);  
  }  
  
  // Notice that this version of run() has 
  // a parameter of type object. 
  void run(object num) {  
    Console.WriteLine(thrd.Name + 
                      " starting with count of " + num);  
  
    do {  
      Thread.Sleep(500);  
      Console.WriteLine("In " + thrd.Name +  
                        ", count is " + count);  
      count++;  
    } while(count < (int) num);  
  
    Console.WriteLine(thrd.Name + " terminating.");  
  }  
}  
  
class PassArgDemo {  
  public static void Main() {  
 
    // Notice that the iteration count is passed 
    // to these two MyThread objects. 
    MyThread mt = new MyThread("Child #1", 5);  
    MyThread mt2 = new MyThread("Child #1", 3);  
  
    do {  
      Thread.Sleep(100);  
    } while (mt.thrd.IsAlive | mt2.thrd.IsAlive);  
  
    Console.WriteLine("Main thread ending.");  
  }  
}

#endif

#if ThreadPriorities
// Demonstrate thread priorities. 
class MyThread { 
  public int count; 
  public Thread thrd; 
 
  static bool stop = false; 
  static string currentName; 
 
   // Construct a new thread. Notice that this   constructor does not actually start the 
   //  threads running. 
  public MyThread(string name) { 
    count = 0; 
    thrd = new Thread(this.run); 
    thrd.Name = name; 
    currentName = name; 
  } 
 
  // Begin execution of new thread. 
  void run() { 
    Console.WriteLine(thrd.Name + " starting."); 
    do { 
      count++; 
 
      if(currentName != thrd.Name) { 
        currentName = thrd.Name; 
        Console.WriteLine("In " + currentName); 
      } 
 
    } while(stop == false && count < 1000000000); 
    stop = true; 
 
    Console.WriteLine(thrd.Name + " terminating."); 
  } 
} 
 
class PriorityDemo { 
  public static void Main() { 
    MyThread mt1 = new MyThread("High Priority"); 
    MyThread mt2 = new MyThread("Low Priority"); 
 
    // Set the priorities. 
    mt1.thrd.Priority = ThreadPriority.AboveNormal; 
    mt2.thrd.Priority = ThreadPriority.BelowNormal; 
 
    // Start the threads. 
    mt1.thrd.Start(); 
    mt2.thrd.Start(); 
 
    mt1.thrd.Join(); 
    mt2.thrd.Join(); 
 
    Console.WriteLine(); 
    Console.WriteLine(mt1.thrd.Name + " thread counted to " + 
                      mt1.count); 
    Console.WriteLine(mt2.thrd.Name + " thread counted to " + 
                      mt2.count); 
  } 
}

#endif

#if Lock
// Use lock to synchronize access to an object.  
class SumArray {  
  int sum;  
  
  public int sumIt(int[] nums) {  
    lock(this) { // lock the entire method 
      sum = 0; // reset sum  
    
      for(int i=0; i < nums.Length; i++) {  
        sum += nums[i];  
        Console.WriteLine("Running total for " +  
               Thread.CurrentThread.Name +  
               " is " + sum);  
        Thread.Sleep(10); // allow task-switch  
      }  
      return sum; 
    } 
  }  
}   
  
class MyThread {  
  public Thread thrd;  
  int[] a;  
  int answer; 
 
  // Create one SumArray object for all instances of MyThread. 
  static SumArray sa = new SumArray();  
 
  // Construct a new thread.  
  public MyThread(string name, int[] nums) {  
    a = nums;  
    thrd = new Thread(this.run); 
    thrd.Name = name; 
    thrd.Start(); // start the thread  
  }  
  
  // Begin execution of new thread.  
  void run() {  
    Console.WriteLine(thrd.Name + " starting.");  
  
    answer = sa.sumIt(a);           
 
    Console.WriteLine("Sum for " + thrd.Name +  
                       " is " + answer);  
  
    Console.WriteLine(thrd.Name + " terminating.");  
  }  
}  
  
class Sync {  
  public static void Main() {  
    int[] a = {1, 2, 3, 4, 5};  
  
    MyThread mt1 = new MyThread("Child #1", a);  
    MyThread mt2 = new MyThread("Child #2", a);  
  
    mt1.thrd.Join();  
    mt2.thrd.Join();  
  }  
}
#endif

#if AnotherWayOfLocking
// Another way to use lock to synchronize access to an object.  
class SumArray {  
  int sum;  
  
  public int sumIt(int[] nums) {  
    sum = 0; // reset sum  
  
    for(int i=0; i < nums.Length; i++) {  
      sum += nums[i];  
      Console.WriteLine("Running total for " +  
             Thread.CurrentThread.Name +  
             " is " + sum);  
      Thread.Sleep(10); // allow task-switch  
    }  
    return sum; 
  }  
}   
  
class MyThread {  
  public Thread thrd;  
  int[] a;  
  int answer; 
 
  // Create one SumArray object for all instances of MyThread. 
  static SumArray sa = new SumArray();  
 
  // Construct a new thread.  
  public MyThread(string name, int[] nums) {  
    a = nums;  
    thrd = new Thread(this.run); 
    thrd.Name = name; 
    thrd.Start(); // start the thread  
  }  
  
  // Begin execution of new thread.  
  void run() {  
    Console.WriteLine(thrd.Name + " starting.");  
  
    // Lock calls to sumIt().  
    lock(sa) answer = sa.sumIt(a); 
 
    Console.WriteLine("Sum for " + thrd.Name +  
                       " is " + answer);  
  
    Console.WriteLine(thrd.Name + " terminating.");  
  }  
}  
  
class Sync {  
  public static void Main() {  
    int[] a = {1, 2, 3, 4, 5};  
  
    MyThread mt1 = new MyThread("Child #1", a);  
    MyThread mt2 = new MyThread("Child #2", a);  
  
    mt1.thrd.Join();  
    mt2.thrd.Join();  
  }  
}
#endif

#if WaitPulse
// Use Wait() and Pulse() to create a ticking clock. 
 
class TickTock { 
 
  public void tick(bool running) { 
    lock(this) { 
      if(!running) { // stop the clock 
        Monitor.Pulse(this); // notify any waiting threads 
        return; 
      } 
 
      Console.Write("Tick "); 
      Monitor.Pulse(this); // let tock() run 
   
      Monitor.Wait(this); // wait for tock() to complete 
    } 
  } 
 
  public void tock(bool running) { 
    lock(this) { 
      if(!running) { // stop the clock 
        Monitor.Pulse(this); // notify any waiting threads 
        return; 
      } 
 
      Console.WriteLine("Tock"); 
      Monitor.Pulse(this); // let tick() run 
 
      Monitor.Wait(this); // wait for tick() to complete 
    } 
  } 
}  

class MyThread { 
  public Thread thrd; 
  TickTock ttOb; 
 
  // Construct a new thread. 
  public MyThread(string name, TickTock tt) { 
    thrd = new Thread(this.run); 
    ttOb = tt; 
    thrd.Name = name; 
    thrd.Start();  
  } 
 
  // Begin execution of new thread. 
  void run() { 
    if(thrd.Name == "Tick") { 
      for(int i=0; i<5; i++) ttOb.tick(true); 
      ttOb.tick(false); 
    } 
    else { 
      for(int i=0; i<5; i++) ttOb.tock(true); 
      ttOb.tock(false); 
    } 
  } 
} 
 
class TickingClock { 
  public static void Main() { 
    TickTock tt = new TickTock(); 
    MyThread mt1 = new MyThread("Tick", tt); 
    MyThread mt2 = new MyThread("Tock", tt); 
 
    mt1.thrd.Join(); 
    mt2.thrd.Join(); 
    Console.WriteLine("Clock Stopped"); 
  } 
}

#endif

#if WrongNoWaitPulse
// A non-functional version of TickTock. 
class TickTock { 
 
  public void tick(bool running) { 
    lock(this) { 
      if(!running) { // stop the clock 
        return; 
      } 
 
      Console.Write("Tick "); 
    } 
  } 
 
  public void tock(bool running) { 
    lock(this) { 
      if(!running) { // stop the clock 
        return; 
      } 
 
      Console.WriteLine("Tock"); 
    } 
  } 
}

public void tock(bool running) { 
    lock(this) { 
      if(!running) { // stop the clock 
        Monitor.Pulse(this); // notify any waiting threads 
        return; 
      } 
 
      Console.WriteLine("Tock"); 
      Monitor.Pulse(this); // let tick() run 
 
      Monitor.Wait(this); // wait for tick() to complete 
    } 
  } 
}  

class MyThread { 
  public Thread thrd; 
  TickTock ttOb; 
 
  // Construct a new thread. 
  public MyThread(string name, TickTock tt) { 
    thrd = new Thread(this.run); 
    ttOb = tt; 
    thrd.Name = name; 
    thrd.Start();  
  } 
 
  // Begin execution of new thread. 
  void run() { 
    if(thrd.Name == "Tick") { 
      for(int i=0; i<5; i++) ttOb.tick(true); 
      ttOb.tick(false); 
    } 
    else { 
      for(int i=0; i<5; i++) ttOb.tock(true); 
      ttOb.tock(false); 
    } 
  } 
} 
 
class TickingClock { 
  public static void Main() { 
    TickTock tt = new TickTock(); 
    MyThread mt1 = new MyThread("Tick", tt); 
    MyThread mt2 = new MyThread("Tock", tt); 
 
    mt1.thrd.Join(); 
    mt2.thrd.Join(); 
    Console.WriteLine("Clock Stopped"); 
  } 
}
#endif

#if LockWithAttribute
// Use MethodImplAttribute to synchronize a method. 
  
using System.Runtime.CompilerServices; 
 
// Rewrite of TickTock to use MethodImplOptions.Synchronized. 
class TickTock { 
 
  // The following attribute synchronizes the entire  tick() method. 
  [MethodImplAttribute(MethodImplOptions.Synchronized)] 
  public void tick(bool running) { 
    if(!running) { // stop the clock 
      Monitor.Pulse(this); // notify any waiting threads 
      return; 
    } 
 
    Console.Write("Tick "); 
    Monitor.Pulse(this); // let tock() run 
   
    Monitor.Wait(this); // wait for tock() to complete 
  } 
 
 
  // The following attribute synchronizes the entire  tock() method. 
  [MethodImplAttribute(MethodImplOptions.Synchronized)] 
  public void tock(bool running) { 
    if(!running) { // stop the clock 
      Monitor.Pulse(this); // notify any waiting threads 
      return; 
    } 
 
    Console.WriteLine("Tock"); 
    Monitor.Pulse(this); // let tick() run 
 
    Monitor.Wait(this); // wait for tick() to complete 
  } 
}  
 
class MyThread { 
  public Thread thrd; 
  TickTock ttOb; 
 
  // Construct a new thread. 
  public MyThread(string name, TickTock tt) { 
    thrd = new Thread(this.run); 
    ttOb = tt; 
    thrd.Name = name; 
    thrd.Start();  
  } 
 
  // Begin execution of new thread. 
  void run() { 
    if(thrd.Name == "Tick") { 
      for(int i=0; i<5; i++) ttOb.tick(true); 
      ttOb.tick(false); 
    } 
    else { 
      for(int i=0; i<5; i++) ttOb.tock(true); 
      ttOb.tock(false); 
    } 
  } 
} 
 
class TickingClock { 
  public static void Main() { 
    TickTock tt = new TickTock(); 
    MyThread mt1 = new MyThread("Tick", tt); 
    MyThread mt2 = new MyThread("Tock", tt); 
 
    mt1.thrd.Join(); 
    mt2.thrd.Join(); 
    Console.WriteLine("Clock Stopped"); 
  } 
}

#endif

#if Mutex
// Use a Mutex. 
// This class contains a shared resource (count), 
// and a mutex (mtx) to control access to it.  
class SharedRes { 
  public static int count = 0; 
  public static Mutex mtx = new Mutex(); 
} 
 
// This thread increments SharedRes.count. 
class IncThread {  
  int num; 
  public Thread thrd;  
  
  public IncThread(string name, int n) {  
    thrd = new Thread(this.run);  
    num = n; 
    thrd.Name = name;  
    thrd.Start();  
  }  
  
  // Entry point of thread.  
  void run() {  
 
    Console.WriteLine(thrd.Name + " is waiting for the mutex."); 
 
    // Acquire the Mutex. 
    SharedRes.mtx.WaitOne(); 
 
    Console.WriteLine(thrd.Name + " acquires the mutex."); 
 
    do {  
      Thread.Sleep(500);  
      SharedRes.count++;  
      Console.WriteLine("In " + thrd.Name +  
                        ", SharedRes.count is " + SharedRes.count);  
      num--; 
    } while(num > 0);  
  
    Console.WriteLine(thrd.Name + " releases the mutex.");   
 
    // Release the Mutex. 
    SharedRes.mtx.ReleaseMutex(); 
  }  
}  
 
// This thread decrements SharedRes.count. 
class DecThread {  
  int num; 
  public Thread thrd;  
  
  public DecThread(string name, int n) {  
    thrd = new Thread(new ThreadStart(this.run));  
    num = n; 
    thrd.Name = name;  
    thrd.Start();  
  }  
  
  // Entry point of thread.  
  void run() {  
 
    Console.WriteLine(thrd.Name + " is waiting for the mutex."); 
 
    // Acquire the Mutex. 
    SharedRes.mtx.WaitOne(); 
 
    Console.WriteLine(thrd.Name + " acquires the mutex."); 
 
    do {  
      Thread.Sleep(500);  
      SharedRes.count--;  
      Console.WriteLine("In " + thrd.Name +  
                        ", SharedRes.count is " + SharedRes.count);  
      num--; 
    } while(num > 0);  
  
    Console.WriteLine(thrd.Name + " releases the mutex.");  
 
    // Release the Mutex. 
    SharedRes.mtx.ReleaseMutex(); 
  }  
}  
  
class MutexDemo {  
  public static void Main() {  
 
    // Construct three threads.  
    IncThread mt1 = new IncThread("Increment Thread", 5);  
    DecThread mt2 = new DecThread("Decrement Thread", 5);  
  
    mt1.thrd.Join(); 
    mt2.thrd.Join(); 
  }  
}

#endif

#if Semaphore
// Use a Semaphore 
 
// This thread allows only two instances of itself 
// to run at any one time. 
class MyThread {  
  public Thread thrd; 
 
  // This creates a semaphore that allows up to 2 
  // permits to be granted and that initially has 
  // two permits available. 
  static Semaphore sem = new Semaphore(2, 2); 
  
  public MyThread(string name) {  
    thrd = new Thread(this.run);  
    thrd.Name = name;  
    thrd.Start();  
  }  
  
  // Entry point of thread.  
  void run() {  
 
    Console.WriteLine(thrd.Name + " is waiting for a permit."); 
 
    sem.WaitOne(); 
 
    Console.WriteLine(thrd.Name + " acquires a permit."); 
 
    for(char ch='A'; ch < 'D'; ch++) { 
      Console.WriteLine(thrd.Name + " : " + ch + " "); 
      Thread.Sleep(500);  
    } 
  
    Console.WriteLine(thrd.Name + " releases a permit."); 
 
    // Release the semaphore. 
    sem.Release(); 
  }  
}  
 
  
class SemaphoreDemo {  
  public static void Main() {  
 
    // Construct three threads.  
    MyThread mt1 = new MyThread("Thread #1");  
    MyThread mt2 = new MyThread("Thread #2");  
    MyThread mt3 = new MyThread("Thread #3");  
  
    mt1.thrd.Join(); 
    mt2.thrd.Join(); 
    mt3.thrd.Join(); 
  }  
}

#endif

#if ManualEvent
// Use a manual event object.  
  
// This thread signals the event passed to its constructor.  
class MyThread {   
  public Thread thrd;  
  ManualResetEvent mre;  
   
  public MyThread(string name, ManualResetEvent evt) {   
    thrd = new Thread(this.run);   
    thrd.Name = name;  
    mre = evt;  
    thrd.Start();   
  }   
   
  // Entry point of thread.   
  void run() {   
    Console.WriteLine("Inside thread " + thrd.Name);  
  
    for(int i=0; i<5; i++) {  
      Console.WriteLine(thrd.Name);  
      Thread.Sleep(500);  
    }  
  
    Console.WriteLine(thrd.Name + " Done!");  
  
    // Signal the event.
    mre.Set();
  }   
}   
   
class ManualEventDemo {   
  public static void Main() {   
    ManualResetEvent evtObj = new ManualResetEvent(false);  
  
    MyThread mt1 = new MyThread("Event Thread 1", evtObj);   

    Console.WriteLine("Main thread waiting for event.");

    // Wait for signaled event.
    evtObj.WaitOne();

    Console.WriteLine("Main thread received first event.");


    // Reset the event.
    evtObj.Reset(); 


    mt1 = new MyThread("Event Thread 2", evtObj);   

    // Wait for signaled event.
    evtObj.WaitOne();

    Console.WriteLine("Main thread received second event.");

  }   
}

#endif

#if Interlocked
// Use Interlocked operations. 
  
// A shared resource. 
class SharedRes { 
  public static int count = 0; 
} 
 
// This thread increments SharedRes.count. 
class IncThread {  
  public Thread thrd; 
  
  public IncThread(string name) {  
    thrd = new Thread(this.run);  
    thrd.Name = name; 
    thrd.Start();  
  }  
  
  // Entry point of thread.  
  void run() {  
 
    for(int i=0; i<5; i++) { 
      Interlocked.Increment(ref SharedRes.count); 
      Console.WriteLine(thrd.Name + " count is " + SharedRes.count); 
    } 
  }  
}  
 
// This thread decrements SharedRes.count. 
class DecThread {  
  public Thread thrd; 
  
  public DecThread(string name) {  
    thrd = new Thread(this.run);  
    thrd.Name = name; 
    thrd.Start();  
  }  
  
  // Entry point of thread.  
  void run() {  
 
    for(int i=0; i<5; i++) { 
      Interlocked.Decrement(ref SharedRes.count); 
      Console.WriteLine(thrd.Name + " count is " + SharedRes.count); 
    } 
  }  
}  
  
class InterdlockedDemo {  
  public static void Main() {  
 
    // Construct two threads.  
    IncThread mt1 = new IncThread("Increment Thread");  
    DecThread mt2 = new DecThread("Decrement Thread");  
  
    mt1.thrd.Join(); 
    mt2.thrd.Join(); 
  }  
}

#endif

#if StoppingThread
// Stopping a thread. 
 
class MyThread {  
  public Thread thrd;  
    
  public MyThread(string name) {  
    thrd = new Thread(this.run); 
    thrd.Name = name; 
    thrd.Start();  
  }  
  
  // This is the entry point for thread.  
  void run() {  
    Console.WriteLine(thrd.Name + " starting."); 
 
    for(int i = 1; i <= 1000; i++) {  
      Console.Write(i + " ");  
      if((i%10)==0) { 
        Console.WriteLine(); 
        Thread.Sleep(250); 
      } 
    } 
    Console.WriteLine(thrd.Name + " exiting.");  
  }  
} 
  
class StopDemo {  
  public static void Main() {  
    MyThread mt1 = new MyThread("My Thread");  
 
    Thread.Sleep(1000); // let child thread start executing 
  
    Console.WriteLine("Stopping thread.");  
    mt1.thrd.Abort(); 
 
    mt1.thrd.Join(); // wait for thread to terminate 
 
    Console.WriteLine("Main thread terminating.");  
  }  
}

#endif

#if AbortWithParameter
// Using Abort(object). 
 
class MyThread {  
  public Thread thrd;  
    
  public MyThread(string name) {  
    thrd = new Thread(this.run); 
    thrd.Name = name; 
    thrd.Start();  
  }  
  
  // This is the entry point for thread.  
  void run() {  
    try { 
      Console.WriteLine(thrd.Name + " starting."); 
 
      for(int i = 1; i <= 1000; i++) {  
        Console.Write(i + " ");  
        if((i%10)==0) { 
          Console.WriteLine(); 
          Thread.Sleep(250); 
        } 
      } 
      Console.WriteLine(thrd.Name + " exiting normally.");  
    } catch(ThreadAbortException exc) { 
      Console.WriteLine("Thread aborting, code is " + 
                         exc.ExceptionState); 
    } 
  }  
} 
  
class UseAltAbort {  
  public static void Main() {  
    MyThread mt1 = new MyThread("My Thread");  
 
    Thread.Sleep(1000); // let child thread start executing 
 
    Console.WriteLine("Stopping thread.");  
    mt1.thrd.Abort(100); 
 
    mt1.thrd.Join(); // wait for thread to terminate 
 
    Console.WriteLine("Main thread terminating.");  
  }  
}

#endif

#if ResetAbort
// Using ResetAbort(). 
class MyThread {  
  public Thread thrd;  
    
  public MyThread(string name) {  
    thrd = new Thread(this.run); 
    thrd.Name = name; 
    thrd.Start();  
  }  
  
  // This is the entry point for thread.  
  void run() {  
    Console.WriteLine(thrd.Name + " starting."); 
 
    for(int i = 1; i <= 1000; i++) {  
      try { 
        Console.Write(i + " ");  
        if((i%10)==0) { 
          Console.WriteLine(); 
          Thread.Sleep(250); 
        } 
      } catch(ThreadAbortException exc) { 
        if((int)exc.ExceptionState == 0) { 
          Console.WriteLine("Abort Cancelled! Code is " + 
                             exc.ExceptionState); 
          Thread.ResetAbort(); 
        } 
        else  
          Console.WriteLine("Thread aborting, code is " + 
                             exc.ExceptionState); 
      } 
    } 
    Console.WriteLine(thrd.Name + " exiting normally.");  
  } 
} 
  
class ResetAbort {  
  public static void Main() {  
    MyThread mt1 = new MyThread("My Thread");  
 
    Thread.Sleep(1000); // let child thread start executing 
 
    Console.WriteLine("Stopping thread.");  
    mt1.thrd.Abort(0); // this won't stop the thread 
 
    Thread.Sleep(1000); // let child execute a bit longer 
 
    Console.WriteLine("Stopping thread.");  
    mt1.thrd.Abort(100); // this will stop the thread 
 
    mt1.thrd.Join(); // wait for thread to terminate 
 
    Console.WriteLine("Main thread terminating.");  
  }  
}

#endif

#if CurrentThread
// Control the main thread. 
class UseMain { 
  public static void Main() { 
    Thread thrd; 
 
    // Get the main thread. 
    thrd = Thread.CurrentThread; 
 
    // Display main thread's name. 
    if(thrd.Name == null) 
      Console.WriteLine("Main thread has no name."); 
    else 
      Console.WriteLine("Main thread is called: " + thrd.Name); 
 
    // Display main thread's priority. 
    Console.WriteLine("Priority: " + thrd.Priority); 
 
    Console.WriteLine(); 
 
    // Set the name and priority. 
    Console.WriteLine("Setting name and priority.\n"); 
    thrd.Name = "Main Thread"; 
    thrd.Priority = ThreadPriority.AboveNormal; 
 
    Console.WriteLine("Main thread is now called: " + 
                       thrd.Name); 
 
    Console.WriteLine("Priority is now: " + 
                       thrd.Priority); 
  } 
}

#endif

#if StartProcess
// Starting a new process. 
 
using System.Diagnostics; 
 
class StartProcess {  
  public static void Main() {  
    Process newProc = Process.Start("wordpad.exe"); 
 
    Console.WriteLine("New process started."); 
 
    newProc.WaitForExit(); 
 
    newProc.Close(); // free resources 
 
    Console.WriteLine("New process ended."); 
  }  
}

#endif
}

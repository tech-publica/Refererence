
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Refererence.Refe12_IO
{

#if ReadCharacterFromKeyBoard
 
// Read a character from the keyboard. 
 
class KbIn {   
  public static void Main() { 
    char ch;
    Console.Write("Press a key followed by ENTER: "); 
 
    ch = (char) Console.Read(); // get a char 
    
    Console.WriteLine("Your key is: " + ch); 
  }   
}
#endif

#if ReadLineFromKeyBoard

// Input from the console using ReadLine(). 
 
using System;  
  
class ReadString { 
  public static void Main() { 
    string str; 
 
    Console.WriteLine("Enter some characters."); 
    str = Console.ReadLine(); 
    Console.WriteLine("You entered: " + str); 
  } 
}
#endif

#if UsingConsoleIn
// Read a string from the keyboard, using Console.In directly.  
 
class ReadChars2 { 
  public static void Main() { 
    string str; 
 
    Console.WriteLine("Enter some characters."); 
 
    str = Console.In.ReadLine(); // call TextReader's ReadLine() method 
 
    Console.WriteLine("You entered: " + str); 
  } 
}

#endif

#if ReadKeyBoardNonBuffered
// Read keystrokes from the console by 
// using ReadKey(). 
  

class ReadKeys {    
  public static void Main() {  
    ConsoleKeyInfo keypress; 
  
    Console.WriteLine("Enter keystrokes. Enter Q to stop."); 
  
    do { 
      keypress = Console.ReadKey(); // read keystrokes 
     
      Console.WriteLine(" Your key is: " + keypress.KeyChar);  
 
      // Check for modifier keys. 
      if((ConsoleModifiers.Alt & keypress.Modifiers) != 0) 
        Console.WriteLine("Alt key pressed."); 
      if((ConsoleModifiers.Control & keypress.Modifiers) != 0) 
        Console.WriteLine("Control key pressed."); 
      if((ConsoleModifiers.Shift & keypress.Modifiers) != 0) 
        Console.WriteLine("Shift key pressed."); 
 
    } while(keypress.KeyChar != 'Q'); 
  }    
}
#endif

#if ConsoleOutErr
// Write to Console.Out and Console.Error. 
 
using System; 
 
class ErrOut { 
  public static void Main() { 
    int a=10, b=0; 
    int result; 
 
    Console.Out.WriteLine("This will generate an exception."); 
    try { 
      result = a / b; // generate an exception 
    } catch(DivideByZeroException exc) { 
      Console.Error.WriteLine(exc.Message); 
    } 
  } 
}
#endif

#if ShowFile

/* Display a text file. 
 
   To use this program, specify the name  
   of the file that you want to see. 
   For example, to see a file called TEST.CS, 
   use the following command line. 
 
   ShowFile TEST.CS 
*/ 
 
class ShowFile { 
  public static void Main(string[] args) { 
    int i; 
    FileStream fin; 
 
    try { 
      fin = new FileStream(args[0], FileMode.Open); 
    } catch(FileNotFoundException exc) { 
      Console.WriteLine(exc.Message); 
      return; 
    } catch(IndexOutOfRangeException exc) { 
      Console.WriteLine(exc.Message + "\nUsage: ShowFile File"); 
      return; 
    } 
 
    // read bytes until EOF is encountered 
    do { 
      try { 
        i = fin.ReadByte(); 
      } catch(Exception exc) { 
        Console.WriteLine(exc.Message); 
        return; 
      } 
      if(i != -1) Console.Write((char) i); 
    } while(i != -1); 
 
    fin.Close(); 
  } 
}

#endif

#if WriteToFile
// Write to a file.  
 
class WriteToFile { 
  public static void Main(string[] args) { 
    FileStream fout; 
 
    // open output file 
    try { 
      fout = new FileStream("test.txt", FileMode.Create); 
    } catch(IOException exc) { 
      Console.WriteLine(exc.Message + "\nError Opening Output File"); 
      return; 
    } 
 
    // Write the alphabet to the file. 
    try { 
      for(char c = 'A'; c <= 'Z'; c++) 
        fout.WriteByte((byte) c); 
    } catch(IOException exc) { 
      Console.WriteLine(exc.Message + "File Error"); 
    } 
 
    fout.Close(); 
  } 
}

#endif

#if CopyFile
/* Copy a file. 
 
   To use this program, specify the name  
   of the source file and the destination file. 
   For example, to copy a file called FIRST.DAT 
   to a file called SECOND.DAT, use the following 
   command line. 
 
   CopyFile FIRST.DAT SECOND.DAT 
*/ 
 
class CopyFile { 
  public static void Main(string[] args) { 
    int i; 
    FileStream fin; 
    FileStream fout; 
 
    try { 
      // open input file 
      try { 
        fin = new FileStream(args[0], FileMode.Open); 
      } catch(FileNotFoundException exc) { 
        Console.WriteLine(exc.Message + "\nInput File Not Found"); 
        return; 
      } 
 
      // open output file 
      try { 
        fout = new FileStream(args[1], FileMode.Create); 
      } catch(IOException exc) { 
        Console.WriteLine(exc.Message + "\nError Opening Output File"); 
        return; 
      } 
    } catch(IndexOutOfRangeException exc) { 
      Console.WriteLine(exc.Message + "\nUsage: CopyFile From To"); 
      return; 
    } 
 
    // Copy File 
    try { 
      do { 
        i = fin.ReadByte(); 
        if(i != -1) fout.WriteByte((byte)i); 
      } while(i != -1); 
    } catch(IOException exc) { 
      Console.WriteLine(exc.Message + "File Error"); 
    } 
 
    fin.Close(); 
    fout.Close(); 
  } 
}

#endif

#if KeyToDisk0
/* A simple key-to-disk utility that 
   demonstrates a StreamWriter. */ 
 
class KtoD { 
  public static void Main() { 
    string str; 
    FileStream fout; 
 
    try { 
      fout = new FileStream("test.txt", FileMode.Create); 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message + "Cannot open file."); 
      return ; 
    } 
    StreamWriter fstr_out = new StreamWriter(fout); 
 
    Console.WriteLine("Enter text ('stop' to quit)."); 
    do { 
      Console.Write(": "); 
      str = Console.ReadLine(); 
 
      if(str != "stop") { 
        str = str + "\r\n"; // add newline 
        try { 
          fstr_out.Write(str); 
        } catch(IOException exc) { 
          Console.WriteLine(exc.Message + "File Error"); 
          return ; 
        } 
      } 
    } while(str != "stop"); 
 
    fstr_out.Close(); 
  } 
}

#endif

#if KeyToDisk1


// Open a file using StreamWriter.  
 
class KtoD { 
  public static void Main() { 
    string str; 
    StreamWriter fstr_out; 
 
    // Open the file directly using StreamWriter. 
    try { 
      fstr_out = new StreamWriter("test.txt"); 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message + "Cannot open file."); 
      return ; 
    } 
 
    Console.WriteLine("Enter text ('stop' to quit)."); 
    do { 
      Console.Write(": "); 
      str = Console.ReadLine(); 
 
      if(str != "stop") { 
        str = str + "\r\n"; // add newline 
        try { 
          fstr_out.Write(str); 
        } catch(IOException exc) { 
          Console.WriteLine(exc.Message + "File Error"); 
          return ; 
        } 
      } 
    } while(str != "stop"); 
 
    fstr_out.Close(); 
  } 
}

#endif

#if DiskToString
/* A simple disk-to-screen utility */ 
 
class DtoS { 
  public static void Main() { 
    FileStream fin; 
    string s; 
 
    try { 
      fin = new FileStream("test.txt", FileMode.Open); 
    } 
    catch(FileNotFoundException exc) { 
      Console.WriteLine(exc.Message + "Cannot open file."); 
      return ; 
    }  
 
    StreamReader fstr_in = new StreamReader(fin); 
 
    // Read the file line-by-line. 
    while((s = fstr_in.ReadLine()) != null) { 
      Console.WriteLine(s); 
    } 
 
    fstr_in.Close(); 
  } 
}

#endif

#if RedirectOut

// Redirect Console.Out. 
 
using System;  
using System.IO; 
  
class Redirect { 
  public static void Main() { 
    StreamWriter log_out; 
 
    try { 
      log_out = new StreamWriter("logfile.txt"); 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message + "Cannot open file."); 
      return ; 
    } 
    
    // Direct standard output to the log file. 
    Console.SetOut(log_out); 
    Console.WriteLine("This is the start of the log file."); 
 
    for(int i=0; i<10; i++) Console.WriteLine(i); 
 
    Console.WriteLine("This is the end of the log file."); 
    log_out.Close(); 
  } 
}

#endif

#if ReadWriteBinary
// Write and then read back binary data. 
 
class RWData { 
  public static void Main() { 
    BinaryWriter dataOut; 
    BinaryReader dataIn; 
 
    int i = 10; 
    double d = 1023.56; 
    bool b = true; 
 
    try { 
      dataOut = new 
        BinaryWriter(new FileStream("testdata", FileMode.Create)); 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message + "\nCannot open file."); 
      return; 
    } 
 
    try { 
      Console.WriteLine("Writing " + i); 
      dataOut.Write(i);  
 
      Console.WriteLine("Writing " + d); 
      dataOut.Write(d); 
 
      Console.WriteLine("Writing " + b); 
      dataOut.Write(b); 
 
      Console.WriteLine("Writing " + 12.2 * 7.4); 
      dataOut.Write(12.2 * 7.4); 
 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message + "\nWrite error."); 
    } 
 
    dataOut.Close(); 
 
    Console.WriteLine(); 
 
    // Now, read them back. 
    try { 
      dataIn = new 
          BinaryReader(new FileStream("testdata", FileMode.Open)); 
    } 
    catch(FileNotFoundException exc) { 
      Console.WriteLine(exc.Message + "\nCannot open file."); 
      return; 
    } 
 
    try { 
      i = dataIn.ReadInt32(); 
      Console.WriteLine("Reading " + i); 
 
      d = dataIn.ReadDouble(); 
      Console.WriteLine("Reading " + d); 
 
      b = dataIn.ReadBoolean(); 
      Console.WriteLine("Reading " + b); 
 
      d = dataIn.ReadDouble(); 
      Console.WriteLine("Reading " + d); 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message + "Read error."); 
    } 
 
    dataIn.Close();  
  } 
}

#endif

#if BinaryInventory

/* Use BinaryReader and BinaryWriter to implement 
   a simple inventory program. */ 
 
class Inventory { 
  public static void Main() { 
    BinaryWriter dataOut; 
    BinaryReader dataIn; 
 
    string item; // name of item 
    int onhand;  // number on hand 
    double cost; // cost 
 
    try { 
      dataOut = new 
        BinaryWriter(new FileStream("inventory.dat", 
                                    FileMode.Create)); 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message + "\nCannot open file."); 
      return; 
    } 
 
    // Write some inventory data to the file. 
    try { 
      dataOut.Write("Hammers");  
      dataOut.Write(10); 
      dataOut.Write(3.95); 
 
      dataOut.Write("Screwdrivers");  
      dataOut.Write(18); 
      dataOut.Write(1.50); 
 
      dataOut.Write("Pliers");  
      dataOut.Write(5); 
      dataOut.Write(4.95); 
 
      dataOut.Write("Saws");  
      dataOut.Write(8); 
      dataOut.Write(8.95); 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message + "\nWrite error."); 
    } 
 
    dataOut.Close(); 
 
    Console.WriteLine(); 
 
    // Now, open inventory file for reading. 
    try { 
      dataIn = new 
          BinaryReader(new FileStream("inventory.dat", 
                       FileMode.Open)); 
    } 
    catch(FileNotFoundException exc) { 
      Console.WriteLine(exc.Message + "\nCannot open file."); 
      return; 
    } 
 
    // Lookup item entered by user. 
    Console.Write("Enter item to lookup: "); 
    string what = Console.ReadLine(); 
    Console.WriteLine(); 
 
    try { 
      for(;;) { 
        // Read an inventory entry. 
        item = dataIn.ReadString(); 
        onhand = dataIn.ReadInt32(); 
        cost = dataIn.ReadDouble(); 
 
        /* See if the item matches the one requested. 
           If so, display information */ 
        if(item.CompareTo(what) == 0) { 
          Console.WriteLine(onhand + " " + item + " on hand. " + 
                            "Cost: {0:C} each", cost); 
          Console.WriteLine("Total value of {0}: {1:C}." , 
                            item, cost * onhand); 
          break; 
        } 
      } 
    } 
    catch(EndOfStreamException) { 
      Console.WriteLine("Item not found."); 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message + "Read error."); 
    } 
 
    dataIn.Close();  
  } 
}


#endif

#if FileRandomAccess
// Demonstrate random access. 

class RandomAccessDemo { 
  public static void Main() { 
    FileStream f; 
    char ch; 
 
    try { 
      f = new FileStream("random.dat", FileMode.Create); 
    } 
    catch(IOException exc) { 
      Console.WriteLine(exc.Message); 
      return ; 
    } 
 
    // Write the alphabet.      
    for(int i=0; i < 26; i++) { 
      try { 
        f.WriteByte((byte)('A'+i)); 
      }  
      catch(IOException exc) { 
        Console.WriteLine(exc.Message); 
        return ; 
      } 
    } 
 
    try { 
      // Now, read back specific values 
      f.Seek(0, SeekOrigin.Begin); // seek to first byte 
      ch = (char) f.ReadByte(); 
      Console.WriteLine("First value is " + ch); 
 
      f.Seek(1, SeekOrigin.Begin); // seek to second byte 
      ch = (char) f.ReadByte(); 
      Console.WriteLine("Second value is " + ch); 
 
      f.Seek(4, SeekOrigin.Begin); // seek to 5th byte 
      ch = (char) f.ReadByte(); 
      Console.WriteLine("Fifth value is " + ch); 
 
      Console.WriteLine(); 
 
      // Now, read every other value. 
      Console.WriteLine("Here is every other value: "); 
      for(int i=0; i < 26; i += 2) { 
        f.Seek(i, SeekOrigin.Begin); // seek to ith double 
        ch = (char) f.ReadByte(); 
        Console.Write(ch + " "); 
      } 
    }  
    catch(IOException exc) { 
      Console.WriteLine(exc.Message); 
    } 
  
    Console.WriteLine(); 
    f.Close(); 
  } 
}

#endif

#if MemoryStream

// Demonstrate MemoryStream. 
 
class MemStrDemo {   
  public static void Main() {   
    byte[] storage = new byte[255]; 
 
    // Create a memory-based stream. 
    MemoryStream memstrm = new MemoryStream(storage); 
 
    // Wrap memstrm in a reader and a writer. 
    StreamWriter memwtr = new StreamWriter(memstrm); 
    StreamReader memrdr = new StreamReader(memstrm); 
 
    // Write to storage, through memwtr. 
    for(int i=0; i < 10; i++) 
       memwtr.WriteLine("byte [" + i + "]: " + i); 
 
    // put a period at the end 
    memwtr.WriteLine("."); 
 
    memwtr.Flush(); 
 
    Console.WriteLine("Reading from storage directly: "); 
 
    // Display contents of storage directly. 
    foreach(char ch in storage) { 
      if (ch == '.') break; 
      Console.Write(ch); 
    } 
 
    Console.WriteLine("\nReading through memrdr: "); 
 
    // Read from memstrm using the stream reader. 
    memstrm.Seek(0, SeekOrigin.Begin); // reset file pointer  
 
    string str = memrdr.ReadLine(); 
    while(str != null) { 
      Console.WriteLine(str); 
      str = memrdr.ReadLine(); 
      if(str.CompareTo(".") == 0) break; 
    }  
  }  
}
#endif

#if StringReader
// Demonstrate StringReader and StringWriter 
 
class StrRdrDemo {   
  public static void Main() {   
    // Create a StringWriter 
    StringWriter strwtr = new StringWriter(); 
 
    // Write to StringWriter. 
    for(int i=0; i < 10; i++) 
       strwtr.WriteLine("This is i: " + i); 
 
    // Create a StringReader 
 
    StringReader strrdr = new StringReader(strwtr.ToString()); 
 
    // Now, read from StringReader. 
    string str = strrdr.ReadLine(); 
    while(str != null) { 
      str = strrdr.ReadLine(); 
      Console.WriteLine(str); 
    }  
  
  }  
}

#endif

#if ParseInput
// This program averages a list of numbers entered by the user.  
   
class AvgNums {  
  public static void Main() {  
    string str;  
    int n;  
    double sum = 0.0; 
    double avg, t;  
      
    Console.Write("How many numbers will you enter: ");  
    str = Console.ReadLine(); 
    try { 
      n = Int32.Parse(str); 
    }  
    catch(FormatException exc) { 
      Console.WriteLine(exc.Message); 
      n = 0; 
    } 
    catch(OverflowException exc) { 
      Console.WriteLine(exc.Message); 
      n = 0; 
    } 
    
    Console.WriteLine("Enter " + n + " values."); 
    for(int i=0; i < n ; i++)  {  
      Console.Write(": "); 
      str = Console.ReadLine();  
      try {  
        t = Double.Parse(str);  
      } catch(FormatException exc) {  
        Console.WriteLine(exc.Message);  
        t = 0.0;  
      }  
      catch(OverflowException exc) { 
        Console.WriteLine(exc.Message); 
        t = 0; 
      } 
      sum += t;  
    }  
    avg = sum / n; 
    Console.WriteLine("Average is " + avg); 
  }  
}

#endif
}

using system;

public class Panda
{
	public string name;
	public static int Population;

	public Panda(string n)
	{
		Name = n;
		Population = Population+1;
	}
}

public class UnitCoverter
{
	int ratio;
	public UnitCoverter(int unitRatio) {ratio = unitRatio;}
	public int Convert(int unit){ return unit * ratio;}
}

public struct Point //value instance
{
	public int x, y;
}


public class Point //reference instance
{
	public int x, y;
}

struct A
{
	byte b;
	long l;
}


class Test
{
	static void main()
	{
		int x = 12*30;
		Console.WriteLine(x);
		Console.WriteLine(FeetToInches(200));

		string message = "Hello World";
		string uppermsg = message.ToUpper();
		Console.WriteLine(uppermsg);

		int x = 2015;
		message += x.ToString();
		Console.WriteLine(message);

		//panda
		Panda p1 = new Panda("pan Dee");
		Panda p2 = new Panda("pan dat");

		Console.WriteLine(p1.name);
		Console.WriteLine(p2.name);

		Console.WriteLine(Panda.Population);

		//value instance
		Point p1 = new Point();
		p1.x = 7;

		Point p2 = p1;
		Console.WriteLine(p1.x); //7
		Console.WriteLine(p2.x); //7

		p1.x = 9;
		Console.WriteLine(p1.x); //9
		Console.WriteLine(p2.x); //7 ///*******

		//reference isntance
		Point p1 = new Point();
		p1.x = 7;

		Point p2 = p1;
		Console.WriteLine(p1.x); //7
		Console.WriteLine(p2.x); //7

		p1.x = 9;
		Console.WriteLine(p1.x); //9
		Console.WriteLine(p2.x); //9 ///*******

		Point p = null; //class point
		Console.WriteLine(p == null); //true
		Console.WriteLine(p.x); //throw exception

		Point p = null; //struct point, compile error
		int x = null; //compile error

		//caculate size
		A a = new A();
		Console.WriteLine(Marshal.Sizeof(a)); // 8: 32bit, 16:64bit

		int x = 0, y = 0;
		Console.WriteLine(x++); //output:0, x is now 1
		Console.WriteLine(++x); //output:1, x is now 1

		int x = 2/3; //x = 0;
		int y = 2%3; //x = 2;

		int a = 1000000;
		int b = 1000000;
		int c = checked(a*b); //checks just the expression

		//=>
		checked
		{
			c = a*b;
		}

		int x = int.MaxValue;
		int y = unchecked(x+1);
		unchecked(int z = x+1);

		short x = 1, y = 1;
		short Z = x+y; //compile error
        short z = (short)(x + y);

        string a1 = "\\\\server\\fileshare\\helloworld.cs"; //equal below @
        string a2 = @"\\server\fileshare\helloworld.cs";

        string xml = @"<customer id = "123"></customer>";

        int x = 4;
        Console.WriteLine($"A square has {x} sides"); //prints: A square has 4 sides

        int y = 2;
        string s = $@"this spans {y} lines";

        //array
        char[] vowels = new char[20];
        vowels[0] = 'a';
        vowels[1] = 'b';
        vowels[2] = 'c';
        vowels[3] = 'd';
        vowels[4] = 'e';

        char[] vowels = new char[] {'a', 'b', 'c', 'd', 'e'};
        //or
        char[] vowels = {'a', 'b', 'c', 'd', 'e'};

        //struct point
        Point[] a = new Point[1000];
        int x = a[100].x; //value

        //class point
        point[] a = new Point[1000];
        int x = a[100].x; //runtime error, NullReferenceException
        //handle above problem
        for(int i = 0; i < a.length;i++)
        {
        	a[i] = new point();
        }

        //3x3 array
        int[,] matrix = new int[3,3];

        //assignment
        for(int i = 0; i < matrix.GetLength(0); i++)
        	for(int j = 0; j < matrix.GetLength(1); j++)
        	{
        		matrix[i,j] = i*3+j;
        	}


        int[,] matrix = new int[,]{
        	{0,1,2},
        	{3,4,5},
        	{6,7 8}
        }



	}



	static int FeetToInches(int feet)
	{
		int inches = feet * 12;
		return inches;
	}
}








//reference parameter
class Test
{
	static void Foo(ref int p)
	{
		p = p+1;
		Console.WriteLine(p);
	}

	static void main()
	{
		int x = 9;
		Foo(9);
		Console.WriteLine(x); //x is now 10;
	}

}

void swap(ref int x, ref int y)
{
	int temp;
	temp = x;
	x = y;
	y = temp;
}

//out parameter
class Test
{
	static void Split(string name, out string firstname, out string lastname)
	{
		int i = name.LastIndexOf(' ');
		firstname = name.Substring(0, i);
		lastname = name.Substring(i+1);
	}

	static void main()
	{
		string a, b;
		Split("Steve Ray Vaugh", out a, out b);
		Console.WriteLine(a);
		Console.WriteLine(b);
	}
}

class Test
{
	static int x;
	static void main(){
		Foo(out x);
	}

	static void Foo(out int y)
	{
		Console.WriteLine(x); //x = 0;
		y = 1;
		Console.WriteLine(x); //x = 1;
	}
}


//params modifier: many parameters
class Test
{
	static int Sum(params int[] ints)
	{
		int sum = 0;
		for(int i = 0; i < ints.length; i++)
		{
			sum+=ints[i];
		}
		return sum;
	}

	static void Main()
	{
		int total = Sum(1,2,3,4);
		Console.WriteLine(total); //10

		Foo();

		foreach(char c in  "beer")
		{
			Console.WriteLine(c);
		}
	}

	static void Foo(int x = 23) {Console.WriteLine(x);}

}




//namespace
namespace.Outer.Middle.Inner
{
	class class1(){}
	class class2(){}
}
//=>
namespace Outer
{
	namespace Middle
	{
		namespace Inner
		{
			class class1{}
			class class2{}
		}
	}
}

//using
using Outer.Middle.Inner;
class Test
{
	static void main()
	{
		class1 c;
	}
}

///////////////////
//2018.03.28

//value types
public struct Point { public int X, Y; }

static void Main()
{
	Point p1 = new Point();
	p1.X = 7;
	
	Point p2 = p1;             // Assignment causes copy
	
	Console.WriteLine (p1.X);  // 7
	Console.WriteLine (p2.X);  // 7
	
	p1.X = 9;                  // Change p1.X
	
	Console.WriteLine (p1.X);  // 9
	Console.WriteLine (p2.X);  // 7
}

//Reference types
public class Point { public int X, Y; }

static void Main()
{
	Point p1 = new Point();
	p1.X = 7;
	
	Point p2 = p1;             // Copies p1 *reference*
	
	Console.WriteLine (p1.X);  // 7
	Console.WriteLine (p2.X);  // 7
	
	p1.X = 9;                  // Change p1.X
	
	Console.WriteLine (p1.X);  // 9
	Console.WriteLine (p2.X);  // 9
}

//NULL
public class Point { public int X, Y; }

static void Main()
{
	Point p = null;
	Console.WriteLine (p == null);   // True
	
	// The following line generates a runtime error (a NullReferenceException is thrown):
	//Console.WriteLine (p.X);
}

//Null with structs
public struct Point { public int X, Y; }

static void Main()
{
	Point p = null;		// This line will not compile.
	int x = null;		// Illegal, too.
}

//struct size
struct Point
{
	int x;  // 4 bytes
	int y;  // 4 bytes
}

// However, the CLR requires that fields are offset within the type at an address
// that¡¯s a multiple of their size:
struct A
{
	byte b;  // 1 byte
	long l;  // 8 bytes
}

unsafe static void Main()
{
	sizeof (Point);	// 8 bytes
	sizeof (A);		// 16 bytes
}

//numeric literals
// Integral literals can use decimal or hexadecimal notation; hexadecimal is denoted with the 0x prefix:
int x = 127;
long y = 0x7F;

//Real literals can use decimal and/or exponential notation. For example:
double d = 1.5;
double million = 1E06;

// Numeric literal type inference:
Console.WriteLine (       1.0.GetType());  // Double  (double)
Console.WriteLine (      1E06.GetType());  // Double  (double)
Console.WriteLine (         1.GetType());  // Int32   (int)
Console.WriteLine (0xF0000000.GetType());  // UInt32  (uint)
Console.WriteLine (0x100000000.GetType());  // Int64   (long)

//numeric suffixes
// Numeric literals can be suffixed with a character to indicate their type:
//   F = float
//   D = double
//   M = decimal
//   U = uint
//   L = long
//   UL = ulong

long i = 5;     // No suffix needed: Implicit lossless conversion from int literal to long

// The D suffix is redundant in that all literals with a decimal point are inferred to be double:
double x = 4.0;

// The F and M suffixes are the most useful:
float f = 4.5F;			// Will not compile without the F suffix
decimal d = -1.23M;		// Will not compile without the M suffix.

//divide
Console.WriteLine(2 / 3);  => 0
Console.WriteLine(2 % 3); => 2;

//Integral overflow
// By default, integral arithmetic operations overflow silently:

int a = int.MinValue;
a--;
Console.WriteLine (a == int.MaxValue);  // True

//generate overflow exception
int a = 1000000;
int b = 1000000;

// The following code throws OverflowExceptions:

int c = checked (a * b);      // Checks just the expression.

// Checks all expressions in statement block:
checked
{                             
   int c2 = a * b;
}
// Compile-time overflows are special in that they're checked by default:

int x = int.MaxValue + 1;               // Compile-time error

// You have to use unchecked to disable this:

int y = unchecked (int.MaxValue + 1);   // No errors

// The 8- and 16-bit integral types are byte, sbyte, short, and ushort. These types lack their
// own arithmetic operators, so C# implicitly converts them to larger types as required.
// This can cause a compile-time error when trying to assign the result back to a small integral type:

short x = 1, y = 1;
short z = x + y;          // Compile-time error

// In this case, x and y are implicitly converted to int so that the addition can be performed.
// To make this compile, we must add an explicit cast:

short z = (short) (x + y);   // OK

//equality with reference type
// For reference types, equality, by default, is based on reference, as opposed to the 
// actual value of the underlying object (more on this in Chapter 6).

static void Main()
{
	Dude d1 = new Dude ("John");
	Dude d2 = new Dude ("John");
	Console.WriteLine (d1 == d2);       // False
	Dude d3 = d1;
	Console.WriteLine (d1 == d3);       // True
}

public class Dude
{
	public string Name;
	public Dude (string n) { Name = n; }
}

//// The && and || operators short-circuit. This is essential in allowing expressions such as
// the following to run without throwing a NullReferenceException:

StringBuilder sb = null;

if (sb != null && sb.Length > 0) 
	Console.WriteLine ("sb has data");
else
	Console.WriteLine ("sb is null or empty");


ushort us = 'a';
int i = 'z';

Console.writeline(us); =>97
Console.writeline(i); =>122

// For other numeric types, an explicit conversion is required

short s = (short) 'a';
Console.writeline(s); =>97

  // string is a reference type, rather than a value type. Its equality operators, however, follow value-type semantics:
            string a = "test";
            string b = "test";
            Console.WriteLine(a == b);  // True

            // The escape sequences that are valid for char literals also work inside strings:
            string t = "Here's a tab:\t";

            // The cost of this is that whenever you need a literal backslash, you must write it twice:
            string a1 = "\\\\server\\fileshare\\helloworld.cs";
            Console.WriteLine(a1);

            // To avoid this problem, C# allows "verbatim string literals" - prefixed with @ symbols:
            string a2 = @"\\server\fileshare\helloworld.cs";
            Console.WriteLine(a2);

            // A verbatim string literal can also span multiple lines:
            string escaped = "First Line\r\nSecond Line";
            string verbatim = @"First Line
Second Line";

            // Assuming your IDE uses CR-LF line separators:
            Console.WriteLine(escaped == verbatim);  // True

            // You can include the double-quote character in a verbatim literal by writing it twice:
            string xml = @"<customer id=""123""></customer>";
            Console.WriteLine(xml);

 // The + operator concatenates two strings:
string s1 = "a" + "b";
Console.WriteLine(s1);

// The righthand operand may be a nonstring value, in which case ToString is called on that value:
string s2 = "a" + 5;   // a5
Console.WriteLine(s2);

//string inteporation
            int x = 4;
            Console.WriteLine($"A square has {x} sides");    // Prints: A square has 4 sides

            string s = $"255 in hex is {byte.MaxValue:X2}";   // X2 = 2-digit Hexadecimal
            Console.WriteLine(s);

            x = 2;
            s = $@"this spans {
            x} lines";
            Console.WriteLine(s);

//////////////////////////////////////ARRAY///////////////////////////////////////////////////////////////////////////
 // An array represents a fixed number of elements of a particular type.

char[] vowels = new char[5];    // Declare an array of 5 characters

// Square brackets also index the array, accessing a particular element by position:

vowels[0] = 'a';
vowels[1] = 'e';
vowels[2] = 'i';
vowels[3] = 'o';
vowels[4] = 'u';
Console.WriteLine(vowels[1]);      // e

// Array indexes start at 0. We can use a for loop statement to iterate through each element in the array.
// The for loop in this example cycles the integer i from 0 to 4:

for (int i = 0; i < vowels.Length; i++)
    Console.Write(vowels[i]);            // aeiou

// An array initialization expression:

char[] easy = { 'a', 'e', 'i', 'o', 'u' };

//Default element initialization
int[] a = new int[1000];
Console.Write (a [123]);    // 0


// In contrast, creating an array of reference types allocates null references:
public class Point { public int X, Y; }

static void Main()
{
	Point[] a = new Point[1000];
	
	for (int i = 0; i < a.Length; i++)		// Iterate i from 0 to 999
		a[i] = new Point();					// Set array element i with new point
		
	Point[] nulls = new Point[1000];
	Console.WriteLine (nulls[0] == null);	// True
	Console.WriteLine (nulls[0].X);			// Error: NullReferenceException thrown
}


// For arrays, when the element type is a value type, each element value is allocated as part of the array:

public struct Point { public int X, Y; }

static void Main()
{
	Point[] a = new Point[1000];
	int x = a[500].X;                // 0
	Console.writeline(x); => 0;
}

// Rectangular arrays represent an n-dimensional block of memory; jagged arrays are arrays of arrays.

 int[,] matrix = new int[3, 3];  // 2-dimensional rectangular array

// The GetLength method of an array returns the length for a given dimension (starting at 0):

for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
        matrix[i, j] = i * 3 + j;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i, j]);
    }
    Console.WriteLine();
}

// A rectangular array can be initialized as follows:
int[,] matrix2 = new int[,]
{
	{0,1,2},
	{3,4,5},
	{6,7,8}
};

//array of array ref :https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/arrays/jagged-arrays
// Here's how to declare a jagged array (an array of arrays):

int [][] matrix = new int [3][];

// The inner dimensions aren¡¯t specified in the declaration. Unlike a rectangular array, each inner array
// can be an arbitrary length. Each inner array is implicitly initialized to null rather than an empty array.
// Each inner array must be created manually:

for (int i = 0; i < matrix.Length; i++)
{
	matrix[i] = new int [3];                    // Create inner array
	for (int j = 0; j < matrix[i].Length; j++)
		matrix[i][j] = i * 3 + j;
}

matrix.Dump ("Populated manually");

// A jagged array can be initialized as follows:

int[][] matrix2 = new int[][]
{
  new int[] {0,1,2},
  new int[] {3,4,5},
  new int[] {6,7,8,9}
};

matrix2.Dump ("Populated via array initialization expression");

//Array initialization
char[] vowels = {'a','e','i','o','u'};

// We can omit the "new" expression after the assignment operator:

int[,] rectangularMatrix =
{
	{0,1,2},
	{3,4,5},
	{6,7,8}
};

int[][] jaggedMatrix =
{
	new int[] {0,1,2},
	new int[] {3,4,5},
	new int[] {6,7,8}
};

rectangularMatrix.Dump(); jaggedMatrix.Dump();


// The var keyword tells the compiler to implicitly type a local variable:

var i = 3;           // i is implicitly of type int
var s = "sausage";   // s is implicitly of type string

// Therefore:
var rectMatrix = new int[,]    // rectMatrix is implicitly of type int[,]
{
	{0,1,2},
	{3,4,5},
	{6,7,8}
};

var jaggedMat = new int[][]    // jaggedMat is implicitly of type int[][]
{
	new int[] {0,1,2},
	new int[] {3,4,5},
	new int[] {6,7,8}
};

// Implicit typing can be taken one stage further with single-dimensional arrays. You can omit
// the type qualifier after the new keyword and have the compiler infer the array type:

var vowels = new[] {'a','e','i','o','u'};   // Compiler infers char[]
var x = new[] { 1, 10000000000 };   // Legal - all elements are convertible to long

vowels.Dump(); x.Dump();

int[] arr = new int[3];
arr[3] = 1;               // IndexOutOfRangeException thrown

// The stack is a block of memory for storing local variables and parameters.

static void Main()
{
	Factorial(5).Dump();
}

// For each call to Factorial, x gets pushed onto the stack:

static int Factorial (int x)
{
	if (x == 0) return 1;
	return x * Factorial (x-1);
}

// The heap is a block of memory in which objects (i.e., reference-type instances) reside.
// The runtime has a garbage collector that periodically deallocates objects from the heap.

StringBuilder ref1 = new StringBuilder ("object1");
Console.WriteLine (ref1);
// The StringBuilder referenced by ref1 is now eligible for GC.

StringBuilder ref2 = new StringBuilder ("object2");
StringBuilder ref3 = ref2;
// The StringBuilder referenced by ref2 is NOT yet eligible for GC.

Console.WriteLine (ref3);                   // object2

// Fields are automatically initialized:

static int x;

static void Main()
{
	Console.WriteLine (x);    // 0
}


// By default, arguments in C# are passed by value.
// This means a copy of the value is created when passed to the method:

static void Foo (int p)
{
	p = p + 1;							// Increment p by 1
	Console.WriteLine ("p is " + p);	// Write p to screen
}

static void Main()
{
	int x = 8;
	Foo (x);                  			// Make a copy of x
	Console.WriteLine ("x is " + x);	// x will still be 8
}

// Passing a reference-type argument by value copies the reference, not the object:

static void Foo (StringBuilder fooSB)
{
	fooSB.Append ("test");
	fooSB = null;
}

static void Main()
{
	StringBuilder sb = new StringBuilder();
	
	Foo (sb);
	Console.WriteLine (sb.ToString());    // test
}


static void Foo (ref int p)
{
	p = p + 1;               // Increment p by 1
	Console.WriteLine (p);   // Write p to screen
}

static void Main()
{
	int x = 8;
	Foo (ref  x);            // Ask Foo to deal directly with x
	Console.WriteLine (x);   // x is now 9
}

// The out modifier is most commonly used to get multiple return values back from a method:

static void Split (string name, out string firstNames, out string lastName)
{
	int i = name.LastIndexOf (' ');
	firstNames = name.Substring (0, i);
	lastName   = name.Substring (i + 1);
}
	
static void Main()
{
	string a, b;
	Split ("Stevie Ray Vaughn", out a, out b);
	Console.WriteLine (a);                      // Stevie Ray
	Console.WriteLine (b);                      // Vaughn
}

// In the following example, the variables x and y represent the same instance:

static int x;

static void Main() { Foo (out x); }

static void Foo (out int y)
{
	Console.WriteLine (x);                // x is 0
	y = 1;                                // Mutate y
	Console.WriteLine (x);                // x is 1
}

// The params parameter modifier on the last parameter of a method accepts any number of parameters
// of a specified type:

static int Sum (params int[] ints)
{
	int sum = 0;
	for (int i = 0; i < ints.Length; i++)
		sum += ints[i];                       // Increase sum by ints[i]
	return sum;
}
	
static void Main()
{
	int total = Sum (1, 2, 3, 4);
	Console.WriteLine (total);              // 10
	
	// The call to Sum above is equivalent to:
	int total2 = Sum (new int[] { 1, 2, 3, 4 } );
}

// The params parameter modifier on the last parameter of a method accepts any number of parameters
// of a specified type:

static int Sum (params int[] ints)
{
	int sum = 0;
	for (int i = 0; i < ints.Length; i++)
		sum += ints[i];                       // Increase sum by ints[i]
	return sum;
}
	
static void Main()
{
	int total = Sum (1, 2, 3, 4);
	Console.WriteLine (total);              // 10
	
	// The call to Sum above is equivalent to:
	int total2 = Sum (new int[] { 1, 2, 3, 4 } );
}

// From C# 4.0, methods, constructors and indexers can declare optional parameters.
// A parameter is optional if it specifies a default value in its declaration:

static void Foo (int x = 23) { Console.WriteLine (x); }

static void Main()
{
	Foo();		// 23
	Foo (23);	// 23  (equivalent to above call)
}

// Rather than identifying an argument by position, you can identify it by name:

static void Foo (int x, int y) { Console.WriteLine (x + ", " + y); }

static void Main()
{
	Foo (x:1, y:2);  // 1, 2
	Foo (y:2, x:1);  // 1, 2   (semantically same as above)
	
	// You can mix named and positional arguments:
	Foo (1, y:2);
}

// Named arguments are particularly useful in conjunction with optional parameters:

static void Bar (int a = 0, int b = 0, int c = 0, int d = 0)
{
	Console.WriteLine (a + " " + b + " " + c + " " + d);
}

static void Main()
{
	Bar (d:3); //=> 0 0 0 3
}

// The contextual keyword var implicitly types local variables:
{
	var x = "hello";
	var y = new System.Text.StringBuilder();
	var z = (float)Math.PI;
}

// This is precisely equivalent to:
{
	string x = "hello";
	System.Text.StringBuilder y = new System.Text.StringBuilder();
	float z = (float)Math.PI;
}

var sb = new System.Text.StringBuilder();   // Type of sb is obvious
var z = (float)Math.PI;						// Type of z is obvious

Random r = new Random();
var x = r.Next();			// What type is x?

// An assignment expression is not a void expression. It actually carries the assignment
// value, and so can be incorporated into another expression:

int x, y;

y = 5 * (x = 2);

x.Dump();
y.Dump();

x *= 2;    // equivalent to x = x * 2
x <<= 1;   // equivalent to x = x << 1

x.Dump();

// For operators of the same precedence, associativity determines order of evaluation.
// The binary operators (except for assignment, lambda and null coalescing operators) are
// left-associative; in other words, they are evaluated from left to right:

8 / 4 / 2

// The assignment operators, lambda, null coalescing and conditional operator are right-associative:

int x, y;
x = y = 3;
x.Dump(); y.Dump();


//The operator is the null-coalescing operator. It says ¡°If the operand is non-null, give it to me; otherwise, give me a default value.¡± For example:
//If the left-hand expression is non-null, the right-hand expression is never evaluated. The null-coalescing operator also works with 
//nullable value types
string s1 = null;
string s2 = s1 ?? "nothing";   // s2 evaluates to "nothing"

s2.Dump();

//null-conditional operator
//It allows you to call methods and access members just like the standard dot operator, except that if the operand on the left is null, 
//the expression evaluates to null instead of throwing a NullReferenceException
System.Text.StringBuilder sb = null;
string s = sb?.ToString();	 // No error; s instead evaluates to null  <=> string s = (sb == null ? null : sb.ToString());
s.Dump();

string s2 = sb?.ToString().ToUpper();   // s evaluates to null without error
s2.Dump();

//#page 56
System.Text.StringBuilder sb = null;
int? length = sb?.ToString().Length;   // OK : int? can be null

length.Dump();

string s = sb?.ToString() ?? "nothing";   // s evaluates to "nothing"
s.Dump();

// With a do-while loop, the check is performed at the end, so the body always executes at least once:

int i = 0;
do
{
	Console.WriteLine (i);
	i++;
}
while (i < 3);

// You can have more than one variable in the initialization clause:

for (int i = 0, prevFib = 1, curFib = 1; i < 10; i++)
{
	Console.WriteLine (prevFib);
	int newFib = prevFib + curFib;
  	prevFib = curFib; 
	curFib = newFib;
}

// The foreach statement iterates over each element in an enumerable object.
// The following works because System.String implements IEnumerable<char>:

foreach (char c in "beer")   // c is the iteration variable
	Console.WriteLine (c);

// The continue statement forgoes the remaining statements in a loop and makes an
// early start on the next iteration:

for (int i = 0; i < 10; i++)
{
	if ((i % 2) == 0)		// If i is even,
		continue;			// continue with next iteration

	Console.Write (i + " ");
}

// A return statement can appear anywhere in a method.

static void Main()
{
	AsPercentage (0.345m).Dump();	
}

static decimal AsPercentage (decimal d)
{
	decimal p = d * 100m;
	return p;             // Return to the calling method with value
}

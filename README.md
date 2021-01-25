# Assignment #01

## Software Engineering

### Exercise 1
1. Explain briefly what we mean by the term "software engineering".
2. Describe briefly the history behind the term 'software engineering'.
3. Explain the expression 'there is no silver bullet' in relation to software systems.
4. Software development projects are often very hard to manage. According to Fred Brooks, software systems are inherently different from many other systems due to four properties. Explain briefly these four properties.

### Exercise 2
Discuss briefly the biggest differences between these two software process models: "Waterfall" and "Scrum". For what kind of situations you would see each one to be best suited for?

### Exercise 3
 What is the difference between the "application domain" concept and the "solution domain" concept? Give a brief example of each. 

## C&#35;

Fork this repository and implement the code required for the assignments below.

### Week Number

In the `Calculator` class you will find a method `Add` which is already implemented.

Implement a set of unit tests in the `CalculatorAdd.cs` file, which ensure that all the following rules are verified:

1. The method can take 0, 1, or 2 numbers, and will return their sum (for an empty string it will return 0) for example `""` or `"1"` or `"1,2"`
Start with the simplest test case of an empty string and move to 1 and two numbers
1. Calling the method with a negative number will throw an ArgumentException with the message "Negative numbers are not allowed".

A test must only ever have one assertion, but you are allowed to implement some of your tests as theories if you want.

### Magnitude

You need to implement the `Magnitude` method in the `Calculator` class.
The method should return the magnitude (length of the `long` input).
E.g. 42 has a magnitude of 2 while 1,000 has a magnitude of 4.

You must implement the method using numeric calculation - using string length is not acceptable.

Your code may not throw exceptions and you aare *not* allowed to use `try`/`catch`.

In the `CalculatorMagnitudeTests.cs` file you will find a set of unit tests.
All tests must be green.

### Main

Implement and test the `Main` method of the `Program` class.

The main method should support two syntaxes:

1. `dotnet run add "[string]"` (quotes are optional if the string parameter contains no spaces)
2. `dotnet run magnitude [number]`

Given an understandable command it should print out the result of running the correct `Calculator` function.

Given no arguments or something that's not understandable, it should print out an error message.

You do not need to test the exception cases of the `Add` method.

You are *not* allowed to use `try`/`catch` and the program may only throw exceptions from the `Add` method.

## Submitting the assignment

To submit the assignment you need to create a .pdf document using LaTeX containing the answers to the questions and a link to a public repository containing your fork of the completed code.
Upload the document to Peergrade.

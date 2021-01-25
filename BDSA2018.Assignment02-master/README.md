# Assignment #2

## Software Engineering

### Exercise 1
1. Consider your watch (or the watch of a friend of yours that you can inspect) as a system and set the time 2 minutes ahead. Write down each interaction between you and the watch __as a scenario__. Record all interactions, including any feedback the watch provides you.
2. Consider the scenario you just wrote. 
    - Identify the actor of the scenario. 
    - Next, write the corresponding __use case__ SetTime. 
3. Assume the watch system you described in point 1 and 2 also supports an alarm feature. Describe setting the alarm time as a self-contained __use case__ named SetAlarmTime.
4. Examine the SetTime and SetAlarmTime use cases you wrote in point 2 and 3. Eliminate any redundancy by using an __include relationship__. 
5. Why an include relationship is preferable to an extend relationship in point 4?

### Exercise 2
Below are examples of nonfunctional requirements. Specify which of theses requirements are verifiable and which are not. Regarding those that are not verifiable, please improve the requirement so that it is verifiable.
- "The system must be usable"
- "The system must provide visual feedback to the user within one second of issuing a command"
- "The system should be organized in such a way that user errors are minimized"
- "The availability of the system must be above 95 %"
- The user interface of the new system should be similar enough to the old system that users familiar with the old system can be easily trained to use the new system"

### Exercise 3
Maintaining traceability during requirements and subsequent activities is expensive, because of the additional information that must be captured and maintained. What are the benefits of traceability that outweigh this overhead? Mention at least 2 points you would consider.

### Exercise 4
From your point of view, describe the strengths and weaknesses of users during the requirements elicitation activity. Describe also the strengths and weaknesses of developers during the requirements elicitation activity. Mention at least 2 strenghts and weaknesses you would consider regarding users and regarding developers.


## C&#35;

Fork this repository and implement the code required for the assignments below.

### Generics

Compare the following two methods:

```csharp
int GreaterCount<T, U>(IEnumerable<T> items, T x)
where T : IComparable<T>

int GreaterCount<T, U>(IEnumerable<T> items, T x)
where T : U
where U : IComparable<U>
```

Both methods returns the amount of elements in `items` which are *greater than* `x`.

Explain in your own words what the type constrains mean for both methods.

*Optional*

Implement and test the latter of the two methods including a type hierarchy which supports the given type constraints.

### Iterators

Implement and test the following methods:

```csharp
IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)

IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
```

1. `Flatten` takes as argument a stream of a stream of `T`'s. It should return a stream of `T`'s.

2. `Filter` takes as arguments a stream of `T`'s and a function which returns `true` or `false` when applied to an instance of `T`. It returns a stream of only the `T`s where the predicate returns `true`.

#### Notes
You must `yield` elements and you may not use a temporary in-memory collection. 

You can declare a `Predicate` likes this:

```csharp
public static void Main(string[] args)
{
    Predicate<int> even = Even; 
}

public static bool Even(int i)
{
    return i % 2 == 0;
}
```

### Regular Expressions

Implement and test the following methods:

```csharp
IEnumerable<string> SplitLine(IEnumerable<string> lines)

IEnumerable<(int width, int height)> Resolution(string resolutions)

IEnumerable<string> InnerText(string html, string tag)
```

1. `SplitLine` takes as argument a stream of lines (strings) and returns a stream of the words on those lines (also strings).
A 'word' is a non-empty contiguous sequence of the letters a–z or A–Z or the digits 0–9. Use a regular expression to split the lines into words.

2. `Resolutions` takes a string containing resolutions. A resolution could be `1920x1080`. It returns a stream of resolutions as tuples, e.g. `(1920, 1080)`. The solution must use *named capture groups* 

3. `InnerText` takes as arguments a string containing HTML and a specific tag name. It returns the *inner text* of each of those tags. Use a regular expression with a *back reference* to match tags.

#### Notes
You must `yield` elements and not use a temporary in-memory collection. 

Given the following `html` and the tag `a`:

```html
<div>
    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href="/wiki/Theoretical_computer_science" title="Theoretical computer science">theoretical computer science</a> and <a href="/wiki/Formal_language" title="Formal language">formal language</a> theory, a sequence of <a href="/wiki/Character_(computing)" title="Character (computing)">characters</a> that define a <i>search <a href="/wiki/Pattern_matching" title="Pattern matching">pattern</a></i>. Usually this pattern is then used by <a href="/wiki/String_searching_algorithm" title="String searching algorithm">string searching algorithms</a> for "find" or "find and replace" operations on <a href="/wiki/String_(computer_science)" title="String (computer science)">strings</a>.</p>
</div>
```

The `InnerText` method should return:

- theoretical computer science
- formal language
- characters
- pattern
- string searching algorithms
- strings

You should support nested html tags such that given the following `html` and the tag `p`:

```html
<div>
    <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
</div>
```

The `InnerText` method should return:

>The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to.

## Submitting the assignment

To submit the assignment you need to create a .pdf document using LaTeX containing the answers to the questions and a link to a public repository containing your fork of the completed code.
Upload the document to Peergrade.

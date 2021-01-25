# Assignment #4: Week 38

## Software Engineering

### Exercise 1

1. What level of details should UML models have?
2. Discuss briefly how much and how are design models used in the industry according to the study by Gorschek et al.
3. What is the difference between structure diagrams and behavior diagrams in UML?  Provide two examples per category.
4. What is the difference between a state machine diagram and an activity diagram?

### Exercise 2
1. Draw a use case diagram for a ticket distributor for a train system. The system includes two actors: a traveler, who purchases different types of tickets, and a central computer system, which maintains a reference database for the tariff. Use cases should include: BuyOneWayTicket, BuyWeeklyCard, BuyMonthlyCard, UpdateTariff. Also include the following exceptional cases: Time-Out (i.e., traveler took too long to insert the right amount), TransactionAborted (i.e., traveler selected the cancel button without completing the transaction), DistributorOutOfChange, and DistributorOutOfPaper.

### Exercise 3
1. Consider the process of ordering a pizza over the phone. Draw an activity diagram representing each step of the process, from the moment you pick up the phone to the point where you start eating the pizza. Do not represent any exceptions. Include activities that others need to perform.
2. Add exception handling to the activity diagram you developed in the previous exercise. Consider at least three exceptions. You can for instance use the following: delivery person wrote down the wrong address, delivery person brings wrong pizza, store out of anchovies.


## C&#35;

Fork this repository and implement the code required for the assignments below.

### Slot Car Tournament

![](images/Ninco_JGTC_Fahrerfeld.jpg "Modern commercially made slot cars and track. Ninco, 1:32 scale - source: https://en.wikipedia.org/wiki/Slot_car")

You are required to implement a model using Entity Framework Core for a slot car tournament.

The tournament needs the following entities:

- Track (name, length in meters, best lap time, max cars)
- Car (name, driver name)
- Race (track, number of laps)
- CarInRace (race, car, start position, end position, best lap, total race time)

Create the *POCOs* and `DBContext` required for the model above.

Note: *Duration* may be modelled as 64-bit integers representing *ticks*, as they can be easily converted to/from a `TimeSpan`.

Implement and test the `CarCRUD` class.

Implement a `Seed` method on your context. `Seed` should seed your database with data allowing you to query the database test results against the queries to be implemented in the `Queries` class.

Implement and test the `Queries` class.

## Submitting the assignment

To submit the assignment you need to create a .pdf document using LaTeX containing the answers to the questions and a link to a public repository containing your fork of the completed code.
Upload the document to Peergrade.

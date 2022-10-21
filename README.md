# Traveling Salesperson Problem 2.0
## What it is about
### Acording to Wikipedia
The travelling salesperson problem Aka TSP asks the following question: "Given a list of cities and the distances between each pair of cities, what is the shortest possible route that visits each city exactly once and returns to the origin city?" It is an NP-hard problem in combinatorial optimization, important in theoretical computer science and operations research.

## My previous project
In january 2019 I published on github my first version of TSP made in javascript using Processing js library. Here's a [link](https://github.com/Lucasdvs10/Traveller-Salesperson-Problem) to the repo. In that time I was just starting my studies in computer science and when I read those codes today, I just don't recognize it. So I decided to remake that project applying the knowledge that I acquired in the last 3 years.

## The algorithm I used

In this version I used the ant colony optimization, wich is an algorithm that simulates the behaviour of ants looking for food.

When the program initializes, it instantiates one ant for each city. Every city is connected to each other and the ants must travel through the paths and return to their initial city when there's no other city to visit. 
During the travel, ants leave a path of pheromon, wich evaporates over time. When the ants are deciding wich path to chose, they make this decision based on the pheromon amount and the distance of the path.

The idea is basically it. For a more visually exemple, check this Sebastian Lague's video: https://www.youtube.com/watch?v=X-iSQQgOd1A


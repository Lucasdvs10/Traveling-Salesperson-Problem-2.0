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

## Prints

![14 cidades](https://user-images.githubusercontent.com/46378322/197609194-c41e8383-79a6-4669-bab9-071568470f0c.png)
![21 cidades](https://user-images.githubusercontent.com/46378322/197609218-e2228b14-b784-495e-82ee-ed184dd5d4e6.png)

The first image is a screenshot of the program calculating the best path for 14 cities, while de second one is calculating for 21 cities

As you can see, I made this program in Unity. I chosed unity just because I'm familiar with it and I wanted to improve my skills in it.

![testes que eu escrevi](https://user-images.githubusercontent.com/46378322/197609758-8ec3e24f-ef04-41b0-8429-9275d0e8ff73.png)

I wrote a bunch of tests in this project. I've been learning how to write tests and how to take the best from them. It's really helpful and important. I don't really know why people are not used to them.

Writing tests in Unity is can be harder than writing test in "conventional" software development. To make it a little easier, I used the Humble object pattern and separeted the core logic from Unity itself. And i wrote tests only for the logic.

## Performance problems
![performace com 45 cidades](https://user-images.githubusercontent.com/46378322/197610963-db9c653d-f9ed-4888-b125-2c961d8f991c.png)

The print above is the performace of the program with 45 cities. As you can see, it's not performatic at all. 
I'd like to improve it, but I still don't have technical skills enough to do so.

Recently I was serching about performace improve and I found this programming paradigm called Data Oriented Design. I'd like to learn more about it and try to implement it in Travelling Salesperson Problem

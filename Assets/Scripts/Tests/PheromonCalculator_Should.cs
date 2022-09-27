using System.Collections.Generic;
using Core_Scripts.Entities;
using NUnit.Framework;
using UnityEngine;

namespace Tests {
    public class PheromonCalculator_Should {
        private Path mockPath1;
        private Path mockPath2;
        private Path mockPath3;
        private Ant mockAnt;
        private PheromonCalculator pheromonCalculator;

        [SetUp]
        public void SetupTests() {
            var cityA = new City(Vector2.zero);
            var cityB = new City(Vector2.right * 5);
            var cityC = new City(Vector2.left * 5);

            mockPath1 = new Path(cityA, cityB, 10);
            mockPath2 = new Path(cityA, cityC, 10);
            mockPath3 = new Path(cityB, cityC, 10);
            
            cityA.AddPathToSet(mockPath1);
            cityB.AddPathToSet(mockPath1);
            
            cityA.AddPathToSet(mockPath2);
            cityC.AddPathToSet(mockPath2);

            cityB.AddPathToSet(mockPath3);
            cityC.AddPathToSet(mockPath3);
            
            mockAnt = new Ant(cityA, 1, 1);

            pheromonCalculator = new PheromonCalculator(0.7f, 10f);
        }

        [Test]
        public void Change_Pheromon_Amount_To_5_Of_Visited_Path() {
            mockAnt.TravelOnPath(mockPath1);
            var mockHashSet1 = new HashSet<Ant>(){mockAnt};
            var mockHashSet2 = new HashSet<Path>(){mockPath1};
            pheromonCalculator.CalculatePathPheromon(mockHashSet1, mockHashSet2);
            
            Assert.AreEqual(5f,mockPath1.PheromonAmount);
        }
        
        [Test]
        public void Change_Pheromon_Amount_To_3_Of_Not_Visited_Paths() {
            mockAnt.TravelOnPath(mockPath1);
            var mockHashSet1 = new HashSet<Ant>(){mockAnt};
            var mockHashSet2 = new HashSet<Path>(){mockPath1, mockPath2, mockPath3};
            pheromonCalculator.CalculatePathPheromon(mockHashSet1, mockHashSet2);
            
            Assert.AreEqual(3f,mockPath2.PheromonAmount);
            Assert.AreEqual(3f,mockPath3.PheromonAmount);
        }
        
    }
}
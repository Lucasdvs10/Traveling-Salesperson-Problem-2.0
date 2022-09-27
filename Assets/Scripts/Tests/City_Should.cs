using System.Collections.Generic;
using Core_Scripts.Entities;
using NUnit.Framework;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests {
    public class City_Should {
        private City _cityA;
        private City _cityB;
        
        [SetUp]
        public void SetupTests() {
            _cityA = new City(Vector2.one);
            _cityB = new City(Vector2.one * 10);
        }

        [Test]
        public void Not_Add_Path_That_Doesnt_Contain_This_City() {
            var cityC = new City(Vector2.one * - 10);
            Path mockPath = new Path(_cityB, cityC, 10f);
            
            _cityA.AddPathToSet(mockPath);

            
            Assert.AreEqual(0, _cityA.PossiblePaths.Count);
        }
        [Test]
        public void Add_Path_That_Does_Contain_This_City() {
            var cityC = new City(Vector2.one * - 10);
            Path mockPath = new Path(_cityB, cityC, 10f);
            
            _cityB.AddPathToSet(mockPath);

            
            Assert.AreEqual(1, _cityB.PossiblePaths.Count);
        }
        
        [Test]
        public void Not_Add_Paths_More_Than_Once() {
            var cityC = new City(Vector2.one * - 10);
            Path mockPath = new Path(_cityB, cityC, 10f);
            Path mockPath2 = new Path(_cityB, cityC, 10f);
            Path mockPath3 = new Path(_cityB, _cityA, 10f);
            
            _cityB.AddPathToSet(mockPath);
            _cityB.AddPathToSet(mockPath2);
            _cityB.AddPathToSet(mockPath3);
            
            
            Assert.AreEqual(2, _cityB.PossiblePaths.Count);
        }
        
        
    }
}
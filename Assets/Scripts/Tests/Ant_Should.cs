using System.Collections.Generic;
using Entities;
using NUnit.Framework;
using UnityEngine;

namespace Tests {
    public class Ant_Should {
        private Ant _ant;
        
        [SetUp]
        public void SetupTests() {
            var cityA = new City(Vector2.one);
            _ant = new Ant(cityA);
        }
        
        [Test]
        public void Change_Current_City_To_Initial_City() {
            _ant.ReturnToInitialCity();
            
            Assert.AreEqual(_ant.InitialCity, _ant.CurrentCity);
        }

        [Test]
        public void Go_To_Another_City() {
            var cityA = new City(Vector2.one);
            var cityB = new City(Vector2.one * 10);

            _ant = new Ant(cityA);
            
            Path mockPath = new Path(cityA, cityB, 10f) ;
            
            cityA.AddPathToSet(mockPath);
            cityB.AddPathToSet(mockPath);

            _ant.GoToNextCity();
            
            Assert.AreNotEqual(cityA, _ant.CurrentCity);
            
            _ant.GoToNextCity();
            Assert.AreNotEqual(cityB, _ant.CurrentCity);

        }
        
    }
}
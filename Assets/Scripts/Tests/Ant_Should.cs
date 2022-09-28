using Core_Scripts.Entities;
using NUnit.Framework;
using UnityEngine;

namespace Tests {
    public class Ant_Should {
        private Ant _ant;
        
        [SetUp]
        public void SetupTests() {
            var cityA = new City(Vector2.one);
            _ant = new Ant(cityA, 2, 2);
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

            _ant = new Ant(cityA, 2, 2);
            
            Path.CreatePathAndInsertInCities(cityA, cityB, 10f) ;
            
            _ant.PickNextCityAndGo();
            
            Assert.AreEqual(cityB, _ant.CurrentCity);
            
        }
        
        [Test]
        public void Not_Visit_A_City_Twice() {
            var cityA = new City(Vector2.zero);
            var cityB = new City(Vector2.right * 10);
            var cityC = new City(Vector2.left * 10);

            _ant = new Ant(cityA, 1, 1);
            
            Path mockPath1 = Path.CreatePathAndInsertInCities(cityA, cityB, Mathf.Infinity) ;
            Path mockPath2 = Path.CreatePathAndInsertInCities(cityB, cityC, 10f) ;
            

            _ant.TravelOnPath(mockPath1); //current city is B. Two possible paths: path1: pheromon infinity and already visited
                                          // Path 2: Not visited yet. Pheromon amount = 10                              
            
            _ant.PickNextCityAndGo();

            Assert.AreEqual(cityC, _ant.CurrentCity);
            

        }
        
        [Test]
        public void Return_To_Initial_City_When_Theres_No_Other_City_Left() {
            var cityA = new City(Vector2.zero);
            var cityB = new City(Vector2.right * 10);
            var cityC = new City(Vector2.left * 10);

            _ant = new Ant(cityA, 1, 1);
            
            Path mockPath1 = Path.CreatePathAndInsertInCities(cityA, cityB, Mathf.Infinity) ;
            Path mockPath2 = Path.CreatePathAndInsertInCities(cityB, cityC, Mathf.Infinity) ;

            _ant.TravelOnPath(mockPath1);//City A to City B
            _ant.TravelOnPath(mockPath2);//City B to City C
            _ant.PickNextCityAndGo();//Should be City C to City A
            
            Assert.AreEqual(cityA, _ant.CurrentCity);
            
        }

        [Test]
        public void Reset_Total_distance_and_Sets() {
            var cityA = new City(Vector2.zero);
            var cityB = new City(Vector2.right * 10);
            var cityC = new City(Vector2.left * 10);

            _ant = new Ant(cityA, 1, 1);
            
            Path mockPath1 = Path.CreatePathAndInsertInCities(cityA, cityB, Mathf.Infinity) ;
            Path mockPath2 = Path.CreatePathAndInsertInCities(cityB, cityC, Mathf.Infinity) ;

            _ant.TravelOnPath(mockPath1);//City A to City B
            _ant.TravelOnPath(mockPath2);//City B to City C
            _ant.ResetAnt();//Should be City C to City A
            
            Assert.AreEqual(0, _ant.TotalDistance);
            Assert.AreEqual(0, _ant.VisitedPaths.Count);
            Assert.AreEqual(0, _ant.VisitedCities.Count);
        }
        
    }
}
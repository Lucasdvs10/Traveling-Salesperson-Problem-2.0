using System.Collections.Generic;
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
            
            Path mockPath = new Path(cityA, cityB, 10f) ;
            
            cityA.AddPathToSet(mockPath);
            cityB.AddPathToSet(mockPath);

            _ant.PickNextCityAndGo();
            
            Assert.AreEqual(cityB, _ant.CurrentCity);
            
            // _ant.PickNextCityAndGo();
            // Assert.AreNotEqual(cityB, _ant.CurrentCity);

        }
        
        //Todo: Implementar o código necessário para passar neste teste
        //Falta implementar a verificação de quais cidades a formiga já passou
        [Test]
        public void Not_Visit_A_City_Twice() {
            var cityA = new City(Vector2.zero);
            var cityB = new City(Vector2.right * 10);
            var cityC = new City(Vector2.left * 10);

            _ant = new Ant(cityA, 1, 1);
            
            Path mockPath1 = new Path(cityA, cityB, Mathf.Infinity) ;
            Path mockPath2 = new Path(cityB, cityC, 10f) ;
            
            cityA.AddPathToSet(mockPath1);
            cityB.AddPathToSet(mockPath1);
            
            cityB.AddPathToSet(mockPath2);

            _ant.TravelOnPath(mockPath1); //current city is B. Two possible paths: path1: pheromon infinity and already visited
                                          // Path 2: Not visited yet. Pheromon amount = 10                              
            
            _ant.PickNextCityAndGo();

            Assert.AreEqual(cityC, _ant.CurrentCity);
            

        }
        
        //Todo: Escrever um teste e uma implementação que faça com que a formiga sempre volte quando não sobrar nenhuma cidade para visitar
        
    }
}
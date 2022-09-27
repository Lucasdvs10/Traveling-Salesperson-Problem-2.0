using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Core_Scripts.Entities {
    public class Ant {
        private City _initialCity;
        private City _currentCity;
        private HashSet<City> _visitedCity;
        private HashSet<Path> _visitedPaths;
        private readonly float _pheromonInfluence; //Definindo parâmetros de influencia de feromônio e da distância
        private readonly float _distanceInfluence;
        private float _totalDistance;
        
        public void PickNextCityAndGo() {
            var probabilitySum = 0f;

            foreach (var path in CurrentCity.PossiblePaths) { //Somando todas as probabilidades
                probabilitySum += Mathf.Pow(path.PheromonAmount, _pheromonInfluence) * Mathf.Pow(1 / path.Distance, _distanceInfluence);
            }
            
            foreach (var path in CurrentCity.PossiblePaths) {
                
                var probabilityToChooseThisPath = //Calculando a probabilidade de escolher o caminho analisado atualmente
                    (Mathf.Pow(path.PheromonAmount, _pheromonInfluence) * Mathf.Pow(1 / path.Distance, _distanceInfluence)) / probabilitySum;
                
                var thisPathHasBeenChosen = RollDice(probabilityToChooseThisPath);
                if (thisPathHasBeenChosen) { //Viajando até o caminho caso tenha sido selecionado
                    TravelOnPath(path);
                    return;
                }
            }
            
            TravelOnPath(CurrentCity.PossiblePaths.ToArray()[0]);
            
        }
        public void TravelOnPath(Path path) {
            _visitedPaths.Add(path);
            _totalDistance += path.Distance;

            if (path.CitiesPath[1] != _currentCity) {
                GoToCity(path.CitiesPath[1]);
                return;
            }
            GoToCity(path.CitiesPath[0]);
        }

        public void GoToCity(City city) {
            _visitedCity.Add(city);
            _currentCity = city;
        }
        
        private bool RollDice(float probability) {
            var random = new Random(); //Jogando um D20 para ver passou no teste
            var randomNumber = random.NextDouble();

            var passedInTest = randomNumber <= probability;
            return passedInTest;
        }

        public void ReturnToInitialCity() {
            _currentCity = _initialCity;
        }
        
        
        public Ant(City initialCity, float pheromonInfluence, float distanceInfluence) {
            _initialCity = initialCity;
            _currentCity = _initialCity;
            _pheromonInfluence = pheromonInfluence;
            _distanceInfluence = distanceInfluence;
            _totalDistance = 0f;
            _visitedCity = new HashSet<City> { _initialCity};
            _visitedPaths = new HashSet<Path>();
        }

        public City InitialCity => _initialCity;

        public City CurrentCity => _currentCity;

        public HashSet<City> VisitedCity => _visitedCity;

        public HashSet<Path> VisitedPaths => _visitedPaths;

        public float TotalDistance => _totalDistance;
    }
}
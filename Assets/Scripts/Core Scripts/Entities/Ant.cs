using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Core_Scripts.Entities {
    public class Ant {
        private City _initialCity;
        private City _currentCity;
        private HashSet<City> _visitedCities;
        private HashSet<Path> _visitedPaths;
        private readonly float _pheromonInfluence; //Definindo parâmetros de influencia de feromônio e da distância
        private readonly float _distanceInfluence;
        private float _totalDistance;
        
        public void PickNextCityAndGo() {
            var probabilitySum = 0f;
            
            if (GetAvaiblePathsFromCurrentCity().Count == 0) {
                ResetAnt();
                return;
            }
            
            foreach (var path in GetAvaiblePathsFromCurrentCity()) { //Somando todas as probabilidades
                probabilitySum += Mathf.Pow(path.PheromonAmount, _pheromonInfluence) * Mathf.Pow(1 / path.Distance, _distanceInfluence);
            }

            foreach (var path in GetAvaiblePathsFromCurrentCity()) {

                var probabilityToChooseThisPath = //Calculando a probabilidade de escolher o caminho analisado atualmente
                    (Mathf.Pow(path.PheromonAmount, _pheromonInfluence) * Mathf.Pow(1 / path.Distance, _distanceInfluence)) / probabilitySum;
                
                var thisPathHasBeenChosen = RollDice(probabilityToChooseThisPath);
                if (thisPathHasBeenChosen) { //Viajando até o caminho caso tenha sido selecionado
                    TravelOnPath(path);
                    return;
                }
            }
            
            TravelOnPath(GetAvaiblePathsFromCurrentCity().ToArray()[0]);
            
        }

        private void ResetAnt() {
            ReturnToInitialCity();
            _totalDistance = 0;
            _visitedPaths.Clear();
            _visitedCities.Clear();
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
            _visitedCities.Add(city);
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
            _visitedCities = new HashSet<City> { _initialCity};
            _visitedPaths = new HashSet<Path>();
        }

        public HashSet<Path> GetAvaiblePathsFromCurrentCity() {
            HashSet<Path> avaiblePaths = new HashSet<Path>();

            foreach (var path in CurrentCity.PossiblePaths) {
                if (!_visitedCities.Contains(path.CitiesPath[0]) || !_visitedCities.Contains(path.CitiesPath[1]))
                    avaiblePaths.Add(path);
            }

            return avaiblePaths;
        }
        
        public City InitialCity => _initialCity;

        public City CurrentCity => _currentCity;

        public HashSet<City> VisitedCities => _visitedCities;

        public HashSet<Path> VisitedPaths => _visitedPaths;

        public float TotalDistance => _totalDistance;
    }
}
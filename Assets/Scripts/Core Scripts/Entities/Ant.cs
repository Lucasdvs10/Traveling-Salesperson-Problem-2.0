using System.Collections.Generic;

namespace Entities {
    public class Ant {
        private City _initialCity;
        private City _currentCity;
        private HashSet<City> _visitedCity;
        private HashSet<Path> _visitedPaths;
        
        public void GoToNextCity() {
            foreach (var path in CurrentCity.PossiblePaths) {
                
                //todo: Fazer os cálculos de probabilidade de escolher este caminho
                
                //Calcular um numero e ver se este caminho foi escolhido ou não
                
                var choseThisPath = true; //Variável mockada para fins de teste
                
                if (choseThisPath) {

                    if (path.CitiesPath[1] != _currentCity) {
                        _currentCity = path.CitiesPath[1];
                        return;
                    }
                    _currentCity = path.CitiesPath[0];
                    return;
                }
            }
        }
        
        public void ReturnToInitialCity() {
            _currentCity = _initialCity;
        }
        
        
        public Ant(City initialCity) {
            _initialCity = initialCity;
            _currentCity = _initialCity;
        }

        public City InitialCity => _initialCity;

        public City CurrentCity => _currentCity;

        public HashSet<City> VisitedCity => _visitedCity;

        public HashSet<Path> VisitedPaths => _visitedPaths;


    }
}
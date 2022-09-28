using UnityEngine;

namespace Core_Scripts.Entities {
    public class Path {
        private City[] _citiesPath;
        private float _distance;
        private float _pheromonAmount;

        public static Path CreatePathAndInsertInCities(City cityA, City cityB, float pheromonAmount) {
            var pathToReturn = new Path(cityA, cityB, pheromonAmount);
            cityA.AddPathToSet(pathToReturn);
            cityB.AddPathToSet(pathToReturn);
            return pathToReturn;
        }

        public override string ToString() {
            return $"Ligação entre a cidade {_citiesPath[0]} e a cidade {_citiesPath[1]}";
        }

        public override int GetHashCode() {
            return _citiesPath[0].GetHashCode() + _citiesPath[1].GetHashCode();
        }

        public override bool Equals(object obj) {
            return obj.GetHashCode() == GetHashCode();
        }

        public Path(City cityA, City cityB, float pheromonAmount) {
            _citiesPath = new City[] { cityA, cityB };
            _pheromonAmount = pheromonAmount;
            _distance = Vector2.Distance(cityA.Position, cityB.Position);
        }
        
        public void SetPheromonAmount(float newAmount) => _pheromonAmount = newAmount;
        public City[] CitiesPath => _citiesPath;
        public float Distance => _distance;
        public float PheromonAmount => _pheromonAmount;
    }
}
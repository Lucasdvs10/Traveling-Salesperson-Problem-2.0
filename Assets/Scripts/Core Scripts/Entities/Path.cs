using UnityEngine;

namespace Entities {
    public class Path {
        private City[] _citiesPath;
        private float _distance;
        private float _pheromonAmount;


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
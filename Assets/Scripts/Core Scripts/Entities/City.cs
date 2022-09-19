using System.Collections.Generic;
using UnityEngine;

namespace Entities {
    public class City {
        private Vector2 _position;
        private HashSet<Path> _possiblePaths;

        public City(Vector2 position, HashSet<Path> possiblePaths) {
            _position = position;
            _possiblePaths = possiblePaths;
        }

        public Vector2 Position => _position;
        public HashSet<Path> PossiblePaths => _possiblePaths;
    }
}
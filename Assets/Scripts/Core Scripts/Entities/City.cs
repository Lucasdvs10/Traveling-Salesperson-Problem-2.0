using System.Collections.Generic;
using UnityEngine;

namespace Core_Scripts.Entities {
    public class City {
        private Vector2 _position;
        private HashSet<Path> _possiblePaths;

        public override string ToString() {
            return $"City at position{_position}";
        }

        public City(Vector2 position, HashSet<Path> possiblePaths) {
            _position = position;
            _possiblePaths = possiblePaths;
        }

        public City(Vector2 position) {
            _position = position;
            _possiblePaths = new HashSet<Path>();
        }

        public void AddPathToSet(Path pathToAdd) { 
            if(pathToAdd.CitiesPath[0] != this && pathToAdd.CitiesPath[1] != this) return;
            _possiblePaths.Add(pathToAdd);
        }
        public Vector2 Position => _position;
        public HashSet<Path> PossiblePaths => _possiblePaths;
    }
}
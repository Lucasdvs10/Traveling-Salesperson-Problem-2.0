using System.Collections.Generic;

namespace Entities {
    public class Ant {
        private City _initialCity;
        private City _currentCity;
        private HashSet<City> _visitedCity;
        private HashSet<Path> _visitedPaths;
    }
}
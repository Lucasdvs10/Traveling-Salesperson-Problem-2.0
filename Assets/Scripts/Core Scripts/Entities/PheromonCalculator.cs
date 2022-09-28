using System.Collections.Generic;

namespace Core_Scripts.Entities {
    public class PheromonCalculator {
        readonly float  _EVAPORATIONRATE;
        private readonly float CONSTANTQ;

        public void CalculatePathPheromon(HashSet<Ant> antsSet, HashSet<Path> containerPaths) {

            foreach (var path in containerPaths) {

                path.SetPheromonAmount(path.PheromonAmount * (1 - _EVAPORATIONRATE));
            }
            
            foreach (var ant in antsSet) {
                float deltaPheromon = CONSTANTQ / ant.TotalDistance;

                foreach (var visitedPath in ant.VisitedPaths) {
                    visitedPath.SetPheromonAmount(visitedPath.PheromonAmount + deltaPheromon);
                }
            }
        }

        public PheromonCalculator(float evaporationRate, float constantq) {
            _EVAPORATIONRATE = evaporationRate;
            CONSTANTQ = constantq;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Core_Scripts.Entities;
using UnityEngine;

namespace MonoBehaviours {
    //todo: Talvez city manager não seja um bom nome, pois ele tbm tá gerenciando e instanciando os paths
    public class CityManagerBehaviour : MonoBehaviour {
        private List<CityBehaviour> _citiesContainer;
        private HashSet<Path> _pathsContainer;

        private void Awake() {
            _citiesContainer = FindObjectsOfType<CityBehaviour>().ToList();
            _pathsContainer = new HashSet<Path>();
        }

        private void Start() { //Inserting Paths in Cities
            if(_citiesContainer.Count <= 1) { //Se for menor ou igual a 1, nem faz nada
                print("Número de cidades inválido! Deve-se ter pelo menos duas cidades");
                return;
            }
            for (var i = 0; i < _citiesContainer.Count - 1; i++) {
                var currentCity = _citiesContainer[i].CityEntity;

                for (var j = i+1; j < _citiesContainer.Count; j++) {
                    var nextCity = _citiesContainer[j].CityEntity;
                    _pathsContainer.Add(Path.CreatePathAndInsertInCities(currentCity, nextCity, 10f));
                }
            }
        }
        [ContextMenu("Printar todos os paths")]
        public void PrintAllPaths() {
            foreach (var path in PathsContainer) {
                print(path);
            }
        }

        public HashSet<Path> PathsContainer => _pathsContainer;

        public List<CityBehaviour> CitiesContainer => _citiesContainer;
    }
}
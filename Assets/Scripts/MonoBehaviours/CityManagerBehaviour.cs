using System.Collections.Generic;
using System.Linq;
using Core_Scripts.Entities;
using UnityEngine;

namespace MonoBehaviours {
    //todo: Talvez city manager não seja um bom nome, pois ele tbm tá gerenciando e instanciando os paths
    public class CityManagerBehaviour : MonoBehaviour {
        private List<CityBehaviour> _citiesContainer;

        private void Awake() {
            _citiesContainer = FindObjectsOfType<CityBehaviour>().ToList();
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
                    Path.CreatePathAndInsertInCities(currentCity, nextCity, 10f);
                }
            }
        }

        public List<CityBehaviour> CitiesContainer => _citiesContainer;
    }
}
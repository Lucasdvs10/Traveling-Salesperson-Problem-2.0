using System.Collections.Generic;
using System.Linq;
using Core_Scripts.Entities;
using UnityEngine;

namespace MonoBehaviours {
    public class AntsSystem : MonoBehaviour {
        [SerializeField] private float _pheromonInfluence;
        [SerializeField] private float _distanceInfluence;
        [SerializeField] private float _evaporationRate;
        [SerializeField] private float _constantQ;
        [SerializeField] private int _numberOfCycles;
        
        private CityManagerBehaviour _cityManagerBehaviour;
        private List<CityBehaviour> _allCitiesList;
        private HashSet<Ant> _antsSet;
        private PheromonCalculator _pheromonCalculator;
        private void Awake() {
            _cityManagerBehaviour = FindObjectOfType<CityManagerBehaviour>();
            _antsSet = new HashSet<Ant>();
            _pheromonCalculator = new PheromonCalculator(_evaporationRate, _constantQ);
        }

        private void Start() {
            _allCitiesList = _cityManagerBehaviour.CitiesContainer;

            foreach (var cityBehaviour in _allCitiesList) {
                _antsSet.Add(new Ant(cityBehaviour.CityEntity, _pheromonInfluence, _distanceInfluence));
            }
        }

        [ContextMenu("Rodar um ciclo")]
        public void RunOneCycle() {
            foreach (var cityBehaviour in _allCitiesList) { //Um ciclo consiste em: As formigas percorrerem todas as cidades e depois recalcular os feromonios de cada caminho
                foreach (var ant in _antsSet) {
                    ant.PickNextCityAndGo();
                }
            }
            
            //Após o ciclo, recalcular todos os feromonios
            _pheromonCalculator.CalculatePathPheromon(_antsSet, _cityManagerBehaviour.PathsContainer);
            foreach (var ant in _antsSet) {
                ant.ResetAnt();
            }

        }

        [ContextMenu("Rodar multiplos ciclos")]
        public void RunMutipleCycles() {
            for (int i = 0; i < _numberOfCycles; i++) {
                RunOneCycle();
            }

            
            
            foreach (var path in _cityManagerBehaviour.GetBestPath()) {
                print(path);
            }
        }
        
        

    }
}
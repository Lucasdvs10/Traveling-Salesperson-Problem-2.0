using System.Collections.Generic;
using Core_Scripts.Entities;
using UnityEngine;

namespace MonoBehaviours {
    public class AntsSystem : MonoBehaviour {
        [SerializeField] private float _pheromonInfluence;
        [SerializeField] private float _distanceInfluence;
        
        private CityManagerBehaviour _cityManagerBehaviour;
        private List<CityBehaviour> _allCitiesList;
        private HashSet<Ant> _antsSet;
        private void Awake() {
            _cityManagerBehaviour = FindObjectOfType<CityManagerBehaviour>();
            _antsSet = new HashSet<Ant>();
        }

        private void Start() {
            _allCitiesList = _cityManagerBehaviour.CitiesContainer;

            foreach (var cityBehaviour in _allCitiesList) {
                _antsSet.Add(new Ant(cityBehaviour.CityEntity, _pheromonInfluence, _distanceInfluence));
            }
        }
    }
}
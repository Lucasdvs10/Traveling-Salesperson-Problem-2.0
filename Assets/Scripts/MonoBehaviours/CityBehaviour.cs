using Core_Scripts.Entities;
using UnityEngine;

namespace MonoBehaviours {
    public class CityBehaviour : MonoBehaviour {
        private City _cityEntity;

        private void Awake() {
            _cityEntity = new City(transform.position);
        }

        public City CityEntity => _cityEntity;
    }
}
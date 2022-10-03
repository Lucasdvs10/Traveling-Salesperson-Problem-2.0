using System.Collections.Generic;
using Core_Scripts.Entities;
using UnityEngine;

namespace MonoBehaviours {
    public class PathsDrawer : MonoBehaviour {
        [SerializeField] private GameObject _linePrefab;
        private HashSet<GameObject> _linesSet;
        private LineRenderer _lineRenderer;
        private CityManagerBehaviour _cityManager;

        private void Awake() {
            _cityManager = FindObjectOfType<CityManagerBehaviour>();
            _linesSet = new HashSet<GameObject>();
        }
        
        [ContextMenu("Desenhar caminho")]
        public void DrawBestPath() {

            foreach (var line in _linesSet) {
                Destroy(line);
            }

            var bestPath = _cityManager.GetBestPath();
            foreach (var path in bestPath) {
                AddSide(path);
            }
        }

        private void AddSide(Path verticesPosition) {
            var gameObj = Instantiate(_linePrefab);
            var lineRenderer = gameObj.GetComponent<LineRenderer>();

            lineRenderer.positionCount = 2;

            Vector3[] verticesArray = {verticesPosition.CitiesPath[0].Position, verticesPosition.CitiesPath[1].Position };
            lineRenderer.SetPositions(verticesArray);
            _linesSet.Add(gameObj);
        }
    }
}
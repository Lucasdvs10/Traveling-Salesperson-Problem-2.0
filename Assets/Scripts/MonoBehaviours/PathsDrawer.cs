using UnityEngine;

namespace MonoBehaviours {
    public class PathsDrawer : MonoBehaviour {
        [SerializeField] private GameObject _linePrefab;
        private LineRenderer[] _linesRendererSet;
        private LineRenderer _lineRenderer;
        private CityManagerBehaviour _cityManager;

        private void Awake() {
            _cityManager = FindObjectOfType<CityManagerBehaviour>();
        }

        private void Start() {
            _linesRendererSet = new LineRenderer[_cityManager.CitiesContainer.Count];

            for(var i = 0; i<_cityManager.CitiesContainer.Count; i++){
                var gameObj = Instantiate(_linePrefab);
                var lineRenderer = gameObj.GetComponent<LineRenderer>();
                lineRenderer.positionCount = 2;
                _linesRendererSet[i] = lineRenderer;
            }
        }

        [ContextMenu("Desenhar caminho")]
        public void DrawBestPath() {
            var bestPath = _cityManager.GetBestPath();

            for (int i = 0; i < bestPath.Count; i++) {
                Vector3[] verticesArray = {bestPath[i].CitiesPath[0].Position, bestPath[i].CitiesPath[1].Position };
                _linesRendererSet[i].SetPositions(verticesArray);
            }
        }
    }
}
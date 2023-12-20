using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts
{
    public class TurbinesSpawner : TurbinesPool
    {
        [SerializeField] private Turbine turbinePrefab;
        [SerializeField] private float _secondsBetweenSpawn;
        [SerializeField] private float _minSpawnPositionY;
        [SerializeField] private float _maxSpawnPositionY;
        
        private float _elapsedTime;

        private void Start()
        {
            Init(turbinePrefab);

            _elapsedTime = _secondsBetweenSpawn;
        }

        public void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _secondsBetweenSpawn)
            {
                if (TryGetTurbine(out Turbine turbine))
                {
                    _elapsedTime = 0;
                    
                    float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                    Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                    turbine.gameObject.SetActive(true);
                    turbine.transform.position = spawnPoint;
                    
                    DisableTurbinesAfterCamera();
                }
            }
        }
    }
}
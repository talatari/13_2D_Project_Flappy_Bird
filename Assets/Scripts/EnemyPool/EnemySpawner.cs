using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts
{
    public class EnemySpawner : EnemyPool
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private float _secondsBetweenSpawn;
        [SerializeField] private float _minSpawnPositionY;
        [SerializeField] private float _maxSpawnPositionY;
        
        private float _elapsedTime;

        private void Start()
        {
            Init(enemyPrefab);

            _elapsedTime = _secondsBetweenSpawn;
        }

        public void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _secondsBetweenSpawn)
                if (TryGetEnemy(out Enemy enemy))
                {
                    _elapsedTime = 0;
                    
                    float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                    Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                    enemy.gameObject.SetActive(true);
                    enemy.transform.position = spawnPoint;
                    
                    DisableEnemyAfterCamera();
                }
        }
    }
}
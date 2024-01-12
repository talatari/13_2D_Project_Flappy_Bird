using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;
        
        private Camera _camera;
        private List<Enemy> _enemies = new ();

        protected void Init(Enemy enemyPrefab)
        {
            _camera = Camera.main;

            for (int i = 0; i < _capacity; i++)
            {
                Enemy newEnemy = Instantiate(enemyPrefab, _container.transform);
                newEnemy.gameObject.SetActive(false);
                
                _enemies.Add(newEnemy);
            }
        }

        protected bool TryGetEnemy(out Enemy enemy) => 
            (enemy = _enemies.FirstOrDefault(p => p.gameObject.activeSelf == false)) != null;

        protected void DisableEnemyAfterCamera()
        {
            Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
            
            foreach (Enemy enemy in _enemies)
                if (enemy.gameObject.activeSelf)
                    if (enemy.transform.position.x < disablePoint.x)
                        enemy.gameObject.SetActive(false);
        }

        public void ResetPool()
        {
            foreach (Enemy enemy in _enemies)
                enemy.gameObject.SetActive(false);
        }
    }
}
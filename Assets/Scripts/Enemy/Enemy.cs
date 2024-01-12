using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyLaser _enemyLaser;
        [SerializeField] private Transform _shootPosition;
        
        private Coroutine _fireCoroutine;
        
        private void OnEnable() => 
            _fireCoroutine = StartCoroutine(Fire());

        private void OnDisable()
        {
            if (_fireCoroutine != null)
                StopCoroutine(_fireCoroutine);
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator Fire()
        {
            float minDelay = 0.5f;
            float maxDelay = 2.0f;
            
            while (true)
            {
                float randomDelay = Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(randomDelay);

                EnemyLaser enemyLaser = Instantiate(_enemyLaser);
                enemyLaser.SetStartPosition(_shootPosition.position);
            }
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Laser _laserPrefab;
        [SerializeField] private Transform _shootPosition;
        
        private Coroutine _fireCoroutine;
        
        private void OnEnable() => 
            _fireCoroutine = StartCoroutine(Fire());

        private void OnDisable()
        {
            if (_fireCoroutine != null)
                StopCoroutine(_fireCoroutine);
        }

        private IEnumerator Fire()
        {
            float minDelay = 0.5f;
            float maxDelay = 1.5f;
            
            while (true)
            {
                float randomDelay = Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(randomDelay);
                
                Instantiate(_laserPrefab, _shootPosition);
            }
        }
    }
}
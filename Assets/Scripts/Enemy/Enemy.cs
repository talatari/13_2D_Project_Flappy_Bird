using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class Enemy : MonoBehaviour
    {
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
            float minDelay = 1.5f;
            float maxDelay = 2.5f;
            
            while (true)
            {
                float randomDelay = Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(randomDelay);
                
                
            }
        }
    }
}
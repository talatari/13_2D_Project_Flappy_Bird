using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class TurbinesPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;
        
        private Camera _camera;
        private List<GameObject> _pool = new List<GameObject>();

        protected void Init(GameObject prefab)
        {
            _camera = Camera.main;

            for (int i = 0; i < _capacity; i++)
            {
                GameObject spawned = Instantiate(prefab, _container.transform);
                spawned.SetActive(false);
                
                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => p.activeSelf == false);
            
            return result != null;
        }

        public void ResetPool()
        {
            foreach (GameObject item in _pool)
                item.SetActive(false);
        }
    }
}
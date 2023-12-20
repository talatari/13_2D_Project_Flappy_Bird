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
        private List<Turbine> _turbines = new ();

        protected void Init(Turbine turbinePrefab)
        {
            _camera = Camera.main;

            for (int i = 0; i < _capacity; i++)
            {
                Turbine spawned = Instantiate(turbinePrefab, _container.transform);
                spawned.gameObject.SetActive(false);
                
                _turbines.Add(spawned);
            }
        }

        protected bool TryGetTurbine(out Turbine turbine) => 
            (turbine = _turbines.FirstOrDefault(p => p.gameObject.activeSelf == false)) != null;

        protected void DisableTurbinesAfterCamera()
        {
            Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
            
            foreach (Turbine turbine in _turbines)
                if (turbine.gameObject.activeSelf)
                {
                    if (turbine.transform.position.x < disablePoint.x)
                        turbine.gameObject.SetActive(false);
                }
        }

        public void ResetPool()
        {
            foreach (Turbine turbine in _turbines)
                turbine.gameObject.SetActive(false);
        }
    }
}
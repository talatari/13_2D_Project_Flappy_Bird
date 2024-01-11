using UnityEngine;

namespace Scripts
{
    public abstract class Laser : MonoBehaviour
    {
        protected Vector3 _direction;
        
        private float _speed = 5f;
        private float _liveTime = 3f;

        private void Start() => 
            Destroy(gameObject, _liveTime);

        private void Update() => 
            transform.Translate(_direction * (_speed * Time.deltaTime), Space.World);
    }
}
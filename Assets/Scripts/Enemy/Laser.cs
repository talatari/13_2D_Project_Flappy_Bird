using UnityEngine;

namespace Scripts
{
    public class Laser : MonoBehaviour
    {
        private Vector3 _direction;
        private float _speed = 5f;
        private float _liveTime = 3f;

        private void Start() => 
            Destroy(gameObject, _liveTime);

        private void Update() => 
            transform.Translate(Vector3.left * (_speed * Time.deltaTime), Space.World);
    }
}
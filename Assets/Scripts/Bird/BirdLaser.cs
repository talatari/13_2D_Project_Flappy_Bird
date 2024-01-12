using UnityEngine;

namespace Scripts
{
    public class BirdLaser : MonoBehaviour
    {
        private float _speed = 5f;
        private float _liveTime = 3f;
        private Bird _bird;
    
        public void Init(Vector3 startPosition, Bird bird)
        {
            transform.position = startPosition;
            _bird = bird;
        }

        private void Start() => 
            Destroy(gameObject, _liveTime);
    
        private void Update() => 
            transform.Translate(transform.right * (_speed * Time.deltaTime), Space.World);
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.Disable();
                _bird.IncreaseScore();
            }
        }
    }
}
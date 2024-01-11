using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Bird))]
    public class BirdCollisionHandler : MonoBehaviour
    {
        private Bird _bird;

        private void Start() => 
            _bird = GetComponent<Bird>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Laser laser))
                _bird.Die();
            
            if (other.TryGetComponent(out Enemy enemy))
                _bird.Die();
            
            if (other.TryGetComponent(out Ground ground))
                _bird.Die();
        }
    }
}
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
            print("BirdCollisionHandler");
            print($"other: {other.name}");

            if (other.TryGetComponent(out Enemy enemy))
                _bird.Die();
            
            if (other.TryGetComponent(out Ground ground))
                _bird.Die();
        }
    }
}
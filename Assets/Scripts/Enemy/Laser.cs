using UnityEngine;

namespace Scripts
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private Vector3 _direction;
        
        private float _speed = 5f;
        private float _liveTime = 3f;

        private void Start() => 
            Destroy(gameObject, _liveTime);

        private void Update() => 
            transform.Translate(_direction * (_speed * Time.deltaTime), Space.Self);
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            print("Laser");
            print($"other: {other.name}");
            
            if (other.TryGetComponent(out Enemy enemy))
                enemy.Disable();
            
            if (other.TryGetComponent(out Bird bird))
                bird.Die();
        }
    }
}
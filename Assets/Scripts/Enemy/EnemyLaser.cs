using UnityEngine;

namespace Scripts
{
    public class EnemyLaser : MonoBehaviour
    {
        private float _speed = 5f;
        private float _liveTime = 3f;

        public void Init(Vector3 startPosition) => 
            transform.position = startPosition;
        
        private void Start() => 
            Destroy(gameObject, _liveTime);

        private void Update() => 
            transform.Translate(transform.right * (-1 * (_speed * Time.deltaTime)), Space.World);
        
        public void SetStartPosition(Vector3 position) => 
            transform.position = position;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bird bird))
                bird.Die();
        }
    }
}
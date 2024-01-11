using UnityEngine;

namespace Scripts
{
    public class EnemyLaser : Laser
    {
        [SerializeField] private Vector3 _direction;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            print("EnemyLaser");
            print($"other: {other.name}");
            
            if (other.TryGetComponent(out Bird bird))
                bird.Die();
        }
    }
}
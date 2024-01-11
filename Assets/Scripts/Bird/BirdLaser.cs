using UnityEngine;

namespace Scripts
{
    public class BirdLaser : Laser
    {
        [SerializeField] private Vector3 _direction = new Vector3();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
                enemy.Disable();
        }
    }
}
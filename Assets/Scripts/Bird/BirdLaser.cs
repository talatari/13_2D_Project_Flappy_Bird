using System;
using UnityEngine;

namespace Scripts
{
    public class BirdLaser : MonoBehaviour
    {
        private float _speed = 5f;
        private float _liveTime = 3f;

        public void Init(Vector3 startPosition) => 
            transform.position = startPosition;

        private void Start() => 
            Destroy(gameObject, _liveTime);

        private void Update() => 
            Move();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
                enemy.Disable();
        }

        private void Move() => 
            transform.Translate(transform.right * (_speed * Time.deltaTime), Space.World);
    }
}
using System;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Bird))]
    public class BirdCollisionHandler : MonoBehaviour
    {
        private Bird _bird;

        private void Start() => 
            _bird = GetComponent<Bird>();

        private void OnTriggerEnter2D(Collider2D other) => 
            _bird.Die();
    }
}
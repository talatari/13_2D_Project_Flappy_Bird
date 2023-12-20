using System;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(BirdMover))]
    public class Bird : MonoBehaviour
    {
        private BirdMover _mover;
        private int _score;

        public event Action Dead;

        private void Start() => 
            _mover = GetComponent<BirdMover>();

        public void ResetParameters()
        {
            _score = 0;
            _mover.ResetPosition();
        }

        public void Die() => 
            Dead?.Invoke();

        public void IncreaseScore() => 
            _score++;
    }
}
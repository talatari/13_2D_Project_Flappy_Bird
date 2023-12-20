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
        public event Action<int> ScoreChanged;
        
        public int Score => _score;

        private void Start() => 
            _mover = GetComponent<BirdMover>();

        public void ResetParameters()
        {
            _score = 0;
            ScoreChanged?.Invoke(_score);
            
            _mover.ResetPosition();
        }

        public void Die() => 
            Dead?.Invoke();

        public void IncreaseScore()
        {
            _score++;
            ScoreChanged?.Invoke(_score);
        }
    }
}
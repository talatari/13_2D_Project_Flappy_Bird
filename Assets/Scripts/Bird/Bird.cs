using System;
using Unity.Mathematics;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(BirdMover))]
    public class Bird : MonoBehaviour
    {
        [SerializeField] private BirdLaser _birdLaser;
        [SerializeField] private Transform _shootPosition;
        
        private BirdMover _mover;
        private int _score;

        public event Action Dead;
        public event Action<int> ScoreChanged;
        
        public int Score => _score;

        private void Start() => 
            _mover = GetComponent<BirdMover>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                Fire();
        }

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

        private void Fire()
        {
            BirdLaser birdLaser = Instantiate(_birdLaser, transform.position, Quaternion.identity);
            birdLaser.Init(_shootPosition.position);
            birdLaser.transform.parent = null;
            birdLaser.transform.rotation = transform.rotation;
        }
    }
}
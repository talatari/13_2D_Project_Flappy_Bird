using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(BirdMover))]
    public class Bird : MonoBehaviour
    {
        private BirdMover _mover;
        private int _score;

        private void Start()
        {
            _mover = GetComponent<BirdMover>();
        }

        public void ResetGame()
        {
            _score = 0;
            _mover.ResetBird();
        }

        public void Die()
        {
            ResetGame();
            // Time.timeScale = 0;
        }

        public void IncreaseScore()
        {
            _score++;
        }
    }
}
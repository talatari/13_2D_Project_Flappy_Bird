using UnityEngine;

namespace Scripts
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField] private Bird _bird;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GameStartScreen _gameStartScreen;
        [SerializeField] private GameOverScreen _gameOverScreen;

        private void OnValidate()
        {
            if (_enemySpawner == null)
                _enemySpawner = FindObjectOfType<EnemySpawner>();
            
            if (_gameStartScreen == null)
                _gameStartScreen = FindObjectOfType<GameStartScreen>();
            
            if (_gameOverScreen == null)
                _gameOverScreen = FindObjectOfType<GameOverScreen>();
        }

        private void OnEnable()
        {
            _bird.Dead += OnBirdDead;
            _gameStartScreen.StartButtonClicked += OnStartButtonClick;
            _gameOverScreen.RestartButtonClicked += OnRestartButtonClick;
        }

        private void Start()
        {
            Time.timeScale = 0;
            _gameStartScreen.Open();
        }

        private void OnDisable()
        {
            _bird.Dead -= OnBirdDead;
            _gameStartScreen.StartButtonClicked -= OnStartButtonClick;
            _gameOverScreen.RestartButtonClicked -= OnRestartButtonClick;
        }

        private void OnBirdDead()
        {
            Time.timeScale = 0;
            _gameOverScreen.Open();
        }

        private void OnStartButtonClick()
        {
            _gameStartScreen.Close();
            StartGame();
        }

        private void OnRestartButtonClick()
        {
            _gameOverScreen.Close();
            _enemySpawner.ResetPool();
            StartGame();
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            _bird.ResetParameters();
        }
    }
}
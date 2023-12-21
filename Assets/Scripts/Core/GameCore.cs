using System;
using UnityEngine;

namespace Scripts
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField] private Bird _bird;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private GameStartScreen _gameStartScreen;
        [SerializeField] private GameOverScreen _gameOverScreen;

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
            enemySpawner.ResetPool();
            StartGame();
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            _bird.ResetParameters();
        }
    }
}
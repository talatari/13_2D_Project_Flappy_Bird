using TMPro;
using UnityEngine;

namespace Scripts
{
    public class ScoreTextRefresher : MonoBehaviour
    {
        [SerializeField] private Bird _bird;
        [SerializeField] private TMP_Text _score;

        private void OnEnable() => 
            _bird.ScoreChanged += OnRefreshChanged;

        private void OnDisable() => 
            _bird.ScoreChanged -= OnRefreshChanged;

        private void OnRefreshChanged(int score) => 
            _score.text = score.ToString();
    }
}
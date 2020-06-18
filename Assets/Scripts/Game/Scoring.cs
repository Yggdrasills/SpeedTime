using UnityEngine;
using UnityEngine.UI;

namespace SpeedTime.Game
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] private Text _scoreText = null;
        private float _score = 1;

        private void Update()
        {
            _score += Time.deltaTime * 10;
            int score = (int)_score;
            _scoreText.text = score.ToString();
        }
    }
}
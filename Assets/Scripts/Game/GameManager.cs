using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpeedTime.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }
        [SerializeField] private GameObject _gameOverCanvas = null;
        [SerializeField] private AudioSource _musicSource = null;

        private void Awake()
        {
            Instance = this;
            Time.timeScale = 1;
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            _gameOverCanvas.SetActive(true);
            _musicSource.enabled = false;
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
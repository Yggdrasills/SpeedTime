using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpeedTime.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }
        [SerializeField] private GameObject _gameOverCanvas = null;
        [SerializeField] private AudioSource _musicSource = null;
        [SerializeField] private GameObject _pauseBtn = null;
        [SerializeField] private GameObject _playBtn = null;

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

        public void PauseGame(bool isPause)
        {
            if(isPause)
            {
                _musicSource.Pause();
                Time.timeScale = 0;
            }
            else
            {
                _musicSource.UnPause();
                Time.timeScale = 1;
            }
            _pauseBtn.SetActive(!isPause);
            _playBtn.SetActive(isPause);
        }
    }
}
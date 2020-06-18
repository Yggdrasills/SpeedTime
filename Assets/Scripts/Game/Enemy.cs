using UnityEngine;

namespace SpeedTime.Game
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GameManager.Instance.GameOver();
                SoundsPlayer.Instance.PlaySound(_clip);
            }
            else if (collision.CompareTag("Destroyer"))
            {
                Destroy(gameObject);
            }
        }
    }
}
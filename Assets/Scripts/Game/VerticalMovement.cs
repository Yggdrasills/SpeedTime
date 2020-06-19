using UnityEngine;

namespace SpeedTime.Game
{
    public class VerticalMovement : MonoBehaviour
    {
        [SerializeField, Range(-80, 80)] private float _speed = 20;

        private void Update()
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
    }
}
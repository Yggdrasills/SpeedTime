using UnityEngine;

namespace SpeedTime.Game
{
    public class RoadPooler : MonoBehaviour
    {
        [SerializeField] private Transform[] _roadPieces = null;
        [SerializeField] private float _speed = 15;
        [SerializeField] private float _offset = 38.7f;

        private Vector3 _newBGPosition;
        private float _bgAmount;

        private void Awake()
        {
            _bgAmount = _roadPieces.Length;
            _newBGPosition = Vector3.up * _offset * 2;
        }

        private void Update()
        {
            for (int i = 0; i < _bgAmount; i++)
            {
                _roadPieces[i].transform.Translate(Vector2.up * _speed * Time.deltaTime);

                if (_roadPieces[i].transform.position.y > _offset) continue;

                _roadPieces[i].transform.position -= _newBGPosition;
            }
        }
    }
}
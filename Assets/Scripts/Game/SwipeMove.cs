using DG.Tweening;
using System;
using UnityEngine;

namespace SpeedTime.Game
{
    public class SwipeMove : MonoBehaviour
    {
        [SerializeField] private Transform[] _movePoints = null;
        [SerializeField] private float _moveDuration = 0.1f;

        private float _startTouchPositionX;
        private float _endTouchPositionX;
        private int _currentPosition = 2;
        private int _movePointAmount;
        private bool _isMoving;

        private void Awake()
        {
            _movePointAmount = _movePoints.Length;
        }

        private void Update()
        {
#if UNITY_EDITOR
            if(Input.GetKeyDown(KeyCode.A)) ChangePosition(-1);
            else if(Input.GetKeyDown(KeyCode.D)) ChangePosition(1);
#endif
            if (Input.touchCount <= 0) return;

            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPositionX = touch.position.x;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _endTouchPositionX = touch.position.x;

                if (_endTouchPositionX == _startTouchPositionX) return;

                ChangePosition(_endTouchPositionX < _startTouchPositionX ? -1 : 1);
            }
        }

        private void ChangePosition(int direction)
        {
            if (_isMoving) return;

            _isMoving = true;

            int newPosition = _currentPosition + direction;

            if (newPosition < 0) newPosition = 0;
            else if (newPosition >= _movePointAmount) newPosition = _movePointAmount - 1;

            _currentPosition = newPosition;

            transform.DOMoveX(_movePoints[newPosition].position.x, _moveDuration)
                .OnComplete(() => _isMoving = false);
        }
    }
}
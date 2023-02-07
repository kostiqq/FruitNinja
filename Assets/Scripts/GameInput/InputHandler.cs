using System;
using StaticData;
using UnityEngine;

namespace GameInput
{
    public class InputHandler : MonoBehaviour
    {
        private float _minSwipeDistance = 20;
        private int _mouseButtonIndex = 0;

        private Camera _gameCamera;
        private InputState _inputState;
        private Vector3 _startTouchPos;
        private Vector3 _screenOffset;
        private Vector3 _previousPos;

        public event Action<Vector3> OnSwipe;
        public event Action<Vector3> OnGetTouch;
        public event Action OnTouchFinish;

        private enum InputState
        {
            Empty,
            Touch,
            Swipe
        }

        public void Construct(InputConfig configsHandlerInputConfig, Camera gameCamera)
        {
            _minSwipeDistance = configsHandlerInputConfig.minDistance;
            _mouseButtonIndex = configsHandlerInputConfig.MouseButtonIndex;
            _gameCamera = gameCamera;
            _screenOffset = new Vector3(0, 0, -_gameCamera.transform.position.z);
        }

        public Vector3 InputVector() =>
            _previousPos - _gameCamera.ScreenToWorldPoint(Input.mousePosition);

        private void AwaitSwipe()
        {
            if (Vector3.Distance(Input.mousePosition, _startTouchPos) > _minSwipeDistance)
                _inputState = InputState.Swipe;
        }

        private void SendSwipeEvent()
        {
            OnSwipe?.Invoke(_gameCamera.ScreenToWorldPoint(Input.mousePosition + _screenOffset));
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(_mouseButtonIndex))
            {
                _previousPos = _gameCamera.ScreenToWorldPoint(Input.mousePosition);
                _inputState = InputState.Touch;
                _startTouchPos = Input.mousePosition;
                OnGetTouch?.Invoke(_gameCamera.ScreenToWorldPoint(Input.mousePosition + _screenOffset));
            }
            else if (Input.GetMouseButton(_mouseButtonIndex))
            {
                switch (_inputState)
                {
                    case InputState.Empty:
                        break;
                    case InputState.Touch:
                        AwaitSwipe();
                        break;
                    case InputState.Swipe:
                        SendSwipeEvent();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _previousPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(_mouseButtonIndex))
            {
                OnTouchFinish?.Invoke();
                _inputState = InputState.Empty;
            }
        }
    }
}

using System;
using UnityEngine;

namespace GameInput
{
    public class InputHandler : MonoBehaviour
    {
        public event Action<Vector3> OnSwipe;
        public event Action<Vector3> OnGetTouch;
        public event Action OnTouchFinish;

        [SerializeField] private float _minSwipeDistance = 20;
        [SerializeField] private Camera _mainCamera;

        private const int MouseButtonIndex = 0;

        private InputState _inputState;
        private Vector3 _startTouchPos;
        private Vector3 _screenOffset;

        private enum InputState
        {
            Empty,
            Touch,
            Swipe
        }

        public void Start()
        {
            _screenOffset = new Vector3(0, 0, -_mainCamera.transform.position.z);
        }


        private void AwaitSwipe()
        {
            if (Vector3.Distance(Input.mousePosition, _startTouchPos) > _minSwipeDistance)
                _inputState = InputState.Swipe;
        }

        private void SendSwipeEvent()
        {
            OnSwipe?.Invoke(_mainCamera.ScreenToWorldPoint(Input.mousePosition + _screenOffset));
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(MouseButtonIndex))
            {
                _inputState = InputState.Touch;
                _startTouchPos = Input.mousePosition;
                OnGetTouch?.Invoke(_mainCamera.ScreenToWorldPoint(Input.mousePosition + _screenOffset));
            }
            else
            {
                if (Input.GetMouseButton(MouseButtonIndex))
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
                }
                else
                {
                    if (Input.GetMouseButtonUp(MouseButtonIndex))
                    {
                        OnTouchFinish?.Invoke();
                        _inputState = InputState.Empty;
                    }
                }
            }
        }
    }
}

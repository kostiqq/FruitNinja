using System;
using StaticData;
using UnityEngine;

namespace GameInput
{
    public class InputHandler : MonoBehaviour
    {
        private float _minSwipeSpeed = 15;
        private int _mouseButtonIndex = 0;
        public float bladeLength;

        [SerializeField] private Camera _gameCamera;
        [SerializeField] private InputConfig configsHandlerInputConfig;
        [SerializeField] private TrailRenderer trail;

        private InputState _inputState;
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

        public void Start()
        {
            Input.multiTouchEnabled = false;

            _minSwipeSpeed = configsHandlerInputConfig.minDistance;
            _mouseButtonIndex = configsHandlerInputConfig.MouseButtonIndex;
            _screenOffset = new Vector3(0, 0, -_gameCamera.transform.position.z);
        }

        public Vector3 InputVector() =>
            inputVector;
        
        private Vector3 inputVector;

        private void UpdateInputState()
        {
            if (trail.positionCount < 2)
                return;

            Vector3[] inputPositions = new Vector3[trail.positionCount];
            trail.GetPositions(inputPositions);
            var actualPosition = inputPositions[^1];
            inputVector = actualPosition - inputPositions[^2];

            _inputState = inputVector.magnitude >= bladeLength ? InputState.Swipe : InputState.Touch;
            var speed = InputVector().magnitude / Time.deltaTime;
            
            if (inputVector.magnitude >= bladeLength && speed > _minSwipeSpeed)
                _inputState = InputState.Swipe;
            else
                _inputState = InputState.Touch;
        }

        private void SendSwipeEvent()=>
            OnSwipe?.Invoke(_gameCamera.ScreenToWorldPoint(Input.mousePosition + _screenOffset));
        
        public void Update()
        {
            if (Input.GetMouseButtonDown(_mouseButtonIndex))
            {
                _previousPos = _gameCamera.ScreenToWorldPoint(Input.mousePosition);
                _inputState = InputState.Touch;
                OnGetTouch?.Invoke(_gameCamera.ScreenToWorldPoint(Input.mousePosition + _screenOffset));
            }
            else if (Input.GetMouseButton(_mouseButtonIndex))
            {
                UpdateInputState();

                if(_inputState == InputState.Swipe)
                    SendSwipeEvent();

                _previousPos = _gameCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(_mouseButtonIndex))
            {
                OnTouchFinish?.Invoke();
                _inputState = InputState.Empty;
            }
        }
    }
}
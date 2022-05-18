using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
        [Range(0, 0.25f)] [SerializeField] private float _stickDeadZone;
        [SerializeField] private Character _serializeCharacter;

        private ICharacter _character;
        private InputScheme _inputScheme;
        private WaitForFixedUpdate _wait;
        private IEnumerator _leftStickReader;
        private IEnumerator _rightStickReader;

        #region Buttons
        
        private InputAction _leftStick;
        private InputAction _rightStick;
        private InputAction _start;
        private InputAction _select;
        private InputAction _dPadUp;
        private InputAction _dPadDown;
        private InputAction _dPadLeft;
        private InputAction _dPadRight;
        private InputAction _l1;
        private InputAction _l2;
        private InputAction _r1;
        private InputAction _r2;
        private InputAction _x;
        private InputAction _circle;
        private InputAction _square;
        private InputAction _triangle;
        
        #endregion

        private void Awake()
        {
                _character = _serializeCharacter;
                _inputScheme = new InputScheme();
                _inputScheme.Enable();
                SetKeyboardScheme();
        }

        private void SetKeyboardScheme()
        {
                _leftStick = _inputScheme.Keyboard.LeftStick;
                _rightStick = _inputScheme.Keyboard.RightStick;
                _start = _inputScheme.Keyboard.Start;
                _select = _inputScheme.Keyboard.Select;
                _dPadUp = _inputScheme.Keyboard.DPadUp;
                _dPadDown = _inputScheme.Keyboard.DPadDown;
                  _dPadLeft = _inputScheme.Keyboard.DPadUp;
                  _dPadRight = _inputScheme.Keyboard.DPadUp;
                  _l1 = _inputScheme.Keyboard.L1;
                  _l2 = _inputScheme.Keyboard.L2;
                  _r1= _inputScheme.Keyboard.R1;
                  _r2= _inputScheme.Keyboard.R2;
                  _x= _inputScheme.Keyboard.X;
                  _circle= _inputScheme.Keyboard.Circle;
                  _square= _inputScheme.Keyboard.Square;
                  _triangle= _inputScheme.Keyboard.Triangle;
        }

        private void OnEnable()
        {
                _leftStick.started += OnLeftStickActivate;
                _rightStick.started += OnRightStickActivate;
        }

        private void OnDisable()
        {
                _leftStick.started -= OnLeftStickActivate;
                _rightStick.started -= OnRightStickActivate;
        }
        
        private void OnRightStickActivate(InputAction.CallbackContext context)
        {
                if (_rightStickReader != null)
                {
                        StopCoroutine(_rightStickReader);
                }
                
                _rightStickReader = ReadAnalogInputTo(_leftStick, _character.Rotate);
                StartCoroutine(_rightStickReader);
        }

        private void OnLeftStickActivate(InputAction.CallbackContext context)
        {
                if (_leftStickReader != null)
                {
                        StopCoroutine(_leftStickReader);
                }
                
                _leftStickReader = ReadAnalogInputTo(_leftStick, _character.Move);
                StartCoroutine(_leftStickReader);
        }

        private IEnumerator ReadAnalogInputTo(InputAction inputAction, Action<Vector3> action)
        {
                while (inputAction.ReadValue<Vector2>().magnitude > _stickDeadZone)
                {
                        Vector2 inputVector = inputAction.ReadValue<Vector2>();
                        Vector3 direction = new Vector3(inputVector.x,0,inputVector.y);
                        action.Invoke(direction);
                        yield return _wait;
                }
                
                _character.Idle();
                yield break;
        }
        
        private IEnumerator ReadAnalogInputTo(InputAction inputAction, Action<float> action)
        {
                while (inputAction.ReadValue<Vector2>().magnitude > _stickDeadZone)
                {
                        Vector2 inputVector = inputAction.ReadValue<Vector2>();
                        float angle = Mathf.Atan2(inputVector.y, inputVector.x) / Mathf.PI * 360;
                        action.Invoke(angle);
                        yield return _wait;
                }
                
                _character.Idle();
                yield break;
        }
}

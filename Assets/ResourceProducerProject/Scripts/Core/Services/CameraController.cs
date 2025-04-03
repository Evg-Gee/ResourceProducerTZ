using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField] private float _panSpeed = 20f;
    [SerializeField] private FixedJoystick _joystick;
    private bool _isMobile;

    private void Awake()
    {        
        _isMobile = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
        if (_isMobile && _joystick == null)
        {
            Debug.LogError("Joystick не назначен! Добавьте его в инспекторе.");
        }
        SetJoystick();
    }

    private void Update()
    {
        if (_isMobile)
        {
            Vector3 moveInput =  GetMobileInput();
            transform.Translate(moveInput * _panSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 moveInput =  GetKeyboardInput();
            transform.Translate(moveInput * _panSpeed * Time.deltaTime);
        }
    }
     
    private Vector3 GetKeyboardInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, vertical, vertical);
    }

    private Vector3 GetMobileInput()
    {
        if (_joystick == null) return Vector3.zero;
        return new Vector3(_joystick.Horizontal, _joystick.Vertical, _joystick.Vertical);
    }
    
    private void SetJoystick()
    {
        if (!_isMobile)
        {
            _joystick.gameObject.SetActive(false);
        }
        else
        {
            _joystick.gameObject.SetActive(true);

        }
    }
}
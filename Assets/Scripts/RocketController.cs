using UnityEngine;

public class RocketController : MonoBehaviour
{
    [Header("lazer gun array")]
    [SerializeField] private GameObject[] _lazers;

    [Header("Main Setup Settings")]
    [Tooltip("How fast the ship moves to x and y")][SerializeField] private float _controleSpeed;
    [SerializeField] private float _XRange = 5f;
    [SerializeField] private float _yRange = 5f;


    [SerializeField] private float _positionPitchFactor = -2f;
    [SerializeField] private float _controleHightFactor = -10f;
    [SerializeField] private float _positionYawFactor = 2f;
    [SerializeField] private float _positionRollFactor = -5f;

    private float _horizontalMove;
    private float _verticalMove;

    private bool _controllerEnabled;

    void Start()
    {
        _controllerEnabled = false;
        Invoke("ShipControllerEnabled", 1f);
    }

    void Update()
    {
        if (_controllerEnabled)
        {
            ProcessTranlation();
            ProcessRotation();
        }
        ProcessFiring();
    }

    void ShipControllerEnabled()
    {
        _controllerEnabled = true;
    }

    private void ProcessFiring()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ControleLazers(true);
        }
        else
        {
            ControleLazers(false);
        }
    }

    private void ControleLazers(bool isActive)
    {
        foreach(var lazer in _lazers)
        {
            var emissionModule = lazer.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    private void ProcessRotation()
    {
        float RotateToX = transform.localPosition.y * _positionPitchFactor + _verticalMove * _controleHightFactor;
        float RotateToY = transform.localPosition.x * _positionYawFactor;
        float RotateToZ = _horizontalMove * _positionRollFactor;
        transform.localRotation = Quaternion.Euler(RotateToX, RotateToY, RotateToZ);
    }

    private void ProcessTranlation()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");


        float xOffSet = _horizontalMove * _controleSpeed * Time.deltaTime;
        float newPosX = transform.localPosition.x + xOffSet;
        float clampedPosX = Mathf.Clamp(newPosX, -_XRange, _XRange);


        float yOffSet = _verticalMove * _controleSpeed * Time.deltaTime;
        float newPosY = transform.localPosition.y + yOffSet;
        float clampedPosY = Mathf.Clamp(newPosY, -_yRange, _yRange);


        transform.localPosition = new Vector3(clampedPosX, clampedPosY, transform.localPosition.z);
    }
}

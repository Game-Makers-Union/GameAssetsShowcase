using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private bool autoRotate = true;
    private const float autoRotateSpeed = 1f;

    private const float manualRotateSpeed = 5f;

    [SerializeField] private MeshRenderer floor;
    [SerializeField] private Material floorDark;
    [SerializeField] private Material floorLight;
    [SerializeField] private Color32 cameraDark;
    [SerializeField] private Color32 cameraLight;

    [SerializeField] private Toggle darkModeToggle;
    [SerializeField] private Slider cameraFOVSlider;

    private void Start()
    {

    }

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, autoRotate ? autoRotateSpeed : (Input.GetAxis("Horizontal") + Input.GetAxis("Mouse X")) * manualRotateSpeed);
    }

    public void SetAutoRotate(bool value)
    {
        autoRotate = value;
    }

    public void SetDarkMode()
    {
        var value = darkModeToggle.isOn;
        floor.material = value ? floorDark : floorLight;
        Camera.main.backgroundColor = value ? cameraDark : cameraLight;
    }

    public void SetCameraFOV()
    {
        Camera.main.fieldOfView = cameraFOVSlider.value;
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}

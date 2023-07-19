using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public XRNode inputSource = XRNode.LeftHand; // Select the input source for player movement
    public float moveSpeed = 1.5f; // Adjust the player movement speed
    public XRNode cameraSnapSource = XRNode.RightHand; // Select the input source for camera snapping
    public float cameraSnapAngle = 45f; // Adjust the angle to snap the camera (in degrees)

    private CharacterController characterController;
    private Transform cameraTransform;
    private Quaternion originalCameraRotation;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        originalCameraRotation = cameraTransform.rotation;
    }

    private void Update()
    {
        // Player Movement
        InputDevice inputDevice = InputDevices.GetDeviceAtXRNode(inputSource);
        Vector2 inputAxis;
        if (inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis))
        {
            Vector3 movement = new Vector3(inputAxis.x, 0f, inputAxis.y) * moveSpeed;
            movement = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f) * movement;
            characterController.Move(movement * Time.deltaTime);
        }

        // Camera Snapping
        InputDevice cameraSnapDevice = InputDevices.GetDeviceAtXRNode(cameraSnapSource);
        Vector2 cameraSnapAxis;
        if (cameraSnapDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out cameraSnapAxis))
        {
            float snapAngleRadians = Mathf.Deg2Rad * cameraSnapAngle;
            float rotationAmount = cameraSnapAxis.x * snapAngleRadians;
            Quaternion newRotation = originalCameraRotation * Quaternion.Euler(0f, rotationAmount, 0f);
            cameraTransform.rotation = newRotation;
        }
    }
}

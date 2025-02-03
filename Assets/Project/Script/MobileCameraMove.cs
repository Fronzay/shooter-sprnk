using UnityEngine;
using YG;

public class MobileCameraMove : MonoBehaviour
{
    public float xMove; 
    public float yMove;
    public Transform playerTransform;
    public Vector2 lockAxis;
    float xRotation;
    public static float sensa;

    private void Start()
    {
    }

    private void Update()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            xMove = lockAxis.x * CameraRotate.mouseSensitivity * Time.deltaTime;
            yMove = lockAxis.y * CameraRotate.mouseSensitivity * Time.deltaTime;

            xRotation -= yMove;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerTransform.Rotate(Vector3.up * xMove);
        }
    }
}

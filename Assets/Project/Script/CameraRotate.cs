using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class CameraRotate : MonoBehaviour
{
    public static float mouseSensitivity = 100f; // ���������������� ����
    public Transform playerBody; // ������ �� ������ ���� ������
    public Camera playerCamera; // ������ �� ������ ������

    public float rotationSmoothTime = 0.1f; // ����� ����������� ��������
    private float xRotation = 0f; // ���� �������� �� ��� X
    private float yRotation = 0f; // ���� �������� �� ��� Y
    private float yRotationSmoothVelocity; // ������������� ���������� ��� ����������� Y
    private float xRotationSmoothVelocity; // ������������� ���������� ��� ����������� X

    [SerializeField] private TextMeshProUGUI textSensetivity;



    void Start()
    {
        
      
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            EnableSettingsPanel();
            if (YandexGame.EnvironmentData.isDesktop)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }

    void Update()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ������������ ����, ����� �� ����������������
            yRotation += mouseX;
            yRotation = Mathf.SmoothDamp(yRotation, yRotation + mouseX, ref yRotationSmoothVelocity, rotationSmoothTime);

            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }

    public void AddSensetivity()
    {
        mouseSensitivity += 5;
        textSensetivity.text = mouseSensitivity.ToString();
        PlayerPrefs.SetFloat("Mouse", mouseSensitivity);
    }

    public void RemoveSensetivity()
    {
        mouseSensitivity -= 5;
        textSensetivity.text = mouseSensitivity.ToString();
        PlayerPrefs.SetFloat("Mouse", mouseSensitivity);

    }

    public void EnableSettingsPanel()
    {

        if (PlayerPrefs.HasKey("Mouse"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("Mouse");

            textSensetivity.text = mouseSensitivity.ToString();
        }
        else
        {
            if (YandexGame.EnvironmentData.isDesktop)
            {
                mouseSensitivity = 70;
            }
            else
            {
                mouseSensitivity = 20;
            }
            

            PlayerPrefs.SetFloat("Mouse", mouseSensitivity);

            textSensetivity.text = mouseSensitivity.ToString();
        }
    }
}

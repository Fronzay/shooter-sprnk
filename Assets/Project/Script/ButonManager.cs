using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class ButonManager : MonoBehaviour
{

    public int sceneTransition;

    public GameObject panelMenu;

   // public CameraRotate CameraRotate;

    public GameObject panelSettings;


    public void Restart()
    {
        YandexGame.FullscreenShow();
        Time.timeScale = 1;
        if (panelMenu != null)
        {
            panelMenu.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SceneTransition()
    {
        YandexGame.FullscreenShow();
        Time.timeScale = 1;
        if (panelMenu != null)
        {
            panelMenu.SetActive(false);
        }

        SceneManager.LoadScene(sceneTransition);
    }

    private void Update()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (panelMenu.activeSelf)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Time.timeScale = 1;

                    if (panelMenu != null)
                    {
                        panelMenu.SetActive(false);
                    }
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    Time.timeScale = 0;

                    if (panelMenu != null)
                    {
                        panelMenu.SetActive(true);
                    }

                }
            }

            if (panelSettings != null)
            {
                if (panelSettings.activeSelf)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        panelSettings.SetActive(false);
                    }
                }
            }
        }

    }

    public void Pause()
    {
        if (panelMenu.activeSelf)
        {
            Time.timeScale = 1;

            if (panelMenu != null)
            {
                panelMenu.SetActive(false);
            }
        }
        else
        {
            Time.timeScale = 0;

            if (panelMenu != null)
            {
                panelMenu.SetActive(true);
            }

        }
    }

    public void Resume()
    {
        Time.timeScale = 1;

        if (panelMenu != null)
        {
            panelMenu.SetActive(false);
        }

        if (YandexGame.EnvironmentData.isDesktop)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void AddSensetivity()
    {
        CameraRotate.mouseSensitivity += 5;

        PlayerPrefs.SetFloat("Mouse", CameraRotate.mouseSensitivity);

    }

    public void RemoveSensetivity()
    {
        CameraRotate.mouseSensitivity -= 5;
        PlayerPrefs.SetFloat("Mouse", CameraRotate.mouseSensitivity);
    }

    public void OpenSettings()
    {
        panelSettings.SetActive(true);

    }
    public void CloseSettings()
    {
        panelSettings.SetActive(false);
    }
}

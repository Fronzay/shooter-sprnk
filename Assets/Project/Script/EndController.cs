using TMPro;
using UnityEngine;
using YG;

public class EndController : MonoBehaviour
{

    public static EndController Instance;
    public  float countDeadEnemy;

    public  float numberEndGame = 1;

    public  GameObject panelWin;

    public TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        UpText();
    }

    public void UpText()
    {
        textMeshProUGUI.text = $"{numberEndGame}/{countDeadEnemy}";
    }

    private void Update()
    {
        if (countDeadEnemy >= numberEndGame)
        {
            if (!panelWin.activeSelf)
            {
                Time.timeScale = 0;
                if (YandexGame.EnvironmentData.isDesktop)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                }
                panelWin.SetActive(true);
            }
        }
    }
}

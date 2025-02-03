using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public Transform playerPosition;

    public float health = 100;

    public TextMeshProUGUI textHealth;

    public GameObject paneldead;

    public void ViewHealth()
    {
        textHealth.text = health.ToString();
    }

    void Start()
    {
        if (Instance == null)
        { 
            Instance = this; 
        }
        else if (Instance == this)
        { 
            Destroy(gameObject); 
        }

    }
}

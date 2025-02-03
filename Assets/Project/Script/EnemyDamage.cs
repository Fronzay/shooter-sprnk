using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using YG;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] bool canAtack;

    [SerializeField] float delayAtack;

    private void Update()
    {
        if (Vector3.Distance(transform.position, PlayerStats.Instance.playerPosition.position) <= agent.stoppingDistance)
        {

            if (canAtack)
            {
                Debug.Log("Damage");

                PlayerStats.Instance.health -= 5;

                PlayerStats.Instance.ViewHealth();

                if (PlayerStats.Instance.health <= 0)
                {
                    Time.timeScale = 0;
                    PlayerStats.Instance.paneldead.SetActive(true);

                    if (YandexGame.EnvironmentData.isDesktop)
                    {
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true;
                    }

                }

                canAtack = false;

                StartCoroutine(ReloadAtack());
            }
        }


    }


    private IEnumerator ReloadAtack() 
    {
        yield return new WaitForSeconds(delayAtack);
        canAtack = true;
    }

}

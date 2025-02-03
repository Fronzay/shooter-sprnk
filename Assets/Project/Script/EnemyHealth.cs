using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _enemyHealth;

    public void DamageEnemy()
    {
        _enemyHealth -= 25;

        if (_enemyHealth <= 0)
        {
            SpawnEnemyRandom.countEnemyOnScene -= 1;
            EndController.Instance.countDeadEnemy++;
            EndController.Instance.UpText();
            Destroy(gameObject);
        }
    }
}

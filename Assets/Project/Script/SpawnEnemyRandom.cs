using UnityEngine;

public class SpawnEnemyRandom : MonoBehaviour
{
    [SerializeField] private Transform[] _posSpawnEnemy;
    [SerializeField] private GameObject[] _enemy;

    private float timeSpawn;

    public static int countEnemyOnScene;

    private void Update()
    {
        if (_posSpawnEnemy != null && _enemy != null)
        {
                timeSpawn += Time.deltaTime;

                if (timeSpawn > 1.5f)
                {
                    countEnemyOnScene += 1;
                    Debug.Log(_posSpawnEnemy.Length);
                    Instantiate(_enemy[Random.RandomRange(  0, _enemy.Length)], _posSpawnEnemy[Random.Range(0, 5)]);
                    timeSpawn = 0;
                }
            

        }
    
    }
}

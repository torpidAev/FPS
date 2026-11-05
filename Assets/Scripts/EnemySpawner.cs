using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject breadImpPrefab;
    
    [SerializeField] private GameObject roboMonsterPrefab;

    [SerializeField] private float breadImpInterval = 3f;

    [SerializeField] private float roboMonsterInterval = 8f;

    void Start()
    {
        StartCoroutine(spawnEnemy(breadImpInterval, breadImpPrefab));
        StartCoroutine(spawnEnemy(roboMonsterInterval, roboMonsterPrefab)); 
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    void Update()
    {
        
    }
}

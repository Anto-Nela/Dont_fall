using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange= 9;
    public int enemyCount;
    public int waveNumber= 1;
    public GameObject powerupPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        // findobjectsbytype is a method that will find all the objects in a scene that have (in this case) a specific script attached to them as a component, similar to getcomponent but it works for all objects in the scene instead of just the object the script is attached to
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i=0; i<enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange); 
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPositionX,0,spawnPositionZ); 

        return randomPos;
    }
}

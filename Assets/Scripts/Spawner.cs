using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bugPrefab;
    public Vector2 spawnAreaMin = new Vector2(-20f, -20f);
    public Vector2 spawnAreaMax = new Vector2(-15f, -15f);
    public static int totalSpawned = 0;
    float timer = 2f;     

    public float changeInterval;

    void Start()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 spawnPos = new Vector3(x, y, 0f);
        Instantiate(bugPrefab, spawnPos, Quaternion.identity);
    }
     void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval && totalSpawned < 5){
             float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 spawnPos = new Vector3(x, y, 0f);
            Instantiate(bugPrefab, spawnPos, Quaternion.identity);
            totalSpawned++;
            timer = 0f;
        }
    }
}
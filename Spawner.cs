using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bugPrefab;
    public Vector2 spawnAreaMin = new Vector2(-5f, -5f);
    public Vector2 spawnAreaMax = new Vector2(5f, 5f);
    float timer = 0f;     

    public float changeInterval = 3f;

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
        if (timer >= changeInterval){
             float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 spawnPos = new Vector3(x, y, 0f);
        Instantiate(bugPrefab, spawnPos, Quaternion.identity);
            timer = 0f;
        }
    }
}
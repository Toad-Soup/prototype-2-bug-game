using UnityEngine;

public class Movement : MonoBehaviour
{
    float moveSpeedx = 1f;
float moveSpeedy = 1f;
float timer = 0f;     
public float changeInterval = 3f;
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval){
            moveSpeedx = Random.Range(-2f, 2f);
            moveSpeedy = Random.Range(-2f, 2f);
            timer = 0f;
        }
        Vector3 pos = transform.position;
        pos.x += moveSpeedx * Time.deltaTime;
        pos.y += moveSpeedy * Time.deltaTime; 
        transform.position = pos;
    }
}

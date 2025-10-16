
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
        if (timer >= changeInterval)
        {
            moveSpeedx = Random.Range(-4f, 4f);
            moveSpeedy = Random.Range(-4f, 4f);
            timer = 0f;
        }
        Vector3 pos = transform.position;
         
        if (pos.x< -10 && moveSpeedx < 0)
        {
            moveSpeedx=moveSpeedx*-1;
        }
        if( pos.x>10&& moveSpeedx> 0){
            moveSpeedx=moveSpeedx*-1;
        }
        if (pos.y< -4 && moveSpeedy < 0)
        {
            moveSpeedy=moveSpeedx*-1;
        }
        if (pos.y > 4 && moveSpeedy > 0)
        {
            moveSpeedy = moveSpeedx * -1;
        }
        if (moveSpeedx > 0)
        {
            //TODO SET X TO DEFAULT
        }
          if (moveSpeedx < 0)
        {
            //TODO FLIP X 
        }
        pos.x += moveSpeedx * Time.deltaTime;
        pos.y += moveSpeedy * Time.deltaTime; 
        transform.position = pos;

    }
}

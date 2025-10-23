
using UnityEngine;

public class Movement : MonoBehaviour
{
    SpriteRenderer sr;
    float moveSpeedx = 1f;
    float moveSpeedy = 1f;
    float timer = 0f;
    public float changeInterval = 3f;
    public bool held = false;


    BugIdentity identity;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        identity = GetComponent<BugIdentity>();
    }
    void Update()
    {
        if (!held) {
        if (identity.nature == "energetic")
        {
            timer += Time.deltaTime;
            if (timer >= changeInterval)
            {
                moveSpeedx = Random.Range(-4, 4);
                moveSpeedy = Random.Range(-4, 4);
                timer = 0f;
            }
            Vector3 pos = transform.position;

            if (pos.x < -9.2 && moveSpeedx < 0)
            {
                moveSpeedx = moveSpeedx * -1;
            }
            if (pos.x > 9.2 && moveSpeedx > 0)
            {
                moveSpeedx = moveSpeedx * -1;
            }
            if (pos.y < -3.7 && moveSpeedy < 0)
            {
                moveSpeedy = moveSpeedy * -1;
            }
            if (pos.y > 3.7 && moveSpeedy > 0)
            {
                moveSpeedy = moveSpeedy * -1;
            }
            if (moveSpeedx > 0)
            {
                sr.flipX = true;
            }
            if (moveSpeedx < 0)
            {
                sr.flipX = false;
            }
            pos.x += moveSpeedx * Time.deltaTime;
            pos.y += moveSpeedy * Time.deltaTime;
            transform.position = pos;

        }

        if (identity.nature == "lazy")
        {
            timer += Time.deltaTime;
            if (timer >= changeInterval)
            {
                moveSpeedx = Random.Range(-1f, 1f);
                moveSpeedy = Random.Range(-1f, 1f);
                timer = 0f;
            }
            Vector3 pos = transform.position;

            if (pos.x < -9.2 && moveSpeedx < 0)
            {
                moveSpeedx = moveSpeedx * -1;
            }
            if (pos.x > 9.2 && moveSpeedx > 0)
            {
                moveSpeedx = moveSpeedx * -1;
            }
            if (pos.y < -3.7 && moveSpeedy < 0)
            {
                moveSpeedy = moveSpeedy * -1;
            }
            if (pos.y > 3.7 && moveSpeedy > 0)
            {
                moveSpeedy = moveSpeedy * -1;
            }
            if (moveSpeedx > 0)
            {
                sr.flipX = true;
            }
            if (moveSpeedx < 0)
            {
                sr.flipX = false;
            }
            pos.x += moveSpeedx * Time.deltaTime;
            pos.y += moveSpeedy * Time.deltaTime;
            transform.position = pos;

        }
        if (identity.nature == "sporadic")
        {
            timer += Time.deltaTime;
            if (timer >= changeInterval)
            {

                if (moveSpeedx > 2f)
                {
                    moveSpeedx = Random.Range(-1f, 1f);
                    moveSpeedy = Random.Range(-1f, 1f);
                }
                else
                {
                    moveSpeedx = 6;
                    moveSpeedy = 6;
                }
                timer = 0f;
            }
            Vector3 pos = transform.position;
            if (pos.x < -9.2 && moveSpeedx < 0)
            {
                moveSpeedx = moveSpeedx * -1;
            }
            if (pos.x > 9.2 && moveSpeedx > 0)
            {
                moveSpeedx = moveSpeedx * -1;
            }
            if (pos.y < -3.7 && moveSpeedy < 0)
            {
                moveSpeedy = moveSpeedy * -1;
            }
            if (pos.y > 3.7 && moveSpeedy > 0)
            {
                moveSpeedy = moveSpeedy * -1;
            }
            if (moveSpeedx > 0)
            {
                sr.flipX = true;
            }
            if (moveSpeedx < 0)
            {
                sr.flipX = false;
            }
            pos.x += moveSpeedx * Time.deltaTime;
            pos.y += moveSpeedy * Time.deltaTime;
            transform.position = pos;

        }

            if (identity.nature == "cursed")
            {
                timer += Time.deltaTime;
                if (timer >= changeInterval)
                {

                    moveSpeedx = Random.Range(-9.2f, 9.2f);
                    moveSpeedy = Random.Range(-3.7f, 3.7f);

                    timer = 0f;
                }
                
                Vector3 pos = transform.position;
                if (pos.x + moveSpeedx < -9.2f)
                {
                    moveSpeedx = -9.2f - pos.x;
                }
                if (pos.x + moveSpeedx > 9.2f)
                {
                    moveSpeedx = 9.2f - pos.x;
                }
                if (pos.y + moveSpeedy < -3.7)
                {
                    moveSpeedy = -3.7f - pos.y;
                }
                if (pos.y + moveSpeedy > 3.7)
                {
                    moveSpeedy = 3.7f - pos.y;
                }
                if (moveSpeedx > 0)
                {
                    sr.flipX = true;
                }
                if (moveSpeedx < 0)
                {
                    sr.flipX = false;
                }
                 pos.x += moveSpeedx * Time.deltaTime;
                 pos.y += moveSpeedy * Time.deltaTime;
                 transform.position = pos;
                }

                // trying to prevent bugs from overlapping as much. not sure how well thats working
                foreach (var other in FindObjectsByType<Movement>(FindObjectsSortMode.None))
            {
                if (other == this) continue;

                float minDistance = 1f;
                Vector3 direction = transform.position - other.transform.position;
                float distance = direction.magnitude;

                if (distance < minDistance && distance > 0f)
                {
                    Vector3 push = direction.normalized * (minDistance - distance) * 0.5f;
                    transform.position += push;
                }
            }


        }
    }

    public void hold()
    {
        held = true;
    }

    public void release()
    {
        held = false;
    }

}

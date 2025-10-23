using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

// tooltip that appears when hovering over a bug 
public class BugHover : MonoBehaviour
{
    public GameObject tooltipPrefab;
    private GameObject tooltipInstance;
    private BugIdentity identity;
    private Movement moveScript;
    private Canvas canvas;

    void Start()
    {
        identity = GetComponent<BugIdentity>();
        moveScript = GetComponent<Movement>();
        canvas = FindFirstObjectByType<Canvas>();
    }

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Collider2D col = GetComponent<Collider2D>();
        if (col != null && col.OverlapPoint(worldPos))
        {
            if (tooltipInstance == null)
            {
                tooltipInstance = Instantiate(tooltipPrefab, canvas.transform);
                tooltipInstance.GetComponentInChildren<TextMeshProUGUI>().text = identity.GetDescription();
            }

            tooltipInstance.transform.position = mousePos + new Vector2(-35f, 50f);
            moveScript.hold();


        }
        else
        {
            if (tooltipInstance != null)
            {
                Destroy(tooltipInstance);
                moveScript.release();

            }

            // currently no handling for when a bug dies so it just persists
            // that was unintentional but i kind of like the effect
        }
    }

}

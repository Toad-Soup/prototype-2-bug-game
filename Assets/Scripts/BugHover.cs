using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class BugHover : MonoBehaviour
{
    public GameObject tooltipPrefab;
    private GameObject tooltipInstance;
    private BugIdentity identity;
    private Canvas canvas;

    void Start()
    {
        identity = GetComponent<BugIdentity>();
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

            tooltipInstance.transform.position = mousePos + new Vector2(0, 25f);
        }
        else
        {
            if (tooltipInstance != null)
            {
                Destroy(tooltipInstance);
            }
        }
    }

}

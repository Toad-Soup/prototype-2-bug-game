using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

// handle basic click to squish a bug

public class BugSquish : MonoBehaviour
{
    public GameObject BLOOD;
    public AudioClip squishSound;

    private BugIdentity identity;
    private AudioSource squishSource;

    void Start()
    {
        identity = GetComponent<BugIdentity>();
        squishSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Collider2D col = GetComponent<Collider2D>();
        if (col != null && col.OverlapPoint(worldPos))
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                StartCoroutine(ConfirmSquish());
            }
        }
    }

    // multiple confirmations sequence
    private IEnumerator ConfirmSquish()
    {
        // pause
        Time.timeScale = 0f;

        bool confirmed = false;

        confirmed = ShowConfirmation("Do you want to squish this bug?");
        if (!confirmed) { Time.timeScale = 1f; yield break; }

        confirmed = ShowConfirmation("Confirm the identity of the bug you wish to squish?\n\n" + identity.GetDescription());
        if (!confirmed) { Time.timeScale = 1f; yield break; }

        confirmed = ShowConfirmation("Are you certain you want to end this bug's life? This action cannot be undone.");
        if (!confirmed) { Time.timeScale = 1f; yield break; }

        confirmed = ShowConfirmation("...please don't..");
        if (!confirmed) { Time.timeScale = 1f; yield break; }

        Instantiate(BLOOD, transform.position, Quaternion.identity, transform.parent);
        squishSource.PlayOneShot(squishSound);
        Spawner.totalSpawned--;
        Destroy(gameObject);

        //permenantly stop music here
        if (SoundManager.BGM != null)
        {
            SoundManager.BGM.Pause();
        }

        // unpause
        Time.timeScale = 1f;
        yield break;
    }

    // unity editor popup for now, can add ui w prefab later if we need to make a real build
    private bool ShowConfirmation(string message)
    {
        // using unity editor popup for now 
#if UNITY_EDITOR
        return UnityEditor.EditorUtility.DisplayDialog("Squish Bug?", message, "Yes", "No");
#else
        //replace with ui panel
        Debug.Log(message + " (auto-confirmed for testing)");
        return true;
#endif
    }
}

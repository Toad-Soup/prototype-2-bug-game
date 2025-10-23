using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource BGM;

    void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        BGM = GetComponent<AudioSource>();
    }
}

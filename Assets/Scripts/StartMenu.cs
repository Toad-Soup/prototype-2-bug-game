using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void onStartClick()
    {
        SceneManager.LoadScene("Tension Level");
    }  

    // // Update is called once per frame
    // public void onExitClick()
    // {
        
    // }
}
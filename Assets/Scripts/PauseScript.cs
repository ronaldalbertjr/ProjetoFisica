using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour 
{
    [SerializeField]
    GameObject pauseCanvas;
	void Start () 
    {
        pauseCanvas.SetActive(false);
	}
	void Update () 
    {
	    if(Input.GetKey(KeyCode.Escape))
        {
            OnPause();
        }
	}
    public void OnPause()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }
    public void OnResume()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }
    public void OnBackToMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Menu");
    }
    public void OnRestartLevel()
    {
        Time.timeScale = 1;
        Application.LoadLevel("MainScene");
    }
}

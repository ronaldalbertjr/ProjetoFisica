using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
    public void OnPlay()
    {
        Application.LoadLevel("MainScene");
    }
    public void OnExit()
    {
        Application.Quit();
    }
}

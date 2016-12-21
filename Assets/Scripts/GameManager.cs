using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    float time;
    bool player1Turn;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;
    [SerializeField]
    GameObject miraPlayer1;
    [SerializeField]
    GameObject miraPlayer2;
	void Awake ()
    {
        player1Turn = true;
        player1.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;
        time = 0;
	
	}
	
	void Update ()
    {
        if(player1Turn)
        {
            player2.GetComponent<Animator>().SetBool("Walking", false);
            player2.GetComponent<PlayerMovement>().enabled = false;
            player1.GetComponent<PlayerMovement>().enabled = true;
            miraPlayer1.SetActive(true);
            miraPlayer2.SetActive(false);
            cam.GetComponent<CameraMovement>().player1 = player1;
        }
        else
        {
            player1.GetComponent<Animator>().SetBool("Walking", false);
            player1.GetComponent<PlayerMovement>().enabled = false;
            player2.GetComponent<PlayerMovement>().enabled = true;
            miraPlayer1.SetActive(false);
            miraPlayer2.SetActive(true);
            cam.GetComponent<CameraMovement>().player1 = player2;
        }

        ChangeTurn();
	}

    void ChangeTurn()
    {
        time += Time.deltaTime;
        if(time > 10)
        {
            player1Turn = !player1Turn;
            time = 0;
        }
    }
}

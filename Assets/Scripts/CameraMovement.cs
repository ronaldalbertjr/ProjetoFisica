using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
    [HideInInspector]
    public GameObject player1;
    [SerializeField]
    Transform[] camPos;
    [SerializeField]
    Vector3 offset;
	void Start () 
    {
	
	}
	void Update () 
    {
	    if(player1.transform.position.x > camPos[0].position.x && player1.transform.position.x < camPos[1].position.x)
        {
            transform.position = player1.transform.position + offset;
        }

        else if(player1.transform.position.x < camPos[0].position.x)
        {
            transform.position = camPos[0].position;
        }
        else if(player1.transform.position.x > camPos[1].position.x)
        {
            transform.position = camPos[1].position;
        }
	}
}

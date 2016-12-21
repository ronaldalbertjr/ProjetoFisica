using UnityEngine;
using System.Collections;

public class BombForce : MonoBehaviour {

	public float force;
	GameObject mira;
    float time;

	void Start () 
	{
		mira = GameObject.Find("Mira");
	}
	
	void Update () 
	{
		if(force != 0)
		{
			transform.Translate(Vector2.right * force * Time.deltaTime);
		}
        time += Time.deltaTime;
        if(time > 2)
        {
            Destroy(gameObject);
        }
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		mira.GetComponent<MiraeAtira> ().atirar = true;
		mira.GetComponent<MiraeAtira> ().defineForce = false;
		mira.GetComponent<MiraeAtira> ()._scale = new Vector3 (1f, 1f, 1f);
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("oi");
        }
	}

	void OnBecameInvisible()
	{
		mira.GetComponent<MiraeAtira> ().atirar = true;
		mira.GetComponent<MiraeAtira> ().defineForce = false;
		mira.GetComponent<MiraeAtira> ()._scale = new Vector3 (1f, 1f, 1f);
		Destroy(gameObject);
	}
}

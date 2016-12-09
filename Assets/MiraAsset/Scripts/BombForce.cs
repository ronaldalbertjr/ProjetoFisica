using UnityEngine;
using System.Collections;

public class BombForce : MonoBehaviour {

	public float force;
	GameObject mira;

	void Start () 
	{
		mira = GameObject.Find("Mira");
	}
	
	void Update () 
	{
		if(force != null)
		{
			transform.Translate(Vector2.right * force * Time.deltaTime);
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		mira.GetComponent<MiraeAtira> ().atirar = true;
		mira.GetComponent<MiraeAtira> ().defineForce = false;
		mira.GetComponent<MiraeAtira> ()._scale = new Vector3 (1f, 1f, 1f);
		Destroy(gameObject);
	}

	void OnBecameInvisible()
	{
		mira.GetComponent<MiraeAtira> ().atirar = true;
		mira.GetComponent<MiraeAtira> ().defineForce = false;
		mira.GetComponent<MiraeAtira> ()._scale = new Vector3 (1f, 1f, 1f);
		Destroy(gameObject);
	}
}

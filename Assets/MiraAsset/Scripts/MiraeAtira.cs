﻿using UnityEngine;
using System.Collections;

public class MiraeAtira : MonoBehaviour {

	public Vector3 _scale = new Vector3 (1f, 1f, 1f);

	private GameObject player;
	public GameObject bomba;

	private float limitZ = 0f;

	public bool atirar = true;
	public bool defineForce = false;
	public bool prontoPraAtirar = false;
	bool irVoltar = false;


	void Start () 
	{
		player = GameObject.Find (transform.parent.name);
	}
	
	void Update () 
	{
		if(atirar)
		{
			if(!defineForce)
			{
				if(Input.GetKey(KeyCode.UpArrow) && limitZ < 60f)
				{
					transform.RotateAround(player.GetComponent<Transform>().position, Vector3.forward, 20 * Time.deltaTime);
					limitZ += 20 * Time.deltaTime;
				}
				else if(Input.GetKey(KeyCode.DownArrow) && limitZ > -20f)
				{
					transform.RotateAround(player.GetComponent<Transform>().position, Vector3.back, 20 * Time.deltaTime);
					limitZ -= 20 * Time.deltaTime;
				}

				if(Input.GetKeyDown(KeyCode.Space) && !defineForce)
				{
					defineForce = true;
				}
			}

			if(defineForce)
			{
				if(!irVoltar)	_scale.x += 0.5f * Time.deltaTime;
				if(_scale.x > 2f)	irVoltar = true;

				if(irVoltar)	_scale.x -= 0.5f * Time.deltaTime;
				if(_scale.x < 1f)	irVoltar = false;
			}
		}

		if(Input.GetKeyUp(KeyCode.Space) && atirar && defineForce)
		{
			Instantiate(bomba, this.transform.position, this.transform.rotation);
			GameObject bombaInst = GameObject.Find("Bullet(Clone)");
            if (!player.GetComponent<PlayerMovement>().isFacingRight)
            {
                bombaInst.GetComponent<BombForce>().force = 7.5f * _scale.x;
            }
            else
            {
                bombaInst.GetComponent<BombForce>().force = 7.5f * _scale.x * -1;
                bombaInst.transform.rotation = Quaternion.Euler(bombaInst.transform.eulerAngles.x, bombaInst.transform.eulerAngles.y * -1, bombaInst.transform.eulerAngles.z);
            }
			atirar = false;
		}	

		transform.localScale = _scale;
	}
}

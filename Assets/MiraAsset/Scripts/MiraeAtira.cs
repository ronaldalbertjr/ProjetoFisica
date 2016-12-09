using UnityEngine;
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
			bombaInst.GetComponent<BombForce>().force = 7.5f * _scale.x;
			atirar = false;
		}	

		transform.localScale = _scale;
	}

/*	void OnGUI()
	{
		DrawQuad (new Rect (50f, 200f, _scale.x * 10f, 10f), Color.red);
	}

	void DrawQuad(Rect position, Color color) 
	{
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}	*/
}

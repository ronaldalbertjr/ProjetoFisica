using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    float w;
    float jumpAnimAux;
    [HideInInspector]
    public bool isFacingRight;
    bool walkAnimAux;
    Animator anim;
    Rigidbody2D rb;
    [SerializeField]
    Image lifebar;

	void Start ()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        w = Input.GetAxis("Horizontal");
        walkAnimAux = (w != 0);
        rb.velocity = new Vector2(w * speed, 0);
        anim.SetBool("Walking", walkAnimAux);

        if(isFacingRight && w > 0)
        {
            Flip();
        }
        else if(!isFacingRight && w < 0)
        {
            Flip();
        }

        if(lifebar.fillAmount <= 0)
        {
            Destroy(gameObject);
        }
	}

    protected void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void LoseLife()
    {
        lifebar.fillAmount -= 0.05f;
    }
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    float w;
    float jumpAnimAux;
    bool isFacingRight;
    bool walkAnimAux;
    Animator anim;
    Rigidbody2D rb;

	void Start ()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        Debug.Log(rb.velocity.y);
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
	}

    protected void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlatformSpring : MonoBehaviour
{
	public float jumpForce = 10f;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.y <= 0f)
		{
			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				Vector2 velocity = rb.velocity;
				velocity.y = jumpForce;
				rb.velocity = velocity;
			}
		}
	}
}




/*
public class PlatformSpring : MonoBehaviour
{
    public int springForce = 900;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y<=0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * springForce);
        }
              
    }
}
*/
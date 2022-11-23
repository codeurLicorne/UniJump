using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

	public float movementSpeed = 10f;

	Rigidbody2D rb;

	float movement = 0f;

	public Text scoreText;
	private float topScore = 0;

	public GameObject jetpackAnim;
	private bool hasJetpack;
	public float jetSpeed;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}


	void Update()
	{
		if(movement < 0)
        {
			transform.localScale = new Vector3(1, 1, 1);
			//this.GetComponent<SpriteRenderer>().flipX = true;
        }
		else
        {
			transform.localScale = new Vector3(-1, 1, 1);
			//this.GetComponent<SpriteRenderer>().flipX = false;
		}


		movement = Input.GetAxis("Horizontal") * movementSpeed;

		if(rb.velocity.y > 0 && transform.position.y > topScore)
        {
			topScore = transform.position.y;
        }

		

		scoreText.text = "Score: " + Mathf.Round(topScore).ToString();

		
	}

	void FixedUpdate()
	{
		if (hasJetpack)
		{
			rb.velocity = new Vector2(movement, jetSpeed);
		}
        else
        {
			Vector2 velocity = rb.velocity;
			velocity.x = movement;
			rb.velocity = velocity;

		}
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("rocket"))
        {
			Destroy(collision.gameObject);
			jetpackAnim.SetActive(true);
			hasJetpack = true;
			StartCoroutine(Jetpack());
        }
    }

	IEnumerator Jetpack()
    {
		
		yield return new WaitForSeconds(3);
		hasJetpack = false;
		jetpackAnim.SetActive(false);
	}
}
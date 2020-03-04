using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float speed = 5f;

	public Animator animator;
	public Rigidbody2D rb;

	Vector2 move;

	SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
		sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		move.x = Input.GetAxisRaw("Horizontal");

		animator.SetFloat("Speed", Mathf.Abs(move.x));

		if (Input.GetButtonDown("Fire1"))
		{
			animator.SetTrigger("Attack");
		}
    }

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

		if (move.x < 0f)
		{
			sr.flipX = true;
		} else if (move.x > 0f)
		{
			sr.flipX = false;
		}
	}
}

using UnityEngine;
using System.Collections;

public class CharMovement : MonoBehaviour 
{

	public float jumpSpeed = 600.0f;
	public bool grounded = false;
	public bool doubleJump = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	[SerializeField]public Animation anim;
	public Rigidbody rb;
	public float vSpeed;

	void Awake()
	{
		anim = GetComponentInChildren<Animation>();
        rb = GetComponent<Rigidbody>();
	}

}

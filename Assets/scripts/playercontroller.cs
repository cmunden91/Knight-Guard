using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private player play;
    [SerializeField]
    private Transform ground;
    [SerializeField]
    private Transform ceiling;
    [SerializeField]
    private float groundcircleradius;
    [SerializeField]
    private bool isgrounded;
    [SerializeField]
    private LayerMask whatisground;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		isgrounded = Physics2D.OverlapCircle (ground.position, groundcircleradius, whatisground);
		if (Input.GetButtonDown ("Jump")) {
			if (isgrounded == true) {
				int jump = play.Jumpheight;
				rb.velocity = Vector2.up * jump;
			}
		}
		if (Input.GetAxis ("Horizontal") > 0) {
			int move = play.Movementspeed;
			rb.velocity = new Vector2 (play.Movementspeed, rb.velocity.y);
		}
		if (Input.GetAxis ("Horizontal") < 0) {
			int move = play.Movementspeed;
			rb.velocity = new Vector2 (0 - play.Movementspeed, rb.velocity.y);
		}
        
	}
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision);
	}
    [HideInInspector]
    public bool Isgrounded
    {
        get { return isgrounded; }
        set { isgrounded = value; }
    }


}
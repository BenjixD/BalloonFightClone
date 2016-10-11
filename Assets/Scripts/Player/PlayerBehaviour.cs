using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    Rigidbody2D playerRB;
    float direction, lift;
    public float horizontalSpd = 0.4f;
    public float verticalSpd = 2.0f;
    public float maxHorizontalSpd = 6.0f;

    //Simulate Button spamming
    bool verticalCD;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
        direction = 0.0f;
        lift = 0.0f;
        verticalCD = false;
    }
	
	// Update is used for receiving input
	void Update () {
        direction = Input.GetAxisRaw("Horizontal");
        if (!verticalCD && Input.GetAxisRaw("Vertical") > 0)
        {
            lift = Input.GetAxisRaw("Vertical");
        }
        else {
            lift = 0.0f;
        }    
        verticalCD = Input.GetAxisRaw("Vertical") != 0.0f;

    }

    // FixedUpdate is used for movement and methods involving rigidbody
    void FixedUpdate() {
        Vector2 playerMove = new Vector2(direction * horizontalSpd, lift * verticalSpd);
        playerRB.AddForce(playerMove, ForceMode2D.Impulse);
        if (Mathf.Abs(playerRB.velocity.x) > maxHorizontalSpd)
        {
            playerRB.velocity = new Vector2(Mathf.Sign(playerRB.velocity.x)*maxHorizontalSpd, playerRB.velocity.y);
        }
    }
}

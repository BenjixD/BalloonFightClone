using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    Rigidbody2D playerRB;
    float direction, lift;
    public float horizontalSpd = 0.6f;
    public float verticalSpd = 0.8f;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
        direction = 0.0f;
        lift = 0.0f;
    }
	
	// Update is used for receiving input
	void Update () {
            direction = Input.GetAxisRaw("Horizontal");
            lift = Input.GetAxisRaw("Vertical");

    }

    // FixedUpdate is used for movement and methods involving rigidbody
    void FixedUpdate() {
        Vector2 playerMove = new Vector2(direction * horizontalSpd, lift * verticalSpd);
        playerRB.AddForce(playerMove, ForceMode2D.Impulse);
    }
}

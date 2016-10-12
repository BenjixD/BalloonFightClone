using UnityEngine;
using System.Collections;

public class LifeCount : MonoBehaviour {

    public int lives = 2;
    public Color green = new Color(66 / 255f, 1.0f, 190 / 255f, 1);
    public Color orange = new Color(1.0f, 142/255f, 0, 1);
    public Color red = new Color(1, 0, 0, 1);
    Color[] lifeColors;

    GameObject lifeline;
    SpriteRenderer knot;
	PlayerBehaviour pb;

	// Use this for initialization
	void Start () {
        lifeline = transform.Find("Rope/life").gameObject;
        knot = lifeline.GetComponent<SpriteRenderer>();
        lifeColors = new Color[] {red, orange, green};
        knot.color = lifeColors[lives - 1];
		pb = GetComponent<PlayerBehaviour>();
		pb.playerAnim.SetInteger ("life", lives);
    }


    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("You lost a life!");
        lives -= 1;
        if (lives <= 0) {
            Debug.Log("You died!");
            deathAnimation();
        }
        else
        {
            knot.color = lifeColors[lives -1];
			Debug.Log (knot.color);
        }
    }

    void deathAnimation() {
		pb.playerAnim.SetInteger ("life", lives);
        pb.enabled = false;
        Destroy(lifeline);
        GetComponent<Collider2D>().enabled = false;
        Rigidbody2D playerModel = GetComponent<Rigidbody2D>();
        playerModel.freezeRotation = false;
        playerModel.AddTorque(20);
        Destroy(this, 5.0f);

		GameObject rope = transform.Find ("Rope").gameObject;
		rope.transform.parent = null;
		Rigidbody2D ropeModel = rope.AddComponent<Rigidbody2D>();
		ropeModel.isKinematic = true;
		ropeModel.velocity = new Vector2 (0,5);
    }
}

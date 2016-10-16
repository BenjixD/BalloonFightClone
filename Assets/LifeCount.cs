using UnityEngine;
using System.Collections;

public class LifeCount : MonoBehaviour {

    public int lives = 2;
    public Color green = new Color(66 / 255f, 1.0f, 190 / 255f, 1);
    public Color orange = new Color(1.0f, 142/255f, 0, 1);
    public Color red = new Color(1, 0, 0, 1);
	public Color transparent = new Color (0, 0, 0, 0);
	public Color currentColor;
    Color[] lifeColors;

    GameObject lifeline;
    SpriteRenderer knot;
	PlayerBehaviour pb;

	// Use this for initialization
	void Start () {
        lifeline = transform.Find("Rope/life").gameObject;
        knot = lifeline.GetComponent<SpriteRenderer>();
        lifeColors = new Color[] {transparent, red, orange, green};
		knot.color = currentColor = lifeColors[lives];
		pb = GetComponent<PlayerBehaviour>();
		pb.playerAnim.SetInteger ("life", lives);
    }


    void OnTriggerEnter2D(Collider2D col) {
        lives -= 1;
		knot.color = currentColor = lifeColors[lives];
		pb.playerAnim.SetInteger ("life", lives);

		if (lives <= 0) {
			Debug.Log("You died!");
			deathAnimation();
		}

		Debug.Log (knot.color);
		Debug.Log("You lost a life!");
    }

    void deathAnimation() {
        pb.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Rigidbody2D playerModel = GetComponent<Rigidbody2D>();
        playerModel.freezeRotation = false;
        playerModel.AddTorque(20);
        Destroy(gameObject, 3.0f);

		GameObject rope = transform.Find ("Rope").gameObject;
		rope.transform.parent = null;
		Rigidbody2D ropeModel = rope.AddComponent<Rigidbody2D>();
		ropeModel.isKinematic = true;
		ropeModel.velocity = pb.ropeRelease;
        Destroy(rope, 3.0f);
    }
}

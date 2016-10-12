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

	// Use this for initialization
	void Start () {
        lifeline = transform.Find("Rope/life").gameObject;
        knot = lifeline.GetComponent<SpriteRenderer>();
        lifeColors = new Color[] {red, orange, green};
        knot.color = lifeColors[lives - 1];
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
        }
    }

    void deathAnimation() {
        GetComponent<PlayerBehaviour>().enabled = false;
        Destroy(lifeline);
        GetComponent<Collider2D>().enabled = false;
        Rigidbody2D playerModel = GetComponent<Rigidbody2D>();
        playerModel.freezeRotation = false;
        playerModel.AddTorque(20);
        Destroy(this, 5.0f);
        
    }
}

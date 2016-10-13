using UnityEngine;
using System.Collections;

public class GhostBehaviour : MonoBehaviour {

	public Animator referencedAnim;		//Reference given by screenWrapper at instantiation
	public LifeCount referencedLife;	//Reference to the life object given by screenWrapper


	public Animator myAnim;			//myself
	public GameObject lifeline; 	//my life			

	void start(){
	}

	// Update is called once per frame
	void Update () {
		//Update Anime Values (Copy from reference)
		myAnim.SetBool("grounded", referencedAnim.GetBool("grounded")); 
		myAnim.SetBool("isFlying", referencedAnim.GetBool("isFlying"));
		myAnim.SetFloat("velocity", referencedAnim.GetFloat("velocity"));
		myAnim.SetInteger("life", referencedAnim.GetInteger("life"));

		//Update the life Color
		lifeline.GetComponent<SpriteRenderer>().color = referencedLife.currentColor;

		//run deathAnim
		if (referencedLife.lives <= 0) {
			deathAnimation();
			enabled = false;
		}
	}

	void deathAnimation(){
		Rigidbody2D playerModel = GetComponent<Rigidbody2D>();
		playerModel.freezeRotation = false;
		playerModel.AddTorque(20);
		GameObject rope = transform.Find ("Rope").gameObject;
		rope.transform.parent = null;
		Rigidbody2D ropeModel = rope.AddComponent<Rigidbody2D>();
		ropeModel.isKinematic = true;
		ropeModel.velocity = new Vector2 (0,5);
		//Destroy(rope, 3.0f);
	}
}

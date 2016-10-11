using UnityEngine;
using System.Collections;

public class cameraInfo : MonoBehaviour {

	//Private
	private static float screenWidth;
	private static float screenHeight;
	private static Vector3 screenBottomLeft;
	private static Vector3 screenTopRight;
	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main; //Get the camera values
		screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
		screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

		//Find the width and height of screen based on world size
		screenWidth = screenTopRight.x - screenBottomLeft.x;	
		screenHeight = screenTopRight.y - screenBottomLeft.y;
	}

	//Getter Functions to obtain value of screen Width and Height
	public float getScreenWidth(){
		return screenWidth;
	}

	public float getScreenHeight(){
		return screenHeight;
	}

	public Vector3 getBottomLeft(){
		return screenBottomLeft;
	}

	public Vector3 getTopRight(){
		return screenTopRight;
	}
}

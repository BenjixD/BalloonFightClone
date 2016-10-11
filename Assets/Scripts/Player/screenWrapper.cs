using UnityEngine;
using System.Collections;

public class screenWrapper : MonoBehaviour {

	//Ghost Prefab
	public GameObject ghostPrefab;

	//Ghost Characters on wrap (left, right)
	private GameObject[] ghosts = new GameObject[2];
	private cameraInfo cam;

	void createGhosts(){
		for (int i = 0; i < ghosts.Length; i++) {
			ghosts[i] = Instantiate(ghostPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		}
	}

	void positionGhosts(){
		Vector3 ghostPosition = transform.position;

		//Left Ghost
		ghostPosition.x = transform.position.x - cam.getScreenWidth();
		ghostPosition.y = transform.position.y;
		ghosts[0].transform.position = ghostPosition;

		//Right Ghost
		ghostPosition.x = transform.position.x + cam.getScreenWidth();
		ghostPosition.y = transform.position.y;
		ghosts[1].transform.position = ghostPosition;
	}

	void swapWithGhost(){
		foreach (GameObject ghost in ghosts) {
			if (ghost.transform.position.x >= cam.getBottomLeft().x && 
				ghost.transform.position.x <= cam.getTopRight().x) {
				transform.position = ghost.transform.position;
				break;
			}
		}
	}

	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera").GetComponent<cameraInfo> ();
		createGhosts ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		swapWithGhost ();
		positionGhosts ();
	}
}

using UnityEngine;
using System.Collections;

public class BGCollectorScript : MonoBehaviour {

	private float lastBGX;
	private float lastGroundX;

	private GameObject[] backgournds;
	private GameObject[] grounds;

	// Use this for initialization
	void Awake () {
		backgournds = GameObject.FindGameObjectsWithTag ("Background");
		grounds = GameObject.FindGameObjectsWithTag ("Ground");

		lastBGX = backgournds [0].transform.position.x;
		lastGroundX = grounds [0].transform.position.x;

		for (int i = 1; i < backgournds.Length; i++) {
			if (lastBGX < backgournds [i].transform.position.x) {
				lastBGX = backgournds [i].transform.position.x;
			}
		}
		for (int i = 1; i < grounds.Length; i++) {
			if (lastGroundX < grounds [i].transform.position.x) {
				lastGroundX = grounds [i].transform.position.x;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Background") {
			Vector3 temp = target.transform.position;
			float BGWidth = ((BoxCollider2D)target).size.x;
			temp.x = lastBGX + BGWidth;
			lastBGX = temp.x;
			target.transform.position = temp;
		}
		if (target.tag == "Ground") {
			Vector3 temp = target.transform.position;
			float GroundWidth = ((BoxCollider2D)target).size.x;
			temp.x = lastGroundX + GroundWidth;
			lastGroundX = temp.x;
			target.transform.position = temp;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}

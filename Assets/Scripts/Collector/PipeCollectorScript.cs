using UnityEngine;
using System.Collections;

public class PipeCollectorScript : MonoBehaviour {

	private GameObject[] pipeHolders;
	private float pipeDistance = 2.5f;
	private float pipeYMax = 3f;
	private float pipeYmin = -1.5f;
	private float lastPipeX;

	void Awake(){
		pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");
		lastPipeX = pipeHolders [0].transform.position.x;
		for (int i = 0; i < pipeHolders.Length; i++) {
			Vector3 temp = pipeHolders [i].transform.position;
			temp.y = Random.Range (pipeYmin, pipeYMax);
			pipeHolders [i].transform.position = temp;
			if (lastPipeX < pipeHolders [i].transform.position.x) {
				lastPipeX = pipeHolders [i].transform.position.x;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		print (target.tag);
		if (target.tag == "PipeHolder") {
			Vector3 temp = target.transform.position;

			temp.x = lastPipeX + pipeDistance;
			temp.y = Random.Range (pipeYmin, pipeYMax);

			lastPipeX = temp.x;
			target.transform.position = temp;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

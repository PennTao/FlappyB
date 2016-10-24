using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour {
	public static BirdScript instance;

	[SerializeField]
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private Animator anim;

	private float forwardSpeed = 3f;

	private float bounceSpeed = 4f;

	private bool didFlap;
	public bool isAlive;

	private Button flapButton;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
		isAlive = true;
		flapButton = GameObject.FindGameObjectWithTag ("FlapButton").GetComponent<Button> ();
		flapButton.onClick.AddListener (() => FlapTheBird ());
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (isAlive) {
			Vector3 temp = transform.position;
			temp.x += forwardSpeed * Time.deltaTime;
			transform.position = temp;

			if (didFlap) {
				didFlap = false;
				myRigidBody.velocity = new Vector2 (0, bounceSpeed);
				anim.SetTrigger ("flap");
			}

			if (myRigidBody.velocity.y >= 0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				float angle = 0f;
				angle = Mathf.Lerp (0, -75, -myRigidBody.velocity.y / 7);
				transform.rotation = Quaternion.Euler (0, 0, angle);
			}
		}
	}

	void SetCameraX(){
		CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x);
	}
	public float GetPositionX(){
		return transform.position.x;
	}

	public void FlapTheBird(){
		didFlap = true;
	}
}

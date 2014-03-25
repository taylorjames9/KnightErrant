using UnityEngine;
using System.Collections;

public class KnightController : MonoBehaviour {


	public Transform target1;
	public Transform target2; 
	public Transform target3; 
	public Transform target4; 
	public Transform target5; 
	public Transform target6; 
		//Transform target = null;

	public Transform target;

		float speed = 2.0f;
	bool move;
		//Vector3 wantedPosition;

	//float speed = 5.0f; 

	// Use this for initialization
	void Start () {


	}
	



		void Update(){
				if (GameManager.myDestination != null) {
						target = GameManager.myDestination;
						float step = speed * Time.deltaTime;
						transform.position = Vector2.MoveTowards(transform.position, target.position, step);
				}


		}
		/*void FixedUpdate () {

				if (Input.GetMouseButtonDown (0)) {
						RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up);
						if (hit != null) {
								print (hit.collider);
						}
				}
	}*/
}
	


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KnightController : MonoBehaviour {


	Transform target;

	float speed = 2.0f;
	bool move;
		//Vector3 wantedPosition;

	private Animator animator;

	//float speed = 5.0f; 

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		target = transform;

	}

		void Update(){

				float dist = Vector3.Distance(target.position, transform.position);
				//print ("Dist =" + dist);

				if (GameManager.myDestination != null) {
						target = GameManager.myDestination;
						float step = speed * Time.deltaTime;
						transform.position = Vector2.MoveTowards(transform.position, target.position, step);
					if(target.position.x < transform.position.x){
						animator.SetInteger("Direction", 2);
					} else if(target.position.x > transform.position.x){
						animator.SetInteger("Direction", 1);
					}
						if (dist <= 0.1f) {
						animator.SetInteger("Direction", 0);
					}
				}
		}
}
	


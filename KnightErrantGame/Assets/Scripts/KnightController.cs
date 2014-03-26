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

	private Animator animator;

	//float speed = 5.0f; 

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		//target = transform;

	}

		void Update(){
				if (GameManager.myDestination != null) {
						target = GameManager.myDestination;
						float step = speed * Time.deltaTime;
						transform.position = Vector2.MoveTowards(transform.position, target.position, step);
					if(target.position.x < transform.position.x){
						print ("Should be facing left");
						animator.SetInteger("Direction", 2);
					} else if(target.position.x > transform.position.x){
						print("Should be facing right");
						animator.SetInteger("Direction", 1);
					}

					if (target.position.x == transform.position.x) {
						animator.SetInteger("Direction", 0);
					}
				}
		}
}
	


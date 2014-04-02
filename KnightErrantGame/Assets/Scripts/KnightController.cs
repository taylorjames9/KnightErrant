using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KnightController : MonoBehaviour {


	Transform target;

	public AudioClip knightWalk;

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
				//audio.Play();
				float dist = Vector3.Distance(target.position, transform.position);
				//print ("Dist =" + dist);

				if (GameManager.myDestination != null) {
						target = GameManager.myDestination;
						float step = speed * Time.deltaTime;
						transform.position = Vector2.MoveTowards(transform.position, target.position, step);
					if(target.position.x < transform.position.x){
						animator.SetInteger("Direction", 2);
								audio.clip = knightWalk;
								audio.Play();
								//audio.Play(knightWalk);
								//audio.Play(); 
					} else if(target.position.x > transform.position.x){
						animator.SetInteger("Direction", 1);
								audio.clip = knightWalk;
								audio.Play();
								//audio.Play(knightWalk);
								//audio.Play(); 
					}
						if (dist <= 0.1f) {
						animator.SetInteger("Direction", 0);
								audio.clip = knightWalk;
								audio.Stop ();
					}
				}
		}
}
	


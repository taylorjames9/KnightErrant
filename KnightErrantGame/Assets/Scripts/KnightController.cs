  using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KnightController : MonoBehaviour {


	Transform target;

		//public AudioClip knightWalk;

		public GameObject knightManager;

	float speed = 2.0f;
	bool move;
		//Vector3 wantedPosition;

	private Animator animator;
	public static bool isMoving;

		public enum CurrentAnimationState {Poof, IdleWait, WalkingRight, WalkingLeft, LayingDown, LayingThere, StandingUp, SittingToRead, StaySeated, StandFromReading, PokeDragon};
		public static CurrentAnimationState currentAnimState;

	//float speed = 5.0f; 

	// Use this for initialization
	void Start () {
		
				currentAnimState = CurrentAnimationState.Poof;
		animator = this.GetComponent<Animator>();
		target = transform;

				//audio.Play ();

	}

		void Update(){
				//audio.Play();
				float dist = Vector3.Distance(target.position, transform.position);
				if (GameManager.myDestination != null) {

						target = GameManager.myDestination;
						float step = speed * Time.deltaTime;
						transform.position = Vector2.MoveTowards (transform.position, target.position, step);
						if (target.position.x < transform.position.x && dist >= 0.1f) {
								currentAnimState = CurrentAnimationState.WalkingLeft;

						} else if (target.position.x > transform.position.x && dist >= 0.1f) {
								currentAnimState = CurrentAnimationState.WalkingRight;
						}
				}

				switch (currentAnimState) {
				case CurrentAnimationState.Poof:
						animator.SetInteger ("Direction", 9);
						isMoving = false;
						break;
				case CurrentAnimationState.IdleWait:
						animator.SetInteger ("Direction", 0);
						isMoving = false;
						break;
				case CurrentAnimationState.WalkingRight:
						animator.SetInteger ("Direction", 1);
						isMoving = true;
						break;
				case CurrentAnimationState.WalkingLeft:
						animator.SetInteger ("Direction", 2);
						isMoving = true;
						break;
				case CurrentAnimationState.LayingDown:
						animator.SetInteger ("Direction", 3);
						isMoving = true;
						break;
				case CurrentAnimationState.LayingThere:
						animator.SetInteger ("Direction", 4);
						isMoving = false;
						break;
				case CurrentAnimationState.StandingUp:
						animator.SetInteger ("Direction", 5);
						isMoving = true;
						break;
				case CurrentAnimationState.SittingToRead:
						animator.SetInteger ("Direction", 6);
						isMoving = true;
						break;
				case CurrentAnimationState.StaySeated:
						isMoving = false;
						animator.SetInteger ("Direction", 7);
						break;
				case CurrentAnimationState.StandFromReading:
						animator.SetInteger ("Direction", 8);
						isMoving = true;
						break;
				default:
						break;
				}

		}

		public IEnumerator StandUpToStand(){
				animator.SetInteger("Direction", 4);
				animator.SetInteger("Direction", 0);
				yield return new WaitForSeconds (0);
		}
}
	


using UnityEngine;
using System.Collections;

public class AudioPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
				if (KnightController.isMoving) {

						if (!audio.isPlaying) {
								audio.Play ();
								audio.loop = true;
						}

				} else {
						audio.Stop ();
				}

	}
}

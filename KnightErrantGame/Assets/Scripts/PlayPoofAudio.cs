using UnityEngine;
using System.Collections;

public class PlayPoofAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

				if (GameManager.poofAudio) {

						if (!audio.isPlaying) {
								audio.Play ();
								//audio.loop = true;

						}

				} else {
						audio.Stop ();
				}
	
	}
}

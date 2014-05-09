using UnityEngine;
using System.Collections;

public class gameFM : MonoBehaviour {

	public static int gStatus;

	// Use this for initialization
	void Start () {
		gStatus = -1;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.R)) //resume
		{
			gStatus = -1;
		}

		if (Input.GetKey (KeyCode.P)) { //pause
						gStatus = 0;
				}

		if (gStatus != -1) {
						if (Input.GetKey (KeyCode.Q)) { gStatus = 1; }  // rewind
							else
								if (Input.GetKey (KeyCode.W)) { gStatus = 2; } 		// forward	
									else gStatus = 0; // stops moving them when no longer pressed
				}
	}
}

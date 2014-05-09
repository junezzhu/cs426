using UnityEngine;
using System.Collections;

public class gameFM : MonoBehaviour {

	public static int gStatus;
	public KeyCode antiStuck;
	public int dimension;
	// Use this for initialization
	void Start () {
		dimension = 1; // starts in first dimension
		gStatus = -1;
	
	}

	public int getStatus()
	{
		return gStatus;
	}

	public int getDimension()
	{
		return dimension;
	}

	public void setStatus(int x)
	{
		gStatus = x;
		}

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.G)) 
						dimension = (dimension == 1) ? 3 : 1;
		
		if (gStatus == 100) {// this is the "antistuck" state, if user refuses to let go,


			if(Input.GetKeyUp(antiStuck)) gStatus = 0;

			return;
				}
		if(Input.GetKey(KeyCode.R)) //resume
		{
			gStatus = -1;
		}

		if (Input.GetKey (KeyCode.P)) { //pause
						gStatus = 0;
				}

		if (gStatus != -1) {
			if (Input.GetKey (KeyCode.Comma)) { gStatus = 1; antiStuck = KeyCode.Comma; }  // rewind
							else
			if (Input.GetKey (KeyCode.Period)) { gStatus = 2; antiStuck = KeyCode.Period;} 		// forward	
									else gStatus = 0; // stops moving them when no longer pressed
				}
	}
}

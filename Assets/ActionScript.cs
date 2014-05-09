using UnityEngine;
using System.Collections;

public class ActionScript : MonoBehaviour {
	public Font font;
	bool PauseState = false;
	float MusicVolume ;
		float GlobalVolume ;
	// Use this for initialization
	void Start () {
		audio.Play ();
		MusicVolume = audio.volume;
		GlobalVolume = AudioListener.volume;
	}
	
	void OnGUI() {

		if (PauseState) {
			Screen.showCursor=true;
						Time.timeScale = 0;
						Debug.Log ("Pause");
						
						GUIStyle myStyle = new GUIStyle ();
						myStyle.font = font;
						myStyle.normal.textColor = Color.cyan;
						myStyle.hover.textColor = Color.cyan;
						myStyle.fontSize = myStyle.fontSize + 24;
						GUIStyle myBoxStyle = new GUIStyle ();
						myBoxStyle.normal.textColor = Color.cyan;
						myBoxStyle.hover.textColor = Color.blue;
		
						GUI.Box (new UnityEngine.Rect (0, 0, Screen.width, Screen.height / 1), "");
		            	GUI.Label (new Rect ((Screen.width / 4) - 50, (Screen.height / 4) - 100, 100, 30), "PauseMenu", myStyle);
			if(GUI.Button (new Rect ((Screen.width/4)+15,( Screen.height/4) -50,(Screen.width/4)+50, ( Screen.height/4)-100),"Restart",myStyle))
						{
			  				Application.LoadLevel("level1");
							
						}


						GUI.Label(new Rect ((Screen.width/4)+15, (Screen.height/4) , 100, 30), "Music Volume ", myStyle);

		            	MusicVolume = GUI.HorizontalScrollbar(new Rect ((Screen.width/4)+140, Screen.height/4+40, (Screen.width/4)+200, 30),MusicVolume, 1F, 0.0F, 10.0F );
			            GUI.Label(new Rect ((Screen.width/4)+15, (Screen.height/4)+60 , 100, 30), "Global Volume ", myStyle);
	               		audio.volume=MusicVolume/10f;
		
		             	GlobalVolume = GUI.HorizontalScrollbar(new Rect ((Screen.width/4)+140, ( Screen.height/4) +120, (Screen.width/4)+200, 30),GlobalVolume, 1F, 0.0F, 10.0F);
		 				AudioListener.volume=GlobalVolume/10f;
			if(GUI.Button (new Rect ((Screen.width/4)+15,( Screen.height/4) + 180,(Screen.width/4)+50, ( Screen.height/4)-100),"Quit Game",myStyle))
			{
				Application.Quit();
				
			}

			            
				} else
						Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update () {

		float Distance;
		int TheDamage=0;
		float MaxDistance = 3F;
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PauseState=!PauseState;
		}
		if(Input.GetKeyDown(KeyCode.E))
		{//Debug.Log("Test");
			//TheWepon.animation.Play("Attack");
			RaycastHit hit  ;
			if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit))
			{
				//Debug.Log(hit.ToString());

			//	if(hit.collider.name.Equals("Stm_button02")){}
				if(hit.collider.tag=="moveit")
				{
					Debug.Log(hit.collider.name);
					hit.rigidbody.position += transform.forward;
				}

				Distance= hit.distance;
				//Debug.Log(Distance);
				if(Distance<MaxDistance)
					hit.transform.SendMessage("ActionWork",SendMessageOptions.DontRequireReceiver);
			}
		}

	}
}

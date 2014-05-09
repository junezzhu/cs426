using UnityEngine;
using System.Collections;

public class GateOpenScript : MonoBehaviour {
	public GameObject openGear;
	public GameObject gate;
	public AudioClip ButtonPress;
	// Use this for initialization
	void Start () {
		
	
		
	}
	void ActionWork()
	{   
		openGear.animation.Play("OpenGateGear");
		Debug.Log ("GateOpening");
		gate.animation.Play ("GateOpening");
		audio.PlayOneShot (ButtonPress);
	}
	// Update is called once per frame
	void Update () {
	
	}
}

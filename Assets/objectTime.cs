using UnityEngine;
using System.Collections;

public class objectTime : MonoBehaviour {

	// Use this for initialization
	public class tSave //general class to save any/all data for objects, so far AngleVelocity, Velocity, Position
	{
	public Vector3 movement = new Vector3();
	public Vector3 position = new Vector3();
		public Vector3 angular = new Vector3();
		
		public tSave(Vector3 m, Vector3 p, Vector3 a)
		{
			angular = a;
			movement = m;
			position = p;
		}
	}
	//end of general class

	public bool resume; // uses this to reset velocity to objects when game is unpaused
	public tSave current; //used to keep track of the current "instance" of object on stack
	public int index; //used for clearing old arrays, not really needed now but when physics change during dimension shifts will be needed
	
	public ArrayList stack = new ArrayList();

	void Start () 
	{
		index = -1; //initialization
		resume = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(gameFM.gStatus == -1)
		{
			if(resume) //when you resume you have to give all properties back to each object, velocities and gravity 
			{
				rigidbody.velocity = current.movement;
				rigidbody.angularVelocity = current.angular;
				rigidbody.useGravity = true;
				// cut everything AFTER index (because we're resuming at previous frame
				if(index +1 != stack.Count) stack.RemoveRange(index, stack.Count-index -1);
			}
		 resume = false; // keep it false so we can know when it's our "first" pause update for later below, needed for logical comparissons
			index = -1; // we only need index when game is paused, at which point we set it to the size -1 (aka index of newest push onto stack)
			Vector3 p = rigidbody.position;
			Vector3 m = rigidbody.velocity;
			Vector3 a = rigidbody.angularVelocity;
		tSave inst = new tSave (m, p, a);
			stack.Add(inst); //here we save all data for each object for each stack

		}
		else
		{ if(index == -1) index = stack.Count-1;

			if(!resume) current = new tSave(rigidbody.velocity, rigidbody.position, rigidbody.angularVelocity); // saves/initiatilizes current
			resume = true; //once more we use "resume" for a logical comparisson
			if(gameFM.gStatus == 0)
			{

				rigidbody.velocity = new Vector3(0,0,0);
				rigidbody.angularVelocity = new Vector3(0,0,0);
				rigidbody.useGravity = false; //zero out all objects to simulate a "pause"
				
					
			}
			else
				if(gameFM.gStatus == 1 && index != 0)
			{
				index--;  //as long as we don't go negative in index we can iterate backwards
				current = (tSave)stack[index];
				pUpdate();
			}
			else if(index + 1 != stack.Count)
			{
				// as long as we don't exceed the range of the array we can iterate forwards
				index ++;
				current = (tSave)stack[index];
				pUpdate();
			}
		}
	}

	void pUpdate() //little function for updating the position whenever we update
	{
		rigidbody.position = new Vector3 (current.position.x, current.position.y, current.position.z);
	}
}

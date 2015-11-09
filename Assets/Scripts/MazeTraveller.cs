using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeTraveller : MonoBehaviour {

	public List<Waypoint> waypoints = new List<Waypoint>();
	bool moving = true;
	Waypoint current;
	int index = 0;
	Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
		current = waypoints [0];
		rbody = GetComponent<Rigidbody2D> ();
		rbody.velocity = (current.transform.position - transform.position) / (current.transform.position - transform.position).magnitude;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			if ((transform.position - current.transform.position).magnitude < 1 && index < waypoints.Count - 1) {
				print(waypoints[index].name + " : " + index);
				index++;
				current = waypoints[index];
				rbody.velocity = (current.transform.position - transform.position) / (current.transform.position - transform.position).magnitude;
			} else if ((transform.position - current.transform.position).magnitude < 1){
				rbody.velocity = Vector2.zero;
				moving = false;
			}
		}
	}

}

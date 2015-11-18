using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeTraveller : MonoBehaviour
{

	public List<Waypoint> waypoints = new List<Waypoint> ();
	bool moving = true, initialized = false;
	Waypoint current;
	int index = 0;
	Rigidbody2D rbody;

	// Use this for initialization
	void Start ()
	{
		current = waypoints [0];
		rbody = GetComponent<Rigidbody2D> ();
		rbody.velocity = current.speed*(current.transform.position - transform.position) / (current.transform.position - transform.position).magnitude;
		initialized = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (moving) {
			if ((transform.position - current.transform.position).magnitude < 1 && index < waypoints.Count - 1) {
				print (waypoints [index].name + " : " + index);
				index++;
				current = waypoints [index];
				StartCoroutine(move());
			} else if ((transform.position - current.transform.position).magnitude < 1) {
				rbody.velocity = Vector2.zero;
				moving = false;
				StartCoroutine(move());
			}
		}
	}

	IEnumerator move ()
	{
		rbody.velocity = Vector2.zero;
		yield return new WaitForSeconds (current.seconds);
		if (moving) {
			rbody.velocity = current.speed*(current.transform.position - transform.position) / (current.transform.position - transform.position).magnitude;
		} else {
			rbody.velocity = Vector2.zero;
		}
	}

}

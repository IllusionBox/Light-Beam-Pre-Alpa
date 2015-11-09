using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	bool touched = false;
	private Rigidbody2D rbody;
	Vector2 start, end;
	public float speed;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
	}

	void OnMouseDown(){
		//rbody.velocity = Vector2.zero;
		//touched = true;
	}

	void OnMouseUp(){
		//rbody.velocity = speed * (start - end); 
		rbody.AddForce (speed*(start - end));
		//Debug.DrawLine (start, end + new Vector2(transform.position.x, transform.position.y));
		//transform.Translate (new Vector3 (end.x, end.y, 0));
		print ("end: "+end +"\tStart: "+ start+"\tMagnitude: "+(start-end).magnitude);
		touched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length > 0) {
			/*if(!touched){
				start = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
				touched = true;
			}
			else{*/
				end = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
			//}
		}
		if (Input.GetMouseButton(0)) {
			if(!touched){
				start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				touched = true;
			}
			else{
				end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
		}
		if (end != null && start != null) {
			Debug.DrawLine(start, end);
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchController : MonoBehaviour {
	//public inspector variables
	public float speed, rate, fuel_divisor;
	public Slider fuel_bar, fuel_prompt_bar;

	//Script only variables
	bool touched = false;
	Vector2 start, end;
	private float fuel;
	private Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
		fuel = 1;
		fuel_bar.value = fuel;
		rbody = GetComponent<Rigidbody2D> ();
	}

	void OnMouseDown(){
		start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		touched = true;
		//rbody.velocity = Vector2.zero;
		//touched = true;
	}

	void OnMouseUp(){
		//rbody.velocity = speed * (start - end); 
		rbody.AddForce (speed*(start - end));
		fuel -= (start - end).magnitude / fuel_divisor;
		//Debug.DrawLine (start, end + new Vector2(transform.position.x, transform.position.y));
		//transform.Translate (new Vector3 (end.x, end.y, 0));
		print ("end: "+end +"\tStart: "+ start+"\tMagnitude: "+(start-end).magnitude);
		touched = false;
	}
	
	// Update is called once per frame
	void Update () {
		fuel -= rate;
		fuel_bar.value = fuel;
		if (Input.touches.Length > 0) {
			/*if(!touched){
				start = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
				touched = true;
			}
			else{*/
				end = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
			//}
		}
		else if (Input.GetMouseButton(0)) {
			if(!touched){
			}
			else{
				end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
		}
		if (end != null && start != null) {
			Debug.DrawLine(start, end);
		}
		if (touched) {
			fuel_prompt_bar.value = fuel - (start - end).magnitude / fuel_divisor;
		} else {
			fuel_prompt_bar.value = fuel;
		}
	}
}

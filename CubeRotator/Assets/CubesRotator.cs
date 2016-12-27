using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubesRotator : MonoBehaviour {

	private Rigidbody[] CubesRB;
	bool r, l, u, d; 
	public Slider speedSlider;
	private GameObject largeCube; 

	// Use this for initialization
	void Start () {
		largeCube = GameObject.Find ("Cubes"); 
		CubesRB = FindObjectsOfType (typeof(Rigidbody)) as Rigidbody[];
		foreach (Rigidbody CubeRB in CubesRB) {
			MyRotation (new Vector3 (0, 45, 0) * Time.smoothDeltaTime);
		}
		speedSlider = FindObjectOfType <Slider>(); 
		speedSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
		speedSlider.value = 1;

	}

	void ValueChangeCheck (){
		Debug.Log (speedSlider.value);	
	}


	void MyRotation (Vector3 vector3) {
		foreach (Rigidbody CubeRB in CubesRB) {
			CubeRB.transform.Rotate (vector3);
		}
		largeCube.transform.Rotate (vector3); 
	}
	// Update is called once per frame

	void Update () {
		// Horizontal
		if (Input.GetKey ("left")) {	
			u = d = r = false;
			l = true;	
		} 
		if (Input.GetKey ("right")){
			u = d = l = false;
			r = true; 
		}  
		//Vertical
		if (Input.GetKey ("up")) {
			l = d = r = false;
			u = true;
		}  
		if (Input.GetKey ("down")) {
			l = u = r = false;
			d = true;
		}
		
		if (l) foreach (Rigidbody CubeRB in CubesRB) {
				MyRotation (new Vector3 (0, Time.smoothDeltaTime, 0) * speedSlider.value);
			}
		if (r) foreach (Rigidbody CubeRB in CubesRB) {
				MyRotation (new Vector3 (0, -Time.smoothDeltaTime, 0) * speedSlider.value);
			}
		if (u) foreach (Rigidbody CubeRB in CubesRB) {
				MyRotation (new Vector3 (Time.smoothDeltaTime, 0, 0) * speedSlider.value);
			}
		if (d) foreach (Rigidbody CubeRB in CubesRB) {
				MyRotation (new Vector3 (-Time.smoothDeltaTime, 0, 0) * speedSlider.value);
			}
				
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour {

	private Renderer [] CubesRN; 
	int i;
	public Button colorChange;

	// Use this for initialization
	void Start () {
		colorChange = FindObjectOfType <Button> ();
		CubesRN = FindObjectsOfType (typeof(Renderer)) as Renderer[];
		i = 0;
		colorChange.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		//Color randColor = new Color (Random.Range(0f, 255f), Random.Range(0f, 255f), Random.Range(0f, 255f), 1f);
	}

	void ChangeColor (){
		Color randColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
		foreach (Renderer CubeRN in CubesRN) {
			CubeRN.material.color = randColor;
			i++;
			Debug.Log (i + ": Color was changed to " + randColor.ToString());
		}
	}

	void TaskOnClick(){
		ChangeColor ();
	}

}

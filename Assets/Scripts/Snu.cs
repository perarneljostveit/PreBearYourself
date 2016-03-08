using UnityEngine;
using System.Collections;

public class Snu : MonoBehaviour { // snu-script for spriten til bjørnen
	bool turn = true;


	// Use this for initialization
	void Start () {
	
	}
	void snu()
	{
		if (Input.GetKey ("a") && turn == true) {
			transform.Rotate (0f, 180, 0f);
			turn = false;

		} else if (Input.GetKey ("d") && turn == false) {
			transform.Rotate (0f, -180, 0f);
			turn = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
			snu();
	}


}

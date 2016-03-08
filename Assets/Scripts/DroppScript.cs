using UnityEngine;
using System.Collections;

public class DroppScript : MonoBehaviour {
	public int faen;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
			faen = 1;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}

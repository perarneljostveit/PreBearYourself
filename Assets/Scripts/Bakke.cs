using UnityEngine;
using System.Collections;

public class Bakke : MonoBehaviour {
	public int jumpCount = 1;


	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			jumpCount = 0;
		}


	}

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

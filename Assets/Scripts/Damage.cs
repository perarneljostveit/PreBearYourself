using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	// Use this for initialization
	public float dmg = 50;
	void Start () {
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Monster") 
		{
			other.transform.SendMessage ("Damage", dmg);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}

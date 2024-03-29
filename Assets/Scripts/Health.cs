using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public Rigidbody2D rb;
	public float liv = 100;
	public float dmg = 50;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Sprite" && GameObject.Find("Teddysprite").GetComponent<playerControls>().dropping == true) 
		{
			liv = liv - dmg;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (liv <= 0) 
		{
			Destroy (gameObject);
		}
	}
	void FixedUpdate () 
	{
		if (GameObject.Find("Teddysprite").GetComponent<playerControls>().roaring == true) 
		{
			rb.velocity = new Vector2 (100f, 0f*Time.deltaTime);
		}
	}
}

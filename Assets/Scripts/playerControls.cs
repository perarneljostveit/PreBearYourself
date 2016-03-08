using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {
	public Rigidbody2D rb;
	public float hoppFart = 65;
	public float fart = 10;
	public int jumpCount;
	public int bloodLust;
	public bool allowBeast = false;
	public bool dropping = false; 
	public bool roaring = false;
	int point = 10;
	private SpriteRenderer sRendrer;



	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		sRendrer = GetComponentInChildren<SpriteRenderer> ();
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			jumpCount = 0; // man kan kun hoppe når jumpCount == 0;
			dropping = false; 
		}

		else if (other.gameObject.tag == "Drops") 
		{
			bloodLust = bloodLust + point;


		}

	}

	void hopp()
	{
		rb.velocity = new Vector2 (0f, 10f * hoppFart*Time.deltaTime);

	}
	void turnIntoBeast() // funksjonen som gir bjørnen beast mode, kan bare aktiverees når man har pplukket opp ti drops, somm akkurat nå gir 10 bloodlust hvær.
	{
		if (Input.GetKey ("e") && bloodLust == 100)
		{
			sRendrer.color = Color.blue;
			allowBeast = true;
			hoppFart = 120;
			fart = 20;
		}
	}
	void turnBack() // denne funksjonen gjøre at bjørnen kommer tilbake til sitt originalstadie etter blodlust synker til 0, ettersom man bruker angrep. har ikke addet denne funksjonaliteten ennå.
	{
		if (bloodLust == 0)
		{
			sRendrer.color = Color.white;
			allowBeast = false;
			hoppFart = 65;
			fart = 10;
		}
	}

	void aoeAngrep()
	{
		rb.AddForce (transform.up * -1000);
		dropping = true; // dette er en sjekk på om bjørnen faller fra himmelen med AOE-angrepet, og ikke at den bare faller av et vanlig hopp. fiendene skades bare om dropping == true i health.cs
	}
		
	void update()
	{
		roaring = false; 
	}
	void FixedUpdate ()
	{

		turnIntoBeast ();

		turnBack ();

		float move = Input.GetAxis ("Horizontal");

		rb.velocity = new Vector2 (move * fart, rb.velocity.y);

		if (Input.GetKey ("w") && jumpCount == 0) 
		{
			hopp ();

			jumpCount = 1;
		}

		if (Input.GetKey ("s") && jumpCount == 1 && allowBeast == true) 
		{
			aoeAngrep ();
		}

		if (Input.GetKey ("r") && allowBeast == true) 
		{
			roaring = true; //fiendene løper bare når roaring == true i  Health.cs. kommer til å gjøre at de bare løper i en viss mengde tid i senere builds
		}
	}



		



}
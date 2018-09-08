using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour {

	public float thrust=150f,legMod,armMod,earMod,torsoMod,scale=1;
	private Color32 torso,ears,arms,legs,basis;
	public Vector3 accel;

	float timePassed;

	void randomAll(){
		//scale breaks when the change is too large.
		//Don't change at runtime.
		//scale = Random.Range(.2f,1f);
		legMod= Random.Range (.3f,.7f);
		earMod = Random.Range (.2f,.7f);
		armMod = Random.Range (.3f, .7f);
		torsoMod = 0;

		basis = new Color32 ((byte)Random.Range(40,255),(byte)Random.Range(40,255),(byte)Random.Range(40,255),255);

		float mag = new Vector3 (basis.r, basis.g, basis.b).magnitude;
		while (mag < 0) {
			basis = new Color32 ((byte)Random.Range(0,255),(byte)Random.Range(0,255),(byte)Random.Range(0,255),255);
			mag = new Vector3 (basis.r, basis.g, basis.b).magnitude;
			//Debug.Log (basis);
		}
	}

	void establishColors(){
		//the Mods are + difference from the basis Color
		torso=new Color(basis.r*(1-torsoMod)/255,basis.g*(1-torsoMod)/255,basis.b*(1-torsoMod)/255,255);
		ears=new Color(basis.r*(1-earMod)/255,basis.g*(1-earMod)/255,basis.b*(1-earMod)/255,255);
		arms=new Color(basis.r*(1-armMod)/255,basis.g*(1-armMod)/255,basis.b*(1-armMod)/255,255);
		legs=new Color(basis.r*(1-legMod)/255,basis.g*(1-legMod)/255,basis.b*(1-legMod)/255,255);
	}

	void updateColor(){
		foreach(Transform child in transform){
			//Debug.Log (child.name);
			if (child.CompareTag("Ear")) {
				child.GetComponent<SpriteRenderer> ().color = ears; //new Color(ears.r,ears.g,ears.b,255);
			}
			if (child.CompareTag("Arm")) {
				child.GetComponent<SpriteRenderer> ().color = arms; //new Color(limbs.r,limbs.g,limbs.b,255);
			}
			if (child.CompareTag("Leg")) {
				child.GetComponent<SpriteRenderer> ().color = legs; //new Color(limbs.r,limbs.g,limbs.b,255);
			}
		}
		transform.GetComponent<SpriteRenderer> ().color = torso; //new Color(torso.r,torso.g,torso.b,255);
	}

	void Start () {
		//scale = Random.Range(.2f,1f);
		randomAll ();
		establishColors();
		updateColor();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (_Value.getHealth());
		timePassed += Time.deltaTime;
		if (timePassed > 2) {
			//randomAll ();
			//establishColors ();
			//updateColor ();
			timePassed = 0;
		}

		transform.localScale = new Vector3 (scale,scale,1);
		//scale += 0.001f;
		//X is the left and right edges
		//+1 left, -1 right

		//Y is the up down.
		//-1 when held upright, +1 when upside down
		accel = new Vector3(thrust*Input.acceleration.x,thrust*Input.acceleration.y,0); //>0?thrust*Input.acceleration.y:0,0);
		transform.GetComponent<Rigidbody2D>().AddForce(accel);
		//Debug.Log ("Vel:"+transform.GetComponent<Rigidbody2D> ().velocity.magnitude);
	


		//Implentation for change on 
	}

}

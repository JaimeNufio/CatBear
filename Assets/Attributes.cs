using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour {

	public float thrust=150f,limbMod,earMod,torsoMod;
	public Color basis;

	private Color limbs,torso,ears;
	public Vector3 accel;

	//private Color limbsCurr = Color.white,torsoCurr = Color.white,earsCurr =Color.white;

	void establishColors(){
		//the Mods are + difference from the basis Color
		limbs=new Color(basis.r*(1-limbMod),basis.g*(1-limbMod),basis.b*(1-limbMod),255);
		torso=new Color(basis.r*(1-torsoMod),basis.g*(1-torsoMod),basis.b*(1-torsoMod),255);
		ears=new Color(basis.r*(1-earMod),basis.g*(1-earMod),basis.b*(1-earMod),255);
	}

	void updateColor(){
		foreach(Transform child in transform){
			//Debug.Log (child.name);
			if (child.CompareTag("Ear")) {
				child.GetComponent<SpriteRenderer> ().color = ears; //new Color(ears.r,ears.g,ears.b,255);
			}
			if (child.CompareTag("Limb")) {
				child.GetComponent<SpriteRenderer> ().color = limbs; //new Color(limbs.r,limbs.g,limbs.b,255);
			}
		}
		transform.GetComponent<SpriteRenderer> ().color = torso; //new Color(torso.r,torso.g,torso.b,255);

	}

	void Start () {
		establishColors ();
		updateColor();
	}

	// Update is called once per frame
	void Update () {
		//X is the left and right edges
		//+1 left, -1 right

		//Y is the up down.
		//-1 when held upright, +1 when upside down
		accel = new Vector3(thrust*Input.acceleration.x,Input.acceleration.y>0?1*thrust*Input.acceleration.y:0,0);
	
		Debug.Log(accel);
		transform.GetComponent<Rigidbody2D>().AddForce(accel);
	
		//Implentation for change on 

	}
}

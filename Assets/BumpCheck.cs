using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpCheck : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "wall") {
			Debug.Log ("wall");
			if (transform.GetComponent<Rigidbody2D>().velocity.magnitude > 1.5){
				Debug.Log ("smack");
				_Value.bump (transform.GetComponent<Rigidbody2D>().velocity.magnitude);
			}
		}
	}

}

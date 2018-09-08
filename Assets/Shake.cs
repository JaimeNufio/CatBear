using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {
	private int cnt;
	private Vector3 target = new Vector3(0,10,-10);
	public float speed = .5f,rotato=5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cnt++;
		if (cnt%20==0){
			target.x*=-1;
			target.y*=-1;
			//new Vector3(-1,-1,0);
		}
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position,target,step);
		transform.rotation *= Quaternion.Euler (Vector3.back*rotato);

	}
}

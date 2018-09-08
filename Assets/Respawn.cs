using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public GameObject prefab;
	public Vector3 pos;
	public float t;
	private bool beingHandled = false;

	private bool blep = false;

	// Use this for initialization
	void Start () {

	}

	public void Update()
	{
		if( !beingHandled )
		{
			StartCoroutine( HandleIt() );
			Instantiate (prefab,pos,Quaternion.identity);
		}
	}

	private IEnumerator HandleIt(){
		beingHandled = true;
		// process pre-yield
		yield return new WaitForSeconds( t );
		// process post-yield
		beingHandled = false;
	}
}

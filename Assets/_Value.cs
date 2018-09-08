using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class _Value  {

	private static int health=1000,hunger,sanity;

	public static void setHealth(int val){
		health = val;
	}

	public static int getHealth(){
		return health;
	}

	public static void bump(float vel){
		int mod = 2;
		setHealth((int)(getHealth()-vel*mod));
	}

}

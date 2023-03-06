using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotator : MonoBehaviour {


public float speed=1f;
	void Update () 
	{
		//transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
		transform.Rotate (new Vector3 (Random.Range(-100.0f,100.0f),Random.Range(-100.0f,100.0f),Random.Range(-100.0f,100.0f)),30f*speed*Time.deltaTime);
	}
}
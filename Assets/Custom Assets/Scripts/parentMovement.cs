using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentMovement : MonoBehaviour
{
	
	private GameObject target = null; 
	private Vector3 offset;

	void Start ()
	{
		//there should be nothing on platform
		target = null;
	}
	void OnTriggerStay (Collider col)
	{
		//set variable target to the object that collided
		target = col.gameObject;
		//offset collided objects position relative to the position of
		//platform
		offset = target.transform.position - transform.position;
	}
	void OnTriggerExit (Collider col)
	{
		//if object leaves, target is null.
		target = null;
	}
	void LateUpdate ()
	{
		if (target != null) {
			target.transform.position = transform.position + offset;
		}
	}
}

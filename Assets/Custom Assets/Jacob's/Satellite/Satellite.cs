using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

    [SerializeField]
    private Transform fins;

    [SerializeField]
    private int speed = 1;


	void Start ()
    {
		
	}
	
	void Update ()
    {
        float angle = speed;
        angle = Mathf.Min(angle * Time.deltaTime * 60);
        fins.Rotate(Vector3.forward, angle);
    }
}

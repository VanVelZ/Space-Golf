using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{

    Transform trans;

    [SerializeField]
    float rotationSpeed = 1;

    private void spawn()
    {
        trans = GetComponent<Transform>();

    }

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform> ();
	}

    // Update is called once per frame
    void Update()
    {
        trans.Rotate(0, 1 * rotationSpeed, 0, Space.World);
    }

}

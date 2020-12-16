using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {
	Transform movement;

	[SerializeField]
	public float speed = .04f;

	public enum FloatDirection { x, y, z };

	[SerializeField]
	public FloatDirection direction = FloatDirection.z;


	//the coords you would like the platform to move to
	[SerializeField]
	public float back = -7;

	[SerializeField]
	public float forth = 5;

	float z = -1;

	float distance = 5;

	// Start is called before the first frame update
	void Start ()
	{
		movement = GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = movement.position;
		switch (direction)
		{
			case FloatDirection.z:
				if (distance < pos.z)
				{
					pos.z += (z * speed * Time.deltaTime * 60);
					distance = back;

				}
				else if (distance > pos.z)
				{

					pos.z += -1 * (z * speed * Time.deltaTime * 60);
					distance = forth;
				}

				break;
			case FloatDirection.y:
				if (distance < pos.y)
				{
					pos.y += (z * speed * Time.deltaTime * 60);
					distance = back;

				}
				else if (distance > pos.y)
				{

					pos.y += -1 * (z * speed * Time.deltaTime * 60);
					distance = forth;
				}

				break;
			case FloatDirection.x:
				if (distance < pos.x)
				{
					pos.x += (z * speed * Time.deltaTime * 60);
					distance = back;

				}
				else if (distance > pos.x)
				{

					pos.x += -1 * (z * speed * Time.deltaTime * 60);
					distance = forth;

				}

				break;
		}

		movement.position = pos;
			}

		}

using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    [SerializeField]
    private Transform ExitTransform;

    [SerializeField]
    private Transform GolfBall;

    [SerializeField]
    SpaceShipMove spaceship;

    [SerializeField]
    private int Z; //Exit z velocity

    [SerializeField]
    private int X; //Exit x velocity

    [SerializeField]
    private int Y; //Exit y velocity

    [SerializeField]
    bool isWarp = true;// if not true carry ball

    [SerializeField]
    private List<Transform> spacePoints = new List<Transform>();

    private Transform SpaceshipTrans;

    void Start ()
    {
        if (spaceship != null)
            SpaceshipTrans = spaceship.GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (spaceship != null)
        {
            if (spaceship.tState != TravelState.RETURN)
            {
                spaceship.tState = TravelState.CARRY;
                GolfBall.transform.parent = spaceship.transform;
                GolfBall.localPosition = new Vector3(0, -2.5f, 0);
                GolfBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

    }

    void OnTriggerStay(Collider c)
    {

        if(isWarp)
        {
        Rigidbody rbody = c.GetComponent<Rigidbody>();
        c.transform.position = ExitTransform.position;
        Vector3 desiredDirection = new Vector3(X,Y,Z); // set this to the direction you want.
        Vector3 newVelocity = desiredDirection.normalized * rbody.velocity.magnitude;
        rbody.velocity = newVelocity;
        }
    }
	
	
	void Update ()
    {
        if (spaceship != null)
        {
            if ((spaceship.tState == TravelState.CARRY) && !isWarp)
            {
                Vector3 v = spacePoints[0].position - SpaceshipTrans.position;
                if (v.magnitude > 1.0f)
                {
                    v.Normalize();
                    SpaceshipTrans.Translate(v * spaceship.warpSpeed * Time.deltaTime);
                }
                else
                {
                    SpaceshipTrans.position = spacePoints[0].position;
                    GolfBall.transform.parent = null;
                    spaceship.tState = TravelState.RETURN;
                }
            }
        }

        //if (t != null)
        //{
        //Vector3 v = spacePoints[0].position - t.position;
        //v.Normalize();
        //    //t.Translate(v * 100 * Time.deltaTime);

        //    Vector3.Lerp(t.position, spacePoints[0].position, 1.0f);

        //print("here");
        //}

    }
}

using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
    private Transform planetToOrbit;
    private Rigidbody GolfBall;
    private Transform ball;
    private GolfClub player;

    [SerializeField]
    public int OrbitMultiplyer = 1;

    [SerializeField]
    public float y_orbit_Offset = 0.5f;

    [SerializeField]
    public bool isHole = false;

    void Start()
    {
        planetToOrbit = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (ball != null)
            Orbit(ball);
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            player = c.GetComponent<GolfClub>();
            ball = c.GetComponent<Transform>();
        }
    }
    //private void OnTriggerExit(Collider c)
    //{
    //    player.isInOrbit = false;
    //    if (isHole) player.isFinished = false;
    //    player = null;
    //    ball = null;
    //}
    public void Orbit(Transform t)
    {

        Vector3 relativePos = (planetToOrbit.position + new Vector3(0, y_orbit_Offset, 0)) - t.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = t.localRotation;

        t.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        t.Translate(0, 0, 6 * OrbitMultiplyer * Time.deltaTime);

        player.isInOrbit = true;
        if (isHole) player.isFinished = true;

    }
}
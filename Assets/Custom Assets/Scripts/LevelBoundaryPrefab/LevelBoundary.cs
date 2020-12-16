using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    [SerializeField]
    public GameObject clusterModel;

    [SerializeField]
    public float clusterDistance = 3f;

    private Transform ball;
    private Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider c) {

        if (c.GetComponent<Rigidbody>() && c.tag == "Player")
        {
            player = c.GetComponent<Rigidbody>();
            ball = c.transform;

            Vector3 ballLocation = ball.position;
            Vector3 ballDirection = player.velocity;

            float xpos = ballLocation.x + (ballDirection.x * clusterDistance);
            float ypos = ballLocation.y + (ballDirection.y * clusterDistance);
            float zpos = ballLocation.z + (ballDirection.z * clusterDistance);

            Vector3 asteroidPos = new Vector3(xpos, ypos, zpos);

            Debug.Log("ballDirection:" + ballDirection);
            Debug.Log("ballLocation: " + ballLocation);
            Debug.Log("Asteroid Position: " + asteroidPos);

            GameObject newRoid = Instantiate(clusterModel, asteroidPos, Quaternion.identity);
            newRoid.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject[] roids;
        roids = GameObject.FindGameObjectsWithTag("Cluster");
        foreach (GameObject roid in roids) { roid.SetActive(false); }
    }

}

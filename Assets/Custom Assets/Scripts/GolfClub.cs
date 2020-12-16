using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GolfClub : MonoBehaviour
{

    private Rigidbody rbody;
    private int endCount;
    //a value that holds the distance the mouse has travelled
    private float mouseY;
    private float lastMouseY;

    //the amount of force to be applied to the ball
    private float addForce;

    //output text <-We should probably move this eventually

    [SerializeField]
    Text powerText;

    [SerializeField]
    Text strokeText;

    public Text parText;
    public Text scoreText;

    public int par = 3;

    [SerializeField]
    string nextScene;

    //adjust if we want ball to go faster
    [SerializeField]
    float forceMultiplier = 1;

    //The maximum amount of force that can be applied in a "swing"
    [SerializeField]
    public float maxForce = 2000;

    //minimum amount of force before ball will just stop
    [SerializeField]
    public float minForce = .2f;

    
    public bool isInOrbit = false;
    public bool isFinished = false;

    
    public int strokeCount = 0;

    public int PlayerNumber;

    public GolfClub()
    {
        
    }

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        powerText.text = "Power Level: ";
        strokeText.text = "Strokes: " + strokeCount;
        parText.text = "Par: " + par;
    }

    public void Swing()
    {

        if ((rbody.IsSleeping() || isInOrbit) && endCount == 0) //is the ball moving or in fixed rotation
        {
            if (Input.GetMouseButtonDown(0)) //grab mouse position on mouse button down
            {
                mouseY = Input.mousePosition.y;

            }
            if (Input.GetMouseButton(0))
            {
                if ((int)lastMouseY != (int)Input.mousePosition.y)
                {
                    if (lastMouseY > Input.mousePosition.y) addForce += (mouseY - Input.mousePosition.y);
                    else addForce -= (mouseY + +Input.mousePosition.y) / 7;
                    lastMouseY = Input.mousePosition.y;
                }
                if (addForce <= maxForce) powerText.text = "Power Level: " + (uint)addForce;
                else powerText.text = "Power Level: " + maxForce;
            }
            if (Input.GetMouseButtonUp(0) && addForce > 0)
            {
                if (addForce > maxForce) addForce = maxForce;
                rbody.AddForce(Camera.main.transform.forward * addForce * forceMultiplier);
                strokeCount++;
                addForce = 0;
                powerText.text = "Power Level: " + (uint)addForce;
                strokeText.text = "Strokes: " + strokeCount;
            }
        }

        if (rbody.velocity.magnitude < minForce && rbody.velocity.magnitude > 0)
        {
            //if the velocity is less than the minimum, stop the ball
            rbody.velocity = Vector3.zero;
            rbody.angularVelocity = Vector3.zero;
        }

    }


    void Update()
    {
        Swing();
        if (isFinished)
        {
            if(endCount == 0)PlayerScore.score += strokeCount - par;
            scoreText.text = "Score: " + PlayerScore.score;
            endCount++;
            if (endCount > 1000) SceneManager.LoadScene(nextScene.ToString());
        }
        else
        {
            endCount = 0;
            strokeText.text = "Strokes: " + strokeCount;
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TravelState { HOVER, CARRY, RETURN };
public class SpaceShipMove : MonoBehaviour
{
    [SerializeField]
    float XRange, YRange, ZRange;

    public Collider playerIn;

    private Vector3 MaxX, MinX, MaxY, MinY, MaxZ, MinZ;
    
    private Transform ship;
    private Vector3 hoverPoint;

    public TravelState tState { get; set; }
    public float warpSpeed = 50; // TODO: Improve access modifier

    bool isReversed = false;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Transform>();
        hoverPoint = ship.position;

        MaxX = ship.position + new Vector3(XRange, 0f, 0f);
        MinX = ship.position - new Vector3(XRange, 0f, 0f);

        MaxY = ship.position + new Vector3(0f, YRange, 0f);
        MinY = ship.position - new Vector3(0f, YRange, 0f);

        MaxZ = ship.position + new Vector3(0f, 0f, ZRange);
        MinZ = ship.position - new Vector3(0f, 0f, ZRange);

        tState = TravelState.HOVER;
    }



    // Update is called once per frame
    void Update()
    {
        if (tState == TravelState.HOVER)
        {
            if (XRange > 0) { AlternatePos(ship.position.x, MaxX.x, MinX.x, new Vector3(XRange, 0f, 0f)); }
            if (YRange > 0) { AlternatePos(ship.position.y, MaxY.y, MinY.y, new Vector3(0f, YRange, 0f)); }
            if (ZRange > 0) { AlternatePos(ship.position.z, MaxZ.z, MinZ.z, new Vector3(0f, 0f, ZRange)); }
        }
        else if (tState == TravelState.RETURN)
        {
            Vector3 v = hoverPoint - ship.position;
            if (v.magnitude > 1.0f)
            {
                v.Normalize();
                ship.Translate(v * warpSpeed * Time.deltaTime);
            }
            else
            {
                ship.position = hoverPoint;
                tState = TravelState.HOVER;
            }
        }


    }

    private void AlternatePos(float currentShipPosition, float targetMaxPosition, float targetMinPosition, Vector3 forceVector) {

        //Debug.Log("Current Position:" + currentShipPosition + "Target Position:" + targetMaxPosition);
        if (currentShipPosition > targetMaxPosition) { isReversed = true; }
        else if (currentShipPosition < targetMinPosition) { isReversed = false; }
        
        if (!isReversed) ship.Translate(forceVector * Time.deltaTime);
        else ship.Translate(forceVector * Time.deltaTime * -1);
    }
}

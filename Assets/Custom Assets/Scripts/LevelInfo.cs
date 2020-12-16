using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    
    public string levelName;
    public string description;
    public int playerCount = 1;

    [SerializeField]
    Text parText;

    public GameObject playerPrefab;

    [Header("Starting position")]
    public Transform spawner;
    public Vector3 startingPos;

    [Header("Ending position")]
    public Transform planet;
    public Vector3 endingPos;

    public float levelLength;



    // Start is called before the first frame update
    void Start()
    {
        //SpawnPlayers();
        startingPos = spawner.position;
        endingPos = planet.position;
        levelLength = spawner.position.magnitude - planet.position.magnitude;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void SpawnPlayers()
    //{
    //    for (int i = 1; i <= playerCount; i++)
    //    {
    //        playerList.Add(Instantiate(playerPrefab, spawner.position, Quaternion.identity));
            
    //        currentPlayer = playerList[i].GetComponent<GolfClub>();
    //        currentPlayer.PlayerNumber = i; 
    //    }
    //}
}

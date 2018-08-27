using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject pedestrianPrefab;
    GameObject newPlayer;
    GameObject newPedestrian;

    // Use this for initialization
    void Start () {
        
        newPlayer = Instantiate(playerPrefab);
        newPlayer.GetComponentInChildren<PlayerController>().gameManager = this;
        /*
        newPedestrian = Instantiate(pedestrianPrefab);
        newPedestrian.GetComponentInChildren<PedestrianController>().gameManager = this;
        */

        InvokeRepeating("SpawnPedestrian", 1f, 15f);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void SpawnPedestrian()
    {
        GameObject.Instantiate(pedestrianPrefab);
    }
}

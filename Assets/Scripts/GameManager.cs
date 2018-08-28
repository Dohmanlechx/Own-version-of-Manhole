using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject pedestrianPrefab;
    GameObject newPlayer;
    GameObject newPedestrian;

    bool over4, over12, over20, over28 = false;

    public static int score;

    // Use this for initialization
    void Start () {

        score = 0;
        
        newPlayer = Instantiate(playerPrefab);
        newPlayer.GetComponentInChildren<PlayerController>().gameManager = this;
        /*
        newPedestrian = Instantiate(pedestrianPrefab);
        newPedestrian.GetComponentInChildren<PedestrianController>().gameManager = this;
        */

        InvokeRepeating("SpawnPedestrian", 1.5f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
        
        score = ScoreManager.score;

        if (score >= 3 && !over4)
        {
            over4 = true;
            CancelInvoke();
            Debug.Log("Faster spawns activated");
            InvokeRepeating("SpawnPedestrian", 3.5f, 12f);
        }
        else if (score >= 11 && !over12)
        {
            over12 = true;
            CancelInvoke();
            Debug.Log("Faster spawns activated");
            InvokeRepeating("SpawnPedestrian", 3f, 8.5f);
        }
        else if (score >= 22 && !over20)
        {
            over20 = true;
            CancelInvoke();
            Debug.Log("Faster spawns activated");
            InvokeRepeating("SpawnPedestrian", 3.5f, 6f);
        }
        else if (score >= 33 && !over28)
        {
            over28 = true;
            CancelInvoke();
            Debug.Log("Faster spawns activated");
            InvokeRepeating("SpawnPedestrian", 3f, 4.5f);
        }
    }

    void SpawnPedestrian()
    {
        GameObject.Instantiate(pedestrianPrefab);
    }
}

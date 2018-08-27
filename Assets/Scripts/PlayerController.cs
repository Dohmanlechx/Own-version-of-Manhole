using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameManager gameManager;

    // Creating a List of all four positions
    public List<Transform> positions = new List<Transform>();

    public static int currentPosition = 0;

    private void OnEnable()
    {
        Input.OnNWPressed += Input_OnNWPressed;
        Input.OnNEPressed += Input_OnNEPressed;
        Input.OnSWPressed += Input_OnSWPressed;
        Input.OnSEPressed += Input_OnSEPressed;
    }

    private void OnDisable()
    {
        Input.OnNWPressed -= Input_OnNWPressed;
        Input.OnNEPressed -= Input_OnNEPressed;
        Input.OnSWPressed -= Input_OnSWPressed;
        Input.OnSEPressed -= Input_OnSEPressed;
    }

    private void Start()
    {
        transform.position = positions[currentPosition].position;
    }

    void Input_OnNWPressed()
    {
        transform.position = positions[0].position;
        currentPosition = 0;
    }

    void Input_OnNEPressed()
    {
        transform.position = positions[1].position;
        currentPosition = 1;
    }

    void Input_OnSWPressed()
    {
        transform.position = positions[2].position;
        currentPosition = 3;
    }

    void Input_OnSEPressed()
    {
        transform.position = positions[3].position;
        currentPosition = 2;
    }
}

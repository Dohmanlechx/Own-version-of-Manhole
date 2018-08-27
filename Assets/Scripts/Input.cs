using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour {

    public delegate void ButtonPressed();
    public static event ButtonPressed OnNWPressed, OnNEPressed, OnSWPressed, OnSEPressed;

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("NW"))
            OnNWPressed();
        else if (gameObject.CompareTag("NE"))
            OnNEPressed();
        else if (gameObject.CompareTag("SW"))
            OnSWPressed();
        else if (gameObject.CompareTag("SE"))
            OnSEPressed();
    }
}

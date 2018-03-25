using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Rotates the item in the Y axis.
        transform.Rotate(0, 60.0f * Time.deltaTime, 0);
	}
}

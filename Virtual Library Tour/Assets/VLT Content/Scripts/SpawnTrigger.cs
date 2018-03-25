using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpawnTrigger : MonoBehaviour {

    private GameObject Prop;

	// Use this for initialization
	void Start ()
    {
        Prop = GameObject.Find("Props");
        Prop.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            Prop.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}

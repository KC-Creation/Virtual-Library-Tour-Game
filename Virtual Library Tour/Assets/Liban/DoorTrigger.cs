using System.Collections;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    TriggerDoor DoorScript;
    public GameObject DoorObject;

    private void Start()
    {
        DoorScript = DoorObject.GetComponent<TriggerDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DoorScript.DoorOpen();
    }
    private void OnTriggerExit(Collider other)
    {
        DoorScript.DoorOpen();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour {

    public Transform pos1;
    public Transform pos2;

    public float doorSpeed = 2f;

    bool isDoorClosed = true;

    void Awake()
    {
        isDoorClosed = true;
    }

    public void DoorOpen ()
    {
        if (isDoorClosed == true)
        {
            StopCoroutine("ClosedDoor");
            StartCoroutine("OpenDoor");
            isDoorClosed = false;
        } else {
            StopCoroutine("OpenDoor");
            StartCoroutine("CloseDoor");
            isDoorClosed = true;

        }
    }

    IEnumerator OpenDoor()
    {
        while (Vector3.Distance (transform.position, pos2.position) > 0f)
        {
            transform.position = Vector3.Lerp(transform.position, pos2.position, doorSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator CloseDoor()
    {
        while (Vector3.Distance (transform.position, pos1.position) > 0f)
        {
            transform.position = Vector3.Lerp(transform.position, pos1.position, doorSpeed * Time.deltaTime);

            yield return null;
        }
    }
}

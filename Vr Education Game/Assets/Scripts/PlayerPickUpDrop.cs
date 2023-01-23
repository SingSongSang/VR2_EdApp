using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    public GameObject Object;
    public Transform PlayerTransform;
    public float range = 3f;
    public Camera Camera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartPickUp();
        }
        if (Input.GetMouseButtonUp(1))
        {
            Drop();
        }
        
    }
    void StartPickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                PickUp();
            }
        }
    }

    void PickUp()
    {
        Gun.GetComponent<Rigidbody>().isKinematic = true;
        Object.transform.SetParent(PlayerTransform);
    }

    void Drop()
    {
        PlayerTransform.DetachChildren();
        Gun.GetComponent<Rigidbody>().isKinematic = false;
    }

}

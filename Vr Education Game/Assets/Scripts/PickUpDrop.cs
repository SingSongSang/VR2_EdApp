using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrop : MonoBehaviour
{
    public GameObject Object;
    public Transform playertransform;
    public float range = 3f;
    public float go = 100f;
    public Camera camera;
    public static bool held = false;
    GameObject TheHitObject = null;
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && held == false)
        {
            startPickup();
        }
        if (Input.GetMouseButtonDown(1) && held == true)
        {
            Drop();
        }
    }
    void startPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Item")
            {
                Debug.Log(hit.transform.name);
                TheHitObject = hit.collider.gameObject;
                PickUp();
            }
        }
    }
    void PickUp()
    {
        held = true;
        TheHitObject.transform.parent = playertransform.transform;
        TheHitObject.transform.position += Vector3.up * 2;

    }
    void Drop()
    {
        held = false;
        TheHitObject.transform.parent = null;
        
    }
}

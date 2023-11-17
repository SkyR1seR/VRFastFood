using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Spawner : MonoBehaviour
{
    public bool main = true;

    private void Start()
    {
        GetComponent<Throwable>().onPickUp.AddListener(SpawnItem);
        GetComponent<Throwable>().onDetachFromHand.AddListener(EnablePhysic);
    }

    public void SpawnItem()
    {
        if (main==true)
        {
            main = false;
            Spawner newItem = Instantiate(this, transform.position, transform.rotation);
            newItem.main = true;
        }
    }

    public void EnablePhysic()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDuck : MonoBehaviour
{
    private Collider coll;
    void Start()
    {
        coll = GetComponent<BoxCollider>();
        StartCoroutine(ColliderDelay());
    }

    IEnumerator ColliderDelay()
    {
        coll.isTrigger = false;
        yield return new WaitForSeconds(2f);
        coll.isTrigger = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLily : MonoBehaviour
{
    private Collider coll;
    void Start()
    {
        coll = GetComponent<BoxCollider>();
        StartCoroutine(WaterLilyCollisionDelay());
    }

    IEnumerator WaterLilyCollisionDelay()
    {
        coll.isTrigger = false;
        yield return new WaitForSeconds(2f);
        coll.isTrigger = true;
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}

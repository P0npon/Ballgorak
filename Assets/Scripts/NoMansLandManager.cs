using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMansLandManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            Destroy(collision.gameObject);
        }
    }


}

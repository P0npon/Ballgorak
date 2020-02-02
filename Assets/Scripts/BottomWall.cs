using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Hit2") || collision.gameObject.layer == LayerMask.NameToLayer("Hit2A"))
        {
            Destroy(collision.gameObject);
        }
    }
}

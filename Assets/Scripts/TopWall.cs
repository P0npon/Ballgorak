using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hit1") || collision.gameObject.layer == LayerMask.NameToLayer("Hit1A"))
        {
            Destroy(collision.gameObject);
        }
    }
}

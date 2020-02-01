using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrefab : MonoBehaviour
{
    [SerializeField]
    float constantSpeed = 10f;
    private PlayerController player;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody.velocity = constantSpeed * (rigidbody.velocity.normalized);
    }
    private void OnDestroy()
    {
        player.BallLandingPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var block = collision.gameObject.GetComponents<Block>();
        if (block.Length!=0)
        {
            block[0].ChangeHealth(-1);
        }
    }
}

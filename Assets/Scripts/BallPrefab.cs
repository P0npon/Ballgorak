using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrefab : MonoBehaviour
{
    [SerializeField]
    float constantSpeed = 10f;
    private PlayerController player;
    private Rigidbody2D rigidbody;
    private bool player1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetPlayer(bool player1)
    {
        this.player1 = player1;
        this.gameObject.layer = player1 ? LayerMask.NameToLayer("Hit2"): LayerMask.NameToLayer("Hit1");
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
        Debug.Log("Hit");
        var block = collision.gameObject.GetComponents<Block>();
        if (block.Length!=0)
        {
            
            if (this.gameObject.layer == LayerMask.NameToLayer("Hit1") || this.gameObject.layer == LayerMask.NameToLayer("Hit2"))
            {
                Debug.Log("Hit1 ou Hit2");
                this.gameObject.layer = player1 ? LayerMask.NameToLayer("Hit2A") : LayerMask.NameToLayer("Hit1A");
                block[0].ChangeHealth(-1);
            }
            else if ((this.gameObject.layer == LayerMask.NameToLayer("Hit2A") && block[0].Player1) || (this.gameObject.layer == LayerMask.NameToLayer("Hit1A") && !block[0].Player1))
            {
                block[0].ChangeHealth(0.5f);
                Destroy(this.gameObject);
            }
        }
    }
}

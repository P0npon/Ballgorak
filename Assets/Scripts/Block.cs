using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    public bool Player1; 
    public float health;

    void Awake()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    public void InitBlock(int health, bool player1)
    {
        this.Player1 = player1;
        textMeshPro.color = player1?Color.green:Color.red;
        this.gameObject.layer = player1 ? LayerMask.NameToLayer("Block1") : LayerMask.NameToLayer("Block2");
        this.health = health;
        textMeshPro.text = health.ToString();
    }

    public void ChangeHealth(float change)
    {
        this.health += change;
        textMeshPro.text = health.ToString();
        if(health<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            Destroy(collision.gameObject);
        }
    }
}


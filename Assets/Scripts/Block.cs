using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    private TextMeshPro textMeshPro;

    public int health;

    void Awake()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    public void InitBlock(int health)
    {
        this.health = health;
        textMeshPro.text = health.ToString();
    }

    public void ChangeHealth(int change)
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


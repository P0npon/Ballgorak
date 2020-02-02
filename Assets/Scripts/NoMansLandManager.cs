using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMansLandManager : MonoBehaviour
{
    [SerializeField] LifeScript Bar1;
    [SerializeField] LifeScript Bar2;
    
  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            var block = collision.gameObject.GetComponent<Block>();
          if (block.Player1)
            {
                Bar2.ChangeLife(block.health);
            }
            else
            {
                Bar1.ChangeLife(block.health);
            }
            
            Destroy(collision.gameObject);

        }
    }


}

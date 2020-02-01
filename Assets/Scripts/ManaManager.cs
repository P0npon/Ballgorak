using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaManager : MonoBehaviour
{

    Image bar;
    Text txt;
    public Color AlertColor = Color.blue;
    Color startColor;
    public float Alerte = 25f;
    private float val;
    public float Val
    {
        get
        {
            return val;
        }
        set
        {
            val = value;
            val = Mathf.Clamp(val, 0, 10);
            bar.fillAmount = val / 10;
        }
    }


    void Awake()
    {
        var manager = GameObject.FindObjectOfType<MainManager>().GetComponent<MainManager>();
        manager.AddListeners(AddMana);
        bar = transform.Find("Bar").GetComponent<Image>();
        txt = bar.transform.Find("Text").GetComponent<Text>();
        startColor = bar.color;
        Val = 0;

    }


    
    
    void AddMana(int seconds)
    {
        if (seconds % 3==0)
        {
            Val++;

          
            txt.text = (int)Val + " Mana";
            
            if (Val == Alerte)
            {
                bar.color = AlertColor;
            }
            
            
        }
    }
}

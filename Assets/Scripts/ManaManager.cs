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
    private float mana;
    public float Mana
    {
        get
        {
            return mana;
        }
        set
        {
            mana = value;
            mana = Mathf.Clamp(mana, 0, 10);
            bar.fillAmount = mana / 10;
        }
    }


    void Awake()
    {
        var manager = GameObject.FindObjectOfType<MainManager>().GetComponent<MainManager>();
        manager.AddListeners(AddMana);
        bar = transform.Find("Bar").GetComponent<Image>();
        txt = bar.transform.Find("Text").GetComponent<Text>();
        startColor = bar.color;
        Mana = 0;

    }


    
    
    void AddMana(int seconds)
    {
        if (seconds % 3==0)
        {
            Mana++;

          
            txt.text = (int)Mana + " Mana";
            
            if (Mana == Alerte)
            {
                bar.color = AlertColor;
            }
            
            
        }
    }
}

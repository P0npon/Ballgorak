using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeScript : MonoBehaviour
{
    Image bar;
    Text txt;
    public Color AlertColor = Color.red;
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
            val = Mathf.Clamp(val, 0, 100);
            bar.fillAmount = val / 100;
        }
    }


    void Awake()
    {
        var manager = GameObject.FindObjectOfType<MainManager>().GetComponent<MainManager>();
        manager.AddListeners(UpdateValueLife);

        bar = transform.Find("Bar").GetComponent<Image>();
        txt = bar.transform.Find("Text").GetComponent<Text>();
        startColor = bar.color;
        Val = 100;

    }


    void UpdateValueLife(int seconds)
    {
        txt.text = (int)Val + "%";
        
        if (Val < Alerte)
        {
            bar.color = AlertColor;
        }
        else
        {
            bar.color = startColor;
        }
        
    }
  public  void ChangeLife(int heals)
    {
        Val = Val - heals;
    }

}

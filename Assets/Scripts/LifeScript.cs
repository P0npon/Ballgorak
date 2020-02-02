using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeScript : MonoBehaviour
{
    Image bar;
    Text txt;
    public Color AlertColor = Color.red;
    Color startColor;
    public float Alerte = 25f;
    private float life;
    public float Life
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
            life = Mathf.Clamp(Life, 0, 100);
            
        }
    }


    void Awake()
    {
       
        var manager = GameObject.FindObjectOfType<MainManager>().GetComponent<MainManager>();
        manager.AddListeners(UpdateValueLife);

        bar = transform.Find("Bar").GetComponent<Image>();
        txt = bar.transform.Find("Text").GetComponent<Text>();
        startColor = bar.color;
        Life = 100;

    }


    void UpdateValueLife(int seconds)
    {
        txt.text = (int)Life + "%";
        
        if (Life < Alerte)
        {
            bar.color = AlertColor;
        }
        else
        {
            bar.color = startColor;
        }
        
    }
  public  void ChangeLife(float heals)
    {
        
        Life = Life - heals;
        bar.fillAmount = Life / 100;

    }
    public void IsWinner()
    {
        if (Life == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       
    }

}

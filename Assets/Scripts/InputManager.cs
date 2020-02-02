using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool player1;

    public void SetPlayer(bool player1)
    {
        this.player1 = player1;
    }

    public bool hold = false, release = false;
    public Vector2 initialPosition;
    public Vector2 swipeDelta;


    private void Start()
    {
        var manager = GameObject.FindObjectOfType<MainManager>().GetComponent<MainManager>();
        manager.AddListeners(AfficherSecondesDeJeu);
    }


    // Update is called once per frame
    void Update()
    {
        release = false;
#if UNITY_ANDROID
        var halfTouch = Input.touches.ToList();
        if (player1)
        {
             halfTouch = Input.touches.ToList().FindAll(it => it.position.y < Screen.height / 2);
        }
        else
        {
             halfTouch = Input.touches.ToList().FindAll(it => it.position.y > Screen.height / 2);
        }

        if (halfTouch.Count > 0 )
        {
            if (halfTouch[0].phase == TouchPhase.Began)
            {
                hold = true;
                initialPosition = halfTouch[0].position;
            }

            else if (halfTouch[0].phase == TouchPhase.Ended)
            {

                Debug.Log("End");
                release = true;
                hold = false;
                swipeDelta = halfTouch[0].position - initialPosition;
            }
            if(hold)
            {
                swipeDelta = halfTouch[0].position - initialPosition;
            }
            else if (swipeDelta.x < 0 || swipeDelta.y < 0)
            {
                release = true;
            }
        }
#endif
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            hold = true;
            initialPosition = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {

            Debug.Log("End");
            release = true;
            hold = false;
            swipeDelta = (Vector2)Input.mousePosition - initialPosition;
        }
        if (hold)
        {
            swipeDelta = (Vector2)Input.mousePosition - initialPosition;
        }
        else if(swipeDelta.x < 0|| swipeDelta.y  < 0)
            {
            release = true;
        }

#endif
    }


    private void AfficherSecondesDeJeu(int seconds)
    {
        Debug.Log(seconds +" Seconds");
    }

}


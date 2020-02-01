using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

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
        if (Input.touches.Length > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                hold = true;
                initialPosition = Input.GetTouch(0).position;
            }

            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                Debug.Log("End");
                release = true;
                hold = false;
                swipeDelta = Input.GetTouch(0).position - initialPosition;
            }
            if(hold)
            {
                swipeDelta = Input.GetTouch(0).position - initialPosition;
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


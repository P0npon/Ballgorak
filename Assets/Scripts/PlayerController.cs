﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform wrapper;
    private const float maximumPull = 160f;
    [SerializeField]
    private InputManager inputInstance;

    [SerializeField]
    private Vector3 BallDirection;
    public Vector3 BallLandingPosition;
    private bool ballRelease;
    public bool BallMoving;
    [SerializeField]
    private int BallAmount = 1;
    [SerializeField]
    private int speed = 9;
    [SerializeField]
    private Ground ground;
    [SerializeField]
    private Rigidbody2D ballPrefab;
    [SerializeField] GameObject Ball1;
    [SerializeField] GameObject Ball2;
    [SerializeField] GameObject Ball3;
    [SerializeField] GameObject Ball4;
    [SerializeField] GameObject Ball5;


    // Start is called before the first frame update
    void Start()
    {
        wrapper.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("BallPrefab(Clone"))
        {
            BallMoving = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            BallMoving = false;
            GetComponent<SpriteRenderer>().enabled = true;
            transform.position = new Vector3(BallLandingPosition.x, transform.position.y, transform.position.z);
            ControlPlayer();
        }

        if(ballRelease)
        {
            inputInstance.swipeDelta = Vector2.zero;
            StartCoroutine(waitToReleaseBall());
            ballRelease = false;
        }
    }

    IEnumerator waitToReleaseBall()
    {
        for(int i =0; i<= BallAmount;i++)
        {
            Debug.Log("Ball instancied");
            Rigidbody2D ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.velocity = BallDirection * speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void ControlPlayer()
    {
        Vector2 sd = inputInstance.swipeDelta;
        sd.Set(-sd.x, -sd.y);

        if(sd != Vector2.zero)
        {
            if(sd.y <0)
            {
                wrapper.parent.gameObject.SetActive(false);
            }
            else
            {
                wrapper.parent.up = sd.normalized;
                wrapper.parent.gameObject.SetActive(true);
                wrapper.localScale = Vector3.Lerp(new Vector3(1,1,1), new Vector3(1.8f,1.8f,1f),sd.magnitude/maximumPull);
                if(inputInstance.release)
                {
                    wrapper.parent.gameObject.SetActive(false);
                    BallDirection = sd.normalized;
                    Debug.Log(BallDirection + "true");
                    ballPrefab.simulated = true;
                    ballRelease = true;
                }
            }
        }
    }
}

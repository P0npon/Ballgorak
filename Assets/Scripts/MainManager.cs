using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager gameManager;
    [SerializeField]
    private int speedGame =1;

    [SerializeField]
    private int speedTour =7;

    public int GameTime;

    public int Tour;

    public static MainManager GameManager { get { return gameManager; } }

    private List<Action<int>> actions = new List<Action<int>>();


    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameManager = this;
        }
    }


    public void AddListeners(Action<int> listener)
    {
        actions.Add(listener);
    }

    private void Start()
    {
        StartCoroutine(SetGameTime());
    }

    IEnumerator SetGameTime()
    {
        while (true)
        {
            foreach (var action in actions)
            {
                GameTime++;
                action.Invoke(GameTime);
            }
            yield return new WaitForSeconds(speedGame);
        }
    }

    IEnumerator SetGameTour()
    {
        while (true)
        {
            foreach (var action in actions)
            {
                GameTime++;
                action.Invoke(GameTime);
            }
            yield return new WaitForSeconds(speedTour);
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int points = 100;
    public static event Action OnBallDestroyed;

    private void OnMouseDown()
    {
        Debug.Log("Zz");
        OnBallDestroyed?.Invoke();
        Destroy(gameObject);
    }
}

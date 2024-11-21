using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class Game : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(2,5);
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxBallPrefab = 10;

    [SerializeField] private int currenctBalls = 0;
    

    private void Start()
    {
        Ball.OnBallDestroyed += ReduceBallCount;
        GenerateBallsAsync();        
    }
    
    private async void GenerateBallsAsync()
    {
        while (true)
        {
            await Task.Delay((int)spawnInterval*1000);
            if (currenctBalls < maxBallPrefab)
            {
                Vector2 spawnPoint = new Vector2(UnityEngine.Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2), UnityEngine.Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2));

                Instantiate(ballPrefab, spawnPoint, Quaternion.identity);
                currenctBalls++;
            }
        }
    }
    private void ReduceBallCount()
    {
        currenctBalls--;
    }
    private void OnDestroy() //desuscribir
    {
        Ball.OnBallDestroyed -= ReduceBallCount;
    }
}

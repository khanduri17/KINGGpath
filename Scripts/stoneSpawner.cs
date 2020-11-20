﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneSpawner : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] float period = 2f;
    [SerializeField] Vector3 movementVector = new Vector3(10f, 0f, 0f);
    [SerializeField] GameObject stone;
    [Range(0, 1)] [SerializeField] float movementFactor;
    [SerializeField] float timebetweenSpawn=2f;
    void Start()
    {
        startingPos = transform.position;
        
        
            StartCoroutine(spawnStone());
        
    }


    void Update()
    {
        move();

        stone.transform.position = new Vector3(0f, stone.transform.position.y, 0f);
    }

    

    IEnumerator spawnStone()
    {
        while (true)
        {

            Instantiate(stone, transform.position, Quaternion.identity);
      
            yield return new WaitForSeconds(timebetweenSpawn);

        }
        

    }

    

    private void move()
    {
        float cycles = Time.time / period;
        float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);
        movementFactor = rawSineWave / 2f + 0.5f;
        Vector3 offSet = movementVector * movementFactor;
        if (movementFactor <= 0.02f)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (movementFactor >= 0.99f)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        transform.position = startingPos + offSet;

      
    }
}

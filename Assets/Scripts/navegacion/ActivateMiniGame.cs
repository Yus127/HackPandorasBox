﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMiniGame : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.tag == "Player")
        {
            print("jala");
            GameManager.instance.Win();
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ActivateMinigame2 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.tag == "Player")
        {
            print("jala");
            SceneManager.LoadScene("Scene3.2");
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

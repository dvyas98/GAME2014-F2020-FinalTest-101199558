/*///////
File Name  : Scaling Platform
Student Name : Dhimant Vyas
Student ID : 101199558
Date Last Modified  : 15 December 2020
Controlling Scaling Platfroms.
//////*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacalingPlatform : MonoBehaviour
{
    public Vector3 normalScale; // TO reset everything back to normal on Reset.
    public PlayerBehaviour player;
    bool downScale;//Do we need to make the platform bigger or Smaller.
    bool upScale;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
    }
    // Update is called once per frame
    void Update()
    {
        if (upScale)// We make platform bigger only when It is already smaller in size.
        {
            _Move();
        }
        else
        {
            if (downScale) // When Player collided with Platform Downscale will turn to True and platform will start to shrink.
            {
                _Move();
            }
        }
    }

     private void  _Move()
    {
        if (upScale)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x + .6f * Time.deltaTime, this.transform.localScale.y + .6f * Time.deltaTime, this.transform.localScale.z);//UpScale the Platform 
            if (this.transform.localScale.x >= 1)
            {
                upScale = false;
            }
        }
        if (downScale)
        {        
            if (this.transform.localScale.x > 0.1)
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x - .6f * Time.deltaTime, this.transform.localScale.y - .6f * Time.deltaTime, this.transform.localScale.z);        // Till it is greater than 0.1 make it Smaller.     
            }
            if (this.transform.localScale.x <= 0.1)
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x + .6f * Time.deltaTime, this.transform.localScale.y - .6f * Time.deltaTime, this.transform.localScale.z); //Make it Bigger Again.
                downScale = false;
                upScale = true;// When Platform is small enough it will start to grow back to it size.
            }
        }
    }
    public void Reset()
    {
        transform.localScale = normalScale;  //Turn it back to normal when We reset the Game.
    }
    private void OnCollisionEnter2D(Collision2D collision)  // Start Everything when Player collides with the platform.
    {
        if (collision.gameObject.tag == "Player")
        {
           downScale = true;
        }
    }
}

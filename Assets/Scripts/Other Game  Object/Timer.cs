using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// timer created so it works past different levels
public class Timer : MonoBehaviour{
	Text               timerText;
	float 			   timer;

    void Start(){
    	timerText = this.GetComponent<Text>();//get timer text
        timer=0f;     	       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        string newTime="";
        if(timer>=3600){//played for more than hour
        	newTime += (int)(timer/3600)/10; //hour
        	newTime += ":";
        }
        newTime += (int)(timer/60)/10; //minute tens
        newTime += (int)(timer/60)%10;
        newTime += ":";
        newTime += (int)(timer%60)/10; //seconds tens place

        newTime += (int)(timer%60)%10; //ones place
        // newTime += ".";
        // newTime += (int)(timer*100)%100;
        //newTime += (int)(timer*100)%10;
        timerText.text= newTime;
        PlayerPrefs.SetFloat("FinalTimer",timer); //save last timer 
    }
}

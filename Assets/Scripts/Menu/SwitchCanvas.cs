using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvas : MonoBehaviour{
	public GameObject mainCanvas;
    public void openCanvas(GameObject newCanvas){ 
    	mainCanvas.SetActive(false);
    	newCanvas.SetActive(true);
        //**open up other canvas and disable this one
        //maybe get current canvas and new canvas or aleast tag
    }
    public void closeCanvas(GameObject newCanvas){
    	newCanvas.SetActive(false);
    	mainCanvas.SetActive(true);
    }

    public void popUp(GameObject canvas){ //use for error messages
        canvas.SetActive(true);
    }

    public void close(GameObject canvas){
    	canvas.SetActive(false);
    }
    
}

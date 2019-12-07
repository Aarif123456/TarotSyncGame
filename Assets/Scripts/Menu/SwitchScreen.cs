using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SwitchScreen : MonoBehaviour
{
	public Image transition;
	public Animator animator;

    public void switchScreen(string screenName){
    	PlayerPrefs.SetString("lastScene",SceneManager.GetActiveScene().name); //store current scene
    	StartCoroutine(fading(screenName));
    }

    public void loadScreen(string screenName){
        PlayerPrefs.SetString("loadScene",screenName);//hold screen to load
        switchScreen("Loading_Screen");
    }

    

    public void back(){
    	switchScreen(PlayerPrefs.GetString("lastScene"));

    }

    public void exit(){
    	Application.Quit();
    }

    IEnumerator fading(string screenName){
        //start async loading with fade then
        AsyncOperation ao = SceneManager.LoadSceneAsync(screenName);
        ao.allowSceneActivation = false; //don't load when fading out
    	animator.SetBool("Fade",true);
    	yield return new WaitUntil(()=>transition.color.a==1); //when faded out
        ao.allowSceneActivation = true; //load screen when done
    	//SceneManager.LoadScene(screenName); 
        
    }
}

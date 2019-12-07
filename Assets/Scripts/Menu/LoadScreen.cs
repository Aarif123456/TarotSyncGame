using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen: MonoBehaviour
{
	public Image transition;
	public Animator animator;
    //public GameObject loadingScreen;
    public Slider loadingBar;
    public Text   progress;

    void Awake(){
        // PlayerPrefs.SetInt("NextLife",0); //set up game
        PlayerPrefs.SetInt("lives",3);
        StartCoroutine(letLoad());       
    }

    IEnumerator letLoad(){
        yield return new WaitForSeconds(1);
        StartCoroutine(loading(PlayerPrefs.GetString("loadScene"))); //
    }

    IEnumerator loading(string screenName){

        //start async loading with fade then
        AsyncOperation ao = SceneManager.LoadSceneAsync(screenName);
        ao.allowSceneActivation = false; //don't load when fading out
        while (!ao.isDone){
            loadingBar.value = ao.progress/0.9f; //show progress 
            if (ao.progress == 0.9f){
                animator.SetBool("Fade",true);
                yield return new WaitUntil(()=>transition.color.a==1); //when faded out
                ao.allowSceneActivation = true; //load screen when done
            }
            progress.text=(int)(loadingBar.value * 100) + "%";
        }
        //Set text to loaded

        
    	//SceneManager.LoadScene(screenName); 

    }
}

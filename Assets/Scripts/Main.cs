using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	static public Main S;
	public int    lives;
    public int  bootBlasts = 0; //number of double jumps player has **or duration
    public int  teleports = 0; //teleports player has
    public int  crossBowShots =0;  //number of shots player has with crossbow
    
    // Start is called before the first frame update
    void Awake() {
        if(S!=null){
            Destroy(gameObject);
        }
        else{
            S = this;  
            lives =PlayerPrefs.GetInt("lives");
            // DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerDamage(){
        SwitchScreen s=this.GetComponent<SwitchScreen>();
        lives -= 1;
        if(lives <=0){ //should never be less than 0 but just in case
            s.loadScreen("level1"); //go reset game
        }
        else{
            PlayerPrefs.SetInt("lives",lives);
            s.switchScreen("level1");
        }  
    }
}

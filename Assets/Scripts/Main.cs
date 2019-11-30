using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	static public Main S;
	public int    lives=3;
    // Start is called before the first frame update
    void Awake() {
        if(S!=null){
            Destroy(gameObject);
        }
        else{
            S = this;  
            //DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

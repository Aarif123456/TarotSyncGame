using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
	
	public GameObject panel,lifePrefab;

    // Start is called before the first frame update
    void Start()
    {
    	List<GameObject> lives=new List<GameObject>();
    	for(int i=0;i<Main.S.lives;i++){
    		lives.Add(Instantiate<GameObject>(lifePrefab,new Vector3(0f, 0f, 0f), Quaternion.identity));
    		lives[i].transform.SetParent(panel.transform,false);
    	}
        
    }


}

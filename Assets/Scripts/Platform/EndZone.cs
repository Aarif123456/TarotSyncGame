using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EndZone : MonoBehaviour
{
	public SerializedObject halo;
	
    void OnTriggerEnter(Collider other) {
     	//if hit the ground then player becomes grounded
     	if(other.gameObject.tag == "Player" ){
     		SerializedObject halo = new SerializedObject(this.gameObject.GetComponent("Halo"));
     		halo.FindProperty("m_Size").floatValue = 5;
        	halo.FindProperty("m_Enabled").boolValue = true;
            halo.FindProperty("m_Color").colorValue = Color.green;
            halo.ApplyModifiedProperties();
            return;
        }
    }
}

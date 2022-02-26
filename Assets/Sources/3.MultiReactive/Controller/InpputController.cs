using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InpputController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
	        Contexts.sharedInstance.input.CreateEntity().isMultiReactiveDeatroyed = true;
	    }
    }
}

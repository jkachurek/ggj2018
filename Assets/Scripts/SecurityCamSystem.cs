using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecurityCam {

    public string Name;
    public Vector3 Position { get; set; }
}

public class SecurityCamSystem : MonoBehaviour {

    public Camera SecurityCamPrefab;
    public int SecurityCamAmt;
    public Vector3[] SecurityCams;
    public string test;

	// Use this for initialization
	void Start () {

        for (int x = 0; x < SecurityCamAmt; x++)
        {
            Instantiate(SecurityCamPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            // cube.transform.position = new Vector3(x, y, 0);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

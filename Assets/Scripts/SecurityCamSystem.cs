using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SecurityCam {

    public string Name;
    public Vector3 Position;
    public float RotationPause;
    public float RotationBegin;
    public float RotationEnd;
}

public class SecurityCamSystem : MonoBehaviour {

    public Camera SecurityCamPrefab;
    public SecurityCam[] SecurityCameras;

    // Use this for initialization
    void Start () {

        for (int x = 0; x < SecurityCameras.Length; x++)
        {
            Instantiate(SecurityCamPrefab, SecurityCameras[x].Position, Quaternion.identity);
   
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

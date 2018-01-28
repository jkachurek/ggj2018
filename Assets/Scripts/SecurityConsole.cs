using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SecurityCam
{
    public string Name;
    public GameObject SecurityCamObject;
    public float Distance;
}

public class SecurityConsole : MonoBehaviour
{
    public GameObject ConsoleGuiCamera;
    public RenderTexture[] SecurityScreenArray;

    private GameObject Player;
    private GameObject PlayerRenderer;

    private List<SecurityCam> SecurityCameraList = new List<SecurityCam>();

    // Use this for initialization
    void Start()
    {

        StartCoroutine(InitializeSecurityCams());
        InvokeRepeating("ChangeCameraViews", 1.0f, 5.0f);
    }

    IEnumerator InitializeSecurityCams()
    {

        //returning 0 will make it wait 1 frame
        yield return 0;

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRenderer = GameObject.FindGameObjectWithTag("PlayerRenderer");

        var securityCamObjectArray = GameObject.FindGameObjectsWithTag("SecurityCamera");
        foreach (GameObject securityCamObj in securityCamObjectArray)
        {
            SecurityCameraList.Add(new SecurityCam()
            {
                Name = securityCamObj.name,
                SecurityCamObject = securityCamObj
            });
        }


    }
    // Update is called once per frame
    void Update()
    {

    }

    void ChangeCameraViews()

    {
        foreach (SecurityCam securityCam in SecurityCameraList)
        {
            bool onScreen = false;
            securityCam.Distance = Vector3.Distance(Player.transform.position, securityCam.SecurityCamObject.transform.position);
            securityCam.SecurityCamObject.GetComponent<Camera>().targetTexture = null;
            securityCam.SecurityCamObject.SetActive(false);

            Vector3 screenPoint = securityCam.SecurityCamObject.GetComponent<Camera>().WorldToViewportPoint(Player.transform.position);

            Vector3 rayDir = Player.transform.position - securityCam.SecurityCamObject.transform.position;
            RaycastHit info;
            Physics.Raycast(securityCam.SecurityCamObject.transform.position, rayDir, out info, 100);
            if (info.transform == Player.transform)
            {
                onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            }

            if (onScreen) { securityCam.Distance = 0; }

            List<SecurityCam> SortedSecurityCameraList = SecurityCameraList.OrderBy(o => o.Distance).ToList();

            for (int cameraToActivate = 0; cameraToActivate < 4; cameraToActivate++)
            {
                SortedSecurityCameraList[cameraToActivate].SecurityCamObject.GetComponent<Camera>().targetTexture = SecurityScreenArray[cameraToActivate];
                SortedSecurityCameraList[cameraToActivate].SecurityCamObject.SetActive(true);
            }
        }

    }
}

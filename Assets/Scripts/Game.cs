using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public GameObject SecurityScreenBattery;
    public Sprite[] BatteryLife;
    public float TimeToLive;

    private int batteryLevel = 5;

    [SerializeField]
    private string levelSceneName = "LevelTest";
    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene(levelSceneName, LoadSceneMode.Additive);
        //  this.GetComponent<Camera>().enabled = true;
        //  this.GetComponent<Camera>().gameObject.SetActive(true);

        InvokeRepeating("ChangeBatteryLife", 1.0f, TimeToLive / 5f);

    }

    // Update is called once per frame
    void Update()
    {

        //   Debug.Log("TEST");
    }

    void ChangeBatteryLife()
    {

        if (batteryLevel == 0)
        {

            Debug.Log("End Game!");

        }

        SecurityScreenBattery.GetComponent<Image>().sprite = BatteryLife[batteryLevel - 1];
        batteryLevel--;

    }
}

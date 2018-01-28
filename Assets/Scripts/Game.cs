using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject Player;

    public GameObject SecurityScreenBattery;
    public Sprite[] BatteryLife;
    public float TimeToLive;

    public GameObject BlowUp;
    public AudioClip explosion;

    public GameObject SecurityScreenEndGame;
    public Sprite EndGame_Win;
    public Sprite EndGame_Lose;

    private AudioSource audioSource;
    private int batteryLevel = 5;


    [SerializeField]
    private string levelSceneName = "LevelTest";
    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene(levelSceneName, LoadSceneMode.Additive);
        audioSource = GetComponent<AudioSource>();

        InvokeRepeating("ChangeBatteryLife", 1.0f, TimeToLive / 5f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeBatteryLife()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (batteryLevel <= 1)
        {

            Debug.Log("End Game!");


            if (Player) StartCoroutine("DestroyPlayer");
            batteryLevel = 1;
        }

        SecurityScreenBattery.GetComponent<Image>().sprite = BatteryLife[batteryLevel - 1];
        batteryLevel--;

    }

    IEnumerator DestroyPlayer()
    {
        BlowUp.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        Player.transform.position = new Vector3(Player.transform.position.x, -50f, Player.transform.position.z);

        audioSource.PlayOneShot(explosion, 0.7F);
        BlowUp.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(2);

        audioSource.Stop();
        SecurityScreenEndGame.GetComponent<Image>().sprite = EndGame_Lose;
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager manager;

    public int score = 0;
    private int playerHealth;

    public Slider energy_Bar;

    private GameObject player_2;

    [SerializeField]
    private TMP_Text scoreText = null;

    [SerializeField]
    private GameObject iconPrefab = null;
    [SerializeField]
    private Transform iconHolder = null;
    [SerializeField]
    private Vector3 iconOffset = Vector3.zero;
    private List<GameObject> iconInstances;

    private bool playerMouse_check;

    private void Awake()
    {
        manager = this;
    }

    void Start()
    {
        playerHealth = Player_2.Continues;
        iconInstances = new List<GameObject>();

        player_2 = GameObject.Find("Player_2");
        if(player_2 == null)
        {
            playerMouse_check = true;
            player_2 = GameObject.Find("Player_Mouse");
        }
        if (player_2.GetComponent<Player_2>()!=null)
        {
            energy_Bar.maxValue = player_2.GetComponent<Player_2>().maxEnergy;
            energy_Bar.value = player_2.GetComponent<Player_2>().maxEnergy;
        }
        else 
        {
            playerMouse_check = true;
            energy_Bar.maxValue = player_2.GetComponent<Player_Mouse>().maxEnergy;
            energy_Bar.value = player_2.GetComponent<Player_Mouse>().maxEnergy;
        }

    }

    public void FixedUpdate()
    {
        if (playerMouse_check == false)
        {
            energy_Bar.value = player_2.GetComponent<Player_2>().curEnergy;
        }
        else
        {
            energy_Bar.value = player_2.GetComponent<Player_Mouse>().curEnergy;
        }
    }

    private void Update()
    {
        int health = playerHealth;
        playerHealth = Player_2.Continues;
        // if less icons are there as should be
        while (health > iconInstances.Count)
        {
            Vector3 position = iconHolder.position + iconOffset * iconInstances.Count;
            GameObject iconInstance = GameObject.Instantiate(iconPrefab, position, Quaternion.identity, iconHolder);
            iconInstances.Add(iconInstance);
        }
        // if more icons are there as should be
        while (health < iconInstances.Count)
        {
            GameObject iconInstance = iconInstances[iconInstances.Count - 1];
            iconInstances.RemoveAt(iconInstances.Count - 1);
            Destroy(iconInstance);
        }
    }

    void LateUpdate()
    {
        scoreText.text = score.ToString();
    }
}

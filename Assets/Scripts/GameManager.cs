using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PrefabManager))]
[RequireComponent(typeof(TimeManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PrefabManager prefabManager;


    public TimeManager timeManager;


    public MapManager mapManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null)
        {   
            Destroy(this);
            return; 
        }
        instance = this;

        prefabManager = GetComponent<PrefabManager>();
        timeManager = GetComponent<TimeManager>();
        StartNewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void StartNewGame()
    {
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        timeManager.ResetTime();
        yield return null;
        timeManager.StartTime(); 
    }
}

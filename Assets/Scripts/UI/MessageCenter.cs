using System.Collections;
using TMPro;
using UnityEngine;

public class MessageCenter : MonoBehaviour
{

    public GameObject MesagePrefab;

    public GameObject Viewport; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator testing()
    {
        int tick = 0;
        while (true)
        {
             
            ShowMessage($"This is a test{tick}", Color.magenta);
            tick++; 
            yield return new WaitForSeconds(1);
        }
    }

    public void ShowMessage(string message, Color color)
    {
        var obj = Instantiate(MesagePrefab, Viewport.transform);
        var text = obj.GetComponent<TextMeshProUGUI>(); 
        text.color = color;
        text.text = message;
    }
}

using UnityEngine;

public class UIController : MonoBehaviour
{

    public MessageCenter MessageCenter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MessageCenter = GetComponentInChildren<MessageCenter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

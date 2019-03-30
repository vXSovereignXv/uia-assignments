using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class WebTestObject : MonoBehaviour
{
    private string _message;

    [DllImport("__Internal")]
    private static extern void ShowAlert(string msg);

    // Start is called before the first frame update
    void Start()
    {
        _message = "No message yet";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //ShowAlert("Hello out there!");
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), _message);
    }

    public void RespondToBrowser(string message)
    {
        _message = message;
    }
}

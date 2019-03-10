using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using MiniJSON;
using UnityEngine;

public class WeatherManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public float cloudValue { get; private set; }

    private NetworkService _network;

    public void StartUp(NetworkService service)
    {
        Debug.Log("Weather manager starting...");

        _network = service;
        StartCoroutine(_network.GetWeatherJson(OnJsonDataLoaded));
        status = ManagerStatus.Initializing;
    }

    private void OnXmlDataLoaded(string data)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        XmlNode root = doc.DocumentElement;

        XmlNode node = root.SelectSingleNode("clouds");
        string value = node.Attributes["value"].Value;
        cloudValue = Convert.ToInt32(value) / 100f;
        Debug.Log("Value: " + cloudValue);

        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);

        status = ManagerStatus.Started;
    }

    private void OnJsonDataLoaded(string data)
    {
        Dictionary<string, object> dict;
        dict = Json.Deserialize(data) as Dictionary<string, object>;
        Dictionary<string, object> clouds = (Dictionary<string, object>)dict["clouds"];
        cloudValue = (long)clouds["all"] / 100f;

        Debug.Log("Value: " + cloudValue);

        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);

        status = ManagerStatus.Started;
    }
}

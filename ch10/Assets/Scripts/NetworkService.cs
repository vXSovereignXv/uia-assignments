using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService {
    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=Minneapolis,us&mode=xml&APPID=e220792be5e31da63e7eb3c6ea85b7bb";
    private const string jsonApi = "http://api.openweathermap.org/data/2.5/weather?q=Minneapolis,us&APPID=e220792be5e31da63e7eb3c6ea85b7bb";
    private const string webImage = "http://upload.wikimedia.org/wikipedia/commons/c/c5/Moraine_Lake_17092005.jpg";

    private IEnumerator CallApi(string url, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if(request.isNetworkError)
            {
                Debug.LogError("network problem: " + request.error);
            }
            else if (request.responseCode != (long)System.Net.HttpStatusCode.OK)
            {
                Debug.LogError("response error: " + request.responseCode);
            }
            else
            {
                callback(request.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallApi(xmlApi, callback);
    }

    public IEnumerator GetWeatherJson(Action<string> callback)
    {
        return CallApi(jsonApi, callback);
    }

    public IEnumerator DownloadImage(Action<Texture2D> callback)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(webImage))
        {
            yield return request.SendWebRequest();
            callback(DownloadHandlerTexture.GetContent(request));
        }
    }
}

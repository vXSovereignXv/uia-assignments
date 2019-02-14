using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private InputField nameInput;

    private void Start()
    {
        float defaultSpeed = PlayerPrefs.GetFloat("speed", 1);
        speedSlider.value = defaultSpeed;
        nameInput.text = PlayerPrefs.GetString("name", string.Empty);

        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, defaultSpeed);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name)
    {
        PlayerPrefs.SetString("name", name);
        Debug.Log(name);
    }

    public void OnSpeedValue(float speed)
    {
        PlayerPrefs.SetFloat("speed", speed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }
}

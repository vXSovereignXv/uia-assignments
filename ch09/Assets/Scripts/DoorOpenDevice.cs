using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] private Vector3 dPos;
    [SerializeField] private float openTime = 1f;

    private bool _open;
    private bool operating;

    public void Operate()
    {
        if (!operating)
        {
            if (_open)
            {
                Vector3 pos = transform.position - dPos;
                iTween.MoveTo(gameObject, pos, openTime);
                StartCoroutine(DisableDoor());
            }
            else
            {
                Vector3 pos = transform.position + dPos;
                iTween.MoveTo(gameObject, pos, openTime);
                StartCoroutine(DisableDoor());
            }
        }
    }

    public void Activate()
    {
        if (!operating && !_open)
        {
            Vector3 pos = transform.position + dPos;
            iTween.MoveTo(gameObject, pos, openTime);
            StartCoroutine(DisableDoor());
        }
    }

    public void Deactivate()
    {
        if (!operating && _open)
        {
            Vector3 pos = transform.position - dPos;
            iTween.MoveTo(gameObject, pos, openTime);
            StartCoroutine(DisableDoor());
        }
    }

    private IEnumerator DisableDoor()
    {
        operating = true;
        yield return new WaitForSeconds(openTime);
        operating = false;
        _open = !_open;
    }
}

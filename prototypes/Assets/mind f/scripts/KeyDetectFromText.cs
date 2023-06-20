using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDetectFromText : MonoBehaviour
{
    [SerializeField] private UnityEvent myEvent;
    TextMesh text;
    string key;
    KeyCode keyCode;

    void Start()
    {
        text = GetComponent<TextMesh>();
        key = text.text.ToString();
        text.text = text.name + " " + key;

        KeyCode kc = (KeyCode)Enum.Parse(typeof(KeyCode), key);
        keyCode = kc;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            myEvent.Invoke();
            Debug.Log("INVOKED");
        }
    }
}

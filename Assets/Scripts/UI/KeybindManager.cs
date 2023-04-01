using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    private GameObject[] keybindButtons;

    private static KeybindManager instance;

    public static KeybindManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<KeybindManager>();
            }
            return instance;
        }
    }

    public Dictionary<string, KeyCode> Keybinds { get; private set; }

    public Dictionary<string, KeyCode> ActionBinds { get; private set; }

    private string bindName;

    private void Awake()
    {
        keybindButtons = GameObject.FindGameObjectsWithTag("Keybind");
    }

    private void Start()
    {

        Keybinds = new Dictionary<string, KeyCode>();
        ActionBinds = new Dictionary<string, KeyCode>();

        BindKey("Forward", KeyCode.W);
        BindKey("Backwards", KeyCode.S);
        BindKey("Left", KeyCode.A);
        BindKey("Right", KeyCode.D);
        BindKey("Jump", KeyCode.Space);
        BindKey("Brake", KeyCode.LeftControl);

        BindKey("ACT Nitro", KeyCode.LeftShift);
        BindKey("ACT Ability 1", KeyCode.Q);
        BindKey("ACT Ability 2", KeyCode.E);
    }

    public void BindKey(string key, KeyCode keyBind)
    {
        Dictionary<string, KeyCode> currentDictionary = Keybinds;

        if (key.Contains("ACT"))
        {
            currentDictionary = ActionBinds;
        }

        if (!currentDictionary.ContainsValue(keyBind))
        {
            currentDictionary.Add(key, keyBind);
            UpdateKeyText(key, keyBind);
        }
        else if (currentDictionary.ContainsValue(keyBind))
        {
            string existingKey = currentDictionary.FirstOrDefault(x => x.Value == keyBind).Key;
            currentDictionary[existingKey] = KeyCode.None;
            UpdateKeyText(key, KeyCode.None);
        }

        currentDictionary[key] = keyBind;
        UpdateKeyText(key, keyBind);
        bindName = string.Empty;
    }

    public void UpdateKeyText(string key, KeyCode code)
    {
        TMPro.TextMeshProUGUI tmp = Array.Find(keybindButtons, x => x.name == key).GetComponentInChildren<TMPro.TextMeshProUGUI>();
        tmp.text = code.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveUpgrade
{
    public string title;
    public int count;

    public SaveUpgrade(string title, int count)
    {
        this.title = title;
        this.count = count;
    }
}

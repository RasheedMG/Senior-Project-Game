using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveItem
{
    public string itemName;
    public int count;

    public SaveItem(string itemName,int count)
    {
        this.itemName = itemName;
        this.count = count;
    }

    public void setName(string itemName)
    {
        this.itemName = itemName;
    }

    public void setCount(int count)
    {
        this.count = count;
    }

    public string getName()
    {
        return this.itemName;
    }

    public int getCount()
    {
        return this.count;
    }
}

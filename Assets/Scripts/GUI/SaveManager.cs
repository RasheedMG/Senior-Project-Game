using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveManager
{
    public static bool isNewGame=false;
    public static int slotNum;
    public static void SaveData(PlayerData data)
    {
        switch (slotNum) {
            case 1:
                {
                    string filePath = Application.persistentDataPath + "/player1.json";
                    string JSONdata = JsonUtility.ToJson(data);
                    System.IO.File.WriteAllText(filePath, JSONdata);
                    break;
                }
            case 2:
                {
                    string filePath = Application.persistentDataPath + "/player2.json";
                    string JSONdata = JsonUtility.ToJson(data);
                    System.IO.File.WriteAllText(filePath, JSONdata);
                    break;
                    
                }
            case 3:
                {
                    string filePath = Application.persistentDataPath + "/player3.json";
                    string JSONdata = JsonUtility.ToJson(data);
                    System.IO.File.WriteAllText(filePath, JSONdata);
                    break;
                }
            default:
                    break;
    }
    }

    public static PlayerData LoadData()
    {
        switch (slotNum)
        {
            case 1:
                {
                    string filePath = Application.persistentDataPath + "/player1.json";
                    if (System.IO.File.Exists(filePath))
                    {
                        string JSONdata = System.IO.File.ReadAllText(filePath);
                        PlayerData data = JsonUtility.FromJson<PlayerData>(JSONdata);
                        return data;
                    }
                    else
                        return null;
                }
            case 2:
                {
                    string filePath = Application.persistentDataPath + "/player2.json";
                    if (System.IO.File.Exists(filePath))
                    {
                        string JSONdata = System.IO.File.ReadAllText(filePath);
                        PlayerData data = JsonUtility.FromJson<PlayerData>(JSONdata);
                        return data;
                    }
                    else
                        return null;
                }
            case 3:
                {
                    string filePath = Application.persistentDataPath + "/player3.json";
                    if (System.IO.File.Exists(filePath))
                    {
                        string JSONdata = System.IO.File.ReadAllText(filePath);
                        PlayerData data = JsonUtility.FromJson<PlayerData>(JSONdata);
                        return data;
                    }
                    else
                        return null;
                }
            default:
                return null;
        }
    }

    public static DateTime getDate(int x)
    {
        switch (x)
        {
            case 1:
                {
                    string filePath = Application.persistentDataPath + "/player1.json";
                    DateTime dateTime = System.IO.File.GetLastWriteTime(filePath);
                    return dateTime;
                }
            case 2:
                {
                    string filePath = Application.persistentDataPath + "/player2.json";
                    DateTime dateTime = System.IO.File.GetLastWriteTime(filePath);
                    return dateTime;
                }
            case 3:
                {
                    string filePath = Application.persistentDataPath + "/player3.json";
                    DateTime dateTime = System.IO.File.GetLastWriteTime(filePath);
                    return dateTime;
                }
            default:
                return DateTime.Now;
        }
    }
}

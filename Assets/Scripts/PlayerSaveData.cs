using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerSaveData : MonoBehaviour
{
    public string playerName;
    public int playerAge;
    public string playerLocation;
    public int Score;
    public static PlayerSaveData Instance;
    private void Awake()
    {
        Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        SetData();
        GetData();
        Debug.Log("saved score:" + ScoreManager.instance.score);
    }
    public void SetData()
    {
        string path = Application.persistentDataPath + "/PlayerData.file";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        BinaryWriter writer = new BinaryWriter(stream);
        formatter.Serialize(stream, playerName);
        formatter.Serialize(stream, playerAge);
        formatter.Serialize(stream, playerLocation);
        stream.Close();
    }
    public void GetData()
    {
        string path = Application.persistentDataPath + "/PlayerData.file";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        formatter.Deserialize(stream);
        stream.Close();
    }
}
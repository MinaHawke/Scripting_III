using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;

public class SaveableObject : MonoBehaviour
{
    private Player m_player;

    void Start()
    {
        //GenerateNewPlayer ();
        //SaveBin           ();
        LoadBin             ();
        LoadJSON            ();
    }

    void SaveBin           ()
    {
        BinaryFormatter bf   = new BinaryFormatter();
        FileStream      file = File.Create(Application.persistentDataPath + "/GameData.jal");
        bf.Serialize(file, m_player);
        file.Close();
    }

    void LoadBin           ()
    {
        BinaryFormatter bf   = new BinaryFormatter();
        FileStream      file = File.Open(Application.persistentDataPath + "/GameData.jal", FileMode.Open);
        m_player             = (Player)bf.Deserialize(file);

        Debug.Log(m_player.m_playerName);

    }

    void SaveXML           ()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Player));
        FileStream    file = File.Create(Application.persistentDataPath + "/GameData.xml");
        serializer.Serialize(file, m_player);
        file.Close();
    }

    void LoadXml           ()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Player));
        FileStream    file = File.Open(Application.persistentDataPath + "/GameData.xml", FileMode.Open);
        m_player = (Player)serializer.Deserialize(file);

        
        Debug.Log(m_player.m_playerName);
    }

    void SaveJSON          ()
    {
        string      json = JsonUtility.ToJson(m_player);
        File.WriteAllText(Application.persistentDataPath + "/GameData.json", json);
    }

    void LoadJSON          ()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/GameData.json");
        m_player = JsonUtility.FromJson<Player>(json);

        Debug.Log(m_player.m_playerName);

    }

    void GenerateNewPlayer ()
    {
        // Creamos datos del jugador
        m_player                 = new Player();
        m_player.m_playerName    = "NoName";

    }
}


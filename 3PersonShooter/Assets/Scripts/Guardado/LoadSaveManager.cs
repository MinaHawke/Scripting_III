using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
	public void SaveGameScene ()
    {
        SaveableMonoBehaviour[] saveGOVector = FindObjectsOfType<SaveableMonoBehaviour>();
        List<TransformData>     tranformList = new List<TransformData>();

        for (int i = 0; i < saveGOVector.Length; i++)
        {
            tranformList.Add(saveGOVector[i].GetData());
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<TransformData>));
        FileStream    file = File.Create(Application.persistentDataPath + "/GameSceneData.xml");
        serializer.Serialize(file, tranformList);
        file.Close();
	}

    public void LoadGameScene ()
    {
        XmlSerializer       serializer   = new XmlSerializer(typeof(List<TransformData>));
        FileStream          file         = File.Open(Application.persistentDataPath + "/GameSceneData.xml", FileMode.Open);
        List<TransformData> transformList = (List<TransformData>)serializer.Deserialize(file);

        SaveableMonoBehaviour[] saveGOVector = FindObjectsOfType<SaveableMonoBehaviour>();
        
        for (int i = 0; i < saveGOVector.Length; i++)
        {
            for (int j = 0; j < transformList.Count; j++)
            {
                if (saveGOVector[i].transform.name.Equals(transformList[j].m_name))
                {
                    saveGOVector[i].SetData(transformList[j]);
                    transformList.Remove(transformList[j]);
                    break;
                }
            }
        }
	}
}

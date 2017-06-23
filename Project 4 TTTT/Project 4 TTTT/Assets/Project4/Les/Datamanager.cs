using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Datamanager : MonoBehaviour
{
    public DataHolder dataHolder;

    void Start()
    {
        //dataHolder = new DataHolder();

        dataHolder = Load();

        dataHolder.testInt = 100;

        //Save(dataHolder);

        PlayerPrefs.SetInt("testInt", 100);

        print(PlayerPrefs.GetInt("testInt"));
    }

    /*public void Save(DataHolder toSafe)
    {
        var serializer = new XmlSerializer(typeof(DataHolder));

        using (var stream = new FileStream(Application.dataPath + "/TestSafe.xml", FileMode.Create))
        {
            serializer.Serialize(stream, toSafe);

        }
    }*/

    public DataHolder Load()
    {
        var serializer = new XmlSerializer(typeof(DataHolder));

        using (var stream = new FileStream(Application.dataPath + "/TestSafe.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as DataHolder;

        }
    }
}

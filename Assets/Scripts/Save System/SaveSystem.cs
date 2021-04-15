using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static void SaveScene (Scenee scene){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.x";
        FileStream stream = new FileStream(path,FileMode.Create);

        SceneData data = new SceneData(scene);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static SceneData LoadScene(){
        string path = Application.persistentDataPath + "/player.x";

        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            SceneData data = formatter.Deserialize(stream) as SceneData;
            stream.Close();
            return data;
        }
        else{
            return null;
        }
    }
}

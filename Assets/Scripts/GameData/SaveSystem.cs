using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


    public static class SaveSystem
    {
        public static void SaveConfigData(ScriptableConfig sc)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                string path = Application.persistentDataPath + "/configData.nero";

                FileStream fs = new FileStream(path, FileMode.Create);
                ConfigData data = new ConfigData(sc);
                bf.Serialize(fs, data);
                fs.Close();
                Debug.Log("ConfigData Saved!");

            }
            catch (Exception e) { Debug.LogError(e); }
        }

        public static ConfigData LoadConfigData()
        {
            string path = Application.persistentDataPath + "/configData.nero";
            if (File.Exists(path))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream(path, FileMode.Open);
                    ConfigData data = bf.Deserialize(fs) as ConfigData;
                    fs.Close();
                    Debug.Log("ConfigData Loaded!");
                    return data;
                }
                catch (Exception e) { Debug.LogError(e); }
            }
            else { return null; }
            return null;
        }

    }

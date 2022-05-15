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

        public static void SaveGameData(ScriptableGameData sc)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                string path = Application.persistentDataPath + "/gameData.nero";
                FileStream fs = new FileStream(path, FileMode.Create);
                GameData data = new GameData(sc);
                bf.Serialize(fs, data);
                fs.Close();
                Debug.Log("GameData saved!");
            }
            catch (Exception e) { Debug.LogError(e); }
        }

        public static void deleteGameData() {
        string path = Application.persistentDataPath + "/gameData.nero";
        if (File.Exists(path))
        File.Delete(path);
        }
        public static GameData LoadGameData() { 
            string path= Application.persistentDataPath + "/gameData.nero";
        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(path, FileMode.Open);
                GameData data = bf.Deserialize(fs) as GameData;
                fs.Close();
                Debug.Log("GameData loaded!");
                if (data == null) { return null; } else { return data; }
            }
            catch (Exception e) { Debug.LogError(e); }

        }
        else { return null; }
        return null;
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
                    if (data == null) { return null; } else { return data; }
                   
                }
                catch (Exception e) { Debug.LogError(e); }
            }
            else { return null; }
            return null;
        }

    }

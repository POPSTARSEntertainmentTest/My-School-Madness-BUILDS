using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    const string settingsFileName = "game_settings.data";

    public static void SaveSettingsData(SettingsOptionClass settingsOptionClass)
    {
        string jsonFormated = JsonUtility.ToJson(settingsOptionClass);
        WriteFile(settingsFileName, jsonFormated);
    }

    public static void LoadSettingsData()
    {
        SettingsOptionClass settingsOptionClass = new SettingsOptionClass();
        string readerJSON = ReadFile(settingsFileName);
    }

    public static void WriteFile(string fileName , string json)
    {
        string path = getSaveDirectory(fileName);
        FileStream fileStream = new FileStream(path,FileMode.Create);

        using (StreamWriter streamWriter = new StreamWriter(fileStream))
            streamWriter.Write(json);
    }

    public static string ReadFile(string fileName)
    {
        string path = getSaveDirectory(fileName);

        if (File.Exists(path))
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string readedJSON = streamReader.ReadToEnd();
                return readedJSON;
            }
        }
        else
            Debug.LogWarning("//File Manager// File => " + fileName + " has not been founded.");

        return "";
    }

    public static string getSaveDirectory(string fileName = null)
    {
        return fileName == null ? Application.persistentDataPath : Application.persistentDataPath + "/" + fileName;
    }
}

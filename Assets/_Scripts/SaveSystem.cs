using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePlayer(PlayerCollision player, PlayerBehaviour playerBehaviour)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.gd";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, playerBehaviour);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveItems(GameObject items)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/items.gd";
        FileStream stream = new FileStream(path, FileMode.Create);

        ItemData data = new ItemData(items);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.gd";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static ItemData LoadItems()
    {
        string path = Application.persistentDataPath + "/items.gd";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ItemData data = formatter.Deserialize(stream) as ItemData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}

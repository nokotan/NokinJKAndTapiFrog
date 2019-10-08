using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : ObjectRecorderBase
{
    static public NewPlayerController Player
    {
        get
        {
            return GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayerController>();
        }
    }

    [System.Serializable]
    class PlayerRecord
    {
        public Vector3 Position;
    }

    public override string GetRecorderName()
    {
        return "PlayerRecorder";
    }

    public override string GetRecordEntries()
    {
        var recordentry = new PlayerRecord()
        {
            Position = Player.transform.position
        };

        return JsonUtility.ToJson(recordentry);
    }

    public override void RestoreObjectsFromRecordEntries(string serializedData)
    {
        var recordEntry = JsonUtility.FromJson<PlayerRecord>(serializedData);
        Player.transform.position = recordEntry.Position;     
    }
}

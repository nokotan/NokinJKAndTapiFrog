using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsetRecorder : ObjectRecorderBase
{
    static public PinsetController[] Pinsets
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("Pinset")
                .Select(go => go.GetComponent<PinsetController>())
                .Where(pin => pin != null)
                .ToArray();
        }
    }

    [System.Serializable]
    class PinsetRecord
    {
        public string GameObjectName;
        public Vector3 Position;
    }

    [System.Serializable]
    class PinsetRecords
    {
        public PinsetRecord[] Records;
    }

    public override string GetRecorderName()
    {
        return "PinsetRecorder";
    }

    public override string GetRecordEntries()
    {
        var recordEntries = Pinsets.Select(pin => new PinsetRecord()
            {
                GameObjectName = pin.gameObject.name,
                Position = pin.transform.position
            })
            .ToArray();

        return JsonUtility.ToJson(new PinsetRecords() { Records = recordEntries });
    }

    public override void RestoreObjectsFromRecordEntries(string serializedData)
    {
        var recordEntries = JsonUtility.FromJson<PinsetRecords>(serializedData);
        var pinsets = Pinsets;

        foreach (var entry in recordEntries.Records)
        {
            var pinset = pinsets.First(pin => pin.gameObject.name == entry.GameObjectName);
            pinset.transform.position = entry.Position;
        }
    }
}

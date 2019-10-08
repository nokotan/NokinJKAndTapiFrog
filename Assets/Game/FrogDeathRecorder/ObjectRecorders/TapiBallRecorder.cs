using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapiBallRecorder : ObjectRecorderBase
{
    [SerializeField]
    GameObject TapiBallPrefab;

    static public TapiBallController[] TapiBalls
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("tapioka")
                .Select(go => go.GetComponent<TapiBallController>())
                .Where(co => co != null)
                .ToArray();
        }
    }

    [System.Serializable]
    class TapiBallRecord
    {
        public Vector3 Position;
    }

    [System.Serializable]
    class TapiBallRecords
    {
        public TapiBallRecord[] Records;
    }

    public override string GetRecorderName()
    {
        return "TapiBallRecorder";
    }

    public override string GetRecordEntries()
    {
        var recordEntries = TapiBalls.Select(pin => new TapiBallRecord()
            {
                Position = pin.transform.position
            })
            .ToArray();

        return JsonUtility.ToJson(new TapiBallRecords() { Records = recordEntries });
    }

    public override void RestoreObjectsFromRecordEntries(string serializedData)
    {
        var recordEntries = JsonUtility.FromJson<TapiBallRecords>(serializedData);

        foreach (var entry in recordEntries.Records)
        {
            Instantiate(TapiBallPrefab, entry.Position, Quaternion.identity);
        }
    }
}

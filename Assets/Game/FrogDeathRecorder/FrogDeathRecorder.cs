using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDeathRecorder : MonoBehaviour
{
    [System.Serializable]
    public class RecordEntry
    {
        public string RecorderName;
        public string SerializedData;
    }

    [System.Serializable]
    public class RecordEntries
    {
        public RecordEntry[] Records;
    }

    [SerializeField] GameObject RecordersObject;
    [SerializeField] FrogDeathDatabase database;

    ObjectRecorderBase[] Recorders
    {
        get
        {
            return RecordersObject.GetComponentsInChildren<ObjectRecorderBase>();
        }
    }

    string CaptureRecordText()
    {
        var recordEntries = Recorders.Select(rec => new RecordEntry()
        {
            RecorderName = rec.GetRecorderName(),
            SerializedData = rec.GetRecordEntries()
        })
        .ToArray();

        return JsonUtility.ToJson(new RecordEntries() { Records = recordEntries });
    }

    public void CaptureRecord()
    {
        database.AppendEntry(CaptureRecordText());
    }

    public void TestCaptureRecord()
    {
        Debug.Log(CaptureRecordText());
    }

    public void RestoreRecord(int index)
    {
        var recordText = database.GetEntry(index);
        var recordEntries = JsonUtility.FromJson<RecordEntries>(recordText);
        var recoders = Recorders;

        foreach (var item in recordEntries.Records)
        {
            var recoder = recoders.First(r => r.GetRecorderName() == item.RecorderName);
            recoder.RestoreObjectsFromRecordEntries(item.SerializedData);
        }
    }

    public int GetRecordCount()
    {
        return database.GetEntriesCount();
    }
}

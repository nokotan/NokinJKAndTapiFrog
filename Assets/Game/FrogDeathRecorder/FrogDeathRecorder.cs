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

    [SerializeField] ObjectRecorderBase[] Recorders;
    [SerializeField] FrogDeathDatabase database;

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
}

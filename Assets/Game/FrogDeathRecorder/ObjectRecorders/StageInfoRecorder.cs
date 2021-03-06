﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfoRecorder : ObjectRecorderBase
{
    [System.Serializable]
    public class StageInfoRecord
    {
        public string StageFileName;
        public float ElapsedTime;
    }

    public StageInfoRecord stageInfo
    {
        get; private set;
    }

    public override string GetRecorderName()
    {
        return "StageInfoRecorder";
    }

    public override string GetRecordEntries()
    {
        var record = new StageInfoRecord()
        {
            StageFileName = CSVParser.Instance.selectedStage,
            ElapsedTime = TimeManager.Instance.ElapsedTime
        };

        return JsonUtility.ToJson(record);
    }

    public override void RestoreObjectsFromRecordEntries(string serializedData)
    {
        stageInfo = JsonUtility.FromJson<StageInfoRecord>(serializedData);
    }
}

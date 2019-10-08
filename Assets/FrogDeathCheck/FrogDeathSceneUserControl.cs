using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogDeathSceneUserControl : MonoBehaviour
{
    [SerializeField] FrogDeathRecorder recoder;
    [SerializeField] int RestoredRecordIndex = 0;

    [SerializeField] Text infoText;

    AnalogInput input;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<AnalogInput>();
        Invalidate();
    }

    void Invalidate()
    {
        int recordCount = recoder.GetRecordCount();

        recoder.RestoreRecord(RestoredRecordIndex);
        infoText.text = $"Record {RestoredRecordIndex + 1} / {recordCount}";
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetKeyDown(KeyCode.LeftArrow))
        {
            int recordCount = recoder.GetRecordCount();
            RestoredRecordIndex = (RestoredRecordIndex + recordCount - 1) % recordCount;

            Invalidate();
        }
        else if (input.GetKeyDown(KeyCode.RightArrow))
        {
            int recordCount = recoder.GetRecordCount();
            RestoredRecordIndex = (RestoredRecordIndex + 1) % recordCount;

            Invalidate();
        }
    }
}

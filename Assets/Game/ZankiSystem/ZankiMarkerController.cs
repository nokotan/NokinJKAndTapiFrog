using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZankiMarkerController : MonoBehaviour
{
    [SerializeField] Image[] zankiMarkers;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMarker(int remainsZanki)
    {
        if (!enabled) return;

        for (int i = 0; i < zankiMarkers.Length; i++)
        {
            zankiMarkers[i].enabled = i < remainsZanki;
        }
    }
}

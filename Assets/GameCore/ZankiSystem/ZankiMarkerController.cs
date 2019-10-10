using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZankiMarkerController : MonoBehaviour
{
    [SerializeField] Image[] zankiMarkers;

    [Header("Sprites")]
    [SerializeField] Sprite NormalZankiMarker;
    [SerializeField] Sprite DamagedZankiMarker;

    // For enable support
    void Update()
    {
        
    }

    IEnumerator MarkerAnimationRoutine(Image image)
    {
        image.sprite = DamagedZankiMarker;
        yield return new WaitForSeconds(1.0f);
        image.enabled = false;
    }

    public void UpdateMarker(int remainsZanki)
    {
        if (!enabled) return;

        for (int i = 0; i < zankiMarkers.Length; i++)
        {
            if (zankiMarkers[i].enabled && remainsZanki <= i)
            {
                StartCoroutine(MarkerAnimationRoutine(zankiMarkers[i]));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 残機の計算を行うクラス
/// </summary>
public class ZankiSystem : SingletonMonoBehaviour<ZankiSystem>
{
    /// <summary>
    /// 初期残機数
    /// </summary>
    [SerializeField] int InitialZanki;
    /// <summary>
    /// 今現在の残機数
    /// </summary>
    [SerializeField] int m_RemainedZanki;

    public int RemainedZanki => m_RemainedZanki;

    // Start is called before the first frame update
    void Start()
    {
        InitialZanki = ConfigSystem.Instance.GameSetting.InitialZanki;

        m_RemainedZanki = InitialZanki;
        ZankiMarkerController.Instance.UpdateMarker(m_RemainedZanki);
    }

    public void DecreaseZanki()
    {
        m_RemainedZanki--;
        ZankiMarkerController.Instance.UpdateMarker(m_RemainedZanki);

        if (m_RemainedZanki < 0)
        {
            StageSelectManager.Instance.SwitchSubScene("GameOver");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZankiSystem : MonoBehaviour
{
    [System.Serializable]
    class OnZankiDecreaseHandler : UnityEvent<int>
    {

    }

    [SerializeField] int InitialZanki;
    [SerializeField] UnityEvent OnZankiBreak;
    [SerializeField] OnZankiDecreaseHandler OnZankiDecrease;

    int m_RemainedZanki;

    public int RemainedZanki
    {
        get
        {
            return m_RemainedZanki;
        }
        private set
        {
            m_RemainedZanki = value;

            OnZankiDecrease.Invoke(m_RemainedZanki);

            if (m_RemainedZanki < 0)
            {
                OnZankiBreak.Invoke();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RemainedZanki = InitialZanki;
    }

    public void DecreaseZanki()
    {
        RemainedZanki--;
    }
}

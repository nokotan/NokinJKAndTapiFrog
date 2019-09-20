using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float shake_decay = 0.002f;
    public float coef_shake_intensity = 2.0f;
    private Vector3 originPosition;
    private Quaternion originRotation;
    private float shake_intensity;

    public PinsetController pinsetcontroller;
    PinsetController shake;


    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        //originRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (PinsetController.shake)
        {
            if (shake_intensity > 0 && Time.frameCount % 6 == 0)
            {
                transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
               // transform.rotation = new Quaternion(
                                   //              originRotation.x + Random.Range(-shake_intensity, shake_intensity) * 2f,
                                     //            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * 2f,
                                       //          originRotation.z + Random.Range(-shake_intensity, shake_intensity) * 2f,
                                         //        originRotation.w + Random.Range(-shake_intensity, shake_intensity) * 2f);
                shake_intensity -= shake_decay;
            }
        }

        if (PinsetController.shake==false)
        {
            transform.position = originPosition;
            //transform.rotation = originRotation;
            shake_intensity = coef_shake_intensity;
        }
    }

    public void Shake()
    {
        originPosition = transform.position;
        //originRotation = transform.rotation;
        shake_intensity = coef_shake_intensity;
    }

}

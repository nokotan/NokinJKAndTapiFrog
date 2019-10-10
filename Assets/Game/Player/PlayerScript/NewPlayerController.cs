using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public float range;

    SpriteRenderer MainSpriteRenderer;
    public Sprite FrogOnFloor;
    public Sprite FrogOnRFloor;
    public Sprite FrogOnLFloor;
    public Sprite FrogOnRWall;
    public Sprite FrogOnLWall;
    public Sprite FrogOnRCeiling;
    public Sprite FrogOnCeiling;
    public Sprite FrogOnLCeiling;

    [SerializeField] Sprite[] DamageFrogAnimation;
    bool isInDamageAnimation;

    [SerializeField] AudioClip deathSE;

    AnalogInput input;

    /// <summary>
    /// カエルがダメージを負った時のアニメーションを再生するコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator DamageAnimationRoutine()
    {
        isInDamageAnimation = true;

        foreach (var sprite in DamageFrogAnimation)
        {
            MainSpriteRenderer.sprite = sprite;
            yield return new WaitForSeconds(0.15f);
        }

        MainSpriteRenderer.sprite = null;
    }

    /// <summary>
    /// カエルがダメージを負ってからリスタートするまでのコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator FrogRestartRoutine()
    {
        // 操作不能にする
        enabled = false;

        CrossSceneAudioPlayer.PlaySE(deathSE);
        CSVParser.Instance.StopEnemyGenerating();
        TimeManager.Instance.StopTimer();
        FrogDeathRecorder.Instance.CaptureRecord();
        ZankiSystem.Instance.DecreaseZanki();

        yield return new WaitForSeconds(2.0f);

        GameSceneManager.Instance.ReloadScene();

        TimeManager.Instance.ResetTimer();
        TimeManager.Instance.StartTimer();
    }

    // Start is called befores the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        input = GetComponent<AnalogInput>();
    }

    // Update is called once per frame
    void Update()
    {
        // ダメージエフェクト中はUpdate関数での更新はしない
        if (isInDamageAnimation) {
            return;
        }

        Vector3 pos= transform.position;
        
    
        //移動の処理(左回転)
        if (input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<AudioSource>().Play();
                
            if (pos.x == -range)
            {
                if (pos.y != -range)
                {
                    transform.position += new Vector3(0, -range, 0);
                }
                else
                {
                    transform.position += new Vector3(range, 0, 0);
                }
            }
            else if (pos.x == 0)
            {
                if (pos.y == range)
                {
                    transform.position += new Vector3(-range, 0, 0);
                }
                else
                {
                    transform.position += new Vector3(range, 0, 0);
                }
            }
            else if (pos.x == range)
            {
                if (pos.y != range)
                {
                    transform.position += new Vector3(0, range, 0);
                }
                else
                {
                    transform.position += new Vector3(-range, 0, 0);
                }
            }
        }
        //移動（右回転）
       else if (input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<AudioSource>().Play();
            if (pos.x == range)
            {
                if (pos.y != -range)
                {
                    transform.position += new Vector3(0, -range, 0);
                }
                else
                {
                    transform.position += new Vector3(-range, 0, 0);
                }
            }
            else if (pos.x == 0)
            {
                if (pos.y == range)
                {
                    transform.position += new Vector3(range, 0, 0);
                }
                else
                {
                    transform.position += new Vector3(-range, 0, 0);
                }
            }
            if (pos.x == -range)
            {
                if (pos.y == range)
                {
                    transform.position += new Vector3(range, 0, 0);
                }
                else
                {
                    transform.position += new Vector3(0, range, 0);
                }
            }
        }
        

        //テクスチャの処理
        if (pos.y == -range)
        {
            BottomTexture(pos.x);
        }
        else if(pos.y == 0)
        {
            MiddleTexture(pos.x);
        }
        else
        {
            TopTexture(pos.x);
        }
        
    }

    //関数部分
    private void BottomTexture(float bottom)
    {
        if (bottom == range)
        {
            MainSpriteRenderer.sprite = FrogOnRFloor;
        }
        else if (bottom == -range)
        {
            MainSpriteRenderer.sprite = FrogOnLFloor;
        }
        else
        {
            MainSpriteRenderer.sprite = FrogOnFloor;
        }
    }
    private void MiddleTexture(float middle)
    {
        if (middle == range)
        {
            MainSpriteRenderer.sprite = FrogOnRWall;
        }
        else
        {
            MainSpriteRenderer.sprite = FrogOnLWall;
        }
    }

    private void TopTexture(float top)
    {
        if (top == range)
        {
            MainSpriteRenderer.sprite = FrogOnRCeiling;
        }
        else if (top == -range)
        {
            MainSpriteRenderer.sprite = FrogOnLCeiling;
        }
        else
        {
            MainSpriteRenderer.sprite = FrogOnCeiling;
        }
    }

    [Header("Debug"), SerializeField]
    bool isImmortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
#if DEBUG
        if (!isImmortal)
#endif
        {
            StartCoroutine(DamageAnimationRoutine());
            StartCoroutine(FrogRestartRoutine());
        }

        if (collision.tag == "tapioka")
        {
            Debug.Log("衝突しました");            
        }
        else if (collision.tag == "Pinset")
        {
            Debug.Log("刺されました");
            PinsetController.shake = false;
        }
       
    }

}

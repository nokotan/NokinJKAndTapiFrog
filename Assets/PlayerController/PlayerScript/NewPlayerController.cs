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



    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos= transform.position;
        
        //移動の処理(左回転)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
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

    
}

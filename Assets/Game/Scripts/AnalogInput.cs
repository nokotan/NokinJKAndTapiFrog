using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogInput : MonoBehaviour
{
    [SerializeField]
    float Dead = 0.7f;

    private class InputState
    {
        public Vector2 InputDirection { get; set; }
        public int InputFrame { get; set; }
    }

    Dictionary<KeyCode, InputState> KeyInputData;

    void Start()
    {
        KeyInputData = new Dictionary<KeyCode, InputState>()
        {
            { KeyCode.LeftArrow, new InputState() { InputDirection = Vector2.left } },
            { KeyCode.RightArrow, new InputState() { InputDirection = Vector2.right } },
            { KeyCode.UpArrow, new InputState() { InputDirection = Vector2.up } },
            { KeyCode.DownArrow, new InputState() { InputDirection = Vector2.down } },
        };
    }

    // Update is called once per frame
    void Update()
    {
        var inputVector = new Vector2
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetAxisRaw("Vertical")
        };

        foreach (var item in KeyInputData.Values)
        {
            if (Vector2.Dot(inputVector, item.InputDirection) > Dead)
            {
                item.InputFrame++;
            }
            else
            {
                item.InputFrame = 0;
            }
        }
    }

    public bool GetKeyDown(KeyCode c)
    {
        if (KeyInputData.ContainsKey(c))
        {
            return KeyInputData[c].InputFrame == 1;
        }
        else
        {
            Debug.LogWarning($"{c} is not used.");
            return false;
        }
    }
}

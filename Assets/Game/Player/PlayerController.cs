using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float minPositionY = -3.5f;
    [SerializeField] float maxPositionY = 4.5f;

    [SerializeField] float minPositionX = -7.5f;
    [SerializeField] float maxPositionX = -1.5f;



    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    IEnumerable<GameObject> GetOverlappedFrogs()
    {
        var overlappedObjects = new BoxCollider2D[10];
        var filter = new ContactFilter2D()
        {
            useTriggers = true,
        };

        var overlappedObjectsNum = boxCollider.OverlapCollider(filter, overlappedObjects);

        return overlappedObjects
            .Take(overlappedObjectsNum)
            .Select(col => col.gameObject)
            .Where(obj => obj.tag == "Frog");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 newPosition = transform.position + new Vector3(0, -1);
            newPosition.y = Mathf.Clamp(newPosition.y, minPositionY, maxPositionY);
            transform.position = newPosition;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Vector3 newPosition = transform.position + new Vector3(0, 1);
            newPosition.y = Mathf.Clamp(newPosition.y, minPositionY, maxPositionY);
            transform.position = newPosition;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Vector3 newPosition = transform.position + new Vector3(1, 0);
            newPosition.x = Mathf.Clamp(newPosition.x, minPositionX, maxPositionX);
            transform.position = newPosition;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Vector3 newPosition = transform.position + new Vector3(-1, 0);
            newPosition.x = Mathf.Clamp(newPosition.x, minPositionX, maxPositionX);
            transform.position = newPosition;
        }







        foreach (var frogs in GetOverlappedFrogs())
        {
            Destroy(frogs);
            Debug.Log("Destroyed Frog by Player.");
        }
    }
}

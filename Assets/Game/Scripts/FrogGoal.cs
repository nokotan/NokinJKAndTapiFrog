using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FrogGoal : MonoBehaviour
{
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
        foreach (var frogs in GetOverlappedFrogs())
        {
            Destroy(frogs);
            Debug.Log("Destroyed Frog.");
        }
    }
}

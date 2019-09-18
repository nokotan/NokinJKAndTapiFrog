using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] prefabsToInstantiate;
     int positionRange = 4;
    [SerializeField] float InstantiateInterval = 3.0f;

    void RandomInstantiate()
    {
        var selectedPrefab = prefabsToInstantiate[Random.Range(0, prefabsToInstantiate.Length)];
        var instantiatePositionYDelta = Random.Range(0, positionRange - 1) - (positionRange - 1) / 2.0f;
        var instantiatePosition = transform.position + new Vector3(0.0f, instantiatePositionYDelta);

        Instantiate(selectedPrefab, instantiatePosition, Quaternion.identity);
    }

    IEnumerator InstantiateRoutine()
    {
        while (true)
        {
            RandomInstantiate();
            yield return new WaitForSeconds(InstantiateInterval);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        positionRange = 4;
        StartCoroutine(InstantiateRoutine());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LocalMinimum.Geometry2D;

public class TempTest : MonoBehaviour {

    [SerializeField]
    Vector2 side;

    [SerializeField]
    float rotationTolerance = Mathf.PI / 8f;

    [SerializeField]
    float distanceTolerance = 0.1f;

	void Start () {
        
        Vector2 a = side.Rotate(Random.Range(0, 2 * Mathf.PI));

        var GO = new GameObject();
        GO.transform.SetParent(transform);
        GO.transform.localPosition = Vector3.zero;

        GO = new GameObject();
        GO.transform.SetParent(transform);
        GO.transform.localPosition = a.Extend(Random.Range(1 - distanceTolerance, 1 + distanceTolerance));

        Vector2 b = a + a.Rotate(Mathf.PI * 2f / 3f + Random.Range(-rotationTolerance, rotationTolerance));
        GO = new GameObject();
        GO.transform.SetParent(transform);
        GO.transform.localPosition = b.Extend(Random.Range(1 - distanceTolerance, 1 + distanceTolerance));



    }

    void OnDrawGizmosSelected()
    {
        for (int i=0; i<transform.childCount; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild((i + 1) % transform.childCount).position);
        }
    }
    

}

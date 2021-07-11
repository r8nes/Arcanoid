using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    private const float OffsetY = 0.7f;
    private readonly List<GameObject> _saveBalls = new List<GameObject>();
    [SerializeField] private GameObject ballPrefab;
     

    public void Create() {

        _saveBalls.Clear();
        _saveBalls.Add(Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y + OffsetY), Quaternion.identity, transform));
    }

    public void CreateClone() {
        foreach (var item in _saveBalls)
        {
            if (item != null)
            {
                int rand = Random.Range(2,5);

                for (int i = 0; i < rand; i++)
                {
                float direction = Random.Range(-1,2);
                    GameObject ballClone = Instantiate(ballPrefab, new Vector3(item.transform.position.x, item.transform.position.y), Quaternion.identity, null);
                    ballClone.GetComponent<BallMove>().StartClone(direction);
                    _saveBalls.Add(ballClone);
                }
                    break;
            }
        }
    }
}

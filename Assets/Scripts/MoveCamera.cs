using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    float PositionX;
    float PositionY;
    // Start is called before the first frame update
    void Start()
    {
         PositionX = gameObject.transform.localPosition.x;
         PositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.localPosition = new Vector3(PositionX+(200 * GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

    }
}

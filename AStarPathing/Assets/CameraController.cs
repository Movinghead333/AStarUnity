using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public RectTransform screenTransform;
    CanvasScaler scaler;
    float scrollSpeed = 2f;
    float translationSpeed = 200;
    // Start is called before the first frame update
    void Start()
    {
        scaler = gameObject.GetComponent<CanvasScaler>();
        Debug.Log("position: " + screenTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            scaler.scaleFactor += 0.01f * scrollSpeed;
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            scaler.scaleFactor -= 0.01f * scrollSpeed;
        }

        Vector3 newPosition = screenTransform.anchoredPosition;

        if (Input.GetKey(KeyCode.W))
        {
            newPosition.y -= Time.deltaTime * translationSpeed;
            screenTransform.anchoredPosition = newPosition;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newPosition.y += Time.deltaTime * translationSpeed;
            screenTransform.anchoredPosition = newPosition;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newPosition.x += Time.deltaTime * translationSpeed;
            screenTransform.anchoredPosition = newPosition;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newPosition.x -= Time.deltaTime * translationSpeed;
            screenTransform.anchoredPosition = newPosition;
        }
    }
}

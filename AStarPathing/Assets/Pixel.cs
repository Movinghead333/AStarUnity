using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pixel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI currentPathLengthText;
    [SerializeField]
    TextMeshProUGUI estimatedPathLengthText;
    [SerializeField]
    TextMeshProUGUI estimatedPathLength2Text;
    [SerializeField]
    TextMeshProUGUI minimumPathLengthText;

    public bool isObstacle = false;

    void setCurrent(double current)
    {
        currentPathLengthText.SetText(current.ToString());
    }

    void setEstimated(double estimated)
    {
        estimatedPathLengthText.SetText(estimated.ToString());
    }

    void setEstimated2(double estimated2)
    {
        estimatedPathLength2Text.SetText(estimated2.ToString());
    }

    void setMinimum(double minimum)
    {
        minimumPathLengthText.SetText(minimum.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        setMinimum(90.34);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

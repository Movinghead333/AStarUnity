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
    public float gCost;
    public float hCost;
    public float fCost;

    public int x;
    public int y;

    public Pixel predecessor;

    public void setCurrent(double current)
    {
        currentPathLengthText.SetText("G(p): " + current.ToString());
    }

    public void setEstimated(double estimated)
    {
        estimatedPathLengthText.SetText("H(p): " + estimated.ToString());
    }

    public void setEstimated2(double estimated2)
    {
        estimatedPathLength2Text.SetText(estimated2.ToString());
    }

    public void setMinimum(double minimum)
    {
        minimumPathLengthText.SetText("F(p): " + minimum.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

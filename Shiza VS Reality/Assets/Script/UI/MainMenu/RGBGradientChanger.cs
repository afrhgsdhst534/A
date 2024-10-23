using UnityEngine;
using UnityEngine.UI;

public class RGBGradientChanger : MonoBehaviour
{
    public Gradient gradient;
    private Image image;
    private Text text;
    public float gradienTime = 0;
    public float gradienSpeed=0.1f;
    private void Start()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
    }
    private void Update()
    {
        gradienTime += gradienSpeed * Time.deltaTime;
        gradienTime %= 1f;
        image.color = gradient.Evaluate(gradienTime);
        text.color = gradient.Evaluate(gradienTime);
    }
}

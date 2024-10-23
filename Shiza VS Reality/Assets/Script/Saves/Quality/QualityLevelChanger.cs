using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class QualityLevelChanger : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Dropdown>().value = QualitySettings.GetQualityLevel();
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
using UnityEngine;
public class BooksBuy : MonoBehaviour
{
    public GameObject obj;
    private CanvasManager canvasManager;
    private void Start()
    {
        canvasManager = CanvasManager.instance;
    }
    public void EnableForCost(int cost)
    {
        if (cost < canvasManager.pickedChar.GetComponent<Base�haracteristic>().money)
        {
            canvasManager.pickedChar.GetComponent<Base�haracteristic>().money -= cost;
            obj.SetActive(true);
        }
    }
}
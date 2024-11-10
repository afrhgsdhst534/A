using UnityEngine;
using Cinemachine;
using System.Threading.Tasks;
public class CameraController : MonoBehaviour
{
    AllyCharacters ally;
    public static CameraController instance;
    public CinemachineBrain brain;
    public CinemachineVirtualCamera cinema;
    private void Awake()
    {
        instance = this;
        cinema = GetComponentInChildren<CinemachineVirtualCamera>();
        brain = GetComponentInChildren<CinemachineBrain>();
    }
    void Update()
    {
        ally = AllyCharacters.instance;
        if (ally != null)
        {
            if (ally.allAllyCharacters.Count > 0)
            {
                cinema.Follow = ally.allAllyCharacters[0].transform;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.Equals)) // forward
            {
                ScrollDown();
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.Minus)) // backwards
            {
                ScrollUp();
            }
            var tr = transform.position;
            if (Input.GetKey(KeyCode.DownArrow))
                transform.position = new Vector3(tr.x, tr.y, tr.z - 0.1f);
            if (Input.GetKey(KeyCode.UpArrow))
                transform.position = new Vector3(tr.x, tr.y, tr.z + 0.1f);
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.position = new Vector3(tr.x - 0.1f, tr.y, tr.z);
            if (Input.GetKey(KeyCode.RightArrow))
                transform.position = new Vector3(tr.x + 0.1f, tr.y, tr.z);
        }
    }
    public async void ChangeUpdate(bool isLate)
    {
        await Task.Delay(1000);
        if(isLate)    
            brain.m_UpdateMethod = CinemachineBrain.UpdateMethod.LateUpdate;
        else
            brain.m_UpdateMethod = CinemachineBrain.UpdateMethod.ManualUpdate;
    }
    [ContextMenu("Down")]
    public void ScrollDown()
    {
        CinemachineComponentBase componentBase = cinema.GetCinemachineComponent(CinemachineCore.Stage.Body);
        if (componentBase is CinemachineFramingTransposer)
        {
            if ((componentBase as CinemachineFramingTransposer).m_CameraDistance >=1)
                (componentBase as CinemachineFramingTransposer).m_CameraDistance -= 1; // your value
            else
                (componentBase as CinemachineFramingTransposer).m_CameraDistance = 1; // your value
        }
    }
    [ContextMenu("Up")]
    public void ScrollUp()
    {
        CinemachineComponentBase componentBase = cinema.GetCinemachineComponent(CinemachineCore.Stage.Body);
         if (componentBase is CinemachineFramingTransposer)
         {
             if ((componentBase as CinemachineFramingTransposer).m_CameraDistance <= 10)
                 (componentBase as CinemachineFramingTransposer).m_CameraDistance += 1; // your value
             else
                 (componentBase as CinemachineFramingTransposer).m_CameraDistance = 10; // your value
         }
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SwitchPuzzle : MonoBehaviour
{
    public bool DSgsdg = false;
    public Vector2 SDHsdh;
    public Transform SDfDSgD;
    public Image dsFGdsg;
    public List<RaycastResult> dHsdh = new List<RaycastResult>();
    public CanvasManager canvasManager;
    private float fdsa;
    float clicked;
    float clicktime;
    public float clickdelay = 0.1f;
    public Puzzle puzzle=>GetComponent<Puzzle>();
    public void Start()
    {
        canvasManager = CanvasManager.instance;
    }
    bool DoubleClick()
    {

        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            return true;
        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        return false;
    }
    void Update()
    {
        if (DoubleClick())
        {
            if (dsFGdsg != null)
                dsFGdsg.raycastTarget = true;
        }
        if (SDfDSgD != null)
        {
            fdsa += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            SDfDSgD = DSHG();
            if (SDfDSgD != null && SDfDSgD.GetComponent<Image>())
            {
                DSgsdg = true;
                SDHsdh = SDfDSgD.position;
                dsFGdsg = SDfDSgD.GetComponent<Image>();
                dsFGdsg.raycastTarget = false;
                gameObject.GetComponent<GridLayoutGroup>().enabled = false;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (SDfDSgD != null && SDfDSgD.GetComponent<Image>())
            {
                var dsF = DSHG();
                if (dsF != null)
                {
                    var f = SDfDSgD.GetSiblingIndex();
                    var s = dsF.GetSiblingIndex();
                    var p = puzzle.a;
                    (p[f], p[s]) = (p[s], p[f]);
                    dsF.SetSiblingIndex(f);
                    SDfDSgD.SetSiblingIndex(s);
                    SDfDSgD.position = dsF.position;
                    dsF.position = SDHsdh;
                    gameObject.GetComponent<GridLayoutGroup>().enabled = true;
                }
                else
                {
                    SDfDSgD.position = SDHsdh;
                    gameObject.GetComponent<GridLayoutGroup>().enabled = true;
                }
                dsFGdsg.raycastTarget = true;
                SDfDSgD = null;
            }
            DSgsdg = false;
            fdsa = 0;
            if (dsFGdsg != null)
                dsFGdsg.raycastTarget = true;
        }
        if (DSgsdg)
        {
            SDfDSgD.position = Input.mousePosition;
        }
    }
    private GameObject dGds()
    {
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointer, dHsdh);
        if (dHsdh.Count <= 0) return null;
        return dHsdh.First().gameObject;
    }
    private Transform DSHG()
    {
        var clickedObject = dGds();
        if (clickedObject != null && clickedObject.GetComponent<Image>())
        {
            return clickedObject.transform;
        }
        return null;
    }
}
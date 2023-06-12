using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Variable : Symbol, Executable
{
    public enum type
    {
        none,
        integer,
        floating,
        str
    }

    [SerializeField]
    public TMPro.TextMeshPro uiVarName;
    [SerializeField]
    public GameObject PopupPref;
    [SerializeField]
    public float clickTole;

    private type T;
    private List<object> content;
    private string varName;
    private Vector3 clickPoint;

    private GameObject popup;

    public void setName(string n)
    {
        varName = n;
        uiVarName.SetText(n);
    }
    public string getName()
    {
        return varName;
    }
    public type getType()
    {
        return T;
    }
    public void setType(type option)
    {
        T = option;
    }
    public int getSize()
    {
        if (content == null)
            return 0;
        return content.Count;
    }
    public void setSize(int size = 1)
    {
        content = new List<object>(size);
    }
    public object getContent(int index = 0)
    {
        // 변수초기화, 인덱싱 범위 체크
        if (T == type.none || index >= content.Count)
            return null;
        // 범위가 정상이면 리턴
        return content[index];
    }
    public bool setContent(object cont, int index = 0)
    {
        // 인덱싱 범위 체크
        if (index >= content.Count)
            return false;
        // 인덱스가 정상일 경우 셋
        content[index] = cont;
        return true;
    }

    void OnClick()
    {
        if (popup == null)
        {
            GameObject canvas = GameObject.Find("Canvas");
            popup = Instantiate(PopupPref);
            popup.transform.parent = canvas.transform;
            popup.GetComponent<ValuePu>().setBelong(this);
        }
    }

    public string execute()
    {
        return "";
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        this.id = Category.Variable;
        this.T = type.none;
        this.content = null;
    }


    new void OnMouseDown()
    {
        base.OnMouseDown();
        // 레이캐스트를 사용하여 클릭한 오브젝트가 현재 오브젝트인지 확인.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    new void OnMouseUp()
    {
        base.OnMouseUp();
        float distance = Vector3.Distance(clickPoint, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (distance < clickTole)
        {
            OnClick();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ValuePu : MonoBehaviour
{
    [SerializeField]
    public TMPro.TMP_InputField valueName;
    [SerializeField]
    public TMPro.TMP_InputField valueLength;
    [SerializeField]
    public TMPro.TMP_InputField value;
    [SerializeField]
    public Variable belong;

    // 생성 시 호출할 것
    public void setBelong(Variable b)
    {
        belong = b;
    }

    public void onCllickConfirm()
    {
        belong.setName(valueName.text);
        // 추후 자료형 대응 업그레이드 필요
        belong.setType(Variable.type.floating);
        belong.setSize(int.Parse(valueLength.text));
        belong.setContent(parseList());

        // 입력에 성공했을 때
        Destroy(gameObject);
    }

    public void onClickCancel()
    {
        valueName.text = belong.getName();
        valueLength.text = belong.getSize().ToString();
        object content = belong.getContent();
        if (content == null)
            value.text = "";
        else
            value.text = content.ToString();

        // 입력 취소
        Destroy(gameObject);
    }

    private List<object> parseList()
    {
        List<object> result = new List<object>();
        string orig = value.text;
        int size = belong.getSize();

        List<float> floatList = orig.Split(',').Select(n => { float ret = float.TryParse(n, out float succ) ? succ : 0.0f; return ret; }).ToList();
        result = floatList.Select(number => (object)number).Take(size).ToList();

        return result;
    }
}

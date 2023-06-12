using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
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

    // 에러표시 함수
    private void warnInputField(TMPro.TMP_InputField ifield, string msg = "input error")
    {
        ifield.text = "";
        TMPro.TextMeshProUGUI placeholder = (TMPro.TextMeshProUGUI)ifield.placeholder;
        placeholder.text = msg;
        placeholder.color = Color.red;
    }

    // 생성 시 호출할 것
    public void setBelong(Variable b)
    {
        belong = b;
        if (b.getName() != null)
        {
            valueName.text = b.getName();
            valueLength.text = b.getSize().ToString();
            value.text = content2str(b.getContents());
        }
    }

    private string content2str(List<object> cont)
    {
        // 일단 float기준

        string result = "";

        // TODO: string으로 변환하는거 만들기

        return result;
    }

    public void onCllickConfirm()
    {
        // 변수명 지정 안했을 때
        if (valueName.text == "")
        {
            // 에러표시할 것
            warnInputField(valueName, "변수명은 비위둘 수 없습니다");
            return;
        }
        // 변수명 시작이 숫자일 때
        if (valueName.text[0]>='0' && valueName.text[0]<='9')
        {
            warnInputField(valueName, "변수명의 시작은 숫자가 올 수 없습니다");
            return;
        }
        belong.setName(valueName.text);

        // 추후 자료형 대응 업그레이드 필요
        belong.setType(Variable.type.floating);

        // 변수 크기 입력
        int sizeArr;
        if (valueLength.text == "")
        {
            // 입력이 없을 경우 기본값 1
            sizeArr = 1;
        }
        else {
            sizeArr = int.Parse(valueLength.text); 
        }
        // 변수의 길이가 1보다 작을 때
        if (sizeArr < 1)
        {
            // 에러 표시할 것
            warnInputField(valueLength, $"변수의 길이는 1보다 작을 수 없습니다 : {sizeArr}");
            return;
        }
        belong.setSize(sizeArr);

        // 변수 내용물 입력
        List<object> parsed = parseList();
        if (parsed == null)
        {
            // 에러 표시할 것
            warnInputField(value, "내용을 인식할 수 없습니다. 입력예시) 1,3,5,7");
            return;
        }
        belong.setContent(parsed);

        // 입력에 성공했을 때
        Destroy(gameObject);
    }

    public void onClickCancel()
    {
        if (belong.getName() == null)
            Destroy(belong.gameObject);
        // 입력 취소
        Destroy(gameObject);
    }

    private List<object> parseList()
    {
        List<object> result = new List<object>();
        string orig = value.text;
        int size;
        if (!int.TryParse(valueLength.text, out size))
        {
            // 비어있을 경우 기본값 1
            if (valueLength.text == "")
                size = 1;
            else
                return null;
        }
        Debug.Log("변수 길이 int변환 완료");
        if (orig == null)
            return null;
        Debug.Log("변수 내용 null 아님");
        if (size < 1)
            return null;
        Debug.Log("size 0아님");

        List<float> floatList = orig.Split(',').Select(n => { float ret = float.TryParse(n, out float succ) ? succ : 0.0f; return ret; }).ToList();
        result = floatList.Select(number => (object)number).Take(size).ToList();

        return result;
    }
}

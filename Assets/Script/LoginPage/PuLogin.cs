using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuLogin : MonoBehaviour, PuInterface
{
    [SerializeField]
    public TMPro.TMP_InputField id;
    [SerializeField]
    public TMPro.TMP_InputField pw;
    public void onClickLogin()
    {
        Debug.Log("addUser onClick run.");
        Debug.Log("ID: " + id.text);
        Debug.Log("PW: " + pw.text);

        // 입력한 ID가 없을 경우 경고
        if (id.text.Equals("")) { idWarn(); return; }
        // 입력한 PW가 없을 경우 경고
        if (pw.text.Equals("")) { pwWarn(); return; }

        // TODO: 로그인 로직 구현할 것
        string result = login();
        if (result.Equals("")) { loginWarn(); return; }
        // 처리가 끝나면 팝업을 종료
        close();
        // 사용자별 메인화면 표출시키기
    }

    private string login()
    {
        if (false)
        {
            // 사용자 로그인 성공 시
            return "GUID";
        }
        return "";
    }

    private void idWarn()
    {
        id.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "ID를 입력하세요!";
        id.placeholder.color = Color.red;
    }
    private void pwWarn()
    {
        pw.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "PW를 입력하세요!";
        pw.placeholder.color = Color.red;
    }
    private void loginWarn()
    {
        pw.text = "";
        pw.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "ID또는 PW가 잘못되었습니다.";
        pw.placeholder.color = Color.red;
    }
    private void WarnInit()
    {
        id.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "사용할 ID를 입력하세요";
        id.placeholder.color = Color.gray;
        pw.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "사용할 PW를 입력하세요";
        pw.placeholder.color = Color.gray;
    }
    private void clear()
    {
        // 입력칸 비우기
        id.text = "";
        pw.text = "";
    }

    // 팝업 종료 등의 상황에서 입력칸 초기화를 위함
    public void InitPopup()
    {
        clear();
        WarnInit();
    }

    public void close()
    {
        InitPopup();
        this.gameObject.SetActive(false);
    }
}

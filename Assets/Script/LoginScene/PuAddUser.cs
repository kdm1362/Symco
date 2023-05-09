using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuAddUser : MonoBehaviour, PuInterface
{
    [SerializeField]
    public TMPro.TMP_InputField id;
    [SerializeField]
    public TMPro.TMP_InputField pw;
    [SerializeField]
    public TMPro.TMP_InputField pwCfm;

    HUser handleUser;
    ToastMessage toast;

    void Awake()
    {
        handleUser = new HUser();
        toast = FindObjectOfType<ToastMessage>();
    }

    public void onClickConfirm()
    {
        SymcoManager.symcoDebugInfo("addUser onClick run.");
        SymcoManager.symcoDebugInfo("ID: " + id.text);
        SymcoManager.symcoDebugInfo("PW: " + pw.text);
        SymcoManager.symcoDebugInfo("PW: " + pwCfm.text);

        // ID가 없을 경우 경고
        if (id.text.Equals("")) { idWarn(); return; }
        // PW가 없을 경우 경고
        if (pw.text.Equals("")) { pwWarn(); return; }
        // 확인용 비밀번호가 서로 다들경우 경고
        if (!pw.text.Equals(pwCfm.text)) { pwCheckWarn();  return; }

        // 사용자 추가
        int result = handleUser.addUser(id.text, pw.text);
        // ID가 이미 사용중일 경우 경고
        if (result != 0) { toast.message("이미 사용중인 ID입니다"); return; }

        // TODO: 처리 성공여부를 알리는 토스트 메시지 띄울것
        toast.message("사용자 등록이 완료되었습니다.");

        // 처리가 끝나면 팝업을 종료
        close();
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
    private void pwCheckWarn()
    {
        pwCfm.text = "";
        pwCfm.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "입력한 값이 다릅니다";
        pwCfm.placeholder.color = Color.red;
    }
    private void WarnInit()
    {
        id.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "사용할 ID를 입력하세요";
        id.placeholder.color = Color.gray;
        pw.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "사용할 PW를 입력하세요";
        pw.placeholder.color = Color.gray;
        pwCfm.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "PW를 한번 더 입력하세요";
        pwCfm.placeholder.color = Color.gray;
    }
    private void clear()
    {
        // 연속으로 사용자를 추가할 경우를 위한 칸 비우기
        id.text = "";
        pw.text = "";
        pwCfm.text = "";
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

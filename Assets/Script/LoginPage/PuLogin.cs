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

        // �Է��� ID�� ���� ��� ���
        if (id.text.Equals("")) { idWarn(); return; }
        // �Է��� PW�� ���� ��� ���
        if (pw.text.Equals("")) { pwWarn(); return; }

        // TODO: �α��� ���� ������ ��
        string result = login();
        if (result.Equals("")) { loginWarn(); return; }
        // ó���� ������ �˾��� ����
        close();
        // ����ں� ����ȭ�� ǥ���Ű��
    }

    private string login()
    {
        if (false)
        {
            // ����� �α��� ���� ��
            return "GUID";
        }
        return "";
    }

    private void idWarn()
    {
        id.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "ID�� �Է��ϼ���!";
        id.placeholder.color = Color.red;
    }
    private void pwWarn()
    {
        pw.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "PW�� �Է��ϼ���!";
        pw.placeholder.color = Color.red;
    }
    private void loginWarn()
    {
        pw.text = "";
        pw.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "ID�Ǵ� PW�� �߸��Ǿ����ϴ�.";
        pw.placeholder.color = Color.red;
    }
    private void WarnInit()
    {
        id.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "����� ID�� �Է��ϼ���";
        id.placeholder.color = Color.gray;
        pw.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "����� PW�� �Է��ϼ���";
        pw.placeholder.color = Color.gray;
    }
    private void clear()
    {
        // �Է�ĭ ����
        id.text = "";
        pw.text = "";
    }

    // �˾� ���� ���� ��Ȳ���� �Է�ĭ �ʱ�ȭ�� ����
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

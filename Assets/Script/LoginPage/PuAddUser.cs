using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuAddUser : MonoBehaviour
{
    [SerializeField]
    public TMPro.TMP_InputField id;
    [SerializeField]
    public TMPro.TMP_InputField pw;
    [SerializeField]
    public TMPro.TMP_InputField pwCfm;

    public void onClickConfirm()
    {
        Debug.Log("addUser onClick run.");
        Debug.Log("ID: " + id.text);
        Debug.Log("PW: " + pw.text);
        Debug.Log("PW: " + pwCfm.text);

        // ID�� ���� ��� ���
        if (id.text.Equals("")) { idWarn(); return; }
        // PW�� ���� ��� ���
        if (pw.text.Equals("")) { pwWarn(); return; }
        // Ȯ�ο� ��й�ȣ�� ���� �ٵ��� ���
        if (!pw.text.Equals(pwCfm.text)) { pwCheckWarn();  return; }

        // TODO: ����� �߰� ���� ������ ��
        // TODO: �̹̻������ ID�ϰ�� ó���� ��
        // TODO: ó�� �������θ� �˸��� �佺Ʈ �޽��� ����

        // ó���� ������ �˾��� ����
        InitPopup();
        this.gameObject.SetActive(false);
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
    private void pwCheckWarn()
    {
        pwCfm.text = "";
        pwCfm.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "�Է��� ���� �ٸ��ϴ�";
        pwCfm.placeholder.color = Color.red;
    }
    private void WarnInit()
    {
        id.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "����� ID�� �Է��ϼ���";
        id.placeholder.color = Color.gray;
        pw.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "����� PW�� �Է��ϼ���";
        pw.placeholder.color = Color.gray;
        pwCfm.placeholder.GetComponent<TMPro.TextMeshProUGUI>().text = "PW�� �ѹ� �� �Է��ϼ���";
        pwCfm.placeholder.color = Color.gray;
    }
    private void clear()
    {
        // �������� ����ڸ� �߰��� ��츦 ���� ĭ ����
        id.text = "";
        pw.text = "";
        pwCfm.text = "";
    }

    // �˾� ���� ���� ��Ȳ���� �Է�ĭ �ʱ�ȭ�� ����
    public void InitPopup()
    {
        clear();
        WarnInit();
    }
}

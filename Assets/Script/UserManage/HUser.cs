using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HUser : MonoBehaviour
{
    public int addUser(string id, string pw)
    {
        // 만들고하 하는 id가 이미 있을 경우 -1, 생성 성공 시 0

        // id가 이미 존재하는지 확인
        if (PlayerPrefs.HasKey(id))
        {
            SymcoManager.symcoDebugInfo("This ID is already using");
            return -1;
        }

        // pw를 sha256인코딩
        string shadow = getSHA256(pw);

        // Pref에 id: pw 쌍 추가
        PlayerPrefs.SetString(id, shadow);

        // 사용자 폴더 생성
        HUserFile uf = new HUserFile(id);
        uf.createUserHome();

        return 0;
    }

    private string getSHA256(string plane)
    {
        SHA256 sha = new SHA256Managed();
        byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(plane));
        StringBuilder stringBuilder = new StringBuilder();
        foreach(byte b in hash)
        {
            stringBuilder.AppendFormat("{0:x2}", b);
        }

        return stringBuilder.ToString();
    }

    public void checkAdminAcount()
    {
        // 관리자 계정이 없을 경우 생성 // 어두운밤하늘별자리같이
        int result = addUser("teacher", "lighthouse0#");
        if (result == 0)
            SymcoManager.symcoDebugInfo("Adimnistrator account cteated");
        else
            SymcoManager.symcoDebugInfo("Administrator account checked");
    }

    public HUserFile login(string id, string pw)
    {
        // id가 없을 경우 -1, pw가 안맞을 경우 -2, 성공시 0 반환
        HUserFile result;

        // id 유무 확인
        if (!PlayerPrefs.HasKey(id))
        {
            SymcoManager.symcoDebugInfo("this ID is not found");
            result = new HUserFile(-1);
            return result;
        }

        // pw 확인
        string hash = getSHA256(pw);
        string shadow = PlayerPrefs.GetString(id);
        if (!shadow.Equals(hash))
        {
            SymcoManager.symcoDebugInfo("PW does not matched");
            result = new HUserFile(-2);
            return result;
        }

        // 로그인 성공
        SymcoManager.symcoDebugInfo("Login success");
        result = new HUserFile(id);
        return result;
    }

    public int deleteUser(string id, string pw, HUserFile userLogin)
    {
        // id가 없을 경우 -1, pw가 안맞을 경우 -2, 성공시 0 반환
        if (!PlayerPrefs.HasKey(id))
        {
            SymcoManager.symcoDebugInfo("Could not found ID to Delete");
            return -1;
        }
        // 비밀번호가 다르거나 관리자가 아니면 튕기기
        if (!(getSHA256(pw).Equals(PlayerPrefs.GetString(id)) || userLogin.IsAdmin()))
        {
            SymcoManager.symcoDebugInfo("PW does not matched");
            return -2;
        }

        // 사용자 폴더 제거
        HUserFile uf = new HUserFile(id) ;
        uf.deleteUserHome();

        PlayerPrefs.DeleteKey(id);
        return 0;
    }
}

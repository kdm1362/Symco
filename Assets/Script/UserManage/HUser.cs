using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HUser : MonoBehaviour
{
    private bool isAdmin;
    public HUser()
    {
        // 몬가 몬가가 일어나고 있다!
        isAdmin = false;
    }

    public HUser(bool admin)
    {
        this.isAdmin = admin;
    }


    public int addUser(string id, string pw)
    {
        // 만들고하 하는 id가 이미 있을 경우 -1, 생성 성공 시 0

        // id가 이미 존재하는지 확인
        if (PlayerPrefs.HasKey(id))
        {
            Debug.Log("동일 ID 사용자가 존재함");
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
        // 관리자 계정이 없을 경우 생성
        int result = addUser("teacher", "어두운밤하늘별자리같이");
        if (result == 0)
            Debug.Log("관리자 계정 생성됨");
        else
            Debug.Log("관리자 계정 확인됨");
    }

    public HUserFile login(string id, string pw)
    {
        // id가 없을 경우 -1, pw가 안맞을 경우 -2, 성공시 0 반환

        // id 유무 확인
        if (!PlayerPrefs.HasKey(id))
        {
            Debug.Log("입력된 ID는 존재하지 않음");
            return new HUserFile(-1);
        }

        // pw 확인
        string hash = getSHA256(pw);
        string shadow = PlayerPrefs.GetString(id);
        if (!shadow.Equals(hash))
        {
            Debug.Log("PW가 일치하지 않음");
            return new HUserFile(-2);
        }

        // 로그인 성공
        Debug.Log("로그인 성공");
        return new HUserFile(id);
    }

    public int deleteUser(string id, string pw)
    {
        // id가 없을 경우 -1, pw가 안맞을 경우 -2, 성공시 0 반환
        if (!PlayerPrefs.HasKey(id))
        {
            Debug.Log("삭제할 ID가 존재하지 않음");
            return -1;
        }
        // 비밀번호가 다르고 관리자가 아니면 튕기기
        if (!getSHA256(pw).Equals(PlayerPrefs.GetString(id)) && !isAdmin)
        {
            Debug.Log("삭제한 사용자 PW가 일치하지 않음");
            return -2;
        }

        // 사용자 폴더 제거
        HUserFile uf = new HUserFile(id) ;
        uf.deleteUserHome();

        PlayerPrefs.DeleteKey(id);
        return 0;
    }
}

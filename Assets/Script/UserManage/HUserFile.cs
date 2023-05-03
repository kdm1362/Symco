using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml;

public class HUserFile : MonoBehaviour
{
    private string username;
    private string PATH;
    private int validFlag;
    public HUserFile(string username)
    {
        this.username = username;
        this.PATH = Path.Combine(Application.persistentDataPath, username);
        this.validFlag = 0;
        Debug.Log("사용자 폴더 위치: " + this.PATH);
    }
    public HUserFile(int valid)
    {
        this.validFlag = valid;
    }

    public int IsValid()
    {
        return this.validFlag;
    }

    public bool createUserHome()
    {
        try
        {
            if (Directory.Exists(this.PATH))
            {
                // 사용자 폴더 생성은 계정 생성 시 한번만 실행되어야 한다.
                // 일련의 오류로 이전 사용자 폴더가 남았을 경우 지우고 새로 만든다.
                Debug.Log("사용되지 않는 동명의 사용자 정보 삭제");
                deleteUserHome();
            }

            Directory.CreateDirectory(this.PATH);
        }
        catch (Exception e){
            Debug.LogError("사용자 폴더 생성 실패");
            Debug.LogError(e);
            return false;
        }
        return true;
    }

    public bool deleteUserHome()
    {
        try
        {
            if (Directory.Exists(this.PATH))
            {
                // 내부 파일 삭제
                string[] childFiles = Directory.GetFiles(this.PATH);
                foreach (string cf in childFiles)
                {
                    File.Delete(cf);
                }
                // TODO: 여기서 코루틴을 이용하여 IO를 기다리는걸 권장
                // 폴더 삭제
                Directory.Delete(this.PATH);
            }
        } catch(Exception e)
        {
            Debug.LogError("사용자 폴더 삭제 실패");
            Debug.LogError(e);
            return false;
        }

        return true;
    }

    // TODO: 문서 생성, 변경, 제거 구현!
    public XmlDocument createFile(string fileName)
    {
        return new XmlDocument();
    }

    public bool deleteFile(string fileName)
    {
        return false;
    }

    public string[] getFileList()
    {
        // 파일목록 반환
        string[] result = Directory.GetFiles(this.PATH);
        return result;
    }

    public XmlDocument openFile(string fileName)
    {
        return new XmlDocument();
    }

    public bool overWriteFile(string fileName)
    {
        return false;
    }
}

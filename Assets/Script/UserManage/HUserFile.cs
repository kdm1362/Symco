using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml;

public class HUserFile
{
    private string username;
    private string PATH;
    private int validFlag;
    private bool isAdmin;

    public HUserFile(string username)
    {
        this.username = username;
        this.PATH = Path.Combine(Application.persistentDataPath, username);
        this.validFlag = 0;
        if (username.Equals("teacher"))
            this.isAdmin = true;
        else
            this.isAdmin = false;
        SymcoManager.symcoDebugInfo("is this Admin = " + this.isAdmin.ToString());
        SymcoManager.symcoDebugInfo("User Folder Location: " + this.PATH);
    }
    public HUserFile(int valid)
    {
        this.validFlag = valid;
    }

    public int IsValid()
    {
        return this.validFlag;
    }
    
    public bool IsAdmin()
    {
        return this.isAdmin;
    }

    public string getUserName()
    {
        return this.username;
    }

    public string getPath()
    {
        return this.PATH;
    }

    public bool createUserHome()
    {
        try
        {
            if (Directory.Exists(this.PATH))
            {
                // 사용자 폴더 생성은 계정 생성 시 한번만 실행되어야 한다.
                // 일련의 오류로 이전 사용자 폴더가 남았을 경우 지우고 새로 만든다.
                SymcoManager.symcoDebugInfo("Delete unusing same name Folder");
                deleteUserHome();
            }

            // 유저 홈 디렉토리 생성
            Directory.CreateDirectory(this.PATH);

            string cursor;
            // 유저 순서도 디렉토리 생성
            cursor = Path.Combine(this.PATH, "workbench");
            Directory.CreateDirectory(cursor);

            // 유저 문제풀이 디렉토리 생성
            cursor = Path.Combine(this.PATH, "learning");
            Directory.CreateDirectory(cursor);
            // 진행상황 저장 파일 생성
            createScoreCard(Path.Combine(cursor, "scorecard.xml"));
        }
        catch (Exception e){
            SymcoManager.symcoDebugInfo("User Folder create Failed");
            SymcoManager.symcoDebugError(e);
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
                // TODO: 여기서 코루틴을 이용하여 IO를 기다리는걸 권장
                // 폴더 삭제
                deleteDirectory(this.PATH);
            }
        } catch(Exception e)
        {
            SymcoManager.symcoDebugError("User Folder Deleted Failed");
            SymcoManager.symcoDebugError(e);
            return false;
        }

        return true;
    }

    private void deleteDirectory(string path)
    {
        try
        {
            // 자식 디렉토리 삭제
            foreach(string childDir in Directory.GetDirectories(path))
            {
                deleteDirectory(childDir);
            }
            // 자식 파일 삭제
            foreach (string childFile in Directory.GetFiles(path))
            {
                File.Delete(childFile);
            }
            // 목표 디렉토리 삭제
            Directory.Delete(path);
        }
        catch(Exception e)
        {
            SymcoManager.symcoDebugError(e);
            return;
        }
        SymcoManager.symcoDebugInfo("Remove directory success: " + path);
    }

    // TODO: 문서 생성, 변경, 제거 구현!
    public XmlDocument createFile(string fileName)
    {
        return new XmlDocument();
    }

    public XmlDocument createScoreCard(string fileName)
    {
        XmlDocument score = createFile(fileName);
        return score;
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

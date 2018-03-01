using System.Collections.Generic;
using UnityEngine;
using AY_Util;

/// <summary>
/// ���̊Ǘ����s���N���X�ł�
/// </summary>
public class FishManager
{
    /// <summary>
    /// ���𐶐�����Ƃ��Ɏg���A�����̏����l�ł��B
    /// </summary>
    private Quaternion _firstDirection = Quaternion.Euler( new Vector3( 0, 90, 0 ) );

    /// <summary>
    /// �^����Z���\�L���邽�߂̃��b�p�[�N���X�ł��B
    /// </summary>
    /// <typeparam name="T">�Ǘ�����Ώۂ̃N���X</typeparam>
    public class DictStack<T> : Dictionary<string, Stack<T>> { }

    /// <summary>
    /// ���̃C���X�^���X�������`���ŕێ����Ă��܂��B
    /// </summary>
    private DictStack<GameObject> _fishDictionary = new DictStack<GameObject>();

    /// <summary>
    /// ���𐶐����邽�߂Ɏg�����̃I�u�W�F�N�g�ł��B
    /// </summary>
    private GameObject _water;

    /// <summary>
    /// �}�l�[�W���[���琅�̏������炢�܂��B
    /// </summary>
    /// <param name="water"> ���̃I�u�W�F�N�g�ł��B </param>
    public FishManager ( GameObject water ) { _water = water; }

    /// <summary>
    /// ���̃C���X�^���X�𑝂₷�֐��ł��B
    /// </summary>
    /// <param name="type">���̎�ނł�</param>
    /// <param name="fish_name">���̖��O�ł�</param>
    public void FishCreate ( BioType type, string fish_name )
    {
        var frame1 = new System.Diagnostics.StackFrame( 1 );
        var frame0 = new System.Diagnostics.StackFrame( 0 );
        Debug.LogFormat( " {0} <= {1} : {2} ", frame0.GetMethod().Name, frame1.GetType().Name, frame1.GetMethod().Name );
        DictionaryFix( fish_name );
        Vector3 waterScale = _water.transform.localScale;
        GameObject objResource = LoadRecource( type, fish_name );

        GameObject obj = GameObject.Instantiate( objResource );
        obj.transform.position = FirstPosition( waterScale );
        obj.transform.rotation = _firstDirection;

        obj.name = fish_name;
        _fishDictionary[fish_name].Push( obj );
    }

    /// <summary>
    /// ���̃C���X�^���X���폜���܂��B
    /// </summary>
    /// <param name="fish_name">�폜���鋛�̖��O�ł��B</param>
    /// <returns></returns>
    public bool ObjectDelete ( string fish_name )
    {
        if (_fishDictionary[fish_name].Count < 1) return false;
        GameObject.Destroy( _fishDictionary[fish_name].Pop() );
        return true;
    }

    /// <summary>
    /// ���C���X�^���X���Ǘ����鎫���ɁA���ڂ�����Ȃ���Βǉ����܂��B
    /// </summary>
    /// <param name="fish_name"></param>
    private void DictionaryFix ( string fish_name )
    {
        bool isArrayExist = _fishDictionary.ContainsKey( fish_name );
        if (isArrayExist) return;
        _fishDictionary.Add( fish_name, new Stack<GameObject>() );
    }

    /// <summary>
    /// ���̏����ʒu�����߂�֐��ł��B�����_�����g���Ă��܂��B
    /// </summary>
    /// <param name="waterScale">�����ʒu�����߂�ׂɎg���A���̑傫���ł��B</param>
    /// <returns>�����ʒu���x�N�g���ŕԂ��܂��B</returns>
    private Vector3 FirstPosition ( Vector3 waterScale )
    {
        float randomX = Random.Range( -1.0f, 1.0f ) * waterScale.x / 2;
        float randomY = Random.Range( -1.0f, 1.0f ) * waterScale.y / 2;
        return new Vector3( randomX, randomY, 0 );
    }

    /// <summary>
    /// ���̃��\�[�X��ǂݍ���ł��܂��B
    /// ���̃R�[�h�͏������d�����߁A���C�\��ł��B
    /// </summary>
    /// <param name="Type">���̎�ނ��w�肵�܂��B</param>
    /// <param name="fish_name">���̖��O�ł��B</param>
    /// <returns>�ǂݍ��܂ꂽ���\�[�X��Ԃ��܂��B</returns>
    private GameObject LoadRecource ( BioType type, string fish_name )
    {
        string[] folderName = { "Fish", "Leaf", "Accessory", "Terrain" };

        var str = "Prefub/" + folderName[(int) type] + "/" + fish_name;
        Debug.Log( "Load : " + str );

        return Resources.Load( str ) as GameObject;
    }
}

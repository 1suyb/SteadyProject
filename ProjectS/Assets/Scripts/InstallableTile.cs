using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallableTile : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Transform _towerInstallPivot;
    private Color _defaultColor;
    [SerializeField] GameObject _towerPrefab;
    private void Awake()
    {
        _towerInstallPivot = transform.GetChild(0);
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultColor = _meshRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        _meshRenderer.material.color = Color.green;
    }
    private void OnMouseExit()
    {
        _meshRenderer.material.color = _defaultColor;
    }

    private void OnMouseUp()
    {
        InstallTower();
    }

    public void InstallTower()
    {
        // TODO : stagemanager로부터 최대 타워 개수를 받아서 생성 제한 하는 로직
        SpawnManager.Instance.SpawnTower(-1,_towerInstallPivot.position);
    }
}

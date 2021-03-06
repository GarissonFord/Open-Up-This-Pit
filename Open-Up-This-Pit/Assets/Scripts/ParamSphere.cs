﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamSphere : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    Material _material;

    public bool randomBand;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
        if (randomBand)
        {
            _band = Random.Range(0, 8);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            transform.localScale = new Vector3((AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale, (AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale, (AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale);
            Color _color = new Color(AudioPeer._audioBandBuffer[_band], AudioPeer._audioBandBuffer[_band], AudioPeer._audioBandBuffer[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
        if (!_useBuffer)
        {
            transform.localScale = new Vector3((AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale, (AudioPeer._freqBand[_band] * _scaleMultiplier) + _startScale, (AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale);
            Color _color = new Color(AudioPeer._audioBand[_band], AudioPeer._audioBand[_band], AudioPeer._audioBand[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
    }
}

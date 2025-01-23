using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DataDecals : ScriptableObject {
    private String _name;
    private GameObject _decal;

    public String Name {
        get => this._name;
        private set {
            this._name = value;
        }
    }

    public GameObject Decal {
        get => this._decal;
        private set {
            this._decal = value;
        }
    }
}


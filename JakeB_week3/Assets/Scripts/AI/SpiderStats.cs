using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpiderStats", menuName = "ScriptableObjects/SpiderStats", order = 1)]
public class SpiderStats : ScriptableObject {
    public float moveSpeed = 8f;
    public int scoreValue = 1;
    public int maxHealth = 3;
}
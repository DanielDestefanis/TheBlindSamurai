using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableSounds/EnemySounds")]
public class ScriptableSounds : ScriptableObject
{
    public AudioSource audioSource;

    public List<AudioClip> clipList;
}

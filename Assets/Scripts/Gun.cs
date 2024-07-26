using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform leftHandTargetTranform;

    [SerializeField]
    private Transform leftHandHintTranform;

    [SerializeField]
    private Transform rightHandTargetTranform;

    [SerializeField]
    private Transform rightHandHintTranform;

    [SerializeField]
    private Vector3 offsetRotation;

    [SerializeField]
    private float rangeShock = 0.05f;

    [SerializeField]
    private float shockTime = 0.2f;

    public Vector3 OffSetRotation => offsetRotation;
    public float RangeShock => rangeShock;
    public float ShockTime => shockTime;
    public Transform LeftHandTargetTransform => leftHandTargetTranform;
    public Transform LeftHandHintTranform => leftHandHintTranform;
    public Transform RightHandTargetTransform => rightHandTargetTranform;
    public Transform RightHandHintTransform => rightHandHintTranform;
}

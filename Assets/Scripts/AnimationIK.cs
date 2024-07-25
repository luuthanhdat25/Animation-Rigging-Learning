using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimationIK : MonoBehaviour
{
    [SerializeField]
    private Transform leftHandTargetTransform;

    [SerializeField]
    private Transform leftHandHintTransform;

    [SerializeField]
    private Transform rightHandTargetTransform;

    [SerializeField]
    private Transform rightHandHintTransform;

    [SerializeField]
    private MultiAimConstraint chestAimConstraint;

    [SerializeField]
    private Gun rifle;

    [SerializeField]
    private Gun pistol;

    private Gun currentGun;

    private void Start()
    {
        pistol.gameObject.SetActive(false);
        EquipGun(rifle);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchGun();
        }
    }

    private void EquipGun(Gun newGun)
    {
        currentGun?.gameObject.SetActive(false);
        newGun.gameObject.SetActive(true);
        currentGun = newGun;

        chestAimConstraint.data.offset = newGun.OffSetRotation;
        leftHandTargetTransform.SetPositionAndRotation(currentGun.LeftHandTargetTransform.position, currentGun.LeftHandTargetTransform.rotation);
        leftHandHintTransform.SetPositionAndRotation(currentGun.LeftHandHintTranform.position, currentGun.LeftHandHintTranform.rotation);
        rightHandTargetTransform.SetPositionAndRotation(currentGun.RightHandTargetTransform.position, currentGun.RightHandTargetTransform.rotation);
        rightHandHintTransform.SetPositionAndRotation(currentGun.RightHandHintTransform.position, currentGun.RightHandHintTransform.rotation);
    }

    private void SwitchGun()
    {
        EquipGun(currentGun == rifle ? pistol : rifle);
    }
}

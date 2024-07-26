using System.Net.NetworkInformation;
using Unity.VisualScripting;
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
    private float startZ;
    private float timer;
    private bool isIncrease = true;

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

        if (Input.GetMouseButton(0))
        {
            timer += isIncrease? Time.deltaTime : -Time.deltaTime;
            float process = Mathf.Clamp01(timer / currentGun.ShockTime); // Clamp to ensure process is between 0 and 1
            if (timer >= currentGun.ShockTime)
            {
                isIncrease = false;
            }
            else if(timer < 0)
            {
                isIncrease = true;
            }
            float zLerp = Mathf.Lerp(startZ - currentGun.RangeShock, startZ + currentGun.RangeShock, process);
            currentGun.transform.localPosition = new Vector3(currentGun.transform.localPosition.x, currentGun.transform.localPosition.y, zLerp);
            chestAimConstraint.data.offset = new Vector3(zLerp * 100, chestAimConstraint.data.offset.y, chestAimConstraint.data.offset.z); ;
            UpdateHandPositon();
        }
    }

    private void EquipGun(Gun newGun)
    {
        currentGun?.gameObject.SetActive(false);
        newGun.gameObject.SetActive(true);
        currentGun = newGun;
        startZ = currentGun.transform.position.z;
        chestAimConstraint.data.offset = newGun.OffSetRotation;
        UpdateHandPositon();
        timer = 0;
        isIncrease = true;
    }

    private void UpdateHandPositon()
    {
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

// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using XftWeapon;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("X Weapon Trail")]
    [Tooltip("Set Granularity for X weapon trail.")]

    public class SetWeaponGranularity : FsmStateAction

    {
        [RequiredField]
        [CheckForComponent(typeof(XWeaponTrail))]
        public FsmOwnerDefault gameObject;

        [Title("Granularity")]
        public FsmInt Granularity;
        public FsmBool everyFrame;

        XWeaponTrail theScript;

        public override void Reset()
        {

            Granularity = null;
            gameObject = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);

            theScript = go.GetComponent<XWeaponTrail>();

            if (!everyFrame.Value)
            {
                MakeItSo();
                Finish();
            }

        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                MakeItSo();
            }
        }


        void MakeItSo()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            theScript.Granularity = Granularity.Value;

        }

    }
}

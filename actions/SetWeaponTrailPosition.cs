// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using XftWeapon;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("X Weapon Trail")]
    [Tooltip("Set Start and End of weapon trail.")]

    public class SetWeaponTrailPosition : FsmStateAction

    {
        [RequiredField]
        [CheckForComponent(typeof(XWeaponTrail))]
        public FsmOwnerDefault gameObject;

        [Title("Set Start Point")]
        [ObjectType(typeof(Transform))]
        public FsmObject PointStart;

        [Title("Set End Point")]
        [ObjectType(typeof(Transform))]
        public FsmObject PointEnd;

        public FsmBool everyFrame;

        XWeaponTrail theScript;

        public override void Reset()
        {

            PointStart = null;
            PointEnd = null;
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

            theScript.PointStart = (Transform)PointStart.Value;
            theScript.PointEnd = (Transform)PointEnd.Value;


        }

    }
}

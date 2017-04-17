// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using XftWeapon;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("X Weapon Trail")]
    [Tooltip("Set max frames for X weapon trail.")]

    public class SetWeaponMaxFrame : FsmStateAction

    {
        [RequiredField]
        [CheckForComponent(typeof(XWeaponTrail))]
        public FsmOwnerDefault gameObject;

        [Title("Max Frame")]
        public FsmInt MaxFrame;
        public FsmBool everyFrame;

        XWeaponTrail theScript;

        public override void Reset()
        {

            MaxFrame = null;
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

            theScript.MaxFrame = MaxFrame.Value;

        }

    }
}

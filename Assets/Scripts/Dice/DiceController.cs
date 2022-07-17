using System;
using System.Collections.Generic;
using DefaultNamespace;
using ScriptableObjects;
using UnityEngine;

namespace Dice
{
    public abstract class DiceController : MonoBehaviour
    {
        //dice order in mesh
        //bottom
        //XPos
        //zPos
        //top
        //xNeg
        //Dice background color
        //zNeg
        
        [Serializable]
        public struct DiceFaces<T>
        {
            public T top;
            public T bottom;
            public T xPos;
            public T xNeg;
            public T zPos;
            public T zNeg;
        }
        [SerializeField] protected MeshRenderer meshRenderer;
        protected List<Ability> AbilityList = new List<Ability>();
        protected DiceRolling DiceRolling;
        protected int _topFace = 0;


        private void Awake()
        {
            DiceRolling = GetComponent<DiceRolling>();
        }

        protected virtual void OnValidate()
        {
            DiceRolling = GetComponent<DiceRolling>();
            meshRenderer = GetComponent<MeshRenderer>();
        }

        protected virtual void Start()
        {
            DiceRolling.diceStopRollingEvent.AddListener(DiceHaveStoppedRolling);
        }
       // public abstract void UpdateMaterials();
        protected void UpdateMaterials<T>(DiceFaces<T> diceFaces)
        {
            var newMaterial = new Material[7];

            newMaterial[0] = (Ability)(object)diceFaces.bottom ? ((Ability)(object)diceFaces.bottom).material : null;
            newMaterial[1] = (Ability)(object)diceFaces.xPos ? ((Ability)(object)diceFaces.xPos).material: null;
            newMaterial[2] = (Ability)(object)diceFaces.zPos ? ((Ability)(object)diceFaces.zPos).material: null;
            newMaterial[3] = (Ability)(object)diceFaces.top ? ((Ability)(object)diceFaces.top).material: null;
            newMaterial[4] = (Ability)(object)diceFaces.xNeg ? ((Ability)(object)diceFaces.xNeg).material: null;
            newMaterial[5] = DiceRolling.diceColor;
            newMaterial[6] = (Ability)(object)diceFaces.zNeg ? ((Ability)(object)diceFaces.zNeg).material: null;

            meshRenderer.materials = newMaterial;
        }
        
        protected void ValidateActionList<T>(DiceFaces<T> diceFaces)
        {
            if ((Ability)(object)diceFaces.top) AbilityList.Add((Ability)(object)diceFaces.top);
            if ((Ability)(object)diceFaces.bottom) AbilityList.Add((Ability)(object)diceFaces.bottom);
            if ((Ability)(object)diceFaces.xPos) AbilityList.Add((Ability)(object)diceFaces.xPos);
            if ((Ability)(object)diceFaces.xNeg) AbilityList.Add((Ability)(object)diceFaces.xNeg);
            if ((Ability)(object)diceFaces.zPos) AbilityList.Add((Ability)(object)diceFaces.zPos);
            if ((Ability)(object)diceFaces.zNeg) AbilityList.Add((Ability)(object)diceFaces.zNeg);
            
            if(AbilityList.Count != 6)
            {
                Debug.Log("Please check all the faces to the dice! There must be 6 faces in " 
                     + this.name);
                enabled = false;
            }
        }
        protected void DiceHaveStoppedRolling()
        {
            _topFace = 0;
            for (int i = 0; i < DiceRolling.facesTransform.Count; i++)
            {
                if (DiceRolling.facesTransform[i].position.y > DiceRolling.facesTransform[_topFace].position.y)
                {
                    _topFace = i;
                }
            }
        }

        public Vector3 GetTopFaceDirection()
        {
            var topFaceDirection = DiceRolling.facesTransform[_topFace].position - transform.position;
            return topFaceDirection;
        }
        public void ExecuteTopFace(PlayerController player1, PlayerController enemy)
        {
            AbilityList[_topFace].Execute(player1, enemy);
        }
    }
}

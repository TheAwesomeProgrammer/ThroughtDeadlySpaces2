using UnityEngine;

namespace Assets.Scripts.Player
{
    public class DexterityFiller : MonoBehaviour
    {
        public float SecoundsToFillOneDexterity = 1;

        public float Dexterity
        {
            get { return _dexterity; }
            set { _dexterity = Mathf.Clamp(value, 0, MaxDexterity); }
        }

        public float MaxDexterity { get; set; }

        private float _dexterity;

        void Start()
        {
            Dexterity = MaxDexterity;
        }

        public bool HasEnoughDexterity(float dexterity)
        {
            return Dexterity >= dexterity;
        }

        void FixedUpdate()
        {
            Fill();
        }

        void Fill()
        {
            Dexterity += CalculateFillAmount();
        }

        float CalculateFillAmount()
        {
            return (Time.fixedDeltaTime / SecoundsToFillOneDexterity);
        }
         
    }
}
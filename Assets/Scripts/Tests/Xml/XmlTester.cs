using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Curses;
using Assets.Scripts.Tests.Helper;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Tests.Xml
{
    public class XmlTester : MonoBehaviour
    {
        private XmlSearcher _xmlSearcher;

        void Start()
        {
            Reset();
            TestIfCanFindSwordBySwordId();
            Reset();
            TestIfCanFindSwordSpecs();
            Reset();
            TestIfCanFindRustyCurseSpecs();
            Reset();
            TestIfCanFindVStellSwordBlessingSpecs();
            Reset();
            TestIfCanFindLifeDrainSwordSpecs();
        }

        void Reset()
        {
            _xmlSearcher = new XmlSearcher(Location.Sword);
        }

        void TestIfCanFindSwordBySwordId()
        {
            Assert.IsEquals(_xmlSearcher.GetNodeWithId(0, "Swords").Attributes["name"].InnerText, "Standard",
                "Test if can find sword by sword id");
        }

        void TestIfCanFindSwordSpecs()
        {
            int[] specs = _xmlSearcher.GetSpecsWithId(0, "Swords");
            Assert.IsEquals(specs[0], 1, "Test sword base damage");
            Assert.IsEquals(specs[1], 2, "Test sword combat type1 damage");
            Assert.IsEquals(specs[2], 3, "Test sword combat type2 damage");
            Assert.IsEquals(specs[3], 4, "Test sword combat type3 damage");
            Assert.IsEquals(specs[4], 5, "Test sword combat type4 damage");
        }

        void TestIfCanFindRustyCurseSpecs()
        {
            _xmlSearcher = new XmlSearcher(Location.Curse);
            int[] specs = _xmlSearcher.GetSpecsWithId(2, "Curses");

            RustySwordCurse rustySwordCurse = gameObject.AddComponent<RustySwordCurse>();
            rustySwordCurse.MinusProcentDamage = 0;
            rustySwordCurse.ProcentToBreakSword = 0;

            rustySwordCurse.LoadSpecs();

            Assert.IsEquals(specs[0], rustySwordCurse.MinusProcentDamage, "Test minus procent damage");
            Assert.IsEquals(specs[1], rustySwordCurse.ProcentToBreakSword, "Test procent to break sword");
        }

        void TestIfCanFindVStellSwordBlessingSpecs()
        {
            _xmlSearcher = new XmlSearcher(Location.Blessing);
            int[] specs = _xmlSearcher.GetSpecsWithId(0, "Blessings");

            VsteelSwordBaseBlessing vsteelSwordBaseBlessing = gameObject.AddComponent<VsteelSwordBaseBlessing>();
            vsteelSwordBaseBlessing.CriticalHitDamageProcent = 0;
            vsteelSwordBaseBlessing.ProcentChanceOfCriticalHit = 0;

            vsteelSwordBaseBlessing.LoadSpecs();

            Assert.IsEquals(specs[0], vsteelSwordBaseBlessing.ProcentChanceOfCriticalHit, "Test procent chance of crital hit is loaded correct");
            Assert.IsEquals(specs[1], vsteelSwordBaseBlessing.CriticalHitDamageProcent, "Test critical hit damage procent is loaded correct");
        }

        void TestIfCanFindLifeDrainSwordSpecs()
        {
            _xmlSearcher = new XmlSearcher(Location.Blessing);
            int[] specs = _xmlSearcher.GetSpecsWithId(1, "Blessings");

            LifeDrainSwordBlessing lifeDrainSwordBlessing = gameObject.AddComponent<LifeDrainSwordBlessing>();
            lifeDrainSwordBlessing.LifeOnHit = 0;
            lifeDrainSwordBlessing.ProcentChanceOfGainingLifeOnHit = 0;

            lifeDrainSwordBlessing.LoadSpecs();

            Assert.IsEquals(specs[0], lifeDrainSwordBlessing.ProcentChanceOfGainingLifeOnHit, "Test procent change of ganing life on hit spec is loaded correct");
            Assert.IsEquals(specs[1], lifeDrainSwordBlessing.LifeOnHit, "Test life on hit spec is loaded correct");
        }
    }
}
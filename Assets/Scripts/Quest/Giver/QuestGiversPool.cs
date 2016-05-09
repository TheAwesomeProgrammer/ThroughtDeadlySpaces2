using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public static class QuestGiversPool
    {
        public static int NumberOfQuestGivers = 4;
        public static int RandomThreesholdTriesPerAtempt = 1000;

        private static GenerateQuestGivers _generateQuestGivers;

        private static List<QuestGiver>_questGivers;

        static QuestGiversPool()
        {
            _questGivers = new List<QuestGiver>();
            _generateQuestGivers = new GenerateQuestGivers();
            InitPool();
        }

        private static void InitPool()
        {
            for (int i = 0; i < NumberOfQuestGivers; i++)
            {
                CreateDisabledQuestGiverWithRandomId(i);
            }
        }

        private static QuestGiver CreateDisabledQuestGiverWithRandomId(int id)
        {
            QuestGiver createdQuestGiver = CreateQuestGiverWithId(id);
            DeactivateQuestGiver(createdQuestGiver);
            return createdQuestGiver;
        }

        public static void DeactivateQuestGiver(QuestGiver createdQuestGiver)
        {
            createdQuestGiver.gameObject.SetActive(false);
            createdQuestGiver.gameObject.hideFlags = HideFlags.HideInHierarchy;
        }

        public static QuestGiver CreateQuestGiverWithId(int id)
        {
            QuestGiver questGiver = _generateQuestGivers.Generate<QuestGiver>(1)[0];
            questGiver.Id = id;
            _questGivers.Add(questGiver);
            return questGiver;
        }

        public static List<QuestGiver> GenerateAliveQuestGivers(int numberOfQuestGivers)
        {
            List<QuestGiver> questGivers = new List<QuestGiver>();

            questGivers.AddRange(FindAliveQuestGivers(numberOfQuestGivers));
            int missingQuestGivers = numberOfQuestGivers - questGivers.Count;
            if (missingQuestGivers > 0)
            {
                questGivers.AddRange(GenerateRandomQuestGivers(numberOfQuestGivers - questGivers.Count));
            }

            return questGivers;
        }

        public static QuestGiver GetAliveQuestGiver()
        {
            List<QuestGiver> oneQuestGiver = FindAliveQuestGivers(1);
            if (oneQuestGiver.Count > 0)
            {
                return oneQuestGiver[0];
            }
            return null;
        }

        private static List<QuestGiver> FindAliveQuestGivers(int maxNumberOfQuestGivers)
        {
            List<QuestGiver> questGivers = new List<QuestGiver>();

            List<QuestGiver> aliveQuestGivers =
                _questGivers.FindAll(questGiver => questGiver.gameObject.activeSelf);

            foreach (var questGiver in aliveQuestGivers)
            {
                if (questGivers.Count < maxNumberOfQuestGivers)
                {
                    questGivers.Add(questGiver);
                }
            }

            return questGivers;
        }

        private static List<QuestGiver> GenerateRandomQuestGivers(int numberOfQuestGivers)
        {
            List<QuestGiver> randomQuestGivers = new List<QuestGiver>();
            QuestGiver randomQuestGiver = GetQuestGiverWithRandomId();

            for (int i = 0; i < numberOfQuestGivers; i++)
            {
                int count = 0;
                randomQuestGiver = DoesRandomQuestGiverExist(randomQuestGivers, randomQuestGiver, count);
                ActivateQuestGiver(randomQuestGiver);
                randomQuestGivers.Add(randomQuestGiver);
            }

            return randomQuestGivers;
        }

        private static void ActivateQuestGiver(QuestGiver randomQuestGiver)
        {
            randomQuestGiver.gameObject.SetActive(true);
            randomQuestGiver.gameObject.hideFlags = HideFlags.None;
        }

        private static QuestGiver DoesRandomQuestGiverExist(List<QuestGiver> randomQuestGivers, QuestGiver randomQuestGiver, int count)
        {
            while (randomQuestGivers.Contains(randomQuestGiver) && _questGivers.Count > randomQuestGivers.Count &&
                   randomQuestGivers.Count > 0)
            {
                if (HasRunOverThreeshold(count)) break;

                randomQuestGiver = GetQuestGiverWithRandomId();
                count++;
            }

            return randomQuestGiver;
        }

        private static bool HasRunOverThreeshold(int count)
        {
            if (count > RandomThreesholdTriesPerAtempt)
            {
                return true;
            }
            return false;
        }

        public static QuestGiver GetQuestGiverWithRandomId()
        {
            return _questGivers[Random.Range(0, NumberOfQuestGivers)];
        }

        public static void DeactivateAllQuestGivers()
        {
            foreach (var questGiver in FindAliveQuestGivers(NumberOfQuestGivers))
            {
                DeactivateQuestGiver(questGiver);
            }
        }

        public static void Remove(QuestGiver questGiver)
        {
            _questGivers.Remove(questGiver);
            Object.Destroy(questGiver);
        }
    }
}
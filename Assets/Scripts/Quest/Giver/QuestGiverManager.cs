using UnityEngine;

namespace Assets.Scripts.Quest
{
    public class QuestGiverManager : MonoBehaviour
    {
        public QuestGiver ActiveQuestGiver;

        public void SetActiveQuestGiver(int id)
        {
            foreach (var questGiver in FindObjectsOfType<QuestGiver>())
            {
                if (IsChosen(id, questGiver.Id))
                {
                    Chosen(questGiver);
                }
                else
                {
                    NotChosen(questGiver);
                }
            }
        }

        private static bool IsChosen(int id, int questGiverId)
        {
            return questGiverId == id;
        }

        private void Chosen(QuestGiver questGiver)
        {
            ActiveQuestGiver = questGiver;
        }

        private static void NotChosen(QuestGiver questGiver)
        {
            questGiver.Health--;
            QuestGiversPool.DeactivateQuestGiver(questGiver);
        }
    }
}
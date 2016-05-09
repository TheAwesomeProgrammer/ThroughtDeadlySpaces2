using System.Collections.Generic;
using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Quest;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI
{
    public class UiQuestGiver : UiItem
    {
        private Text _title;
        //private Image _dropTypeImage;
        //private Image _pictureOfQuestGiver;
        private Text[] _rewardTexts;
        private Text _targetText;
        private Text _difficultyText;

        protected override void OnActivate()
        {
            _rewardTexts = new Text[3];
            _title = transform.FindComponentInChildWithName<Text>("Title");
            //_dropTypeImage = transform.FindComponentInChildWithName<Image>("DropTypeImage");
            //_pictureOfQuestGiver = transform.FindComponentInChildWithName<Image>("PictureOfQuestGiver");
            _rewardTexts[0] = transform.FindComponentInChildWithName<Text>("Reward1");
            _rewardTexts[1] = transform.FindComponentInChildWithName<Text>("Reward2");
            _rewardTexts[2] = transform.FindComponentInChildWithName<Text>("Reward3");
            _targetText = transform.FindComponentInChildWithName<Text>("Target");
            _difficultyText = transform.FindComponentInChildWithName<Text>("Difficulty");
        }

        public void SetActiveQuestGiver(QuestGiverManager questGiverManager)
        {
            questGiverManager.SetActiveQuestGiver(UiId);
        }

        public override void SetProperties(params object[] properties)
        {
            QuestGiverProperties questGiverProperties = (QuestGiverProperties)properties[0];
            _title.text = questGiverProperties.Name + "(" + questGiverProperties.Health + ")";
            UiId = questGiverProperties.Id;
            List<QuestProperties> rewards = questGiverProperties.QuestPropertieses;
            AddBossGenerationPropertiesText(rewards, questGiverProperties);
            SetRewardTexts(rewards, questGiverProperties);
        }

        private void AddBossGenerationPropertiesText(List<QuestProperties> rewards, QuestGiverProperties questGiverProperties)
        {
            BossGeneratorProperties bossGeneratorProperties =
                rewards[questGiverProperties.CurrentQuestId].BossGeneratorProperties;
            _targetText.text = bossGeneratorProperties.Name;
            _difficultyText.text = bossGeneratorProperties.Difficulty.ToString();
        }

        private void SetRewardTexts(List<QuestProperties> rewards, QuestGiverProperties questGiverProperties)
        {
            for (int i = 1; i <= questGiverProperties.RewardIds.Length; i++)
            {
                var rewardText = GetRewardText(rewards, i);
                _rewardTexts[i-1].text = rewardText;
            }
        }

        private string GetRewardText(List<QuestProperties> rewards, int index)
        {
            string rewardText = "";

            foreach (var rewardWithId in GetRewardsWithId(rewards, index))
            {
                rewardText += rewardWithId.Reward + ", ";
            }

            return rewardText;
        }

        private List<QuestProperties> GetRewardsWithId(List<QuestProperties> rewards, int index)
        {
            List<QuestProperties> rewardsWithId = new List<QuestProperties>();

            foreach (var rewardSet in rewards)
            {
                if (rewardSet.Id == index)
                {
                    rewardsWithId.Add(rewardSet);
                }
            }

            return rewardsWithId;
        }
    }
}
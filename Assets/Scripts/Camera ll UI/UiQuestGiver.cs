using System.Collections.Generic;
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

        protected override void OnActivate()
        {
            _rewardTexts = new Text[3];
            _title = transform.FindComponentInChildWithName<Text>("Title");
            //_dropTypeImage = transform.FindComponentInChildWithName<Image>("DropTypeImage");
            //_pictureOfQuestGiver = transform.FindComponentInChildWithName<Image>("PictureOfQuestGiver");
            _rewardTexts[0] = transform.FindComponentInChildWithName<Text>("Reward1");
            _rewardTexts[1] = transform.FindComponentInChildWithName<Text>("Reward2");
            _rewardTexts[2] = transform.FindComponentInChildWithName<Text>("Reward3");
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
            List<Reward> rewards = questGiverProperties.Rewards;
            SetRewardTexts(rewards, questGiverProperties);
        }

        private void SetRewardTexts(List<Reward> rewards, QuestGiverProperties questGiverProperties)
        {
            for (int i = 0; i < rewards.Count; i++)
            {
                var rewardText = GetRewardText(questGiverProperties, i);
                _rewardTexts[i].text = rewardText;
            }
        }

        private string GetRewardText(QuestGiverProperties questGiverProperties, int i)
        {
            string rewardText = "";

            foreach (var rewardWithId in GetRewardsWithId(questGiverProperties, i))
            {
                rewardText += rewardWithId + ", ";
            }

            return rewardText;
        }

        private List<Reward> GetRewardsWithId(QuestGiverProperties questGiverProperties, int index)
        {
            List<Reward> rewardsWithId = new List<Reward>();

            foreach (Reward reward in questGiverProperties.Rewards)
            {
                if (reward.RewardId == questGiverProperties.RewardIds[index])
                {
                    rewardsWithId.Add(reward);
                }
            }

            return rewardsWithId;
        }
    }
}
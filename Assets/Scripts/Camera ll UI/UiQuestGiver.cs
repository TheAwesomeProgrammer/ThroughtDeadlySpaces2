using System.Collections.Generic;
using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Extensions;
using Assets.Scripts.Quest;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI
{
    public class UiQuestGiver : UiItemActive
    {
        private Text _title;
        //private Image _dropTypeImage;
        //private Image _pictureOfQuestGiver;
        private Text[] _rewardTexts;
        private Text _targetText;
        private Text _difficultyText;
        private QuestGiverProperties _questGiverProperties;

        protected override void OnShow()
        {
            base.OnShow();
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
            questGiverManager.SetActiveQuestGiver(_questGiverProperties.Id);
        }

        public override void SetProperties(params object[] properties)
        {
            base.SetProperties(properties);
            _questGiverProperties = (QuestGiverProperties)properties[0];
            _title.text = _questGiverProperties.Name + "(" + _questGiverProperties.Health + ")";
            List<Quest.Quest> rewards = _questGiverProperties.Quests;
            AddBossGenerationPropertiesText(rewards, _questGiverProperties);
            SetRewardTexts(rewards, _questGiverProperties);
        }

        private void AddBossGenerationPropertiesText(List<Quest.Quest> rewards, QuestGiverProperties questGiverProperties)
        {
            BossGeneratorProperties bossGeneratorProperties =
                rewards[questGiverProperties.CurrentQuestId].BossGeneratorProperties;
            _targetText.text = bossGeneratorProperties.Name;
            _difficultyText.text = bossGeneratorProperties.Difficulty.ToString();
        }

        private void SetRewardTexts(List<Quest.Quest> rewards, QuestGiverProperties questGiverProperties)
        {
            for (int i = 1; i <= questGiverProperties.QuestIds.Length; i++)
            {
                var rewardText = GetRewardText(rewards, i);
                _rewardTexts[i-1].text = rewardText;
            }
        }

        private string GetRewardText(List<Quest.Quest> quests, int index)
        {
            string rewardText = "";

            foreach (var rewardWithId in GetRewardsWithId(quests, index))
            {
                rewardText += rewardWithId + ", ";
            }

            return rewardText;
        }

        private List<Reward> GetRewardsWithId(List<Quest.Quest> quests, int id)
        {
	        Quest.Quest questWithId = null;

            foreach (var quest in quests)
            {
                if (quest.Id == id)
                {
	                questWithId = quest;
                }
            }

	        return Null.OnNot(questWithId, () => questWithId.Rewards);
        }
    }
}
namespace ViewModel
{
    public class PlayerStatsViewModel
    {
        private PlayerStatsModel m_PlayerStatsModel;

        public PlayerStatsViewModel()
        {
            m_PlayerStatsModel = new PlayerStatsModel();
        }

        public void ChangeAliveBool(bool type)
        {
            m_PlayerStatsModel.IsAlive = type;
        }

        public void UpdateScoresInt(int scores)
        {
            m_PlayerStatsModel.Scores = scores;
        }
        
        public void AddScoresInt(int scores)
        {
            m_PlayerStatsModel.Scores += scores;
        }

        public void AddTimeFloat(float time)
        {
            m_PlayerStatsModel.Time += time;
        }

        public PlayerStatsModel PlayerStatsModel => m_PlayerStatsModel;
    }
}
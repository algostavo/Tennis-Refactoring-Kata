namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private int m_score1, m_score2 = default;
        private string player1Name, player2Name = default;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == TennisScoreConstants.PlayerOne)
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            var stateMachine = new TennisGameScoreStateMachine();
            return stateMachine.SetScore(m_score1, m_score2);
        }
    }
}


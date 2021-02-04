using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class TennisGameScoreStateMachine
    {
        public string SetScore(int playerOneScore, int playerTwoScore)
        {
            string score = default;
            int scoreDifferential = playerOneScore - playerTwoScore;
            if (playerOneScore == playerTwoScore) score = PlayerScoreMatch(playerOneScore);
            else if (playerOneScore >= 4 || playerTwoScore >= 4) score = PlayerScoreAdvantageOrWin(scoreDifferential);
            else score = TempScore(playerOneScore, playerTwoScore, score);
            return score;
        }

        private string PlayerScoreMatch(int playerOneScore) => (playerOneScore) switch
        {
            0 => TennisScoreConstants.Love + TennisScoreConstants.All,
            1 => TennisScoreConstants.Fifteen + TennisScoreConstants.All,
            2 => TennisScoreConstants.Thirty + TennisScoreConstants.All,
            _ => TennisScoreConstants.Deuce,
        };

        private string PlayerScoreAdvantageOrWin(int scoreDifferential)
        {

            if (scoreDifferential == 1) return TennisScoreConstants.Advantage + TennisScoreConstants.PlayerOne;
            if (scoreDifferential == -1) return TennisScoreConstants.Advantage + TennisScoreConstants.PlayerTwo;
            if (scoreDifferential >= 2) return TennisScoreConstants.Win + TennisScoreConstants.PlayerOne;
            else return TennisScoreConstants.Win + TennisScoreConstants.PlayerTwo;
        }

        private string TempScore(int playerOneScore, int playerTwoScore, string score)
        {
            for (int i = 1; i < 3; i++)
            {
                var scoreValue = i == 1 ? playerOneScore : playerTwoScore;
                score += i == 1 ? string.Empty : TennisScoreConstants.Dash;
                score += PlayerPoints(scoreValue);
            }
            return score;
        }

        private string PlayerPoints(int playerScore) => (playerScore) switch
        {
            0 => TennisScoreConstants.Love,
            1 => TennisScoreConstants.Fifteen,
            2 => TennisScoreConstants.Thirty,
            3 => TennisScoreConstants.Forty,
            _ => "N/A",
        };
    }
}

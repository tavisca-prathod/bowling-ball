using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private List<Frame> TotalFramesPlayed = new List<Frame>();
        private int PreviousRollScore = 0;
        private bool isGameValid = true;
        private bool isSecondRoll = false;

        public void Roll(int pins)
        {
            if (pins == 10 && PreviousRollScore == 0)
            {
                Frame frame = new Frame(10, 0,10);
                TotalFramesPlayed.Add(frame);
                isSecondRoll = false;
            }
            else if (pins <= 10)
            {
                if (!isSecondRoll)
                {
                    isSecondRoll = true;
                    PreviousRollScore = pins;
                }
                else if ((pins + PreviousRollScore) <= 10)
                {
                    Frame frame = new Frame(PreviousRollScore, pins, pins + PreviousRollScore);
                    TotalFramesPlayed.Add(frame);
                    PreviousRollScore = 0;
                    isSecondRoll = false;
                }
                else
                {
                    isGameValid = false;
                    throw new Exception("Invalid number of pins. The total Number of pins dropped in this frame is greater than 10.");
                }
            }
            else {
                isGameValid = false;
                throw new Exception("Invalid number of pins. Pins per roll should be less than or equal to 10");
            }
        }

        public int GetScore()
        {
            if (isGameValid) {
                int totalScore = 0;
                for (int frameNumber = 0; frameNumber < TotalFramesPlayed.Count && frameNumber < 10; frameNumber++)
                {
                    int frameScore = 0;
                    Frame frame = TotalFramesPlayed[frameNumber];
                    if (frame.Score == 10) {
                     // for strike
                        if (frame.RollOne == 10)
                        {
                            frameScore = GetScoreForStrike(frame,frameNumber);
                        }
                     // for spare
                        else {
                            frameScore = GetScoreForSpare(frame, frameNumber);
                        }
                    }
                     // no strike no spare
                    else {
                        frameScore = frameScore + frame.Score;
                    }
                    totalScore = totalScore + frameScore;
                }
                return totalScore;
                }
            else 
            return -1;
        }

        private int GetScoreForStrike(Frame frame,int frameNumber) {
            int frameScore = 0;
            if (TotalFramesPlayed.Count - 1 >= frameNumber + 1)
            {
                if (TotalFramesPlayed[frameNumber + 1].RollOne != 10)
                    frameScore = frameScore + TotalFramesPlayed[frameNumber + 1].Score + frame.Score;
                else if (TotalFramesPlayed.Count - 1 >= frameNumber + 2)
                {
                    frameScore = frameScore + TotalFramesPlayed[frameNumber + 1].Score + TotalFramesPlayed[frameNumber + 2].RollOne + frame.Score;
                }
                else {
                    frameScore = frameScore + TotalFramesPlayed[frameNumber + 1].Score + frame.Score;
                }
            }
            else
            {
                frameScore = frameScore + frame.Score;
            }
            return frameScore;
        }

        private int GetScoreForSpare(Frame frame, int frameNumber)
        {
            int frameScore = 0;
            if (TotalFramesPlayed.Count - 1 >= frameNumber + 1)
            {
                frameScore = frameScore + TotalFramesPlayed[frameNumber + 1].RollOne + frame.Score;
            }
            else
            {
                frameScore = frameScore + frame.Score;
            }
            return frameScore;
        }
    }
}
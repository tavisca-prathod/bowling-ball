using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Frame
    {
        public int RollOne;
        public int RollTwo;
        public int Score;

        public Frame(int RollOne, int RollTwo,int Score) {
            this.RollOne = RollOne;
            this.RollTwo = RollTwo;
            this.Score = Score;
        }
    }
}

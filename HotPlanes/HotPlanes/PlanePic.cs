using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotPlanes
{
    public class PlanePic
    {
        private string path;
        private int score;

        public PlanePic(string path, int score)
        {
            this.path = path;
            this.score = score;
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}

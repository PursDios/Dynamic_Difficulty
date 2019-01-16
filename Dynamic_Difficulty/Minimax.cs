using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Difficulty
{
    public class Minimax
    {
        char[] m_G;
        int m_Score;
        bool m_TurnForPlayerX;
        public int RecursiveScore
        {
            get;
            private set;
        }
        public bool GameOver
        {
            get;
            private set;
        }

        public char[] MG
        {
            get
            {
                return this.m_G;
            }
        }

        public Minimax(char[] values, bool turnForPlayerX)
        {
            m_TurnForPlayerX = turnForPlayerX;
            m_G = values;
            ComputeScore();
        }

        public bool IsTerminalNode()
        {
            if (GameOver)
                return true;
            //if all entries are set, then it is a leaf node
            foreach (char v in m_G)
            {
                if (v != 'X' && v != 'O')
                    return false;
            }
            return true;
        }

        public IEnumerable<Minimax> GetChildren()
        {
            for (int i = 0; i < m_G.Length; i++)
            {
                if (m_G[i] != 'X' && m_G[i] != 'O')
                {
                    char[] newValues = (char[])m_G.Clone();
                    newValues[i] = m_TurnForPlayerX ? 'X' : 'O';
                    yield return new Minimax(newValues, !m_TurnForPlayerX);
                }
            }
        }

        //http://en.wikipedia.org/wiki/Alpha-beta_pruning
        public int MiniMax(int depth, int alpha, int beta, out Minimax childWithMax)
        {
            childWithMax = null;
            if (depth == 0 || IsTerminalNode())
            {
                //When it is turn for PlayO, we need to find the minimum score.
                RecursiveScore = m_Score;
                return m_TurnForPlayerX ? m_Score : -m_Score;
            }

            foreach (Minimax cur in GetChildren())
            {
                Minimax dummy;
                int score = -cur.MiniMax(depth - 1, -beta, -alpha, out dummy);
                if (alpha < score)
                {
                    alpha = score;
                    childWithMax = cur;
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
            }

            RecursiveScore = alpha;
            return alpha;
        }

        public Minimax FindNextMove(int depth)
        {
            Minimax ret = null;
            MiniMax(depth, int.MinValue + 1, int.MaxValue - 1, out ret);
            return ret;
        }

        int GetScoreForOneLine(char[] values)
        {
            int countX = 0, countO = 0;
            foreach (char v in values)
            {
                if (v == 'X')
                    countX++;
                else if (v == 'O')
                    countO++;
            }

            if (countO == 3 || countX == 3)
            {
                GameOver = true;
            }

            //The player who has turn should have more advantage.
            //What we should have done
            int advantage = 1;
            if (countO == 0)
            {
                if (m_TurnForPlayerX)
                    advantage = 3;
                return (int)System.Math.Pow(10, countX) * advantage;
            }
            else if (countX == 0)
            {
                if (!m_TurnForPlayerX)
                    advantage = 3;
                return -(int)System.Math.Pow(10, countO) * advantage;
            }
            return 0;
        }

        void ComputeScore()
        {
            int ret = 0;
            int[,] lines = { { 0, 1, 2 },
                           { 3, 4, 5 },
                           { 6, 7, 8 },
                           { 0, 3, 6 },
                           { 1, 4, 7 },
                           { 2, 5, 8 },
                           { 0, 4, 8 },
                           { 2, 4, 6 }
                           };

            for (int i = lines.GetLowerBound(0); i <= lines.GetUpperBound(0); i++)
            {
                ret += GetScoreForOneLine(new char[] { this.m_G[lines[i, 0]], m_G[lines[i, 1]], m_G[lines[i, 2]] });
            }
            m_Score = ret;
        }

        public void UpdateBoard(char[] p_Arr)
        {
            this.m_G = (char[])p_Arr.Clone();
        }
    }
}

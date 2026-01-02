using System;
using System.Collections.Generic;
using System.Security.Cryptography;

class GFGconnect4
{

    public class Move
    {
        public int row;
    };

    static int player = 2, opponent = 1;

    static Boolean isMovesLeft(int[,] board)
    {
        for (int i = 0; i < 7; i++)
            if (board[i, 0] == 0)
                return true;
        return false;
    }

    static int evaluate(int[,] b)
    {
        for (int row = 0; row < 7; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (b[row, col] == b[row, col+1] && b[row, col] == b[row, col+2] && b[row, col] == b[row, col+3])
                {
                    if (b[row, col] == player)
                        return +10;
                    else if (b[row, col] == opponent)
                        return -10;
                }
            }
        }

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 6; col++)
            {
                if (b[row, col] == b[row + 1, col] && b[row, col] == b[row + 2, col] && b[row, col] == b[row + 3, col])
                {
                    if (b[row, col] == player)
                        return +10;
                    else if (b[row, col] == opponent)
                        return -10;
                }
            }
        }

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (b[row, col] == b[row + 1, col + 1] && b[row, col] == b[row + 2, col + 2] && b[row, col] == b[row + 3, col + 3])
                {
                    if (b[row, col] == player)
                        return +10;
                    else if (b[row, col] == opponent)
                        return -10;
                }
            }
        }

        for (int row = 0; row < 4; row++)
        {
            for (int col = 3; col < 6; col++)
            {
                if (b[row, col] == b[row + 1, col - 1] && b[row, col] == b[row + 2, col - 2] && b[row, col] == b[row + 3, col - 3])
                {
                    if (b[row, col] == player)
                        return +10;
                    else if (b[row, col] == opponent)
                        return -10;
                }
            }
        }

        return 0;
    }

    static int minimax(int[,] board,
                       int depth, Boolean isMax, int[] levels)
    {
        int score = evaluate(board);
        if (depth > 6) return score;

        if (score == 10)
            return score;

        if (score == -10)
            return score;

        if (isMovesLeft(board) == false)
            return 0;

        if (isMax)
        {
            int best = -1000000;

            for (int i = 0; i < 7; i++)
            {
                if (levels[i] != 6)
                {
                    if (board[i, 5 - levels[i]] == 0)
                    {
                        board[i, 5 - levels[i]] = player;
                        levels[i]++;

                        best = Math.Max(best, minimax(board,
                                        depth + 1, !isMax, levels));

                        board[i, 6 - levels[i]] = 0;
                        levels[i]--;
                    }
                }
            }
            return best;
        }

        else
        {
            int best = 1000000;

            for (int i = 0; i < 7; i++)
            {
                if (levels[i] != 6)
                {
                    if (board[i, 5 - levels[i]] == 0)
                    {
                        board[i, 5 - levels[i]] = opponent;
                        levels[i]++;

                        best = Math.Min(best, minimax(board,
                                        depth + 1, !isMax, levels));

                        board[i, 6 - levels[i]] = 0;
                        levels[i]--;
                    }
                }
            }
            return best;
        }
    }

    public static Move findBestMove(int[,] board, int[] levels)
    {
        int bestVal = -1000000;
        Move bestMove = new Move();
        bestMove.row = -1;

        for (int i = 0; i < 7; i++)
        {
            if (board[i, 0] == 0)
            {
                board[i, 5 - levels[i]] = player;
                levels[i]++;

                int moveVal = minimax(board, 0, false, levels);

                board[i, 6 - levels[i]] = 0;
                levels[i]--;

                if (moveVal > bestVal)
                {
                    bestMove.row = i;
                    bestVal = moveVal;
                }
            }
        }
        return bestMove;
    }
}

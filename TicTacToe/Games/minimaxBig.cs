using System;
using System.Collections.Generic;

class GFGbig
{

    public class Move
    {
        public int row, col;
    };

    static int player = 2, opponent = 1;

    static Boolean isMovesLeft(int[,] board)
    {
        for (int i = 0; i < 7; i++)
            for (int j = 0; j < 7; j++)
                if (board[i, j] == 0)
                    return true;
        return false;
    }

    static int evaluate(int[,] b)
    {
        for (int row = 0; row < 7; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (b[row, col] == b[row, col+1] &&
                    b[row, col+1] == b[row, col+2] &&
                    b[row, col+1] == b[row, col+3])
                {
                    if (b[row, col] == player)
                        return +10;
                    else if (b[row, col] == opponent)
                        return -10;
                }
            }
        }

        for (int col = 0; col < 7; col++)
        {
            for (int row = 0; row < 4; row++)
            {
                if (b[row, col] == b[row+1, col] &&
                    b[row+1, col] == b[row+2, col] &&
                    b[row+2, col] == b[row+3, col])
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
            for (int col = 0; col < 4; col++)
            {
                if (b[row, col] == b[row+1, col+1] && b[row+1, col+1] == b[row+2, col+2] && b[row + 2, col + 2] == b[row + 3, col + 3])
                {
                    if (b[row, col] == player)
                        return +10;
                    else if (b[row, col] == opponent)
                        return -10;
                }

                if (b[row, col+3] == b[row + 1, col + 2] && b[row + 1, col + 2] == b[row + 2, col + 1] && b[row + 2, col + 1] == b[row + 3, col + 0])
                {
                    if (b[row, col+3] == player)
                        return +10;
                    else if (b[row, col+3] == opponent)
                        return -10;
                }
            }
        }

        return 0;
    }

    static int minimax(int[,] board,
                       int depth, Boolean isMax)
    {
        int score = evaluate(board);
        if (depth > 2) return score;

        if (score == 10)
            return score;

        if (score == -10)
            return score;

        if (isMovesLeft(board) == false)
            return 0;

        if (isMax)
        {
            int best = -1000;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] == 0)
                    {
                        board[i, j] = player;

                        best = Math.Max(best, minimax(board,
                                        depth + 1, !isMax));

                        board[i, j] = 0;
                    }
                }
            }
            return best;
        }

        else
        {
            int best = 1000;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] == 0)
                    {
                        board[i, j] = opponent;

                        best = Math.Min(best, minimax(board,
                                        depth + 1, !isMax));

                        board[i, j] = 0;
                    }
                }
            }
            return best;
        }
    }

    public static Move findBestMove(int[,] board)
    {
        int bestVal = -1000;
        Move bestMove = new Move();
        bestMove.row = -1;
        bestMove.col = -1;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (board[i, j] == 0)
                {
                    board[i, j] = player;

                    int moveVal = minimax(board, 0, false);

                    board[i, j] = 0;

                    if (moveVal > bestVal)
                    {
                        bestMove.row = i;
                        bestMove.col = j;
                        bestVal = moveVal;
                    }
                }
            }
        }
        return bestMove;
    }
}

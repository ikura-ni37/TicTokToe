using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyTicTacToe
{
    //キャラクター番号定義
    public enum CharacterNum
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
    }

    //キャラクター画像格納用クラス
    public class Character
    {
        public Image win;   //勝ち画像格納用Image
        public Image think; //考え中＆引き分け画像格納用Image
        public Image lose;  //負け画像格納用Image

        public void Set(int characterNumber)
        {
            /*  Set関数
             * 　（説明）キャラクター番号に対応するwin,think,lose画像を格納する
             * 　（引数）キャラクター番号（int型）
             * 　（戻り値）なし
             */

            switch (characterNumber)
            {
                case (int)CharacterNum.A:
                    win = MyTicTacToe.Properties.Resources.A_win;
                    lose = MyTicTacToe.Properties.Resources.A_lose;
                    think = MyTicTacToe.Properties.Resources.A_think;
                    break;

                case (int)CharacterNum.B:
                    win = MyTicTacToe.Properties.Resources.B_win;
                    lose = MyTicTacToe.Properties.Resources.B_lose;
                    think = MyTicTacToe.Properties.Resources.B_think;
                    break;

                case (int)CharacterNum.C:
                    win = MyTicTacToe.Properties.Resources.C_win;
                    lose = MyTicTacToe.Properties.Resources.C_lose;
                    think = MyTicTacToe.Properties.Resources.C_think;
                    break;

                case (int)CharacterNum.D:
                    win = MyTicTacToe.Properties.Resources.D_win;
                    lose = MyTicTacToe.Properties.Resources.D_lose;
                    think = MyTicTacToe.Properties.Resources.D_think;
                    break;

                case (int)CharacterNum.E:
                    win = MyTicTacToe.Properties.Resources.E_win;
                    lose = MyTicTacToe.Properties.Resources.E_lose;
                    think = MyTicTacToe.Properties.Resources.E_think;
                    break;

                case (int)CharacterNum.F:
                    win = MyTicTacToe.Properties.Resources.F_win;
                    lose = MyTicTacToe.Properties.Resources.F_lose;
                    think = MyTicTacToe.Properties.Resources.F_think;
                    break;
            }
            
        }
    }

    
}

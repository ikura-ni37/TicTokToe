using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTicTacToe
{
    /*ゲームデータ格納用GameDataクラス*/
    public class GameData
    {
        public string player1Name;  //player1名格納用
        public string player2Name;  //player2名格納用
        public int player1Character;//player1キャラクター番号格納用
        public int player2Character;//player2キャラクター番号格納用
        public decimal roundTimes;  //round数格納用
    }
}

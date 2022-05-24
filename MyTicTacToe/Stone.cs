using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTicTacToe
{
    /*〇×pictureBox用クラス*/
    public class Stone : PictureBox
    {
        //行
        public int Colum
        {
            protected set;
            get;
        } = 0;
        //列
        public int Row
        {
            protected set;
            get;
        } = 0;

        //コンストラクタ
        public Stone(int colum, int row)
        {
            Colum = colum;
            Row = row;

            Click += Stone_Click;
        }

        //クリックイベント用
        public delegate void StoneClickHandler(int x, int y);
        public event StoneClickHandler StoneClick;
        private void Stone_Click(object sender, EventArgs e)
        {
            StoneClick?.Invoke(Colum, Row);
        }
    }
}

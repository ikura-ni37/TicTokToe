/*fastModeフォーム
 *  ファストモードを選択した場合このフォームに遷移する
 *
 * (説明)
 *  スタートボタンを押すことでゲーム開始，タイムリミットを選択できる．
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTT;

namespace MyTicTacToe
{
    public partial class FastMode : Form
    {

        private StartWindow startwindowInstance;    //StartWindowデータ移行用インスタンス

        //TicTacToe,Player,GameDataクラスオブジェクトの作成
        internal TicTacToe _ttt = new TicTacToe();
        internal List<Plugin> _player = new List<Plugin>();
        internal GameData _data = new GameData();

        //Player1,2用CharacterObjectの作成
        internal Character player1 = new Character();
        internal Character player2 = new Character();

        //勝利数格納用変数
        int player1winNum = 0;
        int player2winNum = 0;
        //ラウンド数用変数
        decimal round = 1;
        //画像反転用Image
        Image buf;

        //Formのコンストラクタ
        public FastMode()
        {
            /*StartWindowフォームからデータを移行*/
            startwindowInstance = StartWindow.StartWindowInstance;
            _ttt = startwindowInstance._ttt;            //TicTacToeクラスオブジェクトの移行
            _player = startwindowInstance._player;      //Playerクラスオブジェクトの移行
            _data = startwindowInstance._data;          //GameDataクラスオブジェクトの移行

            /*フォームの作成*/
            InitializeComponent();

        }

        private void FastMode_Load(object sender, EventArgs e)
        {
            /*キャラクター設定*/
            player1.Set(startwindowInstance._data.player1Character);    //player1
            player2.Set(startwindowInstance._data.player2Character);    //player2

            /*フォームデータ書き込み*/
            label_player1name.Text = _data.player1Name;                 //player1の名前
            label_player2name.Text = _data.player2Name;                   //制限時間初期設定(無限)

            pictureBox_player1.Image = player1.think;                   //player1初期画像
            buf = (Image)player2.think.Clone();                         //player2初期画像（反転処理コミ）
            buf.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox_player2.Image = buf;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /*  Botton1_Click関数
            * 　説明）startボタンを押された時の処理を行う
            *   引数）なし
            *   戻り値）なし
            */

            button_start.Enabled = false;   /*startボタンの無効化*/
            round = 1;                      /*roundの初期化*/

            /*TextBoxの追加"[player1名]vs[player2名]"*/
            textBox_result.AppendText(_data.player1Name + "vs" + _data.player2Name + Environment.NewLine);

            /*試合数分ゲームを行う*/
            while (_data.roundTimes >= round)
            {
                /*TextBoxの追加"対戦開始"*/
                textBox_result.AppendText("対戦開始" + Environment.NewLine);
                /*試合開始*/
                Battle();
                /*結果表示*/
                ShowResult();
                round++;            //round数の加算
            }
            /*終了処理*/
            finish();
            /*startボタンの有効化*/
            button_start.Enabled = true;
        }

        private void Battle()
        {
            /*  Battle関数
            * 　説明）〇×ゲームの進行を行う関数，Startボタンを押されると開始する
            *   引数）なし  
            *   戻り値）なし
            */

            /*ゲームの初期化*/
            _ttt.Init();
            do
            {
                /*プラグインを利用して〇×を置く*/
                _ttt.Set(_player[(int)_ttt.Player - 1].MyTurn(_ttt.GetBoard()));

            } while (_ttt.Judge == JUDGE.None); //決着がつかない場合繰り返す

        }

        private void ShowResult()
        {            
            /*  ShowResult関数
             * 　説明）〇×ゲームの結果を表示する関数
             *   引数）なし  
             *   戻り値）なし
             */

            string playername = "";  //勝者名格納用string型変数

            string msg = "";      //結果表示メッセージ格納用string型変数

            switch (_ttt.Judge)
            {
                //勝ち
                case JUDGE.WIN:
                    msg = $"win =>";
                    break;
                //引き分け
                case JUDGE.DRAW:
                    msg = $"引き分け";
                    break;
                //反則負け
                case JUDGE.OUT_OF_RANGE:
                    msg = $"lose（out of range  win=>";
                    break;
                //
                case JUDGE.OVERLAP:
                    msg = $"lose（overlap)  win=>";
                    break;
            }

            if (_ttt.Judge != JUDGE.DRAW)
            {
                /* 引き分けでなかった場合の処理
                *  1.勝者・敗者の名前をplayernameに格納
                *  2.勝者の勝利数を加算
                *  3.勝者，敗者の画像を変更
                */

                //プレーヤー1で結果が決まった場合
                if (((int)_ttt.Player == 1 && _ttt.Judge == JUDGE.WIN)
                   || ((int)_ttt.Player == 2 && (_ttt.Judge == JUDGE.OVERLAP || _ttt.Judge == JUDGE.OUT_OF_RANGE)))
                {
                    //処理１
                    playername = _data.player1Name;
                    //処理２
                    player1winNum++;
                    //処理３
                    pictureBox_player1.Image = player1.win;
                    buf = (Image)player2.lose.Clone();
                    buf.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pictureBox_player2.Image = buf;
                }
                else //プレーヤー２で結果が決まった場合
                {
                    //処理１
                    playername = _data.player2Name;
                    //処理２
                    player2winNum++;
                    //処理３
                    pictureBox_player1.Image = player1.lose;
                    buf = (Image)player2.win.Clone();
                    buf.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pictureBox_player2.Image = buf;
                }
                /*勝敗を決めたプレーヤー名をメッセージに格納*/
                msg += playername;
            }

            /*結果の表示*/
            textBox_result.AppendText(msg + Environment.NewLine + "---------" + Environment.NewLine);//TextBoxの追加
            label_winNum1.Text = player1winNum.ToString();      //それぞれの勝ち数，負け数の表示
            label_losNum2.Text = player1winNum.ToString();
            label1_winNum2.Text = player2winNum.ToString();
            label_losNum1.Text = player2winNum.ToString();

        }

        private void finish()
        {
            /*  finish関数
            * 　説明）ゲーム終了時の処理を行う
            * 　      1.result(label)に勝者名を表示
            * 　      2.プレーヤー画像の更新
            *   引数）なし
            *   戻り値）なし
            */

            /*TextBoxの追加*/
            textBox_result.AppendText("result" + Environment.NewLine +"=============" + Environment.NewLine);

            /*player1が勝った場合*/
            if (player2winNum < player1winNum)
            {
                //処理１
                textBox_result.AppendText("Winner" + _data.player1Name + Environment.NewLine);
                //処理２
                pictureBox_player1.Image = player1.win;
                buf = (Image)player2.lose.Clone();
                buf.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox_player2.Image = buf;

            }
            /*player2が勝った場合*/
            else if (player2winNum > player1winNum)
            {
                //処理１
                textBox_result.AppendText("Winner" + _data.player2Name + Environment.NewLine);
                //処理２
                pictureBox_player1.Image = player1.lose;
                buf = (Image)player2.win.Clone();
                buf.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox_player2.Image = buf;
            }
            /*引き分けの場合*/
            else
            {
                //処理１
                textBox_result.AppendText("Draw" + Environment.NewLine);
                //処理２
                pictureBox_player1.Image = player1.think;
                buf = (Image)player2.think.Clone();
                buf.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox_player2.Image = buf;

            }
        }

    }
}

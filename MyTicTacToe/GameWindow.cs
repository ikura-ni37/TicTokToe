/*GameWindowフォーム
 *  ファストモードを選択しなかった場合このフォームに遷移する
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TTT;

namespace MyTicTacToe
{
    public partial class GameWindow : Form

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
        //クリック用bool変数
        bool botton = false;
        //ラウンド数用変数
        decimal round = 1;
        //画像反転用Image
        Image buf;

        
        //ゲーム盤配置用変数（左上座標）
        Point leftTopPoint = new Point(300, 100);
        //〇×位置格納用stoneオブジェクト
        Stone[,] StonePosition = new Stone[3, 3];
        //順番付き〇格納配列
        Image[] maruArray = new Image[] { MyTicTacToe.Properties.Resources.maru1,
                                        　MyTicTacToe.Properties.Resources.maru2,
                                          MyTicTacToe.Properties.Resources.maru3 };
        //順番付き×格納配列
        Image[] batsuArray = new Image[] { MyTicTacToe.Properties.Resources.batsu1,
                                           MyTicTacToe.Properties.Resources.batsu2,
                                           MyTicTacToe.Properties.Resources.batsu3 };

        //Formのコンストラクタ
        public GameWindow()
        {
            /*StartWindowフォームからデータを移行*/
            startwindowInstance = StartWindow.StartWindowInstance; 
            _ttt = startwindowInstance._ttt;            //TicTacToeクラスオブジェクトの移行
            _player = startwindowInstance._player;      //Playerクラスオブジェクトの移行
            _data = startwindowInstance._data;          //GameDataクラスオブジェクトの移行
            
            /*フォームの作成*/
            InitializeComponent();
            

        }

        //フォーム読み込み時
        private void GameWindow_Load(object sender, EventArgs e)
        {
            /*〇×ゲーム盤作成*/
            CreatePictureBoxes();

            /*キャラクター設定*/
            player1.Set(startwindowInstance._data.player1Character);    //player1
            player2.Set(startwindowInstance._data.player2Character);    //player2

            /*フォームデータ書き込み*/
            label_player1name.Text = _data.player1Name;                 //player1の名前
            label_player2name.Text = _data.player2Name;                 //player2の名前
            comboBox_timelimit.SelectedIndex = 3;                       //制限時間初期設定(無限)

            pictureBox_player1.Image = player1.think;                   //player1初期画像
            buf = (Image)player2.think.Clone();                         //player2初期画像（反転処理コミ）
            buf.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox_player2.Image = buf;                             
        }

        //〇×ゲーム盤作成
        void CreatePictureBoxes()
        {
            /*  CreatePictureBox関数
             * 　説明）〇×ゲーム用盤(Picturebox)の作成
             * 　      stoneクラスを利用して3*3のPictureBoxを作成する
             *   引数）なし  
             *   戻り値）なし
             */

            for (int row = 0; row < 3; row++)
            {
                for (int colum = 0; colum < 3; colum++)
                {
                    //Stoneクラスオブジェクトの作成と初期情報設定
                    Stone stone = new Stone(colum, row);
                    stone.Parent = this;
                    stone.Size = new Size(100, 100);
                    stone.BorderStyle = BorderStyle.FixedSingle;
                    stone.Location = new Point(leftTopPoint.X + row * 100, leftTopPoint.Y + colum * 100);
                    stone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    StonePosition[colum, row] = stone;
                    stone.StoneClick += Box_PictureBoxExClick;
                    stone.BackColor = Color.AliceBlue;
                    stone.Enabled = false;
                }
            }
        }

       
        /// <summary>
        /// 対戦
        /// </summary>
        private void Battle()
        {
            /*  Battle関数
             * 　説明）〇×ゲームの進行を行う関数，Startボタンを押されると開始する
             *   引数）なし  
             *   戻り値）なし
             */


            /*ゲームの初期化*/
            _ttt.Init();
            /*resut(label)の非表示*/
            result.Visible = false;

            ShowBoard();
            do
            {
                /*StatusLabelの更新（"{プレーヤー名} Turn"）*/
                toolStripStatusLabel1.Text = "player" + (int)_ttt.Player + "Turn";

                /*プレーヤーが人間だった場合*/
                if (_player[(int)_ttt.Player - 1].IsHuman)
                {
                    /*ゲーム版のクリックイベントの有効化*/
                    Picture_box_Click();
                    while (botton == true)//フォーム動作用
                    {
                        Application.DoEvents();
                    }
                    /*ゲーム版のクリックイベントの無効化*/
                    Picture_box_NotClick();
                    /*ボードの更新*/
                    ShowBoard();

                    botton = true;
                }
                else if (!_player[(int)_ttt.Player - 1].IsHuman)/*プレーヤーが人間でなかった場合*/
                {
                    /*プラグインを利用して〇×を置く*/
                    _ttt.Set(_player[(int)_ttt.Player - 1].MyTurn(_ttt.GetBoard()));
                    ShowBoard();
                }

            } while (_ttt.Judge == JUDGE.None); //決着がつかない場合繰り返す

        }

        ///// <summary>
        ///// 結果表示
        ///// </summary>
        private void ShowResult()
        {
            /*  ShowResult関数
             * 　説明）〇×ゲームの結果を表示する関数
             *   引数）なし  
             *   戻り値）なし
             */

            string playername ="";  //勝者名格納用string型変数

            
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
                if (((int)_ttt.Player == 1&&_ttt.Judge ==JUDGE.WIN)
                   || ((int)_ttt.Player == 2 && (_ttt.Judge == JUDGE.OVERLAP||_ttt.Judge == JUDGE.OUT_OF_RANGE)))
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
            toolStripStatusLabel1.Text = msg;                   //stauslabelの更新
            result.Text = msg;                                  //result(label)の更新
            result.Visible = true;
            label_winNum1.Text = player1winNum.ToString();      //それぞれの勝ち数，負け数の表示
            label_losNum2.Text = player1winNum.ToString();
            label1_winNum2.Text = player2winNum.ToString();
            label_losNum1.Text = player2winNum.ToString();

        }

        private void Box_PictureBoxExClick(int x, int y)
        {
            /*  Box_PictureBoxExClick関数
            * 　説明）〇×ゲーム盤のクリック処理用関数，クリックされた位置に〇×を置く
            *   引数）クリックされた位置のPictureBoxの位置
            *   戻り値）なし
            */

            /*クリックした場所に〇×を置く*/
            _ttt.Set(x * _ttt.BOARD_COLS + y);
            botton = false;
        }

        void ShowBoard()
        {
            /*  Showboard関数
            * 　説明）〇×ゲーム盤表示関数，通常モードの場合は無印〇×，初心者モードの場合は順番付きの〇×を表示
            *   引数）なし
            *   戻り値）なし
            */

            var flip = _ttt.Player == PLAYER.Second ? -1 : 1; //〇×の順番数字用パラメータ

            for (var row = 0; row < 3; row++)
            {
                for (var colum = 0; colum < 3; colum++)
                {
                    /*盤を初期化*/
                    StonePosition[row, colum].Refresh();                            
                    var pos = row * _ttt.BOARD_COLS + colum;                        //盤の位置を示す変数
                    var pIdx = _ttt.Board[pos] * flip > 0 ? PLAYER.First :          
                        _ttt.Board[pos] * flip < 0 ? PLAYER.Second : PLAYER.None;   //〇×を判別する変数（〇:１～３,×:－１～－３）

                    /*初心者モードの場合（順番付き〇×の利用）*/
                    if (checkBox_beginner.Checked)
                    {
                        /*〇×判別*/
                        switch ((int)pIdx)
                        {
                            case 0: /*置かれていない場合*/
                                StonePosition[row, colum].Image = null;
                                StonePosition[row, colum].Update();
                                break;
                            case 1: /*〇の場合*/
                                StonePosition[row, colum].Image = maruArray[Math.Abs(_ttt.Board[pos]) - 1];
                                StonePosition[row, colum].Update();
                                break;
                            case 2: /*×の場合*/
                                StonePosition[row, colum].Image = batsuArray[Math.Abs(_ttt.Board[pos]) - 1];
                                StonePosition[row, colum].Update();
                                break;


                        }
                    }
                    /*通常モードの場合（無印〇×の利用）*/
                    else
                    {
                        /*〇×判別*/
                        switch ((int)pIdx)
                        {
                            case 0: /*置かれていない場合*/
                                StonePosition[row, colum].Image = null;
                                StonePosition[row, colum].Update();
                                break;
                            case 1: /*〇の場合*/
                                StonePosition[row, colum].Image = MyTicTacToe.Properties.Resources.maru;
                                StonePosition[row, colum].Update();
                                break;
                            case 2: /*×の場合*/
                                StonePosition[row, colum].Image = MyTicTacToe.Properties.Resources.batsu;
                                StonePosition[row, colum].Update();
                                break;
                        }
                    }
                    
                }
            }
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

            /*statuslabelの更新*/
            toolStripStatusLabel1.Text = "GameSet";

            /*player1が勝った場合*/
            if (player2winNum < player1winNum)
            {
                //処理１
                result.Text = "Winner" + _data.player1Name;
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
                result.Text="Winner" + _data.player2Name;
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
                result.Text = "Draw";
                //処理２
                pictureBox_player1.Image = player1.think;
                buf = (Image)player2.think.Clone();
                buf.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox_player2.Image = buf;
            }

        }

        private async void Button_start_Click(object sender, EventArgs e)
        {
            /*  Botton_start_Click関数
            * 　説明）startボタンを押された時の処理を行う
            *   引数）なし
            *   戻り値）なし
            */

            button_start.Enabled = false;   /*startボタンの無効化*/
            round = 1;                      /*roundの初期化*/

            /*statusLabelの更新"[player1名]vs[player2名]"*/
            toolStripStatusLabel1.Text=_data.player1Name + "vs" + _data.player2Name;

            /*試合数分ゲームを行う*/
            while (_data.roundTimes >= round)
            {
                /*round数をlabel_roundNum(label)に表示*/
                label_roundNum.Text = round.ToString();
                /*試合開始*/
                Battle();
                /*結果表示*/
                ShowResult();
                round++;            //round数の加算

                await Task.Delay(3000);
            }
            /*終了処理*/
            finish();
            /*startボタンの有効化*/
            button_start.Enabled = true;
        }

        private void Picture_box_NotClick()
        {
            /*  Picture_box_NotClick関数
            * 　説明）ゲーム盤のクリックイベントの無効化
            *   引数）なし
            *   戻り値）なし
            */

            for (var row = 0; row < 3; row++)
            {
                for (var colum = 0; colum < 3; colum++)
                {
                    StonePosition[row, colum].Enabled = false;
                }
            }
        }

        private void Picture_box_Click()
        {
            /*  Picture_box_Click関数
            * 　説明）ゲーム盤のクリックイベントの無効化
            *   引数）なし
            *   戻り値）なし
            */

            for (var row = 0; row < 3; row++)
            {
                for (var colum = 0; colum < 3; colum++)
                {
                    StonePosition[row, colum].Enabled = true;
                }
            }
        }

        private void CheckBox_beginner_CheckedChanged(object sender, EventArgs e)
        {
            /*  CheckBox_beginner_CheckedChanged関数
            * 　説明）初心者モード，通常モードの変更を適用後，盤の表示
            *   引数）なし
            *   戻り値）なし
            */
            ShowBoard();
        }


    }
}

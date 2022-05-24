/*StartWindowフォーム
 *  最初に開くフォーム
 * (説明)
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTT;


namespace MyTicTacToe
{
    public partial class StartWindow : Form
    {
        private static StartWindow _startwindowInstance;

        //TicTacToe,Plugin,Player,GameDataクラスオブジェクトの作成
        internal TicTacToe _ttt = new TicTacToe();
        internal GameData _data = new GameData();
        internal List<Plugin> _plugins = new List<Plugin>();
        internal List<Plugin> _player = new List<Plugin>();

        //readyボタン用bool変数
        bool readyPlayer1 = false;
        bool readyPlayer2 = false;

        //プラグインファイル格納用string配列
        string[] _pluginFiles;

        //キャラクター番号格納用変数
        int indexPlayer1,indexPlayer2;
        DialogResult result = DialogResult.No;

        /// <summary>
        /// プラグインを読み込む
        /// </summary>
        /// <param name="files"></param>
        /// 
        public StartWindow(string[] pluginFiles) 
        {
            InitializeComponent();
            _startwindowInstance = this;

            _pluginFiles = pluginFiles;

            //プラグインがなかった場合のエラー処理
            if (!LoadPlugin(_pluginFiles))
            {
                MessageBox.Show("NO PLUGIN EXIST", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        //プラグインの読み込み
        private bool LoadPlugin(string[] files)
        {
            foreach (var file in files)
            {
                var plugin = new Plugin();
                if (!plugin.Load(file)) continue;
                _plugins.Add(plugin);
            }
            return _plugins.Count > 0;
        }

        //StartWindow用インスタンス
        public static StartWindow StartWindowInstance
        {
            get => _startwindowInstance;
            set => _startwindowInstance = value;
        }

        private void Ready_player1_Click(object sender, EventArgs e)
        {
            /*  Ready_player1_Click関数
            * 　説明）Ready_player2ボタンが押された場合の処理を行う
            *   引数）なし
            *   戻り値）なし
            */

            /*player１のキャラクター番号を格納（ComboBoxより）*/
            indexPlayer1 = comboBox_player1.SelectedIndex;
            readyPlayer1 = true;　　//ボタン用変数true

            //Ready_player２ボタンが押されていた場合
            if (readyPlayer2 == true)
            {
                /*statuslabelの更新*/
                toolStripStatusLabel1.Text = "Pless Start Botton";
                /*startボタンの有効化*/
                botton_Start.Enabled = true;
            }
        }

        private void Ready_player2_Click(object sender, EventArgs e)
        {
            /*  Ready_player2_Click関数
            * 　説明）Ready_player2ボタンが押された場合の処理を行う
            *   引数）なし
            *   戻り値）なし
            */
            
            /*player2のキャラクター番号を格納（ComboBoxより）*/
            indexPlayer2 = comboBox_player2.SelectedIndex;
            readyPlayer2 = true;    //ボタン用変数true

            //Ready_player１ボタンが押されていた場合
            if (readyPlayer1 == true)
            {
                /*statuslabelの更新*/
                toolStripStatusLabel1.Text = "Pless Start Botton";
                /*startボタンの有効化*/
                botton_Start.Enabled = true;
            }

        }

        //フォーム読み込み時
        private void StartWindow_Load(object sender, EventArgs e)
        {
            /*Pruginの名前をコンボボックスに格納*/
            for (var i = 0; i < _plugins.Count; i++)
            {
                comboBox_player1.Items.Add(_plugins[i].Name);
                comboBox_player2.Items.Add(_plugins[i].Name);
            }

            /*コンボボックスの値を0で初期化*/
            comboBox_player1.SelectedIndex = 0;
            comboBox_player2.SelectedIndex = 0;
            comboBox_player1character.SelectedIndex = 0;
            comboBox_player2character.SelectedIndex = 0;

            /*PictureBoxを初期化（初期画像：Anthony）*/
            pictureBox_player1character.Image = MyTicTacToe.Properties.Resources.A;
            pictureBox_player2character.Image = MyTicTacToe.Properties.Resources.A;

            toolStripStatusLabel1.Text = "Get Ready for Playing!!";
        }

        private void ComboBox_player1character_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*  ComboBox_player1character_SelectedIndexChanged_1関数
           * 　説明）ComboBox_player1characterの値が変わった場合画像の変更を行う
           *   引数）なし
           *   戻り値）なし
           */

            switch (comboBox_player1character.SelectedIndex) {
                case 0:
                    pictureBox_player1character.Image = MyTicTacToe.Properties.Resources.A;
                    break;
                case 1:
                    pictureBox_player1character.Image = MyTicTacToe.Properties.Resources.B;
                    break;
                case 2:
                    pictureBox_player1character.Image = MyTicTacToe.Properties.Resources.C;
                    break;
                case 3:
                    pictureBox_player1character.Image = MyTicTacToe.Properties.Resources.D;
                    break;
                case 4:
                    pictureBox_player1character.Image = MyTicTacToe.Properties.Resources.E;
                    break;
                case 5:
                    pictureBox_player1character.Image = MyTicTacToe.Properties.Resources.F;
                    break;
            }

        }

        private void ComboBox_player2character_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*  ComboBox_player2character_SelectedIndexChanged_1関数
            * 　説明）ComboBox_player2characterの値が変わった場合画像の変更を行う
            *   引数）なし
            *   戻り値）なし
            */

            switch (comboBox_player2character.SelectedIndex)
            {
                case 0:
                    pictureBox_player2character.Image = MyTicTacToe.Properties.Resources.A;
                    break;
                case 1:
                    pictureBox_player2character.Image = MyTicTacToe.Properties.Resources.B;
                    break;
                case 2:
                    pictureBox_player2character.Image = MyTicTacToe.Properties.Resources.C;
                    break;
                case 3:
                    pictureBox_player2character.Image = MyTicTacToe.Properties.Resources.D;
                    break;
                case 4:
                    pictureBox_player2character.Image = MyTicTacToe.Properties.Resources.E;
                    break;
                case 5:
                    pictureBox_player2character.Image = MyTicTacToe.Properties.Resources.F;
                    break;
            }
        }

        private void Botton_Start_Click(object sender, EventArgs e)
        {
            /*  Botton_start_Click関数
            * 　説明）startボタンを押された時の処理を行う
            *   引数）なし
            *   戻り値）なし
            */

            /*_playerオブジェクトにpluginの追加*/
            _player.Add(_plugins[indexPlayer1]);
            _player.Add(_plugins[indexPlayer2]);

            /*_dataオブジェクトにplayernameの格納（TextBoxより）*/
            _data.player1Name = textBox_playername1.Text;
            _data.player2Name = textBox_playername2.Text;

            /*_dataオブジェクトにキャラクター番号の格納（ComboBoxより）*/
            _data.player1Character = comboBox_player1character.SelectedIndex;   
            _data.player2Character = comboBox_player2character.SelectedIndex;

            /*_dataオブジェクトにラウンド数の格納（numericUpDownより）*/
            _data.roundTimes = numericUpDown_round.Value;

            /*両方とも人間でない場合，ファストモード選択用ダイアログを表示*/
            if (!(_player[0].IsHuman || _player[1].IsHuman))
            {
                /*ファストモード選択用ダイアログ
                 *      Yes ->ファストモードへ
                 *      No  ->通常モードへ
                 */
                result= MessageBox.Show(this, "Do you want fast mode","SelectMode",  MessageBoxButtons.YesNo);
            }
            
            
            /*フォームの非表示*/
            this.Visible = false;

            //fastモード有効の場合
            if(result == DialogResult.Yes)
            {
                using (var fastWindow = new FastMode())
                {
                    //fastWindowの表示
                    fastWindow.ShowDialog();
                }
            }
            //fastモード無効の場合
            else
            {
                using (var gameWindow = new GameWindow())
                {
                    //GameWindowの表示
                    gameWindow.ShowDialog();
                }
            }

            /*終了後フォームを閉じる*/
            this.Close();
        }
    }
}

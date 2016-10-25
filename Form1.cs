using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IS;
using System.Data.OleDb;

namespace InterfaceASPPR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Прорисовка вкладок с ГОСТ...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            InterfaceSettings.Drawing(tabContGlav, e);
        }
        /// <summary>
        /// Прорисовка вкладок с ГОСТ...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl6_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            InterfaceSettings.Drawing(tabControl6, e);
        }
        /// <summary>
        /// Прорисовка вкладок с ГОСТ...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl7_DrawItem(object sender, DrawItemEventArgs e)
        {
            InterfaceSettings.Drawing(tabControl7, e);
        }

        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //ширина технических показателей // основная информация
            panel6.Width = tabPage7.Width / 3 * 2;
            groupBox2.Width = tabPage7.Width / 5;
            groupBox3.Width = tabPage7.Width / 5;
            groupBox4.Width = tabPage7.Width / 5;
            groupBox5.Width = tabPage7.Width / 5;
            groupBox6.Width = tabPage7.Width / 5;

            //высота технических показателей // основная информация
            panel1.Height = tabPage7.Height / 9;
            panel2.Height = tabPage7.Height / 9;
            panel3.Height = tabPage7.Height / 9;
            panel5.Height = tabPage7.Height / 9 * 2;
            panel9.Height = tabPage7.Height / 9;
            groupBox1.Height = tabPage7.Height / 9;

            //ширина класса и группы детали

            groupBox24.Width = panel6.Width/3;
        }

        private void groupBox24_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //пример запуска вид детали
            List<string> lst = new List<string>();
            lst.Add("122001");
            lst.Add("122009");
            lst.Add("129004");
            lst.Add("129008");
            lst.Add("129010");
            //пример запуска габаритов
            InterfaceASPPR.Froms.Econom.Expert.GabDet GabD = new InterfaceASPPR.Froms.Econom.Expert.GabDet(lst, "129008", 1);
            tabExpGabDet.Controls.Add(GabD);
            GabD.Dock = DockStyle.Fill;
            //пример запуска вида детали
            InterfaceASPPR.Froms.Econom.Expert.VidDetal VidD = new InterfaceASPPR.Froms.Econom.Expert.VidDetal(lst, "129008", 1);
            tabExpVD.Controls.Add(VidD);
            VidD.Dock = DockStyle.Fill;
            //пример запуска материал
            InterfaceASPPR.Froms.Econom.Expert.MatDet MatD = new InterfaceASPPR.Froms.Econom.Expert.MatDet(lst, "129008", 1);
            tabExpMat.Controls.Add(MatD);
            MatD.Dock = DockStyle.Fill;
            //пример запуска точности обработки
            InterfaceASPPR.Froms.Econom.Expert.TochnObrab TochnObExp = new InterfaceASPPR.Froms.Econom.Expert.TochnObrab(lst, "129008", 1);
            tabExpTochOb.Controls.Add(TochnObExp);
            TochnObExp.Dock = DockStyle.Fill;
            //пример запуска схемы базирования
            InterfaceASPPR.Froms.Econom.Expert.ShBasir ShBaz = new InterfaceASPPR.Froms.Econom.Expert.ShBasir(lst, "129008", 1);
            tabExpShemBaz.Controls.Add(ShBaz);
            ShBaz.Dock = DockStyle.Fill;
            //пример запуска технолог. операц.
            InterfaceASPPR.Froms.Econom.Expert.VidTehnOb TehObr = new InterfaceASPPR.Froms.Econom.Expert.VidTehnOb(lst, "129008", 1);
            tabExpVidTehObr.Controls.Add(TehObr);
            TehObr.Dock = DockStyle.Fill;
            //пример поверхности двойной кривизны 
            InterfaceASPPR.Froms.Econom.Expert.PovDK PovDvKrExp = new InterfaceASPPR.Froms.Econom.Expert.PovDK(lst, "129008", 1);
            tabExpPovDvKr.Controls.Add(PovDvKrExp);
            PovDvKrExp.Dock = DockStyle.Fill;
            //пример оборудования
            InterfaceASPPR.Froms.Econom.Expert.Oborud Obor = new InterfaceASPPR.Froms.Econom.Expert.Oborud(lst, "129008", 1);
            tabExpObor.Controls.Add(Obor);
            Obor.Dock = DockStyle.Fill;


            //Свертка Саати
            InterfaceASPPR.Froms.Econom.Svertka.Saaty Saty = new InterfaceASPPR.Froms.Econom.Svertka.Saaty();
            tabExpSaaty.Controls.Add(Saty);
            Saty.Dock = DockStyle.Fill;

            //Свертка Ногина
            InterfaceASPPR.Froms.Econom.Svertka.Nogin SvNogin = new InterfaceASPPR.Froms.Econom.Svertka.Nogin();
            tabExpNogin.Controls.Add(SvNogin);
            SvNogin.Dock = DockStyle.Fill;

            //Свертка Линейная свертка
            InterfaceASPPR.Froms.Econom.Svertka.SvLin LinSvert = new InterfaceASPPR.Froms.Econom.Svertka.SvLin();
            tabExpLin.Controls.Add(LinSvert);
            LinSvert.Dock = DockStyle.Fill;

            //Свертка Мультипликативная свертка
            InterfaceASPPR.Froms.Econom.Svertka.SvMult MultSvert = new InterfaceASPPR.Froms.Econom.Svertka.SvMult();
            tabExpMult.Controls.Add(MultSvert);
            MultSvert.Dock = DockStyle.Fill;

            //Свертка Идеальная точка
            InterfaceASPPR.Froms.Econom.Svertka.SvId IdSvert = new InterfaceASPPR.Froms.Econom.Svertka.SvId();
            tabExpIdeal.Controls.Add(IdSvert);
            IdSvert.Dock = DockStyle.Fill;

            //Свертка Рандомизированная стратегия
            InterfaceASPPR.Froms.Econom.Svertka.SvRand RandSvert = new InterfaceASPPR.Froms.Econom.Svertka.SvRand();
            tabExpRand.Controls.Add(RandSvert);
            RandSvert.Dock = DockStyle.Fill;

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView9_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void groupBox41_Enter(object sender, EventArgs e)
        {

        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox101_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button70_Click(object sender, EventArgs e)
        {
            SQLOracle.BuildConnectionString("ASPPR", "ASPPR", "BASEEOI", "192.168.1.170", "1521");
            MessageBox.Show(SQLOracle.SelectWithOneParam("Select P1 from AS_GOST_25347_82_P_T1 where ID_GOST_82_P_T1 = :ID_GOST_82_P_T1",":ID_GOST_82_P_T1","2"));
            


  //          dataGridView1.DataSource = SQLOracle.SelectGetDS("SELECT " +
  //" ID_GOST_82_P_T1 AS ГОСТ, INTERVAL_RAZMEROV, NAME_TABLE,  " +
  //" NUMBER_TABLE, P1, P10,  " +
  //" P11, P12, P13,  " +
  //" P14, P15, P16,  " +
  //" P17, P18, P19,  " +
  //" P2, P20, P21,  " +
  //" P22, P23, P24,  " +
  //" P25, P26, P27,  " +
  //" P28, P29, P3,  " +
  //" P30, P31, P32,  " +
  //" P33, P34, P35,  " +
  //" P36, P37, P38,  " +
  //" P39, P4, P40,  " +
  //" P41, P42, P43,  " +
  //" P44, P45, P46,  " +
  //" P47, P48, P49,  " +
  //" P5, P50, P51,  " +
  //" P52, P53, P54,  " +
  //" P55, P56, P57,  " +
  //" P6, P7, P8,  " +
  //" P9 " +
  //" FROM AS_GOST_25347_82_P_T1").Tables[0];
           

        }

    

        private void button71_Click(object sender, EventArgs e)
        {
            SQLOracle.BuildConnectionString("ASPPR", "ASPPR", "BASEEOI", "192.168.1.170", "1521");

            dataGridView1.DataSource = SQLOracle.SelectGetDS(" SELECT " +
              " NOM_TABLE, IDSTROKI, NAME_IMAGE, " +
              " OBOZN_RAZMER, RAZMFROM, RAZMTO, " +
              " OTFROM, OTTO, NAME_TABLE " +
              " FROM ASPPR.AS_OST_100022_80_1_4_6_11 ").Tables[0];
            
        }

        private void button75_Click(object sender, EventArgs e)
        {

             
        }

        private void tabContExpOcen_DrawItem(object sender, DrawItemEventArgs e)
        {
            InterfaceSettings.Drawing(tabContExpOcen, e);
        }

        private void мультипликативнаяСверткаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabEconom_MouseClick(object sender, MouseEventArgs e)
        {
            //Расчёт НСП и УСП
            InterfaceASPPR.Froms.Econom.SelNSPorUSP.GenPageSel GenPage = new InterfaceASPPR.Froms.Econom.SelNSPorUSP.GenPageSel();
            tabEconom.Controls.Add(GenPage);
            GenPage.Dock = DockStyle.Fill;



        }



       

       

       
                


    }
}
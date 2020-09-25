using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chartlet1.ChartTitle.Text = "Chartlet Winform Demo";
            chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Bar_2D_Aurora_FlatCrystal_Glow_NoBorder;
            chartlet1.Background.Paper = Color.FromArgb(0, 0, 0, 0);

            string cs = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Chartlet.mdb";
            string sql = "Select Season,sum(Sales) as Sales,sum(Cost) as Cost,sum(Profit) as Profit from Sales group by Season";
            OleDbConnection cn = new OleDbConnection(cs);
            OleDbDataAdapter da = new OleDbDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Jesy");
            chartlet1.BindChartData(ds);
            //chartlet1.BindChartData(ds.Tables[0]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //动态修改外观
            switch (comboBox1.SelectedIndex)
            {
                case 0: chartlet1.AppearanceStyle=FanG.Chartlet.AppearanceStyles.Bar_2D_Aurora_FlatCrystal_Glow_NoBorder; break;
                case 1: chartlet1.AppearanceStyle=FanG.Chartlet.AppearanceStyles.Line_3D_Aurora_FlatCrystalSquare_NoGlow_NoBorder; break;
                case 2: chartlet1.AppearanceStyle=FanG.Chartlet.AppearanceStyles.Pie_3D_Aurora_FlatCrystal_NoGlow_NoBorder; break;
                default: ; break;
            }
            //每次希望修改属性后立即重绘图形就需要调用 Refresh()方法
            chartlet1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartlet1.Width = 600;
            chartlet1.Height = 400;
            chartlet1.Refresh();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //类似于所有控件，需要在推出前嗲用Dispose()方法来释放资源
            chartlet1.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chartlet1.Width = 400;
            chartlet1.Height = 300;
            chartlet1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //将自定义颜色赋给内置的颜色数组
            chartlet1.Aurora[0] = Color.Black;
            chartlet1.Aurora[1] = Color.BlueViolet;
            //颜色数组总共有12个颜色元素 。。。Aurora[11]

            chartlet1.Refresh();
        }
    }
}

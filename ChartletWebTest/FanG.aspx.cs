using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.OleDb;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;

public partial class FGS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cs = WebConfigurationManager.ConnectionStrings["Chartlet"].ConnectionString + Server.MapPath("App_data\\Chartlet.mdb");
        string sql = "Select Season,Sales,Profit,Cost,(Sales-Profit-Cost) as S1 from Sales where user='Jesy' order by Profit DESC";
        OleDbConnection cn = new OleDbConnection(cs);
        OleDbDataAdapter da = new OleDbDataAdapter(sql, cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Jesy");

        string sql2 = "select DTime,Sales,Cost from Sales order by Dtime ASC";
        DataSet ds2 = new DataSet();
        da = new OleDbDataAdapter(sql2, cn);
        da.Fill(ds2, "Jesy");

        /*选择外观基调*/
        Chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Trend_2D_Aurora_ThinRound_Glow_NoBorder;
        //调整折线连接点的大小
        Chartlet1.LineConnectionRadius = 6;
        //调整折线宽度
        Chartlet1.Stroke.Width = 2;
        //关闭投影效果
        Chartlet1.Shadow.Enable = false;
        //通过下面一句调整标题的高度
        Chartlet1.ChartTitle.OffsetY = -10;
        //下面一句是TrendChart必须要有的，是TrendChart中最重要的设置(StartTime,EndTime,TimeSpanType,XLabelDisplayFormat)
        //如果你使用TrendChart，但是缺少了这一句，那么系统会提示：Please Set Chartlet.Trend attribute for Trend Chart
        //详细介绍请参看Chartlet.Trend的参考手册
        Chartlet1.Trend = new FanG.TrendAttributes("2009-04-29", "2009-5-11", FanG.Chartlet.TimeSpanTypes.Day, "MM-dd");
        //图表标题
        Chartlet1.ChartTitle.Text = "TrendChart(趋势图)";
        //绑定数据
        Chartlet1.BindChartData(ds2);
        

        /******************************/
        Chartlet2.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Bar_2D_Aurora_FlatCrystal_NoGlow_NoBorder;
        Chartlet2.ColorGuider.Font = new Font("Arial", 9, FontStyle.Italic);
        Chartlet2.ColorGuider.ForeColor = Color.Green;
        Chartlet2.ChartTitle.ForeColor=Color.Green;
        Chartlet2.XLabels.ForeColor=Color.Green;
        Chartlet2.YLabels.ForeColor=Color.Green;
        Chartlet2.Tips.ForeColor=Color.Green;
        Chartlet2.ChartTitle.Text="BaseLine Attribute(基准线属性)";
        Chartlet2.YLabels.ValueFormat="0.";
        //线面设置baseline属性，会产生一条基准线，基准线一下的数据会导致柱子负向增长
        Chartlet2.BaseLineX = 360;
        Chartlet2.BindChartData(ds);

        /*****************************/
        Chartlet3.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Line_2D_StarryNight_ThickRound_Glow_NoBorder;
        Chartlet3.Tips.Font = new Font("Verdana",6, FontStyle.Regular);
        Chartlet3.Tips.ForeColor = Color.Purple;
        Chartlet3.ChartTitle.Font = new Font("Verdana", 12, FontStyle.Regular);
        Chartlet3.YLabels.Font = new Font("Arial", 6);
        Chartlet3.YLabels.UnitFont = new Font("Arial", 6);
        Chartlet3.XLabels.Font = new Font("Arial", 11);
        Chartlet3.XLabels.UnitFont = new Font("Arial", 6);
        Chartlet3.XLabels.RotateAngle = 0;
        Chartlet3.ChartTitle.Text = "自定义颜色、X坐标文字、ColorGuider文字";
        Chartlet3.BaseLineX = 492;
        //使用自定义颜色数组
        //先定义一个自己的颜色数组
        Color[] myColorA = { Color.Black, Color.Blue, Color.Green };
        //在把它复制到你使用的Chartlet颜色数组中，如StarryNight
        myColorA.CopyTo(Chartlet3.StarryNight, 0);
        //折线连接符的大小
        Chartlet3.LineConnectionRadius =8;
        Chartlet3.Stroke.Width = 3;
        Chartlet3.BindChartData(ds);
        //自定义ColorGuider的文字,必须放在BindChartData()后面
        Chartlet3.GroupTitle = new string[] { "CG1", "CG2", "CG3", "CG4", "CG5" };
        //自定义X坐标文字，必须放在BindChartData()后面
        Chartlet3.AxisX = new string[] { "x1", "x2", "x3", "x4", "x5" };


        /****************************/
        Chartlet4.AppearanceStyle = FanG.Chartlet.AppearanceStyles.HBar_2D_Aurora_FlatCrystal_Glow_NoBorder;
        Chartlet4.XLabels.RotateAngle = 0;
        Chartlet4.ChartTitle.Text = "HBar-Pareto (横向柱图-柏拉图)";
        Chartlet4.Fill.TextureEnable = true;
        Chartlet4.BindChartData(ds);
    }
}

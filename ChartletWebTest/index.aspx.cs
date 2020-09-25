using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //请先修改Web.Config里面的数据库连接字符串的.mdb文件的路径

        /***********************************************************/
        //第一步：设置一个属性（只需要从枚举类型中选取就可以了）
        Chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Bar_2D_Aurora_FlatCrystal_Glow_NoBorder;
        
        //可选步骤
        //如果你要改变颜色，请取消下面一行的注释，并可以修改参数的值 0 ～ 12 (预置了12种典型颜色)
        Chartlet1.Fill.ShiftStep = 8;
        Chartlet1.Crystal.Contraction = 0;
        Chartlet1.Shadow.Distance = 2;
        Chartlet1.Shadow.Alpha = 200;

        //第二步：绑定一个数据源
        Chartlet1.BindChartData(SqlDataSource1);

        //好了，运行一下看看，是不是一个很美丽的图表出现了？
        //Chartlet就这么简单
        //更多信息请参看 http://www.Chartlet.cn
        /*☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
         ☆ BindChartData()方法有四个构造函数，支持常见的四种数据源(DataSet,DataTable,DataView,SqlDataSource)
         ☆ BindChartData(DataSet DataSource)
         ☆ BindChartData(DataTable DataSource)
         ☆ BindChartData(DataView DataSource)
         ☆ BindChartData(SqlDataSource DataSource)
        ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆*/
        /**********************************************************/


        //========================================================//
        Chartlet2.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Line_2D_StarryNight_ThickRound_Glow_NoBorder;
        Chartlet2.ChartTitle.Text = "2D Line Chart";
        //在选择了AppearanceType的基础上进行微调
        //Chartlet2.LineWidth = 2;
        Chartlet2.MaxValueY = 1000;
        Chartlet2.BindChartData(SqlDataSource1);


        Chartlet3.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Line_3D_Aurora_FlatCrystalRound_NoGlow_NoBorder;
        /*************在选择了AppearanceType的基础上进行微调****************/
        Chartlet3.Fill.ShiftStep = 7;
        Chartlet3.LineConnectionRadius = 8;
        //对于折线的颜色控制都使用StrokeColor属性（包括3D折线图）
        Chartlet3.Stroke.ShiftStep = 8;
        Chartlet3.Alpha3D = 200;
        Chartlet2.Tips.Show = false;
        //你可以取消注释下面一句，看看另一种效果
        //Chartlet3.Crystal.Direction = FanG.Chartlet.Direction.BottomTop;
        //************上面代码是在AppearanceType的基础上进行微调***********/
        Chartlet3.ChartTitle.Text = "3D Line Chart";
        Chartlet3.BindChartData(SqlDataSource1);


        Chartlet4.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Pie_3D_Aurora_NoCrystal_NoGlow_NoBorder;
        Chartlet4.Fill.ShiftStep = 9;
        Chartlet4.ChartTitle.Text = "3D Pie Chart";
        Chartlet4.BindChartData(SqlDataSource1);
    }
}

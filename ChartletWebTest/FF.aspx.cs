using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;
using System.IO;
using System.Drawing;

public partial class ss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cs = WebConfigurationManager.ConnectionStrings["Chartlet"].ConnectionString + Server.MapPath("App_data\\Chartlet.mdb");
        SqlDataSource1.ConnectionString = cs;

        //设置数值标签的文字样式
        Chartlet1.Tips.ForeColor = Color.Brown;

        Chartlet1.MaxValueY = 1000;
        Chartlet1.Shadow.Radius = 5;
        Chartlet1.ColorGuider.Show = false;
        Chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Pie_3D_Aurora_FlatCrystal_NoGlow_NoBorder;
        Chartlet1.Fill.ShiftStep = 4;
        Chartlet1.BindChartData(SqlDataSource1);

        //更多信息请参看 http://www.Chartlet.cn
        string sql="Select Season,Profit from Sales";
        OleDbConnection cn = new OleDbConnection(cs);
        OleDbDataAdapter da = new OleDbDataAdapter(sql,cn);
        DataSet ds=new DataSet();
        da.Fill(ds,"Jesy");

        Chartlet2.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Line_3D_Aurora_FlatCrystalRound_NoGlow_NoBorder;
        //下面两个属性用来增大图形右边和下面的可视范围，避免ColorGuider和XLabels的字符被截断
        Chartlet2.InflateBottom = 50;
        Chartlet2.InflateRight = 100;
        Chartlet2.Width=1200;
        //下面通过MinValueY和MaxValueY来纵向拉伸图形，可以注释下面两句看看不拉伸的效果
        Chartlet2.MinValueY = 200;
        Chartlet2.MaxValueY = 600;
        Chartlet2.BindChartData(ds);



/*** 这里演示手动修改横坐标，纵坐标一般是数值，最多只能修改纵坐标的单位，其他暂时不支持修改 ***/

        DataTable tb = ds.Tables["Jesy"];
        Chartlet3.YLabels.UnitText = "销售额(万元)";
        Chartlet3.XLabels.UnitFont = new Font("Arial",18,FontStyle.Bold,GraphicsUnit.Pixel);
        Chartlet3.ShowErrorInfo = false;
        Chartlet3.InflateBottom = 100;
        Chartlet3.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Bar_2D_StarryNight_FlatCrystal_Glow_WhiteBorder;
        Chartlet3.BindChartData(tb);

        //下面演示在绑定数据源之后，如何修改X坐标和ColorGuider的文字
        Chartlet3.GroupTitle = new string[] { "利润","成本"};

        /** X 坐标的修改 **/
        Chartlet3.AxisX[0] = "春";
        Chartlet3.AxisX[1] = "夏";
        /* 
        * 以此类推，修改每一个X坐标
        * 你也可以把一个string数组赋给AxisX，但是数组长度必须大于等于tb.Rows.Count
        * 
        * 下面提供一种利用数组拷贝的方法赋值，不需要知道AxisX数组的长度
        */
        string[] xlabels = new string[] {"春","夏","秋","冬" };
        xlabels.CopyTo(Chartlet3.AxisX, 0);

/*** 这里演示手动修改横坐标，纵坐标一般是数值，最多只能修改纵坐标的单位，其他暂时不支持修改 ***/       

    }
}

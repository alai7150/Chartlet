﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

/// <summary>
///Chartlet - 开源的.NET图表控件
///来源于：http://www.chartlet.cn 
///版本号：v0.98
///原作者：梵高
///联  系：FanG2008.zhao@gmail.com
/// </summary>
namespace FanG
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ShadowAttributes
    {
        public ShadowAttributes(bool Enable, int Radius, int Distance, byte Angle, bool Hollow, Color Color)
        {
            this.Enable = Enable;
            this.Radius = Radius;
            this.Distance = Distance;
            this.Angle = Angle;
            this.Hollow = Hollow;
            this.Color = Color;
        }

        public ShadowAttributes(bool Enable, int Radius, int Distance, byte Angle)
        {
            this.Enable = Enable;
            this.Radius = Radius;
            this.Distance = Distance;
            this.Angle = Angle;
        }

        public ShadowAttributes()
        {
        }

        private bool _Enable = true;
        private int _Radius = 3;
        private int _Distance;
        private byte _Alpha = 192;
        private float _Angle = 60;
        private bool _Hollow = false;
        private Color _Color = Color.Black;
        [Category("Chartlet"), Description("Enable shadow of chart elements\n是否给图表元素加上投影效果")]
        public bool Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }

        [Category("Chartlet"), Description("Radius of shadow\n阴影半径")]
        public int Radius
        {
            get { return _Radius; }
            set { _Radius = value; }
        }

        [Category("Chartlet"), Description("Shadow Distance\n阴影距离")]
        public int Distance
        {
            get { return _Distance; }
            set { _Distance = value; }
        }

        [Category("Chartlet"), Description("Shadow Distance\n阴影距离")]
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        [Category("Chartlet"), Description("Shadow Distance\n阴影距离")]
        public byte Alpha
        {
            get { return _Alpha; }
            set { _Alpha = value; }
        }

        [Category("Chartlet"), Description("Shadow Distance\n阴影距离")]
        public float Angle
        {
            get { return _Angle; }
            set { _Angle = value; }
        }

        [Category("Chartlet"), Description("Enable Hollow Shadow(Only drop shadow of the eage)\n是否使用中空的投影，只投影图形的边框")]
        public bool Hollow
        {
            get { return _Hollow; }
            set { _Hollow = value; }
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CrystalAttributes
    {
        public CrystalAttributes(bool Enable, bool CoverFull, int Contraction)
        {
            this.Enable = Enable;
            this.CoverFull = CoverFull;
            this.Contraction = Contraction;
        }
        public CrystalAttributes()
        {
        }

        private bool _Enable = false;
        private bool _CoverFull = false;
        private int _Contraction = 2;
        private Chartlet.Direction _Direction = Chartlet.Direction.LeftRight;

        [Category("Chartlet"), Description("Enable Crystal effect\n水晶效果")]
        public bool Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }

        [Category("Chartlet"), Description("Full Crystal or half crystal\n全高亮水晶效果，还是半高亮水晶效果")]
        public bool CoverFull
        {
            get { return _CoverFull; }
            set { _CoverFull = value; }
        }

        [Category("Chartlet"), Description("Pixes of crystal effect contraction\n高亮区域收缩像素")]
        public int Contraction
        {
            get { return _Contraction; }
            set { _Contraction = value; }
        }

        [Category("Chartlet"), Description("Crystal effect direction\n水晶效果的投射方向")]
        public Chartlet.Direction Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }
    }

    //属性集合的基类
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Attributes
    {
        public Attributes()
        {
        }

        public Attributes(bool Show, Color ForeColor, Color BackColor, Font Font)
        {
            this.Show = Show;
            this.Font = Font;
            this.ForeColor = ForeColor;
            this.BackColor = BackColor;
        }
        public Attributes(bool Show, Color ForeColor, Color BackColor)
        {
            this.Show = Show;
            this.ForeColor = ForeColor;
            this.BackColor = BackColor;
        }

        private bool _Show = true;
        private Font _Font = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        private Color _ForeColor = Color.Black;
        private Color _BackColor = Color.White;

        [Category("Chartlet"), Description("Whether to show\n是否显示")]
        public bool Show
        {
            get { return _Show; }
            set { _Show = value; }
        }

        [Category("Chartlet"), Description("Fonts this block text\n字体")]
        public Font Font
        {
            get { return _Font; }
            set { _Font = value; }
        }

        [Category("Chartlet"), Description("Fore color, mostly represents text Color\n前景色，大部分时候指的是字体颜色")]
        public Color ForeColor
        {
            get { return _ForeColor; }
            set { _ForeColor = value; }
        }

        [Category("Chartlet"), Description("Back Color\n背景色")]
        public Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }
    }

    //文字属性集合的基类
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TextAttributes: Attributes
    {
        public TextAttributes()
        {
        }
        public TextAttributes(string Text)
        {
            this.Text = Text;
        }
        public TextAttributes(string Text, int OffsetY)
        {
            this.Text = Text;
            this.OffsetY = OffsetY;
        }
        public TextAttributes(string Text, int OffsetY, bool Show, Color ForeColor, Color BackColor, Font Font)
        {
            this.Text = Text;
            this.OffsetY = OffsetY;
            this.Show = Show;
            this.Font = Font;
            this.ForeColor = ForeColor;
            this.BackColor = BackColor;

        }


        private string _Text = "";
        private int _OffsetY = 0;
        private int _OffsetX = 0;

        [Category("Chartlet"), Description("Text to show\n文字")]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        [Category("Chartlet"), Description("Position Offset of Text\n文字的位置偏移，用来微调文字在图上的位置")]
        public int OffsetY
        {
            get { return _OffsetY; }
            set { _OffsetY = value; }
        }

        /*[Category("Chartlet"), Description("Position Offset of Text\n文字的位置偏移，用来微调文字在图上的位置")]
        public int OffsetX
        {
            get { return _OffsetX; }
            set { _OffsetX = value; }
        }*/
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class LabelsAttributes: Attributes
    {
        public LabelsAttributes()
        {
        }
        public LabelsAttributes(string UnitText, string ValueFormat)
        {
            this.UnitText = UnitText;
            this.ValueFormat = ValueFormat;
        }
        public LabelsAttributes(string UnitText, string ValueFormat, Font UnitFont)
        {
            this.UnitText = UnitText;
            this.ValueFormat = ValueFormat;
            this.UnitFont = Font;
        }
        public LabelsAttributes(bool Show, Color ForeColor, Color BackColor, Font Font, string UnitText, string ValueFormat, Font UnitFont)
        {
            this.Show = Show;
            this.Font = Font;
            this.ForeColor = ForeColor;
            this.BackColor = BackColor;
            this.UnitText = UnitText;
            this.ValueFormat = ValueFormat;
            this.UnitFont = Font;
        }
       

        private string _UnitText = "%";
        private string _ValueFormat = "0.0";
        private Font _UnitFont = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);
        private int _LabelCount = 5;

        [Category("Chartlet"), Description("Labels Unit\n坐标文字的单位")]
        public string UnitText
        {
            get { return _UnitText; }
            set { _UnitText = value; }
        }

        [Category("Chartlet"), Description("Fonts this unit text\n坐标轴单位文字的字体")]
        public Font UnitFont
        {
            get { return _UnitFont; }
            set { _UnitFont = value; }
        }

        [Category("Chartlet"), Description("Fonts this unit text\n坐标轴单位文字的字体")]
        public int LabelCount
        {
            get { return _LabelCount; }
            set { _LabelCount = value; }
        }

        [Category("Chartlet"), Description("Text format for Y-label values\n纵坐标数值显示格式(用来控制小数位数)")]
        public string ValueFormat
        {
            get { return _ValueFormat; }
            set { _ValueFormat = value; }
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class XLabelsAttributes: LabelsAttributes
    {

        public XLabelsAttributes()
        {
        }
        public XLabelsAttributes(int SampleSize, float RotateAngle)
        {
            this.SampleSize = SampleSize;
            this.RotateAngle = RotateAngle;
        }
        public XLabelsAttributes( bool Show, Color ForeColor, Color BackColor, Font Font, string UnitText, string ValueFormat, Font UnitFont,int SampleSize, float RotateAngle)
        {
            this.SampleSize = SampleSize;
            this.RotateAngle = RotateAngle;
            this.Show = Show;
            this.Font = Font;
            this.ForeColor = ForeColor;
            this.BackColor = BackColor;
            this.UnitText = UnitText;
            this.ValueFormat = ValueFormat;
            this.UnitFont = Font;
        }

        private int _SampleSize = 1;
        private float _RotateAngle = 30;

        [Category("Chartlet"), Description("XLabels SampleSize\nX坐标抽样率")]
        public int SampleSize
        {
            get { return _SampleSize; }
            set { _SampleSize = value; }
        }

        [Category("Chartlet"), Description("XLabels RotateAngle\nX坐标文字旋转角度")]
        public float RotateAngle
        {
            get { return _RotateAngle; }
            set { _RotateAngle = value; }
        }
    }

    //绘图属性集合的基类
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Painting
    {
        public Painting()
        {
        }
        public Painting(int ShiftStep, Color Color1, Color Color2, Color Color3, bool TextureEnable, HatchStyle TextureStyle)
        {
            this.ShiftStep = ShiftStep;
            this.Color1 = Color1;
            this.Color2 = Color2;
            this.Color3 = Color3;
            this.TextureEnable = TextureEnable;
            this.TextureStyle = TextureStyle;
        }
        public Painting(int ShiftStep, Color Color1, Color Color2, Color Color3)
        {
            this.ShiftStep = ShiftStep;
            this.Color1 = Color1;
            this.Color2 = Color2;
            this.Color3 = Color3;
        }

        private int _ShiftStep = 0;
        private HatchStyle _TextureStyle = HatchStyle.DarkUpwardDiagonal;
        private Color _Color1;
        private Color _Color2;
        private Color _Color3;
        private bool _TextureEnable = false;

        private Chartlet.ColorStyles _ColorStyle = Chartlet.ColorStyles.None;

        [Category("Chartlet"), Description("Please Choose a Color Style\n颜色样式")]
        public Chartlet.ColorStyles ColorStyle
        {
            get { return _ColorStyle; }
            set { _ColorStyle = value;}
        }

        [Category("Chartlet"), Description("Color Index in Color Style\n颜色索引")]
        public int ShiftStep
        {
            get { return _ShiftStep; }
            set { _ShiftStep = value; }
        }

        [Category("Chartlet"), Description("Paint Texture Style\n纹理样式")]
        public HatchStyle TextureStyle
        {
            get { return _TextureStyle; }
            set { _TextureStyle = value; }
        }

        [Category("Chartlet"), Description("First Color\n颜色1")]
        public Color Color1
        {
            get { return _Color1; }
            set { _Color1 = value; }
        }

        [Category("Chartlet"), Description("Second Color\n颜色2")]
        public Color Color2
        {
            get { return _Color2; }
            set { _Color2 = value; }
        }

        [Category("Chartlet"), Description("Third Color\n颜色3")]
        public Color Color3
        {
            get { return _Color3; }
            set { _Color3 = value; }
        }

        [Category("Chartlet"), Description("Enable Texture Style\n启用纹理样式")]
        public bool TextureEnable
        {
            get { return _TextureEnable; }
            set { _TextureEnable = value; }
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class StrokeStyle: Painting
    {
        public StrokeStyle()
        {
        }
        public StrokeStyle(int Width)
        {
            this.Width = Width;
        }
        public StrokeStyle(int ShiftStep, Color Color1, Color Color2, Color Color3, bool TextureEnable, HatchStyle TextureStyle, int Width)
        {
            this.Width = Width;
            this.ShiftStep = ShiftStep;
            this.Color1 = Color1;
            this.Color2 = Color2;
            this.Color3 = Color3;
            this.TextureEnable = TextureEnable;
            this.TextureStyle = TextureStyle;
        }

        private int _Width = 0;

        [Category("Chartlet"), Description("Stroke Line Width\n边框宽度")]
        public int Width 
        {
            get { return _Width; }
            set { _Width = value; }
        }

    }

    //背景属性结合的基类
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BackgroundAttributes
    {
        public BackgroundAttributes()
        {
        }
        public BackgroundAttributes(Color Highlight, Color Lowlight)
        {
            this.Highlight = Highlight;
            this.Lowlight = Lowlight;
        }
        public BackgroundAttributes(Color Highlight, Color Lowlight,Color Paper)
        {
            this.Highlight = Highlight;
            this.Lowlight = Lowlight;
            this.Paper = Paper;
        }

        private Color _Highlight= Color.FromArgb(80, 238, 237, 238);
        private Color _Lowlight = Color.FromArgb(255, 220, 220, 220);
        private Color _Paper = Color.FromArgb(255, Color.White);

        [Category("Chartlet"), Description("Highlighted Background Color\n背景色的高亮色")]
        public Color Highlight
        {
            get { return _Highlight; }
            set { _Highlight = value; }
        }

        [Category("Chartlet"), Description("Low Light of Background Color\n背景色的暗色")]
        public Color Lowlight
        {
            get { return _Lowlight; }
            set { _Lowlight = value; }
        }

        [Category("Chartlet"), Description("sketchpad Color\n画板颜色(最背景的颜色)")]
        public Color Paper
        {
            get { return _Paper; }
            set { _Paper = value; }
        }

    }


    //画线的属性集合的基类
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class LineAttributes
    {
        public LineAttributes()
        {
        }

        public LineAttributes(int Width, Color Color, bool EnableTexture, HatchStyle TextureStype)
        {
            this.Color = Color;
            this.EnableTexture = EnableTexture;
            this.Width = Width;
            this.TextureStyle = TextureStyle;
        }

        public LineAttributes(int Width, Color Color)
        {
            this.Color = Color;
            this.Width = Width;
        }


        private int _Width = 1;
        private Color _Color = Color.Black;
        private bool _EnableTexture = false;
        private HatchStyle _TextureStyle = HatchStyle.LargeGrid;

        [Category("Chartlet"), Description("Line width\n线条的粗细")]
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        [Category("Chartlet"), Description("Line Color\n线条的颜色")]
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        [Category("Chartlet"), Description("Draw texture Line\n使用纹理线条")]
        public bool EnableTexture
        {
            get { return _EnableTexture; }
            set { _EnableTexture = value; }
        }

        [Category("Chartlet"), Description("Texture style of Line\n纹理线条的纹理类型")]
        public HatchStyle TextureStyle
        {
            get { return _TextureStyle; }
            set { _TextureStyle = value; }
        }
       
    }


    //Spec Limit 基类
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SpecLineAttributes: LineAttributes
    {
        public SpecLineAttributes()
        {
        }

        public SpecLineAttributes(bool Show, float LowLimit, float HighLimit, int Width, Color Color, bool EnableTexture, HatchStyle TextureStype)
        {
            this.Color = Color;
            this.EnableTexture = EnableTexture;
            this.Width = Width;
            this.TextureStyle = TextureStyle;
            this.Show = Show;
            this.LowLimit = LowLimit;
            this.HighLimit = HighLimit;
        }

        public SpecLineAttributes(bool Show, float LowLimit, float HighLimit, bool YLimit)
        {
            this.Show = Show;
            this.LowLimit = LowLimit;
            this.HighLimit = HighLimit;
            this.YLimit = YLimit;
        }

        private float _LowLimit = 0;
        private float _HighLimit = 0;
        private float _MeanValue = 0;
        private bool _YLimit = true;
        private bool _Show = false;
        private bool _LLoaded = false;
        private bool _HLoaded = false;
        private bool _MLoaded = false;


        [Category("Chartlet"), Description("Spec line Low limit\nSpec线条的下限")]
        public float LowLimit
        {
            get { return _LowLimit; }
            set { _LowLimit = value; }
        }

        [Category("Chartlet"), Description("Spec line high limit\nSpec线条的上限")]
        public float HighLimit
        {
            get { return _HighLimit; }
            set { _HighLimit = value; }
        }

        [Category("Chartlet"), Description("Mean Value\nSpec线条的均值")]
        public float MeanValue
        {
            get { return _MeanValue; }
            set { _MeanValue = value; }
        }

        [Category("Chartlet"), Description("Whether show Spec limit lines\n是否显示Spec极限线条")]
        public bool Show
        {
            get { return _Show; }
            set { _Show = value; }
        }

        [Category("Chartlet"), Description("Horizental Limits or Vertical Limits.(YLimit=true means Horizental)\n水平线条还是垂直线条 (YLimit=true表示将绘制水平线条)")]
        public bool YLimit
        {
            get { return _YLimit; }
            set { _YLimit = value; }
        }

        [Category("Chartlet"), Description("Low limt value loaded\n下限已赋值")]
        public bool LLoaded
        {
            get { return _LLoaded; }
            set { _LLoaded = value; }
        }

        [Category("Chartlet"), Description("High limt value loaded\ns上限已赋值")]
        public bool HLoaded
        {
            get { return _HLoaded; }
            set { _HLoaded = value; }
        }

        [Category("Chartlet"), Description("Mean value loaded\ns均值已赋值")]
        public bool MLoaded
        {
            get { return _MLoaded; }
            set { _MLoaded = value; }
        }

    }

    /******************* 每种图形的特殊属性的基类 **********************/
    //TrendChart特殊属性的基类
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TrendAttributes
    {
        private DateTime _Start = DateTime.Now;
        private DateTime _End = DateTime.Now;
        private Chartlet.TimeSpanTypes _TimeSpan= Chartlet.TimeSpanTypes.Hour;
        private string _ValueFormat = "hh:mm";
        //private int _LabelCount = 24;

        public TrendAttributes(){
        }
        public TrendAttributes(string StartString, string EndString, Chartlet.TimeSpanTypes TimeSpan, string ValueFormat)
        {
            this.StartString = StartString;
            this.EndString = EndString;
            this.TimeSpan = TimeSpan;
            this.ValueFormat = ValueFormat;
        }
        public TrendAttributes(DateTime Start, DateTime End, Chartlet.TimeSpanTypes TimeSpan, string ValueFormat)
        {
            this.Start = Start;
            this.End = End;
            this.TimeSpan = TimeSpan;
            this.ValueFormat = ValueFormat;
        }

        [Category("Chartlet"), Description("TrendChart Start Time of XLabels\n趋势图的横坐标起始时间")]
        public DateTime Start
        {
            get { return _Start; }
            set { _Start = value; }
        }
        [Category("Chartlet"), Description("TrendChart End Time of XLabels\n趋势图的横坐标结束时间")]
        public DateTime End
        {
            get { return _End; }
            set { _End = value; }
        }
        [Category("Chartlet"), Description("TrendChart Time increase step of XLabels\n趋势图的横坐标步长(年，月，日，时，分，秒)")]
        public Chartlet.TimeSpanTypes TimeSpan
        {
            get { return _TimeSpan; }
            set { _TimeSpan = value; }
        }
        [Category("Chartlet"), Description("TrendChart Time increase step of XLabels\n趋势图的横坐标步长(年，月，日，时，分，秒)")]
        public string ValueFormat
        {
            get { return _ValueFormat; }
            set { _ValueFormat = value; }
        }
        //[Category("Chartlet"), Description("TrendChart step count of XLabels\n趋势图的横坐标数量(也就是TimeSpan的数量)")]
        //public int LabelCount
        //{
        //    get { return _LabelCount; }
        //    set { _LabelCount = value; }
        //}
        [Category("Chartlet"), Description("TrendChart Start Time(string format) of XLabels\n趋势图的横坐标起始时间(字符串格式)")]
        public string StartString
        {
            get { return _Start.ToString(); }
            set { _Start =DateTime.Parse(value); }
        }
        [Category("Chartlet"), Description("TrendChart End Time(string format) of XLabels\n趋势图的横坐标结束时间(字符串格式)")]
        public string EndString
        {
            get { return _End.ToString(); }
            set { _End = DateTime.Parse(value); }
        }

    }

    [ToolboxBitmap("FanG.ico")]
    public class Chartlet : System.Web.UI.WebControls.WebControl
    {
        //构造函数
        public Chartlet()
        {
            //TODO: 在此处添加构造函数逻辑
            this.Width = 600;
            this.Height = 400;
            this.Breeze.CopyTo(this.BarBrushColor, 0);
            this.ChartTitle.Text = "FanG Chartlet";
            this.ChartTitle.Font = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            this.ChartTitle.ForeColor = Color.DarkBlue;
            this.XLabels.UnitText = "XLabelsUnit";
            this.YLabels.UnitText = "YLabelsUnit";
        }

        //外部通用函数
        private float GetMax(float[] Datas)
        {
            float temp = 0;
            for (int i = 0; i < Datas.Length; i++)
            {
                if (Datas[i] > temp)
                    temp = Datas[i];
            }
            return temp;
        }
        private float GetMax(decimal[] Datas)
        {
            float temp = 0;
            for (int i = 0; i < Datas.Length; i++)
            {
                if ((float)Datas[i] > temp)
                    temp = (float)Datas[i];
            }
            return temp;
        }
        private float GetMin(float[] Datas)
        {
            float temp = Datas[0];
            for (int i = 0; i < Datas.Length; i++)
            {
                if (Datas[i] < temp)
                    temp = Datas[i];
            }
            return temp;
        }
        private float GetMin(decimal[] Datas)
        {
            float temp = (float)Datas[0];
            for (int i = 0; i < Datas.Length; i++)
            {
                if ((float)Datas[i] < temp)
                    temp = (float)Datas[i];
            }
            return temp;
        }
        private float GetSum(float[] Datas)
        {
            float temp = 0;
            for (int i = 0; i < Datas.Length; i++)
            {
                temp += Datas[i];
            }
            return temp;
        }
        private float GetSum(decimal[] Datas)
        {
            float temp = 0;
            for (int i = 0; i < Datas.Length; i++)
            {
                temp += (float)Datas[i];
            }
            return temp;
        }
        private float GetBond(float DataIn)
        {
            int z = (int)Math.Floor(DataIn / 10);
            if (z > 0)
            {
                if (DataIn - z * 10 > 5)
                {
                    z = (z + 1) * 10;
                }
                else if ((DataIn - z * 10 < 5) && (DataIn - z * 10 > 0))
                {
                    z = z * 10 + 5;
                }
                else
                {
                    z = (int)DataIn;
                }
                return z;
            }
            else
                return DataIn;
        }
        //外部通用函数

        //自定义枚举
        public enum TimeSpanTypes
        {
            Year,
            Month,
            Day,
            Hour,
            Minute,
            Second,
            Millisecond
        }
        public enum ChartTypes
        {
            Bar,
            Line,
            Pie,
            Stack,
            HBar,
            Trend,
            Bubble,
            FloatBar,
            Linear,
            Histo,
            BoxPlot
        }
        public enum LineConnectionTypes
        {
            Round,
            Square,
            None
        }
        public enum Direction
        {
            LeftRight,
            TopBottom,
            RightLeft,
            BottomTop
        }
        public enum ColorStyles
        {
            None,
            Breeze,
            Aurora,
            StarryNight
        }
        public enum ChartDimensions
        {
            Chart2D,
            Chart3D
        }

        public enum AppearanceStyles
        {
            None_None_None_None_None_None,

            //For Barchart
            Bar_2D_Breeze_NoCrystal_NoGlow_NoBorder,
            Bar_2D_Breeze_NoCrystal_Glow_NoBorder,
            Bar_2D_Breeze_NoCrystal_Glow_WhiteBorder,
            Bar_2D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Bar_2D_Breeze_FlatCrystal_Glow_NoBorder,
            Bar_2D_Breeze_FlatCrystal_Glow_WhiteBorder,
            Bar_2D_Breeze_FlatCrystal_Glow_TextureBorder,
            Bar_2D_Aurora_NoCrystal_NoGlow_NoBorder,
            Bar_2D_Aurora_NoCrystal_Glow_NoBorder,
            Bar_2D_Aurora_NoCrystal_Glow_WhiteBorder,
            Bar_2D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Bar_2D_Aurora_FlatCrystal_Glow_NoBorder,
            Bar_2D_Aurora_FlatCrystal_Glow_WhiteBorder,
            Bar_2D_Aurora_FlatCrystal_Glow_TextureBorder,
            Bar_2D_Aurora_GlassCrystal_NoGlow_NoBorder,
            Bar_2D_Aurora_GlassCrystal_Glow_NoBorder,
            Bar_2D_Aurora_GlassCrystal_Glow_WhiteBorder,
            Bar_2D_StarryNight_FlatCrystal_Glow_NoBorder,
            Bar_2D_StarryNight_FlatCrystal_Glow_WhiteBorder,
            Bar_2D_StarryNight_FlatCrystal_Glow_TextureBorder,
            Bar_2D_StarryNight_GlassCrystal_NoGlow_NoBorder,
            //For Histogram
            Histo_2D_Breeze_NoCrystal_NoGlow_NoBorder,
            Histo_2D_Breeze_NoCrystal_Glow_NoBorder,
            Histo_2D_Breeze_NoCrystal_Glow_WhiteBorder,
            Histo_2D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Histo_2D_Breeze_FlatCrystal_Glow_NoBorder,
            Histo_2D_Breeze_FlatCrystal_Glow_WhiteBorder,
            Histo_2D_Breeze_FlatCrystal_Glow_TextureBorder,
            Histo_2D_Aurora_NoCrystal_NoGlow_NoBorder,
            Histo_2D_Aurora_NoCrystal_Glow_NoBorder,
            Histo_2D_Aurora_NoCrystal_Glow_WhiteBorder,
            Histo_2D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Histo_2D_Aurora_FlatCrystal_Glow_NoBorder,
            Histo_2D_Aurora_FlatCrystal_Glow_WhiteBorder,
            Histo_2D_Aurora_FlatCrystal_Glow_TextureBorder,
            Histo_2D_Aurora_GlassCrystal_NoGlow_NoBorder,
            Histo_2D_Aurora_GlassCrystal_Glow_NoBorder,
            Histo_2D_Aurora_GlassCrystal_Glow_WhiteBorder,
            Histo_2D_StarryNight_FlatCrystal_Glow_NoBorder,
            Histo_2D_StarryNight_FlatCrystal_Glow_WhiteBorder,
            Histo_2D_StarryNight_FlatCrystal_Glow_TextureBorder,
            Histo_2D_StarryNight_GlassCrystal_NoGlow_NoBorder,
            //For 3D Bar Chart
            Bar_3D_Breeze_NoCrystal_NoGlow_NoBorder,
            Bar_3D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Bar_3D_Aurora_NoCrystal_NoGlow_NoBorder,
            Bar_3D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Bar_3D_StarryNight_NoCrystal_NoGlow_NoBorder,
            Bar_3D_StarryNight_FlatCrystal_NoGlow_NoBorder,

            //For Line Chart
            Line_2D_Aurora_ThickRound_NoGlow_NoBorder,
            Line_2D_Aurora_ThickRound_Glow_NoBorder,
            Line_2D_Aurora_ThickSquare_NoGlow_NoBorder,
            Line_2D_Aurora_ThickSquare_Glow_NoBorder,
            Line_2D_Aurora_ThinRound_NoGlow_NoBorder,
            Line_2D_Aurora_ThinRound_Glow_NoBorder,
            Line_2D_Aurora_ThinSquare_NoGlow_NoBorder,
            Line_2D_Aurora_ThinSquare_Glow_NoBorder,

            Line_2D_StarryNight_ThickRound_NoGlow_NoBorder,
            Line_2D_StarryNight_ThickRound_Glow_NoBorder,
            Line_2D_StarryNight_ThickSquare_NoGlow_NoBorder,
            Line_2D_StarryNight_ThickSquare_Glow_NoBorder,
            Line_2D_StarryNight_ThinRound_NoGlow_NoBorder,
            Line_2D_StarryNight_ThinRound_Glow_NoBorder,
            Line_2D_StarryNight_ThinSquare_NoGlow_NoBorder,
            Line_2D_StarryNight_ThinSquare_Glow_NoBorder,
            //For 3D Line
            Line_3D_Breeze_NoCrystalNone_NoGlow_NoBorder,
            Line_3D_Breeze_NoCrystalRound_NoGlow_NoBorder,
            Line_3D_Breeze_NoCrystalSquare_NoGlow_NoBorder,
            Line_3D_Breeze_FlatCrystalNone_NoGlow_NoBorder,
            Line_3D_Breeze_FlatCrystalRound_NoGlow_NoBorder,
            Line_3D_Breeze_FlatCrystalSquare_NoGlow_NoBorder,
            Line_3D_Breeze_GlassCrystalNone_NoGlow_NoBorder,
            Line_3D_Breeze_GlassCrystalRound_NoGlow_NoBorder,
            Line_3D_Breeze_GlassCrystalSquare_NoGlow_NoBorder,
            Line_3D_Aurora_NoCrystalNone_NoGlow_NoBorder,
            Line_3D_Aurora_NoCrystalRound_NoGlow_NoBorder,
            Line_3D_Aurora_NoCrystalSquare_NoGlow_NoBorder,
            Line_3D_Aurora_FlatCrystalNone_NoGlow_NoBorder,
            Line_3D_Aurora_FlatCrystalRound_NoGlow_NoBorder,
            Line_3D_Aurora_FlatCrystalSquare_NoGlow_NoBorder,
            Line_3D_Aurora_GlassCrystalNone_NoGlow_NoBorder,
            Line_3D_Aurora_GlassCrystalRound_NoGlow_NoBorder,
            Line_3D_Aurora_GlassCrystalSquare_NoGlow_NoBorder,
            Line_3D_StarryNight_NoCrystalNone_NoGlow_NoBorder,
            Line_3D_StarryNight_NoCrystalRound_NoGlow_NoBorder,
            Line_3D_StarryNight_NoCrystalSquare_NoGlow_NoBorder,
            Line_3D_StarryNight_FlatCrystalNone_NoGlow_NoBorder,
            Line_3D_StarryNight_FlatCrystalRound_NoGlow_NoBorder,
            Line_3D_StarryNight_FlatCrystalSquare_NoGlow_NoBorder,
            Line_3D_StarryNight_GlassCrystalNone_NoGlow_NoBorder,
            Line_3D_StarryNight_GlassCrystalRound_NoGlow_NoBorder,
            Line_3D_StarryNight_GlassCrystalSquare_NoGlow_NoBorder,

            //For Pie Chart
            Pie_2D_Breeze_NoCrystal_NoGlow_NoBorder,
            Pie_2D_Breeze_NoCrystal_NoGlow_WhiteBorder,
            Pie_2D_Breeze_NoCrystal_Glow_WhiteBorder,
            Pie_2D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Pie_2D_Breeze_FlatCrystal_Glow_WhiteBorder,
            Pie_2D_Breeze_GlassCrystal_NoGlow_NoBorder,
            Pie_2D_Breeze_GlassCrystal_Glow_WhiteBorder,
            Pie_2D_Aurora_NoCrystal_NoGlow_NoBorder,
            Pie_2D_Aurora_NoCrystal_NoGlow_WhiteBorder,
            Pie_2D_Aurora_NoCrystal_Glow_WhiteBorder,
            Pie_2D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Pie_2D_Aurora_FlatCrystal_Glow_WhiteBorder,
            Pie_2D_Aurora_GlassCrystal_NoGlow_NoBorder,
            Pie_2D_Aurora_GlassCrystal_Glow_WhiteBorder,
            Pie_2D_StarryNight_NoCrystal_NoGlow_NoBorder,
            Pie_2D_StarryNight_NoCrystal_NoGlow_WhiteBorder,
            Pie_2D_StarryNight_NoCrystal_Glow_WhiteBorder,
            Pie_2D_StarryNight_FlatCrystal_NoGlow_NoBorder,
            Pie_2D_StarryNight_FlatCrystal_Glow_WhiteBorder,
            Pie_2D_StarryNight_GlassCrystal_NoGlow_NoBorder,
            Pie_2D_StarryNight_GlassCrystal_Glow_WhiteBorder,
            //For 3D Pie Chart
            Pie_3D_Aurora_NoCrystal_NoGlow_NoBorder,
            Pie_3D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Pie_3D_Breeze_NoCrystal_NoGlow_NoBorder,
            Pie_3D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Pie_3D_StarryNight_NoCrystal_NoGlow_NoBorder,
            Pie_3D_StarryNight_FlatCrystal_NoGlow_NoBorder,

            //For Stack Bar Chart
            Stack_2D_Breeze_NoCrystal_NoGlow_NoBorder,
            Stack_2D_Breeze_NoCrystal_Glow_NoBorder,
            Stack_2D_Breeze_NoCrystal_Glow_WhiteBorder,
            Stack_2D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Stack_2D_Breeze_FlatCrystal_Glow_NoBorder,
            Stack_2D_Breeze_FlatCrystal_Glow_WhiteBorder,
            Stack_2D_Breeze_FlatCrystal_Glow_TextureBorder,
            Stack_2D_Aurora_NoCrystal_Glow_WhiteBorder,
            Stack_2D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Stack_2D_Aurora_FlatCrystal_Glow_NoBorder,
            Stack_2D_Aurora_FlatCrystal_Glow_WhiteBorder,
            Stack_2D_Aurora_FlatCrystal_Glow_TextureBorder,
            Stack_2D_Aurora_GlassCrystal_NoGlow_NoBorder,
            Stack_2D_Aurora_GlassCrystal_Glow_NoBorder,
            Stack_2D_Aurora_GlassCrystal_Glow_WhiteBorder,
            Stack_2D_StarryNight_FlatCrystal_Glow_NoBorder,
            Stack_2D_StarryNight_FlatCrystal_Glow_WhiteBorder,
            Stack_2D_StarryNight_FlatCrystal_Glow_TextureBorder,
            Stack_2D_StarryNight_GlassCrystal_NoGlow_NoBorder,
            //For 3D Stack Bar Chart
            Stack_3D_Breeze_NoCrystal_NoGlow_NoBorder,
            Stack_3D_Breeze_FlatCrystal_NoGlow_NoBorder,
            Stack_3D_Aurora_NoCrystal_NoGlow_NoBorder,
            Stack_3D_Aurora_FlatCrystal_NoGlow_NoBorder,
            Stack_3D_StarryNight_NoCrystal_NoGlow_NoBorder,
            Stack_3D_StarryNight_FlatCrystal_NoGlow_NoBorder,

            //For 2D HBar Chart
            HBar_2D_Breeze_NoCrystal_NoGlow_NoBorder,
            HBar_2D_Breeze_NoCrystal_Glow_NoBorder,
            HBar_2D_Breeze_NoCrystal_Glow_WhiteBorder,
            HBar_2D_Breeze_FlatCrystal_NoGlow_NoBorder,
            HBar_2D_Breeze_FlatCrystal_Glow_NoBorder,
            HBar_2D_Breeze_FlatCrystal_Glow_WhiteBorder,
            HBar_2D_Breeze_FlatCrystal_Glow_TextureBorder,
            HBar_2D_Aurora_NoCrystal_NoGlow_NoBorder,
            HBar_2D_Aurora_NoCrystal_Glow_NoBorder,
            HBar_2D_Aurora_NoCrystal_Glow_WhiteBorder,
            HBar_2D_Aurora_FlatCrystal_NoGlow_NoBorder,
            HBar_2D_Aurora_FlatCrystal_Glow_NoBorder,
            HBar_2D_Aurora_FlatCrystal_Glow_WhiteBorder,
            HBar_2D_Aurora_FlatCrystal_Glow_TextureBorder,
            HBar_2D_Aurora_GlassCrystal_NoGlow_NoBorder,
            HBar_2D_Aurora_GlassCrystal_Glow_NoBorder,
            HBar_2D_Aurora_GlassCrystal_Glow_WhiteBorder,
            HBar_2D_StarryNight_FlatCrystal_Glow_NoBorder,
            HBar_2D_StarryNight_FlatCrystal_Glow_WhiteBorder,
            HBar_2D_StarryNight_FlatCrystal_Glow_TextureBorder,
            HBar_2D_StarryNight_GlassCrystal_NoGlow_NoBorder,

            //For Line Chart
            Trend_2D_Aurora_ThickRound_NoGlow_NoBorder,
            Trend_2D_Aurora_ThickRound_Glow_NoBorder,
            Trend_2D_Aurora_ThickSquare_NoGlow_NoBorder,
            Trend_2D_Aurora_ThickSquare_Glow_NoBorder,
            Trend_2D_Aurora_ThinRound_NoGlow_NoBorder,
            Trend_2D_Aurora_ThinRound_Glow_NoBorder,
            Trend_2D_Aurora_ThinSquare_NoGlow_NoBorder,
            Trend_2D_Aurora_ThinSquare_Glow_NoBorder,

            Trend_2D_StarryNight_ThickRound_NoGlow_NoBorder,
            Trend_2D_StarryNight_ThickRound_Glow_NoBorder,
            Trend_2D_StarryNight_ThickSquare_NoGlow_NoBorder,
            Trend_2D_StarryNight_ThickSquare_Glow_NoBorder,
            Trend_2D_StarryNight_ThinRound_NoGlow_NoBorder,
            Trend_2D_StarryNight_ThinRound_Glow_NoBorder,
            Trend_2D_StarryNight_ThinSquare_NoGlow_NoBorder,
            Trend_2D_StarryNight_ThinSquare_Glow_NoBorder,
            //For 3D Trend Chart
            Trend_3D_Breeze_NoCrystalNone_NoGlow_NoBorder,
            Trend_3D_Breeze_NoCrystalRound_NoGlow_NoBorder,
            Trend_3D_Breeze_NoCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Breeze_FlatCrystalNone_NoGlow_NoBorder,
            Trend_3D_Breeze_FlatCrystalRound_NoGlow_NoBorder,
            Trend_3D_Breeze_FlatCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Breeze_GlassCrystalNone_NoGlow_NoBorder,
            Trend_3D_Breeze_GlassCrystalRound_NoGlow_NoBorder,
            Trend_3D_Breeze_GlassCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Aurora_NoCrystalNone_NoGlow_NoBorder,
            Trend_3D_Aurora_NoCrystalRound_NoGlow_NoBorder,
            Trend_3D_Aurora_NoCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Aurora_FlatCrystalNone_NoGlow_NoBorder,
            Trend_3D_Aurora_FlatCrystalRound_NoGlow_NoBorder,
            Trend_3D_Aurora_FlatCrystalSquare_NoGlow_NoBorder,
            Trend_3D_Aurora_GlassCrystalNone_NoGlow_NoBorder,
            Trend_3D_Aurora_GlassCrystalRound_NoGlow_NoBorder,
            Trend_3D_Aurora_GlassCrystalSquare_NoGlow_NoBorder,
            Trend_3D_StarryNight_NoCrystalNone_NoGlow_NoBorder,
            Trend_3D_StarryNight_NoCrystalRound_NoGlow_NoBorder,
            Trend_3D_StarryNight_NoCrystalSquare_NoGlow_NoBorder,
            Trend_3D_StarryNight_FlatCrystalNone_NoGlow_NoBorder,
            Trend_3D_StarryNight_FlatCrystalRound_NoGlow_NoBorder,
            Trend_3D_StarryNight_FlatCrystalSquare_NoGlow_NoBorder,
            Trend_3D_StarryNight_GlassCrystalNone_NoGlow_NoBorder,
            Trend_3D_StarryNight_GlassCrystalRound_NoGlow_NoBorder,
            Trend_3D_StarryNight_GlassCrystalSquare_NoGlow_NoBorder,

        }

        //属性
        private string _RootPath = "C:\\";
        private string _ImageFolder = "Chartlet";
        private ImageFormat _OutputFormat = ImageFormat.Jpeg;
        private ChartTypes _ChartType = ChartTypes.Bar;
        private int _MutipleBars = 0;
        private double _MaxValueY = 0;
        private double _BaseLineX = -0.830213;
        private double _BaseLineY_H = -0.830213;
        private double _BaseLineY_L = -0.830213;
        private double _MinValueY = 0;
        private bool _RoundRectangle = false;
        private int _RoundRadius = 2;
        private LineConnectionTypes _LineConnectionType = LineConnectionTypes.Round;
        private int _LineConnectionRadius = 10;
        private AppearanceStyles _AppearanceStyle = AppearanceStyles.Bar_2D_Aurora_FlatCrystal_Glow_NoBorder;
        private ChartDimensions _Dimension = ChartDimensions.Chart2D;
        private int _Depth3D = 10;
        private byte _Alpha3D = 255;
        private bool _AutoBarWidth = true;
        private bool _Colorful = true;
        private bool _ShowErrorInfo = true;
        private bool _ShowCopyright = false;
        private string _CopyrightText = "Provided by Chartlet.cn";
        private int _InflateRight = 0;
        private int _InflateBottom = 0;
        private int _InflateTop = 0;
        private int _InflateLeft = 0;

        //CSS & Client event for image
        private int _ImageBorder = 0;
        private string _ImageStyle = "";
        private string _ClientClick = "";
        private string _ClientMouseOver = "";
        private string _ClientMouseOut = "";
        private string _ClientMouseMove = "";
        private string _ClientUseMap = "";


        //CSS & Client event for image
        [Category("Chartlet"), Description("Output Image border.\n输出图片的边框")]
        public int ImageBorder
        {
            get { return _ImageBorder; }
            set { _ImageBorder = value; }
        }
        [Category("Chartlet"), Description("Output Image CSS Style.\n输出图片的CSS Style属性")]
        public string ImageStyle
        {
            get { return _ImageStyle; }
            set { _ImageStyle = value; }
        }
        [Category("Chartlet"), Description("Output Image OnClick attribute,this event entrance attribute can provide you a interface to develop some interactive functions.\n输出图片的OnClick属性,可以为javascript代码或者js函数,这几个事件属性可以用来自定义客户端交互功能")]
        public string ClientClick
        {
            get { return _ClientClick; }
            set { _ClientClick = value; }
        }
        [Category("Chartlet"), Description("Output Image OnMouseOver attribute.\n输出图片的OnMouseOver属性,可以为javascript代码或者js函数")]
        public string ClientMouseOver
        {
            get { return _ClientMouseOver; }
            set { _ClientMouseOver = value; }
        }
        [Category("Chartlet"), Description("Output Image OnMouseOut attribute.\n输出图片的OnMouseOut属性,可以为javascript代码或者js函数")]
        public string ClientMouseOut
        {
            get { return _ClientMouseOut; }
            set { _ClientMouseOut = value; }
        }
        [Category("Chartlet"), Description("Output Image OnMouseMove attribute.\n输出图片的OnMouseMove属性,可以为javascript代码或者js函数")]
        public string ClientMouseMove
        {
            get { return _ClientMouseMove; }
            set { _ClientMouseMove = value; }
        }
        [Category("Chartlet"), Description("Map id on the image that you defined.\n自定义图片热点的id(如Map)")]
        public string ClientUseMap
        {
            get { return _ClientUseMap; }
            set { _ClientUseMap = value; }
        }

        /************************************/
        [Category("Chartlet"), Description("Image output format.\n图片输出格式")]
        public ImageFormat OutputFormat
        {
            get { return _OutputFormat; }
            set { _OutputFormat = value; }
        }

        [Category("Chartlet"), Description("Show Chartlet.cn on Chart.\n3D 在图形上显示Chartlet.cn")]
        public bool ShowCopyright
        {
            get { return _ShowCopyright; }
            set { _ShowCopyright = value; }
        }

        [Category("Chartlet"), Description("Show Chartlet.cn on Chart.\n3D 在图形上显示Chartlet.cn")]
        public string CopyrightText
        {
            get { return _CopyrightText; }
            set { _CopyrightText = value; }
        }

        [Category("Chartlet"), Description("Set a horizental baseline for chart, if value is less than baseline the bar will grouth under X axies.\n设定水平基线值，如果数值小于基线，则图形向着Y负方向增长")]
        public double BaseLineX
        {
            get { return _BaseLineX; }
            set { _BaseLineX = value; }
        }

        [Category("Chartlet"), Description("Set a vertical baseline for chart, used to show Low Limit on Histogram.\n设定垂直基线值，用作下限 Low Limit,主要用作直方图")]
        public double BaseLineY_L
        {
            get { return _BaseLineY_L; }
            set { _BaseLineY_L = value; }
        }

        [Category("Chartlet"), Description("Set a vertical baseline for chart, used to show High Limit on Histogram.\n设定垂直基线值，用作上限 High Limit,主要用作直方图")]
        public double BaseLineY_H
        {
            get { return _BaseLineY_H; }
            set { _BaseLineY_H = value; }
        }

        [Category("Chartlet"), Description("To enlarge width of background and keep the size of chart.\n增大背景宽度，保持图形大小不变,可以为负数(缩小)")]
        public int InflateRight
        {
            get { return _InflateRight; }
            set { _InflateRight = value; }
        }

        [Category("Chartlet"), Description("To enlarge height of background and keep the size of chart.\n增大背景高度，保持图形大小不变,可以为负数(缩小)")]
        public int InflateBottom
        {
            get { return _InflateBottom; }
            set { _InflateBottom = value; }
        }

        [Category("Chartlet"), Description("To enlarge width of background and keep the size of chart.\n增大背景宽度，保持图形大小不变,可以为负数(缩小)")]
        public int InflateTop
        {
            get { return _InflateTop; }
            set { _InflateTop = value; }
        }

        [Category("Chartlet"), Description("To enlarge width of background and keep the size of chart.\n增大背景宽度，保持图形大小不变,可以为负数(缩小)")]
        public int InflateLeft
        {
            get { return _InflateLeft; }
            set { _InflateLeft = value; }
        }

        [Category("Chartlet"), Description("Whether show the Error information.\n是否显示错误信息")]
        public bool ShowErrorInfo
        {
            get { return _ShowErrorInfo; }
            set { _ShowErrorInfo = value; }
        }

        [Category("Chartlet"), Description("Use different colors on 1 group data.\n 只有一组数据的时候，是否使用多种颜色")]
        public bool Colorful
        {
            get { return _Colorful; }
            set { _Colorful = value; }
        }

        [Category("Chartlet"), Description("Auto calculate bar width.\n3D 自动计算柱子宽度，如果数据很少请设为false,否则柱子会很宽")]
        public bool AutoBarWidth
        {
            get { return _AutoBarWidth; }
            set { _AutoBarWidth = value; }
        }

        [Category("Chartlet"), Description("Color alpha of 3D Chart.\n3D 图形的透明度")]
        public byte Alpha3D
        {
            get { return _Alpha3D; }
            set { _Alpha3D = value; }
        }

        [Category("Chartlet"), Description("Depth of 3D effect.\n3D 效果的纵向深度")]
        public int Depth3D
        {
            get { return _Depth3D; }
            set { _Depth3D = value; }
        }

        [Category("Chartlet"), Description("Dimension of the chart.\n图形维数2D/3D")]
        public ChartDimensions Dimension
        {
            get { return _Dimension; }
            set { _Dimension = value; }
        }

        [Category("Chartlet"), Description("Chartlet image saved directory when in design mode\n设计时图片暂存路径(如 C:\\)，如果有驱动器C，那就使用默认值")]
        public string RootPath
        {
            get { return _RootPath; }
            set
            {
                if (value.Substring(value.Length - 2, 1) != "\\" && Site != null)
                    value = value + "\\";
                _RootPath = value;
            }
        }

        [Category("Chartlet"), Description("Folder for saving chart image\n图片存储文件夹")]
        public string ImageFolder
        {
            get { return _ImageFolder; }
            set { _ImageFolder = value; }
        }

        [Category("Chartlet"), Description("Chart Type\n统计图的类型(如 折线图:Line)")]
        public ChartTypes ChartType
        {
            get { return _ChartType; }
            set { _ChartType = value; }
        }

        [Category("Chartlet"), Description("Count of Bars in Bar-Chart of one Element\n柱状图中每个元素包含的柱子的数量")]
        public int GroupSize
        {
            get { return _MutipleBars; }
            set { _MutipleBars = value; }
        }

        [Category("Chartlet"), Description("Max Value of Y Axis\n自定义纵坐标的最大值，用来统一调整柱子的高度")]
        public double MaxValueY
        {
            get { return _MaxValueY; }
            set
            {
                if (value != 0)
                    _MaxValueY = value;
                else
                    _MaxValueY = 0;
            }
        }

        [Category("Chartlet"), Description("Min Value of Y Axis\n自定义纵坐标的最小值，用来统一调整柱子的高度")]
        public double MinValueY
        {
            get { return _MinValueY; }
            set { _MinValueY = value; }
        }

        [Category("Chartlet"), Description("Enable Round Rectangle(For Bar Chart)\n使用圆角矩形（针对Bar-Chart）")]
        public bool RoundRectangle
        {
            get { return _RoundRectangle; }
            set { _RoundRectangle = value; }
        }

        [Category("Chartlet"), Description("Round Radius(For Bar Chart)\n圆角半径（针对Bar-Chart）")]
        public int RoundRadius
        {
            get { return _RoundRadius; }
            set { _RoundRadius = value; }
        }

        //下面定义折线图的三个属性
        [Category("Chartlet"), Description("Line Connection Type (For line Chart)\n线条连接点的样式（针对 折线图）")]
        public LineConnectionTypes LineConnectionType
        {
            get { return _LineConnectionType; }
            set { _LineConnectionType = value; }
        }

        [Category("Chartlet"), Description("Line Connector Radias(Width) (For line Chart)\n线条连接点的半径(宽度)（针对 折线图）")]
        public int LineConnectionRadius
        {
            get { return _LineConnectionRadius; }
            set { _LineConnectionRadius = value; }
        }


        //颜色属性
        [Category("Chartlet"), Description("Chart appearance style\n图表的外观样式(你只需设置这一个属性再调用BindChartData()方法，一切OK了)")]
        public AppearanceStyles AppearanceStyle
        {
            get { return _AppearanceStyle; }
            set { _AppearanceStyle = value; SetAppearance(); }
        }


        //投影属性
        private ShadowAttributes _Shadow;
        [Category("Chartlet"), Description("Shadow Attributes\n投影属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ShadowAttributes Shadow
        {
            get
            {
                if (_Shadow == null)
                    _Shadow = new ShadowAttributes();
                return _Shadow;
            }
            set
            {
                _Shadow = value;
            }
        }

        //水晶效果
        private CrystalAttributes _Crystal;
        [Category("Chartlet"), Description("Crystal Attributes\n水晶效果属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CrystalAttributes Crystal
        {
            get
            {
                if (_Crystal == null)
                    _Crystal = new CrystalAttributes();
                return _Crystal;
            }
            set
            { 
                _Crystal=value;
            }
        }

        //ColorGuider控制属性
        private Attributes _ColorGuider;
        [Category("Chartlet"), Description("Color Guider Attributes\n颜色图例的属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Attributes ColorGuider
        {
            get
            {
                if (_ColorGuider == null)
                    _ColorGuider = new Attributes();
                return _ColorGuider;
            }
            set{
                _ColorGuider=value;
            }
        }

        //数值标签控制属性
        private LabelsAttributes _Tips;
        [Category("Chartlet"), Description("Attributes of value tips\n数值标签的属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public LabelsAttributes Tips
        {
            get
            {
                if (_Tips == null)
                    _Tips = new LabelsAttributes();
                return _Tips;
            }
            set
            {
                _Tips = value;
            }
        }

        //Y坐标控制属性
        private LabelsAttributes _YLabels;
        [Category("Chartlet"), Description("YLabels Attributes\nY坐标属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public LabelsAttributes YLabels
        {
            get
            {
                if (_YLabels == null)
                    _YLabels = new LabelsAttributes();
                return _YLabels;
            }
            set
            {
                _YLabels = value;
            }
        }

        //X坐标控制属性
        private XLabelsAttributes _XLabels;
        [Category("Chartlet"), Description("XLabels Attributes\nX坐标属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public XLabelsAttributes XLabels
        {
            get
            {
                if (_XLabels == null)
                    _XLabels = new XLabelsAttributes();
                return _XLabels;
            }
            set
            {
                _XLabels = value;
            }
        }

        //ColorGuider控制属性
        private TextAttributes _ChartTitle;
        [Category("Chartlet"), Description("Chart title\n图表标题属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TextAttributes ChartTitle
        {
            get
            {
                if (_ChartTitle== null)
                    _ChartTitle = new TextAttributes();
                return _ChartTitle;
            }
            set
            {
                _ChartTitle = value;
            }
        }

        //填充控制属性
        private Painting _Fill;
        [Category("Chartlet"), Description("Fill Style\n填充属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Painting Fill
        {
            get
            {
                if (_Fill == null)
                    _Fill = new Painting();
                return _Fill;
            }
            set
            {
                _Fill = value;
            }
        }

        //描边控制属性
        private StrokeStyle _Stroke;
        [Category("Chartlet"), Description("Fill Style\n填充属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StrokeStyle Stroke
        {
            get
            {
                if (_Stroke == null)
                    _Stroke = new StrokeStyle();
                return _Stroke;
            }
            set
            {
                _Stroke = value;
            }
        }

        private BackgroundAttributes _Background;
        [Category("Chartlet"), Description("Background Attributes\n图形背景属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BackgroundAttributes Background
        {
            get
            {
                if (_Background == null)
                    _Background = new BackgroundAttributes();
                return _Background;
            }
            set
            {
                _Background = value;
            }
        }

        private TrendAttributes _Trend;
        [Category("Chartlet"), Description("Trend chart special attributes\n趋势图的特殊属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TrendAttributes Trend
        {
            get
            {
                if (_Trend == null)
                    _Trend = new TrendAttributes();
                return _Trend;
            }
            set
            {
                _Trend = value;
            }
        }

        private SpecLineAttributes _SpecLine;
        [Category("Chartlet"), Description("Spec Line attributes\nSpec Line的属性集合")]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SpecLineAttributes SpecLine
        {
            get
            {
                if (_SpecLine == null)
                    _SpecLine = new SpecLineAttributes();
                return _SpecLine;
            }
            set
            {
                _SpecLine = value;
            }
        }


        /****************方法*****************/

        public string GetVersion()
        {//获得版本信息
            string verInfo = "Product Name: Chartlet<br>Description: Smart Chart Control For .NET<br>";
            verInfo += "Version: v0.98 (16/02/2010 - 03/04/2010)<br>";
            verInfo += "Copyright © <font style='color:purple; font-weight:bold'>FanG</font> Corporation &nbsp;&nbsp;Powered by <font style='color:purple;'>Alay(阿赖)</font><br>";
            verInfo += "Home Page:http://www.chartlet.cn<br>";
            verInfo += "Contact: FanG2008.Zhao@gmail.com";
            return verInfo;
        }
        public string GetVersionDetail()
        {
            string verList = null;
            verList += "Version: v0.98 (03/04/2010) In this version Trend chart is provided. Fixed line chart ColorGuider mismatch bug<br>";
            verList += "Version: v0.97 (16/02/2010) In this version HBar chart is provided and add baseline property to display bar/line below X Axis.<br>";
            verList += "Version: v0.96 (30/12/2009) In this version fixed the Chart Left,Right,Top,Bottom blank space,and the blank space will be replaced by chart when Title/ColorGuider/YLabels is hidden.X labels will be align center when not rotated.<br>";
            verList += "Version: v0.95 (15/10/2009) In this version we create the onmouseover-tips-show effect with JS.<br>";
            verList += "Version: v0.94 (15/9/2009) In this version we reorganized attributes of Chart and put some attributes into composite attributes and provide Font,Color control for all text on chart.<br>";
            verList += "Version: v0.93 (13/9/2009) In this version eleminate Out Of Memery bug and.Stack Bar Chart in 2D and 3D is available<br>";
            verList += "Version: v0.92 (19/8/2009) In this version eleminate out of index bug when pie chart data is all zero and add color guider controls,add Tips.Show control for 2D Pie chart.Add error msg for no-bond chart<br>";
            verList += "Version: v0.91 (19/8/2009) In this version Chartlet can accept DataSet,DataTable,DataView and SqlDataSource as data source.<br>";
            verList += "Version: v0.9 (7/7/2009) In this version 3D Bar chart and 3D Line Chart is available,provide Tips.Show attribute to show values beside every element.<br>";
            verList += "Version: v0.8 (7/6/2009) In this version 3D pie chart is available,provide MinValueY attribute for you to define the Y Axis and removed text displaying in 2D pie chart,correct out of index error.<br>";
            verList += "Version: v0.7 (29/5/2009) In this version Crystal effect is available for Pie Chart, add white border and texture border effect.<br>";
            verList += "Version: v0.6 (25/5/2009) In this version Crystal effect is available for Bar Chart, and embed 3 groups of pretty color, you can create pretty crystal chart easily with it,and enclosed some beautiful chart setting, you can create pretty chart only with one setting!<br>";
            verList += "Version: v0.5 (21/5/2009) In this version Pie - Chart and Chartlet - Help is available.<br>";
            verList += "Version: v0.4 (16/5/2009) In this version BindChartData() method was provided, you can bind SqlDataSource to Chartlet Control directly, and InitializeData() method stil  provided as a alternative choice.<br>";
            verList += "Version: v0.3 (10/5/2009) In this version Line Chart is available,inherit flexible color setting and shadow setting, provide line connection setting.<br>";
            verList += "Version: v0.2 (3/5/2009) In this version glorious Bar Chart is available, provide color setting, flexible shadow setting and round rectangle setting.<br>";
            verList += "Version: v0.1 (29/4/2009) In this version basic Bar Chart is available.<br>";
            return verList;
        }
        //画圆角矩形，返回GraphicsPath
        public GraphicsPath GetRoundRect(float x, float y, float width, float height, float roundRadius, bool halfRound)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, roundRadius * 2, roundRadius * 2, 180, 90);
            gp.AddLine(x + roundRadius, y, x + width - roundRadius, y);
            gp.AddArc(x + width - roundRadius * 2, y, roundRadius * 2, roundRadius * 2, 270, 90);
            if (halfRound)
            {
                gp.AddLine(x + width, y + roundRadius, x + width, y + height);
                gp.AddLine(x + width, y + height, x, y + height);
                gp.AddLine(x, y + height, x, y + roundRadius);
            }
            else
            {
                gp.AddLine(x + width, y + roundRadius, x + width, y + height - roundRadius);
                gp.AddArc(x + width - roundRadius * 2, y + height - 2 * roundRadius, roundRadius * 2, roundRadius * 2, 0, 90);
                gp.AddLine(x + roundRadius, y + height, x + width - roundRadius, y + height);
                gp.AddArc(x, y + height - 2 * roundRadius, roundRadius * 2, roundRadius * 2, 90, 90);
                gp.AddLine(x, y + roundRadius, x, y + height - roundRadius);
            }
            return gp;
        }
        //画圆角矩形，返回GraphicsPath
        public GraphicsPath GetRoundRect(Rectangle r, float roundRadius, bool halfRound)
        {
            float x = r.Left;
            float y = r.Top;
            float width = r.Width;
            float height = r.Height;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, roundRadius * 2, roundRadius * 2, 180, 90);
            gp.AddLine(x + roundRadius, y, x + width - roundRadius, y);
            gp.AddArc(x + width - roundRadius * 2, y, roundRadius * 2, roundRadius * 2, 270, 90);
            if (halfRound)
            {
                gp.AddLine(x + width, y + roundRadius, x + width, y + height);
                gp.AddLine(x + width, y + height, x, y + height);
                gp.AddLine(x, y + height, x, y + roundRadius);
            }
            else
            {
                gp.AddLine(x + width, y + roundRadius, x + width, y + height - roundRadius);
                gp.AddArc(x + width - roundRadius * 2, y + height - 2 * roundRadius, roundRadius * 2, roundRadius * 2, 0, 90);
                gp.AddLine(x + roundRadius, y + height, x + width - roundRadius, y + height);
                gp.AddArc(x, y + height - 2 * roundRadius, roundRadius * 2, roundRadius * 2, 90, 90);
                gp.AddLine(x, y + roundRadius, x, y + height - roundRadius);
            }
            return gp;
        }
        //返回圆角矩形的GraphicsPash对象
        public GraphicsPath GetRoundRect(float x, float y, float width, float height, float roundRadius, string action)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, roundRadius * 2, roundRadius * 2, 180, 90);
            if (action == "Quad")
            {
                gp.AddLine(x + roundRadius, y, x + width, y);
                gp.AddLine(x + width, y, x + width, y + height);
            }
            else
            {
                gp.AddLine(x + roundRadius, y, x + width - roundRadius, y);
                gp.AddArc(x + width - roundRadius * 2, y, roundRadius * 2, roundRadius * 2, 270, 90);
            }
            if (action == "Half" || action == "Quad")
            {
                gp.AddLine(x + width, y + roundRadius, x + width, y + height);
                gp.AddLine(x + width, y + height, x, y + height);
                gp.AddLine(x, y + height, x, y + roundRadius);
            }
            else
            {
                gp.AddLine(x + width, y + roundRadius, x + width, y + height - roundRadius);
                gp.AddArc(x + width - roundRadius * 2, y + height - 2 * roundRadius, roundRadius * 2, roundRadius * 2, 0, 90);
                gp.AddLine(x + roundRadius, y + height, x + width - roundRadius, y + height);
                gp.AddArc(x, y + height - 2 * roundRadius, roundRadius * 2, roundRadius * 2, 90, 90);
                gp.AddLine(x, y + roundRadius, x, y + height - roundRadius);
            }
            return gp;
        }


        //初始化图形数据
        private decimal[][] RawDatas;
        private float[][] IntDatas;
        private float MaxData = 100;
        private float MinData = 0;
        private float BaseLineXInt = 0;
        private int MinCount = 0;
        private int MaxCount = 0;
        public string[] AxisX;
        private bool DataBound = false;
        //横坐标的标识文字数据
        public string[] GroupTitle;
        public void InitializeData(ArrayList[] ChartData, ArrayList XLabel, ArrayList ColorGuider)
        {
            /**********  ColorStyle set *****************/
            switch (this.Fill.ColorStyle)
            {
                case ColorStyles.Breeze: this.Breeze.CopyTo(this.BarBrushColor, 0); break;
                case ColorStyles.Aurora: this.Aurora.CopyTo(this.BarBrushColor, 0); break;
                case ColorStyles.StarryNight: this.StarryNight.CopyTo(this.BarBrushColor, 0); break;
            }
            switch (this.Stroke.ColorStyle)
            {
                case ColorStyles.Breeze: this.Breeze.CopyTo(this.BarPenColor, 0); break;
                case ColorStyles.Aurora: this.Aurora.CopyTo(this.BarPenColor, 0); break;
                case ColorStyles.StarryNight: this.StarryNight.CopyTo(this.BarPenColor, 0); break;
            }
            if (!this.Fill.Color1.IsEmpty)
                this.BarBrushColor[0] = this.Fill.Color1;
            if (!this.Fill.Color2.IsEmpty)
                this.BarBrushColor[1] = this.Fill.Color2;
            if (!this.Fill.Color3.IsEmpty)
                this.BarBrushColor[2] = this.Fill.Color3;
            if (!this.Stroke.Color1.IsEmpty)
                this.BarPenColor[0] = this.Stroke.Color1;
            if (!this.Stroke.Color2.IsEmpty)
                this.BarPenColor[1] = this.Stroke.Color2;
            if (!this.Stroke.Color3.IsEmpty)
                this.BarPenColor[2] = this.Stroke.Color3;
            /********************************************/

            int ImageH = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2));
            int ChartTop = 60;
            int ChartBottom = 40;
            int ChartH = ImageH - ChartTop - ChartBottom;
            if (!this.ChartTitle.Show)
            {
                ChartH += ChartTop - 27;
                ChartTop = 27;
            }

            /******************************************/

            if (Site != null)
            {
                RawDatas = new decimal[3][];
                if (this.GroupSize == 0)
                    this.GroupSize = 3;
                RawDatas[0] = new decimal[] { 75, 61, 75, 90 };
                RawDatas[1] = new decimal[] { 98, 21, 65, 48 };
                RawDatas[2] = new decimal[] { 61, 98, 32, 66 };
                //获得化坐标标识
                MaxCount = (int)GetMax(new float[] { RawDatas[0].Length, RawDatas[0].Length, RawDatas[0].Length });
                MinCount = MaxCount;
                AxisX = new string[MaxCount];
                for (int i = 0; i < MaxCount; i++)
                {
                    AxisX[i] = (i + 1).ToString();
                }
                this.XLabels.UnitText= "Month"; this.YLabels.UnitText = "%";
                GroupTitle = new string[this.GroupSize];
                for (int i = 0; i < this.GroupSize; i++)
                    GroupTitle[i] = "Sales" + i.ToString();
            }
            else
            {//从页面传来的ArrayList数据转存到Float数组中
                if (ChartData != null)
                {
                    int ArrayCount = ChartData.Length;
                    //如果没有设置MultiBars属性，则为数据Array的个数
                    if (this.GroupSize == 0 || this.GroupSize > ArrayCount)
                        this.GroupSize = ArrayCount;
                    float[] SizeArray = new float[ArrayCount];
                    for (int s = 0; s < ArrayCount; s++)
                    {
                        SizeArray[s] = ChartData[s].Count;
                    }
                    //Max ArraySize and Min ArraySize
                    MaxCount = (int)GetMax(SizeArray);
                    MinCount = (int)GetMin(SizeArray);
                    RawDatas = new decimal[ArrayCount][];
                    //取data进Rawdatas
                    for (int l = 0; l < ArrayCount; l++)
                    {
                        RawDatas[l] = new decimal[MaxCount];
                        for (int c = 0; c < MaxCount; c++)
                        {
                            //if (ChartData[l] != null && c < ChartData[l].Count)
                            if(ChartData[l]!=null)
                            {
                                try
                                {
                                    RawDatas[l][c] = decimal.Parse(ChartData[l][c].ToString());
                                }
                                catch (Exception ee)
                                {
                                    RawDatas[l][c] = -0.830213M;
                                }
                            }
                            else
                                RawDatas[l][c] = -0.830213M;
                        }
                    }
                    //取X坐标标签进AxisX
                    AxisX = new string[MaxCount];
                    if (XLabel != null)
                    {
                        for (int i = 0; i < MaxCount; i++)
                        {
                            if (i >= XLabel.Count)
                                AxisX[i] = "null";
                            else
                                AxisX[i] = XLabel[i].ToString();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < MaxCount; i++)
                        {
                            AxisX[i] = (i + 1).ToString();
                        }
                    }
                    //取图例名称进入GroupTitle
                    if (ColorGuider != null)
                    {
                        GroupTitle = new string[this.GroupSize];
                        for (int i = 0; i < this.GroupSize; i++)
                        {
                            if (i >= ColorGuider.Count)
                                GroupTitle[i] = "null";
                            else
                                GroupTitle[i] = ColorGuider[i].ToString();
                        }
                    }
                }
            }

            //取得纵坐标的最大值，如果没有自定义，则默认数据数组中的最大数据
            //float MaxData;
            if (this.MaxValueY != 0)
                MaxData = (float)this.MaxValueY;
            else
            {
                int GroupSize = this.GroupSize;
                float[] MaxDataArray = new float[GroupSize];
                for (int gs = 0; gs < GroupSize; gs++)
                {
                    MaxDataArray[gs] = GetMax(RawDatas[gs]);
                }
                MaxData = GetMax(MaxDataArray);
                MaxData = GetBond(MaxData);
            }
            if (MaxData == 0)
                MaxData = 1;
            //取得纵坐标最小值，如果没有定义则默认为0
            {
                int GroupSize = this.GroupSize;
                float[] MinDataArray = new float[GroupSize];
                for (int gs = 0; gs < GroupSize; gs++)
                {
                    MinDataArray[gs] = GetMin(RawDatas[gs]);
                }
                MinData = GetMin(MinDataArray);
                MinData = GetBond(MinData);
                if (this.MinValueY != 0 || this.MinValueY<MinData)
                    MinData = (float)this.MinValueY;
            }
            if (this.BaseLineX == -0.830213)
                this.BaseLineX = MinData;
            BaseLineXInt = (float)((float)this.BaseLineX - MinData) * ChartH / (MaxData - MinData);
            //将Float数据转成在坐标轴范围内的Int
            IntDatas = new float[RawDatas.Length][];
            for (int m = 0; m < RawDatas.Length; m++)
            {
                IntDatas[m] = new float[RawDatas[m].Length];
                for (int n = 0; n < RawDatas[m].Length; n++)
                {
                    IntDatas[m][n] = (float)((float)RawDatas[m][n] - MinData) * ChartH / (MaxData - MinData);
                }
            }

            //如果没有数据，设置提示信息于this.ChartTitle.Text
            if (MaxCount == 0 && this.ShowErrorInfo)
                this.ChartTitle.Text = "No Data Found!";
            this.DataBound = true;
            //设置外观样式
            //SetAppearance();
            //移动颜色数组已达到改变当前颜色的目的
            ShiftColor(this.Fill.ShiftStep, "Fill");
            ShiftColor(this.Stroke.ShiftStep, "Stroke");

            //auto adjust inflate
            AdjustLabelMargin();
        }

        //Measure string长度,设置Inflate属性
        private void AdjustLabelMargin()
        {
            Bitmap b1 = new Bitmap(400, 200);
            Graphics g1 = Graphics.FromImage(b1);

            //adjust YLabels, inflate Left
            string LongString=YLabels.UnitText;
            if(YLabels.ValueFormat.Length > LongString.Length)
                LongString=YLabels.ValueFormat;
            if (MaxData.ToString(YLabels.ValueFormat).Length > LongString.Length)
                LongString = MaxData.ToString(YLabels.ValueFormat);
            if(MinData.ToString(YLabels.ValueFormat).Length > LongString.Length)
                LongString = MinData.ToString(YLabels.ValueFormat);
            SizeF sz=g1.MeasureString(LongString,YLabels.Font);
            if(this.ChartType == ChartTypes.HBar)
                this.InflateBottom = (int)(sz.Width - 40 + 5);
            else
                this.InflateLeft = (int)(sz.Width - 50 + 5);

            //adjust XLables, inflate bottom
            LongString = "";
            for (int i = 0; i < AxisX.Length; i++)
            {
                if (AxisX[i].Length > LongString.Length)
                    LongString = AxisX[i];
            }
            sz = g1.MeasureString(LongString, XLabels.Font);
            if (this.ChartType == ChartTypes.HBar)
                this.InflateLeft = (int)(sz.Width - 50 + 35);
                // this.InflateLeft = (int)(sz.Width - 50 + 5);
            else
                this.InflateBottom = (int)(sz.Width - 40 + 5);

            //adjust Color Guider, inflate right
            LongString = XLabels.UnitText;
            sz = g1.MeasureString(LongString, XLabels.Font);
            this.InflateRight = (int)(sz.Width);
        }

        //通过DataView绑定数据
        public void BindChartData(DataView DataSource)
        {
            if (DataSource != null)
            {
                ArrayList[] CData = new ArrayList[DataSource.Table.Columns.Count - 1];
                ArrayList XL = new ArrayList();
                ArrayList CG = new ArrayList();
                if (this.XLabels.UnitText == "XLabelsUnit")
                    this.XLabels.UnitText = DataSource.Table.Columns[0].ColumnName;
                for (int j = 0; j < DataSource.Table.Rows.Count; j++)
                {
                    XL.Add(DataSource[j][0].ToString());
                }
                for (int i = 0; i < DataSource.Table.Columns.Count - 1; i++)
                {
                    CData[i] = new ArrayList();
                    for (int j = 0; j < DataSource.Table.Rows.Count; j++)
                    {
                        CData[i].Add(DataSource[j][i + 1].ToString());
                    }
                    CG.Add(DataSource.Table.Columns[i + 1].ColumnName);
                }
                this.InitializeData(CData, XL, CG);
                DataSource.Dispose();
            }
        }
        //通过SqlDatasource绑定数据
        public void BindChartData(SqlDataSource DataSource)
        {
            if (DataSource != null)
            {
                DataSourceSelectArguments arg = new DataSourceSelectArguments();
                DataView dv = (DataView)DataSource.Select(arg);
                BindChartData(dv);
                DataSource.Dispose();
            }
        }
        //通过DataTable绑定
        public void BindChartData(DataTable DataSource)
        {
            if (DataSource != null)
            {
                ArrayList[] CData = new ArrayList[DataSource.Columns.Count - 1];
                ArrayList XL = new ArrayList();
                ArrayList CG = new ArrayList();
                if (this.XLabels.UnitText == "XLabelsUnit")
                    this.XLabels.UnitText = DataSource.Columns[0].ColumnName;
                for (int j = 0; j < DataSource.Rows.Count; j++)
                {
                    XL.Add(DataSource.Rows[j][0].ToString());
                }
                for (int i = 0; i < DataSource.Columns.Count - 1; i++)
                {
                    CData[i] = new ArrayList();
                    for (int j = 0; j < DataSource.Rows.Count; j++)
                    {
                        CData[i].Add(DataSource.Rows[j][i + 1].ToString());
                    }
                    CG.Add(DataSource.Columns[i + 1].ColumnName);
                }
                this.InitializeData(CData, XL, CG);
                DataSource.Dispose(); 
            }
        }
        //通过Dataset绑定数据
        public void BindChartData(DataSet DataSource)
        {
            if (DataSource != null)
            {
                BindChartData(DataSource.Tables[0]);
                DataSource.Dispose();
            }
        }


        //Color Style for Bar Chart
        private Color[] BarBrushColor =
        {
            Color.FromArgb(255, 214, 166, 231),Color.FromArgb(255, 127, 184, 210),Color.FromArgb(255, 231, 216, 166),
            Color.FromArgb(255, 180, 166, 231),Color.FromArgb(255, 181, 231, 166),Color.FromArgb(255, 231, 166, 166),
            Color.FromArgb(255, 180, 166, 231),Color.FromArgb(255, 198, 231, 166),Color.FromArgb(255, 231, 166, 226),
            Color.FromArgb(255, 205, 181, 157),Color.FromArgb(255, 157, 205, 200),Color.FromArgb(255, 222, 222, 222)
        };
        private Color[] BarPenColor =
        {
            Color.FromArgb(255, 120, 135, 136),Color.FromArgb(255, 120, 135, 136),Color.FromArgb(255, 120, 135, 136),
            Color.FromArgb(255, 120, 135, 136),Color.FromArgb(255, 120, 135, 136),Color.FromArgb(255, 120, 135, 136),
            Color.FromArgb(255, 120, 135, 136),Color.FromArgb(255, 120, 135, 136),Color.FromArgb(255, 120, 135, 136),
            Color.FromArgb(255, 120, 135, 136),Color.FromArgb(255, 120, 135, 136),Color.FromArgb(255, 120, 135, 136)
        };

        //Color Style Arrays
        public Color[] Breeze =
        {//轻快
            Color.FromArgb(255, 214, 166, 231),Color.FromArgb(255, 127, 184, 210),Color.FromArgb(255, 231, 216, 166),
            Color.FromArgb(255, 180, 166, 231),Color.FromArgb(255, 181, 231, 166),Color.FromArgb(255, 231, 166, 166),
            Color.FromArgb(255, 180, 166, 231),Color.FromArgb(255, 198, 231, 166),Color.FromArgb(255, 231, 166, 226),
            Color.FromArgb(255, 205, 181, 157),Color.FromArgb(255, 157, 205, 200),Color.FromArgb(255, 222, 222, 222)
        };
        public Color[] Aurora =
        {//绚烂
            Color.FromArgb(255, 25, 202, 45),Color.FromArgb(255, 244, 32, 32),Color.FromArgb(255, 37, 32, 242),
            Color.FromArgb(255, 240, 32, 242),Color.FromArgb(255, 240, 242, 32),Color.FromArgb(255, 32, 242, 235),
            Color.FromArgb(255, 242, 151, 32),Color.FromArgb(255, 146, 242, 32),Color.FromArgb(255, 146, 32, 242),
            Color.FromArgb(255, 32, 131, 242),Color.FromArgb(255, 242, 101, 32),Color.FromArgb(255, 22, 153, 245)
        };
        public Color[] StarryNight =
        {//厚重
            Color.FromArgb(255, 87, 14, 78),Color.FromArgb(255, 87, 55, 14),Color.FromArgb(255, 14, 60, 87),
            Color.FromArgb(255, 87, 35, 14),Color.FromArgb(255, 41, 87, 14),Color.FromArgb(255, 60, 14, 87),
            Color.FromArgb(255, 87, 14, 14),Color.FromArgb(255, 43, 14, 87),Color.FromArgb(255, 14, 86, 87),
            Color.FromArgb(255, 62, 87, 14),Color.FromArgb(255, 61, 3 , 56),Color.FromArgb(255, 3 , 33, 61)
        };

        //绘制2D坐标系
        private void PaintBackground(Graphics g, int ChartLeft, int ChartTop, int ChartW, int ChartH)
        {
            //填充白色背景
            int W = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2));
            int H = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2));
            g.FillRectangle(new SolidBrush(this.Background.Paper), 0, 0, W + this.InflateRight + this.InflateLeft, H + this.InflateBottom + this.InflateTop);
            //绘制背景
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //Draw Copyright on Chart
            if (this.ShowCopyright)
                g.DrawString(this.CopyrightText, new Font("Arial", 12, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.Gray, W - 130, 0);

            Color BackColor = this.Background.Highlight;
            Color BorderColor = this.Background.Lowlight;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;

            if (this.ChartType != ChartTypes.HBar)
            {
                for (int i = 0; i < this.YLabels.LabelCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        //g.FillRectangle(new SolidBrush(BackColor), ChartLeft, ChartTop, ChartW, ChartH / 5);
                        //g.FillRectangle(new SolidBrush(BackColor), ChartLeft, ChartTop + ChartH * 2 / 5, ChartW, ChartH / 5);
                        g.FillRectangle(new SolidBrush(BackColor), ChartLeft, ChartTop + ChartH * i / this.YLabels.LabelCount, ChartW, ChartH / this.YLabels.LabelCount);
                        //g.DrawRectangle(new Pen(BorderColor), ChartLeft, ChartTop + ChartH * 2 / 5, ChartW - 1, ChartH / 5 - 1);
                        //g.DrawRectangle(new Pen(BorderColor), ChartLeft, ChartTop, ChartW - 1, ChartH / 5 - 1);
                        g.DrawRectangle(new Pen(BorderColor), ChartLeft, ChartTop + ChartH * i / this.YLabels.LabelCount, ChartW - 1, ChartH / this.YLabels.LabelCount - 1);
                    }
                }


                for (int i = 0; i <= this.YLabels.LabelCount; i++)
                {
                    if (this.YLabels.Show)
                        g.DrawString((MinData + (MaxData - MinData) * (this.YLabels.LabelCount - i) / this.YLabels.LabelCount).ToString(this.YLabels.ValueFormat), this.YLabels.Font, new SolidBrush(this.YLabels.ForeColor), new Rectangle(0, ChartTop + ChartH * i / this.YLabels.LabelCount - 10, ChartLeft - 4, 20), sf);
                    if (i > 0)
                        g.DrawLine(Pens.Black, ChartLeft - 3, ChartTop + ChartH * i / this.YLabels.LabelCount, ChartLeft, ChartTop + ChartH * i / this.YLabels.LabelCount);
                }


                //绘制Spec line
                if (this.SpecLine.Show)
                {
                    if (this.SpecLine.YLimit)
                    {
                        Brush BR;
                        if (this.SpecLine.EnableTexture)
                            BR = new HatchBrush(this.SpecLine.TextureStyle, this.SpecLine.Color);
                        else
                            //BR = new SolidBrush(this.SpecLine.Color);
                            BR = new SolidBrush(Color.Red);
                        Pen SpenLinePen = new Pen(BR, this.SpecLine.Width);
                        if (this.SpecLine.LLoaded)
                        {
                            int LineHeight = ChartTop + ChartH -(int)((this.SpecLine.LowLimit - MinData) * ChartH / (MaxData - MinData));
                            g.DrawLine(SpenLinePen, ChartLeft - 3, LineHeight, ChartLeft + ChartW, LineHeight);
                            g.DrawString(this.SpecLine.LowLimit.ToString(), this.YLabels.Font, new SolidBrush(Color.Red), ChartLeft + ChartW, LineHeight - 5);
                        }
                        if (this.SpecLine.HLoaded)
                        {
                            int LineHeight = ChartTop + ChartH - (int)((this.SpecLine.HighLimit - MinData) * ChartH / (MaxData - MinData));
                            g.DrawLine(SpenLinePen, ChartLeft - 3, LineHeight, ChartLeft + ChartW, LineHeight);
                            g.DrawString(this.SpecLine.HighLimit.ToString(), this.YLabels.Font, new SolidBrush(Color.Red), ChartLeft + ChartW, LineHeight - 5);
                        }
                        if (this.SpecLine.MLoaded)
                        {
                            SpenLinePen.Color = Color.Blue;
                            SpenLinePen.DashStyle = DashStyle.Dash;
                            int LineHeight = ChartTop + ChartH - (int)((this.SpecLine.MeanValue - MinData) * ChartH / (MaxData - MinData));
                            g.DrawLine(SpenLinePen, ChartLeft - 3, LineHeight, ChartLeft + ChartW, LineHeight);
                            g.DrawString(this.SpecLine.MeanValue.ToString(), this.YLabels.Font, new SolidBrush(Color.Blue), ChartLeft + ChartW, LineHeight - 5);
                        }
                    }
                }
            }
            //绘制图表标题
            //g.DrawRectangle(Pens.Gray, ChartLeft + ChartW / 5, ChartTop-40, 200, 40);
            if (this.ChartTitle.Show)
            {
                sf.Alignment = StringAlignment.Center;
                g.DrawString(this.ChartTitle.Text, this.ChartTitle.Font, new SolidBrush(this.ChartTitle.ForeColor), new Rectangle(ChartLeft, ChartTop - 2 - (int)(g.MeasureString(this.ChartTitle.Text, this.ChartTitle.Font).Height) + this.ChartTitle.OffsetY, ChartW, (int)(g.MeasureString(this.ChartTitle.Text, this.ChartTitle.Font).Height)), sf);
            }
            //绘制色标
            if (GroupTitle != null && this.ColorGuider.Show)
            {
                for (int i = 0; i < GroupTitle.Length; i++)
                {
                    SolidBrush br;
                    //根据图标类型 定义色标笔刷
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar: br = new SolidBrush(BarBrushColor[i % 12]); break;
                        case ChartTypes.Line: br = new SolidBrush(BarPenColor[i % 12]); break;
                        //需要加其他类型的Brush
                        default: br = new SolidBrush(BarBrushColor[i % 12]); break;
                    }
                    //根据图表类型绘制色标
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar:
                            {
                                g.FillRectangle(br, ChartLeft + ChartW + 6, ChartTop + 14 * i + 4, 18, 8);
                                g.DrawRectangle(Pens.Gray, ChartLeft + ChartW + 6, ChartTop + 4 + 14 * i, 17, 7);
                            } break;
                        case ChartTypes.Line:
                            {
                                g.DrawLine(new Pen(br), ChartLeft + ChartW + 6, ChartTop + 14 * i + 8, ChartLeft + ChartW + 24, ChartTop + 14 * i + 8);
                                if (this.LineConnectionType == LineConnectionTypes.Square)
                                    g.FillRectangle(br, ChartLeft + ChartW + 11, ChartTop + 14 * i + 4, 8, 8);
                                else if (this.LineConnectionType == LineConnectionTypes.Round)
                                {
                                    g.SmoothingMode = SmoothingMode.AntiAlias;
                                    g.FillEllipse(br, ChartLeft + ChartW + 11, ChartTop + 14 * i + 4, 8, 8);
                                }
                            } break;
                        default:
                            {
                                g.FillRectangle(br, ChartLeft + ChartW + 6, ChartTop + 14 * i + 4, 18, 8);
                                g.DrawRectangle(Pens.Gray, ChartLeft + ChartW + 6, ChartTop + 4 + 14 * i, 17, 7);
                            } break;
                    }


                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.DrawString(GroupTitle[i], this.ColorGuider.Font, new SolidBrush(this.ColorGuider.ForeColor), ChartLeft + ChartW + 28, ChartTop + 1 + 14 * i);
                    br.Dispose();
                }
            }


            sf.Dispose();
        }

        //绘制3D坐标系
        private void PaintBackground3D(Graphics g, int ChartLeft, int ChartTop, int ChartW, int ChartH)
        {
            //填充白色背景
            int W = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2));
            int H = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2));
            g.FillRectangle(new SolidBrush(this.Background.Paper), 0, 0, W + this.InflateRight + this.InflateLeft, H + this.InflateBottom + this.InflateTop);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //Draw Copyright on Chart
            if (this.ShowCopyright)
                g.DrawString(this.CopyrightText, new Font("Arial", 12, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.Gray, W - 130, 0);
            Rectangle ChartRect = new Rectangle(ChartLeft, ChartTop, ChartW, ChartH);
            Rectangle ForeRect = ChartRect;

            int Depth3D = this.Depth3D;
            ForeRect.Offset(-Depth3D, Depth3D);//need to build new attributes
            SolidBrush BackBrush = new SolidBrush(this.Background.Highlight);
            Pen BackPen = new Pen(this.Background.Lowlight);
            //g.FillRectangle(BackBrush, ChartRect);

            //绘制3D透视效果用的Path
            GraphicsPath gpax = new GraphicsPath();
            gpax.Reset();

            //绘制背景
            Color BackColor = Color.FromArgb(80, 238, 237, 238);
            Color BorderColor = Color.FromArgb(255, 220, 220, 220);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;
            if (this.ChartType != ChartTypes.HBar)
            {
                for (int i = 0; i < this.YLabels.LabelCount; i++)
                {
                    //g.FillRectangle(BackBrush, ChartLeft, ChartTop, ChartW, ChartH / 5);
                    //g.DrawRectangle(BackPen, ChartLeft, ChartTop, ChartW, ChartH / 5);
                    //gpax.StartFigure();
                    //gpax.AddLine(ChartLeft, ChartTop, ChartLeft - Depth3D, ChartTop + Depth3D);
                    //gpax.AddLine(ChartLeft - Depth3D, ChartTop + Depth3D, ChartLeft - Depth3D, ChartTop + Depth3D + ChartH / 5);
                    //gpax.AddLine(ChartLeft - Depth3D, ChartTop + Depth3D + ChartH / 5, ChartLeft, ChartTop + ChartH / 5);
                    //gpax.AddLine(ChartLeft, ChartTop + ChartH / 5, ChartLeft, ChartTop);

                    //g.FillRectangle(BackBrush, ChartLeft, ChartTop + ChartH * 2 / 5, ChartW, ChartH / 5);
                    //g.DrawRectangle(BackPen, ChartLeft, ChartTop + ChartH * 2 / 5, ChartW, ChartH / 5);
                    //gpax.StartFigure();
                    //gpax.AddLine(ChartLeft, ChartTop + ChartH * 2 / 5, ChartLeft - Depth3D, ChartTop + ChartH * 2 / 5 + Depth3D);
                    //gpax.AddLine(ChartLeft - Depth3D, ChartTop + ChartH * 2 / 5 + Depth3D, ChartLeft - Depth3D, ChartTop + ChartH * 2 / 5 + Depth3D + ChartH / 5);
                    //gpax.AddLine(ChartLeft - Depth3D, ChartTop + ChartH * 2 / 5 + Depth3D + ChartH / 5, ChartLeft, ChartTop + ChartH * 2 / 5 + ChartH / 5);
                    //gpax.AddLine(ChartLeft, ChartTop + ChartH * 2 / 5 + ChartH / 5, ChartLeft, ChartTop + ChartH * 2 / 5);
                    if (i % 2 == 0)
                    {
                        g.FillRectangle(BackBrush, ChartLeft, ChartTop + ChartH * i / this.YLabels.LabelCount, ChartW, ChartH / this.YLabels.LabelCount);
                        g.DrawRectangle(BackPen, ChartLeft, ChartTop + ChartH * i / this.YLabels.LabelCount, ChartW, ChartH / this.YLabels.LabelCount);
                        gpax.StartFigure();
                        gpax.AddLine(ChartLeft, ChartTop + ChartH * i / this.YLabels.LabelCount, ChartLeft - Depth3D, ChartTop + ChartH * i / this.YLabels.LabelCount + Depth3D);
                        gpax.AddLine(ChartLeft - Depth3D, ChartTop + ChartH * i / this.YLabels.LabelCount + Depth3D, ChartLeft - Depth3D, ChartTop + ChartH * i / this.YLabels.LabelCount + Depth3D + ChartH / this.YLabels.LabelCount);
                        gpax.AddLine(ChartLeft - Depth3D, ChartTop + ChartH * i / this.YLabels.LabelCount + Depth3D + ChartH / this.YLabels.LabelCount, ChartLeft, ChartTop + ChartH * i / this.YLabels.LabelCount + ChartH / this.YLabels.LabelCount);
                        gpax.AddLine(ChartLeft, ChartTop + ChartH * i / this.YLabels.LabelCount + ChartH / this.YLabels.LabelCount, ChartLeft, ChartTop + ChartH * i / this.YLabels.LabelCount);
                   
                    }                
                }
                g.FillPath(BackBrush, gpax);
                g.DrawPath(BackPen, gpax);
                //绘制纵坐标

                for (int i = 0; i <= this.YLabels.LabelCount; i++)
                {
                    if (this.YLabels.Show)
                        g.DrawString((this.MinValueY + (MaxData - this.MinValueY) * (this.YLabels.LabelCount - i) / this.YLabels.LabelCount).ToString(this.YLabels.ValueFormat), this.YLabels.Font, new SolidBrush(this.YLabels.ForeColor), new Rectangle(-Depth3D, ChartTop + ChartH * i / this.YLabels.LabelCount - 10 + Depth3D, ChartLeft - 4, 20), sf);
                    g.DrawLine(Pens.Black, ForeRect.Left - 3, ForeRect.Top + ChartH * i / this.YLabels.LabelCount, ForeRect.Left, ForeRect.Top + ChartH * i / this.YLabels.LabelCount);
                }
            }
            //绘制图表标题
            //g.DrawRectangle(Pens.Gray, ChartLeft + ChartW / 5, ChartTop-40, 200, 40);
            if (this.ChartTitle.Show)
            {
                sf.Alignment = StringAlignment.Center;
                g.DrawString(this.ChartTitle.Text, this.ChartTitle.Font, new SolidBrush(this.ChartTitle.ForeColor), new Rectangle(ChartLeft, ChartTop - 2 - (int)(g.MeasureString(this.ChartTitle.Text, this.ChartTitle.Font).Height) + this.ChartTitle.OffsetY, ChartW, (int)(g.MeasureString(this.ChartTitle.Text, this.ChartTitle.Font).Height)), sf);
            }
            //绘制色标
            if (GroupTitle != null && this.ColorGuider.Show)
            {
                for (int i = 0; i < GroupTitle.Length; i++)
                {
                    SolidBrush br;
                    //根据图标类型 定义色标笔刷
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar: br = new SolidBrush(BarBrushColor[i % 12]); break;
                        case ChartTypes.Line: br = new SolidBrush(BarPenColor[i % 12]); break;
                        //需要加其他类型的Brush
                        default: br = new SolidBrush(BarBrushColor[i % 12]); break;
                    }
                    //根据图表类型绘制色标
                    switch (this.ChartType)
                    {
                        case ChartTypes.Bar:
                            {
                                g.FillRectangle(br, ChartLeft + ChartW + 6, ChartTop + 14 * i + 4, 18, 8);
                                g.DrawRectangle(Pens.Gray, ChartLeft + ChartW + 6, ChartTop + 4 + 14 * i, 17, 7);
                            } break;
                        case ChartTypes.Line:
                            {
                                g.DrawLine(new Pen(br), ChartLeft + ChartW + 6, ChartTop + 14 * i + 8, ChartLeft + ChartW + 24, ChartTop + 14 * i + 8);
                                if (this.LineConnectionType == LineConnectionTypes.Square)
                                    g.FillRectangle(br, ChartLeft + ChartW + 11, ChartTop + 14 * i + 4, 8, 8);
                                else if (this.LineConnectionType == LineConnectionTypes.Round)
                                {
                                    g.SmoothingMode = SmoothingMode.AntiAlias;
                                    g.FillEllipse(br, ChartLeft + ChartW + 11, ChartTop + 14 * i + 4, 8, 8);
                                }
                            } break;
                        default:
                            {
                                g.FillRectangle(br, ChartLeft + ChartW + 6, ChartTop + 14 * i + 4, 18, 8);
                                g.DrawRectangle(Pens.Gray, ChartLeft + ChartW + 6, ChartTop + 4 + 14 * i, 17, 7);
                            } break;
                    }


                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.DrawString(GroupTitle[i], this.ColorGuider.Font, new SolidBrush(this.ColorGuider.ForeColor), ChartLeft + ChartW + 28, ChartTop + 1 + 14 * i);
                    br.Dispose();
                }
            }
            sf.Dispose();

            g.DrawRectangle(Pens.Gray, ChartRect);
            //
            gpax.Reset();
            gpax.StartFigure();
            gpax.AddLine(ChartRect.Left, ChartRect.Top, ForeRect.Left, ForeRect.Top);
            gpax.AddLine(ForeRect.Left, ForeRect.Top, ForeRect.Left, ForeRect.Top + ForeRect.Height);
            gpax.AddLine(ForeRect.Left, ForeRect.Top + ForeRect.Height, ChartRect.Left, ChartRect.Top + ChartRect.Height);
            gpax.AddLine(ChartRect.Left, ChartRect.Top + ChartRect.Height, ChartRect.Left, ChartRect.Top);
            gpax.StartFigure();
            gpax.AddLine(ChartRect.Left, ChartRect.Top + ChartRect.Height, ForeRect.Left, ForeRect.Top + ForeRect.Height);
            gpax.AddLine(ForeRect.Left, ForeRect.Top + ForeRect.Height, ForeRect.Left + ForeRect.Width, ForeRect.Top + ForeRect.Height);
            gpax.AddLine(ForeRect.Left + ForeRect.Width, ForeRect.Top + ForeRect.Height, ChartRect.Left + ChartRect.Width, ChartRect.Top + ChartRect.Height);
            gpax.AddLine(ChartRect.Left + ChartRect.Width, ChartRect.Top + ChartRect.Height, ChartRect.Left, ChartRect.Top + ChartRect.Height);
            g.DrawPath(Pens.Gray, gpax);
            gpax.Dispose();

            BackBrush.Dispose();
            BackPen.Dispose();
        }

        //ShiftColor函数
        private void ShiftColor(int ShiftSteps, string FillorStroke)
        {
            Color[] ColorArray = new Color[12];
            if (FillorStroke == "Fill")
                ColorArray = this.BarBrushColor;
            else if (FillorStroke == "Stroke")
                ColorArray = this.BarPenColor;

            Color tempColor;
            ShiftSteps = ShiftSteps % 12;
            for (int i = 0; i < ShiftSteps; i++)
            {
                tempColor = ColorArray[0];
                for (int j = 0; j < ColorArray.Length - 1; j++)
                {
                    ColorArray[j] = ColorArray[j + 1];
                }
                ColorArray[ColorArray.Length - 1] = tempColor;
            }
        }

        //设置图标外观样式
        private void SetAppearance()
        {
            string[] AppStyle = this.AppearanceStyle.ToString().Split('_');

            //根据第一个字符串设置图表类型
            switch (AppStyle[0])
            {
                case "Bar": this.ChartType = ChartTypes.Bar; break;
                case "Line":
                    {
                        this.ChartType = ChartTypes.Line;
                        this.Depth3D = 20;
                    } break;
                case "Pie":
                    {
                        this.ChartType = ChartTypes.Pie;
                        this.Stroke.Color1 = Color.White;
                    } break;
                case "Stack": this.ChartType = ChartTypes.Stack; break;
                case "HBar": this.ChartType = ChartTypes.HBar; break;
                case "Trend":
                    {
                        this.ChartType = ChartTypes.Trend;
                        this.Tips.Show = false;
                        this.Depth3D = 20;
                    } break;
                case "Histo":
                    {
                        this.ChartType = ChartTypes.Histo;
                    } break;
                //Add other ChartType here
            }
            //根据第二个字符串设置2D还是3D
            switch (AppStyle[1])
            {
                case "2D": this.Dimension = ChartDimensions.Chart2D; break;
                case "3D": this.Dimension = ChartDimensions.Chart3D; break;
            }
            //根据第三个字符串选择颜色数组
            switch (AppStyle[2])
            {
                case "Breeze":
                    {
                        this.Fill.ColorStyle = ColorStyles.Breeze;
                        this.Breeze.CopyTo(BarBrushColor, 0);
                        if (this.ChartType == ChartTypes.Line || this.ChartType == ChartTypes.Trend)
                        {
                            this.Stroke.ColorStyle = ColorStyles.Breeze;
                            this.Breeze.CopyTo(BarPenColor, 0);
                        }
                    } break;
                case "Aurora":
                    {
                        this.Fill.ColorStyle = ColorStyles.Aurora;
                        this.Aurora.CopyTo(BarBrushColor, 0);
                        if (this.ChartType == ChartTypes.Line || this.ChartType == ChartTypes.Trend)
                        {
                            this.Stroke.ColorStyle = ColorStyles.Aurora;
                            this.Aurora.CopyTo(BarPenColor, 0);
                        }
                    } break;
                case "StarryNight":
                    {
                        this.StarryNight.CopyTo(BarBrushColor, 0);
                        this.Fill.ColorStyle = ColorStyles.StarryNight;
                        if (this.ChartType == ChartTypes.Line || this.ChartType == ChartTypes.Trend)
                        {
                            this.Stroke.ColorStyle = ColorStyles.StarryNight;
                            this.StarryNight.CopyTo(BarPenColor, 0);
                        }
                    } break;
            }

            //Bar_2D_Breeze_NoCrystal_NoGlow
            //根据第四个字符串设置水晶效果
            switch (AppStyle[3])
            {
                case "NoCrystal":
                    {
                        this.Crystal.Enable = false;
                        //Pie chart settings
                        if (this.ChartType == ChartTypes.Pie)
                        {
                            this.Stroke.Width = 3;
                        }
                        //3D Bar chart setting
                        if (this.Dimension == ChartDimensions.Chart3D)
                        {
                            this.Alpha3D = 160;
                        }
                    } break;
                case "FlatCrystal":
                    {
                        this.Crystal.Enable = true;
                        this.Crystal.CoverFull = true;
                        this.Crystal.Direction = Direction.TopBottom;
                        if (this.ChartType == ChartTypes.HBar)
                        {
                            this.Crystal.Direction = Direction.RightLeft;
                        }
                        //this.Crystal.Contraction = 2;
                        switch (this.Fill.ColorStyle)
                        {
                            case ColorStyles.Breeze: this.Crystal.Contraction = 1; break;
                            case ColorStyles.Aurora: this.Crystal.Contraction = 1; break;
                            case ColorStyles.StarryNight: this.Crystal.Contraction = 3; break;
                        }
                        //Pie chart settings
                        if (this.ChartType == ChartTypes.Pie)
                        {
                            this.Stroke.Width = 0;
                        }
                        //3D Bar chart setting
                        if (this.Dimension == ChartDimensions.Chart3D)
                        {
                            this.Alpha3D = 200;
                            this.Crystal.Direction = Direction.BottomTop;
                            this.Crystal.Contraction = 1;
                        }
                    } break;
                case "GlassCrystal":
                    {
                        this.Crystal.Enable = true;
                        this.Crystal.CoverFull = false;
                        this.Crystal.Direction = Direction.LeftRight;
                        if (this.ChartType == ChartTypes.HBar)
                        {
                            this.Crystal.Direction = Direction.TopBottom;
                        }
                        if (this.Fill.ColorStyle == ColorStyles.Aurora)
                            this.RoundRectangle = false;
                        else
                            this.RoundRectangle = true;
                        this.RoundRadius = 3;
                        for (int i = 0; i < this.GroupSize; i++)
                        {
                            BarPenColor[i % 12] = ColorTranslator.FromHtml("");
                        }
                        //Pie chart settings
                        if (this.ChartType == ChartTypes.Pie)
                        {
                            this.Stroke.Width = 0;
                        }
                    } break;
                case "ThickRound":
                    {
                        this.Stroke.Width = 8;
                        this.LineConnectionRadius = 18;
                        this.LineConnectionType = LineConnectionTypes.Round;
                    } break;
                case "ThickSquare":
                    {
                        this.Stroke.Width = 8;
                        this.LineConnectionRadius = 18;
                        this.LineConnectionType = LineConnectionTypes.Square;
                    } break;
                case "ThinRound":
                    {
                        this.Stroke.Width = 2;
                        this.LineConnectionRadius = 8;
                        this.LineConnectionType = LineConnectionTypes.Round;
                    } break;
                case "ThinSquare":
                    {
                        this.Stroke.Width = 2;
                        this.LineConnectionRadius = 8;
                        this.LineConnectionType = LineConnectionTypes.Square;
                    } break;
            }
            //针对3D Line 对第四个参数重新设置
            if ((this.ChartType == ChartTypes.Line || this.ChartType== ChartTypes.Trend) && (this.Dimension == ChartDimensions.Chart3D))
            {
                this.Stroke.Width = 1;
                this.Alpha3D = 100;
                if (AppStyle[3].IndexOf("NoCrystal") > -1)
                {
                    this.Crystal.Enable = false;
                }
                if (AppStyle[3].IndexOf("FlatCrystal") > -1)
                {
                    this.Crystal.Enable = true;
                    this.Crystal.CoverFull = true;
                    this.Crystal.Direction = Direction.LeftRight;
                }
                if (AppStyle[3].IndexOf("GlassCrystal") > -1)
                {
                    this.Crystal.Enable = true;
                    this.Crystal.CoverFull = true;
                    this.Crystal.Direction = Direction.TopBottom;
                }
                if (AppStyle[3].IndexOf("None") > -1)
                {
                    this.LineConnectionType = LineConnectionTypes.None;
                    this.LineConnectionRadius = 0;
                }
                if (AppStyle[3].IndexOf("Round") > -1)
                {
                    this.LineConnectionType = LineConnectionTypes.Round;
                    this.LineConnectionRadius = 6;
                    this.Stroke.Width = 2;
                }
                if (AppStyle[3].IndexOf("Square") > -1)
                {
                    this.LineConnectionType = LineConnectionTypes.Square;
                    this.LineConnectionRadius = 10;
                }
            }
            //根据第五个字符串设置投影参数
            switch (AppStyle[4])
            {
                case "NoGlow": this.Shadow.Enable = false; break;
                case "Glow":
                    {
                        this.Shadow.Enable = true;
                        switch (this.ChartType)
                        {
                            case ChartTypes.Bar:
                                {
                                    if (this.Fill.ColorStyle == ColorStyles.StarryNight)
                                        this.Shadow.Radius = 5;
                                    else
                                        this.Shadow.Radius = 3;
                                } break;
                            case ChartTypes.Line:
                                {
                                    if (AppStyle[3].Contains("Thin"))
                                    {
                                        this.Shadow.Radius = 2;
                                        this.Shadow.Distance = 2;
                                    }
                                    else
                                    {
                                        this.Shadow.Radius = 6;
                                        this.Shadow.Distance = 4;
                                    }
                                } break;
                        }

                    } break;
            }
            //根据第六个参数设置边框
            //置白色边框颜色数组
            if (AppStyle[5] != "NoBorder" && AppStyle[5] != "None")
            {
                for (int i = 0; i < 12; i++)
                {
                    BarPenColor[i % 12] = Color.White;
                }
            }
            switch (AppStyle[5])
            {
                case "NoBorder":
                    {
                        if (this.ChartType != ChartTypes.Line && this.ChartType != ChartTypes.Trend)
                            this.Stroke.Width = 0;
                        if (this.ChartType == ChartTypes.Bar && this.Dimension == ChartDimensions.Chart3D)
                        {
                            this.Stroke.Width = 1;
                            this.Stroke.ColorStyle = this.Fill.ColorStyle;
                        }
                    } break;
                case "WhiteBorder":
                    {
                        switch (this.ChartType)
                        {
                            case ChartTypes.Bar:
                                {
                                    if (this.Dimension == ChartDimensions.Chart2D)
                                    {
                                        this.Stroke.Width = 4;
                                        this.Crystal.Contraction = 3;
                                        this.Shadow.Radius = 6;
                                        this.RoundRectangle = true;
                                    }
                                    else
                                    {
                                        this.Stroke.Width = 1;
                                        this.Crystal.Contraction = 3;
                                    }
                                } break;
                            case ChartTypes.Pie:
                                {
                                    this.Stroke.Width = 6;
                                    this.Shadow.Radius = 10;
                                } break;

                        }
                        this.Shadow.Alpha = 255;
                    } break;
                case "TextureBorder":
                    {
                        switch (this.ChartType)
                        {
                            case ChartTypes.Bar:
                                {
                                    this.Stroke.Width = 4;
                                    this.Crystal.Contraction = 0;
                                    this.Shadow.Radius = 5;
                                    this.RoundRectangle = false;
                                    this.Shadow.Alpha = 255;
                                    this.Stroke.TextureEnable = true;
                                } break;
                        }
                    } break;

            }


        }    
        

        /***************************** 基本绘图函数 *********************************/
        private void DrawBarBase2D(Graphics g,SolidBrush BarBrush,Pen BarPen, int BarLeft, int BarTop, int BarW, int BarH)
        {
            if (this.Shadow.Enable)
            {
                TextShadow tShadow = new TextShadow();
                tShadow.Radius = this.Shadow.Radius;
                tShadow.Distance = this.Shadow.Distance;
                tShadow.Alpha = this.Shadow.Alpha;
                tShadow.Angle = this.Shadow.Angle;
                string ShadowAction = "Fill";
                if (this.Shadow.Hollow)
                    ShadowAction = "Draw";
                tShadow.DropShadow(g, new Rectangle(BarLeft, BarTop, BarW, BarH), this.Shadow.Color, ShadowAction, "Rectangle", null, 1);
            }
            if (this.RoundRectangle)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                if (this.RoundRadius < 1)
                    this.RoundRadius = 1;

                if(this.ChartType== ChartTypes.HBar)
                    g.FillPath(BarBrush, GetRoundRect(BarLeft, BarTop, BarW, BarH, this.RoundRadius, false));
                else
                    g.FillPath(BarBrush, GetRoundRect(BarLeft, BarTop, BarW, BarH, this.RoundRadius, true));

                if (this.Stroke.Width > 0)
                {
                    if (this.ChartType == ChartTypes.HBar)
                        g.DrawPath(BarPen, GetRoundRect(BarLeft, BarTop, BarW, BarH, this.RoundRadius, false));
                    else
                        g.DrawPath(BarPen, GetRoundRect(BarLeft, BarTop, BarW, BarH, this.RoundRadius, true));
                }
                g.SmoothingMode = SmoothingMode.None;
            }
            else
            {
                g.FillRectangle(BarBrush, BarLeft, BarTop, BarW, BarH);
                if (this.Stroke.Width > 0)
                    g.DrawRectangle(BarPen, BarLeft, BarTop, BarW, BarH);
            }
        }

        private void DrawBarBase3D(Graphics g, SolidBrush BarBrush, Pen BarPen, int BarLeft, int BarTop, int BarW, int BarH,int Depth)
        {
            GraphicsPath gpbar = new GraphicsPath();
            //上表面
            gpbar.StartFigure();
            gpbar.AddLine(BarLeft, BarTop, BarLeft - Depth, BarTop + Depth);
            gpbar.AddLine(BarLeft - Depth, BarTop + Depth, BarLeft - Depth + BarW, BarTop + Depth);
            gpbar.AddLine(BarLeft - Depth + BarW, BarTop + Depth, BarLeft + BarW, BarTop);
            gpbar.AddLine(BarLeft + BarW, BarTop, BarLeft, BarTop);
            g.FillPath(BarBrush, gpbar);
            g.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), gpbar);
            if (this.Stroke.Width > 0)
            {
                g.DrawPath(BarPen, gpbar);
            }

            //右表面
            gpbar.Reset();
            gpbar.StartFigure();
            gpbar.AddLine(BarLeft + BarW, BarTop, BarLeft + BarW - Depth, BarTop + Depth);
            gpbar.AddLine(BarLeft + BarW - Depth, BarTop + Depth, BarLeft + BarW - Depth, BarTop + Depth + BarH);
            gpbar.AddLine(BarLeft + BarW - Depth, BarTop + Depth + BarH, BarLeft + BarW, BarTop + BarH);
            gpbar.AddLine(BarLeft + BarW, BarTop + BarH, BarLeft + BarW, BarTop);
            g.FillPath(BarBrush, gpbar);
            g.FillPath(new SolidBrush(Color.FromArgb(40, Color.Black)), gpbar);
            if (this.Stroke.Width > 0)
            {
                g.DrawPath(BarPen, gpbar);
            }

            //前表面
            gpbar.Reset();
            gpbar.StartFigure();
            gpbar.AddLine(BarLeft - Depth, BarTop + Depth, BarLeft - Depth, BarTop + Depth + BarH);
            gpbar.AddLine(BarLeft - Depth, BarTop + Depth + BarH, BarLeft - Depth + BarW, BarTop + Depth + BarH);
            gpbar.AddLine(BarLeft - Depth + BarW, BarTop + Depth + BarH, BarLeft - Depth + BarW, BarTop + Depth);
            gpbar.AddLine(BarLeft - Depth + BarW, BarTop + Depth, BarLeft - Depth, BarTop + Depth);
            g.FillPath(BarBrush, gpbar);
            if (this.Stroke.Width > 0)
            {
                g.DrawPath(BarPen, gpbar);
            }

            gpbar.Dispose();
        }

        private void DrawBarCrystal(Graphics g, int BarLeft, int BarTop, int BarW, int BarH, int Depth)
        {
            Rectangle r = new Rectangle(BarLeft - Depth, BarTop + Depth, BarW, BarH);
            r.Inflate(-1 * this.Crystal.Contraction, -1 * this.Crystal.Contraction);
            //水晶效果是否铺满图形
            if (!this.Crystal.CoverFull)
            {
                Rectangle HalfBar = new Rectangle(BarLeft - Depth, BarTop + Depth, BarW / 2 + 1, BarH);
                if (this.ChartType== ChartTypes.HBar)
                {
                    HalfBar = new Rectangle(BarLeft - Depth, BarTop + Depth, BarW, BarH / 2 + 1);
                }
                r.Intersect(HalfBar);
            }
            //水晶高光区的方向
            Point p1; Point p2;
            switch (this.Crystal.Direction)
            {
                case Direction.LeftRight: { p1 = new Point(r.Left, 0); p2 = new Point(r.Left + r.Width + 1, 0); } break;
                case Direction.RightLeft: { p1 = new Point(r.Left + r.Width, 0); p2 = new Point(r.Left - 1, 0); } break;
                case Direction.TopBottom: { p1 = new Point(0, r.Top - 1); p2 = new Point(0, r.Top + r.Height); } break;
                case Direction.BottomTop: { p1 = new Point(0, r.Top + r.Height); p2 = new Point(0, r.Top - 1); } break;
                default: { p1 = new Point(r.Left, 0); p2 = new Point(r.Left + r.Width / 2, 0); } break;
            }
            LinearGradientBrush lgb = new LinearGradientBrush(p1, p2, Color.FromArgb(178, Color.White), Color.FromArgb(25, Color.White));
            if (this.RoundRectangle)
            {
                int rradius = this.RoundRadius - 2;
                if (rradius < 1)
                    rradius = 1;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillPath(lgb, GetRoundRect(r.Left, r.Top, r.Width, r.Height, rradius, "Full"));
                g.SmoothingMode = SmoothingMode.None;
            }
            else
            {
                g.FillRectangle(lgb, r.Left, r.Top, r.Width, r.Height);
            }
            lgb.Dispose();
        }

        private void DrawTips(Graphics g, string tip, int BarLeft, int BarTop, int BarW, int BarH, bool BelowX)
        {
            if (BelowX)
            {
                BarTop = BarTop + BarH + 15;
            }

            SizeF s = g.MeasureString(tip, this.Tips.Font);
            float rleft;
            if (BarW >= s.Width)
            {
                rleft = BarLeft + (BarW - s.Width) / 2;
            }
            else
            {
                rleft = BarLeft + BarW - s.Width;
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            if(this.ChartType == ChartTypes.Stack)
                g.DrawString(tip.ToString(), this.Tips.Font, new SolidBrush(this.Tips.ForeColor), new RectangleF(rleft, BarTop, s.Width, s.Height), sf);
            else
                g.DrawString(tip.ToString(), this.Tips.Font, new SolidBrush(this.Tips.ForeColor), new RectangleF(rleft, BarTop - 14, s.Width, s.Height), sf);
            
            sf.Dispose();
        }

        private void DrawXLine(Graphics g,Pen BackPen, int DP3, int ChartTop, int ChartH, int XPos, int XWidth)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(BackPen, XPos, ChartTop + ChartH, XPos, ChartTop);
            g.DrawLine(BackPen, XPos - DP3, ChartTop + ChartH + DP3, XPos, ChartTop + ChartH);
            g.SmoothingMode = SmoothingMode.None;
            g.DrawLine(Pens.Black, XPos - DP3, ChartTop + ChartH - 1 + DP3, XPos - DP3, ChartTop + ChartH + 2 + DP3);
        }

        private void DrawXText(Graphics g,Pen BackPen,string XText,int DP3,int ChartTop,int ChartH,int XPos,int XWidth)
        {
            /***********绘制横坐标标识元素*************/            
            StringFormat sf = new StringFormat();
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //旋转绘制横坐标表示
            if (this.XLabels.RotateAngle > 0)
            {
                    sf.Alignment = StringAlignment.Near;
                    g.TranslateTransform(XPos - DP3, ChartTop + ChartH + 1 + DP3);
                    g.RotateTransform(this.XLabels.RotateAngle);
                    g.DrawString(XText, this.XLabels.Font, new SolidBrush(this.XLabels.ForeColor), 0, 0, sf);
                    g.ResetTransform();
             }
             else
             {
                    sf.Alignment = StringAlignment.Center;
                    g.DrawString(XText, this.XLabels.Font, new SolidBrush(this.XLabels.ForeColor), new Rectangle(XPos - XWidth/2 - DP3, ChartTop + DP3 + ChartH + 1, XWidth + 1, (int)g.MeasureString(XText, this.XLabels.Font).Width), sf);
             }
             sf.Dispose();
        }

        private void DrawAxisUnit(Graphics g,int ChartLeft,int ChartTop,int ChartW,int ChartH)
        {
            //坐标单位
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //X Axis
            if (this.XLabels.UnitText != null && this.XLabels.Show)
                g.DrawString(this.XLabels.UnitText, this.XLabels.UnitFont, new SolidBrush(this.XLabels.ForeColor), ChartW + ChartLeft, ChartH + ChartTop);
            //Y Axis
            if (this.YLabels.UnitText != null && this.YLabels.Show)
                g.DrawString(this.YLabels.UnitText, this.YLabels.UnitFont, new SolidBrush(this.YLabels.ForeColor), 2, ChartTop - 25);
        }

        private void DrawYLine(Graphics g, Pen BackPen,string Text, int DP3, int ChartLeft,int ChartTop, int ChartW, int YPos, int YHeight)
        {
            StringFormat sf = new StringFormat();
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.DrawLine(new Pen(Color.FromArgb(255, 220, 220, 220)), ChartLeft, YPos, ChartLeft + ChartW, YPos);
            g.DrawLine(Pens.Black, ChartLeft - 3, YPos, ChartLeft, YPos);
            if (this.YLabels.Show)
                g.DrawString(Text, this.YLabels.Font, new SolidBrush(this.YLabels.ForeColor), new Rectangle(0, YPos - 10, ChartLeft - 4, 20), sf);
            sf.Dispose();     
        }

        private void DrawLine2D(Graphics g, Pen LinePen,float x1,float y1,float x2,float y2)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x1, y1, x2, y2);

            if (this.Shadow.Enable)
            {
                TextShadow tShadow = new TextShadow();
                tShadow.Radius = this.Shadow.Radius;
                tShadow.Distance = this.Shadow.Distance;
                tShadow.Alpha = this.Shadow.Alpha;
                tShadow.Angle = this.Shadow.Angle;
                tShadow.DropShadow(g, new Rectangle((int)gp.GetBounds().Left, (int)gp.GetBounds().Top, (int)gp.GetBounds().Width, (int)gp.GetBounds().Height), this.Shadow.Color, "Draw", "Path", gp, this.Stroke.Width);
            }

            g.DrawPath(LinePen, gp);
            gp.Dispose();
        }

        private void DrawLineConnection3D(Graphics g, Pen LinePen, SolidBrush LineBrush,int Depth,float halfRadius, float x, float y,int pos)
        {
            GraphicsPath gpls = new GraphicsPath();
            //绘制3D折现连接符
            if (this.LineConnectionType == LineConnectionTypes.Square)
            {//方形连接符
                gpls.Reset();
                gpls.StartFigure();
                gpls.AddLine(x - halfRadius, y - halfRadius, x - halfRadius - Depth, y - halfRadius + Depth);
                gpls.AddLine(x - halfRadius - Depth, y - halfRadius + Depth, x + halfRadius - Depth, y - halfRadius + Depth);
                gpls.AddLine(x + halfRadius - Depth, y - halfRadius + Depth, x + halfRadius, y - halfRadius);
                gpls.AddLine(x + halfRadius, y - halfRadius, x - halfRadius, y - halfRadius);
                gpls.StartFigure();
                gpls.AddLine(x - halfRadius - Depth, y - halfRadius + Depth, x + halfRadius - Depth, y - halfRadius + Depth);
                gpls.AddLine(x + halfRadius - Depth, y - halfRadius + Depth, x + halfRadius - Depth, y + halfRadius + Depth);
                gpls.AddLine(x + halfRadius - Depth, y + halfRadius + Depth, x - halfRadius - Depth, y + halfRadius + Depth);
                gpls.AddLine(x - halfRadius - Depth, y + halfRadius + Depth, x - halfRadius - Depth, y - halfRadius + Depth);
                gpls.StartFigure();
                gpls.AddLine(x + halfRadius - Depth, y - halfRadius + Depth, x + halfRadius, y - halfRadius);
                gpls.AddLine(x + halfRadius, y - halfRadius, x + halfRadius, y + halfRadius);
                gpls.AddLine(x + halfRadius, y + halfRadius, x + halfRadius - Depth, y + halfRadius + Depth);
                gpls.AddLine(x + halfRadius - Depth, y + halfRadius + Depth, x + halfRadius - Depth, y - halfRadius + Depth);
                g.FillPath(LineBrush, gpls);
                g.DrawPath(LinePen, gpls);
            }
            else if (this.LineConnectionType == LineConnectionTypes.Round)
            {//圆形连接符
                //准备3/4点
                gpls.Reset();
                gpls.AddArc((int)(x - halfRadius), (int)(y - halfRadius), this.LineConnectionRadius, this.LineConnectionRadius, 225, 180);
                PointF p1 = gpls.PathPoints[0];
                PointF p2 = gpls.PathPoints[gpls.PathPoints.Length - 1];
                PointF p3 = p1 + new SizeF(-1 * Depth, Depth);
                PointF p4 = p2 + new SizeF(-1 * Depth, Depth);
                //准备渐变笔刷
                Color[] GColors ={
                                        BarPenColor[pos % 12],
                                        Color.White,
                                        BarPenColor[pos % 12]
                                        };
                float[] GPoints ={
                                        0.0f,
                                        0.3f,
                                        1.0f
                                        };
                ColorBlend CB = new ColorBlend();
                CB.Colors = GColors;
                CB.Positions = GPoints;
                LinearGradientBrush lgb = new LinearGradientBrush(p1, p2, Color.Red, Color.Red);
                lgb.InterpolationColors = CB;
                //建立路径
                gpls.Reset();
                gpls.StartFigure();
                gpls.AddArc((int)(x - halfRadius), (int)(y - halfRadius), this.LineConnectionRadius, this.LineConnectionRadius, 225, 180);
                gpls.AddLine(p2, p4);
                gpls.AddArc((int)(x - halfRadius - Depth), (int)(y - halfRadius + Depth), this.LineConnectionRadius, this.LineConnectionRadius, 225, 180);
                gpls.AddLine(p3, p1);
                g.FillPath(lgb, gpls);
                g.DrawPath(LinePen, gpls);
                lgb.Dispose();
                //绘制前表面圆形
                gpls.Reset();
                gpls.StartFigure();
                gpls.AddEllipse((int)(x - halfRadius - Depth), (int)(y - halfRadius + Depth), this.LineConnectionRadius, this.LineConnectionRadius);
                g.FillPath(new SolidBrush(Color.FromArgb(255, BarPenColor[pos % 12])), gpls);
                g.DrawPath(LinePen, gpls);
            }
            g.DrawPath(LinePen, gpls);
            gpls.Dispose();
        }

        private void DrawLineSurface3D(Graphics g,Pen LinePen, SolidBrush LineBrush, int Depth, float halfRadius, float x1, float y1, float x2,float y2)
        {
            GraphicsPath gpls = new GraphicsPath();
            //绘制3D折现表面
            gpls.Reset();
            gpls.AddLine(x1 + halfRadius, y1, x1 + halfRadius - Depth, y1 + Depth);
            gpls.AddLine(x1 + halfRadius - Depth, y1 + Depth, x2 - halfRadius - Depth, y2 + Depth);
            gpls.AddLine(x2 - halfRadius - Depth, y2 + Depth, x2 - halfRadius, y2);
            gpls.AddLine(x2 - halfRadius, y2, x1 + halfRadius, y1);
            g.FillPath(LineBrush, gpls);
            if (this.Crystal.Enable)
            {
                DrawLineSurfaceCrystal3D(g, gpls, Depth, halfRadius, x1, y1, x2, y2);
            }
            g.DrawPath(LinePen, gpls);
            gpls.Dispose();
        }

        private void DrawLineSurfaceCrystal3D(Graphics g, GraphicsPath gpls,int Depth, float halfRadius, float x1,float y1, float x2, float y2)
        {
            Point p1; Point p2;
            if (this.Crystal.Direction == Direction.LeftRight)
            {
                p1 = new Point((int)(x1 + halfRadius - Depth), (int)(y1 + Depth));
                p2 = new Point((int)(x2 - halfRadius), (int)(y2));
            }
            else if (this.Crystal.Direction == Direction.RightLeft)
            {
                p2 = new Point((int)(x1 + halfRadius - Depth), (int)(y1 + Depth));
                p1 = new Point((int)(x2 - halfRadius), (int)(y2));
            }
            else if (this.Crystal.Direction == Direction.TopBottom)
            {
                p1 = new Point((int)(x1 + halfRadius), (int)(y1));
                p2 = new Point((int)(x1 + halfRadius - Depth), (int)(y1 + Depth));
            }
            else
            {
                p2 = new Point((int)(x1 + halfRadius), (int)(y1));
                p1 = new Point((int)(x1 + halfRadius - Depth), (int)(y1 + Depth));
            }
            LinearGradientBrush lgb = new LinearGradientBrush(p1, p2, Color.FromArgb(178, Color.White), Color.FromArgb(25, Color.White));
            g.FillPath(lgb, gpls);
        }

        private void WriteSrcipt(float x,float y, Decimal value)
        {
            if (StrBarL == "")
            {
                StrBarL = "" + (x - (int)((this.LineConnectionRadius + 4) / 2));
                StrBarW = "" + (this.LineConnectionRadius + 4);
                StrBarT = "" + (y - (int)((this.LineConnectionRadius + 4) / 2));
                StrBarH = "" + (this.LineConnectionRadius + 4);
                StrBarV = "" + value;
            }
            else
            {
                StrBarL += "," + (x - (int)((this.LineConnectionRadius + 4) / 2));
                StrBarW += "," + (this.LineConnectionRadius + 4);
                StrBarT += "," + (y - (int)((this.LineConnectionRadius + 4) / 2));
                StrBarH += "," + (this.LineConnectionRadius + 4);
                StrBarV += "," + value;
            }
        }

        /***************************** 基本绘图函数 *********************************/




        //3D图形
        private string StrBarL = "";
        private string StrBarW = "";
        private string StrBarT = "";
        private string StrBarH = "";
        private string StrBarV = "";
        private void DrawBarsChart()
        {
            int ImageW = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2)) + this.InflateRight + this.InflateLeft;
            int ImageH = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2)) +this.InflateBottom + this.InflateTop;
            /******************************/
            Bitmap b = new Bitmap(ImageW , ImageH );
            Graphics g = Graphics.FromImage(b);
            int ChartLeft, ChartTop, ChartRight,ChartBottom,AP3;
            ChartLeft = 50 + this.InflateLeft;
            ChartTop = 60 + this.InflateTop; 
            ChartRight = 100 + this.InflateRight;
            ChartBottom= 40 + this.InflateBottom;
            int ChartW = ImageW - ChartLeft - ChartRight;
            int ChartH = ImageH - ChartTop - ChartBottom;
            /*********绘制背景*************/
            if (!this.ColorGuider.Show)
            {
                ChartW += 100 - 2 - ((int)g.MeasureString(this.XLabels.UnitText,this.XLabels.UnitFont).Width);
                ChartRight -=100- 2;
            }
            if (!this.YLabels.Show)
            {
                ChartW += 50 - 2;
                ChartLeft -=50- 2;
            }
            if (!this.ChartTitle.Show)
            {
                ChartH += 60 - 27;
                ChartTop -=60 - 27;
            }
            if (!this.DataBound && this.ShowErrorInfo)
            {
                this.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            }
            int Depth = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                Depth = (int)(this.Depth3D * 0.85);
                PaintBackground3D(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = this.Alpha3D;
            }
            else
            {
                PaintBackground(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = 255;
            }
            /*******************************************/
            if (this.DataBound)
            {//是否绑定了数据
                //绘制柱子
                //g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                Pen BackPen = new Pen(Color.FromArgb(255, 220, 220, 220));

                //***** For SpecLimits and Means *****
                int LastXAix = ChartLeft;
                int CurrentXAix = ChartLeft;

                int GroupSize = this.GroupSize;
                int ElementCount = MaxCount;
                if (ElementCount > 0)
                {
                    ////计算柱子宽度柱子间距
                    int BarGapW,BarW;
                    if ((this.AutoBarWidth == false) && (ElementCount * GroupSize < 12))
                    {
                        BarGapW = (int)(ChartW / 4 / (1 + 5 * 3));
                        BarW = 5 * BarGapW;
                    }
                    else
                    {
                        BarW=(int)(ChartW/ElementCount/(0.25+GroupSize));
                        BarGapW = (int)(0.25 * BarW);
                        //BarGapW = (int)(ChartW / ElementCount / (1 + 5 * GroupSize));
                    }
                    //BarW = 5 * BarGapW;
                    int BarSN; int BarH; int BarTop; int BarLeft;

                    //循环绘制柱子
                    for (int i = 0; i < ElementCount; i++)
                    {
                        SolidBrush BarBrush; Pen BarPen;
                        BarSN = i;
                        BarLeft = ChartLeft + BarW * BarSN * this.GroupSize + BarGapW * (BarSN + 1);


                        /***********绘制横坐标标识元素*************/
                        int DP3 = (int)(Depth / 0.85);
                        DrawXLine(g, BackPen, DP3, ChartTop, ChartH, BarLeft + BarW * GroupSize / 2, BarW * GroupSize + BarGapW);
                        CurrentXAix = BarLeft + BarW * GroupSize / 2;
                        if (this.XLabels.Show && (i % this.XLabels.SampleSize==0))
                        {
                            DrawXText(g, BackPen, AxisX[i], DP3, ChartTop, ChartH, BarLeft + BarW * GroupSize / 2, BarW * GroupSize + BarGapW);
                        }

                        /****************************************/
                        bool BelowX = false;
                        for (int j = 0; j < GroupSize; j++)
                        {
                            if (RawDatas[j][i] != -0.830213m)
                            {
                                BarH = (int)(IntDatas[j][i]- BaseLineXInt - 1);
                                if (BarH < 0)
                                {
                                    BarH = -1 * BarH;
                                    BarTop = ChartTop + ChartH - (int)BaseLineXInt;
                                    BelowX = true;
                                }
                                else
                                {
                                    BarTop = ChartTop + ChartH - BarH - (int)(BaseLineXInt);
                                    BelowX = false;
                                }

                                if (GroupSize == 1 && this.Colorful)
                                    if(this.Dimension==ChartDimensions.Chart3D)
                                        BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[i % 12]));
                                    else
                                        BarBrush = new SolidBrush(BarBrushColor[i % 12]);
                                else
                                    if (this.Dimension == ChartDimensions.Chart3D)
                                        BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[j % 12]));
                                    else
                                        BarBrush = new SolidBrush(BarBrushColor[j % 12]);

                                if (this.Stroke.TextureEnable)
                                {
                                    HatchStyle hs = this.Stroke.TextureStyle;
                                    BarPen = new Pen(new HatchBrush(hs, BarPenColor[j % 12], Color.Gray), this.Stroke.Width);
                                }
                                else
                                {
                                    BarPen = new Pen(BarPenColor[j % 12], this.Stroke.Width);
                                }
                                BarPen.Alignment = PenAlignment.Inset;

                                if (this.Dimension == ChartDimensions.Chart3D)
                                {//3D
                                    DrawBarBase3D(g, BarBrush, BarPen, BarLeft, BarTop, BarW, BarH, Depth);
                                }
                                else
                                {//2D
                                    DrawBarBase2D(g, BarBrush, BarPen, BarLeft, BarTop, BarW, BarH);
                                }
                                //******* 绘制水晶效果 *******//
                                if (this.Crystal.Enable && BarH - this.Crystal.Contraction * 2 > 2 && BarW - this.Crystal.Contraction * 2 > 2)
                                {
                                    DrawBarCrystal(g,BarLeft, BarTop, BarW, BarH, Depth);
                                }

                                //值标签
                                //g.DrawRectangle(new Pen(BarBrush),BarLeft+BarW/2,BarTop-30,40,18);
                                if (this.Tips.Show)
                                {
                                    DrawTips(g, RawDatas[j][i].ToString(this.Tips.ValueFormat), BarLeft, BarTop, BarW, BarH, BelowX);
                                }
                                //else{

                                    /******* 构建客户端参数 ********/
                                    if (StrBarL == "")
                                    {
                                        StrBarL = "" + (BarLeft - Depth);
                                        StrBarW = "" + BarW;
                                        StrBarT = "" + (BarTop + Depth);
                                        StrBarH = "" + BarH;
                                        StrBarV = "" + RawDatas[j][i];
                                    }
                                    else
                                    {
                                        StrBarL += "," + (BarLeft - Depth);
                                        StrBarW += "," + BarW;
                                        StrBarT += "," + (BarTop + Depth);
                                        StrBarH += "," + BarH;
                                        StrBarV += "," + RawDatas[j][i];
                                    }
                                    /*******************************/
                                //}

                                BarLeft = BarLeft + BarW;
                            }
                        }

                        //2011-6-15 Draw Y Limits,for Datalet Histogram
                        if ((!this.SpecLine.YLimit) && this.SpecLine.Show)
                        {

                            if (i>0)
                            {
                                if (this.SpecLine.LLoaded)
                                {
                                    try
                                    {
                                        float lv = float.Parse(AxisX[i-1]);
                                        float rv = float.Parse(AxisX[i]);
                                        if (this.SpecLine.LowLimit >= lv && this.SpecLine.LowLimit <= rv)
                                        {

                                            Pen RedPen = new Pen(Color.Red);
                                            int Splv = (Int32)((this.SpecLine.LowLimit - lv) / (rv - lv) * (CurrentXAix - LastXAix));
                                            DrawXLine(g, RedPen, DP3, ChartTop, ChartH, LastXAix + Splv, BarW * GroupSize + BarGapW);
                                            DrawTips(g, this.SpecLine.LowLimit.ToString(this.Tips.ValueFormat), LastXAix + Splv, ChartTop + 2, BarW, ChartH, false);
                                        }
                                    }
                                    catch (Exception ee)
                                    {

                                    }
                                }
                                if (this.SpecLine.HLoaded)
                                {
                                    try
                                    {
                                        float lv = float.Parse(AxisX[i-1]);
                                        float rv = float.Parse(AxisX[i]);
                                        if (this.SpecLine.HighLimit >= lv && this.SpecLine.HighLimit <= rv)
                                        {
                                            Pen RedPen = new Pen(Color.Red);
                                            int Splv = (Int32)((this.SpecLine.HighLimit - lv) / (rv - lv) * (CurrentXAix - LastXAix));
                                            DrawXLine(g, RedPen, DP3, ChartTop, ChartH, LastXAix + Splv, BarW * GroupSize + BarGapW);
                                            DrawTips(g, this.SpecLine.HighLimit.ToString(this.Tips.ValueFormat), LastXAix + Splv, ChartTop + 2, BarW, ChartH, false);
                                        }
                                    }
                                    catch (Exception ee)
                                    {

                                    }
                                }
                                if (this.SpecLine.MLoaded)
                                {
                                    try
                                    {
                                        float lv = float.Parse(AxisX[i-1]);
                                        float rv = float.Parse(AxisX[i]);
                                        if (this.SpecLine.MeanValue >= lv && this.SpecLine.MeanValue <= rv)
                                        {
                                            Pen RedPen = new Pen(Color.Blue);
                                            RedPen.DashStyle = DashStyle.Dash;
                                            int Splv = (Int32)((this.SpecLine.MeanValue - lv) / (rv - lv) * (CurrentXAix - LastXAix));
                                            DrawXLine(g, RedPen, DP3, ChartTop, ChartH, LastXAix + Splv, BarW * GroupSize + BarGapW);
                                            DrawTips(g, this.SpecLine.MeanValue.ToString(this.Tips.ValueFormat), LastXAix + Splv, ChartTop + 2, BarW, ChartH, false);
                                        }
                                    }
                                    catch (Exception ee)
                                    {

                                    }
                                }
                            }
                        }//eof spec limit Y,for Datalet Histogram

                        LastXAix = CurrentXAix;
                    }
                }
                BackPen.Dispose();
            }//if DataBound
            /********** 绘制坐标轴 **********/
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                g.DrawRectangle(Pens.Gray, ChartLeft, ChartTop, ChartW, ChartH);
                g.DrawLine(Pens.Black, ChartLeft - 4, ChartTop + ChartH - BaseLineXInt, ChartLeft + ChartW - 1, ChartTop + ChartH - BaseLineXInt);
                g.DrawLine(Pens.Black, ChartLeft, ChartTop, ChartLeft, ChartTop + ChartH + 2);
            }
            //坐标单位
            DrawAxisUnit(g, ChartLeft, ChartTop, ChartW, ChartH);


            /******************************************/
            if (Site != null)
                SaveChart(this.RootPath, b);
            else
                SaveChart(System.Web.HttpContext.Current.Server.MapPath(".") + "\\", b);
            g.Dispose();
            b.Dispose();
        }

        private void DrawHBarChart()
        {
            int ImageW = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2)) + this.InflateRight + this.InflateLeft;
            int ImageH = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2)) + this.InflateBottom + this.InflateTop;
            /******************************/
            Bitmap b = new Bitmap(ImageW, ImageH);
            Graphics g = Graphics.FromImage(b);
            int ChartLeft, ChartTop, ChartRight, ChartBottom, AP3;
            ChartLeft = 50 + this.InflateLeft;
            ChartTop = 60 + this.InflateTop;
            ChartRight = 100 + this.InflateRight;
            ChartBottom = 40 + this.InflateBottom;
            int ChartW = ImageW - ChartLeft - ChartRight;
            int ChartH = ImageH - ChartTop - ChartBottom;
            /*********绘制背景*************/
            if (!this.ColorGuider.Show)
            {
                ChartW += 100 - 2 - ((int)g.MeasureString(this.XLabels.UnitText, this.XLabels.UnitFont).Width);
                ChartRight -= 100 - 2;
            }
            if (!this.YLabels.Show)
            {
                ChartW += 50 - 2;
                ChartLeft -= 50 - 2;
            }
            if (!this.ChartTitle.Show)
            {
                ChartH += 60 - 27;
                ChartTop -= 60 - 27;
            }

            if (this.ShowErrorInfo)
            {
                if(!this.DataBound)
                    this.ChartTitle.Text = "Please bind a data source with BindChartData()!";
                else if(MinData < 0)
                {
                    this.ChartTitle.Text = "HBar Chart can not accept value<0";
                    this.DataBound = false;
                }
            }

            int Depth = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                Depth = (int)(this.Depth3D * 0.85);
                PaintBackground3D(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = this.Alpha3D;
            }
            else
            {
                PaintBackground(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = 255;
            }
            /*******************************************/
            for (int idx = 0; idx <= this.YLabels.LabelCount; idx++)
            {
                DrawXLine(g, new Pen(Color.FromArgb(255, 220, 220, 220)), (int)(Depth / 0.85), ChartTop, ChartH, ChartLeft + ChartW * idx / this.YLabels.LabelCount, ChartW / this.YLabels.LabelCount);
                if (this.XLabels.Show)
                {
                    DrawXText(g, new Pen(Color.FromArgb(255, 220, 220, 220)), (MinData + (MaxData - MinData) * (this.YLabels.LabelCount - idx) / this.YLabels.LabelCount).ToString(this.YLabels.ValueFormat), (int)(Depth / 0.85), ChartTop, ChartH, ChartLeft + ChartW * (this.YLabels.LabelCount - idx) / this.YLabels.LabelCount, ChartW / this.YLabels.LabelCount);
                }
            }

            /*******************************************/
            if (this.DataBound)
            {//是否绑定了数据
                //绘制柱子
                //g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                Pen BackPen = new Pen(Color.FromArgb(255, 220, 220, 220));

                int GroupSize = this.GroupSize;
                int ElementCount = MaxCount;
                if (ElementCount > 0)
                {
                    ////计算柱子宽度柱子间距
                    int BarGapH, BarH;
                    if ((this.AutoBarWidth == false) && (ElementCount * GroupSize < 12))
                    {
                        BarGapH = (int)(ChartH / 4 / (1 + 5 * 3));
                        BarH = 5 * BarGapH;
                    }
                    else
                    {
                        BarH = (int)(ChartH / ElementCount / (0.25 + GroupSize));
                        BarGapH = (int)(0.25 * BarH);
                        //BarGapW = (int)(ChartW / ElementCount / (1 + 5 * GroupSize));
                    }
                    //BarW = 5 * BarGapW;
                    int BarSN; int BarW; int BarTop; int BarLeft;

                    //循环绘制柱子
                    for (int i = 0; i < ElementCount; i++)
                    {
                        SolidBrush BarBrush; Pen BarPen;
                        BarSN = i;
                        BarLeft = ChartLeft;
                        //BarLeft = ChartLeft + BarW * BarSN * this.GroupSize + BarGapW * (BarSN + 1);
                        BarTop = ChartTop + BarH * BarSN * this.GroupSize + BarGapH * (BarSN + 1);

                        /***********绘制横坐标标识元素*************/
                        int DP3 = (int)(Depth / 0.85);
                        /**************** 绘制纵坐标 ******************/
                        DrawYLine(g, BackPen, AxisX[i], DP3, ChartLeft, ChartTop, ChartW, BarTop + BarH * GroupSize / 2, BarH);
     
                        
                        /****************************************/
                        bool BelowX = false;
                        for (int j = 0; j < GroupSize; j++)
                        {
                            if (RawDatas[j][i] != -0.830213m)
                            {
                                BarW = (int)(IntDatas[j][i] * ChartW / ChartH - BaseLineXInt - 1);

                                if (GroupSize == 1 && this.Colorful)
                                    if (this.Dimension == ChartDimensions.Chart3D)
                                        BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[i % 12]));
                                    else
                                        BarBrush = new SolidBrush(BarBrushColor[i % 12]);
                                else
                                    if (this.Dimension == ChartDimensions.Chart3D)
                                        BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[j % 12]));
                                    else
                                        BarBrush = new SolidBrush(BarBrushColor[j % 12]);

                                if (this.Stroke.TextureEnable)
                                {
                                    HatchStyle hs = this.Stroke.TextureStyle;
                                    BarPen = new Pen(new HatchBrush(hs, BarPenColor[j % 12], Color.Gray), this.Stroke.Width);
                                }
                                else
                                {
                                    BarPen = new Pen(BarPenColor[j % 12], this.Stroke.Width);
                                }
                                BarPen.Alignment = PenAlignment.Inset;

                                if (this.Dimension == ChartDimensions.Chart3D)
                                {//3D
                                    DrawBarBase3D(g, BarBrush, BarPen, BarLeft, BarTop, BarW, BarH, Depth);
                                }
                                else
                                {//2D
                                    DrawBarBase2D(g, BarBrush, BarPen, BarLeft, BarTop, BarW, BarH);
                                }
                                //******* 绘制水晶效果 *******//
                                if (this.Crystal.Enable && BarH - this.Crystal.Contraction * 2 > 2 && BarW - this.Crystal.Contraction * 2 > 2)
                                {
                                    DrawBarCrystal(g, BarLeft, BarTop, BarW, BarH, Depth);
                                }

                                //值标签
                                //g.DrawRectangle(new Pen(BarBrush),BarLeft+BarW/2,BarTop-30,40,18);
                                if (this.Tips.Show)
                                {
                                    DrawTips(g, RawDatas[j][i].ToString(this.Tips.ValueFormat), BarLeft, BarTop + 15, BarW * 2 + 30, BarH, BelowX);
                                }
                                //else{

                                /******* 构建客户端参数 ********/
                                    if (StrBarL == "")
                                    {
                                        StrBarL = "" + (BarLeft - Depth);
                                        StrBarW = "" + BarW;
                                        StrBarT = "" + (BarTop + Depth);
                                        StrBarH = "" + BarH;
                                        StrBarV = "" + RawDatas[j][i];
                                    }
                                    else
                                    {
                                        StrBarL += "," + (BarLeft - Depth);
                                        StrBarW += "," + BarW;
                                        StrBarT += "," + (BarTop + Depth);
                                        StrBarH += "," + BarH;
                                        StrBarV += "," + RawDatas[j][i];
                                    }
                                /*******************************/
                                //}

                                BarTop = BarTop + BarH;
                            }
                        }
                    }
                }
                BackPen.Dispose();
            }//if DataBound
            /********** 绘制坐标轴 **********/
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                g.DrawRectangle(Pens.Gray, ChartLeft, ChartTop, ChartW, ChartH);
                g.DrawLine(Pens.Black, ChartLeft - 4, ChartTop + ChartH - BaseLineXInt, ChartLeft + ChartW - 1, ChartTop + ChartH - BaseLineXInt);
                g.DrawLine(Pens.Black, ChartLeft, ChartTop, ChartLeft, ChartTop + ChartH + 2);
            }
            //坐标单位
            string UXC = this.YLabels.UnitText;
            this.YLabels.UnitText = this.XLabels.UnitText;
            this.XLabels.UnitText = UXC;

            DrawAxisUnit(g, ChartLeft, ChartTop, ChartW+10, ChartH);


            /******************************************/
            if (Site != null)
                SaveChart(this.RootPath, b);
            else
                SaveChart(System.Web.HttpContext.Current.Server.MapPath(".") + "\\", b);
            g.Dispose();
            b.Dispose();
        }

        private void DrawStackChart()
        {
            int ImageW = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2)) + this.InflateRight + this.InflateLeft;
            int ImageH = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2)) + this.InflateBottom + this.InflateTop;
            /******************************/
            Bitmap b = new Bitmap(ImageW, ImageH);
            Graphics g = Graphics.FromImage(b);
            int ChartLeft, ChartTop, ChartRight, ChartBottom, AP3;
            ChartLeft = 50 + this.InflateLeft;
            ChartTop = 60 + this.InflateTop;
            ChartRight = 100 + this.InflateRight;
            ChartBottom = 40 + this.InflateBottom;
            int ChartW = ImageW - ChartLeft - ChartRight;
            int ChartH = ImageH - ChartTop - ChartBottom;
            /*******************************************/
            int GroupSize = this.GroupSize;
            int ElementCount = MaxCount;
            float[] StackDatas = new float[ElementCount];
            Decimal[] RawStack = new Decimal[ElementCount];
            /*********绘制背景*************/
            if (!this.ColorGuider.Show)
            {
                ChartW += 100 - 2 - ((int)g.MeasureString(this.XLabels.UnitText, this.XLabels.UnitFont).Width);
                ChartRight -= 100 - 2;
            }
            if (!this.YLabels.Show)
            {
                ChartW += 50 - 2;
                ChartLeft -= 50 - 2;
            }
            if (!this.ChartTitle.Show)
            {
                ChartH += 60 - 27;
                ChartTop -= 60 - 27;
            }

            /******* Error Msg Setup *********/
            if (!this.DataBound && this.ShowErrorInfo)
            {
                this.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            }
            else if (MinData < 0)
            {
                this.DataBound = false;
                if (this.ShowErrorInfo == true)
                {
                    this.ChartTitle.Text = "StackBar can not accept value < 0";
                }
            }
            /******* Error Msg Setup *********/

            /*************** 处理数据 ****************/
            if (this.DataBound)
            {
                /******************** 2009-09-09 ******************/
                for (int i = 0; i < MaxCount; i++)
                {
                    RawStack[i] = 0;
                    for (int j = 0; j < GroupSize; j++)
                    {
                        RawStack[i] += RawDatas[j][i];
                    }
                }

                MaxData = GetBond(GetMax(RawStack));
                if (this.MaxValueY != 0)
                {
                    MaxData = (float)this.MaxValueY;
                }

                for (int i = 0; i < MaxCount; i++)
                {
                    for (int j = 0; j < GroupSize; j++)
                    {
                        IntDatas[j][i] = (float)((float)RawDatas[j][i] - (float)this.MinValueY) * ChartH / (MaxData - (float)this.MinValueY);
                    }
                    //StackDatas[i] = (float)((float)RawStack[i] - (float)this.MinValueY) * ChartH / (MaxData - (float)this.MinValueY) - GroupSize - 2;
                }
                /************************************************/
            }
            int Depth = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                Depth = (int)(this.Depth3D * 0.85);
                PaintBackground3D(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = this.Alpha3D;
            }
            else
            {
                PaintBackground(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = 255;
            }
            /********************************/
            if (this.DataBound)
            {//是否绑定了数据
                //绘制柱子
                //g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                Pen BackPen = new Pen(Color.FromArgb(255, 220, 220, 220));

                GroupSize = this.GroupSize;
                ElementCount = MaxCount;

                if (ElementCount > 0)
                {
                    ////计算柱子宽度柱子间距
                    int BarGapW,BarW;
                    if ((this.AutoBarWidth == false) && (ElementCount < 12))
                    {
                        BarGapW = (int)(ChartW / 4 / (1 + 5 * 3));
                        BarW = 5 * BarGapW;
                    }
                    else
                    {
                        BarW = (int)(ChartW /ElementCount/1.25);
                        //BarGapW = (int)(ChartW / ElementCount / (1 + 5));
                        BarGapW =(int)(BarW * 0.25);
                    }
                    
                    int BarSN; int BarH; int BarTop; int BarLeft;

                    //循环绘制柱子
                    for (int i = 0; i < ElementCount; i++)
                    {
                        SolidBrush BarBrush; Pen BarPen;
                        BarSN = i;
                        BarLeft = ChartLeft + BarW * BarSN + BarGapW * (BarSN + 1);

                        int GroupHeigth = 0;

                        /***********绘制横坐标标识元素*************/
                        int DP3 = (int)(Depth / 0.85);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        DrawXLine(g, BackPen, DP3, ChartTop, ChartH, BarLeft + BarW / 2, BarW + BarGapW);
                        if (this.XLabels.Show && (i % this.XLabels.SampleSize==0))
                        {
                            DrawXText(g, BackPen, AxisX[i], DP3, ChartTop, ChartH, BarLeft + BarW / 2, BarW + BarGapW);
                        }
                        /****************************************/

                        for (int j = 0; j < GroupSize; j++)
                        {
                            if (RawDatas[j][i] != -0.830213m)
                            {
                                BarH = (int)IntDatas[j][i] - 1;
                                BarTop = ChartTop + ChartH - BarH - GroupHeigth;

                                if (GroupSize == 1 && this.Colorful)
                                    BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[i % 12]));
                                else
                                    BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[j % 12]));

                                if (this.Stroke.TextureEnable)
                                {
                                    HatchStyle hs = this.Stroke.TextureStyle;
                                    BarPen = new Pen(new HatchBrush(hs, BarPenColor[j % 12], Color.Gray), this.Stroke.Width);
                                }
                                else
                                {
                                    BarPen = new Pen(BarPenColor[j % 12], this.Stroke.Width);
                                }
                                BarPen.Alignment = PenAlignment.Inset;

                                if (this.Dimension == ChartDimensions.Chart3D)
                                {//3D
                                    DrawBarBase3D(g, BarBrush, BarPen, BarLeft, BarTop, BarW, BarH, Depth);
                                }
                                else
                                {//2D
                                    DrawBarBase2D(g, BarBrush, BarPen, BarLeft, BarTop, BarW, BarH);
                                }
                                GroupHeigth += BarH;

                                //******* 绘制水晶效果 *******//
                                //BarH = (int)StackDatas[i];
                                //BarTop = ChartTop + ChartH - BarH;
                                if (this.Crystal.Enable && BarH - this.Crystal.Contraction * 2 > 2 && BarW - this.Crystal.Contraction * 2 > 2)
                                {
                                    DrawBarCrystal(g, BarLeft, BarTop, BarW, BarH, Depth);
                                }

                                //值标签
                                //g.DrawRectangle(new Pen(BarBrush),BarLeft+BarW/2,BarTop-30,40,18);
                                if (this.Tips.Show)
                                {
                                    DrawTips(g, RawDatas[j][i].ToString(this.Tips.ValueFormat), BarLeft - DP3, BarTop + DP3, BarW, BarH, false);
                                }
                                //else{
                                    /******* 构建客户端参数 ********/
                                    if (StrBarL == "")
                                    {
                                        StrBarL = "" + (BarLeft - Depth);
                                        StrBarW = "" + BarW;
                                        StrBarT = "" + (BarTop + Depth);
                                        StrBarH = "" + BarH;
                                        StrBarV = "" + RawDatas[j][i];
                                    }
                                    else
                                    {
                                        StrBarL += "," + (BarLeft - Depth);
                                        StrBarW += "," + BarW;
                                        StrBarT += "," + (BarTop + Depth);
                                        StrBarH += "," + BarH;
                                        StrBarV += "," + RawDatas[j][i];
                                    }
                                    /*******************************/
                                //}

                            }
                        }

                        BarLeft = BarLeft + BarW;
                    }
                }
                BackPen.Dispose();
            }//if DataBound
            /********** 绘制坐标轴 **********/
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                g.DrawRectangle(Pens.Gray, ChartLeft, ChartTop, ChartW, ChartH);
                g.DrawLine(Pens.Black, ChartLeft - 4, ChartTop + ChartH - 1, ChartLeft + ChartW - 1, ChartTop + ChartH - 1);
                g.DrawLine(Pens.Black, ChartLeft, ChartTop, ChartLeft, ChartTop + ChartH + 2);
            }
            //坐标单位
            DrawAxisUnit(g, ChartLeft, ChartTop, ChartW, ChartH);

            /******************************************/
            if (Site != null)
                SaveChart(this.RootPath, b);
            else
                SaveChart(System.Web.HttpContext.Current.Server.MapPath(".") + "\\", b);
            g.Dispose();
            b.Dispose();
        }

        private void DrawLineChart()
        {
            int ImageW = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2)) + this.InflateRight + this.InflateLeft;
            int ImageH = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2)) + this.InflateBottom + this.InflateTop;
            /******************************/
            int ChartLeft, ChartTop, ChartRight, ChartBottom, AP3;
            ChartLeft = 50 + this.InflateLeft;
            ChartTop = 60 + this.InflateTop;
            ChartRight = 100 + this.InflateRight;
            ChartBottom = 40 + this.InflateBottom;
            int ChartW = ImageW - ChartLeft - ChartRight;
            int ChartH = ImageH - ChartTop - ChartBottom;

            //2011-12-14 Reset ImageW by XGrid
            if (ChartW / MaxCount >= 1)
            {
                int CWT = ((int)(ChartW / MaxCount)) * MaxCount;
                ImageW += CWT - ChartW;
                ChartW = CWT;
            }
            //2011-12-14 Reset ImageW by XGrid

            Bitmap b = new Bitmap(ImageW, ImageH);
            Graphics g = Graphics.FromImage(b);
            /*********绘制背景*************/
            if (!this.ColorGuider.Show)
            {
                ChartW += 100 - 2 - ((int)g.MeasureString(this.XLabels.UnitText, this.XLabels.UnitFont).Width);
                ChartRight -= 100 - 2;
            }
            if (!this.YLabels.Show)
            {
                ChartW += 50 - 2;
                ChartLeft -= 50 - 2;
            }
            if (!this.ChartTitle.Show)
            {
                ChartH += 60 - 27;
                ChartTop -= 60 - 27;
            }
            if ((!this.DataBound) && this.ShowErrorInfo)
            {
                this.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            }
            int Depth = 0; int DP3 = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                Depth = (int)(this.Depth3D * 0.85);
                DP3 = this.Depth3D;
                PaintBackground3D(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = this.Alpha3D;
            }
            else
            {
                PaintBackground(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = 255;
            }
            /****************************/
            Pen BackPen = new Pen(Color.FromArgb(255, 220, 220, 220));
            //绘制线条
            if (this.DataBound)
            {//是否绑定了数据
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                int GroupSize = this.GroupSize;
                int ElementCount = MaxCount;
                if (ElementCount > 0)
                {

                    /////=============================================上面都是通用代码=================================================
                    /////////////////////////  Line Chart ///////////////////////////
                    //X坐标上的间距宽度
                    double XGrid = ChartW * 1.0 / ElementCount;
                    //***************************
                    
                    //=== 下面开始绘制 LineChart =====//
                    for (int j = 0; j < GroupSize; j++)
                    {
                        SolidBrush LineBrush = new SolidBrush(Color.FromArgb(AP3, BarPenColor[j % 12]));

                        Pen LinePen;
                        if (this.Stroke.TextureEnable)
                        {
                            HatchStyle hs = this.Stroke.TextureStyle;
                            LinePen = new Pen(new HatchBrush(hs, BarPenColor[j % 12], Color.Black), this.Stroke.Width);
                        }
                        else
                        {
                            LinePen = new Pen(BarPenColor[j % 12], this.Stroke.Width);
                        }

                        GraphicsPath gp = new GraphicsPath();

                        float PointLeft = (float)(XGrid / 2);
                        PointLeft += ChartLeft;
                        int i;
         
                        for (i = 0; i < ElementCount - 1; i++)
                        {
                            //绘制横坐标标识
                            if (j == 0)
                            {
                                //DrawXLine(g, BackPen, DP3, ChartTop, ChartH, PointLeft, XGrid);
                                if (this.XLabels.Show && (i % this.XLabels.SampleSize==0))
                                {
                                    DrawXLine(g, BackPen, DP3, ChartTop, ChartH, (int)PointLeft, (int)XGrid);
                                    DrawXText(g, BackPen, AxisX[i], DP3, ChartTop, ChartH, (int)PointLeft, (int)XGrid);    
                                }
                                //PointLeft调整到下一个点
                            }
                            //绘制折线
                            if (RawDatas[j][i] != -0.830213m)
                            {
                                g.SmoothingMode = SmoothingMode.AntiAlias;
                                if (this.Dimension == ChartDimensions.Chart2D)
                                {
                                    if (RawDatas[j][i + 1] != -0.830213m)
                                        DrawLine2D(g, LinePen, PointLeft, ChartTop + ChartH - IntDatas[j][i], PointLeft + (float)XGrid, ChartTop + ChartH - IntDatas[j][i + 1]);
                                }
                                else
                                {
                                    float halfRadius = this.LineConnectionRadius / 2;
                                    if (this.LineConnectionType == LineConnectionTypes.None)
                                    {
                                        halfRadius = 0;
                                    }
                                    //GraphicsPath gpls = new GraphicsPath();
                                    DrawLineConnection3D(g, LinePen, LineBrush, Depth, halfRadius, PointLeft, ChartTop + ChartH - IntDatas[j][i],j);
                                    //绘制3D折线面
                                    if (RawDatas[j][i+1] != -0.830213m)
                                    {
                                        DrawLineSurface3D(g,LinePen, LineBrush, Depth, halfRadius, PointLeft, ChartTop + ChartH - IntDatas[j][i], PointLeft + (float)XGrid, ChartTop + ChartH - IntDatas[j][i + 1]);
                                    }

                                    //绘制值标签
                                    if (this.Tips.Show && RawDatas[j][i] != -0.830213m)
                                    {
                                        DrawTips(g, RawDatas[j][i].ToString(this.Tips.ValueFormat), (int)(PointLeft - XGrid / 2), (int)(ChartTop + ChartH - IntDatas[j][i] - this.LineConnectionRadius / 2), (int)XGrid, (int)IntDatas[j][i], false); 
                                    }
                                    /******* 构建客户端参数 ********/
                                    WriteSrcipt(PointLeft-Depth, ChartTop + Depth + ChartH - IntDatas[j][i], RawDatas[j][i]);
                                }
                            }
                            PointLeft = (float)( PointLeft + XGrid);
                        }
                       

                        //绘制线条的投影
                        //已经放到DrawLine2D里面了

                        /*********************************************************/
                        //绘制最后一个横坐标标识
                        if (j == 0)
                        {
                            if (j == 0)
                            {
                                //DrawXLine(g, BackPen, DP3, ChartTop, ChartH, PointLeft, XGrid);
                                if (this.XLabels.Show && (i % this.XLabels.SampleSize == 0))
                                {
                                    DrawXLine(g, BackPen, DP3, ChartTop, ChartH, (int)PointLeft, (int)XGrid);
                                    DrawXText(g, BackPen, AxisX[i], DP3, ChartTop, ChartH, (int)PointLeft, (int)XGrid);
                                }
                                //PointLeft调整到下一个点
                            }
                        }
                        //绘制最后一个3D连接符
                        if (this.Dimension == ChartDimensions.Chart3D)
                        {
                            if (RawDatas[j][i] != -0.830213m)
                            {
                                float halfRadius = this.LineConnectionRadius / 2;
                                GraphicsPath gpls = new GraphicsPath();
                                if (this.LineConnectionType == LineConnectionTypes.None)
                                {
                                    halfRadius = 0;
                                }
                                DrawLineConnection3D(g, LinePen, LineBrush, Depth, halfRadius, PointLeft, ChartTop + ChartH - IntDatas[j][i], j);
                                //绘制值标签
                                if (this.Tips.Show)
                                {
                                    DrawTips(g, RawDatas[j][i].ToString(this.Tips.ValueFormat), (int)(PointLeft - XGrid / 2), (int)(ChartTop + ChartH - IntDatas[j][i] - this.LineConnectionRadius / 2), (int)XGrid, (int)IntDatas[j][i], false);
                                }
                                /******* 构建客户端参数 ********/
                                WriteSrcipt(PointLeft - Depth, ChartTop + Depth + ChartH - IntDatas[j][i], RawDatas[j][i]);
                            }
                        }
                        /************************************************************/

                        LinePen.Dispose();
                        gp.Dispose();

                        if (this.Dimension == ChartDimensions.Chart2D)
                        {
                            //下面绘制Point色块
                            PointLeft = (int)(XGrid / 2) + ChartLeft;
                            LineConnectionTypes LineConnectionType = this.LineConnectionType;//Linechart属性
                            int ConntionRadius = this.LineConnectionRadius;//Linechart属性

                            if (LineConnectionType == LineConnectionTypes.Round)
                                g.SmoothingMode = SmoothingMode.AntiAlias;
                            else if (LineConnectionType == LineConnectionTypes.Square)
                                g.SmoothingMode = SmoothingMode.None;

                            for (int k = 0; k < ElementCount; k++)
                            {
                                if (RawDatas[j][k] != -0.830213m)
                                {
                                    if (LineConnectionType == LineConnectionTypes.Round)
                                    {
                                        g.FillEllipse(LineBrush, PointLeft - ConntionRadius / 2, ChartTop + ChartH - IntDatas[j][k] - ConntionRadius / 2, ConntionRadius, ConntionRadius);
                                    }
                                    else if (LineConnectionType == LineConnectionTypes.Square)
                                    {
                                        g.FillRectangle(LineBrush, PointLeft - ConntionRadius / 2, ChartTop + ChartH - IntDatas[j][k] - ConntionRadius / 2, ConntionRadius, ConntionRadius);
                                    }

                                    //绘制值标签
                                    if (this.Tips.Show)
                                    {
                                        DrawTips(g, RawDatas[j][k].ToString(this.Tips.ValueFormat), (int)(PointLeft - XGrid / 2), (int)(ChartTop + ChartH - IntDatas[j][k] - this.LineConnectionRadius / 2), (int)XGrid, (int)IntDatas[j][i], false);
                                    }
                                    /******* 构建客户端参数 ********/
                                    WriteSrcipt(PointLeft, ChartTop + Depth + ChartH - IntDatas[j][k], RawDatas[j][k]);
                                    
                                }
                                PointLeft = (float)(PointLeft + XGrid);
                            }

                            g.SmoothingMode = SmoothingMode.AntiAlias;
                        }
                    }
                }
            }
            /////========================================= 下面都是通用代码 =================================================
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                g.DrawRectangle(Pens.Gray, ChartLeft, ChartTop, ChartW, ChartH);
                //坐标轴  X Axis
                g.DrawLine(Pens.Black, ChartLeft - 4, ChartTop + ChartH - BaseLineXInt, ChartLeft + ChartW - 1, ChartTop + ChartH - BaseLineXInt);
                //Y Axis
                g.DrawLine(Pens.Black, ChartLeft, ChartTop, ChartLeft, ChartTop + ChartH + 2);
            }

            //坐标单位
            DrawAxisUnit(g, ChartLeft, ChartTop, ChartW, ChartH);

            //保存图片，清除对象
            if (Site != null)
                SaveChart(this.RootPath, b);
            else
                SaveChart(System.Web.HttpContext.Current.Server.MapPath(".") + "\\", b);
            g.Dispose();
            b.Dispose();
        }

        private void DrawPieChart()
        {

            //定位参数
            int ImageW = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2)) + this.InflateRight + this.InflateLeft;
            int ImageH = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2)) + this.InflateBottom + this.InflateTop;
            /*******************************/
            Bitmap b = new Bitmap(ImageW, ImageH);
            Graphics g = Graphics.FromImage(b);
            int ChartLeft, ChartTop, ChartRight, ChartBottom, AP3;
            ChartLeft = 50 + this.InflateLeft;
            ChartTop = 60 + this.InflateTop;
            ChartRight = 100 + this.InflateRight;
            ChartBottom = 40 + this.InflateBottom;
            int ChartW = ImageW - ChartLeft - ChartRight;
            int ChartH = ImageH - ChartTop - ChartBottom;
            /******************************/
            if (!this.ColorGuider.Show)
            {
                ChartW += 100 - 2 - ((int)g.MeasureString(this.XLabels.UnitText, this.XLabels.UnitFont).Width);
                ChartRight -= 100 - 2;
            }
            if (!this.ChartTitle.Show)
            {
                ChartH += 60 - 27;
                ChartTop -= 60 - 27;
            }
            /***************************/

            g.FillRectangle(new SolidBrush(this.Background.Paper), 0, 0, ImageW + this.InflateRight, ImageH + this.InflateBottom);

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //Draw Copyright on Chart
            if (this.ShowCopyright)
                g.DrawString(this.CopyrightText, new Font("Arial", 12, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.Gray, ImageW - 130, 0);


            //绘制图表标题
            if (!this.DataBound && this.ShowErrorInfo)
            {
                this.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            }
            else if (MinData < 0)
            {
                this.DataBound = false;
                if (this.ShowErrorInfo == true)
                {
                    this.ChartTitle.Text = "PieBar can not accept value < 0";
                }
            }
            /********************/
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            if (this.ChartTitle.Show)
                g.DrawString(this.ChartTitle.Text, this.ChartTitle.Font, new SolidBrush(this.ChartTitle.ForeColor), new Rectangle(ChartLeft + ChartW / 2 - 160, ChartTop - 40, 300, 40), sf);
            //绘制色标
            if (this.DataBound)
            {
                if (AxisX != null && this.ColorGuider.Show)
                {
                    for (int i = 0; i < MinCount; i++)
                    {
                        SolidBrush br = new SolidBrush(BarBrushColor[i % 12]);
                        //根据图表类型绘制色标   
                        g.FillRectangle(br, ChartLeft + ChartW + 6 + (int)((ImageW - ChartW) * 0.2), ChartTop + 14 * i + 4, 18, 8);
                        g.DrawRectangle(Pens.Gray, ChartLeft + ChartW + 6 + (int)((ImageW - ChartW) * 0.2), ChartTop + 4 + 14 * i, 17, 7);
                        g.TextRenderingHint = TextRenderingHint.AntiAlias;
                        g.DrawString(AxisX[i], this.ColorGuider.Font, new SolidBrush(this.ColorGuider.ForeColor), ChartLeft + ChartW + 28 + (int)((ImageW - ChartW) * 0.2), ChartTop + 1 + 14 * i);
                        br.Dispose();
                    }
                }


                //将数据转换成百分比
                float TotalSum = GetSum(RawDatas[0]);
                for (int i = 0; i < RawDatas[0].Length; i++)
                {
                    IntDatas[0][i] = (float)(RawDatas[0][i]) / TotalSum;
                }
                //绘制饼图
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int L, T, W, H;
                if (ChartW > ChartH)
                {
                    W = ChartH;
                    H = W;
                    L = ChartLeft + (int)(ChartW - ChartH) / 2;
                    T = ChartTop;
                }
                else
                {
                    W = ChartW;
                    H = W;
                    L = ChartLeft;
                    T = ChartTop + (int)(ChartH - ChartW) / 2;
                }
                Rectangle r = new Rectangle(L, T, W, H);
                r.Inflate(-10, -10);
                float cx = L + W / 2;
                float cy = T + H / 2;

                //绘制阴影
                if (this.Shadow.Enable)
                {
                    TextShadow tShadow = new TextShadow();
                    tShadow.Radius = this.Shadow.Radius;
                    tShadow.Distance = this.Shadow.Distance;
                    tShadow.Alpha = this.Shadow.Alpha;
                    tShadow.Angle = this.Shadow.Angle;
                    tShadow.DropShadow(g, r, this.Shadow.Color, "Fill", "Ellipse", null, 1);
                }

                //绘制值标签
                float LastY = T;
                float LastX = L;
                float LastY1 = T;
                float StartAngle = 0;
                int th = 0;
                if (this.Tips.Show)
                {
                    th = 10;
                }
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                for (int i = 0; i < IntDatas[0].Length; i++)
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    SolidBrush br = new SolidBrush(BarBrushColor[i % 12]);
                    Pen pn;
                    if (this.Stroke.TextureEnable)
                    {
                        HatchStyle hs = this.Stroke.TextureStyle;
                        pn = new Pen(new HatchBrush(hs, BarPenColor[0], Color.Black), this.Stroke.Width);
                    }
                    else
                    {
                        pn = new Pen(BarPenColor[0], this.Stroke.Width);
                    }
                    //pn.Alignment=PenAlignment.Inset;
                    g.FillPie(br, r, StartAngle, IntDatas[0][i] * 360);
                    if (this.Stroke.Width > 0)
                    {
                        g.DrawPie(pn, r, StartAngle, IntDatas[0][i] * 360);
                    }
                    //需要画出百分比
                    float Y = cy + (float)Math.Sin((StartAngle + IntDatas[0][i] * 180) * Math.PI / 180) * r.Width / 2;
                    float Y1 = Y;
                    float X = cx + (float)Math.Cos((StartAngle + IntDatas[0][i] * 180) * Math.PI / 180) * r.Width / 2;
                    float SX;
                    //g.SmoothingMode = SmoothingMode.None;
                    if ((StartAngle + IntDatas[0][i] * 180) > 90 && (StartAngle + IntDatas[0][i] * 180) < 270)
                    {
                        SX = L - 40 - 50;
                        if ((Math.Abs(Y - LastY) < 16 + th || Math.Abs(Y1 - LastY1) < 16 + th) && Math.Abs(SX - LastX) < ChartW / 2)
                            Y = LastY - 16 + th;
                        if (IntDatas[0][i] * 180 < 360)
                            g.DrawLine(Pens.Gray, X - 2, Y1, SX + 85, Y);
                    }
                    else
                    {
                        SX = L + W + 10;
                        if ((Math.Abs(Y - LastY) < 16 + th || Math.Abs(Y1 - LastY1) < 16 + th) && Math.Abs(SX - LastX) < ChartW / 2)
                            Y = LastY + 16 + th;
                        if (IntDatas[0][i] * 180 < 360)
                            g.DrawLine(Pens.Gray, X + 2, Y1, SX - 2, Y);
                    }
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    string str = "";
                    //详细值标签显示
                    if (this.Tips.Show)// && (IntDatas[0][i] * 180) >= 20)
                    {
                        str = AxisX[i] + "\n" + RawDatas[0][i] + " ";
                    }
                    str += (IntDatas[0][i] * 100).ToString("0.00") + "%";
                    if (IntDatas[0][i] * 180 < 360)
                    {
                        g.DrawString(str, this.Tips.Font, new SolidBrush(this.Tips.ForeColor), SX, Y - 6 - 5);
                    }
                    else
                    {
                        g.DrawString(str, this.Tips.Font, new SolidBrush(this.Tips.ForeColor), X - 50 - th, Y1 - 6 - 5);
                    }

                    LastY = Y;
                    LastX = SX;
                    LastY1 = Y1;
                    StartAngle += IntDatas[0][i] * 360;
                    pn.Dispose();
                    br.Dispose();
                }

                //绘制水晶效果
                if (this.Crystal.Enable)
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    if (this.Crystal.CoverFull)
                    {//绘制全水晶效果
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        Rectangle nr = new Rectangle((int)(r.Left - r.Width / 4), (int)(r.Top - r.Height / 4), r.Width, r.Height);
                        GraphicsPath ngp = new GraphicsPath();
                        ngp.AddEllipse(nr);
                        //建立高光笔刷
                        PathGradientBrush pgb = new PathGradientBrush(ngp);
                        pgb.CenterColor = Color.FromArgb(165, Color.White);
                        pgb.SurroundColors = new Color[] { Color.FromArgb(0, Color.White) };
                        //建立高光笔刷
                        Region nrg = new Region(ngp);
                        g.SetClip(nrg, CombineMode.Intersect);
                        //两个剪裁的交集
                        ngp = new GraphicsPath();
                        ngp.AddEllipse(r);
                        nrg = new Region(ngp);
                        g.SetClip(nrg, CombineMode.Intersect);
                        //绘制高光
                        g.FillEllipse(pgb, nr);
                        //Dispose对象
                        pgb.Dispose();
                        nrg.Dispose();
                        ngp.Dispose();
                        g.SmoothingMode = SmoothingMode.None;
                    }
                    else
                    {//绘制玻璃质的水晶效果
                        int adj = 3;
                        Rectangle ur = new Rectangle((int)(r.Left + r.Width / 6), r.Top + adj, (int)(r.Width * 2 / 3), (int)(r.Height / 2 - adj));
                        LinearGradientBrush ulrb = new LinearGradientBrush(new Point(ur.Left, ur.Top), new Point(ur.Left, ur.Top + ur.Height + 1), Color.FromArgb(230, Color.White), Color.FromArgb(0, Color.White));
                        g.FillEllipse(ulrb, ur);
                        ulrb.Dispose();
                        Rectangle dr = new Rectangle(r.Left, (int)(r.Top + r.Height / 2 + 1), r.Width, (int)(r.Height / 2 + 1));
                        LinearGradientBrush dlrb = new LinearGradientBrush(new Point(dr.Left, dr.Top + dr.Height), new Point(dr.Left, dr.Top), Color.FromArgb(230, Color.White), Color.FromArgb(0, Color.White));
                        GraphicsPath gp = new GraphicsPath();
                        r.Inflate(1, 1);
                        gp.AddEllipse(r);
                        Region rg = new Region(gp);
                        g.SetClip(rg, CombineMode.Replace);
                        g.FillRectangle(dlrb, dr);
                        g.SetClip(new Rectangle(0, 0, ImageW, ImageH));
                        //Dispose 对象
                        gp.Dispose();
                        rg.Dispose();
                        dlrb.Dispose();
                    }
                    g.SmoothingMode = SmoothingMode.None;
                }

            }//eof DataBound
            /////========================================= 下面都是通用代码 =================================================
            //保存图片，清除对象
            if (Site != null)
                SaveChart(this.RootPath, b);
            else
                SaveChart(System.Web.HttpContext.Current.Server.MapPath(".") + "\\", b);
            g.Dispose();
            b.Dispose();
        }

        private void DrawPieChart3D()
        {
            //定位参数
            int ImageW = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2)) + this.InflateRight + this.InflateLeft;
            int ImageH = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2)) + this.InflateBottom + this.InflateTop;
            /*******************************/
            Bitmap b = new Bitmap(ImageW, ImageH);
            Graphics g = Graphics.FromImage(b);
            int ChartLeft, ChartTop, ChartRight, ChartBottom, AP3;
            ChartLeft = 50 + this.InflateLeft;
            ChartTop = 60 + this.InflateTop;
            ChartRight = 100 + this.InflateRight;
            ChartBottom = 40 + this.InflateBottom;
            int ChartW = ImageW - ChartLeft - ChartRight;
            int ChartH = ImageH - ChartTop - ChartBottom;
            /******************************/
            if (!this.ColorGuider.Show)
            {
                ChartW += 100 - 2 - ((int)g.MeasureString(this.XLabels.UnitText, this.XLabels.UnitFont).Width);
                ChartRight -= 100 - 2;
            }
            if (!this.ChartTitle.Show)
            {
                ChartH += 60 - 27;
                ChartTop -= 60 - 27;
            }
            /***************************/

            g.FillRectangle(new SolidBrush(this.Background.Paper), 0, 0, ImageW + this.InflateRight, ImageH + this.InflateBottom);

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //Draw Copyright on Chart
            if (this.ShowCopyright)
                g.DrawString(this.CopyrightText, new Font("Arial", 12, FontStyle.Italic, GraphicsUnit.Pixel), Brushes.Gray, ImageW - 130, 0);


            //绘制图表标题
            if (!this.DataBound && this.ShowErrorInfo)
            {
                this.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            }
            else if (MinData < 0)
            {
                this.DataBound = false;
                if (this.ShowErrorInfo == true)
                {
                    this.ChartTitle.Text = "PieBar can not accept value < 0";
                }
            }
            /*****************************/
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            if(this.ChartTitle.Show)
                g.DrawString(this.ChartTitle.Text, this.ChartTitle.Font, new SolidBrush(this.ChartTitle.ForeColor), new Rectangle(ChartLeft, 20 - 50 + this.ChartTitle.OffsetY, ChartW, 100), sf);
            
            if (this.DataBound)
            {
                //将数据转换成百分比
                float TotalSum = GetSum(RawDatas[0]);
                if (TotalSum > 0)
                {
                    for (int i = 0; i < RawDatas[0].Length; i++)
                    {
                        IntDatas[0][i] = (float)RawDatas[0][i] / TotalSum;
                    }
                }
                else
                {
                    for (int i = 0; i < RawDatas[0].Length; i++)
                    {
                        IntDatas[0][i] = 0;
                    }
                }

                //绘制色标
                if (AxisX != null && this.ColorGuider.Show)
                {
                    for (int i = 0; i < MinCount; i++)
                    {
                        SolidBrush br = new SolidBrush(BarBrushColor[i % 12]);
                        //根据图表类型绘制色标   
                        g.FillRectangle(br, ChartLeft + ChartW + (int)((ImageW - ChartW) * 0.2), ChartTop + 14 * i + 4, 18, 8);
                        g.DrawRectangle(Pens.Gray, ChartLeft + ChartW + (int)((ImageW - ChartW) * 0.2), ChartTop + 4 + 14 * i, 17, 7);
                        g.TextRenderingHint = TextRenderingHint.AntiAlias;
                        if (TotalSum > 0 && IntDatas[0][i] > 0)
                        {
                            g.DrawString(AxisX[i], this.ColorGuider.Font,new SolidBrush(this.ColorGuider.ForeColor), ChartLeft + ChartW + 22 + (int)((ImageW - ChartW) * 0.2), ChartTop + 1 + 14 * i);
                        }
                        else
                        {
                            g.DrawString(AxisX[i] + "(0)", this.ColorGuider.Font, new SolidBrush(this.ColorGuider.ForeColor),ChartLeft + ChartW + 22 + (int)((ImageW - ChartW) * 0.2), ChartTop + 1 + 14 * i);
                        }
                        br.Dispose();
                    }
                }


                ////绘制饼图
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int depth = 30;
                PointF[] StartPoints = new PointF[IntDatas[0].Length];
                PointF[] MidPoints = new PointF[IntDatas[0].Length];
                float[] StartAngles = new float[IntDatas[0].Length];
                //准备两个矩形
                Rectangle PieTopRect = new Rectangle(ChartLeft, ChartTop, ChartW, ChartH);
                PieTopRect.Inflate((int)(-1 * ChartW * 0.1), (int)(-1 * ChartH * 0.0));
                PieTopRect.Offset((int)(-1 * ChartW * 0.1 / 2), 0);
                Rectangle PieBottomRect = PieTopRect;
                PieBottomRect.Offset(0, depth);
                float cx = PieTopRect.Left + PieTopRect.Width / 2;
                float cy = PieTopRect.Top + PieTopRect.Height / 2;
                ////绘制最底层椭圆
                g.DrawEllipse(Pens.Silver, PieBottomRect);
                ////准备每个Pie的开始点
                GraphicsPath gp = new GraphicsPath();
                GraphicsPath gpi = new GraphicsPath();
                float sa = 0;
                if (TotalSum > 0)
                {
                    for (int i = 0; i < IntDatas[0].Length; i++)
                    {
                        StartAngles[i] = sa;
                        if (IntDatas[0][i] > 0)
                        {
                            gp.AddArc(PieTopRect, sa, IntDatas[0][i] * 360);
                            StartPoints[i] = gp.PathPoints[0];
                        }
                        else
                        {//值为零时要特殊处理
                            if (i == 0 || i == IntDatas[0].Length - 1)
                            {
                                StartPoints[i] = new PointF(PieTopRect.Left + PieTopRect.Width, PieTopRect.Top + PieTopRect.Height / 2);
                            }
                            else
                            {
                                if (IntDatas[0][i + 1] > 0)
                                {
                                    gp.AddArc(PieTopRect, sa, IntDatas[0][i + 1] * 360);
                                    StartPoints[i] = gp.PathPoints[0];
                                }
                                else
                                {
                                    StartPoints[i] = StartPoints[i - 1];
                                }
                            }
                        }
                        sa += IntDatas[0][i] * 360;
                        //绘制里面的隔板
                        if (StartAngles[i] >= 0 && StartAngles[i] <= 180)
                        {
                            gpi.AddLine(cx, cy, cx, cy + depth);
                            gpi.AddLine(cx, cy + depth, StartPoints[i].X, StartPoints[i].Y + depth);
                            gpi.AddLine(StartPoints[i].X, StartPoints[i].Y + depth, StartPoints[i].X, StartPoints[i].Y);
                            gpi.AddLine(StartPoints[i].X, StartPoints[i].Y, cx, cy);
                            g.FillPath(new SolidBrush(Color.FromArgb(200, BarBrushColor[i % 12])), gpi);
                            gpi.Reset();
                        }
                        gp.Reset();
                    }
                    //准备1/2点
                    sa = 0;
                    for (int i = 0; i < IntDatas[0].Length; i++)
                    {
                        StartAngles[i] = sa;
                        if (IntDatas[0][i] > 0)
                        {
                            gp.AddArc(PieTopRect, sa, IntDatas[0][i] * 360 / 2);
                            MidPoints[i] = gp.PathPoints[gp.PathPoints.Length - 1];
                        }
                        else
                        {//值为零时要特殊处理
                            if (i == 0 || i == IntDatas[0].Length - 1)
                            {
                                MidPoints[i] = new PointF(PieTopRect.Left + PieTopRect.Width, PieTopRect.Top + PieTopRect.Height / 2);
                            }
                            else
                            {
                                if (IntDatas[0][i + 1] > 0)
                                {
                                    gp.AddArc(PieTopRect, sa, IntDatas[0][i + 1] * 360 / 2);
                                    MidPoints[i] = gp.PathPoints[gp.PathPoints.Length - 1];
                                }
                                else
                                {
                                    MidPoints[i] = MidPoints[i - 1];
                                }
                            }
                        }
                        sa += IntDatas[0][i] * 360;
                        gp.Reset();
                    }
                }
                ////绘制上盖Pie
                if (TotalSum > 0)
                {
                    for (int i = 0; i < IntDatas[0].Length; i++)
                    {
                        if (IntDatas[0][i] > 0)
                        {
                            byte al = 255;
                            if (i < IntDatas[0].Length - 1)
                            {
                                if (StartAngles[i + 1] <= 180)
                                {
                                    al = 200;
                                }
                            }
                            g.FillPie(new SolidBrush(Color.FromArgb(al, BarBrushColor[i % 12])), PieTopRect, StartAngles[i], IntDatas[0][i] * 360);
                            ////是否使用Flat Crystal效果
                            if (this.Crystal.Enable == true && this.Crystal.CoverFull == true)
                            {
                                if (IntDatas[0][i] * 360 > 30 && IntDatas[0][i] * 360 <= 180)
                                {
                                    if (i < IntDatas[0].Length - 1)
                                        try
                                        {
                                            g.FillPie(new LinearGradientBrush(StartPoints[i], StartPoints[i + 1], Color.FromArgb(178, Color.White), Color.FromArgb(25, Color.White)), PieTopRect, StartAngles[i], IntDatas[0][i] * 360);
                                        }
                                        catch (Exception ee)
                                        {
                                        }
                                    else
                                        g.FillPie(new LinearGradientBrush(StartPoints[i], StartPoints[0], Color.FromArgb(128, Color.White), Color.FromArgb(0, Color.White)), PieTopRect, StartAngles[i], IntDatas[0][i] * 360);
                                }
                            }
                        }
                    }
                }
                else
                {
                    g.FillPie(new SolidBrush(Color.FromArgb(200, BarBrushColor[0])), PieTopRect, 0, 360);
                }
                ////绘制前表面路径
                if (TotalSum > 0)
                {
                    for (int i = 0; i < IntDatas[0].Length; i++)
                    {
                        if (IntDatas[0][i] > 0)
                        {
                            float enpx;
                            float enpy;
                            float enagl;
                            if (StartAngles[i] < 180)
                            {
                                if (i < IntDatas[0].Length - 1)
                                {
                                    if (StartAngles[i + 1] <= 180)
                                    {
                                        enpx = StartPoints[i + 1].X;
                                        enpy = StartPoints[i + 1].Y;
                                        enagl = StartAngles[i + 1] - StartAngles[i];
                                    }
                                    else
                                    {
                                        enpx = PieTopRect.Left;
                                        enpy = PieTopRect.Top + PieTopRect.Height / 2;
                                        enagl = 180 - StartAngles[i];
                                    }
                                }
                                else
                                {
                                    enpx = PieTopRect.Left;
                                    enpy = PieTopRect.Top + PieTopRect.Height / 2;
                                    enagl = 180 - StartAngles[i];
                                }
                                gpi.AddArc(PieTopRect, StartAngles[i], enagl);
                                gpi.AddLine(enpx, enpy, enpx, enpy + depth);
                                gpi.AddArc(PieBottomRect, StartAngles[i], enagl);
                                gpi.AddLine(StartPoints[i].X, StartPoints[i].Y + depth, StartPoints[i].X, StartPoints[i].Y);
                                g.FillPath(new SolidBrush(Color.FromArgb(220, BarBrushColor[i % 12])), gpi);
                                gpi.Reset();
                            }
                        }
                    }
                }
                else
                {
                    gpi.AddArc(PieTopRect, 0, 180);
                    gpi.AddLine(PieTopRect.X, PieTopRect.Y + PieTopRect.Height / 2, PieTopRect.X, PieTopRect.Y + PieTopRect.Height / 2 + depth);
                    gpi.AddArc(PieBottomRect, 0, 180);
                    gpi.AddLine(PieTopRect.X + PieTopRect.Width, PieTopRect.Y + PieTopRect.Height / 2 + depth, PieTopRect.X + PieTopRect.Width, PieTopRect.Y + PieTopRect.Height / 2);
                    g.FillPath(new SolidBrush(Color.FromArgb(220, BarBrushColor[0])), gpi);
                    gpi.Reset();
                }
                //multi color gradient
                Point StartPoint = new Point(PieTopRect.Left, 0);
                Point EndPoint = new Point(PieTopRect.Left + PieTopRect.Width, 0);
                Color[] GColors ={
                                Color.FromArgb(180,Color.Black),
                                Color.FromArgb(100,Color.White),
                                Color.FromArgb(180,Color.Black)
                            };
                float[] GPoints ={
                                0.0f,
                                0.7f,
                                1.0f
                            };
                ColorBlend CB = new ColorBlend();
                CB.Colors = GColors;
                CB.Positions = GPoints;
                LinearGradientBrush lgb = new LinearGradientBrush(StartPoint, EndPoint, Color.Red, Color.Red);
                lgb.InterpolationColors = CB;
                //加上高光
                GraphicsPath gpg = new GraphicsPath();
                gpg.AddArc(PieTopRect, 0, 180);
                gpg.AddLine(PieTopRect.Left, PieTopRect.Top + PieTopRect.Height / 2, PieBottomRect.Left, PieBottomRect.Top + PieBottomRect.Height / 2);
                gpg.AddArc(PieBottomRect, 0, 180);
                gpg.AddLine(PieBottomRect.Left + PieBottomRect.Width, PieBottomRect.Top + PieBottomRect.Height / 2, PieTopRect.Left + PieTopRect.Width, PieTopRect.Top + PieTopRect.Height / 2);
                g.FillPath(lgb, gpg);

                //绘制百分比标识
                float smallx = PieTopRect.Left + PieTopRect.Width + 20;
                float smally = 0;
                float dy = 0;
                float ty = 0;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                for (int i = 0; i < IntDatas[0].Length; i++)
                {
                    if (IntDatas[0][i] > 0)
                    {
                        float apx;
                        float apy;
                        apx = (cx + MidPoints[i].X) / 2;
                        apy = (cy + MidPoints[i].Y) / 2;
                        string str = "";
                        if (IntDatas[0][i] * 360 >= 20)
                        {
                            if (this.Tips.Show)
                            {
                                str = AxisX[i] + "\n" + RawDatas[0][i].ToString() + "\n";
                            }
                            str += (IntDatas[0][i] * 100).ToString("0.0") + "%";
                            g.DrawString(str, this.Tips.Font,new SolidBrush(this.Tips.ForeColor), apx - 10, apy - 4);
                        }
                        else
                        {
                            //小角度百分比
                            if (StartAngles[i] < 180)
                            {
                                if (dy == 0)
                                {
                                    dy = PieTopRect.Top + PieTopRect.Height / 2;
                                }
                                else
                                {
                                    dy += 16;//高度间距
                                    if (this.Tips.Show)
                                    {
                                        dy += 12;
                                    }
                                }
                                smally = dy;
                            }
                            else
                            {
                                if (ty == 0)
                                {
                                    ty = PieTopRect.Top - (PieTopRect.Top - ChartTop) / 4;
                                }
                                else
                                {
                                    ty += 16;//高度间距
                                    if (this.Tips.Show)
                                    {
                                        ty += 12;
                                    }
                                }
                                smally = ty;
                            }
                            //根据Tips.Show判断是否要绘制全部信息
                            if (this.Tips.Show)
                            {
                                str = AxisX[i] + "\n" + RawDatas[0][i].ToString() + "  ";
                            }
                            str += (IntDatas[0][i] * 100).ToString("0.0") + "%";
                            g.DrawString(str, this.Tips.Font, new SolidBrush(this.Tips.ForeColor), smallx, smally);
                            g.DrawLine(Pens.Gray, smallx, smally + 6, MidPoints[i].X, MidPoints[i].Y);
                        }
                    }
                }

                gp.Dispose();
                gpi.Dispose();

                g.DrawEllipse(Pens.Silver, PieTopRect);
            }
            /////========================================= 下面都是通用代码 =================================================
            //保存图片，清除对象
            if (Site != null)
                SaveChart(this.RootPath, b);
            else
                SaveChart(System.Web.HttpContext.Current.Server.MapPath(".") + "\\", b);
            g.Dispose();
            b.Dispose();
        }

        private void DrawTrendChart()
        {
            int ImageW = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2)) + this.InflateRight + this.InflateLeft;
            int ImageH = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2)) + this.InflateBottom + this.InflateTop;
            /******************************/
            Bitmap b = new Bitmap(ImageW, ImageH);
            Graphics g = Graphics.FromImage(b);
            int ChartLeft, ChartTop, ChartRight, ChartBottom, AP3;
            ChartLeft = 50 + this.InflateLeft;
            ChartTop = 60 + this.InflateTop;
            ChartRight = 100 + this.InflateRight;
            ChartBottom = 40 + this.InflateBottom;
            int ChartW = ImageW - ChartLeft - ChartRight;
            int ChartH = ImageH - ChartTop - ChartBottom;
            //////////////////////////////////////////
            if (!this.DataBound && this.ShowErrorInfo)
            {
                this.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            }
            //****** 处理第一列时间参数 - 数据源******//
            DateTime[] XTimes = new DateTime[AxisX.Length];
            for (int i = 0; i < AxisX.Length; i++)
            {
                try
                {
                    XTimes[i] = DateTime.Parse(AxisX[i]);
                }
                catch (Exception ee)
                {
                    this.ChartTitle.Text = "The first column of your data must be DateTime!";
                    this.DataBound = false;
                }
            }
            //********* 准备X坐标标签 - 标准坐标***********//
            int XCount = 0;
            DateTime Ttemp=this.Trend.Start;
            while (Ttemp <= this.Trend.End)
            {
                switch (this.Trend.TimeSpan)
                {
                    case TimeSpanTypes.Year: Ttemp = Ttemp.AddYears(1); break;
                    case TimeSpanTypes.Month: Ttemp = Ttemp.AddMonths(1); break;
                    case TimeSpanTypes.Day: Ttemp = Ttemp.AddDays(1); break;
                    case TimeSpanTypes.Hour: Ttemp = Ttemp.AddHours(1); break;
                    case TimeSpanTypes.Minute: Ttemp = Ttemp.AddMinutes(1); break;
                    case TimeSpanTypes.Second: Ttemp = Ttemp.AddSeconds(1); break;
                    case TimeSpanTypes.Millisecond: Ttemp = Ttemp.AddMilliseconds(1); break;
                    default: Ttemp = Ttemp.AddDays(1); break;
                }
                XCount++;
            }
            if (XCount == 0)
            {
                this.DataBound = false;
                this.ChartTitle.Text = "Please set Chartlet.Trend attribute for TrendChart.";
            }
            /*********绘制背景*************/
            if (!this.ColorGuider.Show)
            {
                ChartW += 100 - 2 - ((int)g.MeasureString(this.XLabels.UnitText, this.XLabels.UnitFont).Width);
                ChartRight -= 100 - 2;
            }
            if (!this.YLabels.Show)
            {
                ChartW += 50 - 2;
                ChartLeft -= 50 - 2;
            }
            if (!this.ChartTitle.Show)
            {
                ChartH += 60 - 27;
                ChartTop -= 60 - 27;
            }
            int Depth = 0; int DP3 = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                Depth = (int)(this.Depth3D * 0.85);
                DP3 = this.Depth3D;
                PaintBackground3D(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = this.Alpha3D;
            }
            else
            {
                PaintBackground(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = 255;
            }
            /****************************/
            Pen BackPen = new Pen(Color.FromArgb(255, 220, 220, 220)); 
            
            //绘制线条
            if (this.DataBound)
            {//是否绑定了数据

                //创建X坐标的时间标签
                DateTime[] XStands = new DateTime[XCount + 1];
                XCount = 0;
                Ttemp = this.Trend.Start;
                while (Ttemp < this.Trend.End)
                {
                    XStands[XCount] = Ttemp;
                    switch (this.Trend.TimeSpan)
                    {
                        case TimeSpanTypes.Year: Ttemp = Ttemp.AddYears(1); break;
                        case TimeSpanTypes.Month: Ttemp = Ttemp.AddMonths(1); break;
                        case TimeSpanTypes.Day: Ttemp = Ttemp.AddDays(1); break;
                        case TimeSpanTypes.Hour: Ttemp = Ttemp.AddHours(1); break;
                        case TimeSpanTypes.Minute: Ttemp = Ttemp.AddMinutes(1); break;
                        case TimeSpanTypes.Second: Ttemp = Ttemp.AddSeconds(1); break;
                        case TimeSpanTypes.Millisecond: Ttemp = Ttemp.AddMilliseconds(1); break;
                        default: Ttemp = Ttemp.AddDays(1); break;
                    }
                    XCount++;
                }
                XStands[XCount] = this.Trend.End;
                //************* 绘制横坐标标签 ***************//
                int XStep = ChartW / (XCount);
                for (int i = 0; i <= XCount; i++)
                {
                    if (i != 0 && i != XCount)
                        DrawXLine(g, BackPen, DP3, ChartTop, ChartH, ChartLeft + i * XStep, XStep);
                    DrawXText(g, BackPen, XStands[i].ToString(this.Trend.ValueFormat), DP3, ChartTop, ChartH, ChartLeft + i * XStep, XStep);
                }

                //SmoothMode,Start to draw line chart
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                int GroupSize = this.GroupSize;
                int ElementCount = MaxCount;
                if (ElementCount > 0)
                {

                    /////=============================================上面都是通用代码=================================================
                    /////////////////////////  Line Chart ///////////////////////////
                    //X坐标上的间距宽度
                    int XGrid = (int)(ChartW / ElementCount);
                    //=== 下面开始绘制 LineChart =====//
                    for (int j = 0; j < GroupSize; j++)
                    {
                        int LastPointLeft = ChartLeft;

                        SolidBrush LineBrush = new SolidBrush(Color.FromArgb(AP3, BarPenColor[j % 12]));
                        Pen LinePen;
                        if (this.Stroke.TextureEnable)
                        {
                            HatchStyle hs = this.Stroke.TextureStyle;
                            LinePen = new Pen(new HatchBrush(hs, BarPenColor[j % 12], Color.Black), this.Stroke.Width);
                        }
                        else
                        {
                            LinePen = new Pen(BarPenColor[j % 12], this.Stroke.Width);
                        }
                        GraphicsPath gp = new GraphicsPath();


                        int i;
                        for (i = 0; i < ElementCount ; i++)
                        {
                            int PointLeft = ChartLeft;
                            switch (this.Trend.TimeSpan)
                            {
                                case TimeSpanTypes.Day: PointLeft += (int)(((XTimes[i] - this.Trend.Start).TotalHours / (this.Trend.End - this.Trend.Start).TotalHours) * ChartW); break;
                                case TimeSpanTypes.Hour: PointLeft += (int)(((XTimes[i] - this.Trend.Start).TotalMinutes / (this.Trend.End - this.Trend.Start).TotalMinutes) * ChartW); break;
                                case TimeSpanTypes.Minute: PointLeft += (int)(((XTimes[i] - this.Trend.Start).TotalSeconds / (this.Trend.End - this.Trend.Start).TotalSeconds) * ChartW); break;
                                case TimeSpanTypes.Second: PointLeft += (int)(((XTimes[i] - this.Trend.Start).TotalMilliseconds / (this.Trend.End - this.Trend.Start).TotalMilliseconds) * ChartW); break;
                                case TimeSpanTypes.Millisecond: PointLeft += (int)(((XTimes[i] - this.Trend.Start).TotalMilliseconds / (this.Trend.End - this.Trend.Start).TotalMilliseconds) * ChartW); break;
                                default: PointLeft += (int)(((XTimes[i] - this.Trend.Start).TotalDays / (this.Trend.End - this.Trend.Start).TotalDays) * ChartW); break;
                            }
                            //绘制折线
                            if (RawDatas[j][i] != -0.830213m && XTimes[i] <= this.Trend.End)
                            {
                                if (this.Dimension == ChartDimensions.Chart2D)
                                {
                                    g.SmoothingMode = SmoothingMode.AntiAlias;
                                    if (i > 0 && PointLeft >= LastPointLeft)
                                    {
                                        if (RawDatas[j][i - 1] != -0.830213m)
                                        {
                                            DrawLine2D(g, LinePen, LastPointLeft, ChartTop + ChartH - IntDatas[j][i - 1], PointLeft, ChartTop + ChartH - IntDatas[j][i]);
                                        }
                                    }

                                    g.SmoothingMode = SmoothingMode.None;
                                    LineConnectionTypes LineConnectionType = this.LineConnectionType;//Linechart属性
                                    int ConntionRadius = this.LineConnectionRadius;//Linechart属性
                                    if (LineConnectionType == LineConnectionTypes.Round)
                                    {
                                        g.FillEllipse(LineBrush, PointLeft - ConntionRadius / 2, ChartTop + ChartH - IntDatas[j][i] - ConntionRadius / 2, ConntionRadius, ConntionRadius);
                                    }
                                    else if (LineConnectionType == LineConnectionTypes.Square)
                                    {
                                        g.FillRectangle(LineBrush, PointLeft - ConntionRadius / 2, ChartTop + ChartH - IntDatas[j][i] - ConntionRadius / 2, ConntionRadius, ConntionRadius);
                                    }
                                }
                                else if (this.Dimension == ChartDimensions.Chart3D)
                                {
                                    g.SmoothingMode = SmoothingMode.AntiAlias;
                                    float halfRadius = this.LineConnectionRadius / 2;
                                    if (this.LineConnectionType == LineConnectionTypes.None)
                                    {
                                        halfRadius = 0;
                                    }
                                    DrawLineConnection3D(g, LinePen, LineBrush, Depth, halfRadius, PointLeft, ChartTop + ChartH - IntDatas[j][i], j);
                                    //绘制3D折线面
                                    if (i > 0 && PointLeft>=LastPointLeft)
                                    {
                                        if (RawDatas[j][i - 1] != -0.830213m)
                                        {
                                            DrawLineSurface3D(g, LinePen, LineBrush, Depth, halfRadius, LastPointLeft, ChartTop + ChartH - IntDatas[j][i - 1], PointLeft, ChartTop + ChartH - IntDatas[j][i]);
                                        }
                                    }
                                }
                                //绘制值标签
                                if (this.Tips.Show)
                                {
                                    DrawTips(g, RawDatas[j][i].ToString(this.Tips.ValueFormat), (int)(PointLeft), (int)(ChartTop + ChartH - IntDatas[j][i] - this.LineConnectionRadius / 2), PointLeft - LastPointLeft, (int)IntDatas[j][i], false);
                                }
                                /******* 构建客户端参数 ********/
                                WriteSrcipt(PointLeft - Depth, ChartTop + Depth + ChartH - IntDatas[j][i], RawDatas[j][i]);
                            }
                            LastPointLeft = PointLeft;
                        }
                        LinePen.Dispose();
                        gp.Dispose();
                    }
                }
            }
            /////========================================= 下面都是通用代码 =================================================
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                g.DrawRectangle(Pens.Gray, ChartLeft, ChartTop, ChartW, ChartH);
                //坐标轴  X Axis
                g.DrawLine(Pens.Black, ChartLeft - 4, ChartTop + ChartH - BaseLineXInt, ChartLeft + ChartW - 1, ChartTop + ChartH - BaseLineXInt);
                //Y Axis
                g.DrawLine(Pens.Black, ChartLeft, ChartTop, ChartLeft, ChartTop + ChartH + 2);
            }
            //坐标单位
            DrawAxisUnit(g, ChartLeft, ChartTop, ChartW, ChartH);

            //保存图片，清除对象
            if (Site != null)
                SaveChart(this.RootPath, b);
            else
                SaveChart(System.Web.HttpContext.Current.Server.MapPath(".") + "\\", b);
            g.Dispose();
            b.Dispose();
        }

        private void DrawHistoChart()
        {
            int ImageW = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2)) + this.InflateRight + this.InflateLeft;
            int ImageH = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2)) + this.InflateBottom + this.InflateTop;
            /******************************/
            Bitmap b = new Bitmap(ImageW, ImageH);
            Graphics g = Graphics.FromImage(b);
            int ChartLeft, ChartTop, ChartRight, ChartBottom, AP3;
            ChartLeft = 50 + this.InflateLeft;
            ChartTop = 60 + this.InflateTop;
            ChartRight = 100 + this.InflateRight;
            ChartBottom = 40 + this.InflateBottom;
            int ChartW = ImageW - ChartLeft - ChartRight;
            int ChartH = ImageH - ChartTop - ChartBottom;
            /*********绘制背景*************/
            if (!this.ColorGuider.Show)
            {
                ChartW += 100 - 2 - ((int)g.MeasureString(this.XLabels.UnitText, this.XLabels.UnitFont).Width);
                ChartRight -= 100 - 2;
            }
            if (!this.YLabels.Show)
            {
                ChartW += 50 - 2;
                ChartLeft -= 50 - 2;
            }
            if (!this.ChartTitle.Show)
            {
                ChartH += 60 - 27;
                ChartTop -= 60 - 27;
            }
            if (!this.DataBound && this.ShowErrorInfo)
            {
                this.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            }
            int Depth = 0;
            if (this.Dimension == ChartDimensions.Chart3D)
            {
                Depth = (int)(this.Depth3D * 0.85);
                PaintBackground3D(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = this.Alpha3D;
            }
            else
            {
                PaintBackground(g, ChartLeft, ChartTop, ChartW, ChartH);
                AP3 = 255;
            }
            /***** 20120513 change AP3 for group histo *****/
            if (this.GroupSize > 1)
            {
                AP3 = this.Alpha3D;
            }
            AP3 = this.Alpha3D;

            /*******************************************/
            if (this.DataBound)
            {//是否绑定了数据
                //绘制柱子
                //g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                Pen BackPen = new Pen(Color.FromArgb(255, 220, 220, 220));

                //***** For SpecLimits and Means *****
                int LastXAix = ChartLeft;
                int CurrentXAix = ChartLeft;

                int GroupSize = this.GroupSize;
                int ElementCount = MaxCount;
                if (ElementCount > 0)
                {
                    ////计算柱子宽度柱子间距
                    int BarGapW, BarW;
                    if ((this.AutoBarWidth == false) && (ElementCount * GroupSize < 12))
                    {
                        BarGapW = (int)(ChartW / 4 / (1 + 5 * 3));
                        BarW = 5 * BarGapW;
                    }
                    else
                    {
                        BarW = (int)(ChartW / ElementCount / (0.1 + 1));
                        BarGapW = (int)(0.1 * BarW);

                        //BarW = (int)(ChartW / ElementCount / (0.25 + GroupSize));
                        //BarGapW = (int)(0.25 * BarW);
                    }
                    //BarW = 5 * BarGapW;
                    int BarSN; int BarH; int BarTop; int BarLeft;

                    //循环绘制柱子
                    for (int i = 0; i < ElementCount; i++)
                    {
                        SolidBrush BarBrush; Pen BarPen;
                        BarSN = i;
                        /***** 20120513 for multip-group historgram *****/
                        //BarLeft = ChartLeft + BarW * BarSN * this.GroupSize + BarGapW * (BarSN + 1);
                        BarLeft = ChartLeft + BarW * BarSN + BarGapW * (BarSN + 1);


                        /***********绘制横坐标标识元素*************/
                        int DP3 = (int)(Depth / 0.85);
                        DrawXLine(g, BackPen, DP3, ChartTop, ChartH, BarLeft + BarW * GroupSize / 2, BarW * GroupSize + BarGapW);
                        CurrentXAix = BarLeft + BarW * GroupSize / 2;
                        if (this.XLabels.Show && (i % this.XLabels.SampleSize == 0))
                        {
                            DrawXText(g, BackPen, AxisX[i], DP3, ChartTop, ChartH, BarLeft + BarW * GroupSize / 2, BarW * GroupSize + BarGapW);
                        }

                        /****************************************/
                        bool BelowX = false;
                        for (int j = 0; j < GroupSize; j++)
                        {
                            if (RawDatas[j][i] != -0.830213m)
                            {
                                BarH = (int)(IntDatas[j][i] - BaseLineXInt - 1);
                                if (BarH < 0)
                                {
                                    BarH = -1 * BarH;
                                    BarTop = ChartTop + ChartH - (int)BaseLineXInt;
                                    BelowX = true;
                                }
                                else
                                {
                                    BarTop = ChartTop + ChartH - BarH - (int)(BaseLineXInt);
                                    BelowX = false;
                                }

                                if (GroupSize == 1 && this.Colorful)
                                    if (this.Dimension == ChartDimensions.Chart3D)
                                        BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[i % 12]));
                                    else
                                        //BarBrush = new SolidBrush(BarBrushColor[i % 12]);
                                        BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[i % 12]));
                                else
                                    if (this.Dimension == ChartDimensions.Chart3D)
                                        BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[j % 12]));
                                    else
                                       // BarBrush = new SolidBrush(BarBrushColor[j % 12]);
                                        BarBrush = new SolidBrush(Color.FromArgb(AP3, BarBrushColor[j % 12]));

                                if (this.Stroke.TextureEnable)
                                {
                                    HatchStyle hs = this.Stroke.TextureStyle;
                                    BarPen = new Pen(new HatchBrush(hs, BarPenColor[j % 12], Color.Gray), this.Stroke.Width);
                                }
                                else
                                {
                                    BarPen = new Pen(BarPenColor[j % 12], this.Stroke.Width);
                                }
                                BarPen.Alignment = PenAlignment.Inset;

                                if (this.Dimension == ChartDimensions.Chart3D)
                                {//3D
                                    DrawBarBase3D(g, BarBrush, BarPen, BarLeft, BarTop, BarW, BarH, Depth);
                                }
                                else
                                {//2D
                                    DrawBarBase2D(g, BarBrush, BarPen, BarLeft, BarTop, BarW, BarH);
                                }
                                //******* 绘制水晶效果 *******//
                                if (this.Crystal.Enable && BarH - this.Crystal.Contraction * 2 > 2 && BarW - this.Crystal.Contraction * 2 > 2)
                                {
                                    DrawBarCrystal(g, BarLeft, BarTop, BarW, BarH, Depth);
                                }

                                //值标签
                                //g.DrawRectangle(new Pen(BarBrush),BarLeft+BarW/2,BarTop-30,40,18);
                                if (this.Tips.Show)
                                {
                                    DrawTips(g, RawDatas[j][i].ToString(this.Tips.ValueFormat), BarLeft, BarTop, BarW, BarH, BelowX);
                                }
                                //else{

                                /******* 构建客户端参数 ********/
                                if (StrBarL == "")
                                {
                                    StrBarL = "" + (BarLeft - Depth);
                                    StrBarW = "" + BarW;
                                    StrBarT = "" + (BarTop + Depth);
                                    StrBarH = "" + BarH;
                                    StrBarV = "" + RawDatas[j][i];
                                }
                                else
                                {
                                    StrBarL += "," + (BarLeft - Depth);
                                    StrBarW += "," + BarW;
                                    StrBarT += "," + (BarTop + Depth);
                                    StrBarH += "," + BarH;
                                    StrBarV += "," + RawDatas[j][i];
                                }
                                /*******************************/
                                //}

                                /***** 20120513 for multip-group historgram *****/
                                //BarLeft = BarLeft + BarW;

                            }
                        }

                        //2011-6-15 Draw Y Limits,for Datalet Histogram
                        if ((!this.SpecLine.YLimit) && this.SpecLine.Show)
                        {

                            if (i > 0)
                            {
                                if (this.SpecLine.LLoaded)
                                {
                                    try
                                    {
                                        float lv = float.Parse(AxisX[i - 1]);
                                        float rv = float.Parse(AxisX[i]);
                                        if (this.SpecLine.LowLimit >= lv && this.SpecLine.LowLimit <= rv)
                                        {

                                            Pen RedPen = new Pen(Color.Red);
                                            int Splv = (Int32)((this.SpecLine.LowLimit - lv) / (rv - lv) * (CurrentXAix - LastXAix));
                                            DrawXLine(g, RedPen, DP3, ChartTop, ChartH, LastXAix + Splv, BarW * GroupSize + BarGapW);
                                            DrawTips(g, this.SpecLine.LowLimit.ToString(this.Tips.ValueFormat), LastXAix + Splv, ChartTop + 2, BarW, ChartH, false);
                                        }
                                    }
                                    catch (Exception ee)
                                    {

                                    }
                                }
                                if (this.SpecLine.HLoaded)
                                {
                                    try
                                    {
                                        float lv = float.Parse(AxisX[i - 1]);
                                        float rv = float.Parse(AxisX[i]);
                                        if (this.SpecLine.HighLimit >= lv && this.SpecLine.HighLimit <= rv)
                                        {
                                            Pen RedPen = new Pen(Color.Red);
                                            int Splv = (Int32)((this.SpecLine.HighLimit - lv) / (rv - lv) * (CurrentXAix - LastXAix));
                                            DrawXLine(g, RedPen, DP3, ChartTop, ChartH, LastXAix + Splv, BarW * GroupSize + BarGapW);
                                            DrawTips(g, this.SpecLine.HighLimit.ToString(this.Tips.ValueFormat), LastXAix + Splv, ChartTop + 2, BarW, ChartH, false);
                                        }
                                    }
                                    catch (Exception ee)
                                    {

                                    }
                                }
                                if (this.SpecLine.MLoaded)
                                {
                                    try
                                    {
                                        float lv = float.Parse(AxisX[i - 1]);
                                        float rv = float.Parse(AxisX[i]);
                                        if (this.SpecLine.MeanValue >= lv && this.SpecLine.MeanValue <= rv)
                                        {
                                            Pen RedPen = new Pen(Color.Blue);
                                            RedPen.DashStyle = DashStyle.Dash;
                                            int Splv = (Int32)((this.SpecLine.MeanValue - lv) / (rv - lv) * (CurrentXAix - LastXAix));
                                            DrawXLine(g, RedPen, DP3, ChartTop, ChartH, LastXAix + Splv, BarW * GroupSize + BarGapW);
                                            DrawTips(g, this.SpecLine.MeanValue.ToString(this.Tips.ValueFormat), LastXAix + Splv, ChartTop + 2, BarW, ChartH, false);
                                        }
                                    }
                                    catch (Exception ee)
                                    {

                                    }
                                }
                            }
                        }//eof spec limit Y,for Datalet Histogram

                        LastXAix = CurrentXAix;
                    }
                }
                BackPen.Dispose();
            }//if DataBound
            /********** 绘制坐标轴 **********/
            if (this.Dimension == ChartDimensions.Chart2D)
            {
                g.DrawRectangle(Pens.Gray, ChartLeft, ChartTop, ChartW, ChartH);
                g.DrawLine(Pens.Black, ChartLeft - 4, ChartTop + ChartH - BaseLineXInt, ChartLeft + ChartW - 1, ChartTop + ChartH - BaseLineXInt);
                g.DrawLine(Pens.Black, ChartLeft, ChartTop, ChartLeft, ChartTop + ChartH + 2);
            }
            //坐标单位
            DrawAxisUnit(g, ChartLeft, ChartTop, ChartW, ChartH);


            /******************************************/
            if (Site != null)
                SaveChart(this.RootPath, b);
            else
                SaveChart(System.Web.HttpContext.Current.Server.MapPath(".") + "\\", b);
            g.Dispose();
            b.Dispose();
        }



        private string ChartFileName = "Chartlet.Jpg";
        private void SaveChart(string path, Bitmap chart)
        {//保存图形
            if (!Directory.Exists(path + this.ImageFolder))
            {
                Directory.CreateDirectory(path + this.ImageFolder);
            }
            path += this.ImageFolder + "\\";
            //string FileName = "Chartlet_" + this.ID + "_" + this.ChartTitle.Text.Replace(" ", "_") + "_" + this.ChartType.ToString() + ".Jpg";
            string FileName = "FanG_Chartlet_" + this.ID + "." + this.OutputFormat;
            string FullPath = path + FileName;
            chart.Save(FullPath, this.OutputFormat);
            if (Site != null)
                ChartFileName = FullPath;
            else
                ChartFileName = FileName;

            //保存客户端用于修改IMG Alt的脚本
            //if (!this.Tips.Show)
            //{
                if (!Directory.Exists(path + "Chartlet.js"))
                {
                    string script = "/*********************************************************\r\n";
                    script += "*	Chartlet Script Document generated by Chartlet.dll\r\n";
                    script += "*	Used for dynamic tooltip display\r\n";
                    script += "*	Please view http://www.chartlet.cn for more information\r\n";
                    script += "*	FanG Corp. 2009\r\n";
                    script += "*********************************************************/\r\n";
                    script += "/* The global variables below can be used by any other js function you defined*/ \r\n";
                    script += "var left,width,top,height,value;\r\n";
                    script += "/* The function is for value show in Tooltip*/\r\n ";
                    script += "function showTips(args){\r\n";
                    script += "var img=event.srcElement;\r\n";
                    script += "var ox=event.offsetX;\r\n";
                    script += "var oy=event.offsetY;\r\n";
                    script += "var argsGroup=args.split(\"|\");\r\n";
                    script += "left=argsGroup[0].split(\",\");\r\n";
                    script += "width=argsGroup[1].split(\",\");\r\n";
                    script += "top=argsGroup[2].split(\",\");\r\n";
                    script += "height=argsGroup[3].split(\",\");\r\n";
                    script += "value=argsGroup[4].split(\",\");\r\n";
                    script += "var nowAlt=img.longDesc;\r\n";
                    script += "for(i=0;i<left.length;i++){\r\n";
                    script += "if(ox>parseInt(left[i]) && ox<parseInt(left[i])+parseInt(width[i])){\r\n";
                    script += "if(oy>parseInt(top[i]) && oy<parseInt(top[i])+parseInt(height[i])){\r\n";
                    script += "nowAlt=	value[i];\r\n";
                    script += "break;\r\n";
                    script += "}}}\r\n";
                    script += "img.alt=nowAlt;\r\n";
                    script += "}\r\n";

                    FileStream fs = new FileStream(path + "Chartlet.js", FileMode.Create);
                    StreamWriter sr = new StreamWriter(fs);
                    sr.Write(script);
                    sr.Close();
                    sr.Dispose();
                    fs.Dispose();
                }
            //}
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            //base.Render(writer);
            if (Site != null)
                InitializeData(null, null, null);

            switch (this.ChartType)
            {
                case ChartTypes.Bar:
                    {
                        DrawBarsChart();
                    } break;
                case ChartTypes.Histo:
                    {
                        DrawHistoChart();
                    } break;
                case ChartTypes.Line:
                    {
                        DrawLineChart();
                    } break;
                case ChartTypes.Pie:
                    {
                        if (this.Dimension == ChartDimensions.Chart2D)
                            DrawPieChart();
                        else
                            DrawPieChart3D();
                    } break;
                case ChartTypes.Stack:
                    {
                        DrawStackChart();
                    } break;
                case ChartTypes.HBar:
                    {
                        DrawHBarChart();
                    } break;
                case ChartTypes.Trend:
                    {
                        DrawTrendChart();
                    } break;
                default: DrawPieChart(); break;
            }

            int iw = Int32.Parse(this.Width.ToString().Substring(0, this.Width.ToString().Length - 2)) + this.InflateRight + this.InflateLeft;
            int ih = Int32.Parse(this.Height.ToString().Substring(0, this.Height.ToString().Length - 2)) + this.InflateBottom + this.InflateTop;

            if (DesignMode)
                writer.Write("<img src='" + ChartFileName + "' widith='" + iw.ToString() + "px' height='" + ih.ToString() + "px'/>");
            else
            {
                //20011-6-15 remove Tip show js
                //this.ClientMouseMove= "showTips('"+ StrBarL +"|"+ StrBarW +"|"+ StrBarT +"|"+ StrBarH +"|"+ StrBarV +"')";
                //writer.Write("<script language=\"javascript\" src=\""+ this.ImageFolder +"/Chartlet.js\"></script>\r\n");
                //writer.Write("<img usemap=\"#"+this.ClientUseMap+"\" id=\"" + this.ID + "\" border='" + this.ImageBorder + "' style=\"" + this.ImageStyle + "\" longdesc=\""+ this.ChartTitle.Text + "\" alt=\"" + this.ChartTitle.Text + "\" onclick=\"" + this.ClientClick + "\" onmouseover=\"" + this.ClientMouseOver + "\" onmouseout=\"" + this.ClientMouseOut +"\" onmousemove=\""+ this.ClientMouseMove  + "\" src='" + this.ImageFolder + "/" + ChartFileName + "?" + DateTime.Now.ToFileTimeUtc().ToString() + "' widith='" + iw.ToString() + "px' height='" + ih.ToString() + "px'/>");
                writer.Write("<img id=\"" + this.ID + "\" border='" + this.ImageBorder + "' style=\"" + this.ImageStyle + "\" longdesc=\"" + this.ChartTitle.Text + "\" alt=\"" + this.ChartTitle.Text + "\"  src='" + this.ImageFolder + "/" + ChartFileName + "?" + DateTime.Now.ToFileTimeUtc().ToString() + "' widith='" + iw.ToString() + "px' height='" + ih.ToString() + "px'/>");
            }
        }
    }


    ///////////////////////////////下面是高斯模糊类/////////////////////////////////////////////////////////////
    public class TextShadow
    {
        private int radius = 3;
        private int distance = 0;
        private double angle = 60;
        private byte alpha = 192;

        /// <summary>
        /// 高斯卷积矩阵
        /// </summary>
        private int[] gaussMatrix;
        /// <summary>
        /// 卷积核
        /// </summary>
        private int nuclear = 0;

        /// <summary>
        /// 阴影半径
        /// </summary>
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (radius != value)
                {
                    radius = value;
                    MakeGaussMatrix();
                }
            }
        }

        /// <summary>
        ///  阴影距离
        /// </summary>
        public int Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }

        /// <summary>
        ///  阴影输出角度(左边平行处为0度。顺时针方向)
        /// </summary>
        public double Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
            }
        }

        /// <summary>
        /// 阴影文字的不透明度
        /// </summary>
        public byte Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = value;
            }
        }

        /// <summary>
        /// 对文字阴影位图按阴影半径计算的高斯矩阵进行卷积模糊
        /// </summary>
        /// <param name="bmp">文字阴影位图</param>
        private unsafe void MaskShadow(Bitmap bmp)
        {
            if (nuclear == 0)
                MakeGaussMatrix();
            Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
            // 克隆临时位图，作为卷积源
            Bitmap tmp = (Bitmap)bmp.Clone();
            BitmapData dest = bmp.LockBits(r, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            BitmapData source = tmp.LockBits(r, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
                // 源首地址(0, 0)的Alpha字节，也就是目标首像素的第一个卷积乘数的像素点
                byte* ps = (byte*)source.Scan0;
                ps += 3;
                // 目标地址为卷积半径点(radius, radius)的Alpha字节
                byte* pd = (byte*)dest.Scan0;
                pd += (radius * (dest.Stride + 4) + 3);
                // 位图实际卷积的部分
                int width = dest.Width - radius * 2;
                int height = dest.Height - radius * 2;
                int matrixSize = radius * 2 + 1;
                // 卷积矩阵字节偏移
                int mOffset = dest.Stride - matrixSize * 4;
                // 行尾卷积半径(radius)的偏移
                int rOffset = radius * 8;
                int count = matrixSize * matrixSize;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        byte* s = ps - mOffset;
                        int v = 0;
                        for (int i = 0; i < count; i++, s += 4)
                        {
                            if ((i % matrixSize) == 0)
                                s += mOffset;           // 卷积矩阵的换行
                            v += gaussMatrix[i] * *s;   // 位图像素点Alpha的卷积值求和
                        }
                        // 目标位图被卷积像素点Alpha等于卷积和除以卷积核
                        *pd = (byte)(v / nuclear);
                        pd += 4;
                        ps += 4;
                    }
                    pd += rOffset;
                    ps += rOffset;
                }
            }
            finally
            {
                tmp.UnlockBits(source);
                bmp.UnlockBits(dest);
                tmp.Dispose();
            }
        }

        /// <summary>
        /// 按给定的阴影半径生成高斯卷积矩阵
        /// </summary>
        protected virtual void MakeGaussMatrix()
        {
            double Q = (double)radius / 2.0;
            if (Q == 0.0)
                Q = 0.1;
            int n = radius * 2 + 1;
            int index = 0;
            nuclear = 0;
            gaussMatrix = new int[n * n];

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    gaussMatrix[index] = (int)Math.Round(Math.Exp(-((double)x * x + y * y) / (2.0 * Q * Q)) /
                                                         (2.0 * Math.PI * Q * Q) * 1000.0);
                    nuclear += gaussMatrix[index];
                    index++;
                }
            }
        }

        public TextShadow()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// 画文字阴影
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="text">文字串</param>
        /// <param name="font">字体</param>
        /// <param name="layoutRect">文字串的布局矩形</param>
        /// <param name="format">文字串输出格式</param>
        public void StringShadow(Graphics g, string text, Font font, RectangleF layoutRect, StringFormat format)
        {
            RectangleF sr = new RectangleF((float)(radius * 2), (float)(radius * 2), layoutRect.Width, layoutRect.Height);
            // 根据文字布局矩形长宽扩大文字阴影半径4倍建立一个32位ARGB格式的位图
            Bitmap bmp = new Bitmap((int)sr.Width + radius * 4, (int)sr.Height + radius * 4, PixelFormat.Format32bppArgb);
            // 按文字阴影不透明度建立阴影画刷
            Brush brush = new SolidBrush(Color.FromArgb(Alpha, Color.Black));
            Graphics bg = Graphics.FromImage(bmp);
            try
            {
                // 在位图上画文字阴影
                bg.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                bg.DrawString(text, font, brush, sr, format);
                // 制造阴影模糊
                MaskShadow(bmp);
                // 按文字阴影角度、半径和距离输出文字阴影到给定的画布
                RectangleF dr = layoutRect;
                dr.Offset((float)(Math.Cos(Math.PI * angle / 180.0) * distance),
                          (float)(Math.Sin(Math.PI * angle / 180.0) * distance));
                sr.Inflate((float)radius, (float)radius);
                dr.Inflate((float)radius, (float)radius);
                g.DrawImage(bmp, dr, sr, GraphicsUnit.Pixel);
            }
            finally
            {
                bg.Dispose();
                brush.Dispose();
                bmp.Dispose();
            }
        }


        public void DropShadow(Graphics g, Rectangle r, Color c, string Action, string Type, GraphicsPath gp, int penWidth)
        {
            RectangleF sr = new RectangleF((float)(radius * 2), (float)(radius * 2), r.Width, r.Height);
            Rectangle ir = new Rectangle((radius * 2), (radius * 2), r.Width, r.Height);
            // 根据文字布局矩形长宽扩大文字阴影半径4倍建立一个32位ARGB格式的位图
            Bitmap bmp = new Bitmap((int)sr.Width + radius * 4, (int)sr.Height + radius * 4, PixelFormat.Format32bppArgb);
            // 按文字阴影不透明度建立阴影画刷
            if (c.IsEmpty)
                c = Color.Black;
            if (penWidth == 0)
                penWidth = 1;
            Brush brush = new SolidBrush(Color.FromArgb(Alpha, c));
            Pen pen = new Pen(Color.FromArgb(Alpha, c), penWidth);
            Graphics bg = Graphics.FromImage(bmp);
            bg.SmoothingMode = SmoothingMode.AntiAlias;
            try
            {
                // 在位图上画文字阴影
                switch (Type)
                {
                    case "Ellipse":
                        {
                            if (Action == "Fill")
                                bg.FillEllipse(brush, sr);
                            else if (Action == "Draw")
                                bg.DrawEllipse(pen, ir);
                            else
                                bg.DrawString("Action Error,(Fill,Draw) is valid", new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Red, sr);
                        } break;
                    case "Rectangle":
                        {
                            if (Action == "Fill")
                                bg.FillRectangle(brush, sr);
                            else if (Action == "Draw")
                                bg.DrawRectangle(pen, ir);
                            else
                                bg.DrawString("Action Error,(Fill,Draw) is valid", new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Red, sr);
                        } break;
                    case "Path":
                        {
                            if (Action == "Fill")
                            {
                                bg.TranslateTransform(r.Left * (-1) + radius * 2, r.Top * (-1) + radius * 2);
                                bg.FillPath(brush, gp);
                            }
                            else if (Action == "Draw")
                            {
                                bg.TranslateTransform(r.Left * (-1) + radius * 2, r.Top * (-1) + radius * 2);
                                bg.DrawPath(pen, gp);

                            }
                            else
                                bg.DrawString("Action Error,(Fill,Draw) is valid", new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Red, sr);
                        } break;
                }
                // 制造阴影模糊
                RectangleF dr = r;
                if (Action == "Fill" || Action == "Draw")
                {
                    MaskShadow(bmp);
                    // 按文字阴影角度、半径和距离输出文字阴影到给定的画布
                    dr.Offset((float)(Math.Cos(Math.PI * angle / 180.0) * distance),
                              (float)(Math.Sin(Math.PI * angle / 180.0) * distance));
                    sr.Inflate((float)radius, (float)radius);
                    dr.Inflate((float)radius, (float)radius);
                }
                g.DrawImage(bmp, dr, sr, GraphicsUnit.Pixel);
            }
            finally
            {
                bg.Dispose();
                brush.Dispose();
                bmp.Dispose();
            }

        }



        /// <summary>
        /// 画文字阴影
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="text">文字串</param>
        /// <param name="font">字体</param>
        /// <param name="layoutRect">文字串的布局矩形</param>
        public void StringShadow(Graphics g, string text, Font font, RectangleF layoutRect)
        {
            StringShadow(g, text, font, layoutRect, null);
        }

        /// <summary>
        /// 画文字阴影
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="text">文字串</param>
        /// <param name="font">字体</param>
        /// <param name="origin">文字串的输出原点</param>
        /// <param name="format">文字串输出格式</param>
        public void StringShadow(Graphics g, string text, Font font, PointF origin, StringFormat format)
        {
            RectangleF rect = new RectangleF(origin, g.MeasureString(text, font, origin, format));
            StringShadow(g, text, font, rect, format);
        }

        /// <summary>
        /// 画文字阴影
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="text">文字串</param>
        /// <param name="font">字体</param>
        /// <param name="origin">文字串的输出原点</param>
        public void StringShadow(Graphics g, string text, Font font, PointF origin)
        {
            StringShadow(g, text, font, origin, null);
        }
    }
}
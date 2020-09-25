namespace test2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chartlet1 = new FanG.Chartlet();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chartlet1
            // 
            this.chartlet1.Alpha3D = ((byte)(255));
            this.chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Bar_2D_Aurora_FlatCrystal_Glow_NoBorder;
            this.chartlet1.AutoBarWidth = true;
            this.chartlet1.Background.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(238)))));
            this.chartlet1.Background.Lowlight = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.chartlet1.Background.Paper = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chartlet1.ChartTitle.BackColor = System.Drawing.Color.White;
            this.chartlet1.ChartTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.ChartTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.chartlet1.ChartTitle.OffsetY = 0;
            this.chartlet1.ChartTitle.Show = true;
            this.chartlet1.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            this.chartlet1.ChartType = FanG.Chartlet.ChartTypes.Bar;
            this.chartlet1.ClientClick = "";
            this.chartlet1.ClientMouseMove = "";
            this.chartlet1.ClientMouseOut = "";
            this.chartlet1.ClientMouseOver = "";
            this.chartlet1.ClientUseMap = "";
            this.chartlet1.Colorful = true;
            this.chartlet1.ColorGuider.BackColor = System.Drawing.Color.White;
            this.chartlet1.ColorGuider.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.ColorGuider.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.ColorGuider.Show = true;
            this.chartlet1.CopyrightText = "Provided by Chartlet.cn";
            this.chartlet1.Crystal.Contraction = 1;
            this.chartlet1.Crystal.CoverFull = true;
            this.chartlet1.Crystal.Direction = FanG.Chartlet.Direction.TopBottom;
            this.chartlet1.Crystal.Enable = true;
            this.chartlet1.Depth3D = 10;
            this.chartlet1.Dimension = FanG.Chartlet.ChartDimensions.Chart2D;
            this.chartlet1.Fill.Color1 = System.Drawing.Color.Empty;
            this.chartlet1.Fill.Color2 = System.Drawing.Color.Empty;
            this.chartlet1.Fill.Color3 = System.Drawing.Color.Empty;
            this.chartlet1.Fill.ColorStyle = FanG.Chartlet.ColorStyles.Aurora;
            this.chartlet1.Fill.ShiftStep = 0;
            this.chartlet1.Fill.TextureEnable = false;
            this.chartlet1.Fill.TextureStyle = System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal;
            this.chartlet1.GroupSize = 0;
            this.chartlet1.ImageBorder = 0;
            this.chartlet1.ImageFolder = "Chartlet";
            this.chartlet1.ImageStyle = "";
            this.chartlet1.InflateBottom = 0;
            this.chartlet1.InflateLeft = 0;
            this.chartlet1.InflateRight = 0;
            this.chartlet1.InflateTop = 0;
            this.chartlet1.LineConnectionRadius = 10;
            this.chartlet1.LineConnectionType = FanG.Chartlet.LineConnectionTypes.Round;
            this.chartlet1.Location = new System.Drawing.Point(12, 13);
            this.chartlet1.MaxValueY = 0;
            this.chartlet1.MinValueY = 0;
            this.chartlet1.Name = "chartlet1";
            this.chartlet1.OutputFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            this.chartlet1.RootPath = "C:\\\\";
            this.chartlet1.RoundRadius = 2;
            this.chartlet1.RoundRectangle = false;
            this.chartlet1.Shadow.Alpha = ((byte)(192));
            this.chartlet1.Shadow.Angle = 60F;
            this.chartlet1.Shadow.Color = System.Drawing.Color.Black;
            this.chartlet1.Shadow.Distance = 0;
            this.chartlet1.Shadow.Enable = true;
            this.chartlet1.Shadow.Hollow = false;
            this.chartlet1.Shadow.Radius = 3;
            this.chartlet1.ShowCopyright = false;
            this.chartlet1.ShowErrorInfo = true;
            this.chartlet1.Size = new System.Drawing.Size(625, 453);
            this.chartlet1.Stroke.Color1 = System.Drawing.Color.Empty;
            this.chartlet1.Stroke.Color2 = System.Drawing.Color.Empty;
            this.chartlet1.Stroke.Color3 = System.Drawing.Color.Empty;
            this.chartlet1.Stroke.ColorStyle = FanG.Chartlet.ColorStyles.None;
            this.chartlet1.Stroke.ShiftStep = 0;
            this.chartlet1.Stroke.TextureEnable = false;
            this.chartlet1.Stroke.TextureStyle = System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal;
            this.chartlet1.Stroke.Width = 0;
            this.chartlet1.TabIndex = 0;
            this.chartlet1.Tips.BackColor = System.Drawing.Color.White;
            this.chartlet1.Tips.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.Tips.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.Tips.Show = true;
            this.chartlet1.XLabels.BackColor = System.Drawing.Color.White;
            this.chartlet1.XLabels.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.XLabels.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.XLabels.RotateAngle = 30F;
            this.chartlet1.XLabels.SampleSize = 1;
            this.chartlet1.XLabels.Show = true;
            this.chartlet1.XLabels.UnitFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.XLabels.UnitText = "XLabelsUnit";
            this.chartlet1.XLabels.ValueFormat = "0.0";
            this.chartlet1.YLabels.BackColor = System.Drawing.Color.White;
            this.chartlet1.YLabels.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.YLabels.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.YLabels.Show = true;
            this.chartlet1.YLabels.UnitFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.YLabels.UnitText = "YLabelsUnit";
            this.chartlet1.YLabels.ValueFormat = "0.0";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "柱图",
            "线图",
            "饼图"});
            this.comboBox1.Location = new System.Drawing.Point(656, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "简单示例";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(656, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "放大";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(656, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "缩小";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(656, 206);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "自定义颜色";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 480);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chartlet1);
            this.Name = "Form1";
            this.Text = "Chartlet Winform Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private FanG.Chartlet chartlet1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}


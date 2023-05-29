using OxyPlot;
using OxyPlot.Axes;

namespace BallisticTrajectoryCalculator.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            createGraphButton = new Button();
            caliberBox = new ComboBox();
            initialVelocityBox = new TextBox();
            shootAngleBox = new TextBox();
            temperatureBox = new TextBox();
            pressureBox = new TextBox();
            humidityBox = new TextBox();
            airDensityBox = new TextBox();
            bcBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            plotView = new OxyPlot.WindowsForms.PlotView();
            clearGraphButton = new Button();
            chartSizeBox = new TextBox();
            label9 = new Label();
            label10 = new Label();
            windAngleBox = new TextBox();
            windVelocityBox = new TextBox();
            label11 = new Label();
            create3dGraphBtn = new Button();
            SuspendLayout();
            // 
            // createGraphButton
            // 
            createGraphButton.Location = new Point(681, 415);
            createGraphButton.Name = "createGraphButton";
            createGraphButton.Size = new Size(107, 23);
            createGraphButton.TabIndex = 0;
            createGraphButton.Text = "Create Graph";
            createGraphButton.UseVisualStyleBackColor = true;
            createGraphButton.Click += createGraphButton_Click;
            // 
            // caliberBox
            // 
            caliberBox.DropDownStyle = ComboBoxStyle.DropDownList;
            caliberBox.FormattingEnabled = true;
            caliberBox.Items.AddRange(new object[] { "22 LR", "223 Remington", "308 Winchester", "30-60 Springfield", "50 BMG" });
            caliberBox.Location = new Point(31, 38);
            caliberBox.Name = "caliberBox";
            caliberBox.Size = new Size(112, 23);
            caliberBox.TabIndex = 1;
            // 
            // initialVelocityBox
            // 
            initialVelocityBox.Location = new Point(126, 157);
            initialVelocityBox.Name = "initialVelocityBox";
            initialVelocityBox.Size = new Size(75, 23);
            initialVelocityBox.TabIndex = 2;
            // 
            // shootAngleBox
            // 
            shootAngleBox.Location = new Point(126, 186);
            shootAngleBox.Name = "shootAngleBox";
            shootAngleBox.Size = new Size(75, 23);
            shootAngleBox.TabIndex = 3;
            // 
            // temperatureBox
            // 
            temperatureBox.Location = new Point(276, 12);
            temperatureBox.Name = "temperatureBox";
            temperatureBox.Size = new Size(79, 23);
            temperatureBox.TabIndex = 4;
            // 
            // pressureBox
            // 
            pressureBox.Location = new Point(276, 41);
            pressureBox.Name = "pressureBox";
            pressureBox.Size = new Size(79, 23);
            pressureBox.TabIndex = 5;
            // 
            // humidityBox
            // 
            humidityBox.Location = new Point(276, 70);
            humidityBox.Name = "humidityBox";
            humidityBox.Size = new Size(79, 23);
            humidityBox.TabIndex = 6;
            // 
            // airDensityBox
            // 
            airDensityBox.Location = new Point(482, 12);
            airDensityBox.Name = "airDensityBox";
            airDensityBox.Size = new Size(81, 23);
            airDensityBox.TabIndex = 7;
            // 
            // bcBox
            // 
            bcBox.Location = new Point(126, 128);
            bcBox.Name = "bcBox";
            bcBox.Size = new Size(75, 23);
            bcBox.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 131);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 9;
            label1.Text = "Ballistic Coefficient";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 160);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 10;
            label2.Text = "Initial Velocity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 189);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 11;
            label3.Text = "Shooting Angle";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(197, 15);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 12;
            label4.Text = "Temperature";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(219, 44);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 13;
            label5.Text = "Pressure";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(213, 73);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 14;
            label6.Text = "Humidity";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(412, 15);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 15;
            label7.Text = "Air Density";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(65, 20);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 16;
            label8.Text = "Caliber";
            // 
            // plotView
            // 
            plotView.Location = new Point(219, 99);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(569, 310);
            plotView.TabIndex = 17;
            plotView.Text = "plotView1";
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // clearGraphButton
            // 
            clearGraphButton.Location = new Point(568, 415);
            clearGraphButton.Name = "clearGraphButton";
            clearGraphButton.Size = new Size(107, 23);
            clearGraphButton.TabIndex = 18;
            clearGraphButton.Text = "Clear Graph";
            clearGraphButton.UseVisualStyleBackColor = true;
            clearGraphButton.Click += clearGraphButton_Click;
            // 
            // chartSizeBox
            // 
            chartSizeBox.Location = new Point(126, 215);
            chartSizeBox.Name = "chartSizeBox";
            chartSizeBox.Size = new Size(75, 23);
            chartSizeBox.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(61, 218);
            label9.Name = "label9";
            label9.Size = new Size(59, 15);
            label9.TabIndex = 20;
            label9.Text = "Chart Size";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(51, 247);
            label10.Name = "label10";
            label10.Size = new Size(69, 15);
            label10.TabIndex = 21;
            label10.Text = "Wind Angle";
            // 
            // windAngleBox
            // 
            windAngleBox.Location = new Point(126, 244);
            windAngleBox.Name = "windAngleBox";
            windAngleBox.Size = new Size(75, 23);
            windAngleBox.TabIndex = 22;
            // 
            // windVelocityBox
            // 
            windVelocityBox.Location = new Point(126, 273);
            windVelocityBox.Name = "windVelocityBox";
            windVelocityBox.Size = new Size(75, 23);
            windVelocityBox.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(41, 276);
            label11.Name = "label11";
            label11.Size = new Size(79, 15);
            label11.TabIndex = 24;
            label11.Text = "Wind Velocity";
            // 
            // create3dGraphBtn
            // 
            create3dGraphBtn.Location = new Point(455, 415);
            create3dGraphBtn.Name = "create3dGraphBtn";
            create3dGraphBtn.Size = new Size(107, 23);
            create3dGraphBtn.TabIndex = 25;
            create3dGraphBtn.Text = "Create 3D Graph";
            create3dGraphBtn.UseVisualStyleBackColor = true;
            create3dGraphBtn.Click += create3dGraphBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(create3dGraphBtn);
            Controls.Add(label11);
            Controls.Add(windVelocityBox);
            Controls.Add(windAngleBox);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(chartSizeBox);
            Controls.Add(clearGraphButton);
            Controls.Add(plotView);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bcBox);
            Controls.Add(airDensityBox);
            Controls.Add(humidityBox);
            Controls.Add(pressureBox);
            Controls.Add(temperatureBox);
            Controls.Add(shootAngleBox);
            Controls.Add(initialVelocityBox);
            Controls.Add(caliberBox);
            Controls.Add(createGraphButton);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        #region PlotModel
        PlotModel plotModel = new PlotModel
        {
            Title = "Bullet Trajectory",
            Axes = {
            new LinearAxis { Position = AxisPosition.Bottom, Title = "Distance", Unit = "m"},
            new LinearAxis { Position = AxisPosition.Left, Title = "Height", Unit = "m" }
            }
        };


        #endregion

        private Button createGraphButton;
        private ComboBox caliberBox;
        private TextBox initialVelocityBox;
        private TextBox shootAngleBox;
        private TextBox temperatureBox;
        private TextBox pressureBox;
        private TextBox humidityBox;
        private TextBox airDensityBox;
        private TextBox bcBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private OxyPlot.WindowsForms.PlotView plotView;
        private Button clearGraphButton;
        private TextBox chartSizeBox;
        private Label label9;
        private Label label10;
        private TextBox windAngleBox;
        private TextBox windVelocityBox;
        private Label label11;
        private Button create3dGraphBtn;
    }
}
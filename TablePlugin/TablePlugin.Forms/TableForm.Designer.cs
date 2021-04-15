
namespace TablePlugin.Forms
{
    partial class TableForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BuildButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CheckHole = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.holeRadius = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.holeParamY = new System.Windows.Forms.NumericUpDown();
            this.holeParamX = new System.Windows.Forms.NumericUpDown();
            this.tableTopHeight = new System.Windows.Forms.NumericUpDown();
            this.tableTopWidth = new System.Windows.Forms.NumericUpDown();
            this.tableTopLength = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tableLegsNumber = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLegsSideLength = new System.Windows.Forms.NumericUpDown();
            this.tableLegsDiameter = new System.Windows.Forms.NumericUpDown();
            this.tableLegsHeight = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SquareLegsRadioButton = new System.Windows.Forms.RadioButton();
            this.RoundLegsRadioButton = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SetMinButton = new System.Windows.Forms.Button();
            this.SetMaxButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.holeRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holeParamY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holeParamX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopLength)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsSideLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(9, 461);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(161, 50);
            this.BuildButton.TabIndex = 0;
            this.BuildButton.Text = "Построить 3D модель";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Длина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ширина";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Высота";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 131);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Расстояние по ширине\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "Расстояние по длине\r\n\r\n";
            // 
            // CheckHole
            // 
            this.CheckHole.AutoSize = true;
            this.CheckHole.Location = new System.Drawing.Point(177, 40);
            this.CheckHole.Name = "CheckHole";
            this.CheckHole.Size = new System.Drawing.Size(130, 17);
            this.CheckHole.TabIndex = 11;
            this.CheckHole.Text = "Сквозное отверстие";
            this.CheckHole.UseVisualStyleBackColor = true;
            this.CheckHole.CheckedChanged += new System.EventHandler(this.CheckHole_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.holeRadius);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.holeParamY);
            this.groupBox1.Controls.Add(this.holeParamX);
            this.groupBox1.Controls.Add(this.tableTopHeight);
            this.groupBox1.Controls.Add(this.tableTopWidth);
            this.groupBox1.Controls.Add(this.tableTopLength);
            this.groupBox1.Controls.Add(this.CheckHole);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 237);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Столешница";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(247, 147);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 24;
            this.label21.Text = "90-700 мм";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(244, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "120-1870 мм";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(247, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "20-30 мм";
            // 
            // holeRadius
            // 
            this.holeRadius.Location = new System.Drawing.Point(177, 206);
            this.holeRadius.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.holeRadius.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.holeRadius.Name = "holeRadius";
            this.holeRadius.ReadOnly = true;
            this.holeRadius.Size = new System.Drawing.Size(64, 20);
            this.holeRadius.TabIndex = 21;
            this.holeRadius.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(174, 189);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Радиус отверстия";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(82, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "30-40 мм";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(82, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "600-800 мм";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(82, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "1000-2000 мм";
            // 
            // holeParamY
            // 
            this.holeParamY.Location = new System.Drawing.Point(177, 147);
            this.holeParamY.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.holeParamY.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.holeParamY.Name = "holeParamY";
            this.holeParamY.ReadOnly = true;
            this.holeParamY.Size = new System.Drawing.Size(64, 20);
            this.holeParamY.TabIndex = 16;
            this.holeParamY.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // holeParamX
            // 
            this.holeParamX.Location = new System.Drawing.Point(177, 91);
            this.holeParamX.Maximum = new decimal(new int[] {
            1870,
            0,
            0,
            0});
            this.holeParamX.Minimum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.holeParamX.Name = "holeParamX";
            this.holeParamX.ReadOnly = true;
            this.holeParamX.Size = new System.Drawing.Size(64, 20);
            this.holeParamX.TabIndex = 15;
            this.holeParamX.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // tableTopHeight
            // 
            this.tableTopHeight.Location = new System.Drawing.Point(12, 147);
            this.tableTopHeight.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.tableTopHeight.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.tableTopHeight.Name = "tableTopHeight";
            this.tableTopHeight.Size = new System.Drawing.Size(64, 20);
            this.tableTopHeight.TabIndex = 14;
            this.tableTopHeight.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // tableTopWidth
            // 
            this.tableTopWidth.Location = new System.Drawing.Point(12, 91);
            this.tableTopWidth.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.tableTopWidth.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.tableTopWidth.Name = "tableTopWidth";
            this.tableTopWidth.Size = new System.Drawing.Size(64, 20);
            this.tableTopWidth.TabIndex = 13;
            this.tableTopWidth.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // tableTopLength
            // 
            this.tableTopLength.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tableTopLength.Location = new System.Drawing.Point(13, 40);
            this.tableTopLength.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.tableTopLength.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tableTopLength.Name = "tableTopLength";
            this.tableTopLength.Size = new System.Drawing.Size(63, 20);
            this.tableTopLength.TabIndex = 12;
            this.tableTopLength.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.tableLegsNumber);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tableLegsSideLength);
            this.groupBox2.Controls.Add(this.tableLegsDiameter);
            this.groupBox2.Controls.Add(this.tableLegsHeight);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.SquareLegsRadioButton);
            this.groupBox2.Controls.Add(this.RoundLegsRadioButton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(9, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 200);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ножки";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.DimGray;
            this.label19.Location = new System.Drawing.Point(247, 161);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 23;
            this.label19.Text = "40-60 мм";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(244, 106);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "40-60 мм";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(247, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "4-5 шт.";
            // 
            // tableLegsNumber
            // 
            this.tableLegsNumber.Location = new System.Drawing.Point(177, 39);
            this.tableLegsNumber.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tableLegsNumber.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.tableLegsNumber.Name = "tableLegsNumber";
            this.tableLegsNumber.Size = new System.Drawing.Size(64, 20);
            this.tableLegsNumber.TabIndex = 20;
            this.tableLegsNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(82, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "600-700 мм";
            // 
            // tableLegsSideLength
            // 
            this.tableLegsSideLength.Location = new System.Drawing.Point(177, 159);
            this.tableLegsSideLength.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.tableLegsSideLength.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.tableLegsSideLength.Name = "tableLegsSideLength";
            this.tableLegsSideLength.ReadOnly = true;
            this.tableLegsSideLength.Size = new System.Drawing.Size(56, 20);
            this.tableLegsSideLength.TabIndex = 17;
            this.tableLegsSideLength.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // tableLegsDiameter
            // 
            this.tableLegsDiameter.Location = new System.Drawing.Point(177, 102);
            this.tableLegsDiameter.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.tableLegsDiameter.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.tableLegsDiameter.Name = "tableLegsDiameter";
            this.tableLegsDiameter.Size = new System.Drawing.Size(56, 20);
            this.tableLegsDiameter.TabIndex = 16;
            this.tableLegsDiameter.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.tableLegsDiameter.Visible = false;
            // 
            // tableLegsHeight
            // 
            this.tableLegsHeight.Location = new System.Drawing.Point(12, 37);
            this.tableLegsHeight.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.tableLegsHeight.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.tableLegsHeight.Name = "tableLegsHeight";
            this.tableLegsHeight.Size = new System.Drawing.Size(64, 20);
            this.tableLegsHeight.TabIndex = 14;
            this.tableLegsHeight.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(177, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Длина ребра основания";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Диаметр основания";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Тип ножек";
            // 
            // SquareLegsRadioButton
            // 
            this.SquareLegsRadioButton.AutoSize = true;
            this.SquareLegsRadioButton.Location = new System.Drawing.Point(13, 162);
            this.SquareLegsRadioButton.Name = "SquareLegsRadioButton";
            this.SquareLegsRadioButton.Size = new System.Drawing.Size(87, 17);
            this.SquareLegsRadioButton.TabIndex = 8;
            this.SquareLegsRadioButton.Text = "Квадратные";
            this.SquareLegsRadioButton.UseVisualStyleBackColor = true;
            this.SquareLegsRadioButton.CheckedChanged += new System.EventHandler(this.SquareLegsRadioButton_CheckedChanged);
            // 
            // RoundLegsRadioButton
            // 
            this.RoundLegsRadioButton.AutoSize = true;
            this.RoundLegsRadioButton.Checked = true;
            this.RoundLegsRadioButton.Location = new System.Drawing.Point(13, 102);
            this.RoundLegsRadioButton.Name = "RoundLegsRadioButton";
            this.RoundLegsRadioButton.Size = new System.Drawing.Size(68, 17);
            this.RoundLegsRadioButton.TabIndex = 7;
            this.RoundLegsRadioButton.TabStop = true;
            this.RoundLegsRadioButton.Text = "Круглые";
            this.RoundLegsRadioButton.UseVisualStyleBackColor = true;
            this.RoundLegsRadioButton.CheckedChanged += new System.EventHandler(this.RoundLegsRadioButton_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Количество ножек";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Длина ножек";
            // 
            // SetMinButton
            // 
            this.SetMinButton.Location = new System.Drawing.Point(182, 460);
            this.SetMinButton.Name = "SetMinButton";
            this.SetMinButton.Size = new System.Drawing.Size(161, 21);
            this.SetMinButton.TabIndex = 14;
            this.SetMinButton.Text = "Минимумы";
            this.SetMinButton.UseVisualStyleBackColor = true;
            this.SetMinButton.Click += new System.EventHandler(this.SetMinButton_Click);
            // 
            // SetMaxButton
            // 
            this.SetMaxButton.Location = new System.Drawing.Point(182, 487);
            this.SetMaxButton.Name = "SetMaxButton";
            this.SetMaxButton.Size = new System.Drawing.Size(161, 21);
            this.SetMaxButton.TabIndex = 15;
            this.SetMaxButton.Text = "Максимумы";
            this.SetMaxButton.UseVisualStyleBackColor = true;
            this.SetMaxButton.Click += new System.EventHandler(this.SetMaxButton_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 523);
            this.Controls.Add(this.SetMaxButton);
            this.Controls.Add(this.SetMinButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BuildButton);
            this.Name = "TableForm";
            this.Text = "TablePlugin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.holeRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holeParamY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holeParamX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopLength)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsSideLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CheckHole;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton SquareLegsRadioButton;
        private System.Windows.Forms.RadioButton RoundLegsRadioButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown holeRadius;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown holeParamY;
        private System.Windows.Forms.NumericUpDown holeParamX;
        private System.Windows.Forms.NumericUpDown tableTopHeight;
        private System.Windows.Forms.NumericUpDown tableTopWidth;
        private System.Windows.Forms.NumericUpDown tableTopLength;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown tableLegsNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown tableLegsSideLength;
        private System.Windows.Forms.NumericUpDown tableLegsDiameter;
        private System.Windows.Forms.NumericUpDown tableLegsHeight;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button SetMinButton;
        private System.Windows.Forms.Button SetMaxButton;
    }
}


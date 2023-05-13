namespace DSAL_CA1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            simulationModeToolStripMenuItem = new ToolStripMenuItem();
            normalModeToolStripMenuItem = new ToolStripMenuItem();
            safeDistanceModeToolStripMenuItem = new ToolStripMenuItem();
            safeDistanceSmartModeToolStripMenuItem = new ToolStripMenuItem();
            buttonLoad = new Button();
            buttonSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textNumRows = new TextBox();
            textSeatPRow = new TextBox();
            textRowDivider = new TextBox();
            textColumnDivider = new TextBox();
            buttonGenerateSeats = new Button();
            label5 = new Label();
            textMaxSeats = new TextBox();
            buttonEndSimulation = new Button();
            groupBoxManualEditor = new GroupBox();
            radioDisable = new RadioButton();
            radioEnable = new RadioButton();
            buttonDisableAllSeats = new Button();
            buttonEnableAllSeats = new Button();
            buttonEditorMode = new Button();
            buttonResetSimulation = new Button();
            textMessageStatus = new TextBox();
            textNumPeople = new TextBox();
            labelNoOfPeople = new Label();
            panelSeats = new Panel();
            textScreen = new TextBox();
            buttonUndo = new Button();
            buttonRedo = new Button();
            menuStrip1.SuspendLayout();
            groupBoxManualEditor.SuspendLayout();
            panelSeats.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { simulationModeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1573, 33);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // simulationModeToolStripMenuItem
            // 
            simulationModeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { normalModeToolStripMenuItem, safeDistanceModeToolStripMenuItem, safeDistanceSmartModeToolStripMenuItem });
            simulationModeToolStripMenuItem.Name = "simulationModeToolStripMenuItem";
            simulationModeToolStripMenuItem.Size = new Size(164, 29);
            simulationModeToolStripMenuItem.Text = "Simulation Mode";
            // 
            // normalModeToolStripMenuItem
            // 
            normalModeToolStripMenuItem.Name = "normalModeToolStripMenuItem";
            normalModeToolStripMenuItem.Size = new Size(324, 34);
            normalModeToolStripMenuItem.Text = "Normal Mode";
            // 
            // safeDistanceModeToolStripMenuItem
            // 
            safeDistanceModeToolStripMenuItem.Name = "safeDistanceModeToolStripMenuItem";
            safeDistanceModeToolStripMenuItem.Size = new Size(324, 34);
            safeDistanceModeToolStripMenuItem.Text = "Safe Distance Mode";
            // 
            // safeDistanceSmartModeToolStripMenuItem
            // 
            safeDistanceSmartModeToolStripMenuItem.Name = "safeDistanceSmartModeToolStripMenuItem";
            safeDistanceSmartModeToolStripMenuItem.Size = new Size(324, 34);
            safeDistanceSmartModeToolStripMenuItem.Text = "Safe Distance Smart Mode";
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = SystemColors.ButtonShadow;
            buttonLoad.ForeColor = SystemColors.ActiveCaptionText;
            buttonLoad.Location = new Point(38, 48);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(146, 34);
            buttonLoad.TabIndex = 1;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = false;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = SystemColors.ButtonShadow;
            buttonSave.ForeColor = SystemColors.ActiveCaptionText;
            buttonSave.Location = new Point(198, 48);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(150, 34);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(38, 139);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 3;
            label1.Text = "Number of Rows";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(38, 173);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 4;
            label2.Text = "Seats per Row";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(38, 210);
            label3.Name = "label3";
            label3.Size = new Size(130, 25);
            label3.TabIndex = 5;
            label3.Text = "Row Divider (s)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(34, 247);
            label4.Name = "label4";
            label4.Size = new Size(158, 25);
            label4.TabIndex = 6;
            label4.Text = "Column Divider (s)";
            // 
            // textNumRows
            // 
            textNumRows.Location = new Point(198, 133);
            textNumRows.Name = "textNumRows";
            textNumRows.Size = new Size(150, 31);
            textNumRows.TabIndex = 7;
            // 
            // textSeatPRow
            // 
            textSeatPRow.Location = new Point(198, 170);
            textSeatPRow.Name = "textSeatPRow";
            textSeatPRow.Size = new Size(150, 31);
            textSeatPRow.TabIndex = 8;
            // 
            // textRowDivider
            // 
            textRowDivider.Location = new Point(198, 207);
            textRowDivider.Name = "textRowDivider";
            textRowDivider.Size = new Size(150, 31);
            textRowDivider.TabIndex = 9;
            // 
            // textColumnDivider
            // 
            textColumnDivider.Location = new Point(198, 244);
            textColumnDivider.Name = "textColumnDivider";
            textColumnDivider.Size = new Size(150, 31);
            textColumnDivider.TabIndex = 10;
            // 
            // buttonGenerateSeats
            // 
            buttonGenerateSeats.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonGenerateSeats.ForeColor = SystemColors.ActiveCaptionText;
            buttonGenerateSeats.Location = new Point(38, 328);
            buttonGenerateSeats.Name = "buttonGenerateSeats";
            buttonGenerateSeats.Size = new Size(310, 34);
            buttonGenerateSeats.TabIndex = 11;
            buttonGenerateSeats.Text = "Generate Seats";
            buttonGenerateSeats.UseVisualStyleBackColor = true;
            buttonGenerateSeats.Click += buttonGenerateSeats_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(38, 368);
            label5.Name = "label5";
            label5.Size = new Size(92, 25);
            label5.TabIndex = 12;
            label5.Text = "Max Seats";
            // 
            // textMaxSeats
            // 
            textMaxSeats.Location = new Point(147, 368);
            textMaxSeats.Name = "textMaxSeats";
            textMaxSeats.Size = new Size(201, 31);
            textMaxSeats.TabIndex = 13;
            // 
            // buttonEndSimulation
            // 
            buttonEndSimulation.BackColor = SystemColors.ButtonShadow;
            buttonEndSimulation.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEndSimulation.ForeColor = SystemColors.ActiveCaptionText;
            buttonEndSimulation.Location = new Point(38, 743);
            buttonEndSimulation.Name = "buttonEndSimulation";
            buttonEndSimulation.Size = new Size(310, 34);
            buttonEndSimulation.TabIndex = 18;
            buttonEndSimulation.Text = "End Simulation";
            buttonEndSimulation.UseVisualStyleBackColor = false;
            buttonEndSimulation.Click += buttonEndSimulation_Click;
            // 
            // groupBoxManualEditor
            // 
            groupBoxManualEditor.Controls.Add(radioDisable);
            groupBoxManualEditor.Controls.Add(radioEnable);
            groupBoxManualEditor.Controls.Add(buttonDisableAllSeats);
            groupBoxManualEditor.Controls.Add(buttonEnableAllSeats);
            groupBoxManualEditor.Controls.Add(buttonEditorMode);
            groupBoxManualEditor.Location = new Point(42, 783);
            groupBoxManualEditor.Name = "groupBoxManualEditor";
            groupBoxManualEditor.Size = new Size(300, 198);
            groupBoxManualEditor.TabIndex = 19;
            groupBoxManualEditor.TabStop = false;
            groupBoxManualEditor.Text = "Manual Editor";
            // 
            // radioDisable
            // 
            radioDisable.AutoSize = true;
            radioDisable.ForeColor = SystemColors.ActiveCaptionText;
            radioDisable.Location = new Point(171, 70);
            radioDisable.Name = "radioDisable";
            radioDisable.Size = new Size(95, 29);
            radioDisable.TabIndex = 4;
            radioDisable.TabStop = true;
            radioDisable.Text = "Disable";
            radioDisable.UseVisualStyleBackColor = true;
            // 
            // radioEnable
            // 
            radioEnable.AutoSize = true;
            radioEnable.ForeColor = SystemColors.ActiveCaptionText;
            radioEnable.Location = new Point(35, 70);
            radioEnable.Name = "radioEnable";
            radioEnable.Size = new Size(89, 29);
            radioEnable.TabIndex = 3;
            radioEnable.TabStop = true;
            radioEnable.Text = "Enable";
            radioEnable.UseVisualStyleBackColor = true;
            // 
            // buttonDisableAllSeats
            // 
            buttonDisableAllSeats.ForeColor = SystemColors.ActiveCaptionText;
            buttonDisableAllSeats.Location = new Point(57, 145);
            buttonDisableAllSeats.Name = "buttonDisableAllSeats";
            buttonDisableAllSeats.Size = new Size(181, 34);
            buttonDisableAllSeats.TabIndex = 2;
            buttonDisableAllSeats.Text = "Disable All";
            buttonDisableAllSeats.UseVisualStyleBackColor = true;
            buttonDisableAllSeats.Click += buttonDisableAllSeats_Click;
            // 
            // buttonEnableAllSeats
            // 
            buttonEnableAllSeats.ForeColor = SystemColors.ActiveCaptionText;
            buttonEnableAllSeats.Location = new Point(57, 105);
            buttonEnableAllSeats.Name = "buttonEnableAllSeats";
            buttonEnableAllSeats.Size = new Size(181, 34);
            buttonEnableAllSeats.TabIndex = 1;
            buttonEnableAllSeats.Text = "Enable All";
            buttonEnableAllSeats.UseVisualStyleBackColor = true;
            buttonEnableAllSeats.Click += buttonEnableAllSeats_Click;
            // 
            // buttonEditorMode
            // 
            buttonEditorMode.ForeColor = SystemColors.ActiveCaptionText;
            buttonEditorMode.Location = new Point(57, 30);
            buttonEditorMode.Name = "buttonEditorMode";
            buttonEditorMode.Size = new Size(181, 34);
            buttonEditorMode.TabIndex = 0;
            buttonEditorMode.Text = "Enter Editor Mode";
            buttonEditorMode.UseVisualStyleBackColor = true;
            buttonEditorMode.Click += buttonEditorMode_Click;
            // 
            // buttonResetSimulation
            // 
            buttonResetSimulation.BackColor = SystemColors.ButtonShadow;
            buttonResetSimulation.ForeColor = SystemColors.ActiveCaptionText;
            buttonResetSimulation.Location = new Point(42, 987);
            buttonResetSimulation.Name = "buttonResetSimulation";
            buttonResetSimulation.Size = new Size(300, 34);
            buttonResetSimulation.TabIndex = 20;
            buttonResetSimulation.Text = "Reset Simulation";
            buttonResetSimulation.UseVisualStyleBackColor = false;
            buttonResetSimulation.Click += buttonResetSimulation_Click;
            // 
            // textMessageStatus
            // 
            textMessageStatus.Location = new Point(44, 1037);
            textMessageStatus.Multiline = true;
            textMessageStatus.Name = "textMessageStatus";
            textMessageStatus.Size = new Size(298, 91);
            textMessageStatus.TabIndex = 21;
            // 
            // textNumPeople
            // 
            textNumPeople.Location = new Point(147, 282);
            textNumPeople.Name = "textNumPeople";
            textNumPeople.Size = new Size(201, 31);
            textNumPeople.TabIndex = 26;
            // 
            // labelNoOfPeople
            // 
            labelNoOfPeople.AutoSize = true;
            labelNoOfPeople.ForeColor = SystemColors.ActiveCaptionText;
            labelNoOfPeople.Location = new Point(38, 283);
            labelNoOfPeople.Name = "labelNoOfPeople";
            labelNoOfPeople.Size = new Size(103, 25);
            labelNoOfPeople.TabIndex = 25;
            labelNoOfPeople.Text = "# of People";
            // 
            // panelSeats
            // 
            panelSeats.BackColor = SystemColors.ControlLightLight;
            panelSeats.BorderStyle = BorderStyle.FixedSingle;
            panelSeats.Controls.Add(textScreen);
            panelSeats.Location = new Point(382, 48);
            panelSeats.Margin = new Padding(4, 5, 4, 5);
            panelSeats.Name = "panelSeats";
            panelSeats.Size = new Size(1167, 1092);
            panelSeats.TabIndex = 27;
            // 
            // textScreen
            // 
            textScreen.BackColor = Color.OrangeRed;
            textScreen.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            textScreen.Location = new Point(277, 32);
            textScreen.Name = "textScreen";
            textScreen.Size = new Size(660, 50);
            textScreen.TabIndex = 0;
            textScreen.Text = "Screen";
            textScreen.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonUndo
            // 
            buttonUndo.BackColor = SystemColors.ControlDark;
            buttonUndo.Location = new Point(38, 88);
            buttonUndo.Name = "buttonUndo";
            buttonUndo.Size = new Size(146, 34);
            buttonUndo.TabIndex = 28;
            buttonUndo.Text = "Undo";
            buttonUndo.UseVisualStyleBackColor = false;
            buttonUndo.Click += buttonUndo_Click;
            // 
            // buttonRedo
            // 
            buttonRedo.BackColor = SystemColors.ControlDark;
            buttonRedo.Location = new Point(198, 88);
            buttonRedo.Name = "buttonRedo";
            buttonRedo.Size = new Size(150, 34);
            buttonRedo.TabIndex = 29;
            buttonRedo.Text = "Redo";
            buttonRedo.UseVisualStyleBackColor = false;
            buttonRedo.Click += buttonRedo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1573, 1170);
            Controls.Add(buttonRedo);
            Controls.Add(buttonUndo);
            Controls.Add(panelSeats);
            Controls.Add(textMessageStatus);
            Controls.Add(textNumPeople);
            Controls.Add(buttonResetSimulation);
            Controls.Add(labelNoOfPeople);
            Controls.Add(groupBoxManualEditor);
            Controls.Add(buttonEndSimulation);
            Controls.Add(menuStrip1);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(label1);
            Controls.Add(textMaxSeats);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(buttonGenerateSeats);
            Controls.Add(label4);
            Controls.Add(textColumnDivider);
            Controls.Add(textNumRows);
            Controls.Add(textRowDivider);
            Controls.Add(textSeatPRow);
            Name = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBoxManualEditor.ResumeLayout(false);
            groupBoxManualEditor.PerformLayout();
            panelSeats.ResumeLayout(false);
            panelSeats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem simulationModeToolStripMenuItem;
        private ToolStripMenuItem normalModeToolStripMenuItem;
        private ToolStripMenuItem safeDistanceModeToolStripMenuItem;
        private ToolStripMenuItem safeDistanceSmartModeToolStripMenuItem;
        private Button buttonLoad;
        private Button buttonSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textNumRows;
        private TextBox textSeatPRow;
        private TextBox textRowDivider;
        private TextBox textColumnDivider;
        private Button buttonGenerateSeats;
        private Label label5;
        private TextBox textMaxSeats;
        private Button buttonEndSimulation;
        private GroupBox groupBoxManualEditor;
        private RadioButton radioDisable;
        private RadioButton radioEnable;
        private Button buttonDisableAllSeats;
        private Button buttonEnableAllSeats;
        private Button buttonEditorMode;
        private Button buttonResetSimulation;
        private TextBox textMessageStatus;
        private TextBox textNumPeople;
        private Label labelNoOfPeople;
        private Panel panelSeats;
        private TextBox textScreen;
        private Button buttonUndo;
        private Button buttonRedo;
    }
}
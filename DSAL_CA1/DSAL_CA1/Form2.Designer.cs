namespace DSAL_CA1
{
    partial class Form2
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
            buttonRedo = new Button();
            buttonUndo = new Button();
            panelSeats = new Panel();
            textScreen = new TextBox();
            textMessageStatus = new TextBox();
            textNumPeople = new TextBox();
            buttonResetSimulation = new Button();
            labelNoOfPeople = new Label();
            groupBoxManualEditor = new GroupBox();
            radioDisable = new RadioButton();
            radioEnable = new RadioButton();
            buttonDisableAllSeats = new Button();
            buttonEnableAllSeats = new Button();
            buttonEditorMode = new Button();
            buttonEndSimulation = new Button();
            buttonLoad = new Button();
            buttonSave = new Button();
            label1 = new Label();
            textMaxSeats = new TextBox();
            label2 = new Label();
            label5 = new Label();
            label3 = new Label();
            buttonGenerateSeats = new Button();
            label4 = new Label();
            textColumnDivider = new TextBox();
            textNumRows = new TextBox();
            textRowDivider = new TextBox();
            textSeatPRow = new TextBox();
            buttonSafeDistMode = new Button();
            panelSeats.SuspendLayout();
            groupBoxManualEditor.SuspendLayout();
            SuspendLayout();
            // 
            // buttonRedo
            // 
            buttonRedo.BackColor = SystemColors.ControlDark;
            buttonRedo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRedo.Location = new Point(133, 45);
            buttonRedo.Margin = new Padding(2);
            buttonRedo.Name = "buttonRedo";
            buttonRedo.Size = new Size(105, 20);
            buttonRedo.TabIndex = 51;
            buttonRedo.Text = "Redo";
            buttonRedo.UseVisualStyleBackColor = false;
            buttonRedo.Click += buttonRedo_Click;
            // 
            // buttonUndo
            // 
            buttonUndo.BackColor = SystemColors.ControlDark;
            buttonUndo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUndo.Location = new Point(21, 45);
            buttonUndo.Margin = new Padding(2);
            buttonUndo.Name = "buttonUndo";
            buttonUndo.Size = new Size(102, 20);
            buttonUndo.TabIndex = 50;
            buttonUndo.Text = "Undo";
            buttonUndo.UseVisualStyleBackColor = false;
            buttonUndo.Click += buttonUndo_Click;
            // 
            // panelSeats
            // 
            panelSeats.BackColor = SystemColors.ControlLightLight;
            panelSeats.BorderStyle = BorderStyle.FixedSingle;
            panelSeats.Controls.Add(textScreen);
            panelSeats.Location = new Point(261, 21);
            panelSeats.Name = "panelSeats";
            panelSeats.Size = new Size(1022, 656);
            panelSeats.TabIndex = 49;
            // 
            // textScreen
            // 
            textScreen.BackColor = Color.OrangeRed;
            textScreen.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            textScreen.Location = new Point(167, 23);
            textScreen.Margin = new Padding(2);
            textScreen.Name = "textScreen";
            textScreen.Size = new Size(698, 36);
            textScreen.TabIndex = 0;
            textScreen.Text = "Screen";
            textScreen.TextAlign = HorizontalAlignment.Center;
            // 
            // textMessageStatus
            // 
            textMessageStatus.Location = new Point(25, 614);
            textMessageStatus.Margin = new Padding(2);
            textMessageStatus.Multiline = true;
            textMessageStatus.Name = "textMessageStatus";
            textMessageStatus.Size = new Size(210, 56);
            textMessageStatus.TabIndex = 46;
            // 
            // textNumPeople
            // 
            textNumPeople.Location = new Point(97, 179);
            textNumPeople.Margin = new Padding(2);
            textNumPeople.Name = "textNumPeople";
            textNumPeople.Size = new Size(142, 23);
            textNumPeople.TabIndex = 48;
            // 
            // buttonResetSimulation
            // 
            buttonResetSimulation.BackColor = SystemColors.ButtonShadow;
            buttonResetSimulation.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonResetSimulation.ForeColor = SystemColors.ActiveCaptionText;
            buttonResetSimulation.Location = new Point(23, 584);
            buttonResetSimulation.Margin = new Padding(2);
            buttonResetSimulation.Name = "buttonResetSimulation";
            buttonResetSimulation.Size = new Size(210, 20);
            buttonResetSimulation.TabIndex = 45;
            buttonResetSimulation.Text = "Reset Simulation";
            buttonResetSimulation.UseVisualStyleBackColor = false;
            buttonResetSimulation.Click += buttonResetSimulation_Click;
            // 
            // labelNoOfPeople
            // 
            labelNoOfPeople.AutoSize = true;
            labelNoOfPeople.ForeColor = SystemColors.ActiveCaptionText;
            labelNoOfPeople.Location = new Point(21, 180);
            labelNoOfPeople.Margin = new Padding(2, 0, 2, 0);
            labelNoOfPeople.Name = "labelNoOfPeople";
            labelNoOfPeople.Size = new Size(67, 15);
            labelNoOfPeople.TabIndex = 47;
            labelNoOfPeople.Text = "# of People";
            // 
            // groupBoxManualEditor
            // 
            groupBoxManualEditor.Controls.Add(radioDisable);
            groupBoxManualEditor.Controls.Add(radioEnable);
            groupBoxManualEditor.Controls.Add(buttonDisableAllSeats);
            groupBoxManualEditor.Controls.Add(buttonEnableAllSeats);
            groupBoxManualEditor.Controls.Add(buttonEditorMode);
            groupBoxManualEditor.Location = new Point(23, 462);
            groupBoxManualEditor.Margin = new Padding(2);
            groupBoxManualEditor.Name = "groupBoxManualEditor";
            groupBoxManualEditor.Padding = new Padding(2);
            groupBoxManualEditor.Size = new Size(210, 119);
            groupBoxManualEditor.TabIndex = 44;
            groupBoxManualEditor.TabStop = false;
            groupBoxManualEditor.Text = "Manual Editor";
            // 
            // radioDisable
            // 
            radioDisable.AutoSize = true;
            radioDisable.ForeColor = SystemColors.ActiveCaptionText;
            radioDisable.Location = new Point(119, 41);
            radioDisable.Margin = new Padding(2);
            radioDisable.Name = "radioDisable";
            radioDisable.Size = new Size(63, 19);
            radioDisable.TabIndex = 4;
            radioDisable.TabStop = true;
            radioDisable.Text = "Disable";
            radioDisable.UseVisualStyleBackColor = true;
            // 
            // radioEnable
            // 
            radioEnable.AutoSize = true;
            radioEnable.ForeColor = SystemColors.ActiveCaptionText;
            radioEnable.Location = new Point(23, 41);
            radioEnable.Margin = new Padding(2);
            radioEnable.Name = "radioEnable";
            radioEnable.Size = new Size(60, 19);
            radioEnable.TabIndex = 3;
            radioEnable.TabStop = true;
            radioEnable.Text = "Enable";
            radioEnable.UseVisualStyleBackColor = true;
            // 
            // buttonDisableAllSeats
            // 
            buttonDisableAllSeats.ForeColor = SystemColors.ActiveCaptionText;
            buttonDisableAllSeats.Location = new Point(40, 87);
            buttonDisableAllSeats.Margin = new Padding(2);
            buttonDisableAllSeats.Name = "buttonDisableAllSeats";
            buttonDisableAllSeats.Size = new Size(127, 20);
            buttonDisableAllSeats.TabIndex = 2;
            buttonDisableAllSeats.Text = "Disable All";
            buttonDisableAllSeats.UseVisualStyleBackColor = true;
            buttonDisableAllSeats.Click += buttonDisableAllSeats_Click;
            // 
            // buttonEnableAllSeats
            // 
            buttonEnableAllSeats.ForeColor = SystemColors.ActiveCaptionText;
            buttonEnableAllSeats.Location = new Point(40, 63);
            buttonEnableAllSeats.Margin = new Padding(2);
            buttonEnableAllSeats.Name = "buttonEnableAllSeats";
            buttonEnableAllSeats.Size = new Size(127, 20);
            buttonEnableAllSeats.TabIndex = 1;
            buttonEnableAllSeats.Text = "Enable All";
            buttonEnableAllSeats.UseVisualStyleBackColor = true;
            buttonEnableAllSeats.Click += buttonEnableAllSeats_Click;
            // 
            // buttonEditorMode
            // 
            buttonEditorMode.ForeColor = SystemColors.ActiveCaptionText;
            buttonEditorMode.Location = new Point(40, 18);
            buttonEditorMode.Margin = new Padding(2);
            buttonEditorMode.Name = "buttonEditorMode";
            buttonEditorMode.Size = new Size(127, 20);
            buttonEditorMode.TabIndex = 0;
            buttonEditorMode.Text = "Enter Editor Mode";
            buttonEditorMode.UseVisualStyleBackColor = true;
            buttonEditorMode.Click += buttonEditorMode_Click;
            // 
            // buttonEndSimulation
            // 
            buttonEndSimulation.BackColor = SystemColors.ButtonShadow;
            buttonEndSimulation.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEndSimulation.ForeColor = SystemColors.ActiveCaptionText;
            buttonEndSimulation.Location = new Point(21, 438);
            buttonEndSimulation.Margin = new Padding(2);
            buttonEndSimulation.Name = "buttonEndSimulation";
            buttonEndSimulation.Size = new Size(217, 20);
            buttonEndSimulation.TabIndex = 43;
            buttonEndSimulation.Text = "End Simulation";
            buttonEndSimulation.UseVisualStyleBackColor = false;
            buttonEndSimulation.Click += buttonEndSimulation_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = SystemColors.ButtonShadow;
            buttonLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLoad.ForeColor = SystemColors.ActiveCaptionText;
            buttonLoad.Location = new Point(21, 21);
            buttonLoad.Margin = new Padding(2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(102, 20);
            buttonLoad.TabIndex = 30;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = false;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = SystemColors.ButtonShadow;
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSave.ForeColor = SystemColors.ActiveCaptionText;
            buttonSave.Location = new Point(133, 21);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(105, 20);
            buttonSave.TabIndex = 31;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(21, 75);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 32;
            label1.Text = "Number of Rows";
            // 
            // textMaxSeats
            // 
            textMaxSeats.Location = new Point(94, 265);
            textMaxSeats.Margin = new Padding(2);
            textMaxSeats.Name = "textMaxSeats";
            textMaxSeats.Size = new Size(142, 23);
            textMaxSeats.TabIndex = 42;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(21, 101);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 33;
            label2.Text = "Seats per Row";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(21, 268);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 41;
            label5.Text = "Max Seats";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(21, 128);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 34;
            label3.Text = "Row Divider (s)";
            // 
            // buttonGenerateSeats
            // 
            buttonGenerateSeats.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonGenerateSeats.ForeColor = SystemColors.ActiveCaptionText;
            buttonGenerateSeats.Location = new Point(20, 208);
            buttonGenerateSeats.Margin = new Padding(2);
            buttonGenerateSeats.Name = "buttonGenerateSeats";
            buttonGenerateSeats.Size = new Size(218, 20);
            buttonGenerateSeats.TabIndex = 40;
            buttonGenerateSeats.Text = "Generate Seats";
            buttonGenerateSeats.UseVisualStyleBackColor = true;
            buttonGenerateSeats.Click += buttonGenerateSeats_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(18, 154);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 35;
            label4.Text = "Column Divider (s)";
            // 
            // textColumnDivider
            // 
            textColumnDivider.Location = new Point(133, 152);
            textColumnDivider.Margin = new Padding(2);
            textColumnDivider.Name = "textColumnDivider";
            textColumnDivider.Size = new Size(106, 23);
            textColumnDivider.TabIndex = 39;
            // 
            // textNumRows
            // 
            textNumRows.Location = new Point(133, 72);
            textNumRows.Margin = new Padding(2);
            textNumRows.Name = "textNumRows";
            textNumRows.Size = new Size(106, 23);
            textNumRows.TabIndex = 36;
            // 
            // textRowDivider
            // 
            textRowDivider.Location = new Point(133, 126);
            textRowDivider.Margin = new Padding(2);
            textRowDivider.Name = "textRowDivider";
            textRowDivider.Size = new Size(106, 23);
            textRowDivider.TabIndex = 38;
            // 
            // textSeatPRow
            // 
            textSeatPRow.Location = new Point(133, 99);
            textSeatPRow.Margin = new Padding(2);
            textSeatPRow.Name = "textSeatPRow";
            textSeatPRow.Size = new Size(106, 23);
            textSeatPRow.TabIndex = 37;
            // 
            // buttonSafeDistMode
            // 
            buttonSafeDistMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSafeDistMode.Location = new Point(21, 233);
            buttonSafeDistMode.Name = "buttonSafeDistMode";
            buttonSafeDistMode.Size = new Size(217, 23);
            buttonSafeDistMode.TabIndex = 53;
            buttonSafeDistMode.Text = "Set Up Safe Distance Mode";
            buttonSafeDistMode.UseVisualStyleBackColor = true;
            buttonSafeDistMode.Click += buttonSafeDistMode_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1311, 692);
            Controls.Add(buttonSafeDistMode);
            Controls.Add(buttonRedo);
            Controls.Add(buttonUndo);
            Controls.Add(panelSeats);
            Controls.Add(textMessageStatus);
            Controls.Add(textNumPeople);
            Controls.Add(buttonResetSimulation);
            Controls.Add(labelNoOfPeople);
            Controls.Add(groupBoxManualEditor);
            Controls.Add(buttonEndSimulation);
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
            Margin = new Padding(2);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            panelSeats.ResumeLayout(false);
            panelSeats.PerformLayout();
            groupBoxManualEditor.ResumeLayout(false);
            groupBoxManualEditor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonRedo;
        private Button buttonUndo;
        private Panel panelSeats;
        private TextBox textScreen;
        private TextBox textMessageStatus;
        private TextBox textNumPeople;
        private Button buttonResetSimulation;
        private Label labelNoOfPeople;
        private GroupBox groupBoxManualEditor;
        private RadioButton radioDisable;
        private RadioButton radioEnable;
        private Button buttonDisableAllSeats;
        private Button buttonEnableAllSeats;
        private Button buttonEditorMode;
        private Button buttonEndSimulation;
        private Button buttonLoad;
        private Button buttonSave;
        private Label label1;
        private TextBox textMaxSeats;
        private Label label2;
        private Label label5;
        private Label label3;
        private Button buttonGenerateSeats;
        private Label label4;
        private TextBox textColumnDivider;
        private TextBox textNumRows;
        private TextBox textRowDivider;
        private TextBox textSeatPRow;
        private Button buttonSafeDistMode;
    }
}